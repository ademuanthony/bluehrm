(function () {
    $(function () {
        var _$table = $('#EducationalLevelsTable');
        var _service = abp.services.app.qualification;
        
        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Qualification.EducationalLevel.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Qualification.EducationalLevel.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Qualification.EducationalLevel.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/EducationalLevels/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Skills/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditEducationalLevelModal'
        });
        
        _$table.jtable({
            jqueryuiTheme: true,

            title: L('EducationalLevels'),

            actions: {
                listAction: {
                    method: _service.getEducationLevels
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
                                    deleteEducationalLevel(data.record);
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

        function deleteEducationalLevel(level) {
            abp.message.confirm(
                L('DeleteEducationalLevelWarningMessage', level.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteEducationLevel({
                            educationLevelId: level.id
                        }).done(function (result) {
                            loadData();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewEducationalLevelButton').click(function () {
            _createOrEditModal.open();
        });

        function loadData() {
            _$table.jtable('load');
        }

        abp.event.on('app.createOrEditEducationalLevelModalSaved', function () {
            loadData();
        });

        loadData();
    });
})();