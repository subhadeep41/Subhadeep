<%@ Page Title="" Language="C#" MasterPageFile="~/mrMaster.Master" AutoEventWireup="true" 
CodeBehind="Railway.aspx.cs" Inherits="Travelme.Railway" %>

<%@ Register src="controls/Categorybox.ascx" tagname="Categorybox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <uc1:Categorybox ID="Categorybox1" runat="server" />
                    <asp:Image ID="Image1" runat="server" Height="234px" ImageUrl="~/images/burdwan1.jpg"
                         Width="340px" />
    </div>
    <div>
        <div style="text-align: right">
                </div>
    </div>
</asp:Content>
