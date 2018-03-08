(function () {
    $(function () {

        var _$employeeListTable = $('#EmployeeListTable');
        var _service = abp.services.app.employee;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Pim.Employee.Create'),
            edit: abp.auth.hasPermission('Pages.Pim.Employee.Edit'),
            'delete': abp.auth.hasPermission('Pages.Pim.Employee.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditEmployeeModal'
        });

        function getEmployees(reload) {
            if (reload) {
                _$employeeListTable.jtable('reload');
            } else {
                _$employeeListTable.jtable('load', {
                    filter: $('#EmployeeListTableFilter').val()
                });
            }
        }

        function deleteEmployee(user) {
            if (user.userName == app.consts.userManagement.defaultAdminUserName) {
                abp.message.warn(app.localize("{0}UserCannotBeDeleted", app.consts.userManagement.defaultAdminUserName));
                return;
            }

            abp.message.confirm(
                app.localize('UserDeleteWarningMessage', user.userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteUser({
                            id: user.id
                        }).done(function () {
                            getEmployees(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }
        
        _$employeeListTable.jtable({
            jqueryuiTheme: true,

            title: L('EmployeeList'),
            paging: true
            ,
            sorting: true,
            multiSorting: true,

            actions: {
                listAction: {
                    method: _service.getEmployees
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
                    display: function(data) {
                        var $span = $('<span></span>');

                        if (_permissions.edit) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Manage') + '"><i class="fa fa-eye"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    window.location.href = '/pim/EmployeeList/detail/' + data.record.number;
                                //_createOrEditModal.open({ id: data.record.id });
                            });
                        }
                        
                        if (_permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function() {
                                    deleteEmployee(data.record);
                                });
                        }

                        return $span;
                    }
                },
                number: {
                    title: L('Number'),
                    width: '15%'
                },
                firstName: {
                    title: L('Name'),
                    width: '20%'
                },
                lastName: {
                    title: L('Surname'),
                    width: '20%'
                },
                gender: {
                    title: L('Gender'),
                    width: '15%',
                    display: function (data) {
                        if (data.record.gender === 0) { return "Female" }
                        return 'Male';
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


        $('#CreateNewEmployeeButton').click(function () {
            _createOrEditModal.open();
        });

        $('#ExportUsersToExcelButton').click(function () {
            _service
                .getUsersToExcel({})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        $('#PrintEmpleeListButton').click(function () {
            printDiv("EmployeeListTable");
        });

        

        $('#GetEmployeeListButton').click(function (e) {
            e.preventDefault();
            getEmployees();
        });

        abp.event.on('app.createOrEditEmployeeModalSaved', function () {
            getEmployees(true);
        });
        
        getEmployees();

        $('#EmployeeListTableFilter').focus();
    });
})();