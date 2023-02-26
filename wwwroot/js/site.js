
$(function () {
    $("#mansionNameSearch").keyup(function () {
        GetMansions();
    });
});


function GetMansions() {
    var mansionName = $.trim($("#mansionNameSearch").val());
    console.log(mansionName);
    var setData = $("#mansionBody")
    setData.html("");
    $.ajax({
        url: "/Admin/SearchMansionByName?mansion=" + mansionName,
        dataType: "html",
        success: function (result) {
            //console.log(result.trim().length);
            if (result.length < 10) {
                setData.append('<tr style="color:red"><td colspan="3">No Match Data</td></tr>');
            } else {
                $.each(JSON.parse(result), function (index, value) {
                    approve = "";
                    if (value.Approve) {
                        approve = "<div class='badge badge-outline-success'>Approved</div>"
                    } else {
                        approve = "<div class='badge badge-outline-warning'>Pending or Rejected</div>"
                    }
                    var Data = "<tr>" +
                        "<td>" + value.clientName + "</td>" +
                        "<td>" + value.mansionTitle + "</td>" +
                        "<td>" + value.mansionCategory + "</td>" +
                        "<td>" + value.price + "</td>" +
                        "<td>" + value.postDate + "</td>" +
                        "<td>" + approve + "</td>" +
                        "<td>" + "<a class='btn btn-success' href='/Admin/MansionState?mansionId=" + value.mansionId + "&mansionState=1'>Approve</a> "
                        + "<a class='btn btn-warning' href = '/Admin/MansionState?mansionId=" + value.mansionId + "&mansionState=0'> Decline</a> "
                        + "<a class='btn btn-info' href='/Admin/MansionDetails?mansionId=" + value.mansionId + "'>Details</a> "
                        + "<a class='btn btn-danger js-delete-mansion' data-id='" + value.mansionId + "' href='javascript:;'>Delete</a> " + "</td > " +
                        "</tr>";
                    setData.append(Data);
                })
            }
        },
        error: function (err) {
            console.log("Error " + err.value)
        }
    });
}
