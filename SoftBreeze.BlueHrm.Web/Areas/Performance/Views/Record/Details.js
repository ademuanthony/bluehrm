(function () {
    $(function () {
        var krasTable = $('#KIATable');
        var service = abp.services.app.staffPerformance;

        var performanceId = $("#performanceId").val();

        var permissions = {
            create: abp.auth.hasPermission('Pages.Performance.Record.Create'),
            edit: abp.auth.hasPermission('Pages.Performance.Record.Edit'),
            'delete': abp.auth.hasPermission('Pages.Performance.Record.Delete')
        };

        var createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Performance/Record/CreateOrEditKiaRcordModal/',
            scriptUrl: abp.appPath + 'Areas/Performance/Views/Record/_CreateOrEditKiaRcordModal.js',
            modalClass: 'CreateOrEditKraModal'
        });

        krasTable.jtable({
            jqueryuiTheme: true,

            title: L('KeyResultAreas'),

            actions: {
                listAction: {
                    method: service.getKras
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: L('Actions'),
                    width: '10%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        if (permissions.edit) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Edit') + '"><i class="fa fa-edit"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    createOrEditModal.open({ id: data.record.id });
                                });
                        }

                        return $span;
                    }
                },
                kpi: {
                    title: L('KPI'),
                    width: '20%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.kpi + " &nbsp; ");

                        return $span;
                    }
                },
                rating: {
                    title: L('Rating'),
                    width: '10%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append((data.record.rating == null ? "" : data.record.rating) + " &nbsp; ");

                        return $span;
                    }
                },
                actualAcheivement: {
                    title: L('ActualAchievement'),
                    width: '30%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append((data.record.actualAcheivement == null ? "" : data.record.actualAcheivement) + " &nbsp; ");

                        return $span;
                    }
                },
                comment: {
                    title: L('Comment'),
                    width: '30%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append((data.record.comment == null ? "" : data.record.comment) + " &nbsp; ");

                        return $span;
                    }
                }
            }

        });

        function getKras() {
            krasTable.jtable('load', { performanceId: performanceId });
        }

        $('#CreateNewKraButton').click(function () {
            createOrEditModal.open();
        });


        abp.event.on('app.createOrEditKraModalSaved', function () {
            getKras();
        });

        getKras();
    });
})();