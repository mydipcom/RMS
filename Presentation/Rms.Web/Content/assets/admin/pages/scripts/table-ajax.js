var TableAjax = function () {

    var initPickers = function () {
        //init date pickers
        $('.date-picker').datepicker({
            rtl: Metronic.isRTL(),
            autoclose: true
        });
    }

    var handleRecords = function () {

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
                "language": {
                    "lengthMenu": "Display _MENU_ records per page",
                    "zeroRecords": "Nothing found - sorry",
                    "info": "Showing page _PAGE_ of _PAGES_",
                    "infoEmpty": "No records available",
                    "infoFiltered": "(filtered from _MAX_ total records)"
                },
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
                    {
                        //自定义列sName
                        "mDataProp": "Age",
                        "sClass": "center",
                        "bSearchable": false,
                        "bStorable": false,
                        "mRender": function(data, type, full) {
                            return '<span>1' + data + '</span>';
                        }
                    },
                      {
                          //自定义列sName
                          "mDataProp": "Id",
                          "sClass": "center",
                          "bSearchable": false,
                          "bStorable": false,
                          "mRender": function (data, type, full) {
                              return '<a data-customer-id=' + full.Id + ' class="customeredit">Edit</a>'; 
                          } 
                      }
                ]
            }
        });

        // handle group actionsubmit button click
        grid.getTableWrapper().on('click', '.table-group-action-submit', function (e) {
            e.preventDefault();
            var action = $(".table-group-action-input", grid.getTableWrapper());
            if (action.val() != "" && grid.getSelectedRowsCount() > 0) {
                grid.setAjaxParam("customActionType", "group_action");
                grid.setAjaxParam("customActionName", action.val());
                grid.setAjaxParam("id", grid.getSelectedRows());
                grid.getDataTable().ajax.reload();
                grid.clearAjaxParams();
            } else if (action.val() == "") {
                Metronic.alert({
                    type: 'danger',
                    icon: 'warning',
                    message: 'Please select an action',
                    container: grid.getTableWrapper(),
                    place: 'prepend'
                });
            } else if (grid.getSelectedRowsCount() === 0) {
                Metronic.alert({
                    type: 'danger',
                    icon: 'warning',
                    message: 'No record selected',
                    container: grid.getTableWrapper(),
                    place: 'prepend'
                });
            }
        });
    }

    var gridActionInit= function() {

        $(".customeredit").live("click", function() {
            $("#stack1").modal('show');
        });

    }

    return {

        //main function to initiate the module
        init: function () {

            initPickers();
            handleRecords();
            gridActionInit();
        }

    };

}();