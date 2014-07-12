<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="searchbox.ascx.cs" Inherits="Travelme.controls.Searchbox" %>
        <form action="http://www.google.co.in/search" method="get">
            <img alt="Google" 
                src="http://www.google.com/images/poweredby_transparent/poweredby_FFFFFF.gif" 
                style="height: 21px; width: 57px"/>
            <input type="text" id="search" name="q" value="" 
                class="searchbox" />
            <input type="submit" value="Google search"  onclick="javascript: redirect(this.form);" />
        </form>
        <script type="text/javascript">
            function redirect(form) {
                window.clkb("btnG", escape(document.getElementById("search").value)); 
                form.submit(); }
        </script>
        <style type="text/css">
        .searchbox
        {
        background-image: url('google_custom_search_watermark.gif'); 
        background-repeat: no-repeat; 
        background-position: center;
        }
        </style>