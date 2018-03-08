(function () {
    $(function () {
        var _$jobsTable = $('#ContactsTable');
        var service = abp.services.app.employee;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Pim/EmployeeList/CreateOrEditEmergencyContactModal/?employeeId=' + app.currentEmployeeId,
            scriptUrl: abp.appPath + 'Areas/Pim/Views/EmployeeList/EmployeeDetail/EmergencyContacts/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditJobTitleModal'
        });

        _$jobsTable.jtable({
            jqueryuiTheme: true,

            title: L('EmergencyContacts'),

            actions: {
                listAction: {
                    method: service.getEmployeeEmergencyContacts
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
                                    deleteContact(data.record);
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

                        $span.append(data.record.relationship + " &nbsp; ");

                        return $span;
                    }
                },
                mobilePhoneNumber: {
                    title: L('MobilePhoneNumber'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.mobilePhoneNumber + " &nbsp; ");

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

        function deleteContact(contact) {
            abp.message.confirm(
                L('DeleteWarningMessage', contact.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteJob({
                            jobId: contact.id
                        }).done(function (result) {
                            getContacts();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewContactButton').click(function () {
            _createOrEditModal.open();
        });

        function getContacts() {
            _$jobsTable.jtable('load', {employeeId: app.currentEmployeeId});
        }

        abp.event.on('app.createOrEditContactModalSaved', function () {
            getContacts();
        });

        getContacts();
    });
})();