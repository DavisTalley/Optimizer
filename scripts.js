$(document).ready(function () {
    $("#output").hide();

    $('.slider').slider({
        reversed: true,
        tooltip: 'always'
    });

    var inputs = ['br1', 'br2', 'hw1', 'hw2', 'fw', 'sw', 'cs', 'mep', 'ub1', 'ub2'];

    inputs.forEach(function (input) {
        $("#" + input + "-slider").on("change", function (slideEvt) {
            $("#" + input + "-count").text(slideEvt.value.newValue);
        })
        $("#" + input + "-lock").on("click", function () {
            if ($("#" + input + "-slider").slider('isEnabled')) {
                $("#" + input + "-lock").html('<i class="fa fa-lock"></i>');
                $("#" + input + "-slider").slider('disable');
            }
            else {
                $("#" + input + "-lock").html('<i class="fa fa-unlock-alt"></i>');
                $("#" + input + "-slider").slider('enable');
            }
        })
    })


    $("#output-header").on("click", function () {
        $("#input").hide();
        $("#output").show();
    });

    $("#input-header").on("click", function () {
        $("#output").hide();
        $("#input").show();
    });
});

