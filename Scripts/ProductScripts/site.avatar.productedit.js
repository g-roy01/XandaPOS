var jcrop_api,
    boundx,
    boundy,
    xsize,
    ysize;

// ToDo - change the size limit of the file. You may need to change web.config if larger files are necessary.
var maxSizeAllowed = 4;     // Upload limit in MB
var maxSizeInBytes = maxSizeAllowed * 1024 * 1024;
var keepUploadBox = false;  // ToDo - Remove if you want to keep the upload box
var keepCropBox = false;    // ToDo - Remove if you want to keep the crop box

jQuery(function () {

    initAvatarUploadProductEdit();
    jQuery('#avatar-max-size-productedit').html(maxSizeAllowed);
    jQuery('#avatar-upload-productedit-form input:file').on("change", function (e) {
        var files = e.currentTarget.files;
        for (var x in files) {
            if (files[x].name != "item" && typeof files[x].name != "undefined") {
                if (files[x].size <= maxSizeInBytes) {

                    jQuery('#avatar-upload-productedit-form .upload-file-notice').text('Uploading...');

                    jQuery('#avatar-upload-productedit-form .upload-file-notice').css('background', 'white');
                    jQuery('#avatar-upload-productedit-form .upload-file-notice').css('color', 'black');

                    jQuery('#avatar-upload-productedit-form').submit();

                } else {

                    // File too large
                    jQuery('#avatar-upload-productedit-form .upload-file-notice').text('Image Size > 4 MB');

                    jQuery('#avatar-upload-productedit-form .upload-file-notice').css('background', 'red');
                    jQuery('#avatar-upload-productedit-form .upload-file-notice').css('color', 'white');

                    jQuery('.upload-percent-bar').width('0%');
                    jQuery('.upload-percent-value').html('0%');

                    jQuery('#avatar-crop-box-productedit').css('display', 'none');

                }
            }
        }
    });

});

function initAvatarUploadProductEdit() {
    jQuery('#avatar-upload-productedit-form').ajaxForm({
        beforeSend: function () {
            updateProgressProductEdit(0);
            jQuery('#avatar-upload-productedit-form').addClass('hidden');
        },
        uploadProgress: function (event, position, total, percentComplete) {
            updateProgressProductEdit(percentComplete);
        },
        success: function (data) {
            updateProgressProductEdit(100);
            if (data.success === false) {
                jQuery('#status').html(data.errorMessage);
            } else {
                jQuery('#preview-pane-productedit .preview-container img').attr('src', data.fileName);
                var img = jQuery('#crop-avatar-target-productedit');
                img.attr('src', data.fileName);

                jQuery('#avatar-upload-productedit-form .upload-file-notice').text('Image Uploaded');

                jQuery('#avatar-crop-box-productedit').css('display', 'block');
                //jQuery('#Preview_pane').css('display', 'block'); //Added - The Preview Panel Will Be Shown
                jQuery('.jcrop-holder img').css('display', 'block'); // Added  - This Portion Will Show the Image Uploaded, Initially It Will Be Hidden On Panel Load
                jQuery('.jcrop-holder img').attr('src', data.fileName); //Added - To Update Image Show When New Image Is Uploaded | If Removed Then New Image Will Not Be Updated If Image Is Re-Uploaded
                jQuery('#Preview_panel_header_productedit').css('display', 'block'); //Added - To Show The Preview Panel Header


                if (!keepUploadBox) {
                    jQuery('#avatar-upload-box').addClass('hidden');
                }
                jQuery('#avatar-crop-box-productedit').removeClass('hidden');
                initAvatarCropProductEdit(img);
            }
        },
        complete: function (xhr) {
        }
    });
}

function updateProgressProductEdit(percentComplete) {
    jQuery('.upload-percent-bar').width(percentComplete + '%');
    jQuery('.upload-percent-value').html(percentComplete + '%');
    if (percentComplete === 0) {
        jQuery('#upload-status').empty();
        jQuery('.upload-progress').removeClass('hidden');
    }
}

function initAvatarCropProductEdit(img) {
    img.Jcrop({
        onChange: updatePreviewPaneProductEdit,
        onSelect: updatePreviewPaneProductEdit,
        aspectRatio: xsize / ysize
    }, function () {
        var bounds = this.getBounds();
        boundx = bounds[0];
        boundy = bounds[1];

        jcrop_api = this;
        jcrop_api.setOptions({ allowSelect: true });
        jcrop_api.setOptions({ allowMove: true });
        jcrop_api.setOptions({ allowResize: true });
        jcrop_api.setOptions({ aspectRatio: 1 });

        // Maximise initial selection around the centre of the image,
        // but leave enough space so that the boundaries are easily identified.
        var padding = 10;
        var shortEdge = (boundx < boundy ? boundx : boundy) - padding;
        var longEdge = boundx < boundy ? boundy : boundx;
        var xCoord = longEdge / 2 - shortEdge / 2;
        jcrop_api.animateTo([xCoord, padding, shortEdge, shortEdge]);

        var pcnt = jQuery('#preview-pane-productedit .preview-container');
        xsize = pcnt.width();
        ysize = pcnt.height();
        jQuery('#preview-pane-productedit').appendTo(jcrop_api.ui.holder);
        jcrop_api.focus();
    });
}

function updatePreviewPaneProductEdit(c) {
    if (parseInt(c.w) > 0) {
        var rx = xsize / c.w;
        var ry = ysize / c.h;

        jQuery('#preview-pane-productedit .preview-container img').css({
            width: Math.round(rx * boundx) + 'px',
            height: Math.round(ry * boundy) + 'px',
            marginLeft: '-' + Math.round(rx * c.x) + 'px',
            marginTop: '-' + Math.round(ry * c.y) + 'px'
        });
    }
}

