
(function () {
    app.modals.CreateOrEditEmployeeModal = function () {

        var _modalManager;
        var _service = abp.services.app.employee;
        var _$formData = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            _$formData = _modalManager.getModal().find('form[name=EmployeeInformationsForm]');
            _$formData.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$formData.valid()) {
                return;
            }

            var formData = _$formData.serializeFormToObject();
            console.log(formData);

            _modalManager.setBusy(true);
            _service.createEmployee({
                employee: formData,
                emailAddress: formData.emailAddress,
                password: formData.password
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditEmployeeModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();