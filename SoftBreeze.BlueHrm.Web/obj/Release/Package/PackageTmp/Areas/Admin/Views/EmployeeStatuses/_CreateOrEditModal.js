
(function () {
    app.modals.CreateOrEditEmployeeStatusModal = function () {

        var _modalManager;
        var _jobConfigurationService = abp.services.app.jobConfiguration;
        var _$employeeStatusInformationForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;
             

            _$employeeStatusInformationForm = _modalManager.getModal().find('form[name=EmployeeStatusInformationsForm]');
            _$employeeStatusInformationForm.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$employeeStatusInformationForm.valid()) {
                return;
            }

            var employmentStatus = _$employeeStatusInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _jobConfigurationService.createOrUpdateEmploymentStatus({
                employmentStatus: employmentStatus
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditEmployeeStatusModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();