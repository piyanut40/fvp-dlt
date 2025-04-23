<%--<%@ Page Language="VB" AutoEventWireup="true" MasterPageFile="~/MasterPageB.master" %>--%>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LicenseAppEdit.aspx.vb" MasterPageFile="~/MasterPageB.master"  Inherits="Admin_LicenseAppEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">


    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../font/Kanit/css/font.css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui.js"></script>
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>
    <link rel="Stylesheet" type="text/css" href="../Scripts/Semantic/semantic.min.css" />
    <script src="../Scripts/Semantic/semantic.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/css/w3-theme-deep-purple.css" />
    <link rel="stylesheet" href="../Styles/w3Home.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<script language="javascript" type="text/javascript">
        $(window).on('load',function () {
            $('#loadings').fadeout();
        });
    </script>
    <div id="loadings" align="center" class="overlays">
        <div class="loader"></div>
    </div>--%>
    <style>
        body {
            overflow-x: unset;
        }

        @font-face {
            font-family: 'Kanit', sans-serif;
            src: url('font/ThaiSansNeue-Regular/thaisansneue-bold-webfont.woff2');
        }

        .w3-col.l01 {
            width: 38px
        }

        .w3-col.l02 {
            width: 50px
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <header>
        <a class=" w3-text-purple" style="margin-left: 0%"><b style="font-size: 1.7em; margin-left: 0%; font-family: 'Kanit', sans-serif;"><i class="fa fa-pencil-square" aria-hidden="true"></i>Edit Application</b></a><br />
        <br>
    </header>
    <br>
   <div align="center">
        
            <div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative w3-text-deep-purple w3-card-2 w3-round-large w3-theme-l5 w3-row-padding">

                <script type="text/javascript">

                    function tab1() {

                        document.getElementById("tab1").className = "active";
                        document.getElementById("tab2").className = "";
                        document.getElementById("tab3").className = "";
                        document.getElementById("tab4").className = "";
                        //document.getElementById("tab5").className = "";
                        document.getElementById("form1").className = "text-dark w3-animate-right fill ";
                        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
                        //document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
                    }


                    function tab2() {

                        document.getElementById("tab2").className = "active";
                        document.getElementById("tab1").className = "completed";
                        document.getElementById("tab3").className = "";
                        document.getElementById("tab4").className = "";
                        // document.getElementById("tab5").className = "";
                        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form2").className = "text-dark w3-animate-right fill ";
                        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
                        //document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";
                    }

                    function tab3() {

                        document.getElementById("tab1").className = "completed";
                        document.getElementById("tab2").className = "completed";
                        document.getElementById("tab3").className = "active";
                        document.getElementById("tab4").className = "";
                        //document.getElementById("tab5").className = "";
                        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form3").className = "text-dark w3-animate-right fill pl-5";
                        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
                        //document.getElementById("form5").className = "text-dark w3-animate-right fill w3-hide";

                    }

                    function tab4() {

                        document.getElementById("tab1").className = "completed";
                        document.getElementById("tab2").className = "completed";
                        document.getElementById("tab3").className = "completed";
                        document.getElementById("tab4").className = "active";
                        //  document.getElementById("tab5").className = "";
                        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form4").className = "text-dark w3-animate-right pl-5";
                        //document.getElementById("form5").className = "text-dark w3-animate-right pl-5 w3-hide";

                    }

                    function tab5() {

                        document.getElementById("tab1").className = "completed";
                        document.getElementById("tab2").className = "completed";
                        document.getElementById("tab3").className = "completed";
                        document.getElementById("tab4").className = "completed";
                        // document.getElementById("tab5").className = "active";
                        document.getElementById("form1").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form2").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form3").className = "text-dark w3-animate-right fill w3-hide";
                        document.getElementById("form4").className = "text-dark w3-animate-right fill w3-hide";
                        //document.getElementById("form5").className = "text-dark w3-animate-right pl-5";
                    }

                    $(function () {
                        $("#MainContent_txtDate").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "-100:-15"
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });

                        $("#MainContent_txtDate").keyup(function () {
                            $("#MainContent_txtDate").val('');
                            $("#MainContent_txtDate").datepicker("option", "defaultDate", new Date(1919, 9, 3));
                        })
                        $("#MainContent_txtDate").datepicker("option", "defaultDate", new Date(1919, 9, 3));
                    });

                    $(function () {
                        $("#MainContent_txtPassportExpire").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });

                        $("#MainContent_txtPassportExpire").keyup(function () {
                            $("#MainContent_txtPassportExpire").val('');
                        })
                    });

                    $(function () {
                        $("#MainContent_txtPassport_exp2").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtPassport_exp2").keyup(function () {
                            $("#MainContent_txtPassport_exp2").val('');
                        })
                    });

                    $(function () {
                        $("#MainContent_txtPassport_exp3").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtPassport_exp3").keyup(function () {
                            $("#MainContent_txtPassport_exp3").val('');
                        })
                    });

                    $(function () {
                        $("#MainContent_txtLicenseExpire").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtLicenseExpire").keyup(function () {
                            $("#MainContent_txtLicenseExpire").val('');
                        })
                    });


                    $(function () {
                        $("#MainContent_txtLicenseExpire2").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtLicenseExpire2").keyup(function () {
                            $("#MainContent_txtLicenseExpire2").val('');
                        })
                    });


                    $(function () {
                        $("#MainContent_txtLicenseExpire3").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtLicenseExpire3").keyup(function () {
                            $("#MainContent_txtLicenseExpire3").val('');
                        })
                    });




                    $(function () {
                        $("#MainContent_txtActStart").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "-5 :+20"
                            , setDate: new Date()
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtActStart").keyup(function () {
                            $("#MainContent_txtActStart").val('');
                        })
                    });

                    $(function () {
                        $("#MainContent_txtActExpire").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtActExpire").keyup(function () {
                            $("#MainContent_txtActExpire").val('');
                        })
                    });


                    $(function () {
                        $("#MainContent_txtActStart2").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "-5 :+20"
                            , setDate: new Date()
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtActStart2").keyup(function () {
                            $("#MainContent_txtActStart2").val('');
                        })
                    });

                    $(function () {
                        $("#MainContent_txtActExpire2").datepicker({
                            changeMonth: true
                            , changeYear: true
                            , yearRange: "now :+20"
                            , setDate: new Date()
                            , minDate: '0'
                            , showButtonPanel: true
                            , dateFormat: 'dd/mm/yy'
                        });
                        $("#MainContent_txtActExpire2").keyup(function () {
                            $("#MainContent_txtActExpire2").val('');
                        })
                    });





                </script>


                <script type="text/javascript">


                    function alertDataDriver() {
                        $.confirm({
                            title: 'Notification ',
                            content: 'Is driver the same as owner?     YES or NO ',
                            buttons: {
                                confirm: function () {
                                    document.getElementById('MainContent_btnLoadDriver').click();
                                },
                                cancel: function () {

                                }
                            }
                        });
                    }

                    function SaveSuccess() {

                        alert("Save Information Success");

                    }

                    function fromCheck() {

                        alert("Please complete the information !!!");

                    }



                    function Error() {

                        alert("Please Fill information !!!");

                    }

                    function isJuristic(_chk) {
                        var chk = document.getElementById(_chk);

                        if (chk.checked == true) {
                            document.getElementById("MainContent_Juristic0").style.visibility = "hidden";
                            document.getElementById("MainContent_Juristic0").style.height = "0px";
                            document.getElementById("MainContent_Juristic1").style.visibility = "visible";
                            document.getElementById("MainContent_Juristic1").style.height = "auto";
                        }
                        else {
                            document.getElementById("MainContent_Juristic0").style.visibility = "visible";
                            document.getElementById("MainContent_Juristic0").style.height = "auto";
                            document.getElementById("MainContent_Juristic1").style.visibility = "hidden";
                            document.getElementById("MainContent_Juristic1").style.height = "0px";
                        }



                    }

                </script>

                <input type="button" name="ctl00$MainContent$btnLoaddata" value="Button" onclick="javascript:__doPostBack('ctl00$MainContent$btnLoaddata','')" id="MainContent_btnLoaddata" style="display: none">
                <input type="button" name="ctl00$MainContent$btnLoadDriver" value="Button" onclick="javascript:__doPostBack('ctl00$MainContent$btnLoadDriver','')" id="MainContent_btnLoadDriver" style="display: none">
                <input type="button" name="ctl00$MainContent$btnSubmit" value="Button" onclick="javascript:__doPostBack('ctl00$MainContent$btnSubmit','')" id="MainContent_btnSubmit" style="display: none">
                <input type="hidden" name="ctl00$MainContent$hiddriver_id" id="MainContent_hiddriver_id">
                <input type="hidden" name="ctl00$MainContent$hidcar_id" id="MainContent_hidcar_id">
                <input type="hidden" name="ctl00$MainContent$hidact_id" id="MainContent_hidact_id">
                <input type="hidden" name="ctl00$MainContent$hidlicense_id" id="MainContent_hidlicense_id">
                <input type="hidden" name="ctl00$MainContent$hidsparedriver_id1" id="MainContent_hidsparedriver_id1">
                <input type="hidden" name="ctl00$MainContent$hidsparedriver_id2" id="MainContent_hidsparedriver_id2">
                <input type="hidden" name="ctl00$MainContent$HiddenField1" id="MainContent_HiddenField1">

                <div id="form1" class="w3-animate-right fill center ui-form w3-margin text-dark ">
                    <div class="row">
                        
                        <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 70px; font-size: x-large;">Owner
                        </b>
                    </div>
                    
                    <span id="MainContent_lblcomments1" class="w3-text-red"></span>
                    <br>

                    <div class="ui form w3-margin" style="font-family: 'Kanit', sans-serif;">

                        <div id="MainContent_Page1_2">
	
                            <div class="fields">
                                <div class="one wide field"></div>

                                <div class=" sixteen wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <span class="w3-left"><input id="MainContent_chkisJuristic" type="checkbox" name="ctl00$MainContent$chkisJuristic" onclick="javascript:isJuristic('MainContent_chkisJuristic');"></span>&nbsp;<label for="name" class="w3-left"> Juristic Persons</label>
                                    
                                </div>
                            </div>

                            <div id="MainContent_Juristic0" class="fields " style="visibility: visible; height: auto;">

                                <div class="one wide field"></div>
                                <div id="MainContent_UpdatePanel20" class=" two wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
		

                                        <label for="Prename" class="w3-left">Title : </label>

                                        <%--<select name="ctl00$MainContent$ddlOwnerPrename" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlOwnerPrename\',\'\')', 0)" id="MainContent_ddlOwnerPrename" class="w3-input w3-border w3-round-large">
			<option selected="selected" value="Mr.">Mr.</option>
			<option value="Ms.">Ms.</option>
			<option value="Miss.">Miss.</option>
			<option value="Mrs.">Mrs.</option>
			<option value="Other">Other</option>

		</select>--%>
									<asp:DropDownList ID="ddlOwnerPrename" runat="server" CssClass="w3-input w3-border w3-round-large" AppendDataBoundItems="True">
    <asp:ListItem Text="Mr." Value="Mr." ></asp:ListItem>
    <asp:ListItem Text="Ms." Value="Ms."></asp:ListItem>
    <asp:ListItem Text="Miss." Value="Miss."></asp:ListItem>
    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
