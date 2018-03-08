(function () {
    $(function () {
        var supervisorTable = $('#EducationsTable');
        var service = abp.services.app.employee;


        var _permissions = {
            create: abp.auth.hasPermission('Pages.Pim.Employee.Create'),
            edit: abp.auth.hasPermission('Pages.Pim.Employee.Edit'),
            'delete': abp.auth.hasPermission('Pages.Pim.Employee.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditQualificationModal/?employeeId=' + app.currentEmployeeId,
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/EmployeeDetail/Qualification/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditQualificationModal'
        });

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('Qualifications'),

            actions: {
                listAction: {
                    method: service.getEducations
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
                                    deleteEducation(data.record);
                                });
                        }

                        return $span;
                    }
                },
                institution: {
                    title: L('Institution'),
                    width: '30%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.institution + " &nbsp; ");

                        return $span;
                    }
                },
                specialization: {
                    title: L('Specialization'),
                    width: '30%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.specialization + " &nbsp; ");

                        return $span;
                    }
                },
                year: {
                    title: L('Year'),
                    width: '10%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.year + " &nbsp; ");

                        return $span;
                    }
                },
                score: {
                    title: L('Score'),
                    width: '10%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.score + " &nbsp; ");

                        return $span;
                    }
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

        function deleteEducation(education) {
            abp.message.confirm(
                L('DeleteWarningMessage', education.institution),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteEducation({
                            educationId: education.id
                        }).done(function (result) {
                            getEducations();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewEducationButton').click(function () {
            _createOrEditModal.open();
        });

        function getEducations() {
            supervisorTable.jtable('load', {employeeId: app.currentEmployeeId});
        }

        abp.event.on('app.createOrEditQualificationModalSaved', function () {
            getEducations();
        });

        getEducations();
    });
})();