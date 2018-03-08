
(function () {
    app.modals.CreateOrEditModal = function () {

        var _modalManager;
        var service = abp.services.app.staffPerformance;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=AttributeForm]');
            form.validate({ ignore: "" });

        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var attribute = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveKeyResultAreaAttribute({ attribute: attribute }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditAttributeFormModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
       


    };
})();