<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_eval.aspx.vb" Inherits="bookings_eval"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="bookings_enquiry.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add New Enquiry">Add New Enquiry</a> 
                               </li> 

                                

    <li class="no_colour">
                                    <a  href="bookings_search.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Booking</a> 
                               </li> 

       <li class="no_colour">
                                    <a  href="bookings_new_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add a New Client</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="bookings_edit_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View & Edit Client</a> 
                               </li> 

    
                 
       <li class="no_colour">
                                    <a  href="accom_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Accom Diary Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Accommodation Diary</a> 
                               </li>    

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Diary General Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="general_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary General Event</a> 
                               </li>   
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div> 

   <h1 class="page-title" style="text-align:center;">Client's Evaluation Form</h1>


    <div class="form-input fl">
    <asp:Button ID="BUT_Back_to_Booking" Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" runat="server" Text="&nbsp;Back to Booking" /> </div>


    <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">

                         
            <table id="booking_tables" border="1">
              
                <tr><th colspan="4" style="height:30px;">Booking Information</th></tr>
                   <tr><td>&nbsp;Booking ID:</td>
                    <td><asp:Label ID="LABEL_Booking_ID" runat="server" Text="&nbsp;Booking ID&nbsp;"></asp:Label></td>
                       <td>&nbsp;Tour:</td>
                    <td><asp:Label ID="LABEL_Tour_and_Stage" runat="server" Text="&nbsp;Tour & Stage #"></asp:Label></td>
                    
                </tr>

                 <tr>
                     <td>&nbsp;Client Name:</td>
                    <td><asp:Label ID="LABEL_Client_Name" runat="server" Text="&nbsp;Client Name"></asp:Label></td>
                       <td>&nbsp;Stage #</td>
                    <td><asp:Label ID="LABEL_Stage" runat="server" Text="&nbsp;Stage #"></asp:Label></td>
               
                </tr>
                  <tr>
                 <td>&nbsp;Total Number in Party:</td>
                    <td><asp:Label ID="LABEL_Total_Number_in_Party" runat="server" Text="&nbsp;Total Number in Party"></asp:Label></td>
                      <td>&nbsp;Total Amount Payable:</td>
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td>
               
</tr>

                   <tr>
                <td>&nbsp;Customised?</td>
                    <td><asp:CheckBox ID="CHK_Customised" enabled="false" style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>
          
</div>
   </section>  

       

 <section class="grid_12">
     <div class="form has-validation">


<div id="Top_Div">

	      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
               
<div class="form has-validation">

 <div class="clearfix" style="background:#ABC4DC;padding:10px;color:#000;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th > Where did you first hear about Easyways?</th>
						
					</tr>
				</thead>
            </table>
           </div> 
                               

                 <div class="clearfix">               
                                <div class="form-input" style="float:left; width:100%">
                                    <asp:TextBox ID="TB_Client_Referrer" name="firstname"  ReadOnly="true" placeholder="Let us know how you heard about us" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>
</div>
<br />
<div class="form has-validation">
 <div class="clearfix" style="background:#ABC4DC;padding:10px;color:#000;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th >Overall Rating of Easyways Service</th>
						
					</tr>
				</thead>
            </table>
           </div> 

        <div class="clearfix">
                          
                                <div class="form-label" style="color:black;">Overall Rating of Easyways Service:</div>
                               
                               
                                <div class="form-input">
                                   
                              
                          <asp:Label ID="LABEL_Overall_EW_Rating" runat="server" ReadOnly="true" Text="Rating"></asp:Label>

                          </div> 

                            </div>
        <div class="clearfix">
                          
                                <div class="form-label" style="color:black;">Ease of Booking:</div>
                               
                               
                                <div class="form-input">
                                   
                              
                                   <asp:Label ID="LABEL_Ease_of_Booking" runat="server" ReadOnly="true" Text="Rating"></asp:Label>

                          </div> 

                            </div>


        <div class="clearfix">
                          
                                <div class="form-label" style="color:black;">Quality of Info Provided:</div>
                               
                               
                                <div class="form-input">
                                   
            <asp:Label ID="LABEL_Rating_Quality_of_Info" runat="server" ReadOnly="true" Text="Rating"></asp:Label>

                          </div> 

                            </div>


        <div class="clearfix">
                          
                                <div class="form-label" style="color:black;">Value for money:</div>
                               
                               
                                <div class="form-input">
                                   
                                    <asp:Label ID="LABEL_Value_for_Money" runat="server" ReadOnly="true" Text="Rating"></asp:Label>
                                 
                          </div> 

                            </div>

    </div>
    <br />
