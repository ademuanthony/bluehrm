(function($) {
    $(function () {

        //My settings

        var mySettingsModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Profile/MySettingsModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Profile/_MySettingsModal.js',
            modalClass: 'MySettingsModal'
        });

        $('#UserProfileMySettingsLink').click(function (e) {
            e.preventDefault();
            mySettingsModal.open();
        });

        //Change password

        var changePasswordModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Profile/ChangePasswordModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Profile/_ChangePasswordModal.js',
            modalClass: 'ChangePasswordModal'
        });

        $('#UserProfileChangePasswordLink').click(function(e) {
            e.preventDefault();
            changePasswordModal.open();
        });

        //Change profile picture

        var changeProfilePictureModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Profile/ChangePictureModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/Profile/_ChangePictureModal.js',
            modalClass: 'ChangeProfilePictureModal'
        });

        $('#UserProfileChangePictureLink').click(function (e) {
            e.preventDefault();
            changeProfilePictureModal.open();
        });

        $('.nav-tabs-items-to-new-page li a').click(function (e) {
            var uri = $(this).attr('data-uri');
            window.location.href = uri;
        });
        
        $(".datepicker").datepicker();
    });
})(jQuery);

function printDiv(divId) {
    //Get the HTML of div
    var divElements = document.getElementById(divId).innerHTML;
    //Get the HTML of whole page
    var oldPage = document.body.innerHTML;

    //Reset the page's HTML with div's HTML only
    document.body.innerHTML =
      "<html><head><title></title></head><body>" +
      divElements + "</body>";

    //Print Page
    window.print();

    //Restore orignal HTML
    document.body.innerHTML = oldPage;


}