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
        //var a = $("#txtEmail").val();
        //var a = $('input[id=CustName]').val()
        //var b = 'as1';

        //var c = document.getElementById('CustName').value;
        //alert(c);

        //var custName = jQuery('#CustName').val();
        //var custAddress = jQuery('#CustAddress').val();
        //var custPinCode = jQuery('#CustPinCode').val();
        //var custPinCode = jQuery('#CustPinCode').val();
        //var custPhnData = jQuery('#CustPhnData').val();
        //var custEmailData = jQuery('#CustEmailData').val();

        var customerMaster = new Object(); //{}; 
        //UPDATE NOTES - While updating the customerMaster members 
        //must be of same name as original model else controller 
        //wont be able to recognize
        customerMaster.cust_id = '';
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
});

//Insert data

//Update data

// Delete Data