(function () {
    $(function () {
        var table = $('#UnitsTable');
        var service = abp.services.app.organisation;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Organisation.Units.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Organisation.Units.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Organisation.Units.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Units/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Units/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditUnitModal'
        });

        table.jtable({

            title: L('Units'),

            actions: {
                listAction: {
                    method: service.getUnits
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
                                    deleteUnit(data.record);
                                });
                        }

                        return $span;
                    }
                },
                name: {
                    title: L('Name'),
                    width: '25%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.name + " &nbsp; ");

                        return $span;
                    }
                },
                description: {
                    title: L('Description'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.description + " &nbsp; ");

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

        function deleteUnit(unit) {
            abp.message.confirm(
                L('DeleteLocationWarningMessage', unit.title),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteUnit({
                            unitId: unit.id
                        }).done(function (result) {
                            getUnits();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewUnitButton').click(function () {
            _createOrEditModal.open();
        });

        function getUnits() {
            table.jtable('load');
        }

        abp.event.on('app.createOrEditUnitModalSaved', function () {
            getUnits();
        });

        getUnits();
    });
})();