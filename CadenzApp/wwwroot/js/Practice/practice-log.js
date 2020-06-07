$(document).ready(function () {
    GetInstrumentOptions();
});

function GetStudentID() {
    return 1;
}

function GetInstrumentOptions() {
    $.ajax({
        url: baseUrl + controller + "/GetInstrumentOptions",
        type: "GET",
        cache: false,
        success: function (data) {
            $("#inputInstrument").empty().append("<option></option>");
            console.log(data);
            $.each(data, function (index, object) {
                var option = "<option value='" + object.id + "'>" + object.name + "</option>";
                $("#inputInstrument").append(option);
            });
            $(".select2").select2();
        }
    });
}

/*function PopulatePracticeLog() {
    var studentID = GetStudentID();
    $.ajax({
        url: baseUrl + controller + "/GetTaskList",
        type: "GET",
        data: "StudentID=" + studentID,
        cache: false,
        success: function (result) {
            $("#task-list").empty();
            if (!result.length) {
                $("#task-list").addClass('display-none');
                $(".tasks.placeholder-text").removeClass('display-none');
            }
            else {
                $("#task-list").removeClass('display-none');
                $(".tasks.placeholder-text").addClass('display-none');
                $.each(result, function (index, object) {
                    var parsedDate = (!object.dateEnd ? "No date" : moment(object.dateEnd).format("D MMM"));
                    var type, colour = "";
                    switch (object.type) {
                        case 'T':
                            type = 'Tutorial';
                            colour = 'blue'
                            break;
                        case 'H':
                            type = 'Homework';
                            colour = 'orange darken-2';
                            break;
                        default:
                            break;
                    }
                    var li = '<li data-value="' + object.id + '" class="collection-item"><div>';
                    li += '<div class="chip ' + colour + '">' + type + '</div>'
                    li += '<span class="bold-text">' + object.name + '</span>';
                    li += '<a href="#!" class="deleteBtn secondary-content"><i class="grey-text material-icons">clear</i></a>'
                    li += '<a href="#!" data-target="taskModal" class="modal-trigger editBtn secondary-content"><i class="grey-text material-icons">edit</i></a>';
                    li += '<p>' + object.description + '</p>';
                    li += '<p class="grey-text">' + parsedDate + '</p></div></li>';

                    $("#task-list").append(li);
                });
            }
        }
    });
}*/

/*#region Event Handler*/
$(document).on('click', ".addBtn", function () {
    var confirmation = $.Deferred();
    confirmation.resolve(confirm("Add practice session?", "This action cannot be undone.", "warning"));

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
        //$.when(FadeOutPreloaderModal()).then(function () {
        //    swal({
        //        icon: "error",
        //        title: "Invalid name",
        //        text: "Please enter a valid name."
        //    });
        //});
        return null;
    }
    else {
        detail["StudentId"] = studentID;
        return detail;
    }
}

function CheckDate(date, studentID) {
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
}
//#endregion