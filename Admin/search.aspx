<%@ Page Language="VB" AutoEventWireup="false" CodeFile="search.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="Admin_search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/datatables.min.css" rel="stylesheet">
<script type="text/javascript" src="../Scripts/datatables.min.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
    <h5><b><i class="fa fa-dashboard"></i> <% Response.Write(text)%></b></h5>
</header>
<style>


td{
    text-align : center;
}
</style>
 <table id="dtBasicExample" class="table table-striped table-bordered table-lg table-center" cellspacing="0" width="100%">
  <thead>
    <tr>
      <th class="th-sm">No.
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
      <th class="th-sm">เลขที่อ้างอิงใบขออนุญาต
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
      <th class="th-sm"><%Response.Write(name)%>
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
      <th class="th-sm">ข้อมูลรถ
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
       <th class="th-sm">สถานะใบอนุญาต
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
      <th class="th-sm">วันที่ขอใบอนุญาต
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
      <th class="th-sm">จัดการ
       
      </th>
      <th class="th-sm">เอกสารใบอนุญาต
        <i class="fa fa-sort float-right" aria-hidden="true"></i>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>1</td>
      <td>A10110</td>
      <td>Mr.Thogchai Macinthai</td>
      <td>Honda Civic</td>
      <td>รอรับรองผล</td>
      <td>25-ต.ค-61</td>
     <td><a href="MgtEdit.aspx"><i class="fa fa-cog fa-2x" aria-hidden="true"></i></a></td>
      <td><a target="_blank" href="../Report/QRCode.aspx"><i class="fa fa-file fa-2x" aria-hidden="true"></i></td></a>
    </tr>
    <tr>
      <td>2</td>
      <td>A102210</td>
      <td>Ms.Srisuda wanrai</td>
      <td>Nissan Almera</td>
      <td>ผ่านการรับรอง</td>
      <td>25-ก.ย.-61</td>
     <td><a href="MgtEdit.aspx"><i class="fa fa-cog fa-2x" aria-hidden="true"></i></a></td>
      <td><a target="_blank" href="../Report/QRCode.aspx"><i class="fa fa-file fa-2x" aria-hidden="true"></i></td></a>
    </tr>
    <tr>
      <td>3</td>
      <td>A10320</td>
      <td>Mr.Noparat urairat</td>
      <td>Toyota Vios</td>
      <td>ผ่านการรับรอง</td>
      <td>15-ม.ค.-61</td>
     <td><a href="MgtEdit.aspx"><i class="fa fa-cog fa-2x" aria-hidden="true"></i></a></td>
      <td><a target="_blank" href="../Report/QRCode.aspx"><i class="fa fa-file fa-2x" aria-hidden="true"></i></td></a>
    </tr>
    
  </tbody>
</table>

<script>

$('#dtBasicExample').dataTable( {
    "oLanguage": {
      "sLengthMenu": "<h4>แสดงผล _MENU_ ราย</h4>",
      "sSearch": "ค้นหา :",
      "sInfoEmpty": "ไม่พบข้อมูล",
      "sEmptyTable": "ไม่พบข้อมูล",
      "sZeroRecords": "ไม่พบข้อมูล",
      "sInfo": "จำนวนข้อมูลทั้งหมด _TOTAL_ ราย แสดงผล(_START_ ถึง _END_)"
  }
});
    $(document).ready(function () {
        $('#dtBasicExample').DataTable();
        $('.dataTables_length').addClass('bs-select');
    });


</script>

</asp:Content>