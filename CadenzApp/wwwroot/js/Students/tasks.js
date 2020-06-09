let originalHeader = "Add task";
let editHeader = "Edit task";

$(document).ready(function () {
    PopulateTask();
});

function PopulateTask() {
    var studentID = GetStudentID();
    $.ajax({
        url: baseUrl + controller + "/GetTaskList",
        type: "GET",
        data: { StudentID: studentID },
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
}

//#region Event Handlers
$(document).on('click', ".deleteBtn", function () {
    var taskID = $(this).parent().parent().attr('data-value');
    var confirmation = $.Deferred();
    confirmation.resolve(confirmDanger("Delete task?", "This action cannot be undone.", "warning"));

    $.when(confirmation).then(function(confirmStatus) {
        if (confirmStatus) {
            DeleteTask(taskID);
        }
    });
});

$(document).on('click', ".editBtn", function () {
    var taskID = $(this).parent().parent().attr('data-value');
    $(".form-header").text(editHeader);
    PopulateForm(taskID);
});


function PopulateForm(taskID) {
    var studentID = GetStudentID();
    $.ajax({
        url: baseUrl + controller + "/GetTask",
        type: "GET",
        data: { "StudentID": studentID, "ID": taskID },
        cache: false,
        success: function (result) {
            $.each(result, function (index, object) {
                $("#inputTaskID").val(object.id);
                if (object.type) {
                    $("#inputTaskType").find("input[value='" + object.type + "']").prop("checked", true);
                }
                $("#inputTaskName").val(object.name);
                $("#inputTaskDescription").val(object.description);
                $("#inputTaskDate").val(moment(object.dateEnd).format("yyyy-MM-DD"));
                $('label').addClass('active');
            });
        }
        //$(".name-field").text(result.);
    });
}

function DeleteTask(ID) {
    var studentID = GetStudentID();
    $.ajax({
        url: baseUrl + controller + "/DeleteTask",
        data: "ID=" + ID,
        cache: false,
        error: function () {
            swal("Error", "Please try again later", "error");
        },
        success: function () {
            swal("", "Your data has been deactivated.", "success").then(function () {
                reload();
            })
        }
    });
}
//#endregion

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
    var studentID = GetStudentID();
    var tutorID = 1;

    var detail = {
        "Id": ($("#inputTaskID").val().length ? $("#inputTaskID").val() : 0),
        "Type": $("#inputTaskType").find("input:checked").val(),
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