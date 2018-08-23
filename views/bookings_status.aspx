<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_status.aspx.vb" Inherits="bookings_status"  ValidateRequest="false"%>
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
    

        
   <h1 class="page-title" style="text-align:center;">View Booking Status</h1>

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
                       <td>&nbsp;Stage #:</td>
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
                    <td><asp:CheckBox ID="CHK_Customised"  enabled="false" style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>
          
</div>
   </section>

         <section class="grid_12">
				<div class="form has-validation">

               
    
                      <div class="clearfix">
                                  <asp:Label ID="Label_Accom_Booked" runat="server" class="form-label" Text="All Accommodation Booked"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:CheckBox ID="CHK_Accom_Booked" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />
                                     

                          </div> </div>
            
                   
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Baggage_Booked" runat="server" class="form-label" Text="All Baggage Booked"></asp:Label>
                              
                                  <div class="form-input">
                                  <asp:CheckBox ID="CHK_Baggage_Booked" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                  

                          </div> </div>
             

            
                              <div class="clearfix">
                                  <asp:Label ID="Label_Extras_Booked" runat="server" class="form-label" Text="All Extras Booked"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Extras_Booked" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                                     

                          </div> </div>
                         
            
                      <div class="clearfix">
                                  <asp:Label ID="LABEL_Accom_Email_Sent" runat="server" class="form-label" Text="Accom Confirmation Email Sent"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:CheckBox ID="CHK_Accom_Email_Sent" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                  

                          </div> </div>
             

                      <div class="clearfix" id="DIV_Agent" runat="server">
                                  <asp:Label ID="LABEL_Agent_Conf_Sent" runat="server" class="form-label" Text="Confirmation Sent to Agent"></asp:Label>
                              
                                  <div class="form-input">
                             <asp:CheckBox ID="CHK_Agent_Email_Conf_Sent" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                  

                          </div> </div>
             

                              <div class="clearfix">
                                  <asp:Label ID="Label_Invoice_Sent" runat="server" class="form-label" Text="Invoice Sent"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Invoice_Sent" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                                </div>

                            </div>
                     <div class="clearfix">
                                  <asp:Label ID="LABEL_Deposit_Received" runat="server" class="form-label" Text="Deposit Received"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Deposit_Received" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                                </div>

                            </div>

                     <div class="clearfix">
                                  <asp:Label ID="LABEL_URL_Sent" runat="server" class="form-label" Text="URL Sent"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_URL_Sent" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                                </div>

                            </div>

                     <div class="clearfix">
                                  <asp:Label ID="LABEL_Eval_Rec" runat="server" class="form-label" Text="Evaluation Form Received"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Eval_Rec" enabled="false" style="margin-top:2%;margin-left:2%;" runat="server" />

                                </div>

                            </div>
                          
                  
                 
				</div>

           
      

        </section>

 </div>        
    

</asp:Content>
