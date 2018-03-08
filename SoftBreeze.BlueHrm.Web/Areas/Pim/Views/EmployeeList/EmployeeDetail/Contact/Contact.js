(function ($) {
    $(function () {

        var employeeService = abp.services.app.employee;
        var dataForm = $('#ContactnformationsForm');
        dataForm.validate({ ignore: "" });

        //Save settings
        $('#SaveContactButton').click(function () {
            if (!dataForm.valid()) {
                return;
            }

            employeeService.saveContact({
                contact: dataForm.serializeFormToObject()
            }).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                } else {
                    abp.notify.error(result.message);
                }
            });
        });

    });
})(jQuery);