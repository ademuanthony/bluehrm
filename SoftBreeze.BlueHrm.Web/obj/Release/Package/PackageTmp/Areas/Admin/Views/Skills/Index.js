(function () {
    $(function () {
        var _$skillsTable = $('#SkillsTable');
        var _service = abp.services.app.qualification;

        console.log(_service);

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Qualification.Skill.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Qualification.Skill.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Qualification.Skill.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Skills/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Skills/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditSkillModal'
        });
        
        _$skillsTable.jtable({
            jqueryuiTheme: true,

            title: L('Skills'),

            actions: {
                listAction: {
                    method: _service.getSkills
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
                                    deleteSkill(data.record);
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

        function deleteSkill(skill) {
            abp.message.confirm(
                L('DeleteSkillWarningMessage', skill.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteSkill({
                            skillId: skill.id
                        }).done(function (result) {
                            getSkills();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewSkillButton').click(function () {
            _createOrEditModal.open();
        });

        function getSkills() {
            _$skillsTable.jtable('load');
        }

        abp.event.on('app.createOrEditSkillModalSaved', function () {
            getSkills();
        });

        getSkills();
    });
})();