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

        var createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Time/Attendance/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Time/Views/Attendance/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModal'
        });
        
        function getAttendances(reload) {
            if (reload) {
                attendanceTable.jtable('reload');
            } else {
                attendanceTable.jtable('load', form.serializeFormToObject());
            }
        }

        function deleteAttendance(attendance) {

            abp.message.confirm(
                L('DeleteWarningMessage', 'The assigned ' + attendance.leaveType),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteAttendance({
                            attendanceId: attendance.id
                        }).done(function () {
                            getAttendances(true);
                            abp.notify.success(L('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

        attendanceTable.jtable({

            title: L('Attendance'),
            paging: true,
            sorting: true,
            multiSorting: true,
            jqueryuiTheme: true,

            actions: {
                listAction: {
                    method: service.getAttendances
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
                    sorting: false,
                    list: permissions.edit || permissions.delete,
                    display: function (data) {
                        var $span = $('<span></span>');

                        if (permissions.edit) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Manage') + '"><i class="fa fa-eye"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    createOrEditModal.open({ id: data.record.id });
                                });
                        }

                        if (permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + L('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteAttendance(data.record);
                                });
                        }

                        return $span;
                    }
                },
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
                employeeNumber: {
                    title: L('EmployeeNumber'),
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
        
        $('#CreateButton').click(function () {
            createOrEditModal.open();
        });

        $('#LoadButton').click(function (e) {
            e.preventDefault();
            getAttendances();
        });

        $('#PunchInButton').click(function () {
            //$('#PunchInButton').setBusy(true);
            service.clockin({}).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    abp.event.trigger('app.createOrEditAttendanceModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                //$('#PunchInButton').setBusy(false);
            });
        });

        $('#PunchOutButton').click(function () {
            //$('#PunchOutButton').setBusy(true);
            service.clockOut({}).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    abp.event.trigger('app.createOrEditAttendanceModalSaved');
                } else { 
                    abp.notify.error(result.message);
                }

            }).always(function () { 
                //$('#PunchOutButton').setBusy(false);
            });
        });


        abp.event.on('app.createOrEditAttendanceModalSaved', function () {
            getAttendances(true);
        });

        getAttendances();

    });
})();