(function () {
    $(function () {
        var supervisorTable = $('#KeyResultAreasTable');
        var service = abp.services.app.staffPerformance;


        var permissions = {
            create: abp.auth.hasPermission('Pages.Performance.KeyResultAreas.Create'),
            edit: abp.auth.hasPermission('Pages.Performance.KeyResultAreas.Edit'),
            'delete': abp.auth.hasPermission('Pages.Performance.KeyResultAreas.Delete')
        };

        var createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Performance/Indicators/CreateOrEditModal/',
            scriptUrl: abp.appPath + 'Areas/Performance/Views/Indicators/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModal'
        });

        function getAttributes() {
            supervisorTable.jtable('load');
        }

        function deleteAttribute(attribute) {
            abp.message.confirm(
                L('DeleteWarningMessage', attribute.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteKeyResultAreaAttribute({
                            attributeId: attribute.id
                        }).done(function (result) {
                            getAttributes();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('Indicators'),

            actions: {
                listAction: {
                    method: service.getKeyResultAreaAttributes
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        if (permissions.edit) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Edit') + '"><i class="fa fa-edit"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    createOrEditModal.open({ id: data.record.id });
                                });
                        }

                        if (!data.record.isStatic && permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteAttribute(data.record);
                                });
                        }

                        return $span;
                    }
                },
                name: {
                    title: L('Name'),
                    width: '50%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.name + " &nbsp; ");

                        return $span;
                    }
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '30%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        }); 
        
        $('#CreateNewKeyResultAreaButton').click(function () {
            createOrEditModal.open();
        });

        abp.event.on('app.createOrEditAttributeFormModalSaved', function () {
            getAttributes();
        });

        getAttributes();
    });
})();