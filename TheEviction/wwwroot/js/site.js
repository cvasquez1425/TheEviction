// site.js Write your JavaScript code.
(function () {
    //$("#dialog-create-client").dialog({
    //    title: 'Create New Client',
    //    autoOpen: false,
    //    resizable: false,
    //    width: 720,
    //    height: 600,
    //    show: { effect: 'drop', direction: "up" },
    //    modal: true,
    //    draggable: true,
    //    open: function (event, ui) {
    //        $(".ui-dialog-titlebar-close").hide();
    //        $(this).load(url);
    //    }
    //});

    var $anchorMouseOver = $("#tblClient a.search");
    $anchorMouseOver.on("mouseover", function () {
        //$anchorMouseOver.style = 
        //alert("TEST");
        $(this).css('cursor', 'pointer');
    });

})();
