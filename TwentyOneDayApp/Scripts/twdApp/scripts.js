

jQuery(function () {
    $(".kontainer a.add").on("click", function (e) {
        e.preventDefault();
    });
    $(".kontainer").on("click", function (e) {
        var $input = $(this).find('input');
        $input.prop("checked", !$input.prop("checked"));
        e.stopPropagation();
    });
    $(".kontainer input").on("click", function (e) {
        e.stopPropagation();
    });
});


