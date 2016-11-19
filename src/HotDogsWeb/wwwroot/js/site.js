(function () {

    var $sidebarAndWrapper = $("#sidebar, #wrapper");
    var icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function(){
        $sidebarAndWrapper.toggleClass("hide-sidebar");

        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(icon).removeClass("fa-chevron-left");
            $(icon).addClass("fa-chevron-right");
        }
        else {
            $(icon).removeClass("fa-chevron-right");
            $(icon).addClass("fa-chevron-left");
        }
    });
    
})();