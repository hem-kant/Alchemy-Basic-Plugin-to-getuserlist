<%@ Page Inherits="Tridion.Web.UI.Controls.TridionPage" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>UnLocalize</title>
    <script src="${JsUrl}/jquery-2.1.4.js" lang="javascript"></script>
    <link rel="stylesheet" type="text/css" href="${CssUrl}/Popup.css">
    
    <script>
        jQuery(document).ready(function () {

            var url = location.href;
            alert("url");

            jQuery('compUri').val(url); // Declare a proxy to reference the hub. 
 
        });
 
    </script>


</head>
<body>
    <h1>List Of users</h1> 
    <div id="compUri"></div>



</body>

</html>

 