(function () {
    $(function () {
        var _$jobsTable = $('#SalaryTable');
        var service = abp.services.app.employee;


        var _permissions = {
            create: abp.auth.hasPermission('Pages.Pim.Employee.Create'),
            edit: abp.auth.hasPermission('Pages.Pim.Employee.Edit'),
            'delete': abp.auth.hasPermission('Pages.Pim.Employee.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditSalaryCompunentModal/?employeeId=' + app.currentEmployeeId,
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/EmployeeDetail/Salary/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditSalaryModal'
        });

        _$jobsTable.jtable({
            jqueryuiTheme: true,

            title: L('SalaryCompunents'),

            actions: {
                listAction: {
                    method: service.getSalaryViews
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
                                    deleteSelery(data.record);
                                });
                        }

                        return $span;
                    }
                },
                salaryComponent: {
                    title: L('SalaryComponent'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.salaryComponent + " &nbsp; ");

                        return $span;
                    }
                },
                payGrade: {
                    title: L('PayGrade'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.payGrade + " &nbsp; ");

                        return $span;
                    }
                },
                payFrequency: {
                    title: L('PayFrequency'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.payFrequency + " &nbsp; ");

                        return $span;
                    }
                },
                currency: {
                    title: L('Currency'),
                    width: '10%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.currency + " &nbsp; ");

                        return $span;
                    }
                },
                amount: {
                    title: L('Amount'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.amount + " &nbsp; ");

                        return $span;
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

        function deleteSelery(salary) {
            abp.message.confirm(
                L('DeleteWarningMessage', salary.salaryComponent),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteSalary({
                            salaryId: salary.id
                        }).done(function (result) {
                            getImmigrations();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewSalaryButton').click(function () {
            _createOrEditModal.open();
        });

        function getImmigrations() {
            _$jobsTable.jtable('load', {employeeId: app.currentEmployeeId});
        }

        abp.event.on('app.createOrEditSalaryModalSaved', function () {
            getImmigrations();
        });

        getImmigrations();
    });
})();