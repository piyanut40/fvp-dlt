<%@ page title="" language="VB" masterpagefile="~/MasterPage.master" autoeventwireup="false" CodeFile="Manual2.aspx.vb" inherits="Manual2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.container{
  background-color:#F8F9F9;
  padding: 2rem;
  box-shadow: 4px 4px 8px rgba(0,0,0,0.1);
}
#mapContact
{
    width:1080px;
    height:450px;
}
@media screen and (min-width: 1025px) and (max-width:1449px)
{
     #mapContact
{
    width:800px;
    height:450px;
}
}
@media screen and (min-width: 980px) and (max-width:1024px)
{
   #mapContact
{
    width:650px;
    height:450px;
}
}
@media screen and (min-width: 480px) and (max-width:767px) and (orientation : portrait)
{
   #mapContact
{
    width:350px;
    height:350px;
}
   
 }
 
@media screen and (min-width: 375px) and (max-width:479px) and (orientation : portrait)
{
    #mapContact
{
    width:270px;
    height:270px;
}
    
    }
 @media screen and (min-width: 360px) and (max-width:376px) and (orientation : portrait)
 {
    
    #mapContact
{
    width:250px;
    height:250px;
}
     
}
 @media screen and (min-width:320px) and (max-width:359px) and (orientation : portrait)
 {#mapContact
{
      width:220px;
    height:220px;
}
  
  
  }
</style>

<div class="container" style=" max-width: 1200px">
<center>
<asp:Image ID="Image1" runat="server" ImageUrl="~/image/dlt_bw.png" Width="150px" /><br /><br />

              <h1 class="w3-purple w3-padding" style="font-size: 2rem;"><b>How to Apply for FVP (Foreign Vehicle Permit)
<br />before Using Private Foreign Registered Vehicle in Thailand
</b></h1>
        <%--<hr style="height:3px; border:none; width:370px; color:#542a6b; background-color:#542a6b; margin-top:-0.5%">--%>
  <br />

