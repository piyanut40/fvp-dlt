<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageB.master" AutoEventWireup="false" CodeFile="CalendarV.aspx.vb" Inherits="Admin_CalendarV" %>

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

    cal.sMth = parseInt(document.getElementById("cal-mth").value); // selected month
    cal.sYear = parseInt(document.getElementById("cal-yr").value); // selected year
    document.getElementById("MainContent_Hidmonth").value = parseInt(document.getElementById("cal-mth").value);
    document.getElementById("MainContent_Hidyear").value = parseInt(document.getElementById("cal-yr").value);
    var daysInMth = new Date(cal.sYear, cal.sMth+1, 0).getDate(), // number of days in selected month
        startDay = new Date(cal.sYear, cal.sMth, 1).getDay(), // first day of the month
        endDay = new Date(cal.sYear, cal.sMth, daysInMth).getDay(); // last day of the month

    // LOAD DATA FROM LOCALSTORAGE


    var _arr_day =  document.getElementById("MainContent_HidAllData").value.split('_');
    var i;
    for (i=0; i < _arr_day.length; i++) 
		{       
			var _arr_dtl = _arr_day[i].split('/');
            localStorage.setItem("cal-" + _arr_dtl[0], _arr_dtl[1]);
             //alert(66);
		}

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
    var _Day ;//= <% Response.Write(min_date)%>;
    var _dd =  <% Response.Write(_dd)%>;
    var _mm =  <% Response.Write(_mm)%>;
    var _yyyy =  <% Response.Write(_yyyy)%>;
    var month = document.getElementById("cal-mth");
    var _month = month.options[month.selectedIndex].value;
    var year = document.getElementById("cal-yr");
    var _year = year.options[year.selectedIndex].value;
    var total = squares.length;
    cRow = document.createElement("tr");

    var i_day = 0;
    for (var i=0; i<total; i++) {

          cCell = document.createElement("td");
          cRow.classList.add("day");
          if (squares[i]=="b") { cCell.classList.add("blank"); }
          else {
          i_day += 1; 
            cCell.innerHTML = "<div class='dd'>"+squares[i]+"</div>";
            if (cal.data[squares[i]]) {
                if(_yyyy == parseInt(_year)){

                    if(_mm == (parseInt(_month) + 1)){
                    
                        if( (i_day) >= _dd){
                                cCell.classList.add("avai"); 
                          }
                        else{
                            cCell.classList.add("not_avai"); 

                        }
                    }
                    else if(_mm < (parseInt(_month) + 1)){
                        cCell.classList.add("avai"); 
                    }
                    else{
                        cCell.classList.add("not_avai"); 
                    }
                }
                else if(_yyyy < parseInt(_year)){
                    cCell.classList.add("avai"); 
                }
                else{
                    cCell.classList.add("not_avai");
                }
                cCell.innerHTML += "<div class='evt'>" + cal.data[squares[i]] + "</div>";
            }
            else{
                if(_yyyy == parseInt(_year)){

                    if(_mm == (parseInt(_month) + 1)){
                    
                        if( (i_day) >= _dd){
                                cCell.classList.add("avai"); 
                          }
                        else{
                            cCell.classList.add("not_avai"); 

                        }
                    }
                    else if(_mm < (parseInt(_month) + 1)){
                        cCell.classList.add("avai"); 
                    }
                    else{
                        cCell.classList.add("not_avai"); 
                    }
                }
                else if(_yyyy < parseInt(_year)){
                    cCell.classList.add("avai"); 
                }
                else{
                    cCell.classList.add("not_avai");
                }
//                cCell.innerHTML += "<div class='evt'>" + cal.data[squares[i]] + "</div>";
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

  list : function () {
  // cal.list() : draw the calendar for the given month

    // BASIC CALCULATIONS
    // Note - Jan is 0 & Dec is 11 in JS.
    // Note - Sun is 0 & Sat is 6
    var _All = document.getElementById("MainContent_HidAllData").value.split("/_");

    cal.sMth = parseInt(document.getElementById("cal-mth").value); // selected month
    cal.sYear = parseInt(document.getElementById("cal-yr").value); // selected year
    document.getElementById("MainContent_Hidmonth").value = parseInt(document.getElementById("cal-mth").value);
    document.getElementById("MainContent_Hidyear").value = parseInt(document.getElementById("cal-yr").value);
    var daysInMth = new Date(cal.sYear, cal.sMth+1, 0).getDate(), // number of days in selected month
        startDay = new Date(cal.sYear, cal.sMth, 1).getDay(), // first day of the month
        endDay = new Date(cal.sYear, cal.sMth, daysInMth).getDay(); // last day of the month

    // LOAD DATA FROM LOCALSTORAGE


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
    var _Day ;//= <% Response.Write(min_date)%>;
    var _dd =  <% Response.Write(_dd)%>;
    var _mm =  <% Response.Write(_mm)%>;
    var _yyyy =  <% Response.Write(_yyyy)%>;
    var month = document.getElementById("cal-mth");
    var _month = month.options[month.selectedIndex].value;
    var year = document.getElementById("cal-yr");
    var _year = year.options[year.selectedIndex].value;
    var total = squares.length;
    cRow = document.createElement("tr");

    var i_day = 0;
    for (var i=0; i<total; i++) {
    
          cCell = document.createElement("td");
          cRow.classList.add("day");
          if (squares[i]=="b") { cCell.classList.add("blank"); }
          else {
          i_day += 1; 
            cCell.innerHTML = "<div class='dd'>"+squares[i]+"</div>";
            if (cal.data[squares[i]]) {
                if(_yyyy == parseInt(_year)){

                    if(_mm == (parseInt(_month) + 1)){
                    
                        if( (i_day) >= _dd){
                                cCell.classList.add("avai"); 
                          }
                        else{
                            cCell.classList.add("not_avai"); 

                        }
                    }
                    else if(_mm < (parseInt(_month) + 1)){
                        cCell.classList.add("avai"); 
                    }
                    else{
                        cCell.classList.add("not_avai"); 
                    }
                }
                else if(_yyyy < parseInt(_year)){
                    cCell.classList.add("avai"); 
                }
                else{
                    cCell.classList.add("not_avai");
                }
                cCell.innerHTML += "<div class='evt'>" + cal.data[squares[i]] + "</div>";
            }
            else{
                if(_yyyy == parseInt(_year)){

                    if(_mm == (parseInt(_month) + 1)){
                    
                        if( (i_day) >= _dd){
                                cCell.classList.add("avai"); 
                          }
                        else{
                            cCell.classList.add("not_avai"); 

                        }
                    }
                    else if(_mm < (parseInt(_month) + 1)){
                        cCell.classList.add("avai"); 
                    }
                    else{
                        cCell.classList.add("not_avai"); 
                    }
                }
                else if(_yyyy < parseInt(_year)){
                    cCell.classList.add("avai"); 
                }
                else{
                    cCell.classList.add("not_avai");
                }
//                cCell.innerHTML += "<div class='evt'>" + cal.data[squares[i]] + "</div>";
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

    tForm += "<input class='w3-button w3-purple2 w3-padding w3-round w3-margin w3-right' type='button' value='ปิด' onclick='cal.close()'/>";
    tForm += "<input class='w3-button w3-purple2 w3-padding w3-round w3-margin w3-right' type='button' value='ลบ' onclick='cal.del()'/>";
    tForm += "<input class='w3-button w3-purple2 w3-padding w3-round w3-margin w3-right' type='submit' value='บันทึก'/>"; 
    tForm += "<br/><br/><br/>";
    
 
    // ATTACH
    var eForm = document.createElement("form");
    eForm.addEventListener("submit", cal.save);
    eForm.innerHTML = tForm;
    var container = document.getElementById("cal-event");
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

    localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, JSON.stringify(cal.data));
    cal.list();
    document.getElementById("MainContent_HidData").value = _1_day + ":" + _2_day;

    document.getElementById("MainContent_Hidmonth").value = cal.sMth + 1;
    document.getElementById("MainContent_Hidyear").value = cal.sYear;

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

  // APPEND MONTHS SELECTOR
  var month = document.getElementById("cal-mth");
  for (var i = 0; i < 12; i++) {
    var opt = document.createElement("option");
    opt.value = i;
    opt.innerHTML = cal.mName[i];
    if (i==nowMth) { opt.selected = true; }
    month.appendChild(opt);
  }

  // APPEND YEARS SELECTOR
  // Set to 10 years range. Change this as you like.
  var year = document.getElementById("cal-yr");
  for (var i = nowYear-5; i<=nowYear+10; i++) {
    var opt = document.createElement("option");
    opt.value = i;
    opt.innerHTML = i;
    if (i==nowYear) { opt.selected = true; }
    year.appendChild(opt);
  }

  // START - DRAW CALENDAR
  document.getElementById("cal-set").addEventListener("click", cal.list);
  cal.listAll();
});

</script>
  <header class="w3-container" style="margin-top: 10px;margin-bottom: 5px;">
<a ><b style="font-size:1.5em;margin-left:0%;font-family: 'Kanit', sans-serif;">จัดการข้อมูลวันหยุดประจำปี</b></a>
</header>

<div id="page-body" class="w3-col l8 w3-right-align">
    <%-- [PERIOD SELECTOR] --%>
    <div id="cal-date">
      <select id="cal-mth" class="w3-border w3-round-large"></select>
      <select id="cal-yr" class="w3-border w3-round-large"></select>
      <input id="cal-set" class="w3-button w3-purple2 w3-padding w3-round w3-margin" type="button" value="ค้นหา"/>
      <input id="btnDtl" class="w3-button w3-purple2 w3-padding w3-round w3-margin" type="button" value="ดูวันหยุดประจำปี" onclick="document.getElementById('MainContent_BtnDtl').click()"/>
    </div>
    <center>
    <%-- [CALENDAR] --%>
    <div id="cal-container"></div>

    <%-- [EVENT] --%>
    <div id="cal-event"></div>

    </center>
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
        <asp:Button style="DISPLAY: none" id="BtnDelete" onclick="BtnDelete_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnSave" onclick="BtnSave_Click" runat="server" UseSubmitBehavior="false"></asp:Button> 
        <asp:Button style="DISPLAY: none" id="BtnDtl" onclick="BtnDtl_Click" runat="server" UseSubmitBehavior="false" ></asp:Button> 

   <asp:UpdatePanel ID="updateCommand" runat="server">
    <ContentTemplate>
     <asp:ImageButton ID="BtnSch" runat="server"  ImageUrl="~/images/schd.gif" />
    </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>
</asp:Content>

