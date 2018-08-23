<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_enquiry.aspx.vb" Inherits="bookings_enquiry"  ValidateRequest="false"%>
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
    

 

    <h1 class="page-title">New Enquiry</h1>
    <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                    
 

              <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">New Enquiry</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   
            <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Create_Booking">

               

                           
                            <div class="clearfix">
                          
                                <div class="form-label">Client Name</div>
                               
                               
                                <div class="form-input">
                          
                                    <br/> <asp:Label ID="LABEL_Client_Name" Style="font-size: 18px;
            color: rgb(60,60,60);font-weight: normal;"  runat="server" Text="&nbsp;&nbsp;No Client Selected"></asp:Label>
                                    <asp:HiddenField ID="hdnClientName" runat="server" Value="" />
                                </div>

                            </div>

                     <div class="clearfix">
             <div class="form-label"></div>

                        
                <div class="form-action clearfix" id="link_client_button">
                                <asp:Button ID="BUT_Add_Link_Client"   class="fr"  runat="server" Text="Link Client" />
                              

                            </div>
                      <div class="form-action clearfix" id="remove_client_button">
                                <asp:Button ID="BUT_Remove_Client"   class="fr"  runat="server" Text="Remove Client" />

                            </div></div>

                        <div class="clearfix">
                                   <div class="form-label">Route</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>

                  <div class="clearfix">
                                   <div class="form-label">Agent</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Agent"   style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>     
                     
                            <div class="clearfix">
                          
                                <div class="form-label">Number of Males</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Number_of_Males" name="no_of_males"   placeholder="Number of Males" runat="server">0</asp:TextBox>   
                      
                                </div>

                            </div>

                 <div class="clearfix">
                          
                                <div class="form-label">Number of Females</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Number_of_Females" name="no_of_females"   placeholder="Number of Females" runat="server">0</asp:TextBox>   
                      
                                </div>

                            </div>

                 <div class="clearfix">
                          
                                <div class="form-label">Number of Unspecified</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Number_of_Unspecified" name="no_of_unspecified"   placeholder="Number of Unspecified" runat="server">0</asp:TextBox>   
                      
                                </div>

                            </div>
     <div class="clearfix">
                          
                                <div class="form-label">Price Band:</div>
                               
                                <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accom_Band"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                      <asp:ListItem Text="Select Band" Value="0"></asp:ListItem>
                                <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                <asp:ListItem Text="B" Value="B"></asp:ListItem>
                                <asp:ListItem Text="C" Value="C"></asp:ListItem>
                                  </asp:DropDownList>

                          </div>

                            </div>
                 <div class="clearfix">
                          
                                <div class="form-label">Room Preference Comments:</div>
                               
                               
                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Room_Preference_Info" TextMode="MultiLine" name="room_pref_info" rows="5" placeholder="Room Preference Comments" runat="server"></asp:TextBox>   

                         

                            </div>

                            </div>

                 <div class="clearfix">
                          
                                <div class="form-label">En-suite Preference:</div>
                               
                              <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Ensuite"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                      <asp:ListItem Text="Select Preference" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Essential" Value="Essential"></asp:ListItem>
                                <asp:ListItem Text="Preferred" Value="Preferred"></asp:ListItem>
                                <asp:ListItem Text="Not Essential" Value="Not Essential"></asp:ListItem>
                                  </asp:DropDownList>

                          </div>

                            </div>

                        <div class="clearfix">
                          
                                <div class="form-label">Dog Friendly</div>
                               
                               
                                <div class="form-input">
                              
                                    <asp:CheckBox ID="CHK_Dog_Friendly" style="margin-left:2%;" runat="server"  />
                                        
                                </div>

                            </div>


                        <div class="clearfix">
                          
                                <div class="form-label">Customised Tour?</div>
                               
                               
                                <div class="form-input">
                              
                                    <asp:CheckBox ID="CHK_Customised_Tour" style="margin-left:2%;" runat="server"  />
                                        
                                </div>

                            </div>
         
                  
                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Create_Booking" UseSubmitBehavior="true" class="fr"  runat="server" Text="Create Booking" />
                              

                            </div>

                                      

            </asp:Panel>
                            
                            </div>


                        
              
		    
       </div></div>

<script type="text/javascript">
    $("#<%= BUT_Create_Booking.ClientID %>").click(function () {
        //alert("HEllo");

        if ($("#<%= hdnClientName.ClientID %>").val() == "") {
            alert("Please select client");
            return false;
        }

        if ($("#<%= DROP_Route.ClientID %>").val() == "0") {
            alert("Please select route");
            $("#<%= DROP_Route.ClientID %>").focus();
            return false;
        }

        if ($("#<%= TB_Number_of_Males.ClientID %>").val() == "") {
            alert("Please add number of males");
            $("#<%= TB_Number_of_Males.ClientID %>").focus();
            return false;
        }

        if ($("#<%= TB_Number_of_Females.ClientID %>").val() == "") {
            alert("Please add number of females");
            $("#<%= TB_Number_of_Females.ClientID %>").focus();
            return false;
        }

        if ($("#<%= TB_Number_of_Unspecified.ClientID %>").val() == "") {
            alert("Please add number of unspecified");
            $("#<%= TB_Number_of_Unspecified.ClientID %>").focus();
            return false;
        }

        /*if ($("# DROP_Ensuite.ClientID ").val() == "0") {
            alert("Please select en-suite preference");
            $("# DROP_Ensuite.ClientID ").focus();
            return false;
        }*/

    });
</script>

</asp:Content>
