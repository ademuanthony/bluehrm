(function () {
    $(function () {
        var _$employeeListTable = $('#LeaveListTable');
        var _service = abp.services.app.leave;
        var form = $("#LoadLeaveForm");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Leaves.Create'),
            edit: abp.auth.hasPermission('Pages.Leaves.Edit'),
            'delete': abp.auth.hasPermission('Pages.Leaves.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Leave/LeaveList/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Leave/Views/LeaveList/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModal'
        });

        _$employeeListTable.jtable({
            jqueryuiTheme: true,

            title: L('LeaveList'),
            paging: true,
            sorting: true,
            multiSorting: true,

            actions: {
                listAction: {
                    method: _service.getLeaves
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
                    list: _permissions.edit || _permissions.delete,
                    display: function (data) {
                        var $span = $('<span></span>');

                        //if (_permissions.edit) {
                        //    $('<button class="btn btn-default btn-xs" title="' + L('Manage') + '"><i class="fa fa-eye"></i></button>')
                        //        .appendTo($span)
                        //        .click(function () {
                        //            _createOrEditModal.open({ id: data.record.id });
                        //        });
                        //}

                        if (_permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteLeave(data.record);
                                });
                        }

                        return $span;
                    }
                },
                date: {
                    title: L('Date'),
                    width: '15%'
                },
                employeeName: {
                    title: L('EmployeeName'),
                    width: '20%'
                },
                leaveType: {
                    title: L('LeaveType'),
                    width: '15%'
                },
                numberOfDays: {
                    title: L('NumberOfDays'),
                    width: '15%'
                },
                status: {
                    title: L('Status'),
                    width: '15%'
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '10%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        function getLeaves(reload) {
            if (reload) {
                _$employeeListTable.jtable('reload');
            } else {
                _$employeeListTable.jtable('load', form.serializeFormToObject());
            }
        }

        function deleteLeave(leave) {

            abp.message.confirm(
                L('DeleteWarningMessage', 'The assigned ' + leave.leaveType),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteLeave({
                            leaveId: leave.id
                        }).done(function () {
                            getLeaves(true);
                            abp.notify.success(L('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

        $('#AssignLeaveButton').click(function () {
            _createOrEditModal.open();
        });

        $('#LoadButton').click(function (e) {
            e.preventDefault();
            getLeaves();
        });

        abp.event.on('app.createOrEditLeaveModalSaved', function () {
            getLeaves(true);
        });

        getLeaves();

    });
})();