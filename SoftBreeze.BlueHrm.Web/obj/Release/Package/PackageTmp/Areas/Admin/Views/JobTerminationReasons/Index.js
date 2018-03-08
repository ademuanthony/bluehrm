(function () {
    $(function () {
        var _$jobTerminationReasonsTable = $('#JobTerminationReasonsTable');
        var jobConfigurationService = abp.services.app.jobConfiguration;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTerminationReasons.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTerminationReasons.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.JobConfiguration.JobTerminationReasons.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/JobTerminationReasons/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/JobTerminationReasons/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditJobTerminationReasonModal'
        });

        _$jobTerminationReasonsTable.jtable({
            jqueryuiTheme: true,

            title: L('JobTerminationReasons'),

            actions: {
                listAction: {
                    method: jobConfigurationService.getJobTerminationReasons
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
                                    deleteJobTerminationReason(data.record);
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

        function deleteJobTerminationReason(reason) {
            abp.message.confirm(
                L('DeleteJobTerminationReasonsWarningMessage', reason.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        jobConfigurationService.deleteJobTerminationReason({
                            jobTerminationReasonId: reason.id
                        }).done(function (result) {
                            getJobTerminationReasons();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewJobTerminationReasonButton').click(function () {
            _createOrEditModal.open();
        });

        function getJobTerminationReasons() {
            _$jobTerminationReasonsTable.jtable('load');
        }

        abp.event.on('app.createOrEditJobTerminationReasonsModalSaved', function () {
            getJobTerminationReasons();
        });

        getJobTerminationReasons();
    });
})();