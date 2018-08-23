<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_new_client.aspx.vb" Inherits="bookings_new_client"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
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

                                  

  <li class="no_colour"><a href="reports_status_all.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Booking Status Report</a></li> 

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

rel="popover" >Add/Edit Accom Diary Event</a> 
                               </li> 

                                      
                                  

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add/Edit General Diary Event</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary</a> 
                               </li>    
                                                                 <li class="no_colour">
                                    <a  href="reports_live_walkers.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Walkers Diary</a> 
                               </li>    
                                
                                 
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div> 
 


    <h1 class="page-title" style="text-align:center;">Enter New Client Details</h1>
  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    
    <div class="form has-validation">
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Enter New Client Details</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   
       
       <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_New_Client">

                    
                            <div class="clearfix">
                          
                                <div class="form-label">First Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_firstname" name="firstname" required="required" placeholder="First Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Surname</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_surname" name="surname" required="required" placeholder="Surname" runat="server"></asp:TextBox>   


                                </div></div>

                                <div class="clearfix">

                                <div class="form-label">URL Name</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_UrlName" name="UrlName" placeholder="URL Name" runat="server"></asp:TextBox>   


                                </div></div>

                                <div class="clearfix">
                          
                                <div class="form-label">Address Line 1</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Address1" name="address1" placeholder="Address Line 1" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Address Line 2</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Address2" name="address2" placeholder="Address Line 2" runat="server"></asp:TextBox>   


                                </div> </div>


                                         <div class="clearfix">
                          
                                 <div class="form-label">City</div> 
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_city" name="city"  placeholder="City" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                               <div class="clearfix">
                          
                                <div class="form-label">Postcode</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_postcode" name="postcode" placeholder="Postcode" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                              <div class="clearfix">
                                   <div class="form-label">Country</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Country" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                  <br />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="DROP_Country" ErrorMessage="Please select country" 
                                        ForeColor="Red">Please select country</asp:RequiredFieldValidator>

                          </div> </div>

                                    <div style="display:none" class="clearfix">
                                  <div class="form-label">Gender</div>
                              
                                   <div class="form-input"  >

                                
                          <asp:RadioButtonList ID="RADIO_Gender"  class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server"> 
                <asp:ListItem Text="&nbsp;Male" Value="0"></asp:ListItem>
                <asp:ListItem Text="&nbsp;Female" Value="1"></asp:ListItem>
               </asp:RadioButtonList>

                          </div> 




                            </div>

                 <div class="clearfix">

                                  <div class="form-label">Email Address</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Client_Email" name="email"  placeholder="Email Address" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                            <div class="clearfix">

                                  <div class="form-label">Main Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone1" name="phone1"  placeholder="Main Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                         <div class="clearfix">

                                  <div class="form-label">Secondary Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone2" name="phone2"  placeholder="Secondary Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>


                                <div class="clearfix">

                                <div class="form-label">Additional Information</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>


                                <div class="clearfix">

                                 <div class="form-label">Newsletter?</div>
                            <div class="form-input">
                                <asp:CheckBox ID="CHK_Newsletter" style="margin-top:2%;margin-left:2%;" runat="server" />
                         
                               </div></div>



                              <div class="clearfix">
                                   <div class="form-label">Marketing Source</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Marketing_Source" style="margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="DROP_Marketing_Source" ErrorMessage="Please select marketing source" 
                                        ForeColor="Red">Please select marketing source</asp:RequiredFieldValidator>                                  
                          </div></div>


                                   



                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_New_Client" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Client" />
                              

                            </div>

                </asp:Panel> 
                      
                       
                        </div>   	
		    
       </div></div>

</asp:Content>
