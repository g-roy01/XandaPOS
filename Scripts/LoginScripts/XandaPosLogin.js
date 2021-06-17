jQuery(function () {
    CheckLogin();
});

function CheckLogin() {
    //alert('1');

    //jQuery(document).click('#loginSubmit', function () {
    jQuery(document).on('click','#loginSubmit', function () {

        var id = jQuery('#loginXandaPos').val();
        var pass = jQuery('#passwordXandaPos').val();


        //$("#loginSubmit").click(function () {
        //    $.post("/Login/LoginVerification", function (data, status) {
        //        alert("Data: "" + data + "\nStatus: " + status);
        //    });
        //});
   
        var loginData = new Object();
        loginData.loginId = jQuery('#loginXandaPos').val();
        loginData.loginPass =jQuery('#passwordXandaPos').val();

        jQuery.ajax({
            type: "POST",
            url: "/Login/LoginVerification",
            data: JSON.stringify(loginData),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Result == 'Redirect') {
                    window.location = data.Url;
                    //alert('Success');
                }
                else {
                    jQuery('#loginmessage label').css('display', 'block');
                    jQuery('#loginmessage label').css('color', 'red');
                    jQuery('#loginmessage label').text(data.Message);
                }

            },
            failure: function (response) {
                //alert(response.responseText);
            },
            error: function (data) {
                if (data.Result == 'Failed') {
                    //Do Nothing And Show Error
                    jQuery('#loginmessage label').css('display', 'block');
                    jQuery('#loginmessage label').css('color', 'red');
                    jQuery('#loginmessage label').val(data.Message);
                }
            }
        });

        return false;




    });




    //var id = 
    //jQuery('#loginSubmit').ajax({
    //    url: "/Login/LoginVerification",
    //    data: '{custID : ' + id + '}',
    //    type: "POST",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",

    //    beforeSend: function(){
    //        jQuery("#login").val('');
    //        jQuery("#password").val('');
    //    },
    //    uploadProgress: function () {
    //        //DO NOTHING
    //    },
    //    success: function (data) {
    //        if (data.Result == 'Redirect')
    //            window.location = data.Url;

    //    },
    //    error: function (data) {
    //        if (data.Result == 'Failed') {
    //            //Do Nothing And Show Error
    //            jQuery('#loginmessage label').css('display', 'block');
    //            jQuery('#loginmessage label').css('color', 'red');
    //            jQuery('#loginmessage label').val(data.Message);
    //        }
    //    }


    //});
}