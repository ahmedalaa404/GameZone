$.validator.addMethod('FileSize', function (value, e, param) {  // Valid Of File Size 
    var IsValid = this.optional(e) || e.files[0].size <= param;
    return IsValid;
});