<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="booking_options_routes.aspx.vb" Inherits="booking_options_routes"  ValidateRequest="false"%>
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


    <h1 class="page-title">Add & Edit Routes</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        


   

                     
     	<div class="form has-validation">

                    

                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Routes</th>
						
					</tr>
				</thead>
            </table>
           </div> 
      
                    <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_New_Route">
                            <div class="clearfix">
                          
                                <div class="form-label">Route Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Route_Name" name="booking_route_name" required="required" placeholder="Enter Route Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>
                 <div class="clearfix">
                          
                                <div class="form-label">Route Code</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Route_Code" name="booking_route_code" required="required" placeholder="Enter Route Code" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>  

                 <div class="clearfix" style="display:none;">
                          
                                <div class="form-label">Cost To You</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Cost_Ew" name="booking_cost_ew" placeholder="0.00" runat="server" value="0"></asp:TextBox>  
                  
                                </div>

                            </div>

                              <div class="clearfix">
                          
                                <div class="form-label">Cost To Client</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Cost_Client" name="booking_cost_client" required="required" placeholder="Enter Cost To Client" runat="server">0.00</asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>



                           <div class="clearfix">
                          
                                <div class="form-label">Single Supplement Charge</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Single_Supplement" name="booking_single_supplement"  required="required"  placeholder="Enter Single Supplement Charge" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>
                         
                               <div class="clearfix">
                          
                                <div class="form-label">Google Doc Link for Information Leaflet</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Bookings_Link_Info_Leaflet" name="booking_link_info_leaflet"  placeholder="Enter Google Doc Link for Information Leaflet" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>

                              <div class="clearfix">
                          
                                <div class="form-label" style="line-height:20px;padding-top:10px;">Website Link to Walk Highlands Page</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Link_Highlands_Page" name="link_highlands_page"  placeholder="Enter Link Here" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>

                              <div class="clearfix">
                          
                                <div class="form-label" style="line-height:20px;padding-top:10px;">Official Walk Page</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Official_Walk_Page" name="official_walk_page"  placeholder="Enter Link Here" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>

                          <div class="clearfix">
                          
                                <div class="form-label">Map Link (from BlueSword) for URL</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Map_Link" name="map_link"  placeholder="Enter Map Link Here" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>

                         <div class="clearfix">
                          
                                <div class="form-label" style="line-height:20px;padding-top:10px;">Cost to Easyways for Guidebook <br />for Fixed Tours</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_EW_Cost_Guidebooks" name="guidebook_cost"  placeholder="Enter Cost Here" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>
                                             
                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_New_Route" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Route" />
                              

                            </div>

                        </asp:Panel>

                    

                     
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Routes</th>
						
					</tr>
				</thead>
            </table>
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
                    <%--<asp:TemplateField HeaderText="Cost To You">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_CostEw" runat="server" Text=''/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_CostEw" runat="server" Text=''/>
                        </EditItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Route Code">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_RouteCode" runat="server" Text='<%# Eval("codex")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_RouteCode" runat="server" Text='<%# Eval("codex")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost To Client">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Single Supplement Charge">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_SingleSupplement" runat="server" Text='<%# Eval("single_supplement")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_SingleSupplement" runat="server" Text='<%# Eval("single_supplement")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Google Doc Link">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_DocLink" runat="server" Text='<%# Eval("doc_loc")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_DocLink" runat="server" Text='<%# Eval("doc_loc")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Link to Walk Highlands Page">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_ExternalLink1" runat="server" Text='<%# Eval("external_link1")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_ExternalLink1" runat="server" Text='<%# Eval("external_link1")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Official Walk Page">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_ExternalLink2" runat="server" Text='<%# Eval("external_link2")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_ExternalLink2" runat="server" Text='<%# Eval("external_link2")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Map Link">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_MapLink" runat="server" Text='<%# Eval("map_link")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_MapLink" runat="server" Text='<%# Eval("map_link")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost to Easyways for Guidebook">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_CostGuideBook" runat="server" Text='<%# Eval("cost_guidebook")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_CostGuideBook" runat="server" Text='<%# Eval("cost_guidebook")%>'/>
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
		        </div>
       </div></div>

</asp:Content>
