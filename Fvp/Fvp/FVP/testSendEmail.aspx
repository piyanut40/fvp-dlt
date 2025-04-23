<%@ Page Language="VB" AutoEventWireup="false" CodeFile="testSendEmail.aspx.vb" Inherits="testSendEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>



<body>
    <form id="form1" runat="server">
    -------------------- ส่งเมล์ ---------------------------
    <br /> email : <asp:TextBox ID="txtemail" runat="server" Text=""></asp:TextBox>
    <br /> _Name : <asp:TextBox ID="txt_Name" runat="server" Text="นางทดสอบ ส่งเมลล์"></asp:TextBox>
    <br /> token : <asp:TextBox ID="txttoken" Text="CD1ECB0F59B80CF97D2D2932FF062F08" runat="server"></asp:TextBox>
    <br /> typename_th : <asp:TextBox ID="txttypename_th" Text="รถท้องถิ่น" runat="server"></asp:TextBox>
    <br /> status : <asp:TextBox ID="txtstatus" Text="2" runat="server"></asp:TextBox>
    <br /> reason : <asp:TextBox ID="txtreason" Text="ส่งเมล ภาษาไทย เป็น ต่างดาว" runat="server"></asp:TextBox>
    <br /> <asp:Button ID="Button1"  runat="server" Text="ส่งเมล์" /><br />

    <br /><br />-------------------- series เดือน ---------------------------
    <div>
    <br /> sdate : <asp:TextBox ID="txtsdate" runat="server" Text="01/01/2019"></asp:TextBox>
    <br /> edate : <asp:TextBox ID="txtedate" runat="server" Text="14/06/2019"></asp:TextBox>
    <br /><asp:Button ID="Button2"  runat="server" Text="series เดือน" />
    <br /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>

     <br /><br />-------------------- ส่งเมล์ ---------------------------
     <br /> Name : <asp:TextBox ID="txtname" runat="server" Text="ทดสอบ ส่งเมล"></asp:TextBox>
     <br /> email : <asp:TextBox ID="txtmail" runat="server" Text=" "></asp:TextBox>
     <br /> smtp : <asp:TextBox ID="txtsmtp" runat="server" Text=" "></asp:TextBox>
     <br /> port : <asp:TextBox ID="txtport" runat="server" Text=" "></asp:TextBox>
            <br /> <asp:Button ID="Button3"  runat="server" Text="ส่งเมล์แบบ MailGoThai" /><br />

     <%-- <br /><br />-------------------- copy paste not allowed on textbox ---------------------------
         <br />   plate2 :<input type="text" id="plate1" oncopy="return false" onpaste="return false" >
         <br />   plate3 :<input type="text" id="plate2" onselectstart="return false" onpaste="return false;" oncopy="return false" oncut="return false" ondrag="return false" ondrop="return false" autocomplete="off">--%>

              <br /><br />-------------------- ส่งเมล์ ---------------------------
     <br /> Name นทท. : <asp:TextBox ID="txtname1" runat="server" Text="ทดสอบส่งเมล นักท่องเที่ยว"></asp:TextBox>
     <br /> Name ผปก. : <asp:TextBox ID="txtname2" runat="server" Text="ทดสอบส่งเมล ผู้ประกอบการ"></asp:TextBox>
     <br /> email นทท. : <asp:TextBox ID="txtmail1" runat="server" Text=""></asp:TextBox>
     <br /> email ผปก. : <asp:TextBox ID="txtmail2" runat="server" Text=""></asp:TextBox>
     <br /> smtp : <asp:TextBox ID="txtsmtp1" runat="server" Text=""></asp:TextBox>
     <br /> port : <asp:TextBox ID="txtport1" runat="server" Text=""></asp:TextBox>
            <br /> <asp:Button ID="Button4"  runat="server" Text="ส่งเมล์" /><br />
    </form>
</body>
</html>
