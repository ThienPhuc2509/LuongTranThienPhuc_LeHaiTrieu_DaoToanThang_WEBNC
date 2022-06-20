const { read } = require("fs");

function ShowImgPreview(imgUpload, previewImg) {
    if (imgUpload.files && imgUpload.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg).attr('src', e.target.result);
        }
        reader.readAsDataURL(imgUpload.files[0]);
    }
}