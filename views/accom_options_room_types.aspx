<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_options_room_types.aspx.vb" Inherits="accom_options_room_types"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="theme_dropdown" class="  theme_dropdown">      
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
                                  <li><a href="accom_options_dog.aspx" title="Add & Edit Dog Information"><span>Add & Edit Dog Information</span></a></li>

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


         

    <h1 class="page-title">Add & Edit Room Types (e.g. Single)</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        


   

                     
     <div class="form has-validation">

                     
            

              <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Room Types (e.g. Single)</th>
						
					</tr>
				</thead>
            </table>
           </div>   

                    

                    <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Room_Type">
                            <div class="clearfix">
                          
                                <div class="form-label">Room Type Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_accom_room_type" name="accom_room_type" required="required" placeholder="Room Type Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                        <div class="clearfix">
                          
                                <div class="form-label">Maximum Occupancy</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Max_Occupancy" name="max_occupancy" required="required" placeholder="Max. Occupancy" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>




                         


                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Room_Type" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Room Type" />
                              

                            </div>
                    </asp:Panel>
                       
                        
                        <div class="form has-validation">
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Room Types</th>
						
					</tr>
				</thead>
            </table>
           </div> 
          </div>

                      	
         
   <div style="overflow-x:auto;">
          <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal" 
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id,name" 
                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
                OnRowDataBound="GridView1_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Name" runat="server" Text='<%# Eval("name")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Name" runat="server" Text='<%# Eval("name")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Max Occupancy">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_MaxOccupancy" runat="server" Text='<%# Eval("max_occupancy")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_MaxOccupancy" runat="server" Text='<%# Eval("max_occupancy")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                 </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" Height="50px"/>
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView></div>
                        

		    
       </div></div></div>
       


</asp:Content>
