<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_options_dog.aspx.vb" Inherits="accom_options_dog"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



   <div id="theme_dropdown" class=" theme_dropdown">      
                      <ul class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="accom_options_facilities.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Accom. Facilities">Add & Edit Accom. Facilities</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_options_room_types.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Room Types">Add & Edit Room Types</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="accom_options_room_facilities.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Room Facilities">Add & Edit Room Facilities</a> 
                               </li> 
                         
       <li class="no_colour">
                                    <a  href="accom_options_room_type_options.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Room Options">Add & Edit Room Options</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="accom_options_breakfast.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Breakfast Types">Add & Edit Breakfast Types</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_options_dog.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Dog Info">Add & Edit Dog Info</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="accom_options_membership.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Memberships">Add & Edit Memberships</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="accom_options_diary_event.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Diary Event Status">Add & Edit Diary Event Status</a> 
                               </li> 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    



    <h1 class="page-title">Add & Edit Dog Information</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        


   

                    
                     
     	 <div class="form has-validation">

                     
            

              <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Dog Information</th>
						
					</tr>
				</thead>
            </table>
           </div>    

                    

                   
                            <div class="clearfix">
                          
                                <div class="form-label">Dog Information</div>
                               
                               
                                <div class="form-input">
                            <asp:TextBox ID="TB_Dog_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Dog Info Here" runat="server"></asp:TextBox>
         
                                        
                                </div>

                            </div>



                         


                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Dog_Info" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add Dog Information" />
                              

                            </div>
                 

                        </div>   	
                         <%--<div class="form has-validation">
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Dog Information</th>
						
					</tr>
				</thead>
            </table>
           </div> 
          </div>
<div style="overflow-x:auto;">
    <asp:GridView ID="GRID_Dog_Info" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
       <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" Height="50px"/>
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
                    </div>--%>

		    
       </div></div>
       


</asp:Content>
