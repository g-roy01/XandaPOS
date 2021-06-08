//Load grid
function loadCustomerGrid() {
    //$.ajax({
    //    type: "GET",
    //    url: "/MasterData/LoadCustomerGrid",
    //    datatype: "json",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (result) {
    //        $("#FlatGrid").ejGrid("dataSource", result);
    //    },
    //    error: function (args) {
    //        alert('error occurred');
    //    }
    //});
    alert("aasd");
} 

jQuery(document).ready(function () {
    //AJAX call to controller
    jQuery("#AddBtnCustomer").click(function () {
        
        var customerMaster = new Object(); //{}; 
        //UPDATE NOTES - While updating the customerMaster members 
        //must be of same name as original model else controller 
        //wont be able to recognize
        //customerMaster.cust_id = '';
        customerMaster.cust_name = jQuery('#CustName').val();
        customerMaster.cust_addr = jQuery('#CustAddress').val();
        customerMaster.cust_pin = jQuery('#CustPinCode').val();
        customerMaster.cust_phn = jQuery('#CustPhnData').val();
        customerMaster.cust_email = jQuery('#CustEmailData').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddCustomer",
            //data: '{custData : ' + JSON.stringify(customerMaster) + '}',
            data: JSON.stringify(customerMaster),
            //data: "{ JSON.stringify(customerMaster) }",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //GetCustomer();
            },
            failure: function (response){
                alert(response.responseText);
            }, 
            error: function (response){
                //Insert error handling code here
            }
        });
        return false;

        // ajax call to controller 
    });

    jQuery(".CustEditButton").click(function () {

        var buttonID = jQuery(this).attr("id");
        //alert('Clicked'); /*CustEdit_*/
        var id = buttonID.substring(9);
        //alert(id.trim());
        //alert(jQuery("#CustomerEditName").val());
        //var a = "CustName_" + id.trim();
        //alert(a);
        //alert(jQuery("#CustName_" + id.trim()).text());
        //jQuery(CustomerEditName).val() = jQuery("#CustName_" + id.trim()).val();
        jQuery("#CustomerEditId")
            .val(id.trim());

        jQuery("#CustomerEditName")
            .val(
                jQuery("#CustName_" + id.trim()).text().trim()
        );

        jQuery("#CustomerEditAddress")
            .val(
                jQuery("#CustAddr_" + id.trim()).text().trim()
        );

        jQuery("#CustomerEditPin")
            .val(
                jQuery("#CustPin_" + id.trim()).text().trim()
        );

        jQuery("#CustomerEditPhone")
            .val(
                jQuery("#CustPin_" + id.trim()).text().trim()
        );

        jQuery("#CustomerEditEmail")
            .val(
                jQuery("#CustEmail_" + id.trim()).text().trim()
        );

    });

    jQuery("#EditBtnCustomer").click(function () {
        var customerMaster = new Object(); //{}; 
        //UPDATE NOTES - While updating the customerMaster members 
        //must be of same name as original model else controller 
        //wont be able to recognize
        customerMaster.cust_id = jQuery('#CustomerEditId').val();
        customerMaster.cust_name = jQuery('#CustomerEditName').val();
        customerMaster.cust_addr = jQuery('#CustomerEditAddress').val();
        customerMaster.cust_pin = jQuery('#CustomerEditPin').val();
        customerMaster.cust_phn = jQuery('#CustomerEditPhone').val();
        customerMaster.cust_email = jQuery('#CustomerEditEmail').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditCustomer",
            //data: '{custid : ' + customerMaster.cust_id + ' ,' + JSON.stringify(customerMaster) + '}',
            data: JSON.stringify(customerMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //GetCustomer();
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                //Insert error handling code here
            }
        });
        return false;
    });

});

//Insert data

//Update data

// Delete Data