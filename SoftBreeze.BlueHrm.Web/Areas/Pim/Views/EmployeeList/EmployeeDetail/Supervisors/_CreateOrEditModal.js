
(function () {
    app.modals.CreateOrEditSupervisorModal = function () {

        var _modalManager;
        var service = abp.services.app.employee;
        var form = null;

        var setEmployeeId = function (event, ui) {
            var input = $(this);
            var value = ui.item.value;
            alert(value);
        }

        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=SupervisorDataformationsForm]');
            form.validate({ ignore: "" });

        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var salary = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.addSupervisor(salary).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditSupervisorModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
       


    };
})();