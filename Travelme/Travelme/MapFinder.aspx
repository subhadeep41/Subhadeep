<%@ Page Title="" Language="C#" MasterPageFile="~/mrMaster.Master" AutoEventWireup="true" CodeBehind="MapFinder.aspx.cs" Inherits="Travelme.MapFinder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Mapfinder.js" type="text/javascript"></script>
    <div align="center">
<p id="demo" >Click the button to get your position:</p>
<button onclick="getLocation()">Try It</button>
</div>
<div id="mapholder"></div>

</asp:Content>
