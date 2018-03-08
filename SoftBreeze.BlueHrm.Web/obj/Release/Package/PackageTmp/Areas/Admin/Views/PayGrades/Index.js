(function () {
    $(function () {
        var _$jobsTable = $('#PayGradesTable');
        var jobConfigurationService = abp.services.app.jobConfiguration;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.PayGrade.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.PayGrade.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.PayGrade.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/PayGrades/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/PayGrades/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditPayGradeModal'
        });

        _$jobsTable.jtable({
            jqueryuiTheme: true,

            title: L('PayGrades'),

            actions: {
                listAction: {
                    method: jobConfigurationService.getPayGrades
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
                            $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    _createOrEditModal.open({ id: data.record.id });
                                });
                        }

                        if (!data.record.isStatic && _permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deletePaygrade(data.record);
                                });
                        }

                        return $span;
                    }
                },
                title: {
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

        function deletePaygrade(paygrade) {
            abp.message.confirm(
                L('DeletePayGradeWarningMessage', paygrade.title),
                function (isConfirmed) {
                    if (isConfirmed) {
                        jobConfigurationService.deletePayGrade({
                            payGradeId: paygrade.id
                        }).done(function (result) {
                            getPaygrade();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewPayGradeButton').click(function () {
            _createOrEditModal.open();
        });

        function getPaygrade() {
            _$jobsTable.jtable('load');
        }

        abp.event.on('app.createOrEditPaygradeModalSaved', function () {
            getPaygrade();
        });

        getPaygrade();
    });
})();