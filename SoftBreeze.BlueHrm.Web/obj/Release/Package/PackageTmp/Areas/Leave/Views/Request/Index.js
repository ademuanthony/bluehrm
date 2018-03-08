(function () {
    $(function () {
        var supervisorTable = $('#RequestsTable');
        var service = abp.services.app.leave;


        var searchForm = $('#LoadRequestForm');
        searchForm.validate({ ignore: "" }); 

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Leave.LeaveRequest.MakeRequest'),
            approve: abp.auth.hasPermission('Pages.Leave.LeaveRequest.Approve'),
            reject: abp.auth.hasPermission('Pages.Leave.LeaveRequest.Reject'),
            'delete': abp.auth.hasPermission('Pages.Leave.LeaveRequest.Delete'),
            deleteAny: abp.auth.hasPermission('Pages.Leave.LeaveRequest.DeleteAny')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Leave/Request/MakeRequest/',
            scriptUrl: abp.appPath + 'Areas/Leave/Views/Request/_MakeRequest.js',
            modalClass: 'MakeRequestModal'
        });
        
        function getRequests() {
            supervisorTable.jtable('load', searchForm.serializeFormToObject());
        }

        function approveRequest(request) {
            abp.message.confirm(
                L("ApproveLeaveRequestWarning"),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.approveLeaveRequest({
                            leaveRequestId: request.id
                        }).done(function (result) {
                            getRequests();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        }

        function rejectRequest(request) {
            abp.message.confirm(
                L('RejectLeaveRequestWarning'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.rejectLeaveRequest({
                            leaveRequestId: request.id
                        }).done(function (result) {
                            getRequests();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        }

        function deleteRequest(request) {
            abp.message.confirm(
                L('DeleteWarningMessage', "This Leave Reject"),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteLeaveRequest({
                            leaveRequestId: request.id
                        }).done(function (result) {
                            getRequests();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        }

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('LeaveRequests'),
            paging: true
            ,
            sorting: true,
            multiSorting: true,

            actions: {
                listAction: {
                    method: service.getLeaveRequests
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '10%',
                    sorting: false,
                    list: _permissions.approve || _permissions.reject || _permissions.delete || _permissions.deleteAny,
                    display: function (data) {
                        var $span = $('<span></span>');

                        if (_permissions.approve && data.record.status === 1) {
                            $('<button class="btn btn-default btn-xs green" title="' + L('Approve') + '"><i class="fa fa-check"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    approveRequest(data.record);
                                });
                        }

                        if (_permissions.reject && data.record.status === 1) {
                            $('<button class="btn btn-default btn-xs red" title="' + L('Reject') + '"><i class="fa fa-times"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    rejectRequest(data.record);
                                });
                        }

                        if ((_permissions.delete || _permissions.deleteAny) && data.record.status !== 1) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteRequest(data.record);
                                });
                        }

                        return $span;
                    }
                },
                employee: {
                    title: L('Employee'),
                    width: '20%'
                },
                leaveType: {
                    title: L('LeaveType'),
                    width: '10%'
                },
                startDate: {
                    title: L('StartDate'),
                    width: '15%',
                    display: function (data) {
                        return moment(data.record.startDate).format('L');
                    }
                },
                endDate: {
                    title: L('EndDate'),
                    width: '15%',
                    display: function (data) {
                        return moment(data.record.endDate).format('L');
                    }
                },
                status: {
                    title: L('Status'),
                    width: '15%',
                    display: function (data) {
                        return data.record.status === 1 ? "Pending" : data.record.status === 2? "Approved": "Rejected";
                    }
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '15%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });
        
        $('#MakeRequestButton').click(function () {
            _createOrEditModal.open();
        });

        $('#LoadButton').click(function (e) {
            e.preventDefault();
            if (!searchForm.valid()) {
                return;
            }
            getRequests();
            return;
        });


        abp.event.on('app.createOrEditLeaveRequestModalSaved', function () {
            getRequests();
        });

        getRequests();
    });
})();