(function ($) {
    $(function () {

        var employeeService = abp.services.app.employee;
        var dataForm = $('#JobInformationsForm');
        dataForm.validate({ ignore: "" });


        //Save settings
        $('#SaveJobButton').click(function () {
            if (!dataForm.valid()) { 
                return;
            }

            employeeService.saveJobInformation(dataForm.serializeFormToObject()).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                } else {
                    abp.notify.error(result.message);
                }
            });
        });

    });
})(jQuery);