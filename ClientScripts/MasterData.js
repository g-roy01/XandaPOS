//Product Master Grid Refresh
function ReloadProductMasterData() {
    //Check the table class
    jQuery(".tableProductLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadProductMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.ProductMasterList.mainProductData, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id ='ProductName_" + item.product_id + "'>" + item.product_name + "</td >"
                    + "<td id='ProductTypeName_" + item.product_id + "'>" + item.product_type_name + "</td >"
                    + "<td id='ProductGroupName_" + item.product_id + "'>" + item.product_group_name + "</td >"
                    + "<td id='ProductCompanyName_" + item.product_id + "'>" + item.product_company_name + "</td >"
                    + "<td id='ProductDetails_" + item.product_id + "'>" + item.product_details + "</td >"
                    //+ "<td id='ProductImageLink_" + item.product_id + "'>" + item.product_image_link + "</td >"
                    + "<td id='ProductImageLink_" + item.product_id + "'><img src='/Avatars/" + item.product_image_link + "' height='50' width='50' /></td >"
                    + "<td id='ProductCode_" + item.product_id + "'>" + item.product_code + "</td >"
                    + "<td id='ProductDefaultCost_" + item.product_id + "'>" + Number(item.product_default_cost).toFixed(2) + "</td >"
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
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit ProductEditButton' id='ProductEdit_" + item.product_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete ProductDeleteButton' id='ProductDelete_" + item.product_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableProductLoad tbody").append(row);
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

//Warehouse Master Grid Refresh
function ReloadWarehouseMasterData() {
    //Check the table class
    jQuery(".tableWarehouseLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadWarehouseMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.WarehouseMasterList, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id ='WarehouseName_" + item.warehouse_id + "'>" + item.warehouse_name + "</td >"
                    + "<td id='WarehouseAddr_" + item.warehouse_id + "'>" + item.warehouse_address + "</td >"
                    + "<td id='WarehousePin_" + item.warehouse_id + "'>" + item.warehouse_pin + "</td >"
                    + "<td id='WarehousePhone_" + item.warehouse_id + "'>" + item.warehouse_phone + "</td >"
                    + "<td id='WarehouseCode_" + item.warehouse_id + "'>" + item.warehouse_code + "</td >"
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
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit WarehouseEditButton' id='WarehouseEdit_" + item.warehouse_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete WarehouseDeleteButton' id='WarehouseDelete_" + item.warehouse_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableWarehouseLoad tbody").append(row);
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

//Company Master Grid Refresh
function ReloadEmployeeMasterData() {
    //Check the table class
    jQuery(".tableEmployeeLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadEmployeeMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.EmpMasterList, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id ='EmpName_" + item.emp_id + "'>" + item.emp_name + "</td >"
                    + "<td class='' id='EmpAddr_" + item.emp_id + "'>" + item.emp_addr + "</td >"
                    + "<td class='' id='EmpPin_" + item.emp_id + "'>" + item.emp_pin + "</td >"
                    + "<td class='' id='EmpPhone_" + item.emp_id + "'>" + item.emp_phone + "</td >"
                    + "<td class='' id='EmpEmail_" + item.emp_id + "'>" + item.emp_email + "</td >"
                    + "<td class='' id='EmpGovtIdType_" + item.emp_id + "'>" + item.emp_govt_id_type + "</td >"
                    + "<td class='' id='EmpGovtIdNo_" + item.emp_id + "'>" + item.emp_govt_id_no + "</td >"
                    + "<td class='' id='EmpJoinDate_" + item.emp_id + "'>" + item.emp_join_date + "</td >"
                    + "<td class='' id='EmpResignDate_" + item.emp_id + "'>" + item.emp_resign_date + "</td >"
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
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit EmpEditButton' id='EmpEdit_" + item.emp_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete EmpDeleteButton' id='EmpDelete_" + item.emp_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableEmployeeLoad tbody").append(row);
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

//Company Master Grid Refresh
function ReloadCompanyMasterData() {
    //Check the table class
    jQuery(".tableCompanyLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadCompanyMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.CompanyMasterList, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id ='CompanyName_" + item.comp_id + "'>" + item.comp_name + "</td >"
                    + "<td class='' id='CompanyAddr_" + item.comp_id + "'>" + item.comp_address + "</td >"
                    + "<td class='' id='CompanyPin_" + item.comp_id + "'>" + item.comp_pin + "</td >"
                    + "<td class='' id='CompanyType_" + item.comp_id + "'>" + item.comp_type_name + "</td >"
                    + "<td class='' id='CompanyRegnNo_" + item.comp_id + "'>" + item.comp_regn_no + "</td >"
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
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit CompanyEditButton' id='CompanyEdit_" + item.comp_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete CompanyDeleteButton' id='CompanyDelete_" + item.comp_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableCompanyLoad tbody").append(row);
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

//Helper Master Grid Refresh
function ReloadHelperMasterData() {
    //Check the table class
    jQuery(".tableHelperLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadHelperMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.HelperMasterList, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id ='HelperName_" + item.helper_id + "'>" + item.helper_name + "</td >"
                    + "<td class='' id='HelperFor_" + item.helper_id + "'>" + item.helper_link_master_table + "</td >"
                    + "<td class='' id='HelperDetails_" + item.helper_id + "'>" + item.helper_details + "</td >"
                    + "<td class='' id='HelperActive_" + item.helper_id + "'>" + item.helper_active + "</td >"
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
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit HelperEditButton' id='HelperEdit_" + item.helper_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete HelperDeleteButton' id='HelperDelete_" + item.helper_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableHelperLoad tbody").append(row);
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

//Brand Master Grid Refresh 
function ReloadBrandMasterData() {
    //Check the table class
    jQuery(".tableBrandLoad tbody tr").remove();

    jQuery.ajax({
        url: "/Masterdata/GetReloadBrandMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var item = '';
            jQuery.each(data.BrandMasterList.mainBrandData, function (i, item) {
                var row =
                    "<tr class='kt-table-row kt-table-row-level-0'>"
                    + "<td id='BrandName_" + item.brand_id + "'>" + item.brand_name + "</td >"
                    + "<td class='' id='BrandCompany_" + item.brand_id + "'>" + item.brand_company_name + "</td >"
                    + "<td class='' id='BrandProdGrp_" + item.brand_id + "'>" + item.brand_product_group_name + "</td >"
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
                    + "<a href='javascript:void(0)' class='dropdown-item click-edit BrandEditButton' id='BrandEdit_" + item.brand_id + "' data-toggle='tooltip' title='' data-placement='right' data-original-title='Check out more demos'>Edit</a>"
                    + "<a class='dropdown-item confirm-delete BrandDeleteButton' id='BrandDelete_" + item.brand_id + "' title='Delete' href='#'>Delete</a>"
                    + "</div>"
                    + "</div>"
                    + "</td >"
                    + "</tr >";


                jQuery(".tableBrandLoad tbody").append(row);
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

//Customer Master Grid Refresh
function ReloadCustomerMasterData() {
    //Check the table class
    jQuery(".tableCustomerLoad tbody tr").remove();
    //jQuery(".tableCustomerLoad tbody tr").empty();

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
            failure: function (response) {
                //alert(response.responseText);
            },
            error: function (response) {
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

        //jQuery('.se-pre-con_2').css('background-color', 'rgba(0, 0, 0, 0.5)');

        
        
        jQuery.ajax({
            url: "/Masterdata/GetCustomerDataForEdit",
            data: '{custID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                jQuery('.se-pre-con_2').show();
            },
            success: function (data) {
                jQuery("#CustomerEditId").val(data.CustMasterList[0].cust_id);
                jQuery("#CustomerEditName").val(data.CustMasterList[0].cust_name);
                jQuery("#CustomerEditAddress").val(data.CustMasterList[0].cust_addr);
                jQuery("#CustomerEditPin").val(data.CustMasterList[0].cust_pin);
                jQuery("#CustomerEditPhone").val(data.CustMasterList[0].cust_phn);
                jQuery("#CustomerEditEmail").val(data.CustMasterList[0].cust_email);
                jQuery('.se-pre-con_2').fadeOut("slow");
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

        //Cleaning the Product Group Add Field
        jQuery("#ProdGrpNameAdd").val('');
        jQuery("#ProdGrpTypeAdd").val('');

        //Setting focus to the Product Name field
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

    //**************************************//
    //PROD GROUP MASTER CODE SECTION END    //
    //**************************************//

    //========================================================================//

    //**********************************//
    //HELPER MASTER CODE SECTION START  //
    //**********************************//

    //Helper Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_helper').on("click", function (e) {

        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Helper Add Field
        jQuery("#HelperNameAdd").val('');
        jQuery('#HelperForAdd').val('NA');
        jQuery("#HelperDetailsAdd").val('');
        jQuery('#HelperInUseAdd').val('True');

        //Setting focus to the Helper Name field
        jQuery("#HelperNameAdd").focus();
    });

    //Helper Master Add To DB
    jQuery("#AddBtnHelper").click(function () {
        var helperMaster = new Object(); //{}; 
        //helperMaster.helper_id = '';
        helperMaster.helper_name = jQuery('#HelperNameAdd').val();
        helperMaster.helper_link_master_table = jQuery('#HelperForAdd').val();
        helperMaster.helper_details = jQuery('#HelperDetailsAdd').val();
        helperMaster.helper_active = jQuery('#HelperInUseAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddHelper",
            data: JSON.stringify(helperMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadHelperMasterData();
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

    //Helper Master Edit Panel Open
    jQuery(document).on('click', '.HelperEditButton', function () {

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#HelperNameAdd").val('');
        jQuery('#HelperForAdd').val('NA');
        jQuery("#HelperDetailsAdd").val('');
        jQuery('#HelperInUseAdd').val('True');

        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(11); //HelperEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetHelperDataForEdit",
            data: '{helperID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#HelperEditId").val(data.HelperMasterList[0].helper_id);
                jQuery("#HelperEditName").val(data.HelperMasterList[0].helper_name);
                jQuery("#HelperEditFor").val(data.HelperMasterList[0].helper_link_master_table);
                jQuery("#HelperEditDetails").val(data.HelperMasterList[0].helper_details);
                jQuery("#HelperInUseAdd").val(data.HelperMasterList[0].helper_active);
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

    //Helper Master Edit To DB
    jQuery("#EditBtnHelper").click(function () {
        var helperMaster = new Object();

        helperMaster.helper_id = jQuery("#HelperEditId").val();
        helperMaster.helper_name = jQuery("#HelperEditName").val();
        helperMaster.helper_link_master_table = jQuery("#HelperEditFor").val();
        helperMaster.helper_details = jQuery("#HelperEditDetails").val();
        helperMaster.helper_active = jQuery("#HelperEditInUse").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditHelper",
            data: JSON.stringify(helperMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadHelperMasterData();
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

    //Helper Master Delete Button Setup
    jQuery(document).on('click', '.HelperDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var helperId = buttonID.substring(13); //HelperDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Helper data will be deleted!",
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
                DeleteHelper(helperId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Helper Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Helper Master Delete From DB
    function DeleteHelper(helperId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteHelper",
            data: '{helperId : ' + helperId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadHelperMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Helper Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Helper Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Helper Data cannot been deleted, as unexpected condition occured!",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
        return false;
    }

    //**********************************//
    //HELPER MASTER CODE SECTION END    //
    //**********************************//

    //========================================================================//

    //***********************************//
    //COMPANY MASTER CODE SECTION START  //
    //***********************************//

    //Company Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_company').on("click", function (e) {

        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Helper Add Field
        jQuery("#CompanyNameAdd").val('');
        jQuery('#CompanyAddrAdd').val('');
        jQuery("#CompanyPinAdd").val('');
        jQuery('#CompanyTypeAdd').val('NA');
        jQuery('#CompanyRegnAdd').val('');

        //Setting focus to the Helper Name field
        jQuery("#CompanyNameAdd").focus();
    });

    //Company Master Add To DB
    jQuery("#AddBtnCompany").click(function () {
        var companyMaster = new Object(); //{}; 
        //companyMaster.comp_id = '';
        companyMaster.comp_name = jQuery('#CompanyNameAdd').val();
        companyMaster.comp_address = jQuery('#CompanyAddrAdd').val();
        companyMaster.comp_pin = jQuery('#CompanyPinAdd').val();
        companyMaster.comp_type = jQuery('#CompanyTypeAdd').val();
        companyMaster.comp_regn_no = jQuery('#CompanyRegnAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddCompany",
            data: JSON.stringify(companyMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadCompanyMasterData();
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

    //Company Master Edit Panel Open
    jQuery(document).on('click', '.CompanyEditButton', function () {

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#CompanyEditName").val('');
        jQuery('#CompanyEditAddress').val('');
        jQuery("#CompanyEditPin").val('');
        jQuery('#CompanyEditType').val('NA');
        jQuery('#CompanyEditRegn').val('');

        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(12); //CompanyEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetCompanyDataForEdit",
            data: '{companyID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#CompanyEditId").val(data.CompanyMasterList[0].comp_id);
                jQuery("#CompanyEditName").val(data.CompanyMasterList[0].comp_name);
                jQuery("#CompanyEditAddress").val(data.CompanyMasterList[0].comp_address);
                jQuery("#CompanyEditPin").val(data.CompanyMasterList[0].comp_pin);
                //jQuery("#HelperInUseAdd").val(data.CompanyMasterList[0].comp_);
                jQuery("#CompanyEditType").val(data.CompanyMasterList[0].comp_type_name);
                jQuery("#CompanyEditRegn").val(data.CompanyMasterList[0].comp_regn_no);
                
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

    //Company Master Edit To DB
    jQuery("#EditBtnCompany").click(function () {
        var companyMaster = new Object();

        companyMaster.comp_id = jQuery("#CompanyEditId").val();
        companyMaster.comp_name = jQuery("#CompanyEditName").val();
        companyMaster.comp_address = jQuery("#CompanyEditAddress").val();
        companyMaster.comp_pin = jQuery("#CompanyEditPin").val();
        companyMaster.comp_type = jQuery("#CompanyEditType").val();
        companyMaster.comp_regn_no = jQuery("#CompanyEditRegn").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditCompany",
            data: JSON.stringify(companyMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadCompanyMasterData();
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

    //Company Master Delete Button Setup
    jQuery(document).on('click', '.CompanyDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var compId = buttonID.substring(14); //CompanyDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Company data will be deleted!",
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
                DeleteCompany(compId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Company Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Helper Master Delete From DB
    function DeleteCompany(compId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteCompany",
            data: '{compId : ' + compId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadCompanyMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Company Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Company Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Company Data cannot been deleted, as unexpected condition occured!",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
        return false;
    }

    //***********************************//
    //COMPANY MASTER CODE SECTION END    //
    //***********************************//

    //========================================================================//

    //*********************************//
    //BRAND MASTER CODE SECTION START  //
    //*********************************//

    //Brand Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_brand').on("click", function (e) {

        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Helper Add Field
        jQuery("#BrandNameAdd").val('');
        jQuery('#BrandCompanyAdd').val('NA');
        jQuery("#BrandProdGrpAdd").val('NA');

        //Setting focus to the Helper Name field
        jQuery("#BrandNameAdd").focus();
    });

    //Brand Master Add To DB
    jQuery("#AddBtnBrand").click(function () {
        var brandMaster = new Object(); //{}; 

        //brandMaster.brand_id = '';
        brandMaster.brand_name = jQuery('#BrandNameAdd').val();
        brandMaster.brand_company = jQuery('#BrandCompanyAdd').val();
        brandMaster.brand_product_group = jQuery('#BrandProdGrpAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddBrand",
            data: JSON.stringify(brandMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadBrandMasterData();
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

    //Brand Master Edit Panel Open
    jQuery(document).on('click', '.BrandEditButton', function () {

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#BrandEditName").val('');
        jQuery('#BrandEditCompany').val('NA');
        jQuery("#BrandEditProdGrp").val('NA');

        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(10); //BrandEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetBrandDataForEdit",
            data: '{brandID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#BrandEditId").val(data.BrandMasterList.mainBrandData[0].brand_id);
                jQuery("#BrandEditName").val(data.BrandMasterList.mainBrandData[0].brand_name);
                jQuery("#BrandEditCompany").val(data.BrandMasterList.mainBrandData[0].brand_company_name);
                jQuery("#BrandEditProdGrp").val(data.BrandMasterList.mainBrandData[0].brand_product_group_name);
                //jQuery("#HelperInUseAdd").val(data.CompanyMasterList[0].comp_);
                //jQuery("#CompanyEditType").val(data.CompanyMasterList[0].comp_type_name);
                //jQuery("#CompanyEditRegn").val(data.CompanyMasterList[0].comp_regn_no);

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

    //Brand Master Edit To DB
    jQuery("#EditBtnBrand").click(function () {
        var brandMaster = new Object();

        brandMaster.brand_id = jQuery("#BrandEditId").val();
        brandMaster.brand_name = jQuery("#BrandEditName").val();
        brandMaster.brand_company = jQuery("#BrandEditCompany").val();
        brandMaster.brand_product_group = jQuery("#BrandEditProdGrp").val();
        //companyMaster.comp_type = jQuery("#CompanyEditType").val();
        //companyMaster.comp_regn_no = jQuery("#CompanyEditRegn").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditBrand",
            data: JSON.stringify(brandMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadBrandMasterData();
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

    //Brand Master Delete Button Setup
    jQuery(document).on('click', '.BrandDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var brandId = buttonID.substring(12); //BrandDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Brand data will be deleted!",
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
                DeleteBrand(brandId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Brand Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Brand Master Delete From DB
    function DeleteBrand(brandId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteBrand",
            data: '{brandId : ' + brandId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadBrandMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Brand Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Brand Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Brand Data cannot been deleted, as unexpected condition occured!",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
        return false;
    }

    //*******************************//
    //BRAND MASTER CODE SECTION END  //
    //*******************************//

    //========================================================================//

    //***********************************//
    //EMPLOYEE MASTER CODE SECTION START  //
    //***********************************//

    //Employee Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_employee').on("click", function (e) {

        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Helper Add Field
        jQuery("#EmpNameAdd").val('');
        jQuery('#EmpAddressAdd').val('');
        jQuery("#EmpPinAdd").val('');
        jQuery("#EmpPhnDataAdd").val('');
        jQuery('#EmpEmailDataAdd').val('');
        jQuery("#EmpGovtIdTypeAdd").val('');
        jQuery("#EmpGovtIdNoAdd").val('');
        jQuery('#EmpJoinDateAdd').val('');
        jQuery("#EmpResignDateAdd").val('');

        //Setting focus to the Helper Name field
        jQuery("#EmpNameAdd").focus();
    });

    //Employee Master Add To DB
    jQuery("#AddBtnEmployee").click(function () {
        var employeeMaster = new Object(); //{}; 

        //employeeMaster.emp_id = '';
        employeeMaster.emp_name = jQuery("#EmpNameAdd").val();
        employeeMaster.emp_addr = jQuery('#EmpAddressAdd').val();
        employeeMaster.emp_pin = jQuery("#EmpPinAdd").val();
        employeeMaster.emp_phone = jQuery("#EmpPhnDataAdd").val();
        employeeMaster.emp_email = jQuery('#EmpEmailDataAdd').val();
        employeeMaster.emp_govt_id_type = jQuery("#EmpGovtIdTypeAdd").val();
        employeeMaster.emp_govt_id_no = jQuery("#EmpGovtIdNoAdd").val();
        employeeMaster.emp_join_date = jQuery('#EmpJoinDateAdd').val();
        employeeMaster.emp_resign_date = jQuery("#EmpResignDateAdd").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddEmployee",
            data: JSON.stringify(employeeMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadEmployeeMasterData();
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

    //Employee Master Edit Panel Open
    jQuery(document).on('click', '.EmpEditButton', function () {

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#EmpEditName").val('');
        jQuery('#EmpEditAddress').val('');
        jQuery("#EmpEditPin").val('');
        jQuery("#EmpEditPhnData").val('');
        jQuery('#EmpEditEmailData').val('');
        jQuery("#EmpEditGovtIdType").val('');
        jQuery("#EmpEditGovtIdNo").val('');
        jQuery('#EmpEditJoinDate').val('');
        jQuery("#EmpEditResignDate").val('');

        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(8); //EmpEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetEmployeeDataForEdit",
            data: '{empID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#EmpEditId").val(data.EmpMasterList[0].emp_id);
                jQuery("#EmpEditName").val(data.EmpMasterList[0].emp_name);
                jQuery("#EmpEditAddress").val(data.EmpMasterList[0].emp_addr);
                jQuery("#EmpEditPin").val(data.EmpMasterList[0].emp_pin);
                jQuery("#EmpEditPhnData").val(data.EmpMasterList[0].emp_phone);
                jQuery("#EmpEditEmailData").val(data.EmpMasterList[0].emp_email);
                jQuery("#EmpEditGovtIdType").val(data.EmpMasterList[0].emp_govt_id_type);
                jQuery("#EmpEditGovtIdNo").val(data.EmpMasterList[0].emp_govt_id_no);
                jQuery("#EmpEditJoinDate").val(data.EmpMasterList[0].emp_join_date);
                jQuery("#EmpEditResignDate").val(data.EmpMasterList[0].emp_resign_date);

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

    //Employee Master Edit To DB
    jQuery("#EditBtnEmployee").click(function () {
        var empMaster = new Object();

        empMaster.emp_id = jQuery("#EmpEditId").val();
        empMaster.emp_name = jQuery("#EmpEditName").val();
        empMaster.emp_addr = jQuery("#EmpEditAddress").val();
        empMaster.emp_pin = jQuery("#EmpEditPin").val();
        empMaster.emp_phone = jQuery("#EmpEditPhnData").val();
        empMaster.emp_email = jQuery("#EmpEditEmailData").val();
        empMaster.emp_govt_id_type = jQuery("#EmpEditGovtIdType").val();
        empMaster.emp_govt_id_no = jQuery("#EmpEditGovtIdNo").val();
        empMaster.emp_join_date = jQuery("#EmpEditJoinDate").val();
        empMaster.emp_resign_date = jQuery("#EmpEditResignDate").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditEmployee",
            data: JSON.stringify(empMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadEmployeeMasterData();
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

    //Employee Master Delete Button Setup
    jQuery(document).on('click', '.EmpDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var empId = buttonID.substring(10); //EmpDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Employee data will be deleted!",
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
                DeleteEmployee(empId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Employee Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Employee Master Delete From DB
    function DeleteEmployee(empId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteEmployee",
            data: '{empId : ' + empId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadEmployeeMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Employee Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Employee Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Employee Data cannot been deleted, as unexpected condition occured!",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
        return false;
    }

    //**********************************//
    //EMPLOYEE MASTER CODE SECTION END  //
    //**********************************//

    //========================================================================//

    //*************************************//
    //WAREHOUSE MASTER CODE SECTION START  //
    //*************************************//

    //Warehouse Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_warehouse').on("click", function (e) {
        
        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Helper Add Field
        jQuery("#WarehouseNameAdd").val('');
        jQuery('#WarehouseAddressAdd').val('');
        jQuery("#WarehousePinCodeAdd").val('');
        jQuery("#WarehousePhoneAdd").val('');
        jQuery('#WarehouseCodeAdd').val('');
 
        //Setting focus to the Helper Name field
        jQuery("#WarehouseNameAdd").focus();
    });

    //Warehouse Master Add To DB
    jQuery("#AddBtnWarehouse").click(function () {
        var warehouseMaster = new Object(); //{}; 

        //warehouseMaster.warehouse_id = '';
        warehouseMaster.warehouse_name = jQuery("#WarehouseNameAdd").val();
        warehouseMaster.warehouse_address = jQuery('#WarehouseAddressAdd').val();
        warehouseMaster.warehouse_pin = jQuery("#WarehousePinCodeAdd").val();
        warehouseMaster.warehouse_phone = jQuery("#WarehousePhoneAdd").val();
        warehouseMaster.warehouse_code = jQuery('#WarehouseCodeAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddWarehouse",
            data: JSON.stringify(warehouseMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadWarehouseMasterData();
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

    //Warehouse Master Edit Panel Open
    jQuery(document).on('click', '.WarehouseEditButton', function () {

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#WarehouseEditName").val('');
        jQuery('#WarehouseEditAddress').val('');
        jQuery("#WarehouseEditPin").val('');
        jQuery("#WarehouseEditPhone").val('');
        jQuery('#WarehouseEditCode').val('');

        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(14); //WarehouseEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetWarehouseDataForEdit",
            data: '{warehouseID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#WarehouseEditId").val(data.WarehouseMasterList[0].warehouse_id);
                jQuery("#WarehouseEditName").val(data.WarehouseMasterList[0].warehouse_name);
                jQuery("#WarehouseEditAddress").val(data.WarehouseMasterList[0].warehouse_address);
                jQuery("#WarehouseEditPin").val(data.WarehouseMasterList[0].warehouse_pin);
                jQuery("#WarehouseEditPhone").val(data.WarehouseMasterList[0].warehouse_phone);
                jQuery("#WarehouseEditCode").val(data.WarehouseMasterList[0].warehouse_code);

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

    //Warehouse Master Edit To DB
    jQuery("#EditBtnWarehouse").click(function () {
        var warehouseMaster = new Object();

        warehouseMaster.warehouse_id = jQuery("#WarehouseEditId").val();
        warehouseMaster.warehouse_name = jQuery("#WarehouseEditName").val();
        warehouseMaster.warehouse_address = jQuery("#WarehouseEditAddress").val();
        warehouseMaster.warehouse_pin = jQuery("#WarehouseEditPin").val();
        warehouseMaster.warehouse_phone = jQuery("#WarehouseEditPhone").val();
        warehouseMaster.warehouse_code = jQuery("#WarehouseEditCode").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditWarehouse",
            data: JSON.stringify(warehouseMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadWarehouseMasterData();
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

    //Warehouse Master Delete Button Setup
    jQuery(document).on('click', '.WarehouseDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var warehouseId = buttonID.substring(16); //WarehouseDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Warehouse data will be deleted!",
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
                DeleteWarehouse(warehouseId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Warehouse Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Warehouse Master Delete From DB
    function DeleteWarehouse(warehouseId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteWarehouse",
            data: '{warehouseId : ' + warehouseId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadWarehouseMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Warehouse Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Warehouse Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Warehouse Data cannot been deleted, as unexpected condition occured!",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
        return false;
    }

    //***********************************//
    //WAREHOUSE MASTER CODE SECTION END  //
    //***********************************//

    //========================================================================//

    //***********************************//
    //PRODUCT MASTER CODE SECTION START  //
    //***********************************//

    //Product Master Add Panel Open
    jQuery('#kt_notes_panel_toggle_product').on("click", function (e) {
        
        //The script has been used from script.bundle.js
        //For all the Add Panel this code must be used to open the edit panel
        jQuery('#kt_notes_panel').addClass('offcanvas-on');

        //Cleaning the Helper Add Field
        jQuery("#ProductNameAdd").val('');
        jQuery('#ProductTypeNameAdd').val('NA');
        jQuery("#ProdGrpNameAdd").val('NA');
        jQuery("#ProdCompanyNameAdd").val('NA');
        jQuery('#ProductDetailsAdd').val('');
        jQuery('#ProductImageNameAdd').val('');
        //jQuery('#ProductImageAdd').val('');
        jQuery('#ProductCodeAdd').val('');
        jQuery('#ProductDefaultCostAdd').val('');

        //IMAGE EDIT SECTION SETUP START - PRODUCT ADD
        jQuery('.jcrop-holder div div img').attr('src', '#1'); //Selected Image In Temp Folder - This will be the 

        jQuery('.jcrop-holder img').attr('src', '#2'); //To Remove The Uploaded Image
        jQuery('.jcrop-holder').css('background', '');

         //************************FILE UPLOAD CLEARING
        jQuery('#imageUploadHolderProductAdd').val('');
        jQuery('#avatar-upload-productadd-form .upload-file-notice').text('Max Size: 4 MB');

        jQuery('#avatar-upload-productadd-form .upload-file-notice').css('background', 'white');
        jQuery('#avatar-upload-productadd-form .upload-file-notice').css('color', 'black');

        jQuery('.upload-percent-bar').width('0%');
        jQuery('.upload-percent-value').html('0%');


        jQuery('#avatar-crop-box-productadd').css('display', 'none');
        //jQuery('#Preview_pane').css('display', 'none'); // The Preview Panel Will Be Hidden
        jQuery('.jcrop-holder img').css('display', 'none'); // Image Upload Holder Will Be Hidden
        jQuery('#Preview_panel_header_productadd').css('display', 'none'); //Cropping portion live panel header

        jQuery('#finalImageProductAdd').attr('src', '#4'); //Cropped Image - Image that will be displayed at Product Insert

        //IMAGE EDIT SECTION SETUP END - PRODUCT ADD

        //Setting focus to the Helper Name field
        jQuery("#ProductNameAdd").focus();
    });

    //Product Master Add To DB
    jQuery("#AddBtnProduct").click(function () {
        var productMaster = new Object(); //{}; 

        //productMaster.product_id = '';
        productMaster.product_name = jQuery("#ProductNameAdd").val();
        productMaster.product_type = jQuery('#ProductTypeNameAdd').val();
        productMaster.product_group = jQuery("#ProdGrpNameAdd").val();
        productMaster.product_company = jQuery("#ProdCompanyNameAdd").val();
        productMaster.product_details = jQuery('#ProductDetailsAdd').val();
        productMaster.product_image_link = jQuery('#ProductImageNameAdd').val();
        productMaster.product_code = jQuery('#ProductCodeAdd').val();
        productMaster.product_default_cost = jQuery('#ProductDefaultCostAdd').val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/AddProduct",
            data: JSON.stringify(productMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                jQuery('#kt_notes_panel').removeClass('offcanvas-on');
                ReloadProductMasterData();
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

    //Product Master Edit Panel Open
    jQuery(document).on('click', '.ProductEditButton', function () {

        //The script has been used from script.bundle.js
        //For all the Edit Panel this code must be used to open the edit panel
        jQuery('.editpopup').addClass('offcanvas-on');

        //Cleaning Edit Panel Field for any old data
        jQuery("#ProductEditName").val('');
        jQuery('#ProductEditTypeName').val('NA');
        jQuery("#ProdEditGrpName").val('NA');
        jQuery("#ProdEditCompanyName").val('NA');
        jQuery('#ProductEditDetails').val('');
        jQuery('#ProductEditImage').val('');
        jQuery('#ProductEditCode').val('');
        jQuery('#ProductEditDefaultCost').val('');


        //IMAGE EDIT SECTION SETUP START - PRODUCT EDIT
        jQuery('.jcrop-holder div div img').attr('src', '#1'); //Selected Image In Temp Folder - This will be the 

        jQuery('.jcrop-holder img').attr('src', '#2'); //To Remove The Uploaded Image
        jQuery('.jcrop-holder').css('background', '');

        //************************FILE UPLOAD CLEARING
        jQuery('#imageUploadHolderProductEdit').val('');
        jQuery('#avatar-upload-productedit-form .upload-file-notice').text('Max Size: 4 MB');

        jQuery('#avatar-upload-productedit-form .upload-file-notice').css('background', 'white');
        jQuery('#avatar-upload-productedit-form .upload-file-notice').css('color', 'black');

        jQuery('.upload-percent-bar').width('0%');
        jQuery('.upload-percent-value').html('0%');


        jQuery('#avatar-crop-box-productedit').css('display', 'none');
        //jQuery('#Preview_pane').css('display', 'none'); // The Preview Panel Will Be Hidden
        jQuery('.jcrop-holder img').css('display', 'none'); // Image Upload Holder Will Be Hidden
        jQuery('#Preview_panel_header_productedit').css('display', 'none'); //Cropping portion live panel header

        jQuery('#finalImageProductEdit').attr('src', '#4'); //Cropped Image - Image that will be displayed at Product Insert

        //IMAGE EDIT SECTION SETUP END - PRODUCT EDIT









        var buttonID = jQuery(this).attr("id");
        var id = buttonID.substring(12); //ProductEdit_

        //jQuery('.modal_pre_loader').show();
        jQuery.ajax({
            url: "/Masterdata/GetProductDataForEdit",
            data: '{productID : ' + id + '}',
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                jQuery("#ProductEditId").val(data.ProdMasterList[0].product_id);
                jQuery("#ProductEditName").val(data.ProdMasterList[0].product_name);
                jQuery("#ProductEditTypeName").val(data.ProdMasterList[0].product_type_name);
                jQuery("#ProdEditGrpName").val(data.ProdMasterList[0].product_group_name);
                jQuery("#ProdEditCompanyName").val(data.ProdMasterList[0].product_company_name);
                jQuery("#ProductEditDetails").val(data.ProdMasterList[0].product_details);
                jQuery("#ProductEditImage").val(data.ProdMasterList[0].product_image_link);
                //jQuery('#finalImageProductEdit').css('display', 'block');
                //jQuery('#finalImageProductEdit').attr('src', '/Avatars/' + data.ProdMasterList[0].product_image_link); //On Edit Panel Open Here Last Image will be Shown
                jQuery('#avatar-result-productedit img').attr('src', '/Avatars/' + data.ProdMasterList[0].product_image_link);

                jQuery("#ProductEditCode").val(data.ProdMasterList[0].product_code);
                jQuery("#ProductEditDefaultCost").val(Number(data.ProdMasterList[0].product_default_cost).toFixed(2));

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

    //Product Master Edit To DB
    jQuery("#EditBtnProduct").click(function () {
        var productMaster = new Object();

        productMaster.product_id = jQuery("#ProductEditId").val();
        productMaster.product_name = jQuery("#ProductEditName").val();
        productMaster.product_type = jQuery("#ProductEditTypeName").val();
        productMaster.product_group = jQuery("#ProdEditGrpName").val();
        productMaster.product_company = jQuery("#ProdEditCompanyName").val();
        productMaster.product_details = jQuery("#ProductEditDetails").val();
        productMaster.product_image_link = jQuery("#ProductEditImage").val();
        productMaster.product_code = jQuery("#ProductEditCode").val();
        productMaster.product_default_cost = jQuery("#ProductEditDefaultCost").val();

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/EditProduct",
            data: JSON.stringify(productMaster),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //alert(data.Message);
                jQuery('.editpopup').removeClass('offcanvas-on');
                ReloadProductMasterData();
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

    //Product Master Delete Button Setup
    jQuery(document).on('click', '.ProductDeleteButton', function () {
        var buttonID = jQuery(this).attr("id");
        var productId = buttonID.substring(14); //ProductDelete_

        //The code has been used from sweetalert1.js
        //This will launch the pop-up for deletion
        Swal.fire({
            title: "Are you sure ?",
            text: "Product data will be deleted!",
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
                DeleteProduct(productId);
            }
            else { //If 'No' is clicked
                t.dismiss === Swal.DismissReason.cancel && Swal.fire
                    ({
                        type: "error",
                        title: "Cancelled!",
                        text: "Product Data is safe :)",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
    });

    //Product Master Delete From DB
    function DeleteProduct(productId) {

        jQuery.ajax({
            type: "POST",
            url: "/Masterdata/DeleteProduct",
            data: '{productId : ' + productId + ' }',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                ReloadProductMasterData();
                Swal.fire({
                    type: "success",
                    title: "Deleted!",
                    text: "Product Data has been deleted.",
                    confirmButtonClass: "btn btn-success"
                });
            },
            failure: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Product Data cannot been deleted, as server cannot process the request currently.",
                        confirmButtonClass: "btn btn-success"
                    });
            },
            error: function (response) {
                Swal.fire
                    ({
                        type: "warning",
                        title: "Deletion Fail!",
                        text: "Product Data cannot been deleted, as unexpected condition occured!",
                        confirmButtonClass: "btn btn-success"
                    });
            }
        });
        return false;
    }

    //*********************************//
    //PRODUCT MASTER CODE SECTION END  //
    //*********************************//

    //========================================================================//

});


function UploadProductImageAdd() {
    var img = jQuery('#preview-pane-productadd .preview-container img');
    jQuery('#avatar-crop-box-productadd button').addClass('disabled');
    console.log('UploadProductImageAdd()');
    console.log(img.attr('src'));
    console.log(img.css('width'));
    console.log(img.css('height'));
    console.log(img.css('marginLeft'));
    console.log(img.css('marginTop'));

    jQuery.ajax({
        type: "POST",
        url: "/Masterdata/UploadProductImageAdd",
        traditional: true,
        data: {
            w: img.css('width'),
            h: img.css('height'),
            l: img.css('marginLeft'),
            t: img.css('marginTop'),
            fileName: img.attr('src'),
            targetNameId: '#ProductImageNameAdd'
        }
    }).done(function (data) {
        if (data.success === true) {
            //ORIGINAL CODE
            jQuery('#avatar-result-productadd img').attr('src', data.avatarFileLocation);

            //UPDATED CODE
            jQuery(data.ImageHoldeNameId).val(data.ActualSavedFileName);

            jQuery('#avatar-result-productadd').removeClass('hidden');

            if (!keepCropBox) {
                jQuery('#avatar-crop-box-productadd').addClass('hidden');
            }

        } else {
            alert(data.errorMessage)
        }
    }).fail(function (e) {
        alert('Cannot upload avatar at this time');
    });
}

function UploadProductImageEdit() {
    var img = jQuery('#preview-pane-productedit .preview-container img');
    jQuery('#avatar-crop-box-productedit button').addClass('disabled');
    console.log('UploadProductImageEdit()');
    console.log(img.attr('src'));
    console.log(img.css('width'));
    console.log(img.css('height'));
    console.log(img.css('marginLeft'));
    console.log(img.css('marginTop'));

    jQuery.ajax({
        type: "POST",
        url: "/Masterdata/UploadProductImageAdd",
        traditional: true,
        data: {
            w: img.css('width'),
            h: img.css('height'),
            l: img.css('marginLeft'),
            t: img.css('marginTop'),
            fileName: img.attr('src'),
            targetNameId: '#ProductEditImage'
        }
    }).done(function (data) {
        if (data.success === true) {
            //ORIGINAL CODE
            jQuery('#avatar-result-productedit img').attr('src', data.avatarFileLocation);

            //UPDATED CODE
            jQuery(data.ImageHoldeNameId).val(data.ActualSavedFileName);

            jQuery('#avatar-result-productedit').removeClass('hidden');

            if (!keepCropBox) {
                jQuery('#avatar-crop-box-productedit').addClass('hidden');
            }
        } else {
            alert(data.errorMessage)
        }
    }).fail(function (e) {
        alert('Cannot upload avatar at this time');
    });
}

//Insert data

//Update data

// Delete Data