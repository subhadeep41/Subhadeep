<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Usersearch.ascx.cs"
    Inherits="Travelme.controls.Usersearch" %>
<script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-ui-1.10.3.js" type="text/javascript"></script>
<link href="../accordtion.css" rel="stylesheet" type="text/css" />
<%--<link href="../style.css" rel="stylesheet" type="text/css" />--%>
<style type="text/css">
    .textbox12
    {
        font-family: 'Times New Roman' , Times, serif;
        text-align: left;
        font-size: x-large;
        background-color: #f0ebeb;
        height: 36px;
        width: 244px;
        border: 6px solid #d8d7d2;
    }
</style>
<div id="mainwidget">
    <div>
        Take me from
        <input type="text" id="text1" value="" name="tags" class="textbox12" />
        to
        <input type="text" id="TextBox2" name="TextBox2" class="textbox12" />
        <input type="submit" id="button1" class="btnsearch" value="Search" onclick="click();" />
        <div>
            <div id="accordion">
                <h3>
                    Train results</h3>
                <div>
                    <p>
                        dummy values here
                    </p>
                </div>
                <h3>
                    Bus results</h3>
                <div>
                    <p>
                        dummy values here
                    </p>
                </div>
                <h3>
                    Others</h3>
                <div>
                    <p>
                        dummy values here
                    </p>
                    <ul>
                        <li>List item one</li>
                        <li>List item two</li>
                        <li>List item three</li>
                    </ul>
                </div>
                <h3>
                    Map your location</h3>
                <div>
                    <p>
                        dummy values here
                    </p>
                    <p>
                        dummy values here
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        var myarr = [];
        $.ajax({
            type: "GET",
            url: "data.xml",
            datatype: "xml",
            success: parsexml,
            failure: function (data) {
                alert("xml not found");
            }
        });
        // for parsing value for autocomplete
        function parsexml(xml) {
            $(xml).find("state").each(function () {
                var thisitem = {};
                thisitem = $(this).attr("lable");
                myarr.push(thisitem);
            });
            $("#text1").autocomplete({
                source: myarr,
                minlength: 1
                //                select: function (event, ui) {
                //                    var str = "http://www.google.com/" + "search?q=" + (ui.item.label);
                //                    $("#text1").val(str);
                //                    location.href = str;
                //                }
            });
        }
        // end for parsing value

        $(function () {
            $("#accordion").accordion();
        });

    });
    function click(event, ui) {
        $("#button1").attr(url + "?state=" + (ui.item.label));
    };

</script>
