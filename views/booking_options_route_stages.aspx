<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="booking_options_route_stages.aspx.vb" Inherits="booking_options_route_stages"  ValidateRequest="false"%>
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


    <h1 class="page-title">Add & Edit New Stage within Route</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        


   

                     
     	

                    
 <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add New Stage within Route</th>
						
					</tr>
				</thead>
            </table>
           </div> 
          
                    <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_New_Route_Stage">

                            <div class="clearfix">
                          
                                <div class="form-label">Route</div>
                               
                               <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
         
                                        
                                </div>

                            </div>


                 <div class="clearfix">
                          
                                <div class="form-label">Stage</div>
                               
                                         <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Stage" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
         
                                        
                                </div>

                            </div>

                 <div class="clearfix">
                          
                                <div class="form-label">Sequence in Route</div>
                               
                                   <div class="form-input">
                                    <asp:TextBox ID="TB_Bookings_Sequence__In_Route" name="booking_sequence_in_route" required="required" placeholder="Enter Sequence in Route" runat="server"></asp:TextBox>  
                            
         
                                        
                                </div>

                            </div>
                         
                         


                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_New_Route_Stage" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Stage within Route" />
                              

                            </div>

                    </asp:Panel>
                        </div> 

       
                        
                         <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit New Stage within Route</th>
						
					</tr>
				</thead>
            </table>
           </div> 
          </div>

          <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" PageSize="10000" AutoGenerateColumns="false" DataKeyNames="id,routename,stagename" 
                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
                OnRowDataBound="GridView1_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Route">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_GridRoute" runat="server" Text='<%# Eval("routename")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnRouteId" runat="server" Value='<%# Eval("route_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_GridRoute" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stage">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_GridStage" runat="server" Text='<%# Eval("stagename")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnStageId" runat="server" Value='<%# Eval("stage_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_GridStage" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sequence in Route">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_RouteSequence" runat="server" Text='<%# Eval("route_sequence")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_RouteSequence" runat="server" Text='<%# Eval("route_sequence")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                 </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Medium" Height="50px"/>
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        

		    
     </div></div>

</asp:Content>
