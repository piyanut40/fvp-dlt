<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="RptStatChartTab.aspx.vb" Inherits="Admin_RptStatChartTab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

       
        <link rel="stylesheet" href="../Scripts/jquery-steps/demo/css/jquery.steps.css">
        <script src="../Scripts/jquery-steps/lib/modernizr-2.6.2.min.js"></script>
        <script src="../Scripts/jquery-steps/lib/jquery-1.9.1.min.js"></script>
        <script src="../Scripts/jquery-steps/lib/jquery.cookie-1.3.1.js"></script>
        <script src="../Scripts/jquery-steps/build/jquery.steps.js"></script>
 <header class="w3-container" style="margin-top: 15px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ภาพรวมสถิติ<asp:Label ID="lblHead" runat="server" Text=""></asp:Label> </b></a><br /><br/>
</header>
<%--        <h1>ภาพรวมกราฟสรุปสถิติ<asp:Label ID="lblHead" runat="server" Text=""></asp:Label> </h1>--%>
<div class="content">
            

            <script>
                $(function () {
                    $("#wizard").steps({
                        headerTag: "h2",
                        bodyTag: "section",
                        transitionEffect: "none",
                        enableFinishButton: false,
                        enablePagination: false,
                        enableAllSteps: true,
                        titleTemplate: "#title#",
                        cssClass: "tabcontrol"
                    });
                });
            </script>

    <style type="text/css">
        
    </style>
            <div id="wizard">
                <h2>รถที่ได้รับอนุญาตให้เข้ามาในราชอาณาจักร</h2>
                <section>
                    <iframe runat="server" id="Iframe1" enableviewstate="true" frameborder="0" name="Iframe1" scrolling="yes" 
                        width="100%" height="102%"  src="" >Your browser does not support iframes 
                    </iframe>
                </section>

                <%--<h2>ข้อมูลรถที่ขออนุญาต</h2>--%>
                <h2>ข้อมูลรถ</h2>
                <section>
                    <%--ข้อมูลรถที่ขออนุญาต--%>
                    <iframe runat="server" id="Iframe2" enableviewstate="true" frameborder="0" name="Iframe2" scrolling="yes" 
                        width="100%" height="100%"  src="" >Your browser does not support iframes 
                    </iframe>
                </section>

                <%--<h2>ข้อมูลด่านศุลกากรเข้า-ออก</h2>--%>
                <h2>ข้อมูลด่านศุลกากร</h2>
                <section>
                     <%--ข้อมูลด่านศุลกากรเข้า-ออก--%>
                     <iframe runat="server" id="Iframe3" enableviewstate="true" frameborder="0" name="Iframe3" scrolling="yes" 
                        width="100%" height="100%"  src="" >Your browser does not support iframes 
                    </iframe>
                </section>

                <%--<h2>ข้อมูลผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอ</h2>--%>
                <h2>ข้อมูลผู้ประกอบธุรกิจนำเที่ยว</h2>
                <section>
                     <%--ข้อมูลผู้ประกอบธุรกิจนำเที่ยวที่ยื่นขอ--%>
                     <iframe runat="server" id="Iframe4" enableviewstate="true" frameborder="0" name="Iframe4" scrolling="yes" 
                        width="100%" height="100%"  src="" >Your browser does not support iframes 
                    </iframe>
                </section>
                
                <h2>ข้อมูลสำนักงานขนส่ง</h2>
                <section>
                     <%--ข้อมูลสำนักงานขนส่ง--%>
                      <iframe runat="server" id="Iframe5" enableviewstate="true" frameborder="0" name="Iframe5" scrolling="yes" 
                        width="100%" height="100%"  src="" >Your browser does not support iframes 
                    </iframe>
                </section>

                <h2>ข้อมูลประเทศที่จดทะเบียน</h2>
                <section>
                     <%--ข้อมูลประเทศที่จดทะเบียน--%>
                      <iframe runat="server" id="Iframe6" enableviewstate="true" frameborder="0" name="Iframe6" scrolling="yes" 
                        width="100%" height="100%"  src="" >Your browser does not support iframes 
                    </iframe>
                </section>
            </div>
        </div>
</asp:Content>

