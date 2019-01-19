const uri = "api/rooms";
let todos = null;
function getCount(data) {
    const el = $("#counter");
    let name = "Conference room";
    if (data) {
        if (data > 1) {
            name = "Conference rooms";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#todos");

            $(tBody).empty();

            getCount(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.id))
                    .append($("<td></td>").text(item.name))
                    .append(
                        $("<td></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    )
                    
                    .append($("<td></td>").text(item.capacity))
                    .append($("<td></td>").text(item.isAvalible))

                tr.appendTo(tBody);
            });

            todos = data;
            
            var x = document.getElementsByTagName("tr");
            var txt = "";
            var i;
            for (i = 0; i < x.length; i++) {
                txt = txt + "The index of Row " + (i + 1) + " is: " + x[i].rowIndex + "<br>";
             
            }
        }
    });
}

function addItem() {
    const item = {
        name: $("#add-name").val(),
        capacity: $("#add-capacity").val(),
        isAvalible: true
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
            $("#add-name").val("");
            $("#add-capacity").val("");
           
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(todos, function (key, item) {
        if (item.id === id) {
            $("#edit-name").val(item.name);
            $("#edit-capacity").val(item.capacity);
            $("#edit-id").val(item.id);
            $("#edit-isAvalible").checked = item.isAvalible; 
        }
    },
    
    $("#spoiler").css({ display: "block" }));
}


$(".my-form").on("submit", function () {
    const item = {
        name: $("#edit-name").val(),
        capacity: $("#edit-capacity").val(),
        isAvalible: $("#edit-isAvalible").is(":unchecked"),
        id: $("#edit-id").val()
    };

    $.ajax({
        url: uri + "/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}