var CustomerProfile = function () {

    var successMsg = function(msg) {
        Metronic.alert({
            type: 'success',
            icon: 'check',
            message: msg,
            closeInSeconds: 5,
            container: $("#metronic-alert"),
            place: 'prepend'
        });
    };

    var failMsg = function (msgarray) {
        var msg = "";
        for (var i = 0; i < msgarray.length; i++) {
            msg += "<div>" + msgarray[i] + "</div>";
        }
        Metronic.alert({
            type: 'danger',
            icon: 'warning',
            message: msg,
            container: $("#metronic-alert"),
            place: 'prepend'
        });
    };

    var imageUpload = function() {
        var $imagerender = $("#upload-image-render");
        var uploader = new plupload.Uploader({
            runtimes: 'html5,flash,silverlight,html4',
            browse_button: 'pickfile', // you can pass in id...
            container: document.getElementById('container'), // ... or DOM Element itself
            url: '/Common/Upload',
            flash_swf_url: '/Content/assets/global/plugins/plupload/js/Moxie.swf',
            silverlight_xap_url: '/Content/assets/global/plugins/plupload/js/Moxie.xap',
            filters: {
                max_file_size: '10mb',
                mime_types: [
                    { title: "Image files", extensions: "jpg,gif,png" }
                ]
            },
            init: {
                PostInit: function() {
                },
                FilesAdded: function(up, files) {
                    uploader.start();
                },
                FileUploaded: function (up, file, info) {
                    successMsg("ok");
                    $imagerender.attr("src", info.response);
                },
                UploadProgress: function(up, file) {
                },
                Error: function(up, err) {
                }
            }
        });

        uploader.init();
    };

    var changePwdValite = function () {
        var $formel = $('#changepassword');
        $formel.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            rules: {
                OldPassword: {
                    required: true
                },
                NewPassword: {
                    required: true
                },
                ConfirmNewPassword: {
                    required: true,
                    equalTo: '#NewPassword'
                }
            },

            messages: {
                OldPassword: {
                    required: "CurrentPassword is required."
                },
                NewPassword: {
                    required: "NewPassword is required."
                },
                ConfirmNewPassword: {
                    required: "ConfirmNewPassword is required.",
                    equalTo: "ConfirmNewPassword is not equal oldPassword."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
                $('.alert-danger', $formel).show();
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            submitHandler: function (form) {
                form.submit();
            }
        });
    };

    var changePwd = function() {
        var $form = $("#changepassword");
        var $submit = $("#changepassword-submit");
        $submit.click(function () {

            if (!$form.validate().form()) {
                return;
            }
            var model = $form.serialize();
            $.post("/Customer/ChangePassword", model, function(databack) {
                if (databack.Result) {
                    successMsg('The Password has been update successfully.');
                    $form[0].reset();
                } else {
                    failMsg(databack.Msgs);
                }
            });

        });
    };

    var userinfoEditValite = function() {
        var $formel = $('#userinfo');
        $formel.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            rules: {
                FirstName: {
                    required: true
                },
                LastName: {
                    required: true
                },
                MobileNumber: {
                    required: true
                }
            },

            messages: {
                FirstName: {
                    required: "FirstName is required."
                },
                LastName: {
                    required: "LastName is required."
                },
                MobileNumber: {
                    required: "MobileNumber is required."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
                $('.alert-danger', $formel).show();
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            submitHandler: function (form) {
                form.submit();
            }
        });
    };

    var userinfoEdit = function() {
        var $form = $("#userinfo");
        var $submit = $("#userinfo-submit");
        $submit.click(function() {

            if (!$form.validate().form()) {
                return;
            }
            var model = $form.serialize();
            $.post("/Customer/UserInfoEdit", model, function (databack) {
                if (databack.Result) {
                    successMsg('The User Info has been update successfully.');
                    $form[0].reset();
                } else {
                    failMsg(databack.Msgs);
                }
            });
        });
    };

    return {

        //main function to initiate the module
        init: function() {
            imageUpload();
            changePwdValite();
            changePwd();
            userinfoEditValite();
            userinfoEdit();

        }

    };

}();