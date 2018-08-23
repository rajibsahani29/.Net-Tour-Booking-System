<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_add_rooms.aspx.vb" Inherits="accom_add_rooms"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="accom_new.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add New Accommodation">Add New Accommodation</a> 
                               </li> 

   <li class="no_colour">
                                    <a  href="accom_view_all.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View Accommodation">View Accommodation</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Edit Accommodation">Edit Accommodation</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_photos.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add & Delete Accommodation Imagery">Add & Delete Accommodation Imagery</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_docs.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add & Delete Accommodation Docs">Add & Delete Accommodation Docs</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_add_rooms.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add a New Room Type for an Acccommodation">Add New Room Type for an Accom.</a> 
                               </li>  
               <li class="no_colour">
                                    <a  href="accom_room_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="View Room Types for an Accommodation">View Room Types for an Accom.</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_link.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Assign Accommodation to a Route and Stage">Assign Accommodation to Route and Stage</a> 
                               </li>                
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 

    <h1 class="page-title">Add a New Room Type for an Accommodation</h1>
    <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                    
 

              <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add a New Room Type for an Accommodation</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   
           
           <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_New_Room">

                   <div class="clearfix">
                                   <div class="form-label">Select Accommodation</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accommodation" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>

                  <div class="clearfix">
                                   <div class="form-label">Add a Room Type</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Room_Type" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True" Enabled="False">
                                  </asp:DropDownList>

                          </div> </div>

                           
                            <div class="clearfix">
                          
                                <div class="form-label">Cost to Easyways</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_EW_Cost" name="ew_cost" required="required" placeholder="Cost to Easyways" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                    <div class="clearfix">
                          
                                <div class="form-label">Cost to Client</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Client_Cost" name="client_cost" required="required" placeholder="Cost to Client" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>


                          <div class="clearfix">

                                <div class="form-label">Select Room Facilities</div>

                               <div class="form-input">


                                    <asp:CheckBoxList ID="CHKLIST_Room_Facilities" name="room_facilities"  required="required" runat="server"></asp:CheckBoxList>
         
                                        
                                </div></div>

                   <div class="clearfix">

                                <div class="form-label">Select Room Options</div>

                               <div class="form-input">


                                    <asp:CheckBoxList ID="CHKLIST_Room_Options" name="room_options"  required="required" runat="server"></asp:CheckBoxList>
         
                                        
                                </div></div>


                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_New_Room" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Room" />
                              

                            </div>

          </asp:Panel>  
                      
                        </div>  

                        
              
		    
       </div></div>


</asp:Content>
