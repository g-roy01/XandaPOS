//Load grid
//function loadCustomerGrid() {
//    //$.ajax({
//    //    type: "GET",
//    //    url: "/MasterData/LoadCustomerGrid",
//    //    datatype: "json",
//    //    contentType: "application/json; charset=utf-8",
//    //    success: function (result) {
//    //        $("#FlatGrid").ejGrid("dataSource", result);
//    //    },
//    //    error: function (args) {
//    //        alert('error occurred');
//    //    }
//    //});
//    alert("aasd");
//} 

function ReloadCustomerMasterData() {
    //Check the table class
    jQuery(".tableCustomerLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadCustomerMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
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
            //alert(response.responseText);
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
            },
            failure: function (response){
                //alert(response.responseText);
            }, 
            error: function (response){
                //Insert error handling code here
            }
        });
        return false;
    });

    jQuery(document).on('click', '.CustEditButton', function () {
        ReloadCustomerMasterData();

        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        var buttonID = jQuery(this).attr("id");
        //alert(buttonID);
        var id = buttonID.substring(9);
        jQuery.ajax({
            url: "/Masterdata/GetCustomerDataForEdit",
            data: '{custID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                
                alert(data.CustMasterList[0].cust_id);
                jQuery("#CustomerEditId").val(data.CustMasterList[0].cust_id);
                jQuery("#CustomerEditName").val(data.CustMasterList[0].cust_name);
                jQuery("#CustomerEditAddress").val(data.CustMasterList[0].cust_addr);
                jQuery("#CustomerEditPin").val(data.CustMasterList[0].cust_pin);
                jQuery("#CustomerEditPhone").val(data.CustMasterList[0].cust_phn);
                jQuery("#CustomerEditEmail").val(data.CustMasterList[0].cust_email);
            },
            failure: function (response) {
                //alert(response.responseText);
            },
            error: function (response) {
                //Insert error handling code here
            }
        });
        return false;
    });
    
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
            data: JSON.stringify(customerMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadCustomerMasterData();
            },
            failure: function (response) {
                //alert(response.responseText);
            },
            error: function (response) {
                //Insert error handling code here
            }
        });
        return false;
    });

    //jQuery(".confirm-delete").on("click", function () { 
    //jQuery(".CustDeleteButton").click(function () {
    jQuery(document).on('click', '.CustDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var custId = buttonID.substring(11);
        //The code has been used from sweetalert1.js
        //Swal.fire({
        //    title: "Are you sure ?",
        //    text: "Customer data will be deleted!",
        //    type: "warning", showCancelButton: !0,
        //    confirmButtonColor: "#3085d6",
        //    cancelButtonColor: "#d33",
        //    confirmButtonText: "Yes, delete it!",
        //    confirmButtonClass: "btn btn-primary",
        //    cancelButtonClass: "btn btn-danger ml-1",
        //    buttonsStyling: !1
        //}).then(function (t) {
        //    t.value ?
        //        Swal.fire({
        //            type: "success",
        //            title: "Deleted!",
        //            text: "Customer Data has been deleted.",
        //            confirmButtonClass: "btn btn-success"
        //        })
        //        : t.dismiss === Swal.DismissReason.cancel && Swal.fire
        //            ({
        //                title: "Cancelled", text: "Customer Data is safe :)",
        //                type: "error", confirmButtonClass: "btn btn-success"
        //            })
        //});

        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Customer data will be deleted!",
            type: "warning", showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!",
            confirmButtonClass: "btn btn-primary",
            cancelButtonClass: "btn btn-danger ml-1",
            buttonsStyling: !1
        }).then(function (t) {
            //Here the click operation will be checked 
            if (t.value) { //Deletion Process
                DeleteCustomer(custId);
            }
            else {
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Customer Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });    
    });

    function DeleteCustomer(custId) {
        //var status = 0;
        //alert('Deleting Customer id : ' + custId);
            jQuery.ajax({
                type: "POST",
                url: "/Masterdata/DeleteCustomer",
                data: '{custId : ' + custId + ' }',
                //data: JSON.stringify(customerMaster),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    ReloadCustomerMasterData();
                    //GetCustomer();
                    Swal.fire({
                        type: "success",
                        title: "Deleted!",
                        text: "Customer Data has been deleted.",
                        confirmButtonClass: "btn btn-success"
                    });
                },
                failure: function (response) {
                    Swal.fire
                        ({
                            type: "warning",
                            title: "Deletion Fail!",
                            text: "Customer Data cannot been deleted, as server cannot process the request currently.",
                            confirmButtonClass: "btn btn-success"
                        });
                },
                error: function (response) {
                    Swal.fire
                        ({
                            type: "warning",
                            title: "Deletion Fail!",
                            text: "Customer Data cannot been deleted, as unexpected condition occured!",
                            confirmButtonClass: "btn btn-success"
                        });
                }
            });
        return false;
    }
});
    
//Insert data

//Update data

// Delete Data