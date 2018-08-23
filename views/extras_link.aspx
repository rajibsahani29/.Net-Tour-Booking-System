<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="extras_link.aspx.vb" Inherits="extras_link"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

<div id="theme_dropdown" class=" theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                                          <li class="no_colour">
                                    <a  href="extras_new_type.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Extra Type of Service">Add New Extra Type of Service</a> 
                               </li> 
                                <li class="no_colour">
                                    <a  href="extras_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Extra Supplier/Service">Add New Extra Supplier/Service</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="extras_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View & Edit Extra Supplier/Service">View & Edit Extra Supplier/Service</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="extras_link.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit to a Route-Stage">Add & Edit Extras Link to Route-Stage</a> 
                               </li> 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

    <h1 class="page-title">Add & Edit Extras Link to a Route-Stage</h1>

  
      <div class="container_12 clearfix leading">

       <div class="grid_12">
                        



              
     	<div class="form has-validation">

          <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Extras Link to a Route-Stage</th>
						
					</tr>
				</thead>
            </table>
           </div>   
           
           <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Extra_Route_Stage">          
                <div class="clearfix">
                                 <div class="form-label">Route-Stage 1</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route_Stage1" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>

                     </div>

                <div class="clearfix">
                                 <div class="form-label">Route-Stage 2</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route_Stage2" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>

                     </div>

                <div class="clearfix">
                                 <div class="form-label">Extra Service</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Extra_Service" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>

                     </div>

                  <div class="clearfix">
                          
                                <div class="form-label">Cost To You</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Cost_Ew" name="booking_cost_ew" required="required" placeholder="Enter Cost To You" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>

                              <div class="clearfix">
                          
                                <div class="form-label">Cost To Client</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Cost_Client" name="booking_cost_client" required="required" placeholder="Enter Cost To Client" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>
                         
             

                <div class="clearfix">

                                <div class="form-label">Additional Information</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>
                           
               
             <div class="clearfix">
             <div class="form-label"></div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Extra_Route_Stage" UseSubmitBehavior="true" class="fr"  runat="server" Text="Link Extra to Route-Stage" />
                              

                            </div>
                    </div>

            </asp:Panel>
                        </div>   	



<div class="form has-validation">

   
        <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Extras Link to a Route-Stage</th>
						
					</tr>
				</thead>
            </table>
           </div>  

      <div class="clearfix">

 <div class="form-label">Filter by Route Name:</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div>

    </div>

     <div class="clearfix">

 <div class="form-label">OR Filter by Extra Service Supplier</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Supplier" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div>

    </div>
    </div>

            <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id,extraservicename" 
                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
                OnRowDataBound="GridView1_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                    <%--<asp:TemplateField HeaderText="Route-Stage 1">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_RouteStage1" runat="server" Text=' Eval("routestagename1")'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnRouteStage1" runat="server" Value=' Eval("route_stage_id1")'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_RouteStage1" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Route-Stage 2">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_RouteStage2" runat="server" Text='Eval("routestagename2")'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnRouteStage2" runat="server" Value='Eval("route_stage_id2")'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_RouteStage2" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Route">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnRouteStage1" runat="server" Value='<%# Eval("route_stage_id1")%>'></asp:HiddenField>
                            <asp:Label ID="LABEL_Route" runat="server" Text='<%# Eval("RouteName")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stage 1">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnRouteStage2" runat="server" Value='<%# Eval("route_stage_id2")%>'></asp:HiddenField>
                            <asp:Label ID="LABEL_Stage1" runat="server" Text='<%# Eval("StageName1")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stage 2">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Stage2" runat="server" Text='<%# Eval("StageName2")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Extra Service">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_ExtraService" runat="server" Text='<%# Eval("extraservicename")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnExtraService" runat="server" Value='<%# Eval("extras_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_ExtraService" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost To You">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_CostEw" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_CostEw" runat="server" Text='<%# Eval("cost_easyways")%>'/>
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
                    <asp:TemplateField HeaderText="Additional Information">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_AddInfo" runat="server" Text='<%# Eval("additional_notes")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_AddInfo" runat="server" Text='<%# Eval("additional_notes")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                 </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left"  Font-Size="Small" Height="50px"/>
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

          </div></div>


</asp:Content>
