
(function () {
    app.modals.CreateOrEditJobTitleModal = function () {

        var _modalManager;
        var _jobConfigurationService = abp.services.app.jobConfiguration;
        var _$jobInformationForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            _$jobInformationForm = _modalManager.getModal().find('form[name=JobInformationsForm]');
            _$jobInformationForm.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$jobInformationForm.valid()) {
                return;
            }

            var job = _$jobInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _jobConfigurationService.createOrUpdateJob({
                job: job
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditJobTitleModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();