<%@ Page Title="" Language="C#" MasterPageFile="~/mrMaster.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="Travelme.Home" %>

<%@ Register Src="controls/Categorybox.ascx" TagName="Categorybox" TagPrefix="uc1" %>
<%@ Register Src="controls/Usersearch.ascx" TagName="Usersearch" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="Homecss.css" rel="stylesheet" type="text/css" />
    <script src="Mapfinder.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            color: #990000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Top Block Starts -->
    <div id="top_block">
        <div id="tabs">
            <ul>
                <a href="#Locate" class="navi_tx">Locate</a> 
                <a href="#Railway" class="navi_tx">Railway</a>
                <a href="#Bus" class="navi_tx">Bus/Public</a> 
                <a href="#Taxi" class="navi_tx">Taxi/Private</a>
                <a href="#Map" class="navi_tx">Map Finder</a> 
                <a href="#Table" class="navi_tx">TimeTable</a>
                <%--/*<a href="#" class="navi_tx">Phone Numbers</a>--%>
            </ul>
            <div id="Locate" class="navi_hm">
                <uc2:Usersearch ID="Usersearch1" runat="server" />
            </div>
            <div id="Railway" class="navi_hm">
                <h4>
                    This is the railway page search routes and timetable from here Please select your
                    area:</h4>
                <a href="Railway.aspx">click here to go railway page</a>
            </div>
            <div id="Bus" class="navi_hm">
            </div>
            <div id="Taxi" class="navi_hm">
            </div>
            <div id="Map" class="navi_hm">
                
                <div align="center">
                    <p id="demo">
                        Click the button to get your position:</p>
                    <button onclick="getLocation()">
                        Try It</button>
                </div>
                <div id="mapholder">
                </div>
                <a href="MapFinder.aspx">Go to the Maps page for more querries !!</a>
            </div>
            <div id="Table" class="navi_hm">
            </div>
        </div>
        <div>
        </div>
    </div>
    
    <!--Top Block Ends -->
    <div class="heading1">
        We are here to help you with all the travelling facilities !!!
    </div>
    <%--<div class="heading1">
        Select your appropiate way to travel
        <div>
            <div>
                <uc1:Categorybox ID="Categorybox1" runat="server" />
            </div>
        </div>
    </div>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#Railway,#Bus,#Taxi,#Map,#Table').hide();
            $('#tabs div:first').show();
            //      $('#tabs ul:first').addClass('navi_tz');

            $('#tabs ul a').click(function () {
                //                        $('#tabs ul').removeClass('navi_tx');
                //                        $('#tabs ul').addClass('navi_tz');
                //                        $(this).parent().addClass('navi_tz');
                var currentTab = $(this).attr('href');
                // $('#tabs div ').hide();
                $(currentTab).show();
                if (currentTab == '#Locate') {
                    $('#tabs div').show();
                    $('#Railway,#Bus,#Taxi,#Map,#Table').hide();
                }
                if (currentTab != '#Locate') {
                    $('#tabs div').hide();
                    $(currentTab).show();
                }
                if (currentTab == '#Map') {
                    $('#tabs div').show();
                    $('#Railway,#Bus,#Taxi,#Locate,#Table').hide();
                }
                return false;
            });
        });
    </script>
</asp:Content>
