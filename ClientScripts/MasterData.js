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

function ReloadCustomerMasterData() {
    //jQuery.ReloadCustomerMasterData = function () {

    alert("abc");

    jQuery(".tableCustomerLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadCustomerMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert('1');
            //alert(data.CustMasterList);
            //alert(data);
            //var item = '';
            jQuery.each(data.CustMasterList, function (i, item) {
                //alert(item.cust_id);
                var row =
                      "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id='CustName_" + item.cust_id + "'>" + item.cust_name + "</td>"
                    + "<td class='' id='CustAddr_" + item.cust_id + "'>" + item.cust_addr + "</td >"
                    + "<td class='' id='CustPin_" + item.cust_id + "'>" + item.cust_pin + "</td >"
                    + "<td class='' id='CustPhn_" + item.cust_id + "'>" + item.cust_phn + "</td >"
                    + "<td class='' id='CustEmail_" + item.cust_id + "'>" + item.cust_email + "</td >"
                    + "<td>"
                    + "<div class='card-toolbar text-right'>"
                    + "<button class='btn p-0 shadow-none' type='button' id='dropdowneditButton' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>"
                    + "<span class='svg-icon'>"
                    + "<svg width='20px' height='20px' viewBox='0 0 16 16' class='bi bi-three-dots text-body' fill='currentColor' xmlns='http://www.w3.org/2000/svg'>"
                    + "<path fill-rule='evenodd' d='M3 9.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z'></path>"
                    + "</svg>"
                    + "</span>"
                    + "</button>"
                    + "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='dropdowneditButton' style='position: absolute; transform: translate3d(1001px, 111px, 0px); top: 0px; left: 0px; will-change: transform;'>"
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit CustEditButton' id='CustEdit_" + item.cust_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete CustDeleteButton' id='CustDelete_" + item.cust_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableCustomerLoad tbody").append(row);
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            //Insert error handling code here
        }
    });
    return false;
}

jQuery(document).ready(function () {
    //AJAX call to controller
    jQuery("#AddBtnCustomer").click(function () {
        //ReloadCustomerMasterData();
        var customerMaster = new Object(); //{}; 
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
            success: function (msg) {
                ReloadCustomerMasterData();
                //alert(msg);
                //GetCustomer();
                //ReloadCustomerMasterData1();
            },
            failure: function (response){
                alert(response.responseText);
            }, 
            error: function (response){
                //Insert error handling code here
            }
        });
        return false;
    });

    jQuery(document).on('click', '.CustEditButton', function () {
        alert('1');
        ReloadCustomerMasterData();
        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(9);
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

   

    //jQuery(".CustEditButton").click(function () {
    //    alert('1');
    //    ReloadCustomerMasterData();
    //    var buttonID = jQuery(this).attr("id");
    //    var id = buttonID.substring(9);
    //    jQuery("#CustomerEditId")
    //        .val(id.trim());

    //    jQuery("#CustomerEditName")
    //        .val(
    //            jQuery("#CustName_" + id.trim()).text().trim()
    //    );

    //    jQuery("#CustomerEditAddress")
    //        .val(
    //            jQuery("#CustAddr_" + id.trim()).text().trim()
    //    );

    //    jQuery("#CustomerEditPin")
    //        .val(
    //            jQuery("#CustPin_" + id.trim()).text().trim()
    //    );

    //    jQuery("#CustomerEditPhone")
    //        .val(
    //            jQuery("#CustPin_" + id.trim()).text().trim()
    //    );

    //    jQuery("#CustomerEditEmail")
    //        .val(
    //            jQuery("#CustEmail_" + id.trim()).text().trim()
    //    );

    //});

    jQuery("#EditBtnCustomer").click(function () {
        var customerMaster = new Object(); 
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

    jQuery(".CustDeleteButton").click(function () {

        var buttonID = jQuery(this).attr("id");
        var custId = buttonID.substring(11);
        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteCustomer",
            data: '{custId : ' + custId + ' }',
            //data: JSON.stringify(customerMaster),
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