(function () {
    $(function () {
        var _$employeeStatusesTable = $('#EmployeeStatusesTable');
        var jobConfigurationService = abp.services.app.jobConfiguration;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.EmployeeStatus.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.EmployeeStatus.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.EmployeeStatus.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/EmployeeStatuses/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/EmployeeStatuses/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditEmployeeStatusModal'
        });

        _$employeeStatusesTable.jtable({
            jqueryuiTheme: true,

            title: L('EmployeeStatuses'),

            actions: {
                listAction: {
                    method: jobConfigurationService.getEmploymentStatuses
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '30%',
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
                                    deleteEmployeeStatus(data.record);
                                });
                        }

                        return $span;
                    }
                },
                title: {
                    title: L('Name'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.name + " &nbsp; ");

                        return $span;
                    }
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '35%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        function deleteEmployeeStatus(employeeStatus) {
            abp.message.confirm(
                L('DeleteEmployeeStatusWarningMessage', employeeStatus.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        jobConfigurationService.deleteEmploymentStatus({
                            id: employeeStatus.id
                        }).done(function (result) {
                            getEmployeeStatuses(); 
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewEmployeeStatusButton').click(function () {
            _createOrEditModal.open();
        });

        function getEmployeeStatuses() {
            _$employeeStatusesTable.jtable('load');
        }

        abp.event.on('app.createOrEditEmployeeStatusModalSaved', function () {
            getEmployeeStatuses();
        });

        getEmployeeStatuses();
    });
})();