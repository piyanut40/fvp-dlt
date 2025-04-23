<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="CalendarAllV.aspx.vb" Inherits="Admin_CalendarAllV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="../Styles/calendar.css" rel="stylesheet" />  
   <%-- <script src="../Scripts/calendar.js"></script>  --%>

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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<%--<center>--%>
<style>
.tooltip_1 {
  position: relative;
  display: inline-block;
   width: 100%;
  /*border-bottom: 1px dotted black;*/
}

.tooltip_1 .tooltiptext_1 {
  visibility: hidden;
  width: 150px;
  background-color: #999;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 5px 5px;

  /* Position the tooltip */
  position: absolute;
  z-index: 1;
}

.tooltip_1:hover .tooltiptext_1 {
  visibility: visible;
}
</style>
<script type="text/javascript">
var cal = {
  /* [PROPERTIES] */
  mName : ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"], // Month Names
  data : null, // Events for the selected period
  sDay : 0, // Current selected day
  sMth : 0, // Current selected month
  sYear : 0, // Current selected year
  sMon : false, // Week start on Monday?

  /* [FUNCTIONS] */
  listAll : function () {
  // cal.list() : draw the calendar for the given month

    // BASIC CALCULATIONS
    // Note - Jan is 0 & Dec is 11 in JS.
    // Note - Sun is 0 & Sat is 6
    var _arr_day =  document.getElementById("MainContent_HidAllData").value.split('_');
    var i;
//    var now = new Date();
    //    alert(_arr_day);
    for (i=0; i < _arr_day.length-1; i++) 
	{            
		var _arr_dtl = _arr_day[i].split('/');
            localStorage.setItem("cal-" + _arr_dtl[0], _arr_dtl[1]);
            //alert(66);
	}

     for (var i_month=0; i_month<12; i_month++) { 

        cal.sMth = parseInt(i_month); //parseInt(document.getElementById("cal-mth").value); // selected month      
        cal.sYear = <% Response.Write(yearid)%> ; //parseInt(now.getFullYear()); //parseInt(document.getElementById("cal-yr").value); // selected year
//            alert(i_month);           
        var daysInMth = new Date(cal.sYear, cal.sMth+1, 0).getDate(), // number of days in selected month
            
        startDay = new Date(cal.sYear, cal.sMth, 1).getDay(), // first day of the month
        endDay = new Date(cal.sYear, cal.sMth, daysInMth).getDay(); // last day of the month
         
        cal.data = localStorage.getItem("cal-" + cal.sMth + "-" + cal.sYear);
        if (cal.data==null) {
          localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, "{}");
          cal.data = {};
        } else {
          cal.data = JSON.parse(cal.data);
        }

        // DRAWING CALCULATIONS
        // Determine the number of blank squares before start of month
        var squares = [];
        if (cal.sMon && startDay != 1) {
          var blanks = startDay==0 ? 7 : startDay ;
          for (var i=1; i<blanks; i++) { squares.push("b"); }
        }
        if (!cal.sMon && startDay != 0) {
          for (var i=0; i<startDay; i++) { squares.push("b"); }
        }

        // Populate the days of the month
        for (var i=1; i<=daysInMth; i++) { squares.push(i); }

        // Determine the number of blank squares after end of month
        if (cal.sMon && endDay != 0) {
          var blanks = endDay==6 ? 1 : 7-endDay;
          for (var i=0; i<blanks; i++) { squares.push("b"); }
        }
        if (!cal.sMon && endDay != 6) {
          var blanks = endDay==0 ? 6 : 6-endDay;
          for (var i=0; i<blanks; i++) { squares.push("b"); }
        }

        // DRAW HTML
        // Container & Table
        var container = document.getElementById("cal-container" + (i_month+1)),
            cTable = document.createElement("table");
        cTable.id = "calendar" + (i_month+1);
        container.innerHTML = "";
        container.appendChild(cTable);

        // First row - Days
        var cRow = document.createElement("tr"),
            cCell = null,
            days = ["Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"];
        if (cal.sMon) { days.push(days.shift()); }
        for (var d of days) {
          cCell = document.createElement("td");
          cCell.innerHTML = d;
          cRow.appendChild(cCell);
        }
        cRow.classList.add("head");
        cTable.appendChild(cRow);

        // Days in Month
        var total = squares.length;
        cRow = document.createElement("tr");
        cRow.classList.add("day");
        for (var i=0; i<total; i++) {
          cCell = document.createElement("td");
          if (squares[i]=="b") { cCell.classList.add("blank"); }
          else {
           
                    
            if (cal.data[squares[i]]) {
//              alert(cal.data[squares[i]]);
              cCell.innerHTML = "<div class='tooltip_1 ddr'>" +squares[i]+ " <div class='tooltiptext_1 ' width='100%'>" + cal.data[squares[i]] + "</div></div>";

            }
            else{
                cCell.innerHTML = "<div class='dd'>"+squares[i]+"</div>";
            }

          }
          cRow.appendChild(cCell);
          if (i!=0 && (i+1)%7==0) {
            cTable.appendChild(cRow);
            cRow = document.createElement("tr");
            cRow.classList.add("day");
          }
        }
     
      }
    

    // REMOVE ANY ADD/EDIT EVENT DOCKET
    cal.close();
  },

  list : function () {
  // cal.list() : draw the calendar for the given month

    // BASIC CALCULATIONS
    // Note - Jan is 0 & Dec is 11 in JS.
    // Note - Sun is 0 & Sat is 6
    var _All = document.getElementById("MainContent_HidAllData").value.split("/_");

    cal.sMth = parseInt(document.getElementById("cal-mth").value); // selected month
    cal.sYear = parseInt(document.getElementById("cal-yr").value); // selected year
    var daysInMth = new Date(cal.sYear, cal.sMth+1, 0).getDate(), // number of days in selected month
        startDay = new Date(cal.sYear, cal.sMth, 1).getDay(), // first day of the month
        endDay = new Date(cal.sYear, cal.sMth, daysInMth).getDay(); // last day of the month

    // LOAD DATA FROM LOCALSTORAGE

//    alert("cal-" + cal.sMth + "-" + cal.sYear);
//    alert(localStorage.getItem("cal-" + cal.sMth + "-" + cal.sYear));
    cal.data = localStorage.getItem("cal-" + cal.sMth + "-" + cal.sYear);
    if (cal.data==null) {
      localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, "{}");
      cal.data = {};
    } else {
      cal.data = JSON.parse(cal.data);
    }

    // DRAWING CALCULATIONS
    // Determine the number of blank squares before start of month
    var squares = [];
    if (cal.sMon && startDay != 1) {
      var blanks = startDay==0 ? 7 : startDay ;
      for (var i=1; i<blanks; i++) { squares.push("b"); }
    }
    if (!cal.sMon && startDay != 0) {
      for (var i=0; i<startDay; i++) { squares.push("b"); }
    }

    // Populate the days of the month
    for (var i=1; i<=daysInMth; i++) { squares.push(i); }

    // Determine the number of blank squares after end of month
    if (cal.sMon && endDay != 0) {
      var blanks = endDay==6 ? 1 : 7-endDay;
      for (var i=0; i<blanks; i++) { squares.push("b"); }
    }
    if (!cal.sMon && endDay != 6) {
      var blanks = endDay==0 ? 6 : 6-endDay;
      for (var i=0; i<blanks; i++) { squares.push("b"); }
    }

    // DRAW HTML
    // Container & Table
    var container = document.getElementById("cal-container"),
        cTable = document.createElement("table");
    cTable.id = "calendar";
    container.innerHTML = "";
    container.appendChild(cTable);

    // First row - Days
    var cRow = document.createElement("tr"),
        cCell = null,
        days = ["Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"];
    if (cal.sMon) { days.push(days.shift()); }
    for (var d of days) {
      cCell = document.createElement("td");
      cCell.innerHTML = d;
      cRow.appendChild(cCell);
    }
    cRow.classList.add("head");
    cTable.appendChild(cRow);

    // Days in Month
    var total = squares.length;
    cRow = document.createElement("tr");
    cRow.classList.add("day");
    for (var i=0; i<total; i++) {
      cCell = document.createElement("td");
      if (squares[i]=="b") { cCell.classList.add("blank"); }
      else {
        cCell.innerHTML = "<div class='dd'>"+squares[i]+"</div>";
        if (cal.data[squares[i]]) {
          cCell.innerHTML += "<div class='evt'>" + cal.data[squares[i]] + "</div>";
        }
        cCell.addEventListener("click", function(){
          cal.show(this);
        });
      }
      cRow.appendChild(cCell);
      if (i!=0 && (i+1)%7==0) {
        cTable.appendChild(cRow);
        cRow = document.createElement("tr");
        cRow.classList.add("day");
      }
    }

    // REMOVE ANY ADD/EDIT EVENT DOCKET
    cal.close();
  },

  show : function (el) {
  // cal.show() : show edit event docket for selected day
  // PARAM el : Reference back to cell clicked

    // FETCH EXISTING DATA
    cal.sDay = el.getElementsByClassName("dd")[0].innerHTML;

    // DRAW FORM
    var tForm = "<h1 class='w3-left-align'>" + (cal.data[cal.sDay] ? "แก้ไข" : "เพิ่ม") + " </h1>";
    tForm += "<div id='evt-date' class='w3-left-align'>" + cal.sDay + " " + cal.mName[cal.sMth] + " " + cal.sYear + "</div>";
    tForm += "<textarea id='evt-details' required>" + (cal.data[cal.sDay] ? cal.data[cal.sDay] : "") + "</textarea>";
    
    tForm += "<input type='submit' value='บันทึก'/>"; 
    tForm += "<input type='button' value='ลบ' onclick='cal.del()'/>";
    tForm += "<input type='button' value='ปิด' onclick='cal.close()'/>";

    // ATTACH
    var eForm = document.createElement("form");
    eForm.addEventListener("submit", cal.save);
    eForm.innerHTML = tForm;
    var container = document.getElementById("cal-event"+ (i_month+1));
    container.innerHTML = "";
    container.appendChild(eForm);
  },

  close : function () {
  // cal.close() : close event docket

    document.getElementById("cal-event").innerHTML = "";
  },

  save : function (evt) {
  // cal.save() : save event

    evt.stopPropagation();
    evt.preventDefault();
    cal.data[cal.sDay] = document.getElementById("evt-details").value;
    var _1_day = cal.sDay;
    var _2_day = document.getElementById("evt-details").value;
//    alert(JSON.stringify(cal.data));
    localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, JSON.stringify(cal.data));
    cal.list();
    document.getElementById("MainContent_HidData").value = _1_day + ":" + _2_day;

    document.getElementById("MainContent_Hidmonth").value = cal.sMth + 1;
    document.getElementById("MainContent_Hidyear").value = cal.sYear;
