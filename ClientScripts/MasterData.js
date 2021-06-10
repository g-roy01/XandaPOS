
//Product Group Master Grid Refresh
function ReloadProdGrpMasterData() {
    //Check the table class
    jQuery(".tableProdGrpLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadProductGroupMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.ProdGrpMasterList, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                + "<td id ='ProdGrpName_" + item.prod_grp_id + "'>" + item.prod_grp_name + "</td >"
                + "<td class='' id='ProdGrpTypeName_" + item.prod_grp_id + "'>" + item.prod_grp_type + "</td >"
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
                + "<a href='javascript:void(0)' class='dropdown-item click-edit ProdGrpEditButton' id='ProdGrpEdit_" + item.prod_grp_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                + "<a class='dropdown-item confirm-delete ProdGrpDeleteButton' id='ProdGrpDelete_" + item.prod_grp_id + "' title='Delete' href='#'>Delete</a>"
                + "</div>"
                + "</div>"
                + "</td >"
                + "</tr >";
            

            jQuery(".tableProdGrpLoad tbody").append(row);
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

//Brand Master Grid Refresh - TO BE UPDATED
function ReloadBrandMasterData() {
    //Check the table class
    //jQuery(".tableCustomerLoad tbody tr").remove();

    //jQuery.ajax({
    //    url: "/Masterdata/GetReloadCustomerMaster",
    //    type: "POST",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {
    //        //var item = '';
    //        jQuery.each(data.CustMasterList, function (i, item) {
    //            var row =
    //                "<tr class='kt-table-row kt-table-row-level-0'>"
    //                + "<td id='CustName_" + item.cust_id + "'>" + item.cust_name + "</td>"
    //                + "<td class='' id='CustAddr_" + item.cust_id + "'>" + item.cust_addr + "</td >"
    //                + "<td class='' id='CustPin_" + item.cust_id + "'>" + item.cust_pin + "</td >"
    //                + "<td class='' id='CustPhn_" + item.cust_id + "'>" + item.cust_phn + "</td >"
    //                + "<td class='' id='CustEmail_" + item.cust_id + "'>" + item.cust_email + "</td >"
    //                + "<td>"
    //                + "<div class='card-toolbar text-right'>"
    //                + "<button class='btn p-0 shadow-none' type='button' id='dropdowneditButton' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>"
    //                + "<span class='svg-icon'>"
    //                + "<svg width='20px' height='20px' viewBox='0 0 16 16' class='bi bi-three-dots text-body' fill='currentColor' xmlns='http://www.w3.org/2000/svg'>"
    //                + "<path fill-rule='evenodd' d='M3 9.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z'></path>"
    //                + "</svg>"
    //                + "</span>"
    //                + "</button>"
    //                + "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='dropdowneditButton' style='position: absolute; transform: translate3d(1001px, 111px, 0px); top: 0px; left: 0px; will-change: transform;'>"
    //                + "<a href='javascript:void(0)' class='dropdown-item click-edit CustEditButton' id='CustEdit_" + item.cust_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
    //                + "<a class='dropdown-item confirm-delete CustDeleteButton' id='CustDelete_" + item.cust_id + "' title='Delete' href='#'>Delete</a>"
    //                + "</div>"
    //                + "</div>"
    //                + "</td >"
    //                + "</tr >";


    //            jQuery(".tableCustomerLoad tbody").append(row);
    //        });
    //    },
    //    failure: function (response) {
    //        //alert(response.responseText);
    //    },
    //    error: function (response) {
    //        //Insert error handling code here
    //    }
    //});
    return false;
}

//Customer Master Grid Refresh
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

    //************************************//
    //BRAND MASTER CODE SECTION START     //
    //************************************//

    //Brand Master Add Panel Open - TO BE UPDATED
    //jQuery('#kt_notes_panel_toggle_brand').on("click", function (e) {

        ////The script has been used from script.bundle.js
        ////For all the Add Panel this code must be used to open the edit panel
        //jQuery('#kt_notes_panel').addClass('offcanvas-on');

        ////Cleaning the Customer Add Field
        //jQuery("#CustNameAdd").val('');
        //jQuery("#CustAddressAdd").val('');
        //jQuery("#CustPinCodeAdd").val('');
        //jQuery("#CustPhnDataAdd").val('');
        //jQuery("#CustEmailDataAdd").val('');

        ////Setting focus to the Customer Name field
        //jQuery("#CustNameAdd").focus();
    //});

    //========================================================================//

    //************************************//
    //CUSTOMER MASTER CODE SECTION START  //
    //************************************//

    //Customer Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_customer').on("click", function (e) {

        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Customer Add Field
        jQuery("#CustNameAdd").val('');
        jQuery("#CustAddressAdd").val('');
        jQuery("#CustPinCodeAdd").val('');
        jQuery("#CustPhnDataAdd").val('');
        jQuery("#CustEmailDataAdd").val('');

        //Setting focus to the Customer Name field
        jQuery("#CustNameAdd").focus();
    });

    //Customer Master Add To DB
    jQuery("#AddBtnCustomer").click(function () {
        var customerMaster = new Object(); //{}; 
        //customerMaster.cust_id = '';
        customerMaster.cust_name = jQuery('#CustNameAdd').val();
        customerMaster.cust_addr = jQuery('#CustAddressAdd').val();
        customerMaster.cust_pin = jQuery('#CustPinCodeAdd').val();
        customerMaster.cust_phn = jQuery('#CustPhnDataAdd').val();
        customerMaster.cust_email = jQuery('#CustEmailDataAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddCustomer",
            data: JSON.stringify(customerMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
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

    //Customer Master Edit Panel Open
    jQuery(document).on('click', '.CustEditButton', function () {
        //ReloadCustomerMasterData();

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#CustomerEditId").val('');
        jQuery("#CustomerEditName").val('');
        jQuery("#CustomerEditAddress").val('');
        jQuery("#CustomerEditPin").val('');
        jQuery("#CustomerEditPhone").val('');
        jQuery("#CustomerEditEmail").val('');


        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(9);

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetCustomerDataForEdit",
            data: '{custID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#CustomerEditId").val(data.CustMasterList[0].cust_id);
                jQuery("#CustomerEditName").val(data.CustMasterList[0].cust_name);
                jQuery("#CustomerEditAddress").val(data.CustMasterList[0].cust_addr);
                jQuery("#CustomerEditPin").val(data.CustMasterList[0].cust_pin);
                jQuery("#CustomerEditPhone").val(data.CustMasterList[0].cust_phn);
                jQuery("#CustomerEditEmail").val(data.CustMasterList[0].cust_email);
                //ajaxStop();
            },
            failure: function (response) {
                //jQuery('.modal_pre_loader').hide();
                //alert(response.responseText);
            },
            error: function (response) {
                //jQuery('.modal_pre_loader').hide();
                //Insert error handling code here
            }
        });
        return false;
    });

    //Customer Master Edit To DB
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
                jQuery('.editpopup').removeClass('offcanvas-on');
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

    //Customer Master Delete Button Setup
    jQuery(document).on('click', '.CustDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var custId = buttonID.substring(11);

        //The code has been used from sweetalert1.js
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
            if (t.value) { //Deletion Process - If 'Yes' is clicked
                DeleteCustomer(custId);
            }
            else { //If 'No' is clicked
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

    //Customer Master Delete From DB
    function DeleteCustomer(custId) {

            jQuery.ajax({
                type: "POST",
                url: "/Masterdata/DeleteCustomer",
                data: '{custId : ' + custId + ' }',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    ReloadCustomerMasterData();
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

    //************************************//
    //CUSTOMER MASTER CODE SECTION END    //
    //************************************//

    //========================================================================//

    //**************************************//
    //PROD GROUP MASTER CODE SECTION START  //
    //**************************************//

    //Product Group Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_prodGrp').on("click", function (e) {

        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Customer Add Field
        jQuery("#ProdGrpNameAdd").val('');
        jQuery("#ProdGrpTypeAdd").val('');

        //Setting focus to the Customer Name field
        jQuery("#ProdGrpNameAdd").focus();
    });

    //Product Group Master Add To DB
    jQuery("#AddBtnProdGrp").click(function () {
        var prodGrpMaster = new Object(); //{}; 
        //prodGrpMaster.prod_grp_id = '';
        prodGrpMaster.prod_grp_name = jQuery('#ProdGrpNameAdd').val();
        prodGrpMaster.prod_grp_type = jQuery('#ProdGrpTypeAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddProdGrp",
            data: JSON.stringify(prodGrpMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadProdGrpMasterData();
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

    //Product Group Master Edit Panel Open
    jQuery(document).on('click', '.ProdGrpEditButton', function () {
        //ReloadProdGrpMasterData();

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#ProdGrpEditId").val('');
        jQuery("#ProdGrpEditName").val('');
        jQuery("#ProdGrpEditType").val('');

        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(12); //ProdGrpEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetProdGrpDataForEdit",
            data: '{prodGrpID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#ProdGrpEditId").val(data.ProdGrpMasterList[0].prod_grp_id);
                jQuery("#ProdGrpEditName").val(data.ProdGrpMasterList[0].prod_grp_name);
                jQuery("#ProdGrpEditType").val(data.ProdGrpMasterList[0].prod_grp_type);
                //ajaxStop();
            },
            failure: function (response) {
                //jQuery('.modal_pre_loader').hide();
                //alert(response.responseText);
            },
            error: function (response) {
                //jQuery('.modal_pre_loader').hide();
                //Insert error handling code here
            }
        });
        return false;
    });

    //Product Group Master Edit To DB
    jQuery("#EditBtnProdGrp").click(function () {
        var prodGrpMaster = new Object();
        prodGrpMaster.prod_grp_id = jQuery('#ProdGrpEditId').val();
        prodGrpMaster.prod_grp_name = jQuery('#ProdGrpEditName').val();
        prodGrpMaster.prod_grp_type = jQuery('#ProdGrpEditType').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditProdGrp",
            data: JSON.stringify(prodGrpMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadProdGrpMasterData();
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

    //Product Group Master Delete Button Setup
    jQuery(document).on('click', '.ProdGrpDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var prodGrpId = buttonID.substring(14); //ProdGrpDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Product Group data will be deleted!",
            type: "warning", showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!",
            confirmButtonClass: "btn btn-primary",
            cancelButtonClass: "btn btn-danger ml-1",
            buttonsStyling: !1
        }).then(function (t) {
            //Here the click operation will be checked 
            if (t.value) { //Deletion Process - If 'Yes' is clicked
                DeleteProductGroup(prodGrpId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Product Group Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Product Group Master Delete From DB
    function DeleteProductGroup(prodGrpId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteProdGrp",
            data: '{prodGrpId : ' + prodGrpId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadProdGrpMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Product Group Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Product Group Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Product Group Data cannot been deleted, as unexpected condition occured!",
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