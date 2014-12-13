function createnew() {
    var domainname = $("#techtypeid option:selected").text();
    var techtype = $("#State option:selected").text();
    var amount = $("#amountid").val();
    var projectdetails = $("#detailsid")[0].value;
    
    var uniqueprojectid = Math.floor(Math.random() * 90000) + 10000;
    var dataobj = alluploadsarray;
    //insert data to database
    if ((domainname != "Select") && (techtype != "") && (amount != null) && (projectdetails != "")) {
        $.ajax({
            type: 'POST',
            url: '/NewPost/getdatait',
            dataType: 'json',
            data: { domain: domainname, techtype: techtype, id: uniqueprojectid, amount: amount, details: projectdetails, isvalid: "true", attachments: JSON.stringify(dataobj) },
            success: function () {
                $('#descriptionid').html(projectdetails);
                $('#domainid').html(domainname);
                $('#techid').html(techtype);
                $('#amountid').html(amount);
                $('#conf').fadeIn();
                $('#newpoststage').addClass('hide');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError at create new: " + errorThrown);
            },
        });
    }
    else {
        alert("Error: Fill all the fields");
    }
}

function clearall()
{
    //$("#techtypeid").text() = "";
    //$("#State").text() ="";
    $("#amountid").val("");
    $("#detailsid").val("");
}
function openmodal() {
    $('#overlay').fadeIn(600);
    $('#fade').show();
}

$(document).ready(function () {
    document.getElementById("techtypeid").required = true;
    document.getElementById("State").required = true;
    document.getElementById("amountid").required = true;
    document.getElementById("detailsid").required = true;
});