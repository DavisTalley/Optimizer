$(document).ready(function () {
    $("#output").hide();

    $('.slider').slider({
        reversed: true,
        tooltip: 'always'
    });

    var inputs = ['br1', 'br2', 'hw1', 'hw2', 'fw', 'sw', 'cs', 'mep', 'ub1', 'ub2'];

    inputs.forEach(function (input) {
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
        display += '<div class="col-md-1 text-center">' + p.BR + '</div>';
        display += '<div class="col-md-1 text-center">' + p.HW + '</div>';
        display += '<div class="col-md-1 text-center">' + p.FW + '</div>';
        display += '<div class="col-md-1 text-center">' + p.SW + '</div>';
        display += '<div class="col-md-1 text-center">' + p.CS + '</div>';
        display += '<div class="col-md-1 text-center">' + p.MEP + '</div>';
        display += '<div class="col-md-1 text-center">' + p.UB + '</div>';
        display += '</div>';

        $(display).appendTo("#projects");
    });

    $('#output-table td').each(function () {
        var cellValue = $(this).html();

        if (cellValue == 0) {
            $(this).css("background-color", "#FFB8B8");
            $(this).css("color", "#1A1A1A");
        }
        else if (cellValue <= .2) {
            $(this).css("background-color", "#FA9494");
            $(this).css("color", "#1A1A1A");
        }
        else if (cellValue <= .5) {
            $(this).css("background-color", "#D26161");
            $(this).css("color", "#1A1A1A");
        }
        else if (cellValue <= 1) {
            $(this).css("background-color", "#AA3939");
        }
        else if (cellValue <= 2) {
            $(this).css("background-color", "#821A1A");
        }
        else if (cellValue <= 3) {
            $(this).css("background-color", "#5A0707");
        }
        else {
            $(this).css("background-color", "#3E0000");
        }
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

