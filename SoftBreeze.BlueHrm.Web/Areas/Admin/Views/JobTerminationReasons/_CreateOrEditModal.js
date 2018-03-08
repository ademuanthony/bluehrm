
(function () {
    app.modals.CreateOrEditJobTerminationReasonModal = function () {
        var _modalManager;
        var _jobConfigurationService = abp.services.app.jobConfiguration;
        var _$jobTerminationReasonsInformationForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;
             

            _$jobTerminationReasonsInformationForm = _modalManager.getModal().find('form[name=JobTerminationReasonInformationsForm]');
            _$jobTerminationReasonsInformationForm.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$jobTerminationReasonsInformationForm.valid()) {
                return;
            }

            var reason = _$jobTerminationReasonsInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _jobConfigurationService.createOrUpdateJobTerminationReason({
                jobTerminationReason: reason
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditJobTerminationReasonsModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();