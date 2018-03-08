
(function () {
    app.modals.CreateOrEditDependantModal = function () {

        var _modalManager;
        var service = abp.services.app.employee;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=DepaendatDataformationsForm]');
            form.validate({ ignore: "" });
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var dependant = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.createOrEditDependant(dependant).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditDependantModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();