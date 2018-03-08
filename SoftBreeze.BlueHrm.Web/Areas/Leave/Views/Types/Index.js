(function () {
    $(function () {
        var supervisorTable = $('#LeaveTypesTable');
        var service = abp.services.app.leave;


        var _permissions = {
            create: abp.auth.hasPermission('Pages.Leave.LeaveTypes.Create'),
            edit: abp.auth.hasPermission('Pages.Leave.LeaveTypes.Edit'),
            'delete': abp.auth.hasPermission('Pages.Leave.LeaveTypes.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Leave/Types/CreateOrEditModal/',
            scriptUrl: abp.appPath + 'Areas/Leave/Views/Types/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModal'
        });

        supervisorTable.jtable({
            jqueryuiTheme: true,

            title: L('LeaveTypes'),

            actions: {
                listAction: {
                    method: service.getLeaveTypes
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
                                    deleteLeaveType(data.record);
                                });
                        }

                        return $span;
                    }
                },
                name: {
                    title: L('Name'),
                    width: '40%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.name + " &nbsp; ");

                        return $span;
                    }
                },
                isEntitlementSituational: {
                    title: L('IsEntitlementSituational'),
                    width: '25%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.isEntitlementSituational + " &nbsp; ");

                        return $span;
                    }
                },
                creationTime: {
                    title: L('CreationTime'),
                    width: '15%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        }); 

        function deleteLeaveType(leaveType) {
            abp.message.confirm(
                L('DeleteWarningMessage', leaveType.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        service.deleteLeaveType({
                            leaveTypeId: leaveType.id
                        }).done(function (result) {
                            getLeaveTypes();
                            abp.notify.success(result.message);
                        });
                    }
                }
            );
        };

        $('#CreateNewLeaveTypeButton').click(function () {
            _createOrEditModal.open();
        });

        function getLeaveTypes() {
            supervisorTable.jtable('load');
        }

        abp.event.on('app.createOrEditLeaveTypeModalSaved', function () {
            getLeaveTypes();
        });

        getLeaveTypes();
    });
})();