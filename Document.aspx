<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Document.aspx.vb" Inherits="Document" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Styles/w3Home.css">
    <style type="text/css">
@media print {
  @page { margin: 0 ; }
  body { margin: 0.3cm; }
}
    </style>
</head>
<body>
 <asp:DataList ID="dtl1" runat="server" Width="100%" CellPadding="4" CellSpacing="4">
    <ItemTemplate>  
    <table style="width: 120%;" cellpadding="4" cellspacing="4">
       <tr>
            <td>
                <br><asp:Label ID="lblexpdate" runat="server" Text="วันหมดอายุ: "><%# Eval("exp_date") %></asp:Label><br>
                  <asp:Label ID="Label6" runat="server" Text="เลขที่เครื่องหมายแสดงการใช้รถ: "><%# Eval("license_no") %></asp:Label> 
            </td>
            <td  style="z-index=6" align=center >
                 <img alt="" src="image/HeaderPrint.jpg" width=100px />  &nbsp;
            </td>
            <td>
                
            </td>
        </tr>

        <tr>
            <td>
               &nbsp;
            </td>
            <td style="z-index=5"align=center>
              <asp:Label ID="lbllicenseno" runat="server" Text="" Font-Bold="True" Font-Size="15"><%# Eval("doc_th") %></asp:Label>
            </td>
            <td>
                
            </td>
        </tr>

        <tr>
            <td>
           &nbsp; &nbsp; &nbsp; <asp:Label ID="Label1" runat="server" Text="1.ข้อมูลคนขับ"></asp:Label> 
            </td>
            <td>
             &nbsp;
            </td>
             <td>
             &nbsp;
            </td>
        </tr>

        <tr>
            <td>
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="ชื่อ : "><%# Eval("name") %></asp:Label> 
            </td>
            <td>
               &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="นามสกุล : "><%# Eval("surname") %></asp:Label> 
            </td>
             <td>
             &nbsp;
            </td>
        </tr>

         <tr>
            <td colspan=3>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Text="เลขประจำตัวประชาชน : "><%# Eval("passport_no") %></asp:Label> 
            </td>
            <td> 
             &nbsp;
            </td>
            <td> 
             &nbsp;
            </td>
        </tr>

         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label5" runat="server" Text="Email: "><%# Eval("email")%></asp:Label> 
            </td>
            <td> 
             &nbsp;
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

         <tr>
            <td colspan=2>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label7" runat="server" Text="ที่อยู่ : "><%# Eval("address")%></asp:Label> 
            </td>
            <td> 
             &nbsp;
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

        
         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label8" runat="server" Text="เมือง : "><%# Eval("state")%></asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label9" runat="server" Text="เขต : "><%# Eval("county")%></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

        
         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label10" runat="server" Text="ประเทศ : "><%# Eval("countries")%></asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label11" runat="server" Text="รหัสไปรษณีย์ : "><%# Eval("zipcode")%></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>
        
         <tr>
            <td>
           &nbsp; &nbsp; &nbsp; <asp:Label ID="Label12" runat="server" Text="2.ข้อมูลผู้ขับ"></asp:Label> 
            </td>
            <td>
             &nbsp;
            </td>
             <td>
             &nbsp;
            </td>
        </tr>

        <tr>
            <td width="30%">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label13" runat="server" Text="ชื่อ: "><%# Eval("name")%></asp:Label> 
            </td>
            <td width="30%">
               &nbsp; <asp:Label ID="Label14" runat="server" Text="นามสกุล: "><%# Eval("surname")%></asp:Label> 
            </td>
             <td width="40%">
                <asp:Label ID="Label15" runat="server" Text="Passport No: "><%# Eval("passport_no") %></asp:Label> 
            </td>
        </tr>

         <% Response.Write(Spare_driver)%>

         <tr>
            <td>
           &nbsp; &nbsp; &nbsp; <asp:Label ID="Label16" runat="server" Text="3.ข้อมูลยานพาหนะ"></asp:Label> 
            </td>
            <td>
             &nbsp;
            </td>
             <td>
             &nbsp;
            </td>
        </tr>
         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label17" runat="server" Text="ยี่ห้อรถ: "><%# Eval("brands")%></asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label18" runat="server" Text="ประเภทรถ: "><%# Eval("typecar_en")%></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label19" runat="server" Text="แบบรถ: "><%# Eval("model")%></asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label20" runat="server" Text="สีรถ: "><%# Eval("colors") %></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>
         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label21" runat="server" Text="น้ำหนักรวม: "><%# Eval("weight")%> kg</asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label22" runat="server" Text="จำนวนที่นั่ง: "><%# Eval("seat") %></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>
         <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label23" runat="server" Text="เลขเครื่องยนต์: "><%# Eval("engine_no")%></asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label24" runat="server" Text="ประเทศที่จดทะเบียนรถ: "><%# Eval("country_car")%></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>
          <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label25" runat="server" Text="เลขตัวรถ : "><%# Eval("car_no")%></asp:Label> 
            </td>
            <td> 
           
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

           <tr>
            <td>
           &nbsp; &nbsp; &nbsp; <asp:Label ID="Label26" runat="server" Text="4.ข้อมูล พรบ."></asp:Label> 
            </td>
            <td>
             &nbsp;
            </td>
             <td>
             &nbsp;
            </td>
        </tr>

          <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label27" runat="server" Text="เลขที่กรมธรรม์: "><%# Eval("act_no")%></asp:Label> 
            </td>
            <td> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label28" runat="server" Text="ชื่อผู้เอาประกันภัย: "><%# Eval("act_name")%></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

          <tr>
            <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label29" runat="server" Text="ชื่อบริษัท: "><%# Eval("act_company")%></asp:Label> 
            </td>
            <td colspan=2> 
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label30" runat="server" Text="ระยะเวลาประกันภัย: "><%# Eval("exp")%></asp:Label> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

            <tr>
            <td>
           <br>&nbsp; &nbsp; &nbsp; <asp:Label ID="Label31" runat="server" Text="5.ข้อมูลการเดินทาง"></asp:Label> 
            </td>
            <td>
             &nbsp;
            </td>
             <td>
             &nbsp;
            </td>
        </tr>

         <tr>
            <td colspan=2>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label32" runat="server" Text="ด่านพรหมแดนขาเข้า: "><%# Eval("check_in")%></asp:Label> 
            </td>
            <td>
            </td>
            <td style="text-align:center;"> 
             
            </td>
       
        </tr>
        <tr>
            <td colspan=2>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;    <asp:Label ID="Label33" runat="server" Text="ด่านพรหมแดนขาออก: "><%# Eval("check_out")%></asp:Label>
            </td>
            <td>
            </td>
            <td style="text-align:center;"> 
             
            </td>
       
        </tr>

       <tr>
            <td colspan=3>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label34" runat="server" Text="ท้องที่ใช้รถ: "><%# Eval("area")%></asp:Label> 
            </td>
            <td> 
            </td>
              <td> 
               &nbsp;
            </td>
        </tr>

         <tr>
            <td><br>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <img alt="" src="<%# Eval("qrcode")%>" width=100px />
            </td>
            <td colspan=2 align=center> 
                <asp:Label ID="Label41" runat="server" Text="ออกให้ ณ วันที่ " Font-Bold="True" Font-Size="Medium"><%# Eval("start_date")%></asp:Label>
                 <asp:Image ID="Image1"  runat="server" ImageUrl="~/image/dlt.png" />
            </td>
              <td> 
            </td>
        </tr>


    </table>
                </ItemTemplate>
 </asp:DataList>

<script type="text/javascript">
window.print()
</script>
 
</body>
</html> 
