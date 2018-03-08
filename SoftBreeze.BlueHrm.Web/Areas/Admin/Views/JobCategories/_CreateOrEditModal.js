
(function () {
    app.modals.CreateOrEditJobCategoryModal = function () {

        var _modalManager;
        var _jobConfigurationService = abp.services.app.jobConfiguration;
        var _$JobCategoryInformationForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;
             

            _$JobCategoryInformationForm = _modalManager.getModal().find('form[name=JobCategoryInformationsForm]');
            _$JobCategoryInformationForm.validate({ ignore: "" });
        };

        this.save = function () { 
            if (!_$JobCategoryInformationForm.valid()) {
                return;
            }

            var jobCategory = _$JobCategoryInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _jobConfigurationService.createOrUpdateJobCategory({
                jobCategory: jobCategory
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditJobCategoryModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();