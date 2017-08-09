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

    var people = [
        { name: 'Rick', skills: 'Welding' }, { name: 'Morty', skills: 'Plumbing' }, { name: 'Jerry', skills: 'Electrical' }
    ]

    people.forEach(function (p) {
        var display = "";

        display += '<div class="row">';
        display += '<form style="margin-bottom:0;">';
        display += '<div class="col-md-1 text-center"><input type="radio" name="availability" checked></div>';
        display += '<div class="col-md-1 text-center"><input type="radio" name="availability"></div>';
        display += '<div class="col-md-1 text-center"><input type="radio" name="availability"></div>';
        display += '</form>';
        display += '<div class="col-md-4">' + p.name + '</div>';
        display += '<div class="col-md-5">' + p.skills + '</div>';
        display += '</div>';

        $(display).appendTo("#people");
    })

    var projects = [
        { name: 'Test1', BR: 1, HW: 0, FW: 0, SW: 1, CS: 3, MEP: 0, UB: 1 },
        { name: 'Test2', BR: 0, HW: 3, FW: 1, SW: 0, CS: 2, MEP: 1, UB: 0 },
        { name: 'Test3', BR: 0, HW: 0, FW: 1, SW: 0, CS: 1, MEP: 0, UB: 0 }
    ]

    projects.forEach(function (p) {
        var display = "";

        display += '<div class="row">';
        display += '<div class="col-md-2">' + p.name + '</div>';
        display += '<div class="col-md-2"><input type="date" style="max-width:90%;"></div>';
        display += '<div class="col-md-1">' + p.BR + '</div>';
        display += '<div class="col-md-1">' + p.HW + '</div>';
        display += '<div class="col-md-1">' + p.FW + '</div>';
        display += '<div class="col-md-1">' + p.SW + '</div>';
        display += '<div class="col-md-1">' + p.CS + '</div>';
        display += '<div class="col-md-1">' + p.MEP + '</div>';
        display += '<div class="col-md-1">' + p.UB + '</div>';
        display += '</div>';

        $(display).appendTo("#projects");
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

