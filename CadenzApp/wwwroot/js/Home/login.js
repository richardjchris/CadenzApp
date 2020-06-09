$(document).ready(function () {
    if ($(window).width() < 650) {
        ToggleLoginSplash();
    }
});

$(window).resize(function () {
    ToggleLoginSplash();
});

function ToggleLoginSplash() {
    if ($(window).width() < 651) {
        $("#login-page .card-panel").addClass("vertical");
        $("#login-page .card-panel").removeClass("horizontal");
        $("#login-page .card-panel").css("padding-left", 0);
    }
    else {
        $("#login-page .card-panel").removeClass("vertical");
        $("#login-page .card-panel").addClass("horizontal");
        $("#login-page .card-panel").css("padding-left" , "initial");
    }
}