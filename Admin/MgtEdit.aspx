<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtEdit.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="MgtEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <header class="w3-container" style="padding-top:22px">
    <h5><b><i class="fa fa-dashboard"></i>  จัดการการขออนุญาตใช้รถในราชอาณาจักรชั่วคราว</b></h5>
</header>


<div class="container col-12 bg__white pt-5 pb-5 pl-5 log-in--container position-relative">
    <form id="Form1" class="form-horizontal" align=center>     
        <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">ชื่อผู้ใช้รถ</label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                          <%--<i class="fa fa-id-card-o" aria-hidden="true"></i>--%>
                        </div>
                     <asp:TextBox ID="txtName" type="Name" class="form-control" runat="server" placeholder="Name">MR.THONGCHAI MACINTHAI</asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">ที่อยู่ :</label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                        <%-- <i class="fa fa-map-marker" aria-hidden="true"></i>--%>
                        </div>
                        <asp:TextBox ID="txtAddress" type="Address" class="form-control" runat="server" placeholder="Address">123</asp:TextBox>
                        <asp:TextBox ID="txtRoad" type="Address" class="form-control" runat="server" placeholder="Road">Bangna-Trad</asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                        </div>
                        <asp:TextBox ID="txtTumbol" type="Address" class="form-control" runat="server" placeholder="Tumbol">Samrong</asp:TextBox>
                       <asp:TextBox ID="txtAmphoe" type="Address" class="form-control" runat="server" placeholder="Amphoe">Prakanong</asp:TextBox>
                       <asp:TextBox ID="txtProvince" type="Address" class="form-control" runat="server" placeholder="Province">Bangkok</asp:TextBox>
                       <asp:TextBox ID="txtPostal" type="Address" class="form-control" runat="server" placeholder="Postal">10234</asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div id="cardNo" class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">รหัสประจำตัวประชาชน</label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                         <%-- <i class="fa fa-id-card-o" aria-hidden="true"></i>--%>
                        </div>
                     <asp:TextBox ID="txtIDCard" type="id" class="form-control" runat="server" placeholder="ID Card No. or Passport No.">11038954231</asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

         <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">สัญชาติ : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                       <%--   <i class="fa fa-flag-checkered" aria-hidden="true"></i>--%>
                        </div>
                   <asp:DropDownList ID="ddlNational" runat="server" class="form-control">
                       <asp:ListItem>Thailand</asp:ListItem>
                       <asp:ListItem>Malaysia</asp:ListItem>
                       <asp:ListItem>Cambodia</asp:ListItem>
                       <asp:ListItem>Laos</asp:ListItem>
                       <asp:ListItem>Singapore</asp:ListItem>
                       <asp:ListItem>Myanmar</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

         <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">เบอร์โทรศัพท์ : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                       <%--  <i class="fa fa-mobile" aria-hidden="true"></i>--%>
                        </div>
                     <asp:TextBox ID="txtPhone" type="Telephone" class="form-control" runat="server" placeholder="Telephone">0845612345</asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

         <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">อีเมล : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                        <%--  <i class="fa fa-at" aria-hidden="true"></i>--%>
                        </div>
                        <asp:TextBox ID="txtEmail" type="Email" class="form-control" runat="server" placeholder="@email">Thongchai.mail@hotmail.com</asp:TextBox>
                    </div>
                </div>
            </div>
        </div>




        <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">เพศ : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                       <%--   <i class="fa fa-venus-mars" aria-hidden="true"></i>--%>
                        </div>
                   <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                       <asp:ListItem Value="1">Man</asp:ListItem>
                       <asp:ListItem Value="2">Woman</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

   
    <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">รูปประจำตัว : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                       <%--   <i class="fa fa-venus-mars" aria-hidden="true"></i>--%>
                        </div>
                            <img src="../image/Icon2/businessman.png" / height="300" width="300">
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">รูปภาพรถ : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                        <div class="input-group-addon" style="width: 2.6rem">
                       <%--   <i class="fa fa-venus-mars" aria-hidden="true"></i>--%>
                        </div>
                            <img src="../Upload/car.jpg" height="300" width="300">
                    </div>
                </div>
            </div>
        </div>
        <br>
          <div class="row">
            <div class="col-md-3 field-label-responsive">
                <label for="password">รายละเอียดการเดินทาง : </label>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                       
                            <label for="password">ด่านพรมแดนขาเข้า : </label> &nbsp;&nbsp;  <asp:TextBox ID="txtCheckin" type="Address" class="form-control" runat="server" placeholder="Tumbol">Chaingrai</asp:TextBox>
                          
                    </div>
                </div>
                 <div class="form-group">
                    <div class="input-group mb-3 mr-sm-2 mb-sm-0">
                    
                          <label for="password">ด่านพรมแดนขาออก : </label>  <asp:TextBox ID="txtCheckout" type="Address" class="form-control" runat="server" placeholder="Tumbol">Chaingrai</asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group mb-3 mr-sm-2 mb-sm-0">
                    
                          <label for="password">พื้นที่ต้องการใช้รถ :  </label>  <asp:TextBox ID="txtArea" type="Address" class="form-control" runat="server" placeholder="Tumbol">Chaingrai</asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group mb-3 mr-sm-2 mb-sm-0">
                    
                          <label for="password"> วันที่เดินทาง : </label>  <asp:TextBox ID="TextBox1" type="Address" class="form-control" runat="server" placeholder="Tumbol">12/10/2561</asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
          <div class="row" align=center>
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <button type="submit" class="btn btn-success"><i class="fa fa-address-card" aria-hidden="true"></i> อนุมัติการใช้รถ</button>
            </div>
        </div>
    </form>
</div>
   

</asp:Content>