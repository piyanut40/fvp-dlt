<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SearchLicense.aspx.vb" Inherits="Control_SearchLicense" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">

    <title></title>
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel="stylesheet" href="../Scripts/typeahead/src/jquery.typeahead.css">

    <%--<script src="http://code.jquery.com/jquery-2.1.0.min.js"></script>--%>
    <script src="../Scripts/typeahead/jquery-2.1.0.min.js"></script>
    <script src="../Scripts/typeahead/src/jquery.typeahead.js"></script>

    <style type="text/css"> 
        *
        {
            margin: 0px;
            padding: 0px;
            font-family: "Raleway", sans-serif;
            font-size: 14px;
        }
        </style>
</head>
<body id="mBody" runat="server">
    <form id="form1" runat="server">
    <div id='scrolling-typeahead' name='scrolling-typeahead'> 
        <div class="typeahead__container">
            <div class="typeahead__field">
                <div class="typeahead__query">
                    <input class="js-typeahead"
                           name="q"
                           type="search"
                           autocomplete="off"  />
                </div>
                
            </div>
        </div>
        </div>
    </form>


    <style type="text/css">
     
#scrolling-typeahead .typeahead__list {
    max-height: 200px;
    overflow-y: auto;
    overflow-x: hidden;
}   
</style>
    <script language="javascript" >

        $(document).keyup(function (event) {
            window.parent.mgtonFocus();
        });

        function AddSmartSearch(data_source) {
            console.log(data_source);
            $.typeahead({
                input: ".js-typeahead",
                minLength: 0,
                order: "asc",
                limit: 5,

                searchOnFocus: true,
                display: ["license"],
                source: data_source,

                callback: {
                    onInit: function (node) {
                        //window.parent.mgtonFocus(node);
                        window.parent.mgtonFocus();
                    },
                    onClickAfter: function (node, a, item, event) {
                        window.parent.mgtonFocusClose(item.token);
                    },
                    onCancel: function () {
                        window.parent.mgtonFocusClose('');
                    }
                },
                debug: true
            });
        }
    </script>

</body>
</html>
