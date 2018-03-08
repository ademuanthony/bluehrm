
(function () {
    app.modals.CreateOrEditUnitModal = function () {

        var _modalManager;
        var service = abp.services.app.organisation;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=UnitInformationsForm]');
            form.validate({ ignore: "" });
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var unit = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.createOrUpdateUnit({
                unit: unit
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditUnitModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();