</asp:DropDownList>

                                        

                                    
	</div>

                                <div class="six wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> First name :</label>

                                    <asp:TextBox name="ctl00$MainContent$txtOwnerName" id="MainContent_txtOwnerName" type="text" class="w3-input w3-border w3-round-large" placeholder="First name" runat="server" />

                                </div>

                                <div class=" six wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> Last name :</label>

                                   <asp:TextBox name="ctl00$MainContent$txtOwnerLastName" id="MainContent_txtOwnerLastName" type="text" class="w3-input w3-border w3-round-large" placeholder=" Last name" runat="server"/>

                                </div>
                                <div class=" six wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> ID Card No. :</label>
                                    <asp:TextBox name="ctl00$MainContent$txtOwnerIdcard" id="MainContent_txtOwnerIdcard" type="text" class="w3-input w3-border w3-round-large" placeholder="Owner ID Card No."  runat="server"/>
                                </div>

                                <div class="four wide field " style="font-family: 'Kanit', sans-serif; font-size: small; display: none;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a>Telephone :</label>

                                   <asp:TextBox name="ctl00$MainContent$txtOwnertel" id="MainContent_txtOwnertel" type="text" class="w3-input w3-border w3-round-large" placeholder="Owner Telephone"  runat="server"/>
                                </div>

                            </div>

                            <div id="MainContent_Juristic1" class="fields" style="visibility: hidden; height: 0px;">
                                

                                <div class="one wide field"></div>


                                <div class="fourteen wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> Juristic name :</label>

                                    <input name="ctl00$MainContent$txtJuristicName" id="MainContent_txtJuristicName" type="text" class="w3-input w3-border w3-round-large" placeholder="Juristic name">

                                </div>


                                <div class=" six wide field " style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> Juristic ID :</label>
                                    <input name="ctl00$MainContent$txtJuristicID" id="MainContent_txtJuristicID" type="text" class="w3-input w3-border w3-round-large" placeholder="Juristic ID">
                                </div>


                            </div>


                            <div class="fields" style="margin-left: 4.5%;">
                                
                                <div class=" sixteen wide field" style="margin-top: -0.22rem; font-family: 'Kanit', sans-serif; font-size: small;">
                                    

                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> Address :</label>
									<asp:TextBox 
    ID="txtOwnerAddress" 
    runat="server" 
    CssClass="textarea w3-input w3-border w3-round-large" 
    placeholder="Owner Address" 
    TextMode="MultiLine" 
    Rows="4" 
    Columns="40" />

                                   <%-- <asp:TextBox name="ctl00$MainContent$txtOwnerAddress" rows="2" cols="20" id="MainContent_txtOwnerAddress" type="text" class="textarea w3-input w3-border w3-round-large" placeholder="Owner Address" runat="server"/>--%>

                                </div>
                            </div>
                            <div class="fields" style="margin-top: 1rem;">
                                <div class="one wide field"></div>
                                <div class="five wide field" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Province : </label>
                                    <asp:TextBox  id="txtOwnerProvince" type="Address" class="w3-input w3-border w3-round-large" placeholder="Province" runat="server"/>
                                </div>


                                <div class="three wide field" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Zipcode: </label>
                                     <asp:TextBox name="ctl00$MainContent$txtOwnerZipcode" id="MainContent_txtOwnerZipcode" type="Address" class="w3-input w3-border w3-round-large" placeholder="Zipcode" runat="server"/>
                                </div>

                                <div class="six wide field" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> Country : </label>
                                   <asp:DropDownList ID="ddlOwnerCountry" runat="server" CssClass="w3-input w3-border w3-round-large" AppendDataBoundItems="True">
    <asp:ListItem Text="Malaysia" Value="Malaysia" Selected="True"></asp:ListItem>
    <asp:ListItem Text="Myanmar" Value="Myanmar"></asp:ListItem>
    <asp:ListItem Text="Lao" Value="Lao"></asp:ListItem>
    <asp:ListItem Text="Vietnam" Value="Vietnam"></asp:ListItem>
    <asp:ListItem Text="Cambodia" Value="Cambodia"></asp:ListItem>
    <asp:ListItem Text="Singapore" Value="Singapore"></asp:ListItem>
    <asp:ListItem Text="China" Value="China"></asp:ListItem>
    <asp:ListItem Text="Indonesia" Value="Indonesia"></asp:ListItem>
    <asp:ListItem Text="Philippines" Value="Philippines"></asp:ListItem>
    <asp:ListItem Text="Timor-Leste" Value="Timor-Leste"></asp:ListItem>
    <asp:ListItem Text="Taiwan, Province of China" Value="Taiwan, Province of China"></asp:ListItem>
    <asp:ListItem Text="India" Value="India"></asp:ListItem>
    <asp:ListItem Text="Bangladesh" Value="Bangladesh"></asp:ListItem>
    <asp:ListItem Text="Australia" Value="Australia"></asp:ListItem>
	<asp:ListItem Text="Afghanistan" Value="Afghanistan"></asp:ListItem>
    <asp:ListItem Text="Åland Islands" Value="Åland Islands"></asp:ListItem>
    <asp:ListItem Text="Albania" Value="Albania"></asp:ListItem>
    <asp:ListItem Text="Algeria" Value="Algeria"></asp:ListItem>
    <asp:ListItem Text="American Samoa" Value="American Samoa"></asp:ListItem>
    <asp:ListItem Text="Andorra" Value="Andorra"></asp:ListItem>
    <asp:ListItem Text="Angola" Value="Angola"></asp:ListItem>
    <asp:ListItem Text="Anguilla" Value="Anguilla"></asp:ListItem>
    <asp:ListItem Text="Antarctica" Value="Antarctica"></asp:ListItem>
    <asp:ListItem Text="Antigua and Barbuda" Value="Antigua and Barbuda"></asp:ListItem>
    <asp:ListItem Text="Argentina" Value="Argentina"></asp:ListItem>
    <asp:ListItem Text="Armenia" Value="Armenia"></asp:ListItem>
    <asp:ListItem Text="Aruba" Value="Aruba"></asp:ListItem>
    <asp:ListItem Text="Austria" Value="Austria"></asp:ListItem>
    <asp:ListItem Text="Azerbaijan" Value="Azerbaijan"></asp:ListItem>
	<asp:ListItem Text="Bahamas" Value="Bahamas"></asp:ListItem>
    <asp:ListItem Text="Bahrain" Value="Bahrain"></asp:ListItem>
    <asp:ListItem Text="Barbados" Value="Barbados"></asp:ListItem>
    <asp:ListItem Text="Belarus" Value="Belarus"></asp:ListItem>
    <asp:ListItem Text="Belgium" Value="Belgium"></asp:ListItem>
    <asp:ListItem Text="Belize" Value="Belize"></asp:ListItem>
    <asp:ListItem Text="Benin" Value="Benin"></asp:ListItem>
    <asp:ListItem Text="Bermuda" Value="Bermuda"></asp:ListItem>
    <asp:ListItem Text="Bhutan" Value="Bhutan"></asp:ListItem>
    <asp:ListItem Text="Bolivia (Plurinational State of)" Value="Bolivia (Plurinational State of)"></asp:ListItem>
    <asp:ListItem Text="Bonaire, Sint Eustatius and Saba" Value="Bonaire, Sint Eustatius and Saba"></asp:ListItem>
    <asp:ListItem Text="Bosnia and Herzegovina" Value="Bosnia and Herzegovina"></asp:ListItem>
    <asp:ListItem Text="Botswana" Value="Botswana"></asp:ListItem>
    <asp:ListItem Text="Bouvet Island" Value="Bouvet Island"></asp:ListItem>
    <asp:ListItem Text="Brazil" Value="Brazil"></asp:ListItem>
	<asp:ListItem Text="British Indian Ocean Territory" Value="British Indian Ocean Territory"></asp:ListItem>
    <asp:ListItem Text="Brunei Darussalam" Value="Brunei Darussalam"></asp:ListItem>
    <asp:ListItem Text="Bulgaria" Value="Bulgaria"></asp:ListItem>
    <asp:ListItem Text="Burkina Faso" Value="Burkina Faso"></asp:ListItem>
    <asp:ListItem Text="Burundi" Value="Burundi"></asp:ListItem>
    <asp:ListItem Text="Cabo Verde" Value="Cabo Verde"></asp:ListItem>
    <asp:ListItem Text="Cameroon" Value="Cameroon"></asp:ListItem>
    <asp:ListItem Text="Canada" Value="Canada"></asp:ListItem>
    <asp:ListItem Text="Cayman Islands" Value="Cayman Islands"></asp:ListItem>
    <asp:ListItem Text="Central African Republic" Value="Central African Republic"></asp:ListItem>
    <asp:ListItem Text="Chad" Value="Chad"></asp:ListItem>
    <asp:ListItem Text="Chile" Value="Chile"></asp:ListItem>
    <asp:ListItem Text="Christmas Island" Value="Christmas Island"></asp:ListItem>
    <asp:ListItem Text="Cocos (Keeling) Islands" Value="Cocos (Keeling) Islands"></asp:ListItem>
	<asp:ListItem Text="Colombia" Value="Colombia"></asp:ListItem>
    <asp:ListItem Text="Comoros" Value="Comoros"></asp:ListItem>
    <asp:ListItem Text="Congo (Democratic Republic of the)" Value="Congo (Democratic Republic of the)"></asp:ListItem>
    <asp:ListItem Text="Congo (Republic of the)" Value="Congo (Republic of the)"></asp:ListItem>
    <asp:ListItem Text="Cook Islands" Value="Cook Islands"></asp:ListItem>
    <asp:ListItem Text="Costa Rica" Value="Costa Rica"></asp:ListItem>
    <asp:ListItem Text="Côte d Ivoire" Value="Côte d Ivoire"></asp:ListItem>
    <asp:ListItem Text="Croatia" Value="Croatia"></asp:ListItem>
    <asp:ListItem Text="Cuba" Value="Cuba"></asp:ListItem>
    <asp:ListItem Text="Curaçao" Value="Curaçao"></asp:ListItem>
    <asp:ListItem Text="Cyprus" Value="Cyprus"></asp:ListItem>
    <asp:ListItem Text="Czech Republic" Value="Czech Republic"></asp:ListItem>
    <asp:ListItem Text="Denmark" Value="Denmark"></asp:ListItem>
    <asp:ListItem Text="Djibouti" Value="Djibouti"></asp:ListItem>
	<asp:ListItem Text="Dominica" Value="Dominica"></asp:ListItem>
    <asp:ListItem Text="Dominican Republic" Value="Dominican Republic"></asp:ListItem>
    <asp:ListItem Text="Ecuador" Value="Ecuador"></asp:ListItem>
    <asp:ListItem Text="Egypt" Value="Egypt"></asp:ListItem>
    <asp:ListItem Text="El Salvador" Value="El Salvador"></asp:ListItem>
    <asp:ListItem Text="Equatorial Guinea" Value="Equatorial Guinea"></asp:ListItem>
    <asp:ListItem Text="Eritrea" Value="Eritrea"></asp:ListItem>
    <asp:ListItem Text="Estonia" Value="Estonia"></asp:ListItem>
    <asp:ListItem Text="Ethiopia" Value="Ethiopia"></asp:ListItem>
    <asp:ListItem Text="Falkland Islands (Malvinas)" Value="Falkland Islands (Malvinas)"></asp:ListItem>
    <asp:ListItem Text="Faroe Islands" Value="Faroe Islands"></asp:ListItem>
    <asp:ListItem Text="Fiji" Value="Fiji"></asp:ListItem>
    <asp:ListItem Text="Finland" Value="Finland"></asp:ListItem>
	<asp:ListItem Text="France" Value="France"></asp:ListItem>
    <asp:ListItem Text="French Guiana" Value="French Guiana"></asp:ListItem>
    <asp:ListItem Text="French Polynesia" Value="French Polynesia"></asp:ListItem>
    <asp:ListItem Text="French Southern Territories" Value="French Southern Territories"></asp:ListItem>
    <asp:ListItem Text="Gabon" Value="Gabon"></asp:ListItem>
    <asp:ListItem Text="Gambia" Value="Gambia"></asp:ListItem>
    <asp:ListItem Text="Georgia" Value="Georgia"></asp:ListItem>
    <asp:ListItem Text="Germany" Value="Germany"></asp:ListItem>
    <asp:ListItem Text="Ghana" Value="Ghana"></asp:ListItem>
    <asp:ListItem Text="Gibraltar" Value="Gibraltar"></asp:ListItem>
    <asp:ListItem Text="Greece" Value="Greece"></asp:ListItem>
    <asp:ListItem Text="Greenland" Value="Greenland"></asp:ListItem>
    <asp:ListItem Text="Grenada" Value="Grenada"></asp:ListItem>
	<asp:ListItem Text="Guadeloupe" Value="Guadeloupe"></asp:ListItem>
    <asp:ListItem Text="Guam" Value="Guam"></asp:ListItem>
    <asp:ListItem Text="Guatemala" Value="Guatemala"></asp:ListItem>
    <asp:ListItem Text="Guernsey" Value="Guernsey"></asp:ListItem>
    <asp:ListItem Text="Guinea" Value="Guinea"></asp:ListItem>
    <asp:ListItem Text="Guinea-Bissau" Value="Guinea-Bissau"></asp:ListItem>
    <asp:ListItem Text="Guyana" Value="Guyana"></asp:ListItem>
    <asp:ListItem Text="Haiti" Value="Haiti"></asp:ListItem>
    <asp:ListItem Text="Heard Island and McDonald Islands" Value="Heard Island and McDonald Islands"></asp:ListItem>
    <asp:ListItem Text="Honduras" Value="Honduras"></asp:ListItem>
    <asp:ListItem Text="Hong Kong" Value="Hong Kong"></asp:ListItem>
    <asp:ListItem Text="Hungary" Value="Hungary"></asp:ListItem>
    <asp:ListItem Text="Iceland" Value="Iceland"></asp:ListItem>
	<asp:ListItem Text="India" Value="India"></asp:ListItem>
    <asp:ListItem Text="Indonesia" Value="Indonesia"></asp:ListItem>
    <asp:ListItem Text="Iran (Islamic Republic of)" Value="Iran (Islamic Republic of)"></asp:ListItem>
    <asp:ListItem Text="Iraq" Value="Iraq"></asp:ListItem>
    <asp:ListItem Text="Ireland" Value="Ireland"></asp:ListItem>
    <asp:ListItem Text="Isle of Man" Value="Isle of Man"></asp:ListItem>
    <asp:ListItem Text="Israel" Value="Israel"></asp:ListItem>
    <asp:ListItem Text="Italy" Value="Italy"></asp:ListItem>
    <asp:ListItem Text="Jamaica" Value="Jamaica"></asp:ListItem>
    <asp:ListItem Text="Japan" Value="Japan"></asp:ListItem>
    <asp:ListItem Text="Jersey" Value="Jersey"></asp:ListItem>
    <asp:ListItem Text="Jordan" Value="Jordan"></asp:ListItem>
    <asp:ListItem Text="Kazakhstan" Value="Kazakhstan"></asp:ListItem>
	<asp:ListItem Text="Kenya" Value="Kenya"></asp:ListItem>
    <asp:ListItem Text="Kiribati" Value="Kiribati"></asp:ListItem>
    <asp:ListItem Text="Korea (Democratic People's Republic of)" Value="Korea (Democratic People's Republic of)"></asp:ListItem>
    <asp:ListItem Text="Korea (Republic of)" Value="Korea (Republic of)"></asp:ListItem>
    <asp:ListItem Text="Kuwait" Value="Kuwait"></asp:ListItem>
    <asp:ListItem Text="Kyrgyzstan" Value="Kyrgyzstan"></asp:ListItem>
    <asp:ListItem Text="Lao" Value="Lao"></asp:ListItem>
    <asp:ListItem Text="Latvia" Value="Latvia"></asp:ListItem>
    <asp:ListItem Text="Lebanon" Value="Lebanon"></asp:ListItem>
    <asp:ListItem Text="Lesotho" Value="Lesotho"></asp:ListItem>
    <asp:ListItem Text="Liberia" Value="Liberia"></asp:ListItem>
    <asp:ListItem Text="Libya" Value="Libya"></asp:ListItem>
    <asp:ListItem Text="Liechtenstein" Value="Liechtenstein"></asp:ListItem>
	<asp:ListItem Text="Lithuania" Value="Lithuania"></asp:ListItem>
    <asp:ListItem Text="Luxembourg" Value="Luxembourg"></asp:ListItem>
    <asp:ListItem Text="Macao" Value="Macao"></asp:ListItem>
    <asp:ListItem Text="Madagascar" Value="Madagascar"></asp:ListItem>
    <asp:ListItem Text="Malawi" Value="Malawi"></asp:ListItem>
    <asp:ListItem Text="Malaysia" Value="Malaysia"></asp:ListItem>
    <asp:ListItem Text="Maldives" Value="Maldives"></asp:ListItem>
    <asp:ListItem Text="Mali" Value="Mali"></asp:ListItem>
    <asp:ListItem Text="Malta" Value="Malta"></asp:ListItem>
    <asp:ListItem Text="Marshall Islands" Value="Marshall Islands"></asp:ListItem>
    <asp:ListItem Text="Martinique" Value="Martinique"></asp:ListItem>
    <asp:ListItem Text="Mauritania" Value="Mauritania"></asp:ListItem>
    <asp:ListItem Text="Mauritius" Value="Mauritius"></asp:ListItem>
	<asp:ListItem Text="Mayotte" Value="Mayotte"></asp:ListItem>
    <asp:ListItem Text="Mexico" Value="Mexico"></asp:ListItem>
    <asp:ListItem Text="Micronesia (Federated States of)" Value="Micronesia (Federated States of)"></asp:ListItem>
    <asp:ListItem Text="Moldova (Republic of)" Value="Moldova (Republic of)"></asp:ListItem>
    <asp:ListItem Text="Monaco" Value="Monaco"></asp:ListItem>
    <asp:ListItem Text="Mongolia" Value="Mongolia"></asp:ListItem>
    <asp:ListItem Text="Montenegro" Value="Montenegro"></asp:ListItem>
    <asp:ListItem Text="Montserrat" Value="Montserrat"></asp:ListItem>
    <asp:ListItem Text="Morocco" Value="Morocco"></asp:ListItem>
    <asp:ListItem Text="Mozambique" Value="Mozambique"></asp:ListItem>
    <asp:ListItem Text="Myanmar" Value="Myanmar"></asp:ListItem>
    <asp:ListItem Text="Namibia" Value="Namibia"></asp:ListItem>
    <asp:ListItem Text="Nauru" Value="Nauru"></asp:ListItem>
	<asp:ListItem Text="Nepal" Value="Nepal"></asp:ListItem>
    <asp:ListItem Text="Netherlands" Value="Netherlands"></asp:ListItem>
    <asp:ListItem Text="New Caledonia" Value="New Caledonia"></asp:ListItem>
    <asp:ListItem Text="New Zealand" Value="New Zealand"></asp:ListItem>
    <asp:ListItem Text="Nicaragua" Value="Nicaragua"></asp:ListItem>
    <asp:ListItem Text="Niger" Value="Niger"></asp:ListItem>
    <asp:ListItem Text="Nigeria" Value="Nigeria"></asp:ListItem>
    <asp:ListItem Text="Niue" Value="Niue"></asp:ListItem>
    <asp:ListItem Text="Norfolk Island" Value="Norfolk Island"></asp:ListItem>
    <asp:ListItem Text="Northern Mariana Islands" Value="Northern Mariana Islands"></asp:ListItem>
    <asp:ListItem Text="Norway" Value="Norway"></asp:ListItem>
    <asp:ListItem Text="Oman" Value="Oman"></asp:ListItem>
	<asp:ListItem Text="Pakistan" Value="Pakistan"></asp:ListItem>
    <asp:ListItem Text="Palau" Value="Palau"></asp:ListItem>
    <asp:ListItem Text="Panama" Value="Panama"></asp:ListItem>
    <asp:ListItem Text="Papua New Guinea" Value="Papua New Guinea"></asp:ListItem>
    <asp:ListItem Text="Paraguay" Value="Paraguay"></asp:ListItem>
    <asp:ListItem Text="Peru" Value="Peru"></asp:ListItem>
    <asp:ListItem Text="Philippines" Value="Philippines"></asp:ListItem>
    <asp:ListItem Text="Pitcairn" Value="Pitcairn"></asp:ListItem>
    <asp:ListItem Text="Poland" Value="Poland"></asp:ListItem>
    <asp:ListItem Text="Portugal" Value="Portugal"></asp:ListItem>
    <asp:ListItem Text="Puerto Rico" Value="Puerto Rico"></asp:ListItem>
    <asp:ListItem Text="Qatar" Value="Qatar"></asp:ListItem>
	<asp:ListItem Text="Romania" Value="Romania"></asp:ListItem>
    <asp:ListItem Text="Russian Federation" Value="Russian Federation"></asp:ListItem>
    <asp:ListItem Text="Rwanda" Value="Rwanda"></asp:ListItem>
    <asp:ListItem Text="Réunion" Value="Réunion"></asp:ListItem>
    <asp:ListItem Text="Saint Barthélemy" Value="Saint Barthélemy"></asp:ListItem>
    <asp:ListItem Text="Saint Helena, Ascension and Tristan da Cunha" Value="Saint Helena, Ascension and Tristan da Cunha"></asp:ListItem>
    <asp:ListItem Text="Saint Kitts and Nevis" Value="Saint Kitts and Nevis"></asp:ListItem>
    <asp:ListItem Text="Saint Lucia" Value="Saint Lucia"></asp:ListItem>
    <asp:ListItem Text="Saint Martin (French part)" Value="Saint Martin (French part)"></asp:ListItem>
    <asp:ListItem Text="Saint Pierre and Miquelon" Value="Saint Pierre and Miquelon"></asp:ListItem>
    <asp:ListItem Text="Saint Vincent and the Grenadines" Value="Saint Vincent and the Grenadines"></asp:ListItem>
    <asp:ListItem Text="Samoa" Value="Samoa"></asp:ListItem>
	<asp:ListItem Text="San Marino" Value="San Marino"></asp:ListItem>
    <asp:ListItem Text="Sao Tome and Principe" Value="Sao Tome and Principe"></asp:ListItem>
    <asp:ListItem Text="Saudi Arabia" Value="Saudi Arabia"></asp:ListItem>
    <asp:ListItem Text="Senegal" Value="Senegal"></asp:ListItem>
    <asp:ListItem Text="Serbia" Value="Serbia"></asp:ListItem>
    <asp:ListItem Text="Seychelles" Value="Seychelles"></asp:ListItem>
    <asp:ListItem Text="Sierra Leone" Value="Sierra Leone"></asp:ListItem>
    <asp:ListItem Text="Singapore" Value="Singapore"></asp:ListItem>
    <asp:ListItem Text="Sint Maarten (Dutch part)" Value="Sint Maarten (Dutch part)"></asp:ListItem>
    <asp:ListItem Text="Slovakia (Slovak Republic)" Value="Slovakia (Slovak Republic)"></asp:ListItem>
    <asp:ListItem Text="Slovenia" Value="Slovenia"></asp:ListItem>
    <asp:ListItem Text="Solomon Islands" Value="Solomon Islands"></asp:ListItem>
	<asp:ListItem Text="Somalia" Value="Somalia"></asp:ListItem>
    <asp:ListItem Text="South Africa" Value="South Africa"></asp:ListItem>
    <asp:ListItem Text="South Georgia and the South Sandwich Islands" Value="South Georgia and the South Sandwich Islands"></asp:ListItem>
    <asp:ListItem Text="South Sudan" Value="South Sudan"></asp:ListItem>
    <asp:ListItem Text="Spain" Value="Spain"></asp:ListItem>
    <asp:ListItem Text="Sri Lanka" Value="Sri Lanka"></asp:ListItem>
    <asp:ListItem Text="Sudan" Value="Sudan"></asp:ListItem>
    <asp:ListItem Text="Suriname" Value="Suriname"></asp:ListItem>
    <asp:ListItem Text="Svalbard and Jan Mayen" Value="Svalbard and Jan Mayen"></asp:ListItem>
    <asp:ListItem Text="Sweden" Value="Sweden"></asp:ListItem>
    <asp:ListItem Text="Switzerland" Value="Switzerland"></asp:ListItem>
    <asp:ListItem Text="Syrian Arab Republic" Value="Syrian Arab Republic"></asp:ListItem>
	 <asp:ListItem Text="Taiwan" Value="Taiwan"></asp:ListItem>
    <asp:ListItem Text="Tajikistan" Value="Tajikistan"></asp:ListItem>
    <asp:ListItem Text="Tanzania (United Republic of)" Value="Tanzania (United Republic of)"></asp:ListItem>
    <asp:ListItem Text="Thailand" Value="Thailand"></asp:ListItem>
    <asp:ListItem Text="Timor-Leste" Value="Timor-Leste"></asp:ListItem>
    <asp:ListItem Text="Togo" Value="Togo"></asp:ListItem>
    <asp:ListItem Text="Tokelau" Value="Tokelau"></asp:ListItem>
    <asp:ListItem Text="Tonga" Value="Tonga"></asp:ListItem>
    <asp:ListItem Text="Trinidad and Tobago" Value="Trinidad and Tobago"></asp:ListItem>
    <asp:ListItem Text="Tunisia" Value="Tunisia"></asp:ListItem>
    <asp:ListItem Text="Turkey" Value="Turkey"></asp:ListItem>
    <asp:ListItem Text="Turkmenistan" Value="Turkmenistan"></asp:ListItem>
	<asp:ListItem Text="Tuvalu" Value="Tuvalu"></asp:ListItem>
    <asp:ListItem Text="Uganda" Value="Uganda"></asp:ListItem>
    <asp:ListItem Text="Ukraine" Value="Ukraine"></asp:ListItem>
    <asp:ListItem Text="United Arab Emirates" Value="United Arab Emirates"></asp:ListItem>
    <asp:ListItem Text="United Kingdom" Value="United Kingdom"></asp:ListItem>
    <asp:ListItem Text="United States of America" Value="United States of America"></asp:ListItem>
    <asp:ListItem Text="Uruguay" Value="Uruguay"></asp:ListItem>
    <asp:ListItem Text="Uzbekistan" Value="Uzbekistan"></asp:ListItem>
    <asp:ListItem Text="Vanuatu" Value="Vanuatu"></asp:ListItem>
    <asp:ListItem Text="Venezuela (Bolivarian Republic of)" Value="Venezuela (Bolivarian Republic of)"></asp:ListItem>
    <asp:ListItem Text="Viet Nam" Value="Viet Nam"></asp:ListItem>
    <asp:ListItem Text="Western Sahara" Value="Western Sahara"></asp:ListItem>
	<asp:ListItem Text="Yemen" Value="Yemen"></asp:ListItem>
    <asp:ListItem Text="Zambia" Value="Zambia"></asp:ListItem>
    <asp:ListItem Text="Zimbabwe" Value="Zimbabwe"></asp:ListItem>
</asp:DropDownList>

                                </div>

                                <div class="six wide field" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                    <label for="name" class="w3-left"><a class="w3-text-red">*</a> Email : </label>
                                    <asp:TextBox name="ctl00$MainContent$txtLicenseEmail" id="MainContent_txtLicenseEmail" type="text" class="w3-input w3-border w3-round-large" placeholder="Email"  runat="server"/>
                                </div>

                            </div>

                        
