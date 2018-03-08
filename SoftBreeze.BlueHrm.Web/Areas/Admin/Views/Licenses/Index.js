(function () {
    $(function () {
        var _$table = $('#LicensesTable');
        var _service = abp.services.app.qualification;
        
        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Qualification.License.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Qualification.License.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Qualification.License.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Licenses/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Licenses/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditLicensesModal'
        });
        
        _$table.jtable({
            jqueryuiTheme: true,

            title: L('Licenses'),

            actions: {
                listAction: {
                    method: _service.getLicenseTypes
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
                                    deleteLicense(data.record);
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
                creationTime: {
                    title: L('CreationTime'),
                    width: '35%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        function deleteLicense(license) {
            abp.message.confirm(
                L('DeleteEducationalLevelWarningMessage', license.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteLicenseType({
                            licenseTypeId: license.id
                        }).done(function (result) {
                            loadData();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewLicenseButton').click(function () {
            _createOrEditModal.open();
        });

        function loadData() {
            _$table.jtable('load');
        }

        abp.event.on('app.createOrEditLicenseModalSaved', function () {
            loadData();
        });

        loadData();
    });
})();