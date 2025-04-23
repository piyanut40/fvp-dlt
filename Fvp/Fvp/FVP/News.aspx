<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="News.aspx.vb" Inherits="News" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">

h4 {
    margin: 20px 10px 10px;
}
p {
    margin: 10px;
}

#carousel-example-generic {
    margin: 20px auto;
    width: 400px;
}

#carousel-custom {
    margin: 20px auto;
    width: 400px;
}
#carousel-custom .carousel-indicators {
    margin: 10px 0 0;
    overflow: auto;
    position: static;
    text-align: left;
    white-space: nowrap;
    width: 100%;
}
#carousel-custom .carousel-indicators li {
    background-color: transparent;
    -webkit-border-radius: 0;
    border-radius: 0;
    display: inline-block;
    height: auto;
    margin: 0 !important;
    width: auto;
}
#carousel-custom .carousel-indicators li img {
    display: block;
    opacity: 0.5;
}
#carousel-custom .carousel-indicators li.active img {
    opacity: 1;
}
#carousel-custom .carousel-indicators li:hover img {
    opacity: 0.75;
}

</style>
<!-- Slideshow -->
<%--<div class="w3-container" >--%>

   <%-- <div class="w3-display-container mySlides">
      <img src="image/Background1.jpg" style="width:100%; height:740px;">--%>
      <%--<div class="w3-display-topleft w3-container w3-padding-small">
        <span class="w3-white w3-padding-large w3-animate-bottom">Lorem ipsum</span>
      </div>--%>
   <%-- </div>
    <div class="w3-display-container mySlides">
      <img src="image/Background2.jpg" style="width:100%; height:740px;">--%>
      <%--<div class="w3-display-middle w3-container w3-padding-small">
        <span class="w3-white w3-padding-large w3-animate-bottom">Klorim tipsum</span>
      </div>--%>
   <%-- </div>
    <div class="w3-display-container mySlides">
      <img src="image/Background3.jpg" style="width:100%; height:740px;">--%>
      <%--<div class="w3-display-topright w3-container w3-padding-small">
        <span class="w3-white w3-padding-large w3-animate-bottom">Blorum pipsum</span>
      </div>--%>
    <%--</div>
--%>
    <!-- Slideshow next/previous buttons -->
    <%--<div class="w3-container w3-dark-grey w3-padding w3-xlarge">
      <div class="w3-left" onclick="plusDivs(-1)"><i class="fa fa-arrow-circle-left w3-hover-text-teal"></i></div>
      <div class="w3-right" onclick="plusDivs(1)"><i class="fa fa-arrow-circle-right w3-hover-text-teal"></i></div>
    
      <div class="w3-center">
        <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(1)"></span>
        <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(2)"></span>
        <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(3)"></span>
      </div>
    </div>
  </div>--%>
  <!-- Header with full-height image -->
 
    <asp:Panel ID="Panel1" runat="server">


  <script type="text/javascript">

      $(document).ready(function () {
          $(".loader").fadeOut("slow");
          sendData();
          function sendData(feed, name) {
              if (feed == null) {
                  feed = '';
              } else {
              };
              if (name == null) {
                  name = '';
              } else {
              };
              $.ajax({
                  type: "GET",
                  url: "API/getNews.ashx",
                  data: { fetch: feed, name: name },
                  success: function (result) {
                      $.each(JSON.parse(result), function (key, value) {
                          $.each(value, function (i, y) {
                              $(".loader").fadeOut("slow");
                              var text = "<div id='" + y.news_id + "' class='w3-col l3 m6 w3-margin-bottom w3-row-padding' style='margin-top:1%'>";
                              text = text + "<div class='w3-card-4 w3-hover-shadow w3-dark-gray' style='width:100%;height:450px;'>";
                              text = text + "<img src='https://" + y.url + "'  style='width:100%; height:200px;'>";
                              text = text + "<div class='w3-container w3-text-black ' >";
                              text = text + "<p style='color:#ffffff;margin-top:5px'><img src='image/calendar.png' style='wight:20px;height:20px;margin-right:1%'>" + y.date_news + "</p>";
                              text = text + "<div class='conference_new w3-text-white' > <p class='w3-opacity-min '>" + y.title + "</p> </div> ";
                              text = text + "<div class='w3-center'>  <p><a class='w3-button  w3-border w3-round-xxlarge w3-text-white w3-right' Target='_blank' href='news.aspx?id=" + y.news_id + "' style='margin-top:9%;font-size:0.7em;font-size:10px'>Read More </a></p> </div> ";
                              text = text + "</div>";
                              text = text + "</div>";
                              text = text + "</div>";
                              $("#myDiv").append(text);
                          });

                      });
                  },
                  complete: function () {
                      $('.loader').hide();
                  }
              });
          };



          $(window).scroll(function () {
              if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                  var feed = $('#myDiv').children().last().attr('id');
                  var name = $("#<%=txtSrh.ClientID %>").val();
                  parseInt(feed);
                  sendData(feed, name);
              }
          });

          $("#<%=txtSrh.ClientID %>").on('input', function (e) {
              var input = $(this);
              var val = input.val();
              $("#myDiv").empty();
              sendData('', val);
          });


      });

    


