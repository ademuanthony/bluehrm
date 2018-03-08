(function () {
    $(function () {
        var supervisorTable = $('#SupervisorsTable');
        var service = abp.services.app.employee;


        var _permissions = {
            create: abp.auth.hasPermission('Pages.Pim.Employee.Create'),
            edit: abp.auth.hasPermission('Pages.Pim.Employee.Edit'),
            'delete': abp.auth.hasPermission('Pages.Pim.Employee.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditSupervisorModal/?employeeId=' + app.currentEmployeeId,
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/EmployeeDetail/Supervisors/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditSupervisorModal'
        });

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('Supervisors'),

            actions: {
                listAction: {
                    method: service.getSupervisorDos
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '25%',
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
                                    deleteSupervisor(data.record);
                                });
                        }

                        return $span;
                    }
                },
                name: {
                    title: L('Name'),
                    width: '55%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.name + " &nbsp; ");

                        return $span;
                    }
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '20%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        function deleteSupervisor(supervisor) {
            abp.message.confirm(
                L('DeleteWarningMessage', supervisor.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteSupervisor({
                            supervisorId: supervisor.id
                        }).done(function (result) {
                            getSupervisors();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewSupervisorButton').click(function () {
            _createOrEditModal.open();
        });

        function getSupervisors() {
            supervisorTable.jtable('load', {employeeId: app.currentEmployeeId});
        }

        abp.event.on('app.createOrEditSupervisorModalSaved', function () {
            getSupervisors();
        });

        getSupervisors();
    });
})();