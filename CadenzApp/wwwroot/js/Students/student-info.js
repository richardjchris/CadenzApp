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

//#region Practice Hours
$(document).ready(function () {
    GetnstrumentInfo();
});

function GetnstrumentInfo() {
    $.ajax({
        url: baseUrl + controller + "/GetInstrumentInfo",
        type: "GET",
        cache: false
    }).done(function (data) {
        instrumentList = data;
        PopulatePracticeLog();
    });
}

function GetInstrumentName(instrumentID) {
    var name = "";
    $.each(instrumentList, function (index, object) {
        if (object.id == instrumentID) {
            name = object.name;
            return;
        }
    });
    return name;
}

function PopulatePracticeLog() {
    var studentID = GetStudentID();
    $("#table").DataTable().destroy();

    $.ajax({
        url: baseUrl + controller + "/GetPracticeHours",
        type: "GET",
        data: "StudentID=" + studentID,
        cache: false,
        success: function (data) {
            var tbody = $("#table tbody").empty();
            $.each(data, function (index, object) {
                var date = moment(object.date).format("YYYY-MM-DD");
                var td = "<tr>";
                td += "<td>" + date + "</td>";
                td += "<td>" + object.practiceHours + "</td>";
                td += "<td>" + GetInstrumentName(object.instrumentId) + "</td>";
                td += "<td>" + object.song + "</td>";
                td += "<td>" + object.description + "</td>";
                td += "</tr>"
                tbody.append(td);
            });
            $("#table-wrapper").removeClass("display-none");
            $("#table").dataTable({
                "dom": "ti",
                "columnDefs": [
                    {
                        "targets": "_all",
                        "className": "dt-center"
                    }
                ],
                "data": null,
                "responsive": true,
                "scrollY": 500,
                "scrollCollapse": true,
                "paging": false
            });
        }
    });
}

//Toggle display of practice hours

$(".toggleBtn").click(function () {
    $("#chart-container, #table-container").toggleClass("display-none");
});

//#endregion