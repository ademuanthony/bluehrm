﻿
(function () {
    app.modals.CreateOrEditLicensesModal = function () {

        var _modalManager;
        var _service = abp.services.app.qualification;
        var _$formData = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            _$formData = _modalManager.getModal().find('form[name=LicensesInformationsForm]');
            _$formData.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$formData.valid()) {
                return;
            }

            var licenseType = _$formData.serializeFormToObject();
            _modalManager.setBusy(true);
            _service.createOrEditLicenseType({
                LicenseType: licenseType
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditLicenseModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();