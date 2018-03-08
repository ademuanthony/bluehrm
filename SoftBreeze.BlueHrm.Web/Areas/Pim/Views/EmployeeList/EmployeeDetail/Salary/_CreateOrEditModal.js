
(function () {
    app.modals.CreateOrEditSalaryModal = function () {

        var _modalManager;
        var service = abp.services.app.employee;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=SalaryDataformationsForm]');
            form.validate({ ignore: "" });
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var salary = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveSalary(salary).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditSalaryModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();