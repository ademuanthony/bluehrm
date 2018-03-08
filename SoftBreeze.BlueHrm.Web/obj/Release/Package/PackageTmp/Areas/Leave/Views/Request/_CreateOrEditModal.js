
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

        this.save = function() {
            if (!form.valid()) {
                return;
            }

            var leaveEntitlement = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveEntitlement({ leaveEntitlement: leaveEntitlement }).done(function(result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditLeaveEntitlementModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function() {
                _modalManager.setBusy(false);
            });
        };


    };
})();