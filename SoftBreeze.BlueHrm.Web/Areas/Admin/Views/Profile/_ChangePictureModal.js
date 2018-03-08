(function($) {
    app.modals.ChangeProfilePictureModal = function () {

        var _modalManager;

        this.init = function(modalManager) {
            _modalManager = modalManager;

            $('#ChangeProfilePictureModalForm').ajaxForm({
                beforeSubmit: function (formData, jqForm, options) {

                    if (app.employeeForProfilePictureId) {
                        formData.push({ name: "employeeId", value: app.employeeForProfilePictureId });
                    }
                    

                    var $fileInput = $('#ChangeProfilePictureModalForm input[name=ProfilePicture]');
                    var files = $fileInput.get()[0].files;

                    if (!files.length) {
                        return false;
                    }

                    var file = files[0];

                    //File type check
                    var type = '|' + file.type.slice(file.type.lastIndexOf('/') + 1) + '|';
                    if ('|jpg|jpeg|'.indexOf(type) === -1) {
                        abp.message.warn(L('ProfilePicture_Warn_FileType'));
                        return false;
                    }

                    //File size check
                    if (file.size > 30720) //30KB
                    {
                        abp.message.warn(L('ProfilePicture_Warn_SizeLimit'));
                        return false;
                    }

                    return true;
                },
                success: function() {
                    if (app.employeeForProfilePictureId) {
                        abp.event.trigger('app.profilePictureChanged');
                    } else {
                        var profileFilePath = abp.appPath + 'Profile/GetProfilePicture?t=' + new Date().getTime();
                        $('#HeaderProfilePicture').attr('src', profileFilePath);
                    }
                    _modalManager.close();
                }
            });
        };

        this.save = function () {
            $('#ChangeProfilePictureModalForm').submit();
        };
    };
})(jQuery);