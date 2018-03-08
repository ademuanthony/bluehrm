
(function () {
    app.modals.CreateOrEditQualificationModal = function () {

        var _modalManager;
        var service = abp.services.app.employee;
        var form = null;
        
        this.init = function (modalManager) {
            _modalManager = modalManager;


            form = _modalManager.getModal().find('form[name=EducationDataformationsForm]');
            form.validate({ ignore: "" });

            $(".datepicker").datepicker();
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var education = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveEducation({education:education}).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditQualificationModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
       


    };
})();