(function () {
    $(function () {
        var _$jobsTable = $('#DependantsTable');
        var service = abp.services.app.employee;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditDependantModal/?employeeId=' + app.currentEmployeeId,
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/EmployeeDetail/Dependants/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditDependantModal'
        });

        _$jobsTable.jtable({
            jqueryuiTheme: true,

            title: L('Dependants'),

            actions: {
                listAction: {
                    method: service.getDependants
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
                                    deleteDependant(data.record);
                                });
                        }

                        return $span;
                    }
                },
                name: {
                    title: L('Name'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.name + " &nbsp; ");

                        return $span;
                    }
                },
                relationship: {
                    title: L('Relationship'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');
                        
                        if (data.record.relationship == 0) {
                            $span.append("Child &nbsp; ");
                        } else {
                            $span.append("Others &nbsp; ");
                        }

                        return $span;
                    }
                },
                dateOfBirth: {
                    title: L('DateOfBirth'),
                    width: '20%',
                    display: function (data) {
                        return moment(data.record.dateOfBirth).format('L');
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

        function deleteDependant(dependant) {
            abp.message.confirm(
                L('DeleteWarningMessage', dependant.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteDependant({
                            dependantId: dependant.id
                        }).done(function (result) {
                            getDependants();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewDependantButton').click(function () {
            _createOrEditModal.open();
        });

        function getDependants() {
            _$jobsTable.jtable('load', {employeeId: app.currentEmployeeId});
        }

        abp.event.on('app.createOrEditDependantModalSaved', function () {
            getDependants();
        });

        getDependants();
    });
})();