$(document).ready(function () {
    var studentID = 1;
    GetStudent(studentID);
});

function GetStudentID() {
    return 1;
}

function GetStudent(ID) {
    $.ajax({
        url: baseUrl + controller + "/GetStudent",
        type: "GET",
        data: "ID=" + ID,
        success: function (result) {
            console.log(result);
            //$(".name-field").text(result.);
        }
    });
}