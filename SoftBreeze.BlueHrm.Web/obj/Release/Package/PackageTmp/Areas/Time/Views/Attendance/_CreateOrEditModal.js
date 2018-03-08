(function () {
    app.modals.CreateOrEditModal = function () {
        var _modalManager;
        var service = abp.services.app.time;
        var form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            form = _modalManager.getModal().find('form[name=Attendanceform]');
            form.validate({ ignore: "" });

            $(".datepicker").datepicker();
        };

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var attendance = form.serializeFormToObject();

            _modalManager.setBusy(true);
            service.saveAttendance(attendance).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditAttendanceModalSaved');
                } else {
                    abp.notify.error(result.message);
                }

            }).always(function() {
                _modalManager.setBusy(false);
            });
        };


    };
})();