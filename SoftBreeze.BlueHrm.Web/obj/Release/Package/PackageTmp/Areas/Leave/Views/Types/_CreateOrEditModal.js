
(function () {
    app.modals.CreateOrEditModal = function () {

        var _modalManager;
        var service = abp.services.app.leave;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=LeaveTypeForm]');
            form.validate({ ignore: "" });

        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var leave = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveLeaveType({ leaveType: leave }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditLeaveTypeModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
       


    };
})();