</div>


                        <br>
                        
                    </div>

                
                    
                    <div class="row">
                        <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 6%; font-size: x-large;">Main Driver
                        </b>
                    </div>
                    <br>
                    <span id="MainContent_lblcomments2" class="w3-text-red"></span>
                    <br>

                    <div id="MainContent_Page2">
	

                        <div class="ui stackable five column grid container " style="font-family: 'Kanit', sans-serif;">
                            
                            <div class="w3-left fields col-md-1 pb-3">
                                <div id="MainContent_UpdatePanel3" style="font-family: 'Kanit', sans-serif; font-size: small;">
		


                                        <label for="Prename" class="w3-left"><a class="w3-text-red">*</a>Title : </label>
                                        <select name="ctl00$MainContent$ddlPrename" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlPrename\',\'\')', 0)" id="MainContent_ddlPrename" class="w3-input w3-border w3-round-large">
			<option selected="selected" value="Mr.">Mr.</option>
			<option value="Ms.">Ms.</option>
			<option value="Miss.">Miss.</option>
			<option value="Mrs.">Mrs.</option>
			<option value="Other">Other</option>

		</select>
                                        


                                    
	</div>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left"><a class="w3-text-red">*</a> Name : </label>
                                <asp:TextBox name="ctl00$MainContent$txtName" id="MainContent_txtName" type="Name" class="w3-input w3-border w3-round-large" placeholder="Name" runat="server"/>

                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left fields"><a class="w3-text-red">*</a> Last Name : </label>
                                <asp:TextBox name="ctl00$MainContent$txtSurname" id="MainContent_txtSurname" type="Surname" class="w3-input w3-border w3-round-large" placeholder="Last Name" runat="server"/>
                            </div>



                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left fields"><a class="w3-text-red">*</a> Gender : </label>
                                <select name="ctl00$MainContent$ddlGender" id="MainContent_ddlGender" class="w3-input w3-border w3-round-large">
		<option value="Male">Male</option>
		<option value="Female">Female</option>

	</select>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields"><a class="w3-text-red">*</a> Birth Date : </label>
                                <asp:TextBox name="ctl00$MainContent$txtDate" id="MainContent_txtDate" type="txtDate" autocomplete="off" class="w3-input w3-border w3-round-large w3-left hasDatepicker" placeholder="Birth Date" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left fields"><a class="w3-text-red">*</a> Nationality : </label>
                                <select name="ctl00$MainContent$ddlNational" id="MainContent_ddlNational" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="Malaysian">Malaysian</option>
		<option value="Burmese">Burmese</option>
		<option value="Lao">Lao</option>
		<option value="Vietnamese">Vietnamese</option>
		<option value="Cambodian">Cambodian</option>
		<option value="Singaporean">Singaporean</option>
		<option value="Chinese">Chinese</option>
		<option value="Indonesian">Indonesian</option>
		<option value="Philippine, Filipino">Philippine, Filipino</option>
		<option value="Timorese">Timorese</option>
		<option value="Chinese, Taiwanese">Chinese, Taiwanese</option>
		<option value="Indian">Indian</option>
		<option value="Bangladeshi">Bangladeshi</option>
		<option value="Australian">Australian</option>
		<option value="Afghan">Afghan</option>
		<option value="Åland Island">Åland Island</option>
		<option value="Albanian">Albanian</option>
		<option value="Algerian">Algerian</option>
		<option value="American">American</option>
		<option value="American Samoan">American Samoan</option>
		<option value="Andorran">Andorran</option>
		<option value="Angolan">Angolan</option>
		<option value="Anguillan">Anguillan</option>
		<option value="Antarctic">Antarctic</option>
		<option value="Antiguan or Barbudan">Antiguan or Barbudan</option>
		<option value="Argentine">Argentine</option>
		<option value="Armenian">Armenian</option>
		<option value="Aruban">Aruban</option>
		<option value="Austrian">Austrian</option>
		<option value="Azerbaijani, Azeri">Azerbaijani, Azeri</option>
		<option value="Bahamian">Bahamian</option>
		<option value="Bahraini">Bahraini</option>
		<option value="Barbadian">Barbadian</option>
		<option value="Barthélemois">Barthélemois</option>
		<option value="Basotho">Basotho</option>
		<option value="Belarusian">Belarusian</option>
		<option value="Belgian">Belgian</option>
		<option value="Belizean">Belizean</option>
		<option value="Beninese, Beninois">Beninese, Beninois</option>
		<option value="Bermudian, Bermudan">Bermudian, Bermudan</option>
		<option value="Bhutanese">Bhutanese</option>
		<option value="BIOT">BIOT</option>
		<option value="Bissau-Guinean">Bissau-Guinean</option>
		<option value="Bolivian">Bolivian</option>
		<option value="Bonaire">Bonaire</option>
		<option value="Bosnian or Herzegovinian">Bosnian or Herzegovinian</option>
		<option value="Bouvet Island">Bouvet Island</option>
		<option value="Brazilian">Brazilian</option>
		<option value="British Virgin Island">British Virgin Island</option>
		<option value="British, UK">British, UK</option>
		<option value="Bruneian">Bruneian</option>
		<option value="Bulgarian">Bulgarian</option>
		<option value="Burkinabé">Burkinabé</option>
		<option value="Burundian">Burundian</option>
		<option value="Cabo Verdean">Cabo Verdean</option>
		<option value="Cameroonian">Cameroonian</option>
		<option value="Canadian">Canadian</option>
		<option value="Caymanian">Caymanian</option>
		<option value="Central African">Central African</option>
		<option value="Chadian">Chadian</option>
		<option value="Channel Island">Channel Island</option>
		<option value="Chilean">Chilean</option>
		<option value="Christmas Island">Christmas Island</option>
		<option value="Cocos Island">Cocos Island</option>
		<option value="Colombian">Colombian</option>
		<option value="Comoran, Comorian">Comoran, Comorian</option>
		<option value="Congolese">Congolese</option>
		<option value="Cook Island">Cook Island</option>
		<option value="Costa Rican">Costa Rican</option>
		<option value="Croatian">Croatian</option>
		<option value="Cuban">Cuban</option>
		<option value="Curaçaoan">Curaçaoan</option>
		<option value="Cypriot">Cypriot</option>
		<option value="Czech">Czech</option>
		<option value="Danish">Danish</option>
		<option value="Djiboutian">Djiboutian</option>
		<option value="Dominican">Dominican</option>
		<option value="Dutch, Netherlandic">Dutch, Netherlandic</option>
		<option value="Ecuadorian">Ecuadorian</option>
		<option value="Egyptian">Egyptian</option>
		<option value="Emirati, Emirian, Emiri">Emirati, Emirian, Emiri</option>
		<option value="Equatorial Guinean, Equatoguinean">Equatorial Guinean, Equatoguinean</option>
		<option value="Eritrean">Eritrean</option>
		<option value="Estonian">Estonian</option>
		<option value="Ethiopian">Ethiopian</option>
		<option value="Falkland Island">Falkland Island</option>
		<option value="Faroese">Faroese</option>
		<option value="Fijian">Fijian</option>
		<option value="Finnish">Finnish</option>
		<option value="French">French</option>
		<option value="French Guianese">French Guianese</option>
		<option value="French Polynesian">French Polynesian</option>
		<option value="French Southern Territories">French Southern Territories</option>
		<option value="Gabonese">Gabonese</option>
		<option value="Gambian">Gambian</option>
		<option value="Georgian">Georgian</option>
		<option value="German">German</option>
		<option value="Ghanaian">Ghanaian</option>
		<option value="Gibraltar">Gibraltar</option>
		<option value="Greek, Hellenic">Greek, Hellenic</option>
		<option value="Greenlandic">Greenlandic</option>
		<option value="Grenadian">Grenadian</option>
		<option value="Guadeloupe">Guadeloupe</option>
		<option value="Guamanian, Guambat">Guamanian, Guambat</option>
		<option value="Guatemalan">Guatemalan</option>
		<option value="Guinean">Guinean</option>
		<option value="Guyanese">Guyanese</option>
		<option value="Haitian">Haitian</option>
		<option value="Heard Island or McDonald Islands">Heard Island or McDonald Islands</option>
		<option value="Honduran">Honduran</option>
		<option value="Hong Kong, Hong Kongese">Hong Kong, Hong Kongese</option>
		<option value="Hungarian, Magyar">Hungarian, Magyar</option>
		<option value="I-Kiribati">I-Kiribati</option>
		<option value="Icelandic">Icelandic</option>
		<option value="Iranian, Persian">Iranian, Persian</option>
		<option value="Iraqi">Iraqi</option>
		<option value="Irish">Irish</option>
		<option value="Israeli">Israeli</option>
		<option value="Italian">Italian</option>
		<option value="Ivorian">Ivorian</option>
		<option value="Jamaican">Jamaican</option>
		<option value="Japanese">Japanese</option>
		<option value="Jordanian">Jordanian</option>
		<option value="Kazakhstani, Kazakh">Kazakhstani, Kazakh</option>
		<option value="Kenyan">Kenyan</option>
		<option value="Kittitian or Nevisian">Kittitian or Nevisian</option>
		<option value="Kuwaiti">Kuwaiti</option>
		<option value="Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz">Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz</option>
		<option value="Latvian">Latvian</option>
		<option value="Lebanese">Lebanese</option>
		<option value="Liberian">Liberian</option>
		<option value="Libyan">Libyan</option>
		<option value="Liechtenstein">Liechtenstein</option>
		<option value="Lithuanian">Lithuanian</option>
		<option value="Luxembourg, Luxembourgish">Luxembourg, Luxembourgish</option>
		<option value="Macanese, Chinese">Macanese, Chinese</option>
		<option value="Macedonian">Macedonian</option>
		<option value="Mahoran">Mahoran</option>
		<option value="Malagasy">Malagasy</option>
		<option value="Malawian">Malawian</option>
		<option value="Maldivian">Maldivian</option>
		<option value="Malian, Malinese">Malian, Malinese</option>
		<option value="Maltese">Maltese</option>
		<option value="Manx">Manx</option>
		<option value="Marshallese">Marshallese</option>
		<option value="Martiniquais, Martinican">Martiniquais, Martinican</option>
		<option value="Mauritanian">Mauritanian</option>
		<option value="Mauritian">Mauritian</option>
		<option value="Mexican">Mexican</option>
		<option value="Micronesian">Micronesian</option>
		<option value="Moldovan">Moldovan</option>
		<option value="Monégasque, Monacan">Monégasque, Monacan</option>
		<option value="Mongolian">Mongolian</option>
		<option value="Montenegrin">Montenegrin</option>
		<option value="Montserratian">Montserratian</option>
		<option value="Moroccan">Moroccan</option>
		<option value="Motswana, Botswanan">Motswana, Botswanan</option>
		<option value="Mozambican">Mozambican</option>
		<option value="Namibian">Namibian</option>
		<option value="Nauruan">Nauruan</option>
		<option value="Nepali, Nepalese">Nepali, Nepalese</option>
		<option value="New Caledonian">New Caledonian</option>
		<option value="New Zealand, NZ">New Zealand, NZ</option>
		<option value="Ni-Vanuatu, Vanuatuan">Ni-Vanuatu, Vanuatuan</option>
		<option value="Nicaraguan">Nicaraguan</option>
		<option value="Nigerian">Nigerian</option>
		<option value="Nigerien">Nigerien</option>
		<option value="Niuean">Niuean</option>
		<option value="Norfolk Island">Norfolk Island</option>
		<option value="North Korean">North Korean</option>
		<option value="Northern Marianan">Northern Marianan</option>
		<option value="Norwegian">Norwegian</option>
		<option value="Omani">Omani</option>
		<option value="Pakistani">Pakistani</option>
		<option value="Palauan">Palauan</option>
		<option value="Palestinian">Palestinian</option>
		<option value="Panamanian">Panamanian</option>
		<option value="Papua New Guinean, Papuan">Papua New Guinean, Papuan</option>
		<option value="Paraguayan">Paraguayan</option>
		<option value="Peruvian">Peruvian</option>
		<option value="Pitcairn Island">Pitcairn Island</option>
		<option value="Polish">Polish</option>
		<option value="Portuguese">Portuguese</option>
		<option value="Puerto Rican">Puerto Rican</option>
		<option value="Qatari">Qatari</option>
		<option value="Réunionese, Réunionnais">Réunionese, Réunionnais</option>
		<option value="Romanian">Romanian</option>
		<option value="Russian">Russian</option>
		<option value="Rwandan">Rwandan</option>
		<option value="Sahrawi, Sahrawian, Sahraouian">Sahrawi, Sahrawian, Sahraouian</option>
		<option value="Saint-Martinoise">Saint-Martinoise</option>
		<option value="Saint-Pierrais or Miquelonnais">Saint-Pierrais or Miquelonnais</option>
		<option value="Saint Helenian">Saint Helenian</option>
		<option value="Saint Lucian">Saint Lucian</option>
		<option value="Saint Vincentian, Vincentian">Saint Vincentian, Vincentian</option>
		<option value="Salvadoran">Salvadoran</option>
		<option value="Sammarinese">Sammarinese</option>
		<option value="Samoan">Samoan</option>
		<option value="São Toméan">São Toméan</option>
		<option value="Saudi, Saudi Arabian">Saudi, Saudi Arabian</option>
		<option value="Senegalese">Senegalese</option>
		<option value="Serbian">Serbian</option>
		<option value="Seychellois">Seychellois</option>
		<option value="Sierra Leonean">Sierra Leonean</option>
		<option value="Sint Maarten">Sint Maarten</option>
		<option value="Slovak">Slovak</option>
		<option value="Slovenian, Slovene">Slovenian, Slovene</option>
		<option value="Solomon Island">Solomon Island</option>
		<option value="Somali, Somalian">Somali, Somalian</option>
		<option value="South African">South African</option>
		<option value="South Georgia or South Sandwich Islands">South Georgia or South Sandwich Islands</option>
		<option value="South Korean">South Korean</option>
		<option value="South Sudanese">South Sudanese</option>
		<option value="Spanish">Spanish</option>
		<option value="Sri Lankan">Sri Lankan</option>
		<option value="Sudanese">Sudanese</option>
		<option value="Surinamese">Surinamese</option>
		<option value="Svalbard">Svalbard</option>
		<option value="Swazi">Swazi</option>
		<option value="Swedish">Swedish</option>
		<option value="Swiss">Swiss</option>
		<option value="Syrian">Syrian</option>
		<option value="Tajikistani">Tajikistani</option>
		<option value="Tanzanian">Tanzanian</option>
		<option value="Thai">Thai</option>
		<option value="Togolese">Togolese</option>
		<option value="Tokelauan">Tokelauan</option>
		<option value="Tongan">Tongan</option>
		<option value="Trinidadian or Tobagonian">Trinidadian or Tobagonian</option>
		<option value="Tunisian">Tunisian</option>
		<option value="Turkish">Turkish</option>
		<option value="Turkmen">Turkmen</option>
		<option value="Turks and Caicos Island">Turks and Caicos Island</option>
		<option value="Tuvaluan">Tuvaluan</option>
		<option value="U.S. Virgin Island">U.S. Virgin Island</option>
		<option value="Ugandan">Ugandan</option>
		<option value="Ukrainian">Ukrainian</option>
		<option value="Uruguayan">Uruguayan</option>
		<option value="Uzbekistani, Uzbek">Uzbekistani, Uzbek</option>
		<option value="Vatican">Vatican</option>
		<option value="Venezuelan">Venezuelan</option>
		<option value="Wallis and Futuna, Wallisian or Futunan">Wallis and Futuna, Wallisian or Futunan</option>
		<option value="Yemeni">Yemeni</option>
		<option value="Zambian">Zambian</option>
		<option value="Zimbabwean">Zimbabwean</option>

	</select>
                            </div>



                        </div>



                        <div class="ui stackable three column grid container">
                            
                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Passport No. : </label>
                               <asp:TextBox name="ctl00$MainContent$txtPassportNo" id="MainContent_txtPassportNo" type="passport" class="w3-input w3-border w3-round-large" placeholder="Passport No" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields"><a class="w3-text-red">*</a> Passport Expiry Date : </label>
                                <asp:TextBox name="ctl00$MainContent$txtPassportExpire" id="MainContent_txtPassportExpire" type="PassportExpire" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Passport Expiry Date" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Driver License No. : </label>
                                <asp:TextBox name="ctl00$MainContent$txtLicenseDriver" id="MainContent_txtLicenseDriver" type="Address" class="w3-input w3-border w3-round-large" placeholder="Driver License No." runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-4 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields"><a class="w3-text-red">*</a> Driver License Expiry Date : </label>
                                <asp:TextBox name="ctl00$MainContent$txtLicenseExpire" id="MainContent_txtLicenseExpire" type="LicenseExpire" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Driver License Expiry Date" runat="server"/>
                            </div>

                        </div>

                        <div class="ui stackable four column grid  container">
                            
                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Address : </label>
                                 <asp:TextBox name="ctl00$MainContent$txtAddress" rows="2" cols="20" id="MainContent_txtAddress" type="Address" class="w3-input w3-border w3-round-large" placeholder="Address" TextMode="MultiLine" runat="server"/>
                            </div>


                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields"><a class="w3-text-red">*</a> Province : </label>
                                <asp:TextBox name="ctl00$MainContent$txtCounty" id="MainContent_txtCounty" type="Address" class="w3-input w3-border w3-round-large" placeholder="Province" runat="server"/>
                            </div>


                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Zipcode: </label>
                                <asp:TextBox name="ctl00$MainContent$txtZipcode" id="MainContent_txtZipcode" type="Address" class="w3-input w3-border w3-round-large" placeholder="Zipcode" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left fields"><a class="w3-text-red">*</a> Country : </label>
                                <select name="ctl00$MainContent$ddlCountry" id="MainContent_ddlCountry" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="Malaysia">Malaysia</option>
		<option value="Myanmar">Myanmar</option>
		<option value="Lao">Lao</option>
		<option value="Vietnam">Vietnam</option>
		<option value="Cambodia">Cambodia</option>
		<option value="Singapore">Singapore</option>
		<option value="China">China</option>
		<option value="Indonesia">Indonesia</option>
		<option value="Philippines">Philippines</option>
		<option value="Timor-Leste">Timor-Leste</option>
		<option value="Taiwan, Province of China">Taiwan, Province of China</option>
		<option value="India">India</option>
		<option value="Bangladesh">Bangladesh</option>
		<option value="Australia">Australia</option>
		<option value="Afghanistan">Afghanistan</option>
		<option value="Åland Islands">Åland Islands</option>
		<option value="Albania">Albania</option>
		<option value="Algeria">Algeria</option>
		<option value="American Samoa">American Samoa</option>
		<option value="Andorra">Andorra</option>
		<option value="Angola">Angola</option>
		<option value="Anguilla">Anguilla</option>
		<option value="Antarctica">Antarctica</option>
		<option value="Antigua and Barbuda">Antigua and Barbuda</option>
		<option value="Argentina">Argentina</option>
		<option value="Armenia">Armenia</option>
		<option value="Aruba">Aruba</option>
		<option value="Austria">Austria</option>
		<option value="Azerbaijan">Azerbaijan</option>
		<option value="Bahamas">Bahamas</option>
		<option value="Bahrain">Bahrain</option>
		<option value="Barbados">Barbados</option>
		<option value="Belarus">Belarus</option>
		<option value="Belgium">Belgium</option>
		<option value="Belize">Belize</option>
		<option value="Benin">Benin</option>
		<option value="Bermuda">Bermuda</option>
		<option value="Bhutan">Bhutan</option>
		<option value="Bolivia (Plurinational State of)">Bolivia (Plurinational State of)</option>
		<option value="Bonaire, Sint Eustatius and Saba">Bonaire, Sint Eustatius and Saba</option>
		<option value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
		<option value="Botswana">Botswana</option>
		<option value="Bouvet Island">Bouvet Island</option>
		<option value="Brazil">Brazil</option>
		<option value="British Indian Ocean Territory">British Indian Ocean Territory</option>
		<option value="Brunei Darussalam">Brunei Darussalam</option>
		<option value="Bulgaria">Bulgaria</option>
		<option value="Burkina Faso">Burkina Faso</option>
		<option value="Burundi">Burundi</option>
		<option value="Cabo Verde">Cabo Verde</option>
		<option value="Cameroon">Cameroon</option>
		<option value="Canada">Canada</option>
		<option value="Cayman Islands">Cayman Islands</option>
		<option value="Central African Republic">Central African Republic</option>
		<option value="Chad">Chad</option>
		<option value="Chile">Chile</option>
		<option value="Christmas Island">Christmas Island</option>
		<option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option>
		<option value="Colombia">Colombia</option>
		<option value="Comoros">Comoros</option>
		<option value="Congo (Democratic Republic of the)">Congo (Democratic Republic of the)</option>
		<option value="Congo (Republic of the)">Congo (Republic of the)</option>
		<option value="Cook Islands">Cook Islands</option>
		<option value="Costa Rica">Costa Rica</option>
		<option value="Côte d Ivoire">Côte d Ivoire</option>
		<option value="Croatia">Croatia</option>
		<option value="Cuba">Cuba</option>
		<option value="Curaçao">Curaçao</option>
		<option value="Cyprus">Cyprus</option>
		<option value="Czech Republic">Czech Republic</option>
		<option value="Denmark">Denmark</option>
		<option value="Djibouti">Djibouti</option>
		<option value="Dominica">Dominica</option>
		<option value="Dominican Republic">Dominican Republic</option>
		<option value="Ecuador">Ecuador</option>
		<option value="Egypt">Egypt</option>
		<option value="El Salvador">El Salvador</option>
		<option value="Equatorial Guinea">Equatorial Guinea</option>
		<option value="Eritrea">Eritrea</option>
		<option value="Estonia">Estonia</option>
		<option value="Ethiopia">Ethiopia</option>
		<option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option>
		<option value="Faroe Islands">Faroe Islands</option>
		<option value="Fiji">Fiji</option>
		<option value="Finland">Finland</option>
		<option value="France">France</option>
		<option value="French Guiana">French Guiana</option>
		<option value="French Polynesia">French Polynesia</option>
		<option value="French Southern Territories">French Southern Territories</option>
		<option value="Gabon">Gabon</option>
		<option value="Gambia">Gambia</option>
		<option value="Georgia">Georgia</option>
		<option value="Germany">Germany</option>
		<option value="Ghana">Ghana</option>
		<option value="Gibraltar">Gibraltar</option>
		<option value="Greece">Greece</option>
		<option value="Greenland">Greenland</option>
		<option value="Grenada">Grenada</option>
		<option value="Guadeloupe">Guadeloupe</option>
		<option value="Guam">Guam</option>
		<option value="Guatemala">Guatemala</option>
		<option value="Guernsey">Guernsey</option>
		<option value="Guinea">Guinea</option>
		<option value="Guinea-Bissau">Guinea-Bissau</option>
		<option value="Guyana">Guyana</option>
		<option value="Haiti">Haiti</option>
		<option value="Heard Island and McDonald Islands">Heard Island and McDonald Islands</option>
		<option value="Honduras">Honduras</option>
		<option value="Hong Kong">Hong Kong</option>
		<option value="Hungary">Hungary</option>
		<option value="Iceland">Iceland</option>
		<option value="Iran">Iran</option>
		<option value="Iraq">Iraq</option>
		<option value="Ireland">Ireland</option>
		<option value="Isle of Man">Isle of Man</option>
		<option value="Israel">Israel</option>
		<option value="Italy">Italy</option>
		<option value="Jamaica">Jamaica</option>
		<option value="Japan">Japan</option>
		<option value="Jersey">Jersey</option>
		<option value="Jordan">Jordan</option>
		<option value="Kazakhstan">Kazakhstan</option>
		<option value="Kenya">Kenya</option>
		<option value="Kiribati">Kiribati</option>
		<option value="Korea (Democratic People Republic of)">Korea (Democratic People Republic of)</option>
		<option value="Korea (Republic of)">Korea (Republic of)</option>
		<option value="Kuwait">Kuwait</option>
		<option value="Kyrgyzstan">Kyrgyzstan</option>
		<option value="Latvia">Latvia</option>
		<option value="Lebanon">Lebanon</option>
		<option value="Lesotho">Lesotho</option>
		<option value="Liberia">Liberia</option>
		<option value="Libya">Libya</option>
		<option value="Liechtenstein">Liechtenstein</option>
		<option value="Lithuania">Lithuania</option>
		<option value="Luxembourg">Luxembourg</option>
		<option value="Macao">Macao</option>
		<option value="Macedonia (the former Yugoslav Republic of)">Macedonia (the former Yugoslav Republic of)</option>
		<option value="Madagascar">Madagascar</option>
		<option value="Malawi">Malawi</option>
		<option value="Maldives">Maldives</option>
		<option value="Mali">Mali</option>
		<option value="Malta">Malta</option>
		<option value="Marshall Islands">Marshall Islands</option>
		<option value="Martinique">Martinique</option>
		<option value="Mauritania">Mauritania</option>
		<option value="Mauritius">Mauritius</option>
		<option value="Mayotte">Mayotte</option>
		<option value="Mexico">Mexico</option>
		<option value="Micronesia (Federated States of)">Micronesia (Federated States of)</option>
		<option value="Moldova (Republic of)">Moldova (Republic of)</option>
		<option value="Monaco">Monaco</option>
		<option value="Mongolia">Mongolia</option>
		<option value="Montenegro">Montenegro</option>
		<option value="Montserrat">Montserrat</option>
		<option value="Morocco">Morocco</option>
		<option value="Mozambique">Mozambique</option>
		<option value="Namibia">Namibia</option>
		<option value="Nauru">Nauru</option>
		<option value="Nepal">Nepal</option>
		<option value="Netherlands">Netherlands</option>
		<option value="New Caledonia">New Caledonia</option>
		<option value="New Zealand">New Zealand</option>
		<option value="Nicaragua">Nicaragua</option>
		<option value="Niger">Niger</option>
		<option value="Nigeria">Nigeria</option>
		<option value="Niue">Niue</option>
		<option value="Norfolk Island">Norfolk Island</option>
		<option value="Northern Mariana Islands">Northern Mariana Islands</option>
		<option value="Norway">Norway</option>
		<option value="Oman">Oman</option>
		<option value="Pakistan">Pakistan</option>
		<option value="Palau">Palau</option>
		<option value="Palestine, State of">Palestine, State of</option>
		<option value="Panama">Panama</option>
		<option value="Papua New Guinea">Papua New Guinea</option>
		<option value="Paraguay">Paraguay</option>
		<option value="Peru">Peru</option>
		<option value="Pitcairn">Pitcairn</option>
		<option value="Poland">Poland</option>
		<option value="Portugal">Portugal</option>
		<option value="Puerto Rico">Puerto Rico</option>
		<option value="Qatar">Qatar</option>
		<option value="Réunion">Réunion</option>
		<option value="Romania">Romania</option>
		<option value="Russian Federation">Russian Federation</option>
		<option value="Rwanda">Rwanda</option>
		<option value="Saint Barthélemy">Saint Barthélemy</option>
		<option value="Saint Helena, Ascension and Tristan da Cunha">Saint Helena, Ascension and Tristan da Cunha</option>
		<option value="Saint Kitts and Nevis">Saint Kitts and Nevis</option>
		<option value="Saint Lucia">Saint Lucia</option>
		<option value="Saint Martin (French part)">Saint Martin (French part)</option>
		<option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon</option>
		<option value="Saint Vincent and the Grenadines">Saint Vincent and the Grenadines</option>
		<option value="Samoa">Samoa</option>
		<option value="San Marino">San Marino</option>
		<option value="Sao Tome and Principe">Sao Tome and Principe</option>
		<option value="Saudi Arabia">Saudi Arabia</option>
		<option value="Senegal">Senegal</option>
		<option value="Serbia">Serbia</option>
		<option value="Seychelles">Seychelles</option>
		<option value="Sierra Leone">Sierra Leone</option>
		<option value="Sint Maarten (Dutch part)">Sint Maarten (Dutch part)</option>
		<option value="Slovakia">Slovakia</option>
		<option value="Slovenia">Slovenia</option>
		<option value="Solomon Islands">Solomon Islands</option>
		<option value="Somalia">Somalia</option>
		<option value="South Africa">South Africa</option>
		<option value="South Georgia and the South Sandwich Islands">South Georgia and the South Sandwich Islands</option>
		<option value="South Sudan">South Sudan</option>
		<option value="Spain">Spain</option>
		<option value="Sri Lanka">Sri Lanka</option>
		<option value="Sudan">Sudan</option>
		<option value="Suriname">Suriname</option>
		<option value="Svalbard and Jan Mayen">Svalbard and Jan Mayen</option>
		<option value="Swaziland">Swaziland</option>
		<option value="Sweden">Sweden</option>
		<option value="Switzerland">Switzerland</option>
		<option value="Syrian Arab Republic">Syrian Arab Republic</option>
		<option value="Tajikistan">Tajikistan</option>
		<option value="Tanzania, United Republic of">Tanzania, United Republic of</option>
		<option value="Thailand">Thailand</option>
		<option value="Togo">Togo</option>
		<option value="Tokelau">Tokelau</option>
		<option value="Tonga">Tonga</option>
		<option value="Trinidad and Tobago">Trinidad and Tobago</option>
		<option value="Tunisia">Tunisia</option>
		<option value="Turkey">Turkey</option>
		<option value="Turkmenistan">Turkmenistan</option>
		<option value="Turks and Caicos Islands">Turks and Caicos Islands</option>
		<option value="Tuvalu">Tuvalu</option>
		<option value="Uganda">Uganda</option>
		<option value="Ukraine">Ukraine</option>
		<option value="United Arab Emirates">United Arab Emirates</option>
		<option value="United Kingdom">United Kingdom</option>
		<option value="United States Minor Outlying Islands">United States Minor Outlying Islands</option>
		<option value="United States of America">United States of America</option>
		<option value="Uruguay">Uruguay</option>
		<option value="Uzbekistan">Uzbekistan</option>
		<option value="Vanuatu">Vanuatu</option>
		<option value="Vatican City State">Vatican City State</option>
		<option value="Venezuela (Bolivarian Republic of)">Venezuela (Bolivarian Republic of)</option>
		<option value="Virgin Islands (British)">Virgin Islands (British)</option>
		<option value="Virgin Islands (U.S.)">Virgin Islands (U.S.)</option>
		<option value="Wallis and Futuna">Wallis and Futuna</option>
		<option value="Western Sahara">Western Sahara</option>
		<option value="Yemen">Yemen</option>
		<option value="Zambia">Zambia</option>
		<option value="Zimbabwe">Zimbabwe</option>

	</select>
                            </div>

                        </div>

                        <div class="ui stackable four column grid container">
                            

                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Telephone : </label>
                                <asp:TextBox name="ctl00$MainContent$txtTel" id="MainContent_txtTel" type="Address" class="w3-input w3-border w3-round-large" placeholder="Telephone" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left"><a class="w3-text-red">*</a> Email : </label>
                                <asp:TextBox name="ctl00$MainContent$txtEmail" id="MainContent_txtEmail" type="Address" class="w3-input w3-border w3-round-large" placeholder="Email" runat="server"/>
                            </div>

                        </div>


                        <br>
                        &nbsp; 
   
                        <div class="ui stackable two column grid container ">

   </div>
                        <br>
                        <br>
                        <script language="javascript" type="text/javascript">
                            function setFocusPage(_divName) {
                                var PageAutoSec = 500;
                                setTimeout(function () {
                                    document.location.href = '#' + _divName;
                                }, PageAutoSec);
                            }
                        </script>

                        <div class="row">
                            <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 6%; font-size: x-large;">Reserve Driver 1
                            </b>

                        </div>
                        <br>
                        <br>

                        <div class="ui stackable four column grid container">
                            
                            <div class="w3-left fields col-md-1 pb-3">
                                <div id="MainContent_Updateprename2" style="font-family: 'Kanit', sans-serif; font-size: small;">
		

                                        <label for="Prename" class="w3-left">Title : </label>
                                        <select name="ctl00$MainContent$ddlPrename2" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlPrename2\',\'\')', 0)" id="MainContent_ddlPrename2" class="w3-input w3-border w3-round-large">
			<option selected="selected" value="Mr.">Mr.</option>
			<option value="Ms.">Ms.</option>
			<option value="Miss.">Miss.</option>
			<option value="Mrs.">Mrs.</option>
			<option value="Other">Other</option>

		</select>
                                        

                                    
	</div>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left">Name : </label>
                                <asp:TextBox name="ctl00$MainContent$txtName2" id="MainContent_txtName2" type="Name" class="w3-input w3-border w3-round-large" placeholder="Name" runat="server"/>

                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left fields">Last Name : </label>
                                <asp:TextBox name="ctl00$MainContent$txtSurname2" id="MainContent_txtSurname2" type="Surname" class="w3-input w3-border w3-round-large" placeholder="Last Name" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left">Gender : </label>
                                <select name="ctl00$MainContent$ddlGender2" id="MainContent_ddlGender2" class="w3-input w3-border w3-round-large">
		<option value="Male">Male</option>
		<option value="Female">Female</option>

	</select>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left fields">Nationality : </label>
                                <select name="ctl00$MainContent$ddlNational2" id="MainContent_ddlNational2" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="Malaysian">Malaysian</option>
		<option value="Burmese">Burmese</option>
		<option value="Lao">Lao</option>
		<option value="Vietnamese">Vietnamese</option>
		<option value="Cambodian">Cambodian</option>
		<option value="Singaporean">Singaporean</option>
		<option value="Chinese">Chinese</option>
		<option value="Indonesian">Indonesian</option>
		<option value="Philippine, Filipino">Philippine, Filipino</option>
		<option value="Timorese">Timorese</option>
		<option value="Chinese, Taiwanese">Chinese, Taiwanese</option>
		<option value="Indian">Indian</option>
		<option value="Bangladeshi">Bangladeshi</option>
		<option value="Australian">Australian</option>
		<option value="Afghan">Afghan</option>
		<option value="Åland Island">Åland Island</option>
		<option value="Albanian">Albanian</option>
		<option value="Algerian">Algerian</option>
		<option value="American">American</option>
		<option value="American Samoan">American Samoan</option>
		<option value="Andorran">Andorran</option>
		<option value="Angolan">Angolan</option>
		<option value="Anguillan">Anguillan</option>
		<option value="Antarctic">Antarctic</option>
		<option value="Antiguan or Barbudan">Antiguan or Barbudan</option>
		<option value="Argentine">Argentine</option>
		<option value="Armenian">Armenian</option>
		<option value="Aruban">Aruban</option>
		<option value="Austrian">Austrian</option>
		<option value="Azerbaijani, Azeri">Azerbaijani, Azeri</option>
		<option value="Bahamian">Bahamian</option>
		<option value="Bahraini">Bahraini</option>
		<option value="Barbadian">Barbadian</option>
		<option value="Barthélemois">Barthélemois</option>
		<option value="Basotho">Basotho</option>
		<option value="Belarusian">Belarusian</option>
		<option value="Belgian">Belgian</option>
		<option value="Belizean">Belizean</option>
		<option value="Beninese, Beninois">Beninese, Beninois</option>
		<option value="Bermudian, Bermudan">Bermudian, Bermudan</option>
		<option value="Bhutanese">Bhutanese</option>
		<option value="BIOT">BIOT</option>
		<option value="Bissau-Guinean">Bissau-Guinean</option>
		<option value="Bolivian">Bolivian</option>
		<option value="Bonaire">Bonaire</option>
		<option value="Bosnian or Herzegovinian">Bosnian or Herzegovinian</option>
		<option value="Bouvet Island">Bouvet Island</option>
		<option value="Brazilian">Brazilian</option>
		<option value="British Virgin Island">British Virgin Island</option>
		<option value="British, UK">British, UK</option>
		<option value="Bruneian">Bruneian</option>
		<option value="Bulgarian">Bulgarian</option>
		<option value="Burkinabé">Burkinabé</option>
		<option value="Burundian">Burundian</option>
		<option value="Cabo Verdean">Cabo Verdean</option>
		<option value="Cameroonian">Cameroonian</option>
		<option value="Canadian">Canadian</option>
		<option value="Caymanian">Caymanian</option>
		<option value="Central African">Central African</option>
		<option value="Chadian">Chadian</option>
		<option value="Channel Island">Channel Island</option>
		<option value="Chilean">Chilean</option>
		<option value="Christmas Island">Christmas Island</option>
		<option value="Cocos Island">Cocos Island</option>
		<option value="Colombian">Colombian</option>
		<option value="Comoran, Comorian">Comoran, Comorian</option>
		<option value="Congolese">Congolese</option>
		<option value="Cook Island">Cook Island</option>
		<option value="Costa Rican">Costa Rican</option>
		<option value="Croatian">Croatian</option>
		<option value="Cuban">Cuban</option>
		<option value="Curaçaoan">Curaçaoan</option>
		<option value="Cypriot">Cypriot</option>
		<option value="Czech">Czech</option>
		<option value="Danish">Danish</option>
		<option value="Djiboutian">Djiboutian</option>
		<option value="Dominican">Dominican</option>
		<option value="Dutch, Netherlandic">Dutch, Netherlandic</option>
		<option value="Ecuadorian">Ecuadorian</option>
		<option value="Egyptian">Egyptian</option>
		<option value="Emirati, Emirian, Emiri">Emirati, Emirian, Emiri</option>
		<option value="Equatorial Guinean, Equatoguinean">Equatorial Guinean, Equatoguinean</option>
		<option value="Eritrean">Eritrean</option>
		<option value="Estonian">Estonian</option>
		<option value="Ethiopian">Ethiopian</option>
		<option value="Falkland Island">Falkland Island</option>
		<option value="Faroese">Faroese</option>
		<option value="Fijian">Fijian</option>
		<option value="Finnish">Finnish</option>
		<option value="French">French</option>
		<option value="French Guianese">French Guianese</option>
		<option value="French Polynesian">French Polynesian</option>
		<option value="French Southern Territories">French Southern Territories</option>
		<option value="Gabonese">Gabonese</option>
		<option value="Gambian">Gambian</option>
		<option value="Georgian">Georgian</option>
		<option value="German">German</option>
		<option value="Ghanaian">Ghanaian</option>
		<option value="Gibraltar">Gibraltar</option>
		<option value="Greek, Hellenic">Greek, Hellenic</option>
		<option value="Greenlandic">Greenlandic</option>
		<option value="Grenadian">Grenadian</option>
		<option value="Guadeloupe">Guadeloupe</option>
		<option value="Guamanian, Guambat">Guamanian, Guambat</option>
		<option value="Guatemalan">Guatemalan</option>
		<option value="Guinean">Guinean</option>
		<option value="Guyanese">Guyanese</option>
		<option value="Haitian">Haitian</option>
		<option value="Heard Island or McDonald Islands">Heard Island or McDonald Islands</option>
		<option value="Honduran">Honduran</option>
		<option value="Hong Kong, Hong Kongese">Hong Kong, Hong Kongese</option>
		<option value="Hungarian, Magyar">Hungarian, Magyar</option>
		<option value="I-Kiribati">I-Kiribati</option>
		<option value="Icelandic">Icelandic</option>
		<option value="Iranian, Persian">Iranian, Persian</option>
		<option value="Iraqi">Iraqi</option>
		<option value="Irish">Irish</option>
		<option value="Israeli">Israeli</option>
		<option value="Italian">Italian</option>
		<option value="Ivorian">Ivorian</option>
		<option value="Jamaican">Jamaican</option>
		<option value="Japanese">Japanese</option>
		<option value="Jordanian">Jordanian</option>
		<option value="Kazakhstani, Kazakh">Kazakhstani, Kazakh</option>
		<option value="Kenyan">Kenyan</option>
		<option value="Kittitian or Nevisian">Kittitian or Nevisian</option>
		<option value="Kuwaiti">Kuwaiti</option>
		<option value="Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz">Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz</option>
		<option value="Latvian">Latvian</option>
		<option value="Lebanese">Lebanese</option>
		<option value="Liberian">Liberian</option>
		<option value="Libyan">Libyan</option>
		<option value="Liechtenstein">Liechtenstein</option>
		<option value="Lithuanian">Lithuanian</option>
		<option value="Luxembourg, Luxembourgish">Luxembourg, Luxembourgish</option>
		<option value="Macanese, Chinese">Macanese, Chinese</option>
		<option value="Macedonian">Macedonian</option>
		<option value="Mahoran">Mahoran</option>
		<option value="Malagasy">Malagasy</option>
		<option value="Malawian">Malawian</option>
		<option value="Maldivian">Maldivian</option>
		<option value="Malian, Malinese">Malian, Malinese</option>
		<option value="Maltese">Maltese</option>
		<option value="Manx">Manx</option>
		<option value="Marshallese">Marshallese</option>
		<option value="Martiniquais, Martinican">Martiniquais, Martinican</option>
		<option value="Mauritanian">Mauritanian</option>
		<option value="Mauritian">Mauritian</option>
		<option value="Mexican">Mexican</option>
		<option value="Micronesian">Micronesian</option>
		<option value="Moldovan">Moldovan</option>
		<option value="Monégasque, Monacan">Monégasque, Monacan</option>
		<option value="Mongolian">Mongolian</option>
		<option value="Montenegrin">Montenegrin</option>
		<option value="Montserratian">Montserratian</option>
		<option value="Moroccan">Moroccan</option>
		<option value="Motswana, Botswanan">Motswana, Botswanan</option>
		<option value="Mozambican">Mozambican</option>
		<option value="Namibian">Namibian</option>
		<option value="Nauruan">Nauruan</option>
		<option value="Nepali, Nepalese">Nepali, Nepalese</option>
		<option value="New Caledonian">New Caledonian</option>
		<option value="New Zealand, NZ">New Zealand, NZ</option>
		<option value="Ni-Vanuatu, Vanuatuan">Ni-Vanuatu, Vanuatuan</option>
		<option value="Nicaraguan">Nicaraguan</option>
		<option value="Nigerian">Nigerian</option>
		<option value="Nigerien">Nigerien</option>
		<option value="Niuean">Niuean</option>
		<option value="Norfolk Island">Norfolk Island</option>
		<option value="North Korean">North Korean</option>
		<option value="Northern Marianan">Northern Marianan</option>
		<option value="Norwegian">Norwegian</option>
		<option value="Omani">Omani</option>
		<option value="Pakistani">Pakistani</option>
		<option value="Palauan">Palauan</option>
		<option value="Palestinian">Palestinian</option>
		<option value="Panamanian">Panamanian</option>
		<option value="Papua New Guinean, Papuan">Papua New Guinean, Papuan</option>
		<option value="Paraguayan">Paraguayan</option>
		<option value="Peruvian">Peruvian</option>
		<option value="Pitcairn Island">Pitcairn Island</option>
		<option value="Polish">Polish</option>
		<option value="Portuguese">Portuguese</option>
		<option value="Puerto Rican">Puerto Rican</option>
		<option value="Qatari">Qatari</option>
		<option value="Réunionese, Réunionnais">Réunionese, Réunionnais</option>
		<option value="Romanian">Romanian</option>
		<option value="Russian">Russian</option>
		<option value="Rwandan">Rwandan</option>
		<option value="Sahrawi, Sahrawian, Sahraouian">Sahrawi, Sahrawian, Sahraouian</option>
		<option value="Saint-Martinoise">Saint-Martinoise</option>
		<option value="Saint-Pierrais or Miquelonnais">Saint-Pierrais or Miquelonnais</option>
		<option value="Saint Helenian">Saint Helenian</option>
		<option value="Saint Lucian">Saint Lucian</option>
		<option value="Saint Vincentian, Vincentian">Saint Vincentian, Vincentian</option>
		<option value="Salvadoran">Salvadoran</option>
		<option value="Sammarinese">Sammarinese</option>
		<option value="Samoan">Samoan</option>
		<option value="São Toméan">São Toméan</option>
		<option value="Saudi, Saudi Arabian">Saudi, Saudi Arabian</option>
		<option value="Senegalese">Senegalese</option>
		<option value="Serbian">Serbian</option>
		<option value="Seychellois">Seychellois</option>
		<option value="Sierra Leonean">Sierra Leonean</option>
		<option value="Sint Maarten">Sint Maarten</option>
		<option value="Slovak">Slovak</option>
		<option value="Slovenian, Slovene">Slovenian, Slovene</option>
		<option value="Solomon Island">Solomon Island</option>
		<option value="Somali, Somalian">Somali, Somalian</option>
		<option value="South African">South African</option>
		<option value="South Georgia or South Sandwich Islands">South Georgia or South Sandwich Islands</option>
		<option value="South Korean">South Korean</option>
		<option value="South Sudanese">South Sudanese</option>
		<option value="Spanish">Spanish</option>
		<option value="Sri Lankan">Sri Lankan</option>
		<option value="Sudanese">Sudanese</option>
		<option value="Surinamese">Surinamese</option>
		<option value="Svalbard">Svalbard</option>
		<option value="Swazi">Swazi</option>
		<option value="Swedish">Swedish</option>
		<option value="Swiss">Swiss</option>
		<option value="Syrian">Syrian</option>
		<option value="Tajikistani">Tajikistani</option>
		<option value="Tanzanian">Tanzanian</option>
		<option value="Thai">Thai</option>
		<option value="Togolese">Togolese</option>
		<option value="Tokelauan">Tokelauan</option>
		<option value="Tongan">Tongan</option>
		<option value="Trinidadian or Tobagonian">Trinidadian or Tobagonian</option>
		<option value="Tunisian">Tunisian</option>
		<option value="Turkish">Turkish</option>
		<option value="Turkmen">Turkmen</option>
		<option value="Turks and Caicos Island">Turks and Caicos Island</option>
		<option value="Tuvaluan">Tuvaluan</option>
		<option value="U.S. Virgin Island">U.S. Virgin Island</option>
		<option value="Ugandan">Ugandan</option>
		<option value="Ukrainian">Ukrainian</option>
		<option value="Uruguayan">Uruguayan</option>
		<option value="Uzbekistani, Uzbek">Uzbekistani, Uzbek</option>
		<option value="Vatican">Vatican</option>
		<option value="Venezuelan">Venezuelan</option>
		<option value="Wallis and Futuna, Wallisian or Futunan">Wallis and Futuna, Wallisian or Futunan</option>
		<option value="Yemeni">Yemeni</option>
		<option value="Zambian">Zambian</option>
		<option value="Zimbabwean">Zimbabwean</option>

	</select>
                            </div>


                        </div>

                        <div class="ui stackable three column grid container">
                            

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields">Passport No : </label>
                                 <asp:TextBox name="ctl00$MainContent$txtPassportNo2" id="MainContent_txtPassportNo2" type="Address" class="w3-input w3-border w3-round-large" placeholder="Passport No" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields">Passport Expire : </label>
                                <asp:TextBox name="ctl00$MainContent$txtPassport_exp2" id="MainContent_txtPassport_exp2" autocomplete="off" type="LicenseExpire" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Passport Expire" runat="server"/>
                            </div>
                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields">Driver License No. : </label>
                                <asp:TextBox name="ctl00$MainContent$txtLicense2" id="MainContent_txtLicense2" type="Address" class="w3-input w3-border w3-round-large" placeholder="Driver License No." runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                                <asp:TextBox name="ctl00$MainContent$txtLicenseExpire2" type="text" id="MainContent_txtLicenseExpire2" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Driver License Expiry Date" runat="server"/>
                            </div>


                        </div>

                        <div class="ui stackable four column grid container">
                            
                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields">Address : </label>
                                <asp:TextBox name="ctl00$MainContent$txtAddress2" rows="2" cols="20" id="MainContent_txtAddress2" type="Address" class="w3-input w3-border w3-round-large" placeholder="Address" TextMode="MultiLine" runat="server"/>
                            </div>



                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left fields">Country : </label>
                                <select name="ctl00$MainContent$ddlCountry2" id="MainContent_ddlCountry2" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="Malaysia">Malaysia</option>
		<option value="Myanmar">Myanmar</option>
		<option value="Lao">Lao</option>
		<option value="Vietnam">Vietnam</option>
		<option value="Cambodia">Cambodia</option>
		<option value="Singapore">Singapore</option>
		<option value="China">China</option>
		<option value="Indonesia">Indonesia</option>
		<option value="Philippines">Philippines</option>
		<option value="Timor-Leste">Timor-Leste</option>
		<option value="Taiwan, Province of China">Taiwan, Province of China</option>
		<option value="India">India</option>
		<option value="Bangladesh">Bangladesh</option>
		<option value="Australia">Australia</option>
		<option value="Afghanistan">Afghanistan</option>
		<option value="Åland Islands">Åland Islands</option>
		<option value="Albania">Albania</option>
		<option value="Algeria">Algeria</option>
		<option value="American Samoa">American Samoa</option>
		<option value="Andorra">Andorra</option>
		<option value="Angola">Angola</option>
		<option value="Anguilla">Anguilla</option>
		<option value="Antarctica">Antarctica</option>
		<option value="Antigua and Barbuda">Antigua and Barbuda</option>
		<option value="Argentina">Argentina</option>
		<option value="Armenia">Armenia</option>
		<option value="Aruba">Aruba</option>
		<option value="Austria">Austria</option>
		<option value="Azerbaijan">Azerbaijan</option>
		<option value="Bahamas">Bahamas</option>
		<option value="Bahrain">Bahrain</option>
		<option value="Barbados">Barbados</option>
		<option value="Belarus">Belarus</option>
		<option value="Belgium">Belgium</option>
		<option value="Belize">Belize</option>
		<option value="Benin">Benin</option>
		<option value="Bermuda">Bermuda</option>
		<option value="Bhutan">Bhutan</option>
		<option value="Bolivia (Plurinational State of)">Bolivia (Plurinational State of)</option>
		<option value="Bonaire, Sint Eustatius and Saba">Bonaire, Sint Eustatius and Saba</option>
		<option value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
		<option value="Botswana">Botswana</option>
		<option value="Bouvet Island">Bouvet Island</option>
		<option value="Brazil">Brazil</option>
		<option value="British Indian Ocean Territory">British Indian Ocean Territory</option>
		<option value="Brunei Darussalam">Brunei Darussalam</option>
		<option value="Bulgaria">Bulgaria</option>
		<option value="Burkina Faso">Burkina Faso</option>
		<option value="Burundi">Burundi</option>
		<option value="Cabo Verde">Cabo Verde</option>
		<option value="Cameroon">Cameroon</option>
		<option value="Canada">Canada</option>
		<option value="Cayman Islands">Cayman Islands</option>
		<option value="Central African Republic">Central African Republic</option>
		<option value="Chad">Chad</option>
		<option value="Chile">Chile</option>
		<option value="Christmas Island">Christmas Island</option>
		<option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option>
		<option value="Colombia">Colombia</option>
		<option value="Comoros">Comoros</option>
		<option value="Congo (Democratic Republic of the)">Congo (Democratic Republic of the)</option>
		<option value="Congo (Republic of the)">Congo (Republic of the)</option>
		<option value="Cook Islands">Cook Islands</option>
		<option value="Costa Rica">Costa Rica</option>
		<option value="Côte d Ivoire">Côte d Ivoire</option>
		<option value="Croatia">Croatia</option>
		<option value="Cuba">Cuba</option>
		<option value="Curaçao">Curaçao</option>
		<option value="Cyprus">Cyprus</option>
		<option value="Czech Republic">Czech Republic</option>
		<option value="Denmark">Denmark</option>
		<option value="Djibouti">Djibouti</option>
		<option value="Dominica">Dominica</option>
		<option value="Dominican Republic">Dominican Republic</option>
		<option value="Ecuador">Ecuador</option>
		<option value="Egypt">Egypt</option>
		<option value="El Salvador">El Salvador</option>
		<option value="Equatorial Guinea">Equatorial Guinea</option>
		<option value="Eritrea">Eritrea</option>
		<option value="Estonia">Estonia</option>
		<option value="Ethiopia">Ethiopia</option>
		<option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option>
		<option value="Faroe Islands">Faroe Islands</option>
		<option value="Fiji">Fiji</option>
		<option value="Finland">Finland</option>
		<option value="France">France</option>
		<option value="French Guiana">French Guiana</option>
		<option value="French Polynesia">French Polynesia</option>
		<option value="French Southern Territories">French Southern Territories</option>
		<option value="Gabon">Gabon</option>
		<option value="Gambia">Gambia</option>
		<option value="Georgia">Georgia</option>
		<option value="Germany">Germany</option>
		<option value="Ghana">Ghana</option>
		<option value="Gibraltar">Gibraltar</option>
		<option value="Greece">Greece</option>
		<option value="Greenland">Greenland</option>
		<option value="Grenada">Grenada</option>
		<option value="Guadeloupe">Guadeloupe</option>
		<option value="Guam">Guam</option>
		<option value="Guatemala">Guatemala</option>
		<option value="Guernsey">Guernsey</option>
		<option value="Guinea">Guinea</option>
		<option value="Guinea-Bissau">Guinea-Bissau</option>
		<option value="Guyana">Guyana</option>
		<option value="Haiti">Haiti</option>
		<option value="Heard Island and McDonald Islands">Heard Island and McDonald Islands</option>
		<option value="Honduras">Honduras</option>
		<option value="Hong Kong">Hong Kong</option>
		<option value="Hungary">Hungary</option>
		<option value="Iceland">Iceland</option>
		<option value="Iran">Iran</option>
		<option value="Iraq">Iraq</option>
		<option value="Ireland">Ireland</option>
		<option value="Isle of Man">Isle of Man</option>
		<option value="Israel">Israel</option>
		<option value="Italy">Italy</option>
		<option value="Jamaica">Jamaica</option>
		<option value="Japan">Japan</option>
		<option value="Jersey">Jersey</option>
		<option value="Jordan">Jordan</option>
		<option value="Kazakhstan">Kazakhstan</option>
		<option value="Kenya">Kenya</option>
		<option value="Kiribati">Kiribati</option>
		<option value="Korea (Democratic People Republic of)">Korea (Democratic People Republic of)</option>
		<option value="Korea (Republic of)">Korea (Republic of)</option>
		<option value="Kuwait">Kuwait</option>
		<option value="Kyrgyzstan">Kyrgyzstan</option>
		<option value="Latvia">Latvia</option>
		<option value="Lebanon">Lebanon</option>
		<option value="Lesotho">Lesotho</option>
		<option value="Liberia">Liberia</option>
		<option value="Libya">Libya</option>
		<option value="Liechtenstein">Liechtenstein</option>
		<option value="Lithuania">Lithuania</option>
		<option value="Luxembourg">Luxembourg</option>
		<option value="Macao">Macao</option>
		<option value="Macedonia (the former Yugoslav Republic of)">Macedonia (the former Yugoslav Republic of)</option>
		<option value="Madagascar">Madagascar</option>
		<option value="Malawi">Malawi</option>
		<option value="Maldives">Maldives</option>
		<option value="Mali">Mali</option>
		<option value="Malta">Malta</option>
		<option value="Marshall Islands">Marshall Islands</option>
		<option value="Martinique">Martinique</option>
		<option value="Mauritania">Mauritania</option>
		<option value="Mauritius">Mauritius</option>
		<option value="Mayotte">Mayotte</option>
		<option value="Mexico">Mexico</option>
		<option value="Micronesia (Federated States of)">Micronesia (Federated States of)</option>
		<option value="Moldova (Republic of)">Moldova (Republic of)</option>
		<option value="Monaco">Monaco</option>
		<option value="Mongolia">Mongolia</option>
		<option value="Montenegro">Montenegro</option>
		<option value="Montserrat">Montserrat</option>
		<option value="Morocco">Morocco</option>
		<option value="Mozambique">Mozambique</option>
		<option value="Namibia">Namibia</option>
		<option value="Nauru">Nauru</option>
		<option value="Nepal">Nepal</option>
		<option value="Netherlands">Netherlands</option>
		<option value="New Caledonia">New Caledonia</option>
		<option value="New Zealand">New Zealand</option>
		<option value="Nicaragua">Nicaragua</option>
		<option value="Niger">Niger</option>
		<option value="Nigeria">Nigeria</option>
		<option value="Niue">Niue</option>
		<option value="Norfolk Island">Norfolk Island</option>
		<option value="Northern Mariana Islands">Northern Mariana Islands</option>
		<option value="Norway">Norway</option>
		<option value="Oman">Oman</option>
		<option value="Pakistan">Pakistan</option>
		<option value="Palau">Palau</option>
		<option value="Palestine, State of">Palestine, State of</option>
		<option value="Panama">Panama</option>
		<option value="Papua New Guinea">Papua New Guinea</option>
		<option value="Paraguay">Paraguay</option>
		<option value="Peru">Peru</option>
		<option value="Pitcairn">Pitcairn</option>
		<option value="Poland">Poland</option>
		<option value="Portugal">Portugal</option>
		<option value="Puerto Rico">Puerto Rico</option>
		<option value="Qatar">Qatar</option>
		<option value="Réunion">Réunion</option>
		<option value="Romania">Romania</option>
		<option value="Russian Federation">Russian Federation</option>
		<option value="Rwanda">Rwanda</option>
		<option value="Saint Barthélemy">Saint Barthélemy</option>
		<option value="Saint Helena, Ascension and Tristan da Cunha">Saint Helena, Ascension and Tristan da Cunha</option>
		<option value="Saint Kitts and Nevis">Saint Kitts and Nevis</option>
		<option value="Saint Lucia">Saint Lucia</option>
		<option value="Saint Martin (French part)">Saint Martin (French part)</option>
		<option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon</option>
		<option value="Saint Vincent and the Grenadines">Saint Vincent and the Grenadines</option>
		<option value="Samoa">Samoa</option>
		<option value="San Marino">San Marino</option>
		<option value="Sao Tome and Principe">Sao Tome and Principe</option>
		<option value="Saudi Arabia">Saudi Arabia</option>
		<option value="Senegal">Senegal</option>
		<option value="Serbia">Serbia</option>
		<option value="Seychelles">Seychelles</option>
		<option value="Sierra Leone">Sierra Leone</option>
		<option value="Sint Maarten (Dutch part)">Sint Maarten (Dutch part)</option>
		<option value="Slovakia">Slovakia</option>
		<option value="Slovenia">Slovenia</option>
		<option value="Solomon Islands">Solomon Islands</option>
		<option value="Somalia">Somalia</option>
		<option value="South Africa">South Africa</option>
		<option value="South Georgia and the South Sandwich Islands">South Georgia and the South Sandwich Islands</option>
		<option value="South Sudan">South Sudan</option>
		<option value="Spain">Spain</option>
		<option value="Sri Lanka">Sri Lanka</option>
		<option value="Sudan">Sudan</option>
		<option value="Suriname">Suriname</option>
		<option value="Svalbard and Jan Mayen">Svalbard and Jan Mayen</option>
		<option value="Swaziland">Swaziland</option>
		<option value="Sweden">Sweden</option>
		<option value="Switzerland">Switzerland</option>
		<option value="Syrian Arab Republic">Syrian Arab Republic</option>
		<option value="Tajikistan">Tajikistan</option>
		<option value="Tanzania, United Republic of">Tanzania, United Republic of</option>
		<option value="Thailand">Thailand</option>
		<option value="Togo">Togo</option>
		<option value="Tokelau">Tokelau</option>
		<option value="Tonga">Tonga</option>
		<option value="Trinidad and Tobago">Trinidad and Tobago</option>
		<option value="Tunisia">Tunisia</option>
		<option value="Turkey">Turkey</option>
		<option value="Turkmenistan">Turkmenistan</option>
		<option value="Turks and Caicos Islands">Turks and Caicos Islands</option>
		<option value="Tuvalu">Tuvalu</option>
		<option value="Uganda">Uganda</option>
		<option value="Ukraine">Ukraine</option>
		<option value="United Arab Emirates">United Arab Emirates</option>
		<option value="United Kingdom">United Kingdom</option>
		<option value="United States Minor Outlying Islands">United States Minor Outlying Islands</option>
		<option value="United States of America">United States of America</option>
		<option value="Uruguay">Uruguay</option>
		<option value="Uzbekistan">Uzbekistan</option>
		<option value="Vanuatu">Vanuatu</option>
		<option value="Vatican City State">Vatican City State</option>
		<option value="Venezuela (Bolivarian Republic of)">Venezuela (Bolivarian Republic of)</option>
		<option value="Virgin Islands (British)">Virgin Islands (British)</option>
		<option value="Virgin Islands (U.S.)">Virgin Islands (U.S.)</option>
		<option value="Wallis and Futuna">Wallis and Futuna</option>
		<option value="Western Sahara">Western Sahara</option>
		<option value="Yemen">Yemen</option>
		<option value="Zambia">Zambia</option>
		<option value="Zimbabwe">Zimbabwe</option>

	</select>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left">Zipcode: </label>
                                <asp:TextBox name="ctl00$MainContent$txtZipcode2" id="MainContent_txtZipcode2" type="Address" class="w3-input w3-border w3-round-large" placeholder="Zipcode" runat="server"/>
                            </div>


                        </div>

                        <div class="ui stackable three column grid container" id="divReserveDriver1">
                            
                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left">Telephone : </label>
                                <asp:TextBox name="ctl00$MainContent$txtTel2" id="MainContent_txtTel2" type="Address" class="w3-input w3-border w3-round-large" placeholder="Telephone" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left">Email : </label>
                               <asp:TextBox name="ctl00$MainContent$txtEmail2" id="MainContent_txtEmail2" type="Address" class="w3-input w3-border w3-round-large" placeholder="Email" runat="server"/>
                            </div>

                        </div>

                        <br>
                        &nbsp; 
                        <div class="ui stackable four column grid container">

       
   </div>
                        <br>
                        <br>
                        <div class="row">
                            <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 6%; font-size: x-large;">Reserve Driver 2
                            </b>
                        </div>
                        <br>
                        <br>

                        <div class="ui stackable four column grid container">
                            
                            <div class="w3-left fields col-md-1 pb-3">
                                <div id="MainContent_Updateprename3" style="font-family: 'Kanit', sans-serif; font-size: small;">
		

                                        <label for="Prename" class="w3-left">Title : </label>
                                        <select name="ctl00$MainContent$ddlPrename3" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlPrename3\',\'\')', 0)" id="MainContent_ddlPrename3" class="w3-input w3-border w3-round-large">
			<option selected="selected" value="Mr.">Mr.</option>
			<option value="Ms.">Ms.</option>
			<option value="Miss.">Miss.</option>
			<option value="Mrs.">Mrs.</option>
			<option value="Other">Other</option>

		</select>
                                        

                                    
	</div>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left">Name : </label>
                               <asp:TextBox name="ctl00$MainContent$txtName3" id="MainContent_txtName3" type="Name" class="w3-input w3-border w3-round-large" placeholder="Name" runat="server"/>

                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label class="w3-left fields">Last Name : </label>
                                <asp:TextBox name="ctl00$MainContent$txtSurname3" id="MainContent_txtSurname3" type="Surname" class="w3-input w3-border w3-round-large" placeholder="Last Name" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left">Gender : </label>
                                <select name="ctl00$MainContent$ddlGender3" id="MainContent_ddlGender3" class="w3-input w3-border w3-round-large">
		<option value="Male">Male</option>
		<option value="Female">Female</option>

	</select>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left fields">Nationality : </label>
                                <select name="ctl00$MainContent$ddlNational3" id="MainContent_ddlNational3" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="Malaysian">Malaysian</option>
		<option value="Burmese">Burmese</option>
		<option value="Lao">Lao</option>
		<option value="Vietnamese">Vietnamese</option>
		<option value="Cambodian">Cambodian</option>
		<option value="Singaporean">Singaporean</option>
		<option value="Chinese">Chinese</option>
		<option value="Indonesian">Indonesian</option>
		<option value="Philippine, Filipino">Philippine, Filipino</option>
		<option value="Timorese">Timorese</option>
		<option value="Chinese, Taiwanese">Chinese, Taiwanese</option>
		<option value="Indian">Indian</option>
		<option value="Bangladeshi">Bangladeshi</option>
		<option value="Australian">Australian</option>
		<option value="Afghan">Afghan</option>
		<option value="Åland Island">Åland Island</option>
		<option value="Albanian">Albanian</option>
		<option value="Algerian">Algerian</option>
		<option value="American">American</option>
		<option value="American Samoan">American Samoan</option>
		<option value="Andorran">Andorran</option>
		<option value="Angolan">Angolan</option>
		<option value="Anguillan">Anguillan</option>
		<option value="Antarctic">Antarctic</option>
		<option value="Antiguan or Barbudan">Antiguan or Barbudan</option>
		<option value="Argentine">Argentine</option>
		<option value="Armenian">Armenian</option>
		<option value="Aruban">Aruban</option>
		<option value="Austrian">Austrian</option>
		<option value="Azerbaijani, Azeri">Azerbaijani, Azeri</option>
		<option value="Bahamian">Bahamian</option>
		<option value="Bahraini">Bahraini</option>
		<option value="Barbadian">Barbadian</option>
		<option value="Barthélemois">Barthélemois</option>
		<option value="Basotho">Basotho</option>
		<option value="Belarusian">Belarusian</option>
		<option value="Belgian">Belgian</option>
		<option value="Belizean">Belizean</option>
		<option value="Beninese, Beninois">Beninese, Beninois</option>
		<option value="Bermudian, Bermudan">Bermudian, Bermudan</option>
		<option value="Bhutanese">Bhutanese</option>
		<option value="BIOT">BIOT</option>
		<option value="Bissau-Guinean">Bissau-Guinean</option>
		<option value="Bolivian">Bolivian</option>
		<option value="Bonaire">Bonaire</option>
		<option value="Bosnian or Herzegovinian">Bosnian or Herzegovinian</option>
		<option value="Bouvet Island">Bouvet Island</option>
		<option value="Brazilian">Brazilian</option>
		<option value="British Virgin Island">British Virgin Island</option>
		<option value="British, UK">British, UK</option>
		<option value="Bruneian">Bruneian</option>
		<option value="Bulgarian">Bulgarian</option>
		<option value="Burkinabé">Burkinabé</option>
		<option value="Burundian">Burundian</option>
		<option value="Cabo Verdean">Cabo Verdean</option>
		<option value="Cameroonian">Cameroonian</option>
		<option value="Canadian">Canadian</option>
		<option value="Caymanian">Caymanian</option>
		<option value="Central African">Central African</option>
		<option value="Chadian">Chadian</option>
		<option value="Channel Island">Channel Island</option>
		<option value="Chilean">Chilean</option>
		<option value="Christmas Island">Christmas Island</option>
		<option value="Cocos Island">Cocos Island</option>
		<option value="Colombian">Colombian</option>
		<option value="Comoran, Comorian">Comoran, Comorian</option>
		<option value="Congolese">Congolese</option>
		<option value="Cook Island">Cook Island</option>
		<option value="Costa Rican">Costa Rican</option>
		<option value="Croatian">Croatian</option>
		<option value="Cuban">Cuban</option>
		<option value="Curaçaoan">Curaçaoan</option>
		<option value="Cypriot">Cypriot</option>
		<option value="Czech">Czech</option>
		<option value="Danish">Danish</option>
		<option value="Djiboutian">Djiboutian</option>
		<option value="Dominican">Dominican</option>
		<option value="Dutch, Netherlandic">Dutch, Netherlandic</option>
		<option value="Ecuadorian">Ecuadorian</option>
		<option value="Egyptian">Egyptian</option>
		<option value="Emirati, Emirian, Emiri">Emirati, Emirian, Emiri</option>
		<option value="Equatorial Guinean, Equatoguinean">Equatorial Guinean, Equatoguinean</option>
		<option value="Eritrean">Eritrean</option>
		<option value="Estonian">Estonian</option>
		<option value="Ethiopian">Ethiopian</option>
		<option value="Falkland Island">Falkland Island</option>
		<option value="Faroese">Faroese</option>
		<option value="Fijian">Fijian</option>
		<option value="Finnish">Finnish</option>
		<option value="French">French</option>
		<option value="French Guianese">French Guianese</option>
		<option value="French Polynesian">French Polynesian</option>
		<option value="French Southern Territories">French Southern Territories</option>
		<option value="Gabonese">Gabonese</option>
		<option value="Gambian">Gambian</option>
		<option value="Georgian">Georgian</option>
		<option value="German">German</option>
		<option value="Ghanaian">Ghanaian</option>
		<option value="Gibraltar">Gibraltar</option>
		<option value="Greek, Hellenic">Greek, Hellenic</option>
		<option value="Greenlandic">Greenlandic</option>
		<option value="Grenadian">Grenadian</option>
		<option value="Guadeloupe">Guadeloupe</option>
		<option value="Guamanian, Guambat">Guamanian, Guambat</option>
		<option value="Guatemalan">Guatemalan</option>
		<option value="Guinean">Guinean</option>
		<option value="Guyanese">Guyanese</option>
		<option value="Haitian">Haitian</option>
		<option value="Heard Island or McDonald Islands">Heard Island or McDonald Islands</option>
		<option value="Honduran">Honduran</option>
		<option value="Hong Kong, Hong Kongese">Hong Kong, Hong Kongese</option>
		<option value="Hungarian, Magyar">Hungarian, Magyar</option>
		<option value="I-Kiribati">I-Kiribati</option>
		<option value="Icelandic">Icelandic</option>
		<option value="Iranian, Persian">Iranian, Persian</option>
		<option value="Iraqi">Iraqi</option>
		<option value="Irish">Irish</option>
		<option value="Israeli">Israeli</option>
		<option value="Italian">Italian</option>
		<option value="Ivorian">Ivorian</option>
		<option value="Jamaican">Jamaican</option>
		<option value="Japanese">Japanese</option>
		<option value="Jordanian">Jordanian</option>
		<option value="Kazakhstani, Kazakh">Kazakhstani, Kazakh</option>
		<option value="Kenyan">Kenyan</option>
		<option value="Kittitian or Nevisian">Kittitian or Nevisian</option>
		<option value="Kuwaiti">Kuwaiti</option>
		<option value="Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz">Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz</option>
		<option value="Latvian">Latvian</option>
		<option value="Lebanese">Lebanese</option>
		<option value="Liberian">Liberian</option>
		<option value="Libyan">Libyan</option>
		<option value="Liechtenstein">Liechtenstein</option>
		<option value="Lithuanian">Lithuanian</option>
		<option value="Luxembourg, Luxembourgish">Luxembourg, Luxembourgish</option>
		<option value="Macanese, Chinese">Macanese, Chinese</option>
		<option value="Macedonian">Macedonian</option>
		<option value="Mahoran">Mahoran</option>
		<option value="Malagasy">Malagasy</option>
		<option value="Malawian">Malawian</option>
		<option value="Maldivian">Maldivian</option>
		<option value="Malian, Malinese">Malian, Malinese</option>
		<option value="Maltese">Maltese</option>
		<option value="Manx">Manx</option>
		<option value="Marshallese">Marshallese</option>
		<option value="Martiniquais, Martinican">Martiniquais, Martinican</option>
		<option value="Mauritanian">Mauritanian</option>
		<option value="Mauritian">Mauritian</option>
		<option value="Mexican">Mexican</option>
		<option value="Micronesian">Micronesian</option>
		<option value="Moldovan">Moldovan</option>
		<option value="Monégasque, Monacan">Monégasque, Monacan</option>
		<option value="Mongolian">Mongolian</option>
		<option value="Montenegrin">Montenegrin</option>
		<option value="Montserratian">Montserratian</option>
		<option value="Moroccan">Moroccan</option>
		<option value="Motswana, Botswanan">Motswana, Botswanan</option>
		<option value="Mozambican">Mozambican</option>
		<option value="Namibian">Namibian</option>
		<option value="Nauruan">Nauruan</option>
		<option value="Nepali, Nepalese">Nepali, Nepalese</option>
		<option value="New Caledonian">New Caledonian</option>
		<option value="New Zealand, NZ">New Zealand, NZ</option>
		<option value="Ni-Vanuatu, Vanuatuan">Ni-Vanuatu, Vanuatuan</option>
		<option value="Nicaraguan">Nicaraguan</option>
		<option value="Nigerian">Nigerian</option>
		<option value="Nigerien">Nigerien</option>
		<option value="Niuean">Niuean</option>
		<option value="Norfolk Island">Norfolk Island</option>
		<option value="North Korean">North Korean</option>
		<option value="Northern Marianan">Northern Marianan</option>
		<option value="Norwegian">Norwegian</option>
		<option value="Omani">Omani</option>
		<option value="Pakistani">Pakistani</option>
		<option value="Palauan">Palauan</option>
		<option value="Palestinian">Palestinian</option>
		<option value="Panamanian">Panamanian</option>
		<option value="Papua New Guinean, Papuan">Papua New Guinean, Papuan</option>
		<option value="Paraguayan">Paraguayan</option>
		<option value="Peruvian">Peruvian</option>
		<option value="Pitcairn Island">Pitcairn Island</option>
		<option value="Polish">Polish</option>
		<option value="Portuguese">Portuguese</option>
		<option value="Puerto Rican">Puerto Rican</option>
		<option value="Qatari">Qatari</option>
		<option value="Réunionese, Réunionnais">Réunionese, Réunionnais</option>
		<option value="Romanian">Romanian</option>
		<option value="Russian">Russian</option>
		<option value="Rwandan">Rwandan</option>
		<option value="Sahrawi, Sahrawian, Sahraouian">Sahrawi, Sahrawian, Sahraouian</option>
		<option value="Saint-Martinoise">Saint-Martinoise</option>
		<option value="Saint-Pierrais or Miquelonnais">Saint-Pierrais or Miquelonnais</option>
		<option value="Saint Helenian">Saint Helenian</option>
		<option value="Saint Lucian">Saint Lucian</option>
		<option value="Saint Vincentian, Vincentian">Saint Vincentian, Vincentian</option>
		<option value="Salvadoran">Salvadoran</option>
		<option value="Sammarinese">Sammarinese</option>
		<option value="Samoan">Samoan</option>
		<option value="São Toméan">São Toméan</option>
		<option value="Saudi, Saudi Arabian">Saudi, Saudi Arabian</option>
		<option value="Senegalese">Senegalese</option>
		<option value="Serbian">Serbian</option>
		<option value="Seychellois">Seychellois</option>
		<option value="Sierra Leonean">Sierra Leonean</option>
		<option value="Sint Maarten">Sint Maarten</option>
		<option value="Slovak">Slovak</option>
		<option value="Slovenian, Slovene">Slovenian, Slovene</option>
		<option value="Solomon Island">Solomon Island</option>
		<option value="Somali, Somalian">Somali, Somalian</option>
		<option value="South African">South African</option>
		<option value="South Georgia or South Sandwich Islands">South Georgia or South Sandwich Islands</option>
		<option value="South Korean">South Korean</option>
		<option value="South Sudanese">South Sudanese</option>
		<option value="Spanish">Spanish</option>
		<option value="Sri Lankan">Sri Lankan</option>
		<option value="Sudanese">Sudanese</option>
		<option value="Surinamese">Surinamese</option>
		<option value="Svalbard">Svalbard</option>
		<option value="Swazi">Swazi</option>
		<option value="Swedish">Swedish</option>
		<option value="Swiss">Swiss</option>
		<option value="Syrian">Syrian</option>
		<option value="Tajikistani">Tajikistani</option>
		<option value="Tanzanian">Tanzanian</option>
		<option value="Thai">Thai</option>
		<option value="Togolese">Togolese</option>
		<option value="Tokelauan">Tokelauan</option>
		<option value="Tongan">Tongan</option>
		<option value="Trinidadian or Tobagonian">Trinidadian or Tobagonian</option>
		<option value="Tunisian">Tunisian</option>
		<option value="Turkish">Turkish</option>
		<option value="Turkmen">Turkmen</option>
		<option value="Turks and Caicos Island">Turks and Caicos Island</option>
		<option value="Tuvaluan">Tuvaluan</option>
		<option value="U.S. Virgin Island">U.S. Virgin Island</option>
		<option value="Ugandan">Ugandan</option>
		<option value="Ukrainian">Ukrainian</option>
		<option value="Uruguayan">Uruguayan</option>
		<option value="Uzbekistani, Uzbek">Uzbekistani, Uzbek</option>
		<option value="Vatican">Vatican</option>
		<option value="Venezuelan">Venezuelan</option>
		<option value="Wallis and Futuna, Wallisian or Futunan">Wallis and Futuna, Wallisian or Futunan</option>
		<option value="Yemeni">Yemeni</option>
		<option value="Zambian">Zambian</option>
		<option value="Zimbabwean">Zimbabwean</option>

	</select>
                            </div>
                        </div>

                        <div class="ui stackable three column grid container">

                            

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields">Passport No. : </label>
                                <asp:TextBox name="ctl00$MainContent$txtPassportNo3" id="MainContent_txtPassportNo3" type="Address" class="w3-input w3-border w3-round-large" placeholder="Passport No. " runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields">Passport Expire : </label>
                               <asp:TextBox name="ctl00$MainContent$txtPassport_exp3" id="MainContent_txtPassport_exp3" type="LicenseExpire" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Passport Expire" runat="server"/>
                            </div>
                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields">Driver License No. : </label>
                               <asp:TextBox name="ctl00$MainContent$txtLicense3" id="MainContent_txtLicense3" type="Address" class="w3-input w3-border w3-round-large" placeholder="Driver License No." runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Expire License" class="w3-left fields">Driver License Expiry Date : </label>
                                <asp:TextBox name="ctl00$MainContent$txtLicenseExpire3" id="MainContent_txtLicenseExpire3" type="LicenseExpire" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Driver License Expiry Date" runat="server"/>
                            </div>
                        </div>

                        <div class="ui stackable four column grid container">
                            
                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left fields">Address : </label>
                                <asp:TextBox name="ctl00$MainContent$txtAddress3" rows="2" cols="20" id="MainContent_txtAddress3" type="Address" class="w3-input w3-border w3-round-large" placeholder="Address" TextMode="MultiLine" runat="server"/>
                            </div>


                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name" class="w3-left fields">Country : </label>
                                <select name="ctl00$MainContent$ddlCountry3" id="MainContent_ddlCountry3" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="Malaysia">Malaysia</option>
		<option value="Myanmar">Myanmar</option>
		<option value="Lao">Lao</option>
		<option value="Vietnam">Vietnam</option>
		<option value="Cambodia">Cambodia</option>
		<option value="Singapore">Singapore</option>
		<option value="China">China</option>
		<option value="Indonesia">Indonesia</option>
		<option value="Philippines">Philippines</option>
		<option value="Timor-Leste">Timor-Leste</option>
		<option value="Taiwan, Province of China">Taiwan, Province of China</option>
		<option value="India">India</option>
		<option value="Bangladesh">Bangladesh</option>
		<option value="Australia">Australia</option>
		<option value="Afghanistan">Afghanistan</option>
		<option value="Åland Islands">Åland Islands</option>
		<option value="Albania">Albania</option>
		<option value="Algeria">Algeria</option>
		<option value="American Samoa">American Samoa</option>
		<option value="Andorra">Andorra</option>
		<option value="Angola">Angola</option>
		<option value="Anguilla">Anguilla</option>
		<option value="Antarctica">Antarctica</option>
		<option value="Antigua and Barbuda">Antigua and Barbuda</option>
		<option value="Argentina">Argentina</option>
		<option value="Armenia">Armenia</option>
		<option value="Aruba">Aruba</option>
		<option value="Austria">Austria</option>
		<option value="Azerbaijan">Azerbaijan</option>
		<option value="Bahamas">Bahamas</option>
		<option value="Bahrain">Bahrain</option>
		<option value="Barbados">Barbados</option>
		<option value="Belarus">Belarus</option>
		<option value="Belgium">Belgium</option>
		<option value="Belize">Belize</option>
		<option value="Benin">Benin</option>
		<option value="Bermuda">Bermuda</option>
		<option value="Bhutan">Bhutan</option>
		<option value="Bolivia (Plurinational State of)">Bolivia (Plurinational State of)</option>
		<option value="Bonaire, Sint Eustatius and Saba">Bonaire, Sint Eustatius and Saba</option>
		<option value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
		<option value="Botswana">Botswana</option>
		<option value="Bouvet Island">Bouvet Island</option>
		<option value="Brazil">Brazil</option>
		<option value="British Indian Ocean Territory">British Indian Ocean Territory</option>
		<option value="Brunei Darussalam">Brunei Darussalam</option>
		<option value="Bulgaria">Bulgaria</option>
		<option value="Burkina Faso">Burkina Faso</option>
		<option value="Burundi">Burundi</option>
		<option value="Cabo Verde">Cabo Verde</option>
		<option value="Cameroon">Cameroon</option>
		<option value="Canada">Canada</option>
		<option value="Cayman Islands">Cayman Islands</option>
		<option value="Central African Republic">Central African Republic</option>
		<option value="Chad">Chad</option>
		<option value="Chile">Chile</option>
		<option value="Christmas Island">Christmas Island</option>
		<option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option>
		<option value="Colombia">Colombia</option>
		<option value="Comoros">Comoros</option>
		<option value="Congo (Democratic Republic of the)">Congo (Democratic Republic of the)</option>
		<option value="Congo (Republic of the)">Congo (Republic of the)</option>
		<option value="Cook Islands">Cook Islands</option>
		<option value="Costa Rica">Costa Rica</option>
		<option value="Côte d Ivoire">Côte d Ivoire</option>
		<option value="Croatia">Croatia</option>
		<option value="Cuba">Cuba</option>
		<option value="Curaçao">Curaçao</option>
		<option value="Cyprus">Cyprus</option>
		<option value="Czech Republic">Czech Republic</option>
		<option value="Denmark">Denmark</option>
		<option value="Djibouti">Djibouti</option>
		<option value="Dominica">Dominica</option>
		<option value="Dominican Republic">Dominican Republic</option>
		<option value="Ecuador">Ecuador</option>
		<option value="Egypt">Egypt</option>
		<option value="El Salvador">El Salvador</option>
		<option value="Equatorial Guinea">Equatorial Guinea</option>
		<option value="Eritrea">Eritrea</option>
		<option value="Estonia">Estonia</option>
		<option value="Ethiopia">Ethiopia</option>
		<option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option>
		<option value="Faroe Islands">Faroe Islands</option>
		<option value="Fiji">Fiji</option>
		<option value="Finland">Finland</option>
		<option value="France">France</option>
		<option value="French Guiana">French Guiana</option>
		<option value="French Polynesia">French Polynesia</option>
		<option value="French Southern Territories">French Southern Territories</option>
		<option value="Gabon">Gabon</option>
		<option value="Gambia">Gambia</option>
		<option value="Georgia">Georgia</option>
		<option value="Germany">Germany</option>
		<option value="Ghana">Ghana</option>
		<option value="Gibraltar">Gibraltar</option>
		<option value="Greece">Greece</option>
		<option value="Greenland">Greenland</option>
		<option value="Grenada">Grenada</option>
		<option value="Guadeloupe">Guadeloupe</option>
		<option value="Guam">Guam</option>
		<option value="Guatemala">Guatemala</option>
		<option value="Guernsey">Guernsey</option>
		<option value="Guinea">Guinea</option>
		<option value="Guinea-Bissau">Guinea-Bissau</option>
		<option value="Guyana">Guyana</option>
		<option value="Haiti">Haiti</option>
		<option value="Heard Island and McDonald Islands">Heard Island and McDonald Islands</option>
		<option value="Honduras">Honduras</option>
		<option value="Hong Kong">Hong Kong</option>
		<option value="Hungary">Hungary</option>
		<option value="Iceland">Iceland</option>
		<option value="Iran">Iran</option>
		<option value="Iraq">Iraq</option>
		<option value="Ireland">Ireland</option>
		<option value="Isle of Man">Isle of Man</option>
		<option value="Israel">Israel</option>
		<option value="Italy">Italy</option>
		<option value="Jamaica">Jamaica</option>
		<option value="Japan">Japan</option>
		<option value="Jersey">Jersey</option>
		<option value="Jordan">Jordan</option>
		<option value="Kazakhstan">Kazakhstan</option>
		<option value="Kenya">Kenya</option>
		<option value="Kiribati">Kiribati</option>
		<option value="Korea (Democratic People Republic of)">Korea (Democratic People Republic of)</option>
		<option value="Korea (Republic of)">Korea (Republic of)</option>
		<option value="Kuwait">Kuwait</option>
		<option value="Kyrgyzstan">Kyrgyzstan</option>
		<option value="Latvia">Latvia</option>
		<option value="Lebanon">Lebanon</option>
		<option value="Lesotho">Lesotho</option>
		<option value="Liberia">Liberia</option>
		<option value="Libya">Libya</option>
		<option value="Liechtenstein">Liechtenstein</option>
		<option value="Lithuania">Lithuania</option>
		<option value="Luxembourg">Luxembourg</option>
		<option value="Macao">Macao</option>
		<option value="Macedonia (the former Yugoslav Republic of)">Macedonia (the former Yugoslav Republic of)</option>
		<option value="Madagascar">Madagascar</option>
		<option value="Malawi">Malawi</option>
		<option value="Maldives">Maldives</option>
		<option value="Mali">Mali</option>
		<option value="Malta">Malta</option>
		<option value="Marshall Islands">Marshall Islands</option>
		<option value="Martinique">Martinique</option>
		<option value="Mauritania">Mauritania</option>
		<option value="Mauritius">Mauritius</option>
		<option value="Mayotte">Mayotte</option>
		<option value="Mexico">Mexico</option>
		<option value="Micronesia (Federated States of)">Micronesia (Federated States of)</option>
		<option value="Moldova (Republic of)">Moldova (Republic of)</option>
		<option value="Monaco">Monaco</option>
		<option value="Mongolia">Mongolia</option>
		<option value="Montenegro">Montenegro</option>
		<option value="Montserrat">Montserrat</option>
		<option value="Morocco">Morocco</option>
		<option value="Mozambique">Mozambique</option>
		<option value="Namibia">Namibia</option>
		<option value="Nauru">Nauru</option>
		<option value="Nepal">Nepal</option>
		<option value="Netherlands">Netherlands</option>
		<option value="New Caledonia">New Caledonia</option>
		<option value="New Zealand">New Zealand</option>
		<option value="Nicaragua">Nicaragua</option>
		<option value="Niger">Niger</option>
		<option value="Nigeria">Nigeria</option>
		<option value="Niue">Niue</option>
		<option value="Norfolk Island">Norfolk Island</option>
		<option value="Northern Mariana Islands">Northern Mariana Islands</option>
		<option value="Norway">Norway</option>
		<option value="Oman">Oman</option>
		<option value="Pakistan">Pakistan</option>
		<option value="Palau">Palau</option>
		<option value="Palestine, State of">Palestine, State of</option>
		<option value="Panama">Panama</option>
		<option value="Papua New Guinea">Papua New Guinea</option>
		<option value="Paraguay">Paraguay</option>
		<option value="Peru">Peru</option>
		<option value="Pitcairn">Pitcairn</option>
		<option value="Poland">Poland</option>
		<option value="Portugal">Portugal</option>
		<option value="Puerto Rico">Puerto Rico</option>
		<option value="Qatar">Qatar</option>
		<option value="Réunion">Réunion</option>
		<option value="Romania">Romania</option>
		<option value="Russian Federation">Russian Federation</option>
		<option value="Rwanda">Rwanda</option>
		<option value="Saint Barthélemy">Saint Barthélemy</option>
		<option value="Saint Helena, Ascension and Tristan da Cunha">Saint Helena, Ascension and Tristan da Cunha</option>
		<option value="Saint Kitts and Nevis">Saint Kitts and Nevis</option>
		<option value="Saint Lucia">Saint Lucia</option>
		<option value="Saint Martin (French part)">Saint Martin (French part)</option>
		<option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon</option>
		<option value="Saint Vincent and the Grenadines">Saint Vincent and the Grenadines</option>
		<option value="Samoa">Samoa</option>
		<option value="San Marino">San Marino</option>
		<option value="Sao Tome and Principe">Sao Tome and Principe</option>
		<option value="Saudi Arabia">Saudi Arabia</option>
		<option value="Senegal">Senegal</option>
		<option value="Serbia">Serbia</option>
		<option value="Seychelles">Seychelles</option>
		<option value="Sierra Leone">Sierra Leone</option>
		<option value="Sint Maarten (Dutch part)">Sint Maarten (Dutch part)</option>
		<option value="Slovakia">Slovakia</option>
		<option value="Slovenia">Slovenia</option>
		<option value="Solomon Islands">Solomon Islands</option>
		<option value="Somalia">Somalia</option>
		<option value="South Africa">South Africa</option>
		<option value="South Georgia and the South Sandwich Islands">South Georgia and the South Sandwich Islands</option>
		<option value="South Sudan">South Sudan</option>
		<option value="Spain">Spain</option>
		<option value="Sri Lanka">Sri Lanka</option>
		<option value="Sudan">Sudan</option>
		<option value="Suriname">Suriname</option>
		<option value="Svalbard and Jan Mayen">Svalbard and Jan Mayen</option>
		<option value="Swaziland">Swaziland</option>
		<option value="Sweden">Sweden</option>
		<option value="Switzerland">Switzerland</option>
		<option value="Syrian Arab Republic">Syrian Arab Republic</option>
		<option value="Tajikistan">Tajikistan</option>
		<option value="Tanzania, United Republic of">Tanzania, United Republic of</option>
		<option value="Thailand">Thailand</option>
		<option value="Togo">Togo</option>
		<option value="Tokelau">Tokelau</option>
		<option value="Tonga">Tonga</option>
		<option value="Trinidad and Tobago">Trinidad and Tobago</option>
		<option value="Tunisia">Tunisia</option>
		<option value="Turkey">Turkey</option>
		<option value="Turkmenistan">Turkmenistan</option>
		<option value="Turks and Caicos Islands">Turks and Caicos Islands</option>
		<option value="Tuvalu">Tuvalu</option>
		<option value="Uganda">Uganda</option>
		<option value="Ukraine">Ukraine</option>
		<option value="United Arab Emirates">United Arab Emirates</option>
		<option value="United Kingdom">United Kingdom</option>
		<option value="United States Minor Outlying Islands">United States Minor Outlying Islands</option>
		<option value="United States of America">United States of America</option>
		<option value="Uruguay">Uruguay</option>
		<option value="Uzbekistan">Uzbekistan</option>
		<option value="Vanuatu">Vanuatu</option>
		<option value="Vatican City State">Vatican City State</option>
		<option value="Venezuela (Bolivarian Republic of)">Venezuela (Bolivarian Republic of)</option>
		<option value="Virgin Islands (British)">Virgin Islands (British)</option>
		<option value="Virgin Islands (U.S.)">Virgin Islands (U.S.)</option>
		<option value="Wallis and Futuna">Wallis and Futuna</option>
		<option value="Western Sahara">Western Sahara</option>
		<option value="Yemen">Yemen</option>
		<option value="Zambia">Zambia</option>
		<option value="Zimbabwe">Zimbabwe</option>

	</select>
                            </div>


                            <div class="w3-left fields col-md-3 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left">Zipcode: </label>
                                 <asp:TextBox name="ctl00$MainContent$txtZipcode3" id="MainContent_txtZipcode3" type="Address" class="w3-input w3-border w3-round-large" placeholder="Zipcode" runat="server"/>
                            </div>

                        </div>

                        <div class="ui stackable three column grid container" id="divReserveDriver2">
                            
                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left">Telephone : </label>
                                 <asp:TextBox name="ctl00$MainContent$txtTel3" id="MainContent_txtTel3" type="Address" class="w3-input w3-border w3-round-large" placeholder="Telephone" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-6 pb-3" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname" class="w3-left">Email : </label>
                                 <asp:TextBox name="ctl00$MainContent$txtEmail3" id="MainContent_txtEmail3" type="Address" class="w3-input w3-border w3-round-large" placeholder="Email" runat="server"/>
                            </div>

                        </div>

                        <br>
                        &nbsp; 
                        <div class="ui stackable  four column grid container">
						 </div>
                        </div>
					 <div class="row">
                        <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 10%; font-size: x-large;">Vehicle
                        </b>

                    </div>
                    
                    <span id="MainContent_lblcomments3" class="w3-text-red"></span>
                    <br>
                    <br>

                    <div id="MainContent_Page3">
	
                        <div class="ui stackable four column grid ">

                            <div class="w3-left fields col-md-1 pb-3 "></div>
                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="Surname"><a class="w3-text-red">*</a> Make : </label>

                                

                              <asp:TextBox name="ctl00$MainContent$txtBrands" id="brands_id" type="brands" class="w3-input w3-border w3-round-large"  runat="server"/>

                               
                            </div>


                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Model : </label>

                                
                               <asp:TextBox name="ctl00$MainContent$txtModel" id="MainContent_txtModel" type="Model" class="w3-input w3-border w3-round-large" placeholder="e.g. VIGO CIVIC" runat="server"/>
                                
                            </div>


                            

                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Colors : </label>

                                
                                <select name="ctl00$MainContent$ddlColor" id="MainContent_ddlColor" class="w3-input w3-border w3-round-large">
		<option value="Red">Red</option>
		<option value="Blue">Blue</option>
		<option value="Yellow">Yellow</option>
		<option value="White">White</option>
		<option value="Black">Black</option>
		<option value="Purple">Purple</option>
		<option value="Green">Green</option>
		<option value="Orange">Orange</option>
		<option value="Brown/Bronze">Brown/Bronze</option>
		<option value="Pink">Pink</option>
		<option value="Grey/Silver">Grey/Silver</option>
		<option value="Others">Others</option>

	</select>

                            </div>

                            
                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Seats : </label>


                               <asp:TextBox name="ctl00$MainContent$txtSeats" type="text" id="MainContent_txtSeats" class="w3-input w3-border w3-round-large" placeholder="Seats" runat="server"/>
                            </div>

                        </div>

                        

                        <div class="ui stackable four column grid ">
                            <div class="w3-left fields col-md-1 pb-3 "></div>



                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Country of registration : </label>
                                
                                <div id="MainContent_UpdatePanel5">
		
                                        <select name="ctl00$MainContent$ddlCountryCar" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlCountryCar\',\'\')', 0)" id="MainContent_ddlCountryCar" class="w3-input w3-border w3-round-large" data-inline="true">
			<option selected="selected" value="Malaysia">Malaysia</option>
			<option value="Myanmar">Myanmar</option>
			<option value="Lao">Lao</option>
			<option value="Vietnam">Vietnam</option>
			<option value="Cambodia">Cambodia</option>
			<option value="Singapore">Singapore</option>
			<option value="China">China</option>
			<option value="Indonesia">Indonesia</option>
			<option value="Philippines">Philippines</option>
			<option value="Timor-Leste">Timor-Leste</option>
			<option value="Taiwan, Province of China">Taiwan, Province of China</option>
			<option value="India">India</option>
			<option value="Bangladesh">Bangladesh</option>
			<option value="Australia">Australia</option>
			<option value="Afghanistan">Afghanistan</option>
			<option value="Åland Islands">Åland Islands</option>
			<option value="Albania">Albania</option>
			<option value="Algeria">Algeria</option>
			<option value="American Samoa">American Samoa</option>
			<option value="Andorra">Andorra</option>
			<option value="Angola">Angola</option>
			<option value="Anguilla">Anguilla</option>
			<option value="Antarctica">Antarctica</option>
			<option value="Antigua and Barbuda">Antigua and Barbuda</option>
			<option value="Argentina">Argentina</option>
			<option value="Armenia">Armenia</option>
			<option value="Aruba">Aruba</option>
			<option value="Austria">Austria</option>
			<option value="Azerbaijan">Azerbaijan</option>
			<option value="Bahamas">Bahamas</option>
			<option value="Bahrain">Bahrain</option>
			<option value="Barbados">Barbados</option>
			<option value="Belarus">Belarus</option>
			<option value="Belgium">Belgium</option>
			<option value="Belize">Belize</option>
			<option value="Benin">Benin</option>
			<option value="Bermuda">Bermuda</option>
			<option value="Bhutan">Bhutan</option>
			<option value="Bolivia (Plurinational State of)">Bolivia (Plurinational State of)</option>
			<option value="Bonaire, Sint Eustatius and Saba">Bonaire, Sint Eustatius and Saba</option>
			<option value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
			<option value="Botswana">Botswana</option>
			<option value="Bouvet Island">Bouvet Island</option>
			<option value="Brazil">Brazil</option>
			<option value="British Indian Ocean Territory">British Indian Ocean Territory</option>
			<option value="Brunei Darussalam">Brunei Darussalam</option>
			<option value="Bulgaria">Bulgaria</option>
			<option value="Burkina Faso">Burkina Faso</option>
			<option value="Burundi">Burundi</option>
			<option value="Cabo Verde">Cabo Verde</option>
			<option value="Cameroon">Cameroon</option>
			<option value="Canada">Canada</option>
			<option value="Cayman Islands">Cayman Islands</option>
			<option value="Central African Republic">Central African Republic</option>
			<option value="Chad">Chad</option>
			<option value="Chile">Chile</option>
			<option value="Christmas Island">Christmas Island</option>
			<option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option>
			<option value="Colombia">Colombia</option>
			<option value="Comoros">Comoros</option>
			<option value="Congo (Democratic Republic of the)">Congo (Democratic Republic of the)</option>
			<option value="Congo (Republic of the)">Congo (Republic of the)</option>
			<option value="Cook Islands">Cook Islands</option>
			<option value="Costa Rica">Costa Rica</option>
			<option value="Côte d Ivoire">Côte d Ivoire</option>
			<option value="Croatia">Croatia</option>
			<option value="Cuba">Cuba</option>
			<option value="Curaçao">Curaçao</option>
			<option value="Cyprus">Cyprus</option>
			<option value="Czech Republic">Czech Republic</option>
			<option value="Denmark">Denmark</option>
			<option value="Djibouti">Djibouti</option>
			<option value="Dominica">Dominica</option>
			<option value="Dominican Republic">Dominican Republic</option>
			<option value="Ecuador">Ecuador</option>
			<option value="Egypt">Egypt</option>
			<option value="El Salvador">El Salvador</option>
			<option value="Equatorial Guinea">Equatorial Guinea</option>
			<option value="Eritrea">Eritrea</option>
			<option value="Estonia">Estonia</option>
			<option value="Ethiopia">Ethiopia</option>
			<option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option>
			<option value="Faroe Islands">Faroe Islands</option>
			<option value="Fiji">Fiji</option>
			<option value="Finland">Finland</option>
			<option value="France">France</option>
			<option value="French Guiana">French Guiana</option>
			<option value="French Polynesia">French Polynesia</option>
			<option value="French Southern Territories">French Southern Territories</option>
			<option value="Gabon">Gabon</option>
			<option value="Gambia">Gambia</option>
			<option value="Georgia">Georgia</option>
			<option value="Germany">Germany</option>
			<option value="Ghana">Ghana</option>
			<option value="Gibraltar">Gibraltar</option>
			<option value="Greece">Greece</option>
			<option value="Greenland">Greenland</option>
			<option value="Grenada">Grenada</option>
			<option value="Guadeloupe">Guadeloupe</option>
			<option value="Guam">Guam</option>
			<option value="Guatemala">Guatemala</option>
			<option value="Guernsey">Guernsey</option>
			<option value="Guinea">Guinea</option>
			<option value="Guinea-Bissau">Guinea-Bissau</option>
			<option value="Guyana">Guyana</option>
			<option value="Haiti">Haiti</option>
			<option value="Heard Island and McDonald Islands">Heard Island and McDonald Islands</option>
			<option value="Honduras">Honduras</option>
			<option value="Hong Kong">Hong Kong</option>
			<option value="Hungary">Hungary</option>
			<option value="Iceland">Iceland</option>
			<option value="Iran">Iran</option>
			<option value="Iraq">Iraq</option>
			<option value="Ireland">Ireland</option>
			<option value="Isle of Man">Isle of Man</option>
			<option value="Israel">Israel</option>
			<option value="Italy">Italy</option>
			<option value="Jamaica">Jamaica</option>
			<option value="Japan">Japan</option>
			<option value="Jersey">Jersey</option>
			<option value="Jordan">Jordan</option>
			<option value="Kazakhstan">Kazakhstan</option>
			<option value="Kenya">Kenya</option>
			<option value="Kiribati">Kiribati</option>
			<option value="Korea (Democratic People Republic of)">Korea (Democratic People Republic of)</option>
			<option value="Korea (Republic of)">Korea (Republic of)</option>
			<option value="Kuwait">Kuwait</option>
			<option value="Kyrgyzstan">Kyrgyzstan</option>
			<option value="Latvia">Latvia</option>
			<option value="Lebanon">Lebanon</option>
			<option value="Lesotho">Lesotho</option>
			<option value="Liberia">Liberia</option>
			<option value="Libya">Libya</option>
			<option value="Liechtenstein">Liechtenstein</option>
			<option value="Lithuania">Lithuania</option>
			<option value="Luxembourg">Luxembourg</option>
			<option value="Macao">Macao</option>
			<option value="Macedonia (the former Yugoslav Republic of)">Macedonia (the former Yugoslav Republic of)</option>
			<option value="Madagascar">Madagascar</option>
			<option value="Malawi">Malawi</option>
			<option value="Maldives">Maldives</option>
			<option value="Mali">Mali</option>
			<option value="Malta">Malta</option>
			<option value="Marshall Islands">Marshall Islands</option>
			<option value="Martinique">Martinique</option>
			<option value="Mauritania">Mauritania</option>
			<option value="Mauritius">Mauritius</option>
			<option value="Mayotte">Mayotte</option>
			<option value="Mexico">Mexico</option>
			<option value="Micronesia (Federated States of)">Micronesia (Federated States of)</option>
			<option value="Moldova (Republic of)">Moldova (Republic of)</option>
			<option value="Monaco">Monaco</option>
			<option value="Mongolia">Mongolia</option>
			<option value="Montenegro">Montenegro</option>
			<option value="Montserrat">Montserrat</option>
			<option value="Morocco">Morocco</option>
			<option value="Mozambique">Mozambique</option>
			<option value="Namibia">Namibia</option>
			<option value="Nauru">Nauru</option>
			<option value="Nepal">Nepal</option>
			<option value="Netherlands">Netherlands</option>
			<option value="New Caledonia">New Caledonia</option>
			<option value="New Zealand">New Zealand</option>
			<option value="Nicaragua">Nicaragua</option>
			<option value="Niger">Niger</option>
			<option value="Nigeria">Nigeria</option>
			<option value="Niue">Niue</option>
			<option value="Norfolk Island">Norfolk Island</option>
			<option value="Northern Mariana Islands">Northern Mariana Islands</option>
			<option value="Norway">Norway</option>
			<option value="Oman">Oman</option>
			<option value="Pakistan">Pakistan</option>
			<option value="Palau">Palau</option>
			<option value="Palestine, State of">Palestine, State of</option>
			<option value="Panama">Panama</option>
			<option value="Papua New Guinea">Papua New Guinea</option>
			<option value="Paraguay">Paraguay</option>
			<option value="Peru">Peru</option>
			<option value="Pitcairn">Pitcairn</option>
			<option value="Poland">Poland</option>
			<option value="Portugal">Portugal</option>
			<option value="Puerto Rico">Puerto Rico</option>
			<option value="Qatar">Qatar</option>
			<option value="Réunion">Réunion</option>
			<option value="Romania">Romania</option>
			<option value="Russian Federation">Russian Federation</option>
			<option value="Rwanda">Rwanda</option>
			<option value="Saint Barthélemy">Saint Barthélemy</option>
			<option value="Saint Helena, Ascension and Tristan da Cunha">Saint Helena, Ascension and Tristan da Cunha</option>
			<option value="Saint Kitts and Nevis">Saint Kitts and Nevis</option>
			<option value="Saint Lucia">Saint Lucia</option>
			<option value="Saint Martin (French part)">Saint Martin (French part)</option>
			<option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon</option>
			<option value="Saint Vincent and the Grenadines">Saint Vincent and the Grenadines</option>
			<option value="Samoa">Samoa</option>
			<option value="San Marino">San Marino</option>
			<option value="Sao Tome and Principe">Sao Tome and Principe</option>
			<option value="Saudi Arabia">Saudi Arabia</option>
			<option value="Senegal">Senegal</option>
			<option value="Serbia">Serbia</option>
			<option value="Seychelles">Seychelles</option>
			<option value="Sierra Leone">Sierra Leone</option>
			<option value="Sint Maarten (Dutch part)">Sint Maarten (Dutch part)</option>
			<option value="Slovakia">Slovakia</option>
			<option value="Slovenia">Slovenia</option>
			<option value="Solomon Islands">Solomon Islands</option>
			<option value="Somalia">Somalia</option>
			<option value="South Africa">South Africa</option>
			<option value="South Georgia and the South Sandwich Islands">South Georgia and the South Sandwich Islands</option>
			<option value="South Sudan">South Sudan</option>
			<option value="Spain">Spain</option>
			<option value="Sri Lanka">Sri Lanka</option>
			<option value="Sudan">Sudan</option>
			<option value="Suriname">Suriname</option>
			<option value="Svalbard and Jan Mayen">Svalbard and Jan Mayen</option>
			<option value="Swaziland">Swaziland</option>
			<option value="Sweden">Sweden</option>
			<option value="Switzerland">Switzerland</option>
			<option value="Syrian Arab Republic">Syrian Arab Republic</option>
			<option value="Tajikistan">Tajikistan</option>
			<option value="Tanzania, United Republic of">Tanzania, United Republic of</option>
			<option value="Thailand">Thailand</option>
			<option value="Togo">Togo</option>
			<option value="Tokelau">Tokelau</option>
			<option value="Tonga">Tonga</option>
			<option value="Trinidad and Tobago">Trinidad and Tobago</option>
			<option value="Tunisia">Tunisia</option>
			<option value="Turkey">Turkey</option>
			<option value="Turkmenistan">Turkmenistan</option>
			<option value="Turks and Caicos Islands">Turks and Caicos Islands</option>
			<option value="Tuvalu">Tuvalu</option>
			<option value="Uganda">Uganda</option>
			<option value="Ukraine">Ukraine</option>
			<option value="United Arab Emirates">United Arab Emirates</option>
			<option value="United Kingdom">United Kingdom</option>
			<option value="United States Minor Outlying Islands">United States Minor Outlying Islands</option>
			<option value="United States of America">United States of America</option>
			<option value="Uruguay">Uruguay</option>
			<option value="Uzbekistan">Uzbekistan</option>
			<option value="Vanuatu">Vanuatu</option>
			<option value="Vatican City State">Vatican City State</option>
			<option value="Venezuela (Bolivarian Republic of)">Venezuela (Bolivarian Republic of)</option>
			<option value="Virgin Islands (British)">Virgin Islands (British)</option>
			<option value="Virgin Islands (U.S.)">Virgin Islands (U.S.)</option>
			<option value="Wallis and Futuna">Wallis and Futuna</option>
			<option value="Western Sahara">Western Sahara</option>
			<option value="Yemen">Yemen</option>
			<option value="Zambia">Zambia</option>
			<option value="Zimbabwe">Zimbabwe</option>

		</select>
                                    
	</div>
                            </div>


                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">

                                <label for="name"><a class="w3-text-red">*</a> Province of registration : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtstate_car" id="MainContent_txtstate_car" type="text" class="w3-input w3-border w3-round-large" placeholder="Province" runat="server"/>
                            </div>






                            
                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a>  Plate (ENG)  : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtLicenseCar" id="MainContent_txtLicenseCar" autocomplete="off" placeholder="Plate (ENG)" onpaste="return false;" class="w3-input w3-border w3-round-large" onkeypress="return Validate(event);" ondrop="return false;" type="Registration No." oncut="return false;" style="text-transform: uppercase;" runat="server"/>
                            </div>

                            <script type="text/javascript">
                                function Validate(event) {
                                    var regex = new RegExp("^[A-Za-z0-9]");
                                    var key = String.fromCharCode(event.charCode ? event.which : event.charCode);
                                    if (!regex.test(key)) {
                                        event.preventDefault();
                                        return false;
                                    }

                                }
                            </script>

                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"> Plate (Local) : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtLicenseLocalCar" id="MainContent_txtLicenseLocalCar" type="Registration No." class="w3-input w3-border w3-round-large" placeholder="Plate (Local)" autocomplete="off" style="text-transform: uppercase;" runat="server"/>
                            </div>


                        </div>


                        <div class="ui stackable four column grid ">

                            <div class="w3-left fields col-md-1 pb-3 "></div>
                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Engine Number : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtNumEngine" id="MainContent_txtNumEngine" type="Serial Engine" class="w3-input w3-border w3-round-large" placeholder="Engine Number" runat="server"/>
                            </div>

                            
                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Engine Capacity : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtEnginCap" id="MainContent_txtEnginCap" type="number" class="w3-input w3-border w3-round-large" placeholder="Engine Capacity" runat="server"/>
                            </div>


                            

                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a>Vehicle Identification Number (VIN) : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtNumcar" id="MainContent_txtNumcar" type="Serial Car" class=" w3-input  w3-border w3-round-large" placeholder="VIN Number" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Gross Weight (kg.) : </label>
                                

                                <asp:TextBox name="ctl00$MainContent$txtWeight" id="MainContent_txtWeight" type="number" class="w3-input w3-border w3-round-large " placeholder="weight" runat="server"/>
                            </div>

                        </div>

                        <div class="ui stackable four column grid " id="divCarAuthorize">
                            <div class="w3-left fields col-md-1 pb-3 "></div>


                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Type : </label>
                                

                                <select name="ctl00$MainContent$ddltypecar" id="MainContent_ddltypecar" class="w3-input w3-border w3-round-large">
		<option selected="selected" value="1">Motorcycle</option>
		<option value="2">Passenger Car (≤ 9 seats)</option>
		<option value="4">Pickup Truck (≤ 3,500 kg)</option>

	</select>
                            </div>
                        </div>

                        <br>
                        <br>
                        

                        <br>
                        <br>
                        
                        
                        
                        <br>
                        <br>

                        
                    
