(function () {
    $(function () {
        var supervisorTable = $('#RecordTable');
        var service = abp.services.app.staffPerformance;

        var searchForm = $('#LoadForm');
        searchForm.validate({ ignore: "" });

        var permissions = {
            create: abp.auth.hasPermission('Pages.Performance.KeyResultAreas.Create'),
            edit: abp.auth.hasPermission('Pages.Performance.KeyResultAreas.Edit'),
            'delete': abp.auth.hasPermission('Pages.Performance.KeyResultAreas.Delete')
        };

        var createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Performance/KeyResultAreas/CreateOrEditModal/',
            scriptUrl: abp.appPath + 'Areas/Performance/Views/KeyResultAreas/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModal'
        });

        function getPerformance() {
            supervisorTable.jtable('load', searchForm.serializeFormToObject());
        }

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('KeyResultAreas'),

            actions: {
                listAction: {
                    method: service.getPerfomanceEvaluationStatusDos
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
                                    window.location.href = "/Performance/Record/Details/" + data.record.employeeNumber +
                                                                            "?periodId=" + $("#PeriodId").val();
                                });
                        }


                        return $span;
                    }
                },
                employeeName: {
                    title: L('Name'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.employeeName + " &nbsp; ");

                        return $span;
                    }
                },
                employeeNumber: {
                    title: L('Number'),
                    width: '15%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.employeeNumber + " &nbsp; ");

                        return $span;
                    }
                },
                status: {
                    title: L('Status'),
                    width: '15',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append((data.record.status === 1 ? "Started" : data.record.status === 2? "Completed": "Not Started") + " &nbsp; ");

                        return $span;
                    }
                },
                creationTime: {
                    title: L('StartDate'),
                    width: '15%',
                    display: function (data) {
                        return data.record.startDate != null? moment(data.record.startDate).format('L'): "Not Started";
                    }
                }
            }

        });

        $('#LoadButton').click(function (e) {
            e.preventDefault();
            if (!searchForm.valid()) {
                return;
            }
            getPerformance();
        });


        getPerformance();
    });
})();