<div class="w3-container w3-left-align " >
    <h3 class="w3-purple w3-padding"> <b>[1] Type of vehicle eligible to apply for permit </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>Every traveler planning to use private foreign registered vehicle in Thailand must apply for the temporary permit through Thai travel agency. The travel agency will have to submit the application to Department of Land Transportvia FVP system [URL: <a href="https://fvp.dlt.go.th/" target="_blank">https://fvp.dlt.go.th/</a>] no less than <u>5 working days prior to the date of entry</u>.</span>
    </h3>

   <h3 class="w3-margin-left64"> <b> Vehicles which are eligible for application are as follow; </b></h3> 
   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Passenger car with no more than 9 seats (including driver seat) </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Pick-up truck weighting no more than 3,500 kilograms </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	Motorcycle </h3>

    <h3 > <b><u>NOT ELIGIBLE FOR APPLICATION</u></b>:</h3>
    <h3 class="w3-margin-left64">  Camper Cars, Motorhomes, Buses and Trucks </h3>

    <h3 > <b><u>EXEMPTED FROM THIS REGULATION</u></b>:</h3>
    <h3 class="w3-margin-left64" style="text-align: justify">  -	Vehicles used for collaboration between Thai Government and Foreign Government  </h3>
    <h3 class="w3-margin-left64" style="text-align: justify">  -	Foreign registered vehicle frequently used around the border which is registered to the local Customs and/or the local Immigration.  </h3>
    <h3 class="w3-margin-left64" style="text-align: justify">  -	Vehiclesregistered in Lao, Malaysia and Singapore  </h3>

    <h3 style="text-align: justify"> 
        <span>The approval is also subjected to whether the conditions stated in [4] are satisfied.</span>
    </h3>
    <br />
    <h3 class="w3-purple w3-padding"> <b>[2] How to apply for the permit </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>Those who plan to use foreign registered vehicle in Thailand must apply for <b>FVP (Foreign Vehicle Permit)</b>through Thai licensed travel agency.</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Travel agency must operate with <u>inbound or outbound tourism business license</u>. </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Travel agency must be registered to Foreign Vehicle Permit System (FVP System) in order to submit application for FVP. [URL: <a href="https://fvp.dlt.go.th/" target="_blank">https://fvp.dlt.go.th/</a>] </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	The application andrequired documents mustbe submitted by travel agency no less than 5 working days prior to the date of entry. </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  4.	If approved, travel agency must print out the application form from FVP System and bring it to the provincial land transport office to make payment and pick up FVP.  </h3>

   <br />
    <h3 class="w3-purple w3-padding"> <b>[3] Validity of the temporary permit </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>The validity of the temporary permit will be issued according to the submitted itinerary.However,</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	The itinerary attached to each application shall not go over 30 days. </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Each vehicle is restricted with60-day quota per year. </h3>

   <br />
    <h3 class="w3-purple w3-padding"> <b>[4] Conditions regarding Escorting Vehicles </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>In addition, the travel agency must assign tour guides/escortsto assist and lead traveler(s) throughout thewhole journey in Thailand. The guidelines are as follow;</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	1-5 vehicles: At least one tour guide/escort and oneescorting vehicle. </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	6-15 vehicles:At least 2 tour guides/escorts and 2escorting vehicles  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	More than 15 vehicles: At least 3 tour guides/escorts and 3 escorting vehicles  </h3>

   <h3 style="text-align: justify"> 
        <span><b>Tour guides or escorts must be Thai nationalsand at leastone of the escorting vehicle must be Thai-registered</b>. In the case of more than one escorting vehicle, tour guides/escorts mayalso aboardtraveler’s vehicle. Travel agency shall declare the list of tour guides/escortsalong with respective vehicleeach one is assigned to drive/aboard.</span>
    </h3>

    <br />
    <h3 class="w3-purple w3-padding"> <b>[5] List of required documents for the application </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>Documents concerning travel agency are as follow;</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	National identification card or Certificate of legal person registration </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Certified copy of tourism business license (issued by Tourism Department)  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	Power of attorney (only if the tourism business license holder is not able to process the application by themselves.)  </h3>
   <br />
    <h3 style="text-align: justify"> 
        <span><b>Documents concerningtravelers are as follow;</b></span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Photo of passport with no less than 6 months of validity and visa if applicable </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Photo of driving license (see [6] for more information regarding driving license)  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	Photo of vehicle registration certificate  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  4.	Photo of vehicle inspection certificate or certified proof of road worthiness  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  5.	Letter of Consent (only if the owner of the vehicle not participating inthejourney)  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  6.	Pictures of the vehicle in color(body typeand license plate must be clearly visible)  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  7.	Photo of Thaicompulsory motor vehicle insurance schedule by Thai insurance company  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  8.	Photo of Thaithird party liability insurance schedulewith minimum coverage of;  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  a.	At least 1,000,000 THB of loss of life, bodily injury or damage to health, per person in an accident  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  b.	At least 1,000,000 THB of property damage liability per accident  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  9.	Detailed itinerary indicating all provinces in the planned route  </h3>
   <br />
   <h3  style="text-align: center"><b>In the document is not in English, the certified Thai or English translation <br />by the competent authority must also be submitted.</b>   </h3>

    <br />
    <h3 class="w3-purple w3-padding"> <b>[6] The fees </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>The fee will be collected according to type of vehicle in application as follows;</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Application processing fee of 500 THB per vehicle </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Permit issuance fee;  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  a.	200 THB per permit for motorcycle  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  b.	500 THB per permit for passenger car and pick-up truck  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	The administrative fee of 5 THB per vehicle  </h3>

   <br />
    <h3 class="w3-purple w3-padding"> <b>[7] Driving license </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>Driving licenses issued by other country’s authority which are valid and recognized by Thai authorities are as follow;</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Driving license issued by the competent authority of ASEAN member states. However, a certified English translation by the competent authority is also required if the license does not have English. </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	International driving permit (IDP) issued in accordance with Convention on Road Traffic signed in Geneva on 19 September 1949.  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	International driving permit (IDP) issued in accordance with Convention on Road Traffic signed in Vienna on 8 November 1968.  </h3>

   <h3 style="text-align: justify"> 
        <span><b>If traveler does not have any of the aforementioned driving licenses,</b> it is the responsibility of travel agency to assist traveler in acquiring the temporary driving license (30-days validity) on the date of entry atthe provincial land transport office located within the province of entry.</span>
    </h3>

     <br />
    <h3 class="w3-purple w3-padding"> <b>[8] Acquiring the 30-day temporary driving license  </b></h3> 
    <br />
    <h3 style="text-align: justify"> 
        <span>After completing all immigration and customs clearance procedures on the date of entry, travel agency must escort traveller(s)who is without valid driving licenseto the nearest provincial land transport office in the province of entry. The required documents are as follow;</span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Passport with no less than 6 months of validity </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Letter by travel agency giving consent for the traveller to use agency’s address as a reference of residence in the temporary driving license  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	A medical certificate   </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  4.	A valid driving license issued by the foreign government and a certified Thai or English translation by the competent authority  </h3>

   <h3 style="text-align: justify"> 
        <span><b>The procedures are as follow;</b></span>
    </h3>

   <h3 class="w3-margin-left64" style="text-align: justify">  1.	Take physical test </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	Attend 1 hour of training session  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  3.	Pay the feeand collect the driving license   </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  a.	Temporary driving license	200 THB  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  b.	The administration fee	5 THB </h3>

   <br />
    <h3 class="w3-purple w3-padding"> <b>[9] For more information </b></h3> 
    <br />
   <h3 class="w3-margin-left64" style="text-align: justify">  1.	For Bangkok:Department of Land Transport (DLT) </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  1032 Phaholyothin Road, ChomPhon, Chatuchak, Bangkok 10900  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  -	Bangkok Land Transport Office Area 5 (Building 2 Floor 3)  </h3>
   <h3 class="w3-margin-left128" style="text-align: justify">  -	International Transport Affairs Sub-division(Building 4 Floor 5)  </h3>
   <h3 class="w3-margin-left64" style="text-align: justify">  2.	For other provinces:The provincial land transport office (main branch)  </h3>

   <br /><br />
   <h3 style="text-align: center"><b>-------------------------Updated as of September 2021-------------------------</b>   </h3>
   <br /><br />
   <h3 style="text-align: center">Foreign registered vehicle without the temporary permit shall be denied from entering Thailand.<br />
Driving in Thailand without valid driving license is an offense.
   </h3>
</div>

<div class="w3-container w3-left-align " style="display:none">
    <h3 > <b>๑๐. ระบบจะแสดงรายการกรุ๊ปทัวร์พร้อมสถานะ Success กรณีกดปุ่ม Submit  และจะส่งคำขออนุญาตดังกล่าวไปยังเจ้าหน้าที่สำนักงานขนส่งจังหวัด ดังแสดงในรูปที่ ๑.๒๒ </b></h3> 

    <center class="w3-padding-16" ><asp:Image ID="Image3" runat="server" ImageUrl="~/Upload/FileManual/Manual1_22.png" />
        <p>รูปที่ ๑.๒๒ หน้าจอตารางรายการกรุ๊ปทัวร์</p></center>

   <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๑.๒.๔ ตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวรายคันที่ยังไม่ผ่านการพิจารณา </b></h3>
   <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถตรวจสอบรายการคำขออนุญาตรถเพื่อการท่องเที่ยวรายคันได้ โดยกดที่เมนู “Active and Rejected Application” รายการคำขออนุญาตที่ถูกส่งไปยังเจ้าหน้าที่สำนักงานขนส่งจังหวัดจะขึ้นสถานะ Pending ดังแสดงในรูปที่ ๑.๒๓ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image4" runat="server" ImageUrl="~/Upload/FileManual/Manual1_23.png" />
        <p>รูปที่ ๑.๒๓ หน้าจอตารางรายการคำขออนุญาต</p></center>

         <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ระบบจะแจ้งเตือนการยื่นขออนุญาตรถเพื่อการท่องเที่ยวให้ผู้ประกอบธุรกิจนำเที่ยวและนักท่องเที่ยวทราบทาง E-mail ดังแสดงในรูปที่ ๑.๒๔ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image5" runat="server" ImageUrl="~/Upload/FileManual/Manual1_24.png" />
        <p>รูปที่ ๑.๒๔ หน้าจอการแจ้งเตือนการยื่นขออนุญาตทาง E-mail</p></center>

       <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๑.๒.๕ ตรวจสอบรายการคำขออนุญาตรถเพื่อการที่ผ่านการอนุมัติ </b></h3>

  <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถตรวจสอบคำขอที่ผ่านการอนุมัติจากเจ้าหน้าที่สำนักงานขนส่งจังหวัดได้ โดยกดที่เมนู “Permit” คำขออนุญาตที่ผ่านการอนุมัติจากเจ้าหน้าที่สำนักงานขนส่งจังหวัดจะแสดงสถานะ Pass(Waiting for payment) จากนั้นกดปุ่ม <asp:Image ID="Image7" runat="server" ImageUrl="~/Upload/FileManual/Manual_pdf.png" /> เพื่อตรวจสอบและพิมพ์ใบคำขออนุญาตดังแสดงในรูปที่ ๑.๒๕ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image6" runat="server" ImageUrl="~/Upload/FileManual/Manual1_25.png" />
        <p>รูปที่ ๑.๒๕ หน้าจอตารางรายการคำขออนุญาตที่ผ่านการอนุมัติ</p></center>

    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	หลังจากทำการพิมพ์ใบคำขออนุญาต ผู้ขออนุญาตต้องทำการตรวจสอบความถูกต้องภายในเอกสาร หากไม่ถูกต้องให้ทำการติดต่อไปยังสำนักงานขนส่งจังหวัดเพื่อทำการแก้ไขข้อมูล หากถูกต้องครบถ้วนให้ลงลายมือชื่อผู้ดำเนินการเพื่อรับรองว่าข้อมูลถูกต้องและเป็นความจริง และนำใบคำขออนุญาตไปยื่นพร้อมชำระค่าธรรมเนียมที่สำนักงานขนส่งจังหวัดที่ได้ทำการระบุไว้ในขั้นตอนการสร้างกรุ๊ปทัวร์ เพื่อรับเครื่องหมายแสดงการใช้รถ ดังแสดงในรูปที่ ๑.๒๖ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image9" runat="server" ImageUrl="~/Upload/FileManual/Manual1_26.png" />
        <p>รูปที่ ๑.๒๖ หน้าจอแสดงตัวอย่างใบคำขออนุญาต</p></center>

         <h3 > <b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ๑.๒.๖ การขอขยายเวลา </b></h3>

    <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑.	ผู้ประกอบธุรกิจนำเที่ยวสามารถยื่นขอขยายเวลาได้โดยกดที่เมนู ”All Tour Group” จากนั้นเลือกกรุ๊ปทัวร์ที่ต้องการขอขยายเวลาจากนั้นกดปุ่ม <asp:Image ID="Image10" runat="server" ImageUrl="~/Upload/FileManual/Manual_add.png" />  เพื่อขอขยายเวลา โดยกรุ๊ปทัวร์ดังกล่าวต้องมีสถานะ “Success” ดังแสดงในรูปที่ ๑.๒๗ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image8" runat="server" ImageUrl="~/Upload/FileManual/Manual1_27.png" />
        <p>รูปที่ ๑.๒๗ หน้าจอยื่นขอขยายเวลา</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๒.	ผู้ประกอบธุรกิจนำเที่ยวกรอก End dateและสาเหตุที่ขอขยายเวลาและไฟล์แจ้งวัตถุประสงค์การขอขยายเวลาจากนั้นกดปุ่ม Next ดังแสดงในรูปที่ ๑.๒๘ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image12" runat="server" ImageUrl="~/Upload/FileManual/Manual1_28.png" />
        <p>รูปที่ ๑.๒๘ หน้าจอยื่นขอขยายเวลา(๒)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๓.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวสามารถเลือกรถที่จะขอขยายเวลาได้เป็นรายคัน จากนั้นกดปุ่ม Add ดังแสดงในรูปที่ ๑.๒๙ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image11" runat="server" ImageUrl="~/Upload/FileManual/Manual1_29.png" />
        <p>รูปที่ ๑.๒๙ หน้าจอยื่นขอขยายเวลา(๓)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๔.	ผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขข้อมูลคนขับได้ โดยกดปุ่ม <asp:Image ID="Image14" runat="server" ImageUrl="~/Upload/FileManual/Manual_edit.png" /> ดังแสดงในรูปที่ ๑.๓๐ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image13" runat="server" ImageUrl="~/Upload/FileManual/Manual1_30.png" />
        <p>รูปที่ ๑.๓๐ หน้าจอยื่นขอขยายเวลา(๔)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๕.	หลังจากผู้ประกอบธุรกิจนำเที่ยวแก้ไขข้อมูลคนขับเรียบร้อย สามารถกดปุ่ม Next เพื่อบันทึกข้อมูลคนขับใหม่ลงในระบบ ดังแสดงในรูปที่ ๑.๓๑ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image16" runat="server" ImageUrl="~/Upload/FileManual/Manual1_31.png" />
        <p>รูปที่ ๑.๓๑ หน้าจอยื่นขอขยายเวลา(๕)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๖.	เมื่อผู้ประกอบธุรกิจนำเที่ยวเพิ่มข้อมูลคนขับครบถ้วนแล้ว จากนั้นผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขหรือเพิ่มข้อมูลประกันภัยใหม่ได้ โดยกดปุ่ม <asp:Image ID="Image17" runat="server" ImageUrl="~/Upload/FileManual/Manual_edit.png" /> ที่ช่อง Insurance ดังแสดงในรูปที่ ๑.๓๒ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image15" runat="server" ImageUrl="~/Upload/FileManual/Manual1_32.png" />
        <p>รูปที่ ๑.๓๒ หน้าจอยื่นขอขยายเวลา(๖)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๗.	จากนั้นผู้ประกอบธุรกิจนำเที่ยวเพิ่มข้อมูลประกันภัยให้ครบถ้วน หลังจากนั้นกดปุ่ม save ดังแสดงในรูปที่ ๑.๓๓ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image19" runat="server" ImageUrl="~/Upload/FileManual/Manual1_33.png" />
        <p>รูปที่ ๑.๓๓ หน้าจอยื่นขอขยายเวลา(๗)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๘.	เมื่อผู้ประกอบธุรกิจนำเที่ยวเพิ่มข้อมูลคนขับครบถ้วนแล้วกดปุ่ม Next ดังแสดงในรูปที่ ๑.๓๔ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image18" runat="server" ImageUrl="~/Upload/FileManual/Manual1_34.png" />
        <p>รูปที่ ๑.๓๔ หน้าจอยื่นขอขยายเวลา(๘)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๙.	ผู้ประกอบธุรกิจนำเที่ยวสามารถแก้ไขข้อมูลผู้นำเที่ยวหรือข้อมูลรถนำเยวได้ โดยการลบข้อมูลผู้นำเที่ยวหรือรถนำเที่ยวเดิมออกก่อน จากนั้นจึงกรอกข้อมูลลงในระบบใหม่ จากนั้นกดปุ่ม Submit ดังแสดงในรูปที่ ๑.๓๕ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image20" runat="server" ImageUrl="~/Upload/FileManual/Manual1_35.png" />
        <p>รูปที่ ๑.๓๕ หน้าจอยื่นขอขยายเวลา(๙)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๐. ระบบจะแสดงรายการที่ผู้ประกอบธุรกิจนำเที่ยวได้ทำการขอขยายเวลาไป โดยจะมีสถานะ Pending และเป็นการขยายเวลาครั้งที่ ๑ ดังแสดงในรูปที่ ๑.๓๖ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image21" runat="server" ImageUrl="~/Upload/FileManual/Manual1_36.png" />
        <p>รูปที่ ๑.๓๖ หน้าจอยื่นขอขยายเวลา(๑๐)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๑. หลังจากได้รับการอนุมัติขอขยายเวลาจากทางเจ้าหน้าที่กรมการขนส่งทางบกเรียบร้อยแล้ว สถานะของกรุ๊ปทัวร์จะเปลี่ยนเป็น Success ดังแสดงในรูปที่ ๑.๓๗ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image22" runat="server" ImageUrl="~/Upload/FileManual/Manual1_37.png" />
        <p>รูปที่ ๑.๓๗ หน้าจอยื่นขอขยายเวลา(๑๑)</p></center>

        <div style="text-align: justify"> 
        <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ๑๒. เจ้าหน้าที่กรมการขนส่งทางบกสามารถตรวจสอบกรุ๊ปทัวร์ที่ยื่นขอขยายเวลา ว่าขอขยายเวลาจากกรุ๊ปทัวร์ใดได้ โดยกดปุ่ม <asp:Image ID="Image24" runat="server" ImageUrl="~/Upload/FileManual/Manual_dtl.png" /> ดังแสดงในรูปที่ ๑.๓๘ </span>
    </div>

     <center class="w3-padding-16" ><asp:Image ID="Image23" runat="server" ImageUrl="~/Upload/FileManual/Manual1_38.png" />
        <p>รูปที่ ๑.๓๘ หน้าจอยื่นขอขยายเวลา(๑๒)</p></center>

</div>
</center> 

<%--<hr />--%>
 

</div>

</asp:Content>
  
 
<asp:Content ID="Content5" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

