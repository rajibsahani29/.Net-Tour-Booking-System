<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="booking_options_stages.aspx.vb" Inherits="booking_options_stages"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
  <div id="theme_dropdown" class=" theme_dropdown">      
                      <ul class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="booking_options_fee.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Booking Fees">Edit Booking Fees</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="booking_options_payment.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Payment Methods">Add & Edit Payment Methods</a> 
                               </li> 

                                 
                         
       <li class="no_colour">
                                    <a  href="booking_options_marketing.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Marketing Source">Add & Edit Marketing Source</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="booking_options_stages.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Stages">Add & Edit Stages</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="booking_options_routes.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Routes">Add & Edit Routes</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="booking_options_route_stages.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Route-Stages">Add & Edit Route-Stages</a> 
                               </li> 
                                  <li class="no_colour">
                                    <a  href="booking_options_distance_stages.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add & Edit Distances between Stages">Add & Edit Distances</a> 
                               </li> 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    


    <h1 class="page-title">Add & Edit Stages</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        


   

                     
     	<div class="form has-validation">

                    

          <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Stages</th>
						
					</tr>
				</thead>
            </table>
           </div>             
                    <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_New_Stage">
                            <div class="clearfix">
                          
                                <div class="form-label">Stage Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Stage_Name" name="booking_stage_name" required="required" placeholder="Enter Stage Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>


                  <div class="clearfix" >
                          
                                <div class="form-label">Longitude</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Longitude" name="booking_longitude" placeholder="Enter Longitude" runat="server" Text="0"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

        <div class="clearfix" >
                          
                                <div class="form-label">Latitude</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Latitude" name="booking_latitude" placeholder="Enter Latitude" runat="server" Text="0"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                         <div class="clearfix">

                                <div class="form-label">More Info for Itinerary</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_More_Info" TextMode="MultiLine" name="more_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                         


                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_New_Stage" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Stage" />
                              

                            </div>
                    </asp:Panel>
                        </div>   
                        
                   


          <div class="form has-validation">
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Stages</th>
						
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
                    <asp:TemplateField HeaderText="Longitude">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Longitude" runat="server" Text='<%# Eval("longitude")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Longitude" runat="server" Text='<%# Eval("longitude")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Latitude">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Latitude" runat="server" Text='<%# Eval("latitude")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Latitude" runat="server" Text='<%# Eval("latitude")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="More Info">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_MoreInfo" runat="server" Text='<%# Eval("more_info")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_MoreInfo" runat="server" TextMode="MultiLine" Text='<%# Eval("more_info")%>'/>
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
                        </asp:GridView>
                        </div>

		    
       </div></div>

</asp:Content>
