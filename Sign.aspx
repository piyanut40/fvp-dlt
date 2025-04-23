<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sign.aspx.vb" Inherits="Sign" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Styles/w3Home.css">
    <style type="text/css">
@media print {
  @page { margin: 0; size: A3;  margin-right:14.28cm; }
  body { margin: 1.2cm; , margin-right:3.0cm; }
}

@font-face{
    font-family:'THSarabunPSK';
    src:url('font/THSarabun.woff');
}


.container {
  position: relative;
  text-align: center;
  color: black;
  font-family: THSarabunPSK;
}
    

.date{
    position:absolute;
    top:331px;
    left:320px;
    
}

.start_date{
    position: absolute;
    top: 331px;
    left: 170px;
    font-style: inherit;
    font-size: 55px;
}

.end_date{
    position: absolute;
    top: 462px;
    left: 170px;
    font-style: inherit;
    font-size: 55px;
}

.province {
    position: absolute;
    top: 25px;
    right: 68px;
    left: 582px;
}
.signth{
  position: absolute;
  top: 118px;
  right: 100px;
  left: 150px;
}

.plate{
    position: absolute;
    top: 145px;
    left: 135px;
    font-size: 45px;
}
.platename{
    position:absolute;
    top:178px;
    left:250px;
    
}
.countryname{
    position:absolute;
    top:178px;
    right:380px;

}

.country{
   position: absolute;
    top: 206px;
    left: 138px;
    font-size: 47px;

}
.areaname{
    position:absolute;
    top:328px;
    left:250px;
}
.area{
    position:absolute;
    top:193px;
    left:220px;
    right:200px;
    text-align:center;
}


.ownername{
    position:absolute;
    top:428px;
    right:410px;
}

.owner{
    position: absolute;
       top: 309px;
    left: 456px;
}

.drivename{
    position:absolute;
    top:488px;
    right:570px;
}

.drive1{
    position: absolute;
    top: 373px;
    left: 456px;
}
.drive2{
    position: absolute;
    top: 404px;
    left: 456px;
}
.drive3{
    position: absolute;
    top: 435px;
    left: 456px;
}

.typename{
    position:absolute;
    top:648px;
    right:520px;
   
}
.type{
    position: absolute;
    top: 474px;
    left: 473px;
    right: 140px;
    white-space: nowrap;
    overflow: hidden;
 
}

.colorsname{
    position:absolute;
    top:695px;
    right:320px;
}
.colors{
    position: absolute;
    top : 547px;
    left: 535px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.brandname{
    position:absolute;
    top:695px;
    right:560px;
}
.brand{
   position: absolute;
    top: 511px;
    left: 523px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.modelname{
    position:absolute;
    top:660px;
    right:560px;
    
    
}

.model{
    position:absolute;
    top:505px;
    left:670px;
    right:60px;
    white-space: nowrap; 
    overflow: hidden;
    text-overflow: ellipsis; 
    
}


.checkinname{
    position:absolute;
    top:770px;
    left:560px;
}
.checkin{
  position: absolute;
       top: 600px;
    left: 487px;
    right: 36px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    
    
}

.checkoutname{
    position:absolute;
    top:820px;
    left:560px;
}
.checkout{
    position: absolute;
   top: 634px;
    left: 457px;
    right: 24px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.registrar{
    position: absolute;
   top: 712px;
    left: 450px;
    right: 58px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.registrar_position{
    position: absolute;
   top: 732px;
    left: 450px;
    right: 58px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.qrcode{
    position: absolute;
    top: 565px;
    left: 183px;
}

.qrcode2{
    position: absolute;
    top: 900px;
    left: 139px;
}

.piccar{
    position:absolute;
    top:400px;
    left:250px;
    
}

.border { border-width: 3px; border-color: black; border-style:solid;} 
.bordercut {border-width: 3px; border-color:Black; border-style:dashed;}
.cut {}
   
    </style>
</head>
<body>






    <asp:DataList ID="dtl1" runat="server">
    <ItemTemplate>

    <div class="container">
    <div class="bordercut ">
     <img alt="" class="border w3-margin" src="<%# Eval("imgsign")%>" width=785px; />

    
     </div>
      <img class="cut w3-right" src="image/cutsign.png" width=50px;  />
 



     <asp:Label ID="Label4" class="province" runat="server"  Text="" Font-Bold="True" Font-Size="25px"><%#Eval("permit") %></asp:Label>

     <asp:Label ID="Label2" class="start_date" runat="server" Text="" Font-Bold="True"><%# Eval("start_date")%></asp:Label>

     <asp:Label ID="Label3" style="display:none" class="right1" runat="server" Text="" Font-Size="XX-Large"><%# Eval("start_date")%></asp:Label>

     <asp:Label ID="Label30" class="end_date" runat="server" Text="" Font-Bold="True" ><%# Eval("exp_date")%></asp:Label>
     <asp:Label ID="Label31"  style="display:none" class="right2" runat="server" Text="" Font-Size="XX-Large"><%# Eval("exp_date")%></asp:Label>



     <asp:Label ID="Label5" class="plate" runat="server" Text="" Font-Bold="True"><%#Eval("plate") %></asp:Label>


     <asp:Label ID="Label18" class="country" runat="server" Text="" Font-Bold="True"><%#Eval("country_car") %></asp:Label>
     <asp:Label ID="Label17" class="area" runat="server" Text="" Font-Size="X-Large" Font-Bold="True"><%#Eval("area") %></asp:Label>


     <asp:Label ID="Label19" class="owner" runat="server" Text="" Font-Size="25px" ><%# Eval("nameowner")%></asp:Label>


     <asp:Label ID="Label20" class="drive1" runat="server" Text="" Font-Size="25px" ><%# Eval("name1")%></asp:Label>
     <asp:Label ID="Label21" class="drive2" runat="server" Text="" Font-Size="25px" ><%# Eval("name2")%></asp:Label>
     <asp:Label ID="Label22" class="drive3" runat="server" Text="" Font-Size="25px" ><%# Eval("name3")%></asp:Label>



      <asp:Label ID="Label23" class="type" runat="server" Text="" Font-Size="XX-Large"><%# Eval("type_name")%></asp:Label>
      <asp:Label ID="Label24" class="colors" runat="server" Text="" Font-Size="XX-Large" ><%# Eval("colors")%></asp:Label>
      <asp:Label ID="Label25" class="brand" runat="server" Text="" Font-Size="XX-Large" ><%# Eval("brands")%></asp:Label>
      <asp:Label ID="Label26" class="model" style="display:none" runat="server" Text="" Font-Size="XX-Large" ><%# Eval("model")%></asp:Label>
      <asp:Label ID="Label27" class="checkin" runat="server" Text="" Font-Size="XX-Large" ><%# Eval("checkin")%></asp:Label>
      <asp:Label ID="Label28" class="checkout" runat="server" Text="" Font-Size="XX-Large" ><%# Eval("checkout")%></asp:Label>

      <asp:Label ID="Label1" class="registrar" runat="server" Text="" Font-Size="X-Large" ><%# Eval("registrar")%></asp:Label>
      <asp:Label ID="Label6" class="registrar_position" runat="server" Text="" Font-Size="X-Large" ><%# Eval("regis_pos")%><b> / Registrar</b></asp:Label>
        <img alt="" class="qrcode" src="<%# Eval("qrcode")%>" width=150px; />

           

           </div>
               <img alt="" style="margin-left:0" class="qrcode2" src="<%# Eval("qrcode")%>" width=700px; />
    </ItemTemplate>
   
    </asp:DataList>
   


<script type="text/javascript">
 window.print()
</script>
 
</body>
</html> 
