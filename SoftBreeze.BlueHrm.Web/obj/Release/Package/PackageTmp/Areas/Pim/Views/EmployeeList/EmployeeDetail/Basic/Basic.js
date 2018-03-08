(function ($) {
    $(function () {

        var employeeService = abp.services.app.employee;
        var dataForm = $('#BasicInformationsForm');
        dataForm.validate({ ignore: "" });

        //Save info
        $('#SaveAllSettingsButton').click(function () {
            if (!dataForm.valid()) {
                return;
            }

            employeeService.updateEmployee($('#BasicInformationsForm').serializeFormToObject()).done(function (result) {
                if (result.success) {
                    abp.notify.success(result.message);
                } else {
                    abp.notify.error(result.message);
                }
            });
        });

        //Change profile picture
        var changeProfilePictureModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Profile/ChangePictureModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Profile/_ChangePictureModal.js',
            modalClass: 'ChangeProfilePictureModal'
        });

        $('#ChangeProfilePictureButton').click(function (e) {
            e.preventDefault();
            app.employeeForProfilePictureId = $(this).attr('data-employeeId');
            changeProfilePictureModal.open();
        });




        abp.event.on('app.profilePictureChanged', function () {
            var profileFilePath = abp.appPath + 'Profile/GetProfilePictureByUserId?userId=' + app.employeeForProfilePictureId + '&t=' + +new Date().getTime();
            $('#EmployeeProfilePicture').attr('src', profileFilePath);
        });
    });
})(jQuery);