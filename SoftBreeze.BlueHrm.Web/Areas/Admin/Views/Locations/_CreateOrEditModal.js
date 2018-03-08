
(function () {
    app.modals.CreateOrEditLocationModal = function () {

        var _modalManager;
        var service = abp.services.app.organisation;
        var _$locationInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            _$locationInformationsForm = _modalManager.getModal().find('form[name=LocationInformationsForm]');
            _$locationInformationsForm.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$locationInformationsForm.valid()) {
                return;
            }

            var location = _$locationInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            service.createOrUpdateLocation({
                location: location
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditLocationModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();