//    alert(document.getElementById("MainContent_HidData").value);
    document.getElementById("MainContent_BtnSave").click();
  },

  del : function () {
  // cal.del() : Delete event for selected date

    if (confirm("ต้องการลบข้อมูลใช่หรือไม่?")) {
      var _del_day = cal.sDay;
      delete cal.data[cal.sDay];
      localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, JSON.stringify(cal.data));
      cal.list();
      document.getElementById("MainContent_HidDel_ID").value = _del_day;
      document.getElementById("MainContent_Hidmonth").value = cal.sMth + 1;
      document.getElementById("MainContent_Hidyear").value = cal.sYear;
      document.getElementById("MainContent_BtnDelete").click();
    }
  }
};

// INIT - DRAW MONTH & YEAR SELECTOR
window.addEventListener("load", function () {
  // DATE NOW
  var now = new Date(),
//      nowMth = now.getMonth(),
//      nowYear = parseInt(now.getFullYear());

      nowMth = (<% Response.Write(cur_month)%> == 0 ? now.getMonth() : <% Response.Write(cur_month)%> - 1),
      nowYear = (<% Response.Write(cur_year)%> == 0 ? parseInt(now.getFullYear()) : <% Response.Write(cur_year)%>);

 
  cal.listAll();
});

</script>
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">ข้อมูลวันหยุดประจำปี <% Response.Write(yearid)%> </b></a>
</header>

          
<div id="page-body" >
    <%-- [PERIOD SELECTOR] --%>
    <div id="cal-date">
    
    </div>

  
  
   <center>
   <div class="w3-row w3-padding-small"> 
    <div class="w3-col l5 w3-margin"> 
     <h1 class="w3-left-align ">January</h1>
    <div id="cal-container1" ></div>  
    <div id="cal-event1"></div>
     </div>

    <div class="w3-col l5 w3-margin"> 
    <h1 class="w3-left-align ">February</h1> 
     <div id="cal-container2" ></div>
    <div id="cal-event2"></div>  
    </div>
    </div>

    <div class="w3-row w3-padding-small"> 
     <div class="w3-col l5 w3-margin"> 
      <h1 class="w3-left-align ">March</h1> 
    <div id="cal-container3" ></div>
    <div id="cal-event3" ></div>
     </div>

    <div class="w3-col l5 w3-margin"> 
    <h1 class="w3-left-align ">April</h1>
    <div id="cal-container4" ></div>
    <div id="cal-event4"></div>
     </div>
     </div>

    <div class="w3-row w3-padding-small"> 
    <div class="w3-col l5 w3-margin"> 
     <h1 class="w3-left-align ">May</h1>
    <div id="cal-container5" ></div>
    <div id="cal-event5"></div>
     </div>

    <div class="w3-col l5 w3-margin">
    <h1 class="w3-left-align ">June</h1>
    <div id="cal-container6" ></div>
    <div id="cal-event6"></div>
     </div>
    </div>

    <div class="w3-row w3-padding-small"> 
   <div class="w3-col l5 w3-margin">
   <h1 class="w3-left-align ">July</h1>
    <div id="cal-container7" ></div>
    <div id="cal-event7"></div>
     </div>

    <div class="w3-col l5 w3-margin">
    <h1 class="w3-left-align ">August</h1>
    <div id="cal-container8" ></div>
    <div id="cal-event8"></div>
   </div>
     </div>

    <div class="w3-row w3-padding-small"> 
    <div class="w3-col l5 w3-margin">
    <h1 class="w3-left-align">September</h1>
    <div id="cal-container9"></div>
    <div id="cal-event9"></div>
     </div>

    <div class="w3-col l5 w3-margin">
    <h1 class="w3-left-align">October</h1>
    <div id="cal-container10"></div>
    <div id="cal-event10"></div>
     </div>
      </div>

    <div class="w3-row w3-padding-small"> 
    <div class="w3-col l5 w3-margin">
    <h1 class="w3-left-align">November</h1>
    <div id="cal-container11"></div>
    <div id="cal-event11"></div>
     </div>

    <div class="w3-col l5 w3-margin">
    <h1 class="w3-left-align">December</h1>
    <div id="cal-container12"></div>
    <div id="cal-event12"></div>
    </div>
     </div>

  </center>
    <%-- [EVENT] --%>
    
  </div>

  <%--</center>--%>
  
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
  <asp:Panel ID="PnDelete" style="DISPLAY: none" runat="server" >
  <asp:HiddenField ID="hid_id" runat="server" />
        <asp:HiddenField id="HidDel_ID" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidType" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidActive" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="HidUsername" runat="server"></asp:HiddenField> 
        <asp:HiddenField id="Hidmonth" runat="server"></asp:HiddenField>
        <asp:HiddenField id="Hidyear" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidData" runat="server"></asp:HiddenField>
        <asp:HiddenField id="HidAllData" runat="server"></asp:HiddenField>
     
   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"  ImageUrl="~/images/schd.gif" />
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>
</asp:Content>