</div>
                    <div class="row">
                        <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 10%; font-size: x-large;">Compulsory motor vehicle insurance (พรบ.)
                    </b></div><b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 10%; font-size: x-large;">
                    <br>
                    <span id="MainContent_lblcomments4" class="w3-text-red"></span>
                    <br>
                    &nbsp; 

                    <div id="MainContent_Page4">
	
                        <div class="ui stackable four column grid ">

                            <div class="w3-left fields col-md-1 pb-3 "></div>

                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">

                                <label for="name"><a class="w3-text-red">*</a> Insurance Company :</label>
                                
                               <asp:TextBox name="ctl00$MainContent$txtActCompany" id="MainContent_txtActCompany" type="text" class="w3-input w3-border w3-round-large" placeholder="Insurance Company" runat="server"/>
                            </div>


                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Policy Number : </label>
                                
                               <asp:TextBox name="ctl00$MainContent$txtActNo" id="MainContent_txtActNo" type="text" class="w3-input w3-border w3-round-large" placeholder="Policy Number" runat="server"/>
                            </div>
                            



                            

                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Start date : </label>
                                
                                 <asp:TextBox name="ctl00$MainContent$txtActStart" id="MainContent_txtActStart" type="text" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Start date" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> End date : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtActExpire" id="MainContent_txtActExpire" type="text" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="End date" runat="server"/>
                            </div>

                        </div>
                        <br>
                        &nbsp;
                        

                        <br>
                        <br>
                        &nbsp; 
  <div class="row">
      <b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 10%; font-size: x-large;">Third-party liability motor vehicle insurance (ประกันภัยบุคคลที่ 3 วงเงินคุ้มครองตามที่กรมการขนส่งทางบกกำหนด)
      </b>
  </div>
                        
                        <br>
                        &nbsp;
                        <br>
                        <div class="ui stackable four column grid " id="divThird-party">
                            <div class="w3-left fields col-md-1 pb-3 "></div>

                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">

                                <label for="name"><a class="w3-text-red">*</a> Insurance Company :</label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtActCompany2" id="MainContent_txtActCompany2" type="text" class="w3-input w3-border w3-round-large" placeholder="Insurance Company" runat="server"/>
                            </div>


                            <div class="w3-left fields col-md-3 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Policy Number : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtActNo2" id="MainContent_txtActNo2" type="text" class="w3-input w3-border w3-round-large" placeholder="Policy Number" runat="server"/>
                            </div>
                            




                            

                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> Start date : </label>
                                
                               <asp:TextBox name="ctl00$MainContent$txtActStart2" id="MainContent_txtActStart2" type="text" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="Start date" runat="server"/>
                            </div>

                            <div class="w3-left fields col-md-2 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <label for="name"><a class="w3-text-red">*</a> End date : </label>
                                
                                <asp:TextBox name="ctl00$MainContent$txtActExpire2" id="MainContent_txtActExpire2" type="text" autocomplete="off" class="w3-input w3-border w3-round-large hasDatepicker" placeholder="End date" runat="server"/>
                            </div>

                        </div>

                        <br>
                        &nbsp;
                        
                        <br>
                        <div class="ui stackable four column grid ">
                            <div class="w3-left fields col-md-1 pb-3 "></div>
                            <div class="w3-left fields col-md-5 pb-3 w3-left-align" style="font-family: 'Kanit', sans-serif; font-size: small;">
                                <p>
                                    Third Party Coverage<br>
                                    - Limit liability for bodily injury or death – no less than 1,000,000 baht per person in an accident<br>
                                    - Limit liability for property – no less than 1,000,000 baht per accident
                                </p>
                                <p>
                                    ความคุ้มครองของประกันภัยบุคคลที่ 3<br>
                                    - ความคุ้มครองความเสียหายต่อชีวิตและร่างกายของบุคคลภายนอกไม่ต่ำกว่า 1,000,000 บาทต่อหนึ่งคนในแต่ละครั้ง<br>
                                    - ความคุ้มครองความเสียหายต่อทรัพย์สินไม่ต่ำกว่า 1,000,000 บาท ในแต่ละครั้ง
                                </p>
                            </div>
                        </div>
                        <br>
                        &nbsp;
                    