<div class="form has-validation">
 <div class="clearfix" style="background:#ABC4DC;padding:10px;color:#000;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th >Use this section to give feedback to tell us something about your walk that would be helpful to share with fellow walkers, e.g. restaurants, pubs, points of interest etc.</th>
						
					</tr>
				</thead>
            </table>
           </div> 
      
                 <div class="clearfix">               
                                <div class="form-input" style="float:left;width:100%">
                                    <asp:TextBox ID="TB_Feedback" TextMode="MultiLine" name="feecback"  ReadOnly="true" rows="5" placeholder="Write your feedback here" runat="server"></asp:TextBox>   

         
                                        
                                </div>

                            </div>





</div>
     <br />

                        <div class="form has-validation">
 <div class="clearfix" style="background:#ABC4DC;padding:10px;color:#000;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th>Use this section to give feedback on the accommodation booked by EasyWays on your behalf. <br /> <br />Please Rate on the basis of 1 – 5:<br /> 1 = Poor / 2 = Fair / 3 = Average / 4 = Very Good / 5 = Excellent</th>
						
					</tr>
				</thead>
            </table>
           </div> 
                    <div class="section group" style="font-weight:bold;color:#000;text-align:left;padding:10px;">
	<div class="col span_7_of_6">
	Accommodation
	</div>
	<div class="col span_4_of_6">
	Welcome
	</div>
	<div class="col span_4_of_6">
	Cleanliness
	</div>
	<div class="col span_4_of_6">
	Breakfast
	</div>
	<div class="col span_4_of_6">
	Facilities
	</div>
	<div class="col span_4_of_6">
	Overall
	
</div></div>

<%
    If objFunction.CheckDataSet(dstAccomStageEvalBookingDetail) Then
        For i = 0 To dstAccomStageEvalBookingDetail.Tables(0).Rows.Count - 1
            Dim intIndex As Integer = (i + 1)
%>
<div class="section group" style="font-weight:bold;font-size:medium;text-align:center;padding:10px;">
	<div class="col span_7_of_6" style="text-align:left">
        <%--<asp:Label ID="LABEL_Accom1" ReadOnly="true" runat="server" Text="Accom1"></asp:Label>  --%>
        <label id="LABEL_Accom_<%= intIndex %>"><%= (If(objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("AccomName")) <> "", objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("AccomName")), "&nbsp;")) %></label>
    </div>
    <div class="col span_4_of_6">
        <%--<asp:Label ID="LABEL_Rating_Welcome1" runat="server" ReadOnly="true" Text="Rating"></asp:Label>--%>
        <label id="LABEL_Rating_Welcome_<%= intIndex %>"><%= objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("welcome"))%></label>
    </div>
    <div class="col span_4_of_6">
        <%--<asp:Label ID="LABEL_Rating_Cleanliness1" runat="server" ReadOnly="true" Text="Rating"></asp:Label>--%>
        <label id="LABEL_Rating_Cleanliness_<%= intIndex %>"><%= objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("cleanliness"))%></label>
    </div>
    <div class="col span_4_of_6">
        <%--<asp:Label ID="LABEL_Rating_Breakfast1" runat="server" ReadOnly="true" Text="Rating"></asp:Label>--%>
        <label id="LABEL_Rating_Breakfast_<%= intIndex %>"><%= objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("breakfast"))%></label>
    </div>
    <div class="col span_4_of_6">
        <%--<asp:Label ID="LABEL_Rating_Facilities1" runat="server" ReadOnly="true" Text="Rating"></asp:Label>--%>
        <label id="LABEL_Rating_Facilities_<%= intIndex %>"><%= objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("facilities"))%></label>
    </div>
    <div class="col span_4_of_6">
        <%--<asp:Label ID="LABEL_Rating_Accom_Overall" runat="server" ReadOnly="true" Text="Rating"></asp:Label>--%>
        <label id="LABEL_Rating_Accom_Overal_<%= intIndex %>"><%= objFunction.ReturnString(dstAccomStageEvalBookingDetail.Tables(0).Rows(i)("overall"))%></label>
    </div>
</div>
<%   
        Next
    End If
%>

</div>

</div></div>
    </div>



</div>
</section>
</div>


</asp:Content>
