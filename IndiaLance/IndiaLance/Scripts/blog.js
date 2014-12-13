
var usersonline = "";
$(function () {
    $("#divChat").hide();
    $("#divLogin").show();
    var objHub = $.connection.myHub;
    loadClientMethods(objHub);
    $.connection.hub.start().done(function () {
        loadEvents(objHub);
    });
});

function loadEvents(objHub) {
    $("#btnLogin").click(function () {
        var name = $("#txtUserName").val();
        var pass = $("#txtPassword").val();
        if (name.length > 0 && pass.length > 0) {
            // <<<<<-- ***** Return to Server [  Connect  ] *****
            objHub.server.connect(name, pass);
        }
        else {
            alert("Please Insert UserName and Password");
        }
    });

    $(document).on('click', '#btnregister', function () {
        
        var name = $("#txtname").val();
        var pass = $("#txtpassword").val();
        var email = $("#txtemail").val();
        if (name.length > 0 && pass.length > 0 && email.length > 0) {
            // <<<<<-- ***** Return to Server [  register  ] *****
            objHub.server.register(name, pass, email);
        }
    });

    $('#btnSendMessage').click(function () {
        var msg = $("#txtMessage").val();
        if (msg.length > 0) {
            var userName = $('#hUserName').val();
            // <<<<<-- ***** Return to Server [  SendMessageToGroup  ] *****
            objHub.server.sendMessageToGroup(userName, msg);
        }
        $("#txtMessage").attr("tabindex", -1).focus();
        $('#txtMessage').animate({ scrollTop: $('#txtMessage').attr('scrollHeight') });

    });

    $("#txtPassword").keypress(function (e) {
        if (e.which == 13) {
            $("#btnLogin").click();
        }
    });

    $("#txtMessage").keypress(function (e) {
        if (e.which == 13) {
            $('#btnSendMessage').click();
        }
    });
}

function loadClientMethods(objHub) {

    objHub.client.NoExistAdmin = function () {
        var divNoExist = $('<div><p>Incorrect username or password!!</P></div>');
        $("#divChat").hide();
        $("#divLogin").show();
        $(divNoExist).hide();
        $('#divalarm').prepend(divNoExist);
        $(divNoExist).fadeIn(900).delay(1000).fadeOut(900);
    }

    objHub.client.servererror = function () {
        alert("Temporary server error.. please try again later");
    }

    objHub.client.register = function (username) {
        $("#divregistered").fadeIn(1000).delay(600).fadeOut(600);
        $("#divregistered").html(username + " registered successfully!!");
        $("#divregistered").animate({
            display: "block",
        }, 600, function () {
            $("#divregister").fadeOut(0);
            $("#divLogin").fadeIn(1000);
        });
    }

    objHub.client.getMessages = function (userName, message) {

        $("#txtMessage").val('');
        usersonline = userName;
        if ($('#hUserName').val() == userName) {
            $('#divMessage').append('<div style="text-align: right">' + userName + ': ' + message + '</div>');
        }
        else {
            $('#divMessage').append('<div style="text-align: left">' + userName + ': ' + message + '</div>');
        }
        var height = $('#divMessage')[0].scrollHeight;
        $('#divMessage').scrollTop(height);
    }

    objHub.client.onConnected = function (id, userName, UserID, userGroup) {
        var strWelcome = 'Welcome' + " " + userName;
        $('#welcome').append('<div><h1>Welcome: ' + userName + '</h1></div>');
        //$('#onlineusers').append('<div>online users: ' + adminonline + '</div>');
        $('#hId').val(id);
        $('#hUserId').val(UserID);
        $('#hUserName').val(userName);
        $('#hGroup').val(userGroup);
        $("#divChat").show();
        $("#divLogin").hide();
    }
}

$(document).ready(function () {
    $(document).on('click', '#registerid', function () {
        $('#txtname').val("");
        $('#txtpassword').val("");
        $('#txtemail').val("");
        $("#divLogin").fadeOut(0);
        $("#divregister").fadeIn(1000);
    });

    

    $(document).on('click', '.jqshowchatbox', function () {
        $('#divChatwinwod').removeClass('hide');
    });
});