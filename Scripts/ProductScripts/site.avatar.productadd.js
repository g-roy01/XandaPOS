// ================================================================
//  Description: Avatar Upload supporting script
//  License:     MIT - check License.md file for details
//  Author:      MiroJ (https://github.com/MiroJ)
// ================================================================
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
    //jQuery(document).on('Click', '#imageUploadHolder', function () {
    //    console.log('Image Reuploaded');
    //    initAvatarUpload();
    //});
    //console.log(typeof jQuery('#avatar-upload-form'));

    //if (typeof jQuery('#avatar-upload-form') !== undefined) {

        initAvatarUpload();
        jQuery('#avatar-max-size').html(maxSizeAllowed);
        jQuery('#avatar-upload-form input:file').on("change", function (e) {
            var files = e.currentTarget.files;
            for (var x in files) {
                if (files[x].name != "item" && typeof files[x].name != "undefined") {
                    if (files[x].size <= maxSizeInBytes) {

                        // Submit the selected file
                        //jQuery('#avatar-upload-form .upload-file-notice').removeClass('bg-danger');

                        //jQuery('#avatar-upload-form .upload-file-notice').text('Max Size: 4 MB');
                        jQuery('#avatar-upload-form .upload-file-notice').text('Uploading...');

                        jQuery('#avatar-upload-form .upload-file-notice').css('background', 'white');
                        jQuery('#avatar-upload-form .upload-file-notice').css('color', 'black');

                        jQuery('#avatar-upload-form').submit();
                    } else {
                        // File too large
                        jQuery('#avatar-upload-form .upload-file-notice').text('Image Size > 4 MB');
                        //jQuery('#avatar-upload-form .upload-file-notice').addClass('bg-danger');
                        jQuery('#avatar-upload-form .upload-file-notice').css('background','red');
                        jQuery('#avatar-upload-form .upload-file-notice').css('color', 'white');

                        jQuery('.upload-percent-bar').width('0%');
                        jQuery('.upload-percent-value').html('0%');

                        jQuery('#avatar-crop-box').css('display', 'none');


                    }
                }
            }
        });
    //}
    //else {
    //    console.log('Upload Start');
    //    initAvatarUpload();  
    //}
});

function initAvatarUpload() {
    jQuery('#avatar-upload-form').ajaxForm({
        beforeSend: function () {
            updateProgress(0);
            jQuery('#avatar-upload-form').addClass('hidden');
        },
        uploadProgress: function (event, position, total, percentComplete) {
            updateProgress(percentComplete);
        },
        success: function (data) {
            updateProgress(100);
            if (data.success === false) {
                jQuery('#status').html(data.errorMessage);
            } else {
                jQuery('#preview-pane .preview-container img').attr('src', data.fileName);
                var img = jQuery('#crop-avatar-target');
                img.attr('src', data.fileName);

                jQuery('#avatar-upload-form .upload-file-notice').text('Image Uploaded');

                jQuery('#avatar-crop-box').css('display', 'block');
                jQuery('#Preview_pane').css('display', 'block'); //Added - The Preview Panel Will Be Shown
                jQuery('.jcrop-holder img').css('display', 'block'); // Added  - This Portion Will Show the Image Uploaded, Initially It Will Be Hidden On Panel Load
                jQuery('.jcrop-holder img').attr('src', data.fileName); //Added - To Update Image Show When New Image Is Uploaded | If Removed Then New Image Will Not Be Updated If Image Is Re-Uploaded
                jQuery('#Preview_panel_header').css('display', 'block'); //Added - To Show The Preview Panel Header
                

                if (!keepUploadBox) {
                    jQuery('#avatar-upload-box').addClass('hidden');
                }
                jQuery('#avatar-crop-box').removeClass('hidden');
                initAvatarCrop(img);
            }
        },
        complete: function (xhr) {
        }
    });
}

function updateProgress(percentComplete) {
    jQuery('.upload-percent-bar').width(percentComplete + '%');
    jQuery('.upload-percent-value').html(percentComplete + '%');
    if (percentComplete === 0) {
        jQuery('#upload-status').empty();
        jQuery('.upload-progress').removeClass('hidden');
    }
}

function initAvatarCrop(img) {
    img.Jcrop({
        onChange: updatePreviewPane,
        onSelect: updatePreviewPane,
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

        var pcnt = jQuery('#preview-pane .preview-container');
        xsize = pcnt.width();
        ysize = pcnt.height();
        jQuery('#preview-pane').appendTo(jcrop_api.ui.holder);
        jcrop_api.focus();
    });
}

function updatePreviewPane(c) {
    if (parseInt(c.w) > 0) {
        var rx = xsize / c.w;
        var ry = ysize / c.h;

        jQuery('#preview-pane .preview-container img').css({
            width: Math.round(rx * boundx) + 'px',
            height: Math.round(ry * boundy) + 'px',
            marginLeft: '-' + Math.round(rx * c.x) + 'px',
            marginTop: '-' + Math.round(ry * c.y) + 'px'
        });
    }
}

//function saveAvatar() {
//    var img = jQuery('#preview-pane .preview-container img');
//    jQuery('#avatar-crop-box button').addClass('disabled');

//    jQuery.ajax({
//        type: "POST",
//        url: "/Masterdata/Save",
//        traditional: true,
//        data: {
//            w: img.css('width'),
//            h: img.css('height'),
//            l: img.css('marginLeft'),
//            t: img.css('marginTop'),
//            fileName: img.attr('src')
//        }
//    }).done(function (data) {
//        if (data.success === true) {
//            //ORIGINAL CODE
//            jQuery('#avatar-result img').attr('src', data.avatarFileLocation);

//            //UPDATED CODE
//            jQuery(data.ImageHoldeNameId).val(data.avatarFileLocation);

//            jQuery('#avatar-result').removeClass('hidden');

//            if (!keepCropBox) {
//                jQuery('#avatar-crop-box').addClass('hidden');
//            }
//        } else {
//            alert(data.errorMessage)
//        }
//    }).fail(function (e) {
//        alert('Cannot upload avatar at this time');
//    });
//}