
$(document).ready(function () { //valid of File Extenstion
    $('#Cover').on('change', function () {
        $(".CoverPreview").attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none')


    })
})