
(function () {
    app.modals.CreateOrEditKraModal = function () {

        var _modalManager;
        var service = abp.services.app.staffPerformance;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=KraForm]');
            form.validate({ ignore: "" });

        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var kra = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveKra({ kra: kra }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditKraModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
       


    };
})();