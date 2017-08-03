$(document).ready(function () {
    $("#output").hide();

    $('.slider').slider({
        reversed : true
    });

    $("#output-header").on("click", function () {
        $("#input").hide();
        $("#output").show();
    });

    $("#input-header").on("click", function () {
        $("#output").hide();
        $("#input").show();
    });
});

