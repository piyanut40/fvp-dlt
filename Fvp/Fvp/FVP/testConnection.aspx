<%@ Page Language="VB" AutoEventWireup="false" CodeFile="testConnection.aspx.vb" Inherits="testConnection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    <br />
    -------------------- get current-number-of-connections-in-a-postgresql  --------------------
    <br /> Query : <asp:TextBox ID="TextBox5" Width="400px" runat="server" Text="select max_conn,used,res_for_super,max_conn-used-res_for_super res_for_normal from 
  (select count(*) used from pg_stat_activity) t1,
  (select setting::int res_for_super from pg_settings where name=$$superuser_reserved_connections$$) t2,
  (select setting::int max_conn from pg_settings where name=$$max_connections$$) t3" 
            TextMode="MultiLine"></asp:TextBox> 
          <asp:Button ID="Button7"  runat="server" Text="get connection used" /><br />
    <br /> Query : <asp:TextBox ID="TextBox6" Width="400px" runat="server" Text="select * from pg_stat_activity where datname = 'Border_Transport'"></asp:TextBox> 
          <asp:Button ID="Button8"  runat="server" Text="get pg_stat_activity" /><br />
    <br /> Query : <asp:TextBox ID="TextBox4" Width="400px" runat="server" Text="SELECT * FROM pg_stat_database"></asp:TextBox> 
          <asp:Button ID="Button6"  runat="server" Text="get pg_stat_database" /><br />
    <br /> 
    <br />
    <br />
    <br />
    -------------------- getDataTable ---------------------------
    <br /> Query : <asp:TextBox ID="TextBox1" Width="400px" runat="server" Text="SELECT * FROM public.status order by status_id "></asp:TextBox> 
          <asp:Button ID="Button1"  runat="server" Text="getDataTable" /><br />
    <br />
    -------------------- ReadDataTable โค้ดใหม่ By.ท๊อป ---------------------------
    <br /> Query : <asp:TextBox ID="TextBox2" Width="400px" runat="server" Text="SELECT * FROM public.status order by status_id "></asp:TextBox> 
          <asp:Button ID="Button2"  runat="server" Text="ReadDataTable" /><br />
    <br />
    -------------------- ExecuteReader ---------------------------
    <br /> Query : <asp:TextBox ID="TextBox3" Width="400px" runat="server" Text="SELECT * FROM public.status order by status_id "></asp:TextBox> 
          <asp:Button ID="Button3"  runat="server" Text="ExecuteReader" /><br />
    <br />
    -------------------- ExecuteScalar adminbt ---------------------------
    <br /> <%--Query : <asp:TextBox ID="TextBox4" Width="400px" runat="server" Text="SELECT * FROM public.status order by status_id "></asp:TextBox>--%> 
          <asp:Button ID="Button4"  runat="server" Text="ExecuteScalar adminbt" /><br />
    <br />
    -------------------- ExecuteScalar ขนส่งจังหวัด ---------------------------
    <br /> <%--Query : <asp:TextBox ID="TextBox5" Width="400px" runat="server" Text="SELECT * FROM public.status order by status_id "></asp:TextBox>--%> 
          <asp:Button ID="Button5"  runat="server" Text="ExecuteScalar ขนส่งจังหวัด" /><br />
    <br />
    -------------------- ExecuteScalar genPass ---------------------------
    <br /> UserName : <asp:TextBox ID="TextBox9" Width="400px" runat="server" Text=""></asp:TextBox> 
          <asp:Button ID="Button9"  runat="server" Text="Gen Password" /><br />
    <br />
    </div>
    </form>
</body>
</html>
