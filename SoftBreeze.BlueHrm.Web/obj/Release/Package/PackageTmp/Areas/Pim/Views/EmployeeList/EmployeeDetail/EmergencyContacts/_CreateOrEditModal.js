
(function () {
    app.modals.CreateOrEditJobTitleModal = function () {

        var _modalManager;
        var service = abp.services.app.employee;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=ContactDataformationsForm]');
            form.validate({ ignore: "" });
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var contact = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.createOrEditEmergencyContact(contact).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditContactModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();