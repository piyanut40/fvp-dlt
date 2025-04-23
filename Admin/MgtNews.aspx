<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtNews.aspx.vb" MasterPageFile="~/MasterPageB.master" Inherits="MgtNews" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat=server>
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />  
    <script src="../Scripts/jquery-ui.js"></script>  
    <link href="../Styles/progress-wizard.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/jodit/3.1.39/jodit.min.css">
    <script src="//cdnjs.cloudflare.com/ajax/libs/jodit/3.1.39/jodit.min.js"></script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>

    <header  class="w3-container w3-center" style="padding-top:22px">
    <a style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;"><b> จัดการข่าวประชาสัมพันธ์</b></a>
</header>
 


<br />


<div class="container col-12 bg__white pt-5 pl-5 log-in--container position-relative">

    <div class="row mt-5 mr-5">
            <div class="col-sm">

  <div class="form-row">
  <div class="form-group ml-5 col-12 col-md-6 col-lg-6">
    <label>หัวข้อข่าว : </label>
      <asp:TextBox ID="txtTitle" class="form-control" runat="server"></asp:TextBox>
    </div>
      <div class="form-group ml-5 col-12 col-md-4 col-lg-4 ">
    <label>วันที่ลงข่าว : </label>
      <asp:TextBox ID="txtDate" class="form-control" runat="server"></asp:TextBox>
    </div>
  </div>


<asp:UpdatePanel ID="UpdJodit" runat="server" UpdateMode=Conditional>
<ContentTemplate>
              

  <div class="form-row">
  <div class="form-group ml-5 col-12">
    <label>เนื้อหาข่าว : </label>
      <asp:TextBox ID="txtDetail" class="form-control" Rows=5 runat="server"></asp:TextBox>
    </div>
  </div>
    <div class="form-row">
  <div class="form-group ml-5 col-12">
    <div id="editor"> </div>
    </div>
  </div>
  </ContentTemplate>
    </asp:UpdatePanel>



    
  <div class="form-row">
  <div class="form-group ml-5 col-12">
    <label>อัพโหลดรูปหน้าปก : </label>
        <asp:UpdatePanel ID="UpdPic1" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FilePic1" runat="server" onchange="document.getElementById('MainContent_btnUploadPic1').click();" />
            <asp:ImageButton ID="btnUploadPic1" style="DISPLAY: none"  runat="server" AutoPostBack="true" Width="50px"  OnClientClick="showProgress();" UseSubmitBehavior="false" />
               <asp:HiddenField ID="hidUploadPic1" runat="server" />
            <asp:Image ID="PhotoPic1" runat="server" Height="50%" Width="50%"/>
            <asp:ImageButton ID="PhotoDeletePic1"  OnClientClick="javascript:return confirm('คุณต้องการจะลบรูปภาพนี้หรือไม่ ?'); return false;"  ImageUrl="../image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" UseSubmitBehavior="false" Visible="false" />
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPic1"/>
	          </Triggers>
           </asp:UpdatePanel>
    </div>
  </div>








  
  <div class="form-row">
  <div class="form-group ml-5 col-12">
    <label>อัพโหลดไฟล์เอกสาร : </label>
      <asp:UpdatePanel ID="updFile" runat="server">
      <ContentTemplate>
        <asp:FileUpload ID="FileDoc" runat="server" onchange="document.getElementById('MainContent_btnUploadFile').click();"  />
      <asp:Button ID="btnUploadFile" style="display:none" runat="server" autopostback="true" Text="Button" OnClientClick="showProgress(); " />
         <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="False" CssClass="Grid" GridLines="None" >
              <Columns>
                    <asp:TemplateField>
                            <ItemTemplate>
                            <asp:Label runat=server style=" display:none" ID="lblID" Text='<%# Bind("gid") %>' ></asp:Label>
                            <asp:Label runat=server style=" display:none" ID="lblfilename" Text='<%# Bind("file_name") %>' ></asp:Label>
                            <asp:Label runat=server style=" display:none" ID="lblfiles" Text='<%# Bind("files") %>' ></asp:Label>
                             <asp:Label runat=server style=" display:none" ID="lblPathDoc" Text='<%# Bind("PathDoc") %>' ></asp:Label>
                             <asp:HyperLink runat=server ID="hplDoc" NavigateUrl='<%# Bind("PathDoc") %>' Text='<%# Bind("file_name") %>' Target="_blank" ></asp:HyperLink>
                             <asp:ImageButton ID="FileDelete" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบไฟล์ใช่หรือไม่ ?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="FileDelete_Command" formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/></h3>
                             </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
      </asp:GridView>
            
      </ContentTemplate>
      <Triggers>
                <asp:PostBackTrigger ControlID="btnUploadFile" />
      </Triggers>
      </asp:UpdatePanel>
    
   
    </div>
  </div>






   <div class="form-row">
  <div class="form-group ml-5 col-12 mb-5">
    <label>อัพโหลดไฟล์รูป : </label>

      <asp:UpdatePanel ID="UpdPic2" runat="server" UpdateMode="conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          <asp:FileUpload ID="FilePhotoPic2" runat="server" onchange="document.getElementById('MainContent_btnUploadPhotoNews2').click();" />
            <asp:ImageButton ID="btnUploadPhotoNews2" style="DISPLAY: none" runat="server" AutoPostBack="true" ImageUrl="../image/upload.png" Width="50px"  OnClientClick="showProgress(); " formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/>
               <asp:HiddenField ID="hidPhotoNews2" runat="server" />
            <asp:Image ID="PhotoNews2" runat="server" Width="300px"  />
          <%--  <asp:ImageButton ID="PhotoCarDelete"  OnClientClick="javascript:return confirm('Do you want delete photo?');"  ImageUrl="image/g_delete.gif"  runat="server"
             alt="Delete" title="Delete" formnovalidate="formnovalidate" CausesValidation="false" UseSubmitBehavior="false" Visible="false" oncommand="PhotoCarDelete_Command" />