</script>

<!-- News Section -->
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<div class="loader">
</div>
 <div class="w3-row">
 <div class=" w3-row-padding" style=" margin:1% ">
 <div class="w3-col s6">
  <h1 class=" w3-text-purple w3-hide-medium w3-hide-small " style="font-size:2em "><b>ข่าวประชาสัมพันธ์</b></h1>
  <span class=" w3-hide-large w3-text-purple" style="font-size:18px "><b>ข่าวประชาสัมพันธ์</b><br /></span>
  </div>
  <div class="w3-col s6 ">
  <%--<a class=" w3-xlarge w3-right"><img src="image/magnifying-glass.png" /> ค้นหาข่าว  <asp:TextBox ID="txtSrh" oninput="srh();" placeholder="หัวข้อข่าว" class="w3-round-medium w3-border-purple" runat="server" Font-Size="20px"></asp:TextBox> </a> --%>
  <a class=" w3-right"><asp:TextBox ID="txtSrh" oninput="srh();" placeholder="ค้นหาข่าว" class="w3-round-medium w3-border-purple" runat="server" Font-Size="1em" Width="85%"></asp:TextBox>  <img src="image/magnifying-glass.png" class=" w3-hide-medium w3-hide-small" /></a>
 </div>
 </div>
  <%--<div class="col-8 m-5">--%>
       <%-- <div class="row">--%>
        <%--<asp:Label ID="Label5" class="col-2" runat="server" Text="ค้นหาข่าว : "></asp:Label> --%>

        <%--<a class=" w3-xlarge" style=" margin-right:1% "> ค้นหาข่าว </a>  <asp:TextBox ID="txtSrh" oninput="srh();" placeholder="หัวข้อข่าว" class=" w3-round-medium w3-border-purple col-4" runat="server"></asp:TextBox> --%>

     <%--  </div>--%>
  <%--     </div>--%>
  
 <hr style="border: 2px solid purple;border-radius: 5px;margin-top:1%;width:100%"/>

       


  <div id="myDiv" class=" w3-text-black" >


  </div>
 
</div>











<%--<div id="News">
  <h2 class="w3-border-bottom w3-border-light-grey w3-padding-16 w3-text-purple" style="margin-left:20px;font-family:'Kanit', sans-serif"><b>ข่าวประชาสัมพันธ์ทั้งหมด</b></h2>
 </div>

  <!-- Team Section -->
     <div class=" mySlides1 slideshow-container">
    
 <div class=" w3-row-padding cardsSlides" style="margin-top:20px">
  
    <% Response.Write(DivNews) %>
 
</div>

<a class="prev w3-button w3-light-grey" onclick="plusSlides(-1, 0)">&#10094;</a>
<a class="next w3-button w3-light-grey" onclick="plusSlides(1, 0)">&#10095;</a>
</div>--%>
    </asp:Panel>

 <asp:Panel ID="Panel2" runat="server">
 
 <div class="w3-card-2  w3-round w3-xlarge w3-padding  w3-purple " style=" text-align:justify;font-size:18px;width:100%;">

 <%--<asp:Label ID="Label3" runat="server"  Font-Bold="True"  CssClass="w3-text-purple" Font-Underline="True"></asp:Label><br>--%><%--Text="หัวข้อข่าว" Font-Size="1.5em"--%>
 
 <asp:Label ID="lbltitle" runat="server" Font-Bold="True" CssClass="w3-text-white"></asp:Label><%--Font-Size="1.2em"--%>
 </div>

<div class="w3-card-2 w3-white w3-round-large w3-row-padding" style="margin-top:1%">


<div class="w3-container w3-twothird  w3-padding" >
 <asp:Label ID="Label2" runat="server" Font-Size="1.5em" CssClass="w3-text-purple" Font-Underline="True" ></asp:Label><%--Text="รายละเอียด / เนื้อหาข่าว"--%>
 <div style="text-align:justify;font-size:18px;"><%--class="d-flex justify-content-center mb-5"--%>
    <%--<div class="col-6">--%>
            <asp:Label ID="lblDetail" runat="server" Text="Label" CssClass="w3-panel" ></asp:Label>
    <%--</div>--%>
 </div>

