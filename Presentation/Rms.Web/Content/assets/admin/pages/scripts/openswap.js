var OpenSwap = function() {


   var initOpenSwap= function() {

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        var h = {};


   };

   var handleDatePickers = function () {
       if (jQuery().datepicker) {
           $('.date-picker').datepicker({
               rtl: Metronic.isRTL(),
               orientation: "left",
               autoclose: true
           });
           //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
       }
   }

    var initShiftGrid = function() {
        var grid = new Datatable();
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
                "bFilter": true,
                "searching": false,
                "sDom": '<"top">rt<"bottom"ilp><"clear">', //显示布局
                "pageLength": 10, // default record count per page
                "ajax": {
                    "url": "/Customer/CustomerList", // ajax source
                },
                "order": [
                    [1, "asc"]
                ], // set first column as a default sort by asc
                "aoColumns": [
                    {
                        //自定义列sName
                        "mDataProp": "Id",
                        "sClass": "center",
                        "bSearchable": false,
                        "bStorable": false,
                        "mRender": function(data, type, full) {
                            return '<input type="checkbox" class="checkboxes" value="' + data + '"/>';
                        }
                    },
                    { "sClass": "center", "mDataProp": "Name", "bSearchable": false, "bStorable": false },
                    { "sClass": "center", "mDataProp": "Age", "bSearchable": false, "bStorable": false },
                    {
                        //自定义列sName
                        "mDataProp": "Id",
                        "sClass": "center",
                        "bSearchable": false,
                        "bStorable": false,
                        "mRender": function(data, type, full) {
                            return '<a data-customer-id=' + full.Id + ' class="swapedit">Swap</a>';
                        }
                    }
                ]
            }
        });


        var swagrid = swapeditGridInit();

        // swap shift  modal
        $(".swapedit").live("click", function() {

           // swagrid.setAjaxParam("customActionType", "group_action");
           // swagrid.setAjaxParam("customActionName", action.val());
           // swagrid.setAjaxParam("id", grid.getSelectedRows());
            swagrid.getDataTable().ajax.reload();
            swagrid.clearAjaxParams();

            $("#swapshiftmodal").modal('show');
        });


    };


    var swapeditGridInit = function() { 
        var swapeditgrid = new Datatable();
        swapeditgrid.init({
            src: $("#swapshiftmodal-datatable"),
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
                "bFilter": true,
                "searching": false,
                "sDom": '<"top">rt<"bottom"p><"clear">', //显示布局
                "pageLength": 10, // default record count per page
                "ajax": {
                    "url": "/Customer/CustomerList", // ajax source
                },
                "order": [
                    [1, "asc"]
                ], // set first column as a default sort by asc
                "aoColumns": [
                    { "sClass": "center", "mDataProp": "Id", "bSearchable": false, "bStorable": false },
                    { "sClass": "center", "mDataProp": "Name", "bSearchable": false, "bStorable": false },
                    { "sClass": "center", "mDataProp": "Age", "bSearchable": false, "bStorable": false },
                    {
                        //自定义列sName
                        "mDataProp": "Id",
                        "sClass": "center",
                        "bSearchable": false,
                        "bStorable": false,
                        "mRender": function(data, type, full) {
                            return '<a data-customer-id=' + full.Id + ' class="swapedit">Swap</a>';
                        }
                    }
                ]
            }
        });
        return swapeditgrid;
    };


    return {
        //main function to initiate the module
        init: function() {
            initOpenSwap();
            handleDatePickers();
            initShiftGrid();
        },


    };

}();