--%>
            </ContentTemplate>
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnUploadPhotoNews2"/>
	          </Triggers>
           </asp:UpdatePanel>



       <asp:UpdatePanel ID="UpdgvFile" runat="server" class="w3-row-padding w3-center" UpdateMode="Conditional">
                    <contenttemplate>
                       <asp:DataList ID="DtlImg" runat="server" CellPadding="0" RepeatLayout="Flow" 
                    DataKeyField="gid" ForeColor="#333333" RepeatColumns="4" 
                            RepeatDirection="Horizontal">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                           <ItemTemplate>
                              

                            <div class="w3-col l3 m6 w3-margin-bottom w3-margin-top" style="height: 250px;">
                                <div class="w3-display-container">

                                    <%--<img src="/w3images/sandwich.jpg" alt="Sandwich" style="width:100%">--%>
                                    <asp:Image ID="imageFile" runat="server" ImageUrl='<%# Bind("PathImg") %>' style="width:50%" />
                                    <%--<h3>The Perfect Sandwich, A Real NYC Classic</h3>--%>
                                 
                                    
                                      
                                <div class="w3-white w3-margin">
                                    <h3><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("PathImg") %>' Target="_blank"  runat="server">Big picture</asp:HyperLink>&nbsp;&nbsp;
                                  <asp:ImageButton ID="PhotoCarDelete" runat="server" OnClientClick = "javascript:return confirm('ต้องการลบรูปภาพใช่หรือไม่?');"
                                                CommandArgument='<%# Eval("gid") %>' CommandName="Delete" 
                                                ImageUrl="../image/g_delete.gif" alt="ลบข้อมูล" title="ลบข้อมูล" oncommand="PhotoCarDelete_Command" formnovalidate="formnovalidate" CausesValidation=false  UseSubmitBehavior="false"/></h3>
                                </div>

                                
                            </div>

                             </div>
                               

                           </ItemTemplate> 
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:DataList>

                <asp:Panel style="DISPLAY: none" id="Pngrid" runat="server" Height="0px">
                        <asp:GridView ID="gvImage" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="Grid" GridLines="None" PageSize="2"  
                            Width="500px">
                            <Columns>
                                <asp:TemplateField Visible="False">
                                     <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("gid") %>'></asp:Label>
                                        <asp:Label ID="lblpic_name" runat="server" Text='<%# Bind("pic_name") %>'></asp:Label>
                                         <asp:Label ID="lblPathImg" runat="server" Text='<%# Bind("PathImg") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                </asp:Panel>

                    </contenttemplate>
                     <%--<Triggers>
    <asp:AsyncPostBackTrigger ControlID="ImgDelete" EventName="Click" />
        
    </Triggers>--%>
                </asp:UpdatePanel>


    </div>
  </div>



  <div class="m-5 w3-center">
<%--  <asp:Button ID="Button1" class=" w3-button w3-green  w3-round-large w3-large" runat="server" Text="บันทึก" /> 
  <asp:Button ID="Button2" class=" w3-button w3-red  w3-round-large  w3-large" runat="server" Text="ยกเลิก" />--%>

  <asp:LinkButton ID="Button2" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-arrow-left" aria-hidden="true"></i> ยกเลิก</asp:LinkButton>
    <asp:LinkButton ID="Button1" class="w3-button w3-purple2 w3-padding w3-round" runat="server"><i class="fa fa-save" aria-hidden="true"></i> บันทึก</asp:LinkButton>
  </div>
            </div>
    </div>

</div>


<asp:UpdateProgress ID="UpdateProgress" runat="server" >
    <ProgressTemplate>
        <div align="center" class="overlays">
            <div class="loader" ></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>









<script type="text/javascript">



    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }

    var editor = new Jodit('#<%= txtDetail.ClientID %>', {
     uploader: {
         url: '../API/ajaxfileupload.ashx'
     },
     filebrowser: {
        ajax: {
            url: '../API/filebrowse.ashx'
            }  
     },
    buttons:[
        'source',
        'bold',
        'strikethrough',
        'underline',
        'italic',
        'ul',
        'ol',
        'outdent',
        'indent',
        'font',
        'fontsize',
        'brush',
        'paragraph',
        'image',
        'video',
        'table',
        'link',
        'align',
        'undo',
        'redo',
        '\n',
        'hr',
        'eraser',
        'copyformat',
        'symbol',
        'fullsize',
        'print',
    ],
  });

    $(function () {
        $('#<%=txtDate.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            beforeShow: function () {
                setTimeout(function () {
                    $('.ui-datepicker').css('z-index', 99999999999999);
                }, 0);
            }

        });
         $( "#<%=txtDate.ClientID %>" ).datepicker( "option", "dateFormat", "dd MM yy");
});


</script>
    
</asp:Content>