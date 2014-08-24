
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
        var divNoExist = $('<div><p>There is no Admin to response you try again later</P></div>');
        $("#divChat").hide();
        $("#divLogin").show();
        $(divNoExist).hide();
        $('#divalarm').prepend(divNoExist);
        $(divNoExist).fadeIn(900).delay(1000).fadeOut(900);
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

    objHub.client.onConnected = function (id, userName, UserID, userGroup, adminonline) {
        var strWelcome = 'Welcome' + " " + userName;
        $('#welcome').append('<div><h1>Welcome: ' + userName + '</h1></div>');
        $('#onlineusers').append('<div>online users: ' + adminonline + '</div>');
        $('#hId').val(id);
        $('#hUserId').val(UserID);
        $('#hUserName').val(userName);
        $('#hGroup').val(userGroup);
        $("#divChat").show();
        $("#divLogin").hide();
    }
}