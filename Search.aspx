<%@ Page Title="Foreign Vehicle Permit" Language="VB" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="false"CodeFile="Search.aspx.vb" Inherits="Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br><br>



<div class="container col-12 bg__white pt-5 pb-5 pl-0 log-in--container position-relative">
    
    
    
    
    
    <form class="form-landscape" align=center runat=server>
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6" align=center>
             <div class="alert alert-success">
                <h2><strong><img src="image/icon2/search.png" height="30" width="30"></img>&nbsp;Seach Licence </strong></h2>
                </div>
                <hr>
            </div>
        </div>
      
    
        <asp:Label ID="Label1" class="form-control-lg5" runat="server" Text="Label">Lincence : </asp:Label> 
        <asp:TextBox ID="TextBox1" class="form-control-lg3" runat="server" placeholder="Search....">1234</asp:TextBox>
        <a  href="search.aspx"> <i class="fa fa-search fa-2x" aria-hidden="true"></i></a>

        <br><br>
  
        <div id="Object" class="col-xs-12 col-sm-12">
   
   
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="alert alert-info">Licence : 1234</h3>
            </div>
            <div class="panel-body">
              <div class="row">
                <div class="col-md-3 col-lg-3" align="center"> <img alt="Vehicle Pic" src="Upload/car.jpg" class="rounded-circle img-fluid"> </div>
            
                <div class=" col-md-9 col-lg-9 "> 
                  <table class="table table-user-information">
                    <tbody>
                      <tr>
                        <td>Name Driver : </td>
                        <td>Chidate Chisiri</td>
                      </tr>
                      <tr>
                        <td>Type Vehicle :</td>
                        <td>Sport</td>
                      </tr>
                      <tr>
                        <td>Country Vehicle Registration :</td>
                        <td>Maylaysia</td>
                      </tr>
                       <tr>
                        <td>Vehicle Registration :</td>
                        <td>2ABC901</td>
                      </tr>
                   
                             <tr>
                        <td>Location Use Vehicle : </td>
                        <td>Bangkok </td>
                      </tr>
                        <tr>
                        <td>Start Date </td>
                        <td>12 JUNE 2018</td>
                      </tr>
                      <tr>
                        <td>End Date : </td>
                        <td>20 JUNE 2018</td>
                      </tr>
                      
                     
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
    </form>


<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <asp:Button ID="btnSearch" style="display:none"  runat="server" Text="Button" />
    </asp:UpdatePanel>
--%>


</div>
</asp:Content>