(function () {
    $(function () {
        var supervisorTable = $('#EntitlementsTable');
        var service = abp.services.app.leave;


        var searchForm = $('#LoadEntitlementForm');
        searchForm.validate({ ignore: "" });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Leave.LeaveEntitlements.Create'),
            edit: abp.auth.hasPermission('Pages.Leave.LeaveEntitlements.Edit'),
            'delete': abp.auth.hasPermission('Pages.Leave.LeaveEntitlements.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Leave/Entitlements/CreateOrEditModal/',
            scriptUrl: abp.appPath + 'Areas/Leave/Views/Entitlements/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModal'
        });
        
        function getEntitlements() {
            supervisorTable.jtable('load', searchForm.serializeFormToObject());
        }

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('Entitlements'),

            actions: {
                listAction: {
                    method: service.getLeaveEntitlementDos
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        if (_permissions.edit) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Edit') + '"><i class="fa fa-edit"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    _createOrEditModal.open({ id: data.record.id });
                                });
                        }

                        if (!data.record.isStatic && _permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteEntitlement(data.record);
                                });
                        }

                        return $span;
                    }
                },
                employeeNumber: {
                    title: L('EmployeeNumber'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.employeeNumber + " &nbsp; ");

                        return $span;
                    }
                },
                leaveType: {
                    title: L('LeaveType'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.leaveType + " &nbsp; ");

                        return $span;
                    }
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
                numberOfDays: {
                    title: L('NumberOfDays'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.numberOfDays + " &nbsp; ");

                        return $span;
                    }
                }
            }

        }); 

        function deleteEntitlement(entitlement) {
            abp.message.confirm(
                L('DeleteWarningMessage', "This Leave"),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteEntitlement({
                            leaveEntitlementId: entitlement.id
                        }).done(function (result) {
                            getEntitlements();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewLeaveTypeButton').click(function () {
            _createOrEditModal.open();
        });

        $('#LoadButton').click(function () {
            if (!searchForm.valid()) {
                return false;
            }
            getEntitlements();
        });


        abp.event.on('app.createOrEditLeaveEntitlementModalSaved', function () {
            getEntitlements();
        });

        getEntitlements();
    });
})();