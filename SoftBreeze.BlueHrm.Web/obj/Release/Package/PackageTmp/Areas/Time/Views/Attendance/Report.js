(function () {
    $(function () {
        var attendanceTable = $('#AttendanceTable');
        var service = abp.services.app.time;
        var form = $("#LoadAttendanceForm");

        var permissions = {
            create: abp.auth.hasPermission('Pages.Timing.Attendance.Create'),
            edit: abp.auth.hasPermission('Pages.Timing.Attendance.Edit'),
            'delete': abp.auth.hasPermission('Pages.Timing.Attendance.Delete')
        };
        
        function getAttendances(reload) {
            if (reload) {
                attendanceTable.jtable('reload');
            } else {
                attendanceTable.jtable('load', form.serializeFormToObject());
            }
        }

        attendanceTable.jtable({
            jqueryuiTheme: true,

            title: L('Attendance'),

            actions: {
                listAction: {
                    method: service.getAttendanceReports
                }
            },

            fields: {
                date: {
                    title: L('Date'),
                    width: '15%',
                    display: function (data) {
                        return moment(data.record.date).format('L');
                    }
                },
                employeeName: {
                    title: L('EmployeeName'),
                    width: '20%'
                },
                punchInTime: {
                    title: L('ClockIn'),
                    width: '15%'
                },
                punchOutTime: {
                    title: L('ClockOut'),
                    width: '15%'
                },
                status: {
                    title: L('Status'),
                    width: '15%'
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '10%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });


        $('#LoadButton').click(function (e) {
            e.preventDefault();
            getAttendances();
        });

        getAttendances();

    });
})();