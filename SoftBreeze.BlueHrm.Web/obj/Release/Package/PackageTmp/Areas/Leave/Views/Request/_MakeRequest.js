
(function () {
    app.modals.MakeRequestModal = function () {

        var _modalManager;
        var service = abp.services.app.leave;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            form = _modalManager.getModal().find('form[name=LeaveRequestForm]');
            form.validate({ ignore: "" });

            $('.datepicker').datepicker();
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var request = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.makeLeaveRequest({ leaveRequest: request }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditLeaveRequestModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };


    };
})();