(function () {
    app.modals.CreateOrEditPayGradeModal = function () {
        var _modalManager;
        var _jobConfigurationService = abp.services.app.jobConfiguration;
        var paygradeInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            paygradeInformationsForm = _modalManager.getModal().find('form[name=PaygradeInformationsForm]');
            paygradeInformationsForm.validate({ ignore: "" });
        };

        this.save = function () {
            if (!paygradeInformationsForm.valid()) {
                return;
            }

            var paygrade = paygradeInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _jobConfigurationService.createOrUpdatePaygrade({
                paygrade: paygrade
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditPaygradeModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();
