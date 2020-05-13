$(document).ready(function () {
    var studentID = 1;
    $.ajax({
        url: baseUrl + controller + "/GetStudent",
        type: "GET",
        data: "ID=" + studentID,
        success: function (result) {
            console.log(result);
            //$(".name-field").text(result.);
        }
    });
});