var TenantAjax = function() {

    var grid;
    var handleRecords = function() {
        grid = new Datatable();
        grid.init({
            src: $("#datatable_ajax"),
            onSuccess: function(grid) {
                // execute some code after table records loaded
            },
            onError: function(grid) {
                // execute some code on network or other general error  
            },
            loadingMessage: 'Loading...',
            dataTable: {
                // here you can define a typical datatable settings from http://datatables.net/usage/options 
                "lengthMenu": [
                    [10, 20, 50, 100, 150, -1],
                    [10, 20, 50, 100, 150, "All"] // change per page values here
                ],
                "pagingType": "full_numbers",
                "bFilter": false,
                "searching": false,
                "ordering": false,
                "sDom": '<"top">rt<"bottom"i<"pagelist"p>><"clear">', //显示布局
                "pageLength": 15, // default record count per page
                "language": {
                    "lengthMenu": "Display _MENU_ records per page",
                    "zeroRecords": "Nothing found - sorry",
                    "info": "Showing page _PAGE_ of _PAGES_",
                    "infoEmpty": "No records available",
                    "infoFiltered": "(filtered from _MAX_ total records)"
                },
                "ajax": {
                    "url": "/Tenants/List", // ajax source
                },

                "aoColumns": [
                    { "mDataProp": "Id" },
                    { "mDataProp": "TenantName" },
                    { "mDataProp": "MappedDomain" },
                    { "mDataProp": "Version" },
                    { "mDataProp": "Timezone" },
                    { "mDataProp": "IsPublic" },
                    { "mDataProp": "CreateDate" },
                    {
                        //自定义列sName
                        "mDataProp": "Id",
                        "sClass": "center",
                        "bSearchable": false,
                        "bStorable": false,
                        "mRender": function(data, type, full) {
                            return '<a class="rowedit"  data-id=' + full.Id + '>Edit</a>' +
                                '<a  class="rowdelete" data-id=' + full.Id + '>Delete</a>';
                        }
                    }
                ]
            }
        });
    };

    var handleSubmit = function() {
        var $formel = $('#createorupdateform');
        $formel.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            rules: {
                TenantName: {
                    required: true
                },
                MappedDomain: {
                    required: true
                }
            },

            messages: {
                TenantName: {
                    required: "TenantName is required."
                },
                MappedDomain: {
                    required: "MappedDomain is required."
                }
            },

            invalidHandler: function(event, validator) { //display error alert on form submit   
                $('.alert-danger', $formel).show();
            },

            highlight: function(element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function(label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            submitHandler: function(form) {
                form.submit();
            }
        });
    };

    var clearFormValidate = function() {
        var $modalerror = $("#createorupdate-errormsg");
        var $formel = $('#createorupdateform');

        $("input[name=Id]", $formel).val(0);

        $modalerror.empty();
        $modalerror.hide();

        //clear error style
        $(".help-block", $formel).each(function() {
            $(this).remove();
        });
        $(".form-group", $formel).each(function() {
            $(this).removeClass('has-error');
        });
    };

    var successMsg = function(msg) {
        Metronic.alert({
            type: 'success',
            icon: 'check',
            message: msg,
            closeInSeconds: 5,
            container: grid.getTableWrapper(),
            place: 'prepend'
        });
    };


    var modalfailMsg = function(msg) {
        var $modalerror = $("#createorupdate-errormsg");
        $modalerror.html(msg);
        $modalerror.show();
    };


    var gridActionInit = function() {
        var $formel = $('#createorupdateform');
        var $modalel = $("#createorupdate");
        var $submitel = $("#createorupdatesubmit");
        var $createel = $("#rowcreate");
        var $deletemodalel = $("#item-delete"); 
        var $deletebtnel = $("#item-delete-ok");

        $(".rowedit").live("click", function() {
            clearFormValidate();
            var id = $(this).attr("data-id");
            $.post("/Tenants/GetEntityById", { id: id }, function(model) {
                $("input[name=Id]", $formel).val(model.Id);
                $('input[name=TenantName]', $formel).val(model.TenantName);
                $("input[name=MappedDomain]", $formel).val(model.MappedDomain);
                $("input[name=Version]", $formel).val(model.Version);
                $("input[name=Timezone]", $formel).val(model.Timezone);
                $("input[name=CreateDate]", $formel).val(model.CreateDate);

                var $checkbox = $("input[name=IsPublic]", $formel);
                $checkbox.val(model.IsPublic);
                if (model.IsPublic)
                    $checkbox.parents('span').addClass("checked");
                else
                    $checkbox.parents('span').removeClass("checked");

                $modalel.modal('show');
            });
        });

        $(".rowdelete").live("click", function() {
            var id = $(this).attr("data-id");
            $deletebtnel.attr("data-id", id);
            $deletemodalel.modal('show');
        });

        $deletebtnel.click(function() {
            var id = $(this).attr("data-id");
            $.post("/Tenants/Delete", { id: id }, function(databack) {
                if (databack.Result) {
                    $deletebtnel.attr("data-id", 0);
                    successMsg('The tenants has been delete successfully.');
                    grid.getDataTable().ajax.reload();
                }
            });
        });

        $createel.click(function() {
            $formel[0].reset();
            clearFormValidate();
            $modalel.modal('show');
        });

        $submitel.click(function() {
            var $checkbox = $("input[name=IsPublic]", $formel);
            $checkbox.val($checkbox.prop('checked'));

            if (!$formel.validate().form()) {
                return;
            }

            var model = $formel.serialize();
            $.post("/Tenants/CreateOrUpdate", model, function(databack) {
                if (databack.Result) {
                    $modalel.modal('hide');
                    successMsg('The tenants has been update successfully.');
                    grid.getDataTable().ajax.reload();
                } else {
                    var msg = "";
                    for (var i = 0; i < databack.Msgs.length; i++) {
                        msg += "<div>" + databack.Msgs[i] + "</div>";
                    }
                    modalfailMsg(msg);
                }
            });
        });
    };

    return {

        //main function to initiate the module
        init: function() {
            handleRecords();
            gridActionInit();
            handleSubmit();
        }

    };

}();