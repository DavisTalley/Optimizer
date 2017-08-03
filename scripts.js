$(document).ready(function () {
    $("#output").hide();
    
    $('#ex1').slider({
        formatter: function (value) {
            return 'Current value: ' + value;
        }
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

