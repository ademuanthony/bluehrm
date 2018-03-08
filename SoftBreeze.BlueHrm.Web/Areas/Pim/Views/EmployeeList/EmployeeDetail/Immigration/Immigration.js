(function () {
    $(function () {
        var _$jobsTable = $('#ImmigrationTable');
        var service = abp.services.app.employee;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditImmigrationModal/?employeeId=' + app.currentEmployeeId,
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/EmployeeDetail/Immigration/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditImmigrationModal'
        });

        _$jobsTable.jtable({
            jqueryuiTheme: true,

            title: L('Immigration'),

            actions: {
                listAction: {
                    method: service.getImmigrations
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '15%',
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
                                    deleteImmigration(data.record);
                                });
                        }

                        return $span;
                    }
                },
                number: {
                    title: L('Number'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.number + " &nbsp; ");

                        return $span;
                    }
                },
                document: {
                    title: L('Document Type'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');
                        
                        if (data.record.document == 0) {
                            $span.append("Passport &nbsp; ");
                        } else {
                            $span.append("Visa &nbsp; ");
                        }

                        return $span;
                    }
                },
                issueDate: {
                    title: L('IssueDate'),
                    width: '20%',
                    display: function (data) {
                        return moment(data.record.issueDate).format('L');
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

        function deleteImmigration(immigration) {
            abp.message.confirm(
                L('DeleteWarningMessage', immigration.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteImmigration({
                            immigrationId: immigration.id
                        }).done(function (result) {
                            getImmigrations();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewImmigrationButton').click(function () {
            _createOrEditModal.open();
        });

        function getImmigrations() {
            _$jobsTable.jtable('load', {employeeId: app.currentEmployeeId});
        }

        abp.event.on('app.createOrEditImmigrationModalSaved', function () {
            getImmigrations();
        });

        getImmigrations();
    });
})();