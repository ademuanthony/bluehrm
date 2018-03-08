(function () {
    $(function () {
        var _$locationsTable = $('#LocationsTable');
        var service = abp.services.app.organisation;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Organisation.Locations.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Organisation.Locations.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Organisation.Locations.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Locations/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Locations/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditLocationModal'
        });

        _$locationsTable.jtable({
            jqueryuiTheme: true,

            title: L('Locations'),

            actions: {
                listAction: {
                    method: service.getLocations
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
                                    deleteLocation(data.record);
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
                city: {
                    title: L('City'),
                    width: '25%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.city + " &nbsp; ");

                        return $span;
                    }
                },
                zipcode: {
                    title: L('ZipCode'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.zipCode + " &nbsp; ");

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

        function deleteLocation(location) {
            abp.message.confirm(
                L('DeleteLocationWarningMessage', location.title),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteLocation({
                            locationId: location.id
                        }).done(function (result) {
                            getLocations();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewLocationButton').click(function () {
            _createOrEditModal.open();
        });

        function getLocations() {
            _$locationsTable.jtable('load');
        }

        abp.event.on('app.createOrEditLocationModalSaved', function () {
            getLocations();
        });

        getLocations();
    });
})();