</div>

                    <div class="pb-0">
                        <div class="ml-5 pt-5 pb-5 mb-5 pr-5" style="font-family: 'Kanit', sans-serif; font-size: small;">
                            
                            <%--<input type="button" name="ctl00$MainContent$btnSave" value="Save" onclick="javascript:__doPostBack('ctl00$MainContent$btnSave','')" id="MainContent_btnSave" class=" w3-right w3-purple w3-btn w3-round-large w3-large ">--%>
                            <asp:Button ID="MainContent_btnSave" runat="server" CssClass="w3-right w3-purple w3-btn w3-round-large w3-large" 
    Text="Save" OnClick="BtnSave_Click" />

                        </div>
                    </div>
                </b></div><b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 10%; font-size: x-large;">
            </b></div><b class="w3-text-purple" style="position: relative; font-family: 'Kanit', sans-serif; padding-bottom: .21428571rem; border-bottom: 2px solid rgba(34,36,38,.15); margin-left: 10%; font-size: x-large;">






            

            <div id="form5" class=" w3-animate-right fill w3-hide text-dark">
                <br>
                <span id="MainContent_lblcomments8" class="w3-text-red"></span>
                <br>
                <br>
                <div class="ui form grid">
                    <div class="row">
                        <div class=" seven wide column" id="divMap">

                            <iframe id="MainContent_iframeMap" frameborder="0" style="width: 0px; height: 0px;" name="IframeLocation" scrolling="yes" src="https://fvp.dlt.go.th/Map/MapArea.aspx?pro=-1,27">Your browser does not support iframes 
                            </iframe>


                        </div>


                        <script type="text/javascript">
                            $(document).ready(function () {
                                var dv = document.getElementById("divMap").offsetWidth;
                                //alert(dv)
                                if (navigator.userAgent.match(/Android/i)
                                    || navigator.userAgent.match(/webOS/i)
                                    || navigator.userAgent.match(/iPhone/i)
                                    || navigator.userAgent.match(/iPad/i)
                                    || navigator.userAgent.match(/iPod/i)
                                    || navigator.userAgent.match(/BlackBerry/i)
                                    || navigator.userAgent.match(/Windows Phone/i)
                                ) {
                                    var iFrame = document.getElementById("MainContent_iframeMap");
                                    iFrame.style.width = (dv * 0.9) + 'px';
                                    iFrame.style.height = (dv * 1.1) + 'px';
                                }
                                else {
                                    var iFrame = document.getElementById("MainContent_iframeMap");
                                    iFrame.style.width = (dv * 1.2) + 'px';
                                    iFrame.style.height = (dv * 1.6) + 'px';
                                }




                            });

                            function get_IframeMaps(pro) {
                                document.getElementById('MainContent_iframeMap').src = '../Map/MapArea.aspx?pro=' + pro;
                            }

                            function get_IframeMap(pro) {
                                document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src + ',' + pro;
                                console.log(document.getElementById('MainContent_iframeMap').src);
                            }

                            function get_IframeMapDel(pro) {
                                document.getElementById('MainContent_iframeMap').src = document.getElementById('MainContent_iframeMap').src.replace("," + pro, "");
                                console.log(document.getElementById('MainContent_iframeMap').src);
                            }
                        </script>

                        
                        <div class=" nine wide column">
                            <div id="MainContent_Page8">
	
                                <div class=" ten wide field" style="font-family: 'Kanit', sans-serif; font-size: large;">

                                    <label for="Border" class="w3-left">Border Crossing Checkin : </label>

                                    <select name="ctl00$MainContent$ddlBorderCheckin" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlBorderCheckin\',\'\')', 0)" id="MainContent_ddlBorderCheckin" class="w3-input w3-border w3-round-large" data-inline="true">
		<option selected="selected" value="67">ARANYAPRATHET CUSTOMS CHECKPOINT  (SA KAEO)</option>
		<option value="61">BAN DON CUSTOMS CHECKPOINT  (SURAT THANI)</option>
		<option value="90">BAN HUAK BORDER CHECKPOINT  (PHAYAO)</option>
		<option value="41">BAN KHAO DIN TEMPORARY CUSTOMS CHECKPOINT  (SA KAEO)</option>
		<option value="21">BAN LAEM CUSTOMS CHECKPOINT  (PHETCHABURI)</option>
		<option value="88">BAN PRAKOP CUSTOMS HOUSE  (SONGKHLA)</option>
		<option value="58">BAN WA CUSTOMS CHECKPOINT  (PHRA NAKHON SI AYUTTHAYA)</option>
		<option value="27">BANG SAO THONG CUSTOMS CHECKPOINT  (SAMUT PRAKAN)</option>
		<option value="84">BANGKOK PORT CUSTOMS OFFICE  (BANGKOK)</option>
		<option value="7">BETONG border checkpoint  (YALA)</option>
		<option value="66">BETONG CUSTOMS CHECKPOINT  (YALA)</option>
		<option value="57">BUENG KAN CUSTOMS CHECKPOINT  (BUENG KAN)</option>
		<option value="71">BUKETA CUSTOMS HOUSE  (NARATHIWAT)</option>
		<option value="68">CHANTHABURI CUSTOMS CHECKPOINT  (CHANTHABURI)</option>
		<option value="53">CHIANG DAO CUSTOMS CHECKPOINT  (CHIANG MAI)</option>
		<option value="19">CHIANG KHAN CUSTOMS CHECKPOINT  (LOEI)</option>
		<option value="46">CHIANG KHONG CUSTOMS HOUSE  (CHIANG RAI)</option>
		<option value="73">CHIANG SAEN CUSTOMS CHECKPOINT  (CHIANG RAI)</option>
		<option value="45">CHONG CHOM CUSTOMS HOUSE  (SURIN)</option>
		<option value="51">CHONG MEK CUSTOMS HOUSE  (UBON RATCHATHANI)</option>
		<option value="91">Chong Sa-Ngam BORDER CHECKPOINT  (SI SA KET)</option>
		<option value="76">CHUMPHON CUSTOMS CHECKPOINT  (CHUMPHON)</option>
		<option value="63">HUAI YA U CUSTOMS CHECKPOINT  (TAK)</option>
		<option value="72">KANTANG CUSTOMS CHECKPOINT  (TRANG)</option>
		<option value="42">KHEMARAT CUSTOMS CHECKPOINT  (UBON RATCHATHANI)</option>
		<option value="36">KHLONG YAI CUSTOMS CHECKPOINT  (TRAT)</option>
		<option value="29">KO SAMUI CUSTOMS CHECKPOINT  (SURAT THANI)</option>
		<option value="35">KRABI CUSTOMS CHECKPOINT  (KRABI)</option>
		<option value="33">LAEM CHABANG CUSTOMS CHECKPOINT  (CHON BURI)</option>
		<option value="79">LANG SUAN CUSTOMS CHECKPOINT  (CHUMPHON)</option>
		<option value="77">LAT KRABANG CUSTOMS HOUSE  (BANGKOK)</option>
		<option value="47">MAE HONG SON CUSTOMS CHECKPOINT  (MAE HONG SON)</option>
		<option value="56">MAE KLONG CUSTOMS CHECKPOINT  (SAMUT SONGKHRAM)</option>
		<option value="60">MAE SAI CUSTOMS CHECKPOINT  (CHIANG RAI)</option>
		<option value="48">MAE SARIANG CUSTOMS CHECKPOINT  (MAE HONG SON)</option>
		<option value="39">MAE SOT CUSTOMS CHECKPOINT  (TAK)</option>
		<option value="55">MAPTAPHUT CUSTOMS CHECKPOINT  (RAYONG)</option>
		<option value="31">MUKDAHAN CUSTOMS CHECKPOINT  (MUKDAHAN)</option>
		<option value="44">NAKHON PHANOM CUSTOMS CHECKPOINT  (NAKHON PHANOM)</option>
		<option value="22">NAKHON SI THAMMARAT CUSTOMS CHECKPOINT  (NAKHON SI THAMMARAT)</option>
		<option value="70">NARATHIWAT CUSTOMS CHECKPOINT  (NARATHIWAT)</option>
		<option value="52">NONG KHAI CUSTOMS CHECKPOINT  (NONG KHAI)</option>
		<option value="40">PADANG BESAR CUSTOMS HOUSE  (SONGKHLA)</option>
		<option value="18">PAK BARA CUSTOMS CHECKPOINT  (SATUN)</option>
		<option value="78">PAK NAM LANG SUAN CUSTOMS CHECKPOINT  (CHUMPHON)</option>
		<option value="34">PATTANI CUSTOMS CHECKPOINT  (PATTANI)</option>
		<option value="32">PHIBUN MANGSAHAN CUSTOMS CHECKPOINT  (UBON RATCHATHANI)</option>
		<option value="24">PHRA CHEDI CUSTOMS CHECKPOINT  (KANCHANABURI)</option>
		<option value="69">PHRA SAMUT CHEDI CUSTOMS CHECKPOINT  (SAMUT PRAKAN)</option>
		<option value="64">PHUKET CUSTOMS CHECKPOINT  (PHUKET)</option>
		<option value="65">PRACHUAP KHIRI KHAN CUSTOMS CHECKPOINT  (PRACHUAP KHIRI KHAN)</option>
		<option value="50">RANONG CUSTOMS CHECKPOINT  (RANONG)</option>
		<option value="38">SADAO CUSTOMS CHECKPOINT  (SONGKHLA)</option>
		<option value="43">SAMUT PRAKAN CUSTOMS CHECKPOINT  (SAMUT PRAKAN)</option>
		<option value="25">SAMUT PRAKAN CUSTOMS CHECKPOINT  (SAMUT PRAKAN)</option>
		<option value="49">SANGKHLA BURI CUSTOMS HOUSE  (KANCHANABURI)</option>
		<option value="74">SATUN CUSTOMS CHECKPOINT  (SATUN)</option>
		<option value="30">SI CHIANG MAI CUSTOMS CHECKPOINT  (NONG KHAI)</option>
		<option value="54">SICHON CUSTOMS CHECKPOINT  (NAKHON SI THAMMARAT)</option>
		<option value="28">SONGKHLA CUSTOMS CHECKPOINT  (SONGKHLA)</option>
		<option value="26">SU-NGAI KOLOK CUSTOMS CHECKPOINT  (NARATHIWAT)</option>
		<option value="82">SUVARNABHUMI AIRPORT CARGO CLEARANCE CUSTOMS OFFICE  (SAMUT PRAKAN)</option>
		<option value="86">TAK BAI CUSTOMS CHECKPOINT  (NARATHIWAT)</option>
		<option value="62">TAKUA PA CUSTOMS CHECKPOINT  (PHANGNGA)</option>
		<option value="23">THA LI CUSTOMS CHECKPOINT  (LOEI)</option>
		<option value="20">THUNG CHANG CUSTOMS CHECKPOINT  (NAN)</option>
		<option value="75">THUNG LUNG CUSTOMS CHECKPOINT  (SONGKHLA)</option>
		<option value="37">THUNG NUI CUSTOMS CHECKPOINT  (SATUN)</option>
		<option value="59">WANG PRACHAN CUSTOMS CHECKPOINT  (SATUN)</option>

	</select>

                                </div>






                                <div id="MainContent_receive">
		
                                    <div class="ten wide field" style="font-family: 'Kanit', sans-serif; font-size: large;">

                                        <label for="Border" class="w3-left">Place to receive documents :  </label>


                                        <div id="MainContent_updateddladmin">
			
                                                <select name="ctl00$MainContent$ddladmin" id="MainContent_ddladmin" class="w3-input w3-border w3-round-large" data-inline="true">
				<option value="78">AMNAT CHAROEN LAND TRANSPORT OFFICE</option>
				<option value="77">ANG THONG LAND TRANSPORT OFFICE</option>
				<option value="6">BANGKOK LAND TRANSPORTATION OFFICE AREA 5</option>
				<option value="33">BURI RAM LAND TRANSPORT OFFICE</option>
				<option value="13">CHACHOENGSAO LAND TRANSPORT OFFICE</option>
				<option value="15">CHAI NAT LAND TRANSPORT OFFICE</option>
				<option value="16">CHAIYAPHUM LAND TRANSPORT OFFICE</option>
				<option value="12">CHANTHABURI LAND TRANSPORTATION OFFICE</option>
				<option value="19">CHIANG MAI LAND TRANSPORTATION OFFICE</option>
				<option value="18">CHIANG RAI LAND TRANSPORTATION OFFICE</option>
				<option value="14">CHON BURI LAND TRANSPORT OFFICE</option>
				<option value="17">CHUMPHON LAND TRANSPORT OFFICE</option>
				<option value="9">KALASIN LAND TRANSPORT OFFICE</option>
				<option value="10">KAMPHAENG PHET LAND TRANSPORT OFFICE</option>
				<option value="8">KANCHANABURI LAND TRANSPORTATION OFFICE</option>
				<option value="11">KHON KAEN LAND TRANSPORT OFFICE 1</option>
				<option value="7">KRABI LAND TRANSPORT OFFICE</option>
				<option value="58">LAMPANG LAND TRANSPORTATION OFFICE</option>
				<option value="59">LAMPHUN LAND TRANSPORT OFFICE</option>
				<option value="63">LAND TRANSPORTATION 1, SONGKHLA</option>
				<option value="32">LAND TRANSPORTATION, BUENG KAN</option>
				<option value="60">LOEI LAND TRANSPORTATION OFFICE</option>
				<option value="57">LOP BURI LAND TRANSPORT OFFICE, AMPHOE CHAI BADAN BRANCH</option>
				<option value="50">MAE HONG SON LAND TRANSPORT OFFICE</option>
				<option value="48">MAHA SARAKHAM LAND TRANSPORT OFFICE</option>
				<option value="49">MUKDAHAN PROVINCIAL LAND TRANSPORT OFFICE</option>
				<option value="23">NAKHON NAYOK PROVINCIAL LAND TRANSPORTATION OFFICE</option>
				<option value="24">NAKHON PATHOM LAND TRANSPORT OFFICE</option>
				<option value="25">NAKHON PHANOM LAND TRANSPORT OFFICE</option>
				<option value="26">NAKHON RATCHASIMA LAND TRANSPORTATION OFFICE (OFFICE 1)</option>
				<option value="28">NAKHON SAWAN LAND TRANSPORTATION OFFICE</option>
				<option value="27">NAKHON SI THAMMARAT LAND TRANSPORT OFFICE</option>
				<option value="31">NAN LAND TRANSPORT OFFICE</option>
				<option value="30">NARATHIWAT LAND TRANSPORT OFFICE</option>
				<option value="76">NONG BUA LAM PHU LAND TRANSPORTATION OFFICE</option>
				<option value="75">NONG KHAI LAND TRANSPORT OFFICE</option>
				<option value="29">NONTHABURI LAND TRANSPORT OFFICE</option>
				<option value="34">PATHUM THANI LAND TRANSPORT OFFICE</option>
				<option value="37">PATTANI LAND TRANSPORTATION OFFICE</option>
				<option value="40">PHANGNGA LAND TRANSPORT OFFICE</option>
				<option value="41">PHATTHALUNG LAND TRANSPORT OFFICE</option>
				<option value="39">PHAYAO LAND TRANSPORT OFFICE</option>
				<option value="45">PHETCHABUN LAND TRANSPORT OFFICE</option>
				<option value="44">PHETCHABURI LAND TRANSPORT OFFICE</option>
				<option value="42">PHICHIT LAND TRANSPORT OFFICE</option>
				<option value="43">PHITSANULOK LAND TRANSPORTATION OFFICE</option>
				<option value="38">PHRA NAKHON SI AYUTTHAYA LAND TRANSPORT OFFICE</option>
				<option value="46">PHRAE LAND TRANSPORT OFFICE</option>
				<option value="47">PHUKET LAND TRANSPORT OFFICE</option>
				<option value="36">PRACHIN BURI LAND TRANSPORT OFFICE</option>
				<option value="35">PRACHUAP KHIRI KHAN LAND TRANSPORT OFFICE</option>
				<option value="54">RANONG LAND TRANSPORT OFFICE</option>
				<option value="56">RATCHABURI LAND TRANSPORT OFFICE</option>
				<option value="55">RAYONG LAND TRANSPORT OFFICE</option>
				<option value="53">ROI ET LAND TRANSPORT OFFICE</option>
				<option selected="selected" value="68">SA KAEO LAND TRANSPORT OFFICE</option>
				<option value="62">SAKON NAKHON LAND TRANSPORT OFFICE</option>
				<option value="65">SAMUT PRAKAN LAND TRANSPORT OFFICE</option>
				<option value="67">SAMUT SAKHON LAND TRANSPORT OFFICE</option>
				<option value="66">SAMUT SONGKHRAM LAND TRANSPORT OFFICE</option>
				<option value="69">SARABURI LAND TRANSPORT OFFICE</option>
				<option value="64">SATUN LAND TRANSPORT OFFICE</option>
				<option value="61">SI SA KET LAND TRANSPORT OFFICE</option>
				<option value="70">SING BURI LAND TRANSPORT OFFICE</option>
				<option value="71">SUKHOTHAI LAND TRANSPORT OFFICE</option>
				<option value="72">SUPHAN BURI LAND TRANSPORT OFFICE</option>
				<option value="73">SURAT THANI LAND TRANSPORT OFFICE</option>
				<option value="74">SURIN LAND TRANSPORT OFFICE</option>
				<option value="22">TAK LAND TRANSPORTATION OFFICE</option>
				<option value="20">TRANG LAND TRANSPORT OFFICE</option>
				<option value="21">TRAT LAND TRANSPORT OFFICE</option>
				<option value="82">UBON RATCHATHANI LAND TRANSPORT OFFICE 1</option>
				<option value="79">UDON THANI LAND TRANSPORTATION OFFICE 1</option>
				<option value="81">UTHAI THANI LAND TRANSPORT OFFICE</option>
				<option value="80">UTTARADIT LAND TRANSPORT OFFICE</option>
				<option value="52">YALA LAND TRANSPORTATION OFFICE</option>
				<option value="51">YASOTHON LAND TRANSPORT OFFICE</option>

			</select>


                                                <input type="button" name="ctl00$MainContent$btnSetValueddladmin" value="Button" onclick="javascript:__doPostBack('ctl00$MainContent$btnSetValueddladmin','')" id="MainContent_btnSetValueddladmin" style="display: none">
                                                <input type="hidden" name="ctl00$MainContent$HidValueddladmin" id="MainContent_HidValueddladmin">

                                            
		</div>
                                    </div>



                                    <div class="ten wide field">
                                        
                                        <a id="MainContent_lnkSchMap" class="w3-purple w3-btn w3-round-large w3-large" onclick="javascript:w=window.open(&quot;../Map/MapAdmin2.aspx?&quot;,&quot;SearchMapAdminWindow&quot;,&quot;location=0,status=0,scrollbars=yes,resizable=no,width=1024,height=780&quot;);w.focus();" href="javascript://"><i class="fa fa-map-marker" aria-hidden="true"></i> ค้นหา </a>
                                    </div>

                                
	</div>
                                <br>

                                <div id="MainContent_UpdatePanel11">
		

                                        <div class="ten wide field " style="font-family: 'Kanit', sans-serif; font-size: large">

                                            <label for="area" class="w3-left">Province use vehicle : </label>
                                            <br>
                                            <select name="ctl00$MainContent$ddlProvarea" id="MainContent_ddlProvarea" class="w3-input w3-border w3-round-large" data-inline="true">
			<option selected="selected" value="0">All Province</option>
			<option value="37">AMNAT CHAROEN</option>
			<option value="15">ANG THONG</option>
			<option value="10">BANGKOK</option>
			<option value="38">BUENG KAN</option>
			<option value="31">BURI RAM</option>
			<option value="24">CHACHOENGSAO</option>
			<option value="18">CHAI NAT</option>
			<option value="36">CHAIYAPHUM</option>
			<option value="22">CHANTHABURI</option>
			<option value="50">CHIANG MAI</option>
			<option value="57">CHIANG RAI</option>
			<option value="20">CHON BURI</option>
			<option value="86">CHUMPHON</option>
			<option value="46">KALASIN</option>
			<option value="62">KAMPHAENG PHET</option>
			<option value="71">KANCHANABURI</option>
			<option value="40">KHON KAEN</option>
			<option value="81">KRABI</option>
			<option value="52">LAMPANG</option>
			<option value="51">LAMPHUN</option>
			<option value="42">LOEI</option>
			<option value="16">LOP BURI</option>
			<option value="58">MAE HONG SON</option>
			<option value="44">MAHA SARAKHAM</option>
			<option value="49">MUKDAHAN</option>
			<option value="26">NAKHON NAYOK</option>
			<option value="73">NAKHON PATHOM</option>
			<option value="48">NAKHON PHANOM</option>
			<option value="30">NAKHON RATCHASIMA</option>
			<option value="60">NAKHON SAWAN</option>
			<option value="80">NAKHON SI THAMMARAT</option>
			<option value="55">NAN</option>
			<option value="96">NARATHIWAT</option>
			<option value="39">NONG BUA LAMPHU</option>
			<option value="43">NONG KHAI</option>
			<option value="12">NONTHABURI</option>
			<option value="13">PATHUM THANI</option>
			<option value="94">PATTANI</option>
			<option value="82">PHANGNGA</option>
			<option value="93">PHATTHALUNG</option>
			<option value="56">PHAYAO</option>
			<option value="67">PHETCHABUN</option>
			<option value="76">PHETCHABURI</option>
			<option value="66">PHICHIT</option>
			<option value="65">PHITSANULOK</option>
			<option value="14">PHRA NAKHON SI AYUTTHAYA</option>
			<option value="54">PHRAE</option>
			<option value="83">PHUKET</option>
			<option value="25">PRACHIN BURI</option>
			<option value="77">PRACHUAP KHIRI KHAN</option>
			<option value="85">RANONG</option>
			<option value="70">RATCHABURI</option>
			<option value="21">RAYONG</option>
			<option value="45">ROI ET</option>
			<option value="27" disabled="disabled">SA KAEO</option>
			<option value="47">SAKON NAKHON</option>
			<option value="11">SAMUT PRAKAN</option>
			<option value="74">SAMUT SAKHON</option>
			<option value="75">SAMUT SONGKHRAM</option>
			<option value="19">SARABURI</option>
			<option value="91">SATUN</option>
			<option value="33">SI SA KET</option>
			<option value="17">SING BURI</option>
			<option value="90">SONGKHLA</option>
			<option value="64">SUKHOTHAI</option>
			<option value="72">SUPHAN BURI</option>
			<option value="84">SURAT THANI</option>
			<option value="32">SURIN</option>
			<option value="63">TAK</option>
			<option value="92">TRANG</option>
			<option value="23">TRAT</option>
			<option value="34">UBON RATCHATHANI</option>
			<option value="41">UDON THANI</option>
			<option value="61">UTHAI THANI</option>
			<option value="53">UTTARADIT</option>
			<option value="95">YALA</option>
			<option value="35">YASOTHON</option>

		</select>

                                            <div id="MainContent_Paneladd">
			
                                                <div class=" w3-text-purple mt-2 " onclick="document.getElementById('MainContent_btnProv').click();"><i class="fa fa-2x fa-plus-circle" aria-hidden="true"></i></div>
                                            
		</div>
                                        </div>




                                        <div class="ten wide field">
                                            
                                            <div>
			<table cellspacing="0" id="MainContent_gvProv" style="border-collapse:collapse;">
				<tbody><tr>
					<th scope="col">&nbsp;</th>
				</tr><tr>
					<td>
                                                            <span id="MainContent_gvProv_lblarea_id_0" style="display: none">1</span>
                                                            <span id="MainContent_gvProv_lblprov_code_0" style="display: none">27</span>
                                                            <span id="MainContent_gvProv_lblprov_en_0">SA KAEO</span>
                                                            
                                                        </td>
				</tr>
			</tbody></table>
		</div>
                                        </div>



                                        <input type="hidden" name="ctl00$MainContent$hidProvince" id="MainContent_hidProvince">
                                        <input type="submit" name="ctl00$MainContent$btnProv" value="Button" id="MainContent_btnProv" style="display: none">
                                        <input type="submit" name="ctl00$MainContent$btnProvClear" value="Button" id="MainContent_btnProvClear" style="display: none">


                                    
	</div>


                                <br>
                                <br>
                                <br>
                                <br>
                                <br>
                                <br>
                                <br>


                            
</div>

                        </div>

                    </div>

                </div>


            </div>
        
    </b></div>

</asp:Content>