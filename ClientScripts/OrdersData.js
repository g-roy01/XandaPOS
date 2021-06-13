jQuery(document).ready(function () {
    //jQuery("#PurchaseOrderDateTime").load(function () {
    //alert('a');
    ////});
    //jQuery('#PurchaseOrderDateTime').setNow(true);
    //alert(jQuery("#PurchaseOrderDateTime").val());


    jQuery(document).ready(function () {
        jQuery(".add-row").click(function () {
            markup = "<tr><td>This is row "
                + lineNo + "</td></tr>";
            tableBody = $("table tbody");
            tableBody.append(markup);
            lineNo++;
        });
    }); 

});