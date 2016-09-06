$(function () {
    
    jQuery("#country").jqGrid({
        url: "/TestJqgrid/GetCountryLists",
        datatype: 'json',
        mtype: 'Get',
        styleUI: 'Bootstrap',
        colNames: ['CountryId', 'Country Name', 'Capital City'],
        colModel: [
            { key: false, hidden: true, name: 'CountryId', index: 'CountryId', editable: true },
            { key: false, name: 'CountryName', index: 'CountryName', editable: true },
            { key: false, name: 'CapitalCity', index: 'CapitalCity', editable: true },
        ],
        pager: jQuery('#pager'),
        rowNum: 5,
        rowList: [5, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        caption: 'Country',
        emptyrecords: 'No records to display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
        //onSelectRow: function (ids) {
        //    //$('#countrynamedisp').val(ids);
        //    if (ids == null) {
        //        ids = 0;
        //        if (jQuery("#city").jqGrid('getGridParam', 'records') > 0) {
        //            jQuery("#city").jqGrid('setGridParam', { url: "/City/GetCityLists?countryid=" + ids, page: 1 });
        //            $('#countrynamedisp').val(ids);
        //            jQuery("#city").jqGrid('setCaption', "City for country")
        //            .trigger('reloadGrid');
        //        }
        //    } else {
        //        jQuery("#city").jqGrid('setGridParam', { url: "/City/GetCityLists?countryid=" + ids, page: 1 });
        //        $('#countrynamedisp').val(ids);
        //        jQuery("#city").jqGrid('setCaption', "City for country " + ids)
        //        .trigger('reloadGrid');
        //    }
        //}
    }).navGrid('#pager', { edit: false, add: false, del: false, search: true, refresh: true },
        {
            // edit options
            zIndex: 100,
            url: '/TestJqgrid/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            beforeSubmit: function (postdata, formid) {
                if ($('#TaskName').val() == "") {
                    $('#TaskName').addClass("ui-state-highlight");
                    return [false, 'ERROR MESSAGE']; //error
                }
                return [true, ''];
            },
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            },
            width: 600,
            height: 300
        },
        {
            // add options
            zIndex: 100,
            url: "/TestJqgrid/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            },
            width: 600,
            height: 300
        },
        {
            // delete options
            zIndex: 100,
            url: "/Country/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete this country?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });


});