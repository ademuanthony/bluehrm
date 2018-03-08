(function () {
    $(function () {
        var _$jobsTable = $('#JobsTable');
        var jobConfigurationService = abp.services.app.jobConfiguration;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTitle.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/JobTitles/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/JobTitles/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditJobTitleModal'
        });

        _$jobsTable.jtable({
            jqueryuiTheme: true,

            title: L('JobTitles'),

            actions: {
                listAction: {
                    method: jobConfigurationService.getJobs
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
                                    deleteJob(data.record);
                                });
                        }

                        return $span;
                    }
                },
                title: {
                    title: L('JobTitle'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.title + " &nbsp; ");

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

        function deleteJob(job) {
            abp.message.confirm(
                L('DeleteJobWarningMessage', job.title),
                function (isConfirmed) {
                    if (isConfirmed) {
                        jobConfigurationService.deleteJob({
                            jobId: job.id
                        }).done(function (result) {
                            getJobTitles();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewJobButton').click(function () {
            _createOrEditModal.open();
        });

        function getJobTitles() {
            _$jobsTable.jtable('load');
        }

        abp.event.on('app.createOrEditJobTitleModalSaved', function () {
            getJobTitles();
        });

        getJobTitles();
    });
})();