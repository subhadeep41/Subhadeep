<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MyChatApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignalR chat application</title>
    <script src="Scripts/jquery-1.6.4.min.js"></script>
    <script src="Scripts/jquery.signalR-2.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="textMessage" />
        <input type ="button" id="SendMessage" value="broadcast" onclick="chatme();"/>
        <ul id="listmessages"></ul>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
   function chatme () {
        var chatme = $.connection.MyChatHub;
        chatme.client.addMessage = function (message) {
            $('#listmessages').append('<li>' + message + '<li>');
        };
        $('#SendMessage').click(function () {
            chatme.server.send($('#textMessage').val());
        });
        $.connection.hub.start();
    };

</script>