</div>

<div class="w3-container  w3-third w3-padding">
<div class=" w3-theme-d2 w3-padding w3-card " style="margin-top:1%"><img src="image/jpg.png" /> <asp:Label ID="Label1" runat="server" Text="รูปข่าว" Font-Bold="True" Font-Size="1 em" CssClass="w3-text-white" ></asp:Label></div> <br>
     <asp:DataList ID="dtlImg" runat="server" RepeatColumns="4" CellPadding="0">
     <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
            <ItemTemplate>        
            <div class=" w3-col w3-margin-bottom" >
            <div class= "w3-display-container">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("pic") %>' Width="50%"/>
                <div class=" w3-margin">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("url") %>' Target="_blank">ดูรูปภาพขนาดใหญ่</asp:HyperLink>
                </div>
                </div>
             </div>
      </ItemTemplate>
     </asp:DataList>

 <div class="w3-theme-d2 w3-padding w3-card"> <img src="image/file.png" /> <asp:Label ID="Label4" runat="server" Text="เอกสารข่าว" Font-Bold="True" Font-Size="1 em" CssClass="w3-text-white"></asp:Label></div><br>
     <asp:DataList ID="dtlFile" runat="server">
        <ItemTemplate>
       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("url") %>' Target="_blank"><li><%# Eval("file_name") %></li></asp:HyperLink>
        </ItemTemplate>
     </asp:DataList>
</div>
</div>
    </asp:Panel>

</asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="footer" Runat="Server">
 <footer class="ftbanner" style="width:100%;height:20%;left:0%;buttom:0%;"><%--margin-top:3%--%>
     
         <%--<h2 class="w3-text-white w3-center w3-card w3-orange w3-padding-16" style="margin-bottom:2%;text-shadow:1px 1px 0 #444; width:12.5em; height:3.75em;margin-left:45%"><b style="font-size:x-large">Contact Us</br></h2>

         <div class=" w3-text-white w3-center " style="font-size:0.8em;margin-top:-1%">
         <p> <i class="fa fa-phone w3-hover-opacity w3-text-white"></i>  โทรศัพท์ : 02-2718-443 <i class="fa fa-fax w3-hover-opacity w3-text-white" aria-hidden="true"></i>  โทรสาร : 02-2718-443</p> </br>
         </div>
         <div class=" w3-text-white w3-center" style="font-size:0.8em;margin-top:-2%">
         <p><i class="fa fa-home w3-hover-opacity w3-text-white" "></i> อาคาร4 ชั้น5 กองแผนงาน กรมการขนส่งทางบก </br> 1032 ถนนพหลโยธิน แขวงจอมพล เขตจตุจักร กรุงเทพมหานคร 10900</p>
         </div>
--%>
            <div class="w3-text-white w3-center w3-card w3-orange w3-padding contact">
                <b class=" w3-hide-small">Contact Us</b>
                  <b class=" w3-hide-large w3-hide-medium" style=" margin-top:-5%">Contact Us</b>
            </div>

            <div class=" w3-text-white w3-center textcontact ">

                <p> <i class="fa fa-phone w3-hover-opacity w3-text-white"></i> Telephone : 02-2718-443 <i class="fa fa-fax w3-hover-opacity w3-text-white" aria-hidden="true"></i>  Fax : 02-2718-443<br />
                    <i class="fa fa-home w3-hover-opacity w3-text-white" style="margin-top:-1%"></i> Building 4, 5th floor Center Operation  Department of Land Transport</br>1032 Phaholyothin Road, Chom Phon, Chatuchak, Bangkok 10900.
                </p>
            </div>
             
         <%--<img src="image/arrow-up.png" class="w3-hide-small w3-right" style=" width:2.5em; height:2.5em;margin-top:-5%; margin-right:3%"  class=" w3-right" onclick="topFunction()" id="myBtn2" title="Go to top" />--%>
         
 </footer>
    <p class="w3-center w3-amber w3-black w3-hide-medium w3-hide-small" style="margin-left:0%;width:100%;height:3%;margin-top:-0.1%;font-size:0.7em;margin-bottom: auto;"><i class="fa fa-copyright" aria-hidden="true"></i> Copyright 2019</p>
     <p class="w3-center w3-amber w3-black w3-hide-large" style="margin-left:0%;width:100%;height:3%;margin-top:0.1%;font-size:0.6em;"><i class="fa fa-copyright" aria-hidden="true"></i> Copyright 2019</p>
 </asp:Content>




 