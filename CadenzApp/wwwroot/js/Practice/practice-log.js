$(document).ready(function () {
    //GetPracticeHours();
    GetInstrumentOptions();
    //PopulatePracticeLog();
});

function GetStudentID() {
    return 1;
}

/*function GetPracticeHours() {
    var studentID = GetStudentID();
    var currDate = moment().format("YYYY-MM-DD");
    $.ajax({
        url: baseUrl + controller + "/GetPracticeHours",
        type: "GET",
        cache: false,
        data: { StudentID: studentID, Date: currDate },
        success: function (data) {
            console.log(data);
        }
    });//.then(PopulatePracticeLog());
}*/

function GetInstrumentOptions() {
    $.ajax({
        url: baseUrl + controller + "/GetInstrumentOptions",
        type: "GET",
        cache: false,
        success: function (data) {
            $("#inputInstrument").empty().append("<option></option>");
            instrumentList = data;
            $.each(data, function (index, object) {
                var option = "<option value='" + object.id + "'>" + object.name + "</option>";
                $("#inputInstrument").append(option);
            });
            $(".select2").select2();
        }
    }).then(PopulatePracticeLog());
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
    $.ajax({
        url: baseUrl + controller + "/GetPracticeLogList",
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
                "scrollY": 500,
                "scrollCollapse": true,
                "paging": false
            });
        }
    });
}

/*#region Event Handler*/
$(document).on('click', ".addBtn", function () {
    var confirmation = $.Deferred();
    confirmation.resolve(confirmNormal("Add practice session?", "This action cannot be undone.", "warning"));

    $.when(confirmation).then(function (confirmStatus) {
        if (confirmStatus) {
            SubmitTask();
        }
    });
});
/*#endregion*/

//#region Form Submission
$("#submit-tasks").click(function () {
    SubmitTask();
});

function SubmitTask() {
    /*if (!CheckDate) {
        swal({
            icon: "error",
            title: "Duplicate date",
            text: "Please choose another date to add."
        });
        return;
    }*/

    var data = FormCheck();
    if (!data) {
        swal({
            icon: "error",
            title: "Missing details",
            text: "Please enter all required fields."
        });
        return;
    }
    else {
        $.ajax({
            url: baseUrl + controller + "/InsertPracticeLog",
            type: 'json',
            contentType: 'application/json',
            data: JSON.stringify(data),
            cache: false,
            success: function (response) {
                $.when(FadeOutPreloaderModal()).then(function () {
                    swal("Success!", "", "success").then(function () {
                        reload();
                    });
                });
            },
            error: function (e) {
                $.when(FadeOutPreloaderModal()).then(function () {
                    swal({
                        icon: "error",
                        title: "Error!",
                        text: "An error has occured."
                    });
                });
            }
        });
    }
}

function FormCheck() {
    var studentID = GetStudentID();

    var detail = {
        "Date": $("#inputDate").val(),
        "PracticeHours": $("#inputLength").val(),
        "InstrumentId": $("#inputInstrument").val(),
        "Song": $("#inputSong").val(),
        "Description": $("#inputDescription").val(),
        "IsActive": true
    };

    if (detail["Date"] == null || detail["Date"] == "") {
        //$.when(FadeOutPreloaderModal()).then(function () {
        //    swal({
        //        icon: "error",
        //        title: "Invalid name",
        //        text: "Please enter a valid name."
        //    });
        //});
        return null;
    }
    else if (!detail["PracticeHours"] == null) {
        return null;
    }
    else {
        detail["StudentId"] = studentID;
        return detail;
    }
}

/*function CheckDate(date, studentID) {
    var isExist = false;
    $.ajax({
        url: baseUrl + controller + "/CheckDate",
        type: 'json',
        contentType: 'application/json',
        data: { "Date": date, "StudentID": studentID },
        cache: false,
        success: function (data) {
            isExist = data.Bool;
        }
    });
    return isExist;
}*/

//Toggle display of practice hours

$(".toggleBtn").click(function () {
    $("#chart-container, #table-container").toggleClass("display-none"); 
});

//#endregion