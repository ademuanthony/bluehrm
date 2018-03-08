(function () {
    app.modals.CreateOrEditModal = function () {
        var _modalManager;
        var service = abp.services.app.leave;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            form = _modalManager.getModal().find('form[name=LeaveForm]');
            form.validate({ ignore: "" });

            $(".datepicker").datepicker();
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var leave = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.assignLeave(leave).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditLeaveModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function() {
                _modalManager.setBusy(false);
            });
        };


    };
})();