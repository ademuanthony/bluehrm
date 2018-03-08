(function () {
    $(function () {
        var _$jobCategoriesTable = $('#JobCategoriesTable');
        var jobConfigurationService = abp.services.app.jobConfiguration;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobCategories.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobCategories.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobCategories.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/JobCategories/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/JobCategories/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditJobCategoryModal'
        });

        _$jobCategoriesTable.jtable({
            jqueryuiTheme: true,

            title: L('JobCategories'),

            actions: {
                listAction: {
                    method: jobConfigurationService.getJobCategories
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
                                    deleteJobCategory(data.record);
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

        function deleteJobCategory(jobCategory) {
            abp.message.confirm(
                L('DeleteJobCategoryWarningMessage', jobCategory.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        jobConfigurationService.deleteJobCategory({
                            categoryId: jobCategory.id
                        }).done(function (result) {
                            getJobCategories();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewJobCategoryButton').click(function () {
            _createOrEditModal.open();
        });

        function getJobCategories() {
            _$jobCategoriesTable.jtable('load');
        }

        abp.event.on('app.createOrEditJobCategoryModalSaved', function () {
            getJobCategories();
        });

        getJobCategories();
    });
})();