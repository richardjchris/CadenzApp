$(document).ready(function () {
    PopulateTask();
});

function PopulateTask() {
    var studentID = 1;
    $.ajax({
        url: baseUrl + controller + "/GetTaskList",
        type: "GET",
        data: "StudentID=" + studentID,
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
                    var li = '<li data-value="' + object.id + '" class="collection-item">';
                    li += '<div><span class="bold-text">' + object.name + '</span>';
                    li += '<a href="#!" class="secondary-content"><i class="grey-text material-icons">clear</i></a>'
                    li += '<a href="#!" data-target="taskModal" class="modal-trigger editBtn secondary-content"><i class="grey-text material-icons">edit</i></a>';
                    li += '<p>' + object.description + '</p>';
                    li += '<p class="grey-text">' + parsedDate + '</p></div></li>';

                    $("#task-list").append(li);
                });
            }
        }
    });
}

$(document).on('click', ".editBtn", function () {
    var taskID = $(this).parent().parent().attr('data-value');
    console.log(taskID);
    PopulateForm(taskID);
});


function PopulateForm(taskID) {
    var studentID = 1;
    $.ajax({
        url: baseUrl + controller + "/GetTask",
        type: "GET",
        data: { "StudentID": studentID, "ID": taskID },
        success: function (result) {
            $.each(result, function (index, object) {
                $("#inputTaskID").val(object.id);
                if (result.type) {
                    $("#inputTaskType").find("input[value='" + object.type + "']").prop("checked", true);
                }
                $("#inputTaskName").val(object.name);
                $("#inputTaskDescription").val(object.description);
                $("#inputTaskDate").val(object.dateEnd);
                $('label').addClass('active');
            });
        }
        //$(".name-field").text(result.);
    });
}

$(".modalClose").click(function () {
    swal({
        title: "Close form?",
        text: "Any changes made will not be saved.",
        icon: 'warning',
        buttons: [
            "Cancel",
            "Close"
        ],
        dangerMode: true
    }).then(function (isConfirm) {
        if (isConfirm) {
            $('.modal').modal('close');
        }
    })
});

$('.modal.form').modal({
    dismissible: false,
    onCloseEnd: function () {
        ClearForm();
    }
});

function ClearForm() {
    $("input").val("");
}

//#region Form Submission
$("#submit-tasks").click(function () {
    SubmitTask();
});

function SubmitTask() {
    
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
        console.log(data);
        $.ajax({
            url: baseUrl + controller + "/InsertTask",
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
    var studentID = 1;
    var tutorID = 1;

    var detail = {
        "Id": ($("#inputTaskID").val().length ? $("#inputTaskID").val() : 0),
        "Type": $("#inputTaskType").find("input:first").prop("checked", true).val(),
        "Name": $("#inputTaskName").val(),
        "Description": $("#inputTaskDescription").val(),
        "StatusId": null,
        "DateEnd": $("#inputTaskDate").val(),
        "IsActive": true
    };

    if (detail["Name"] == null || detail["Name"] == "") {
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
        detail["TutorId"] = tutorID;
        return detail;
    }
}
//#endregion