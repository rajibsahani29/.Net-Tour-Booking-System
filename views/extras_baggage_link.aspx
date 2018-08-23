<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="extras_baggage_link.aspx.vb" Inherits="extras_baggage_link"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

<div id="theme_dropdown" class=" theme_dropdown">
       
                                           <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;"> 
                                                         
                                <li class="no_colour">
                                    <a  href="extras_baggage_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Baggage Supplier/Service">Add New Baggage Supplier/Service</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="extras_baggage_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View & Edit Baggage Supplier/Service">View & Edit Baggage Supplier/Service</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="extras_baggage_link.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Baggage to a Route-Stage">Add & Edit Baggage Link to Route</a> 
                               </li> 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

    <h1 class="page-title">Add & Edit Baggage Link to a Route-Stage</h1>

  
      <div class="container_12 clearfix leading">

       <div class="grid_12">
                        



              
     	<div class="form has-validation">

          <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Baggage Link to a Route-Stage</th>
						
					</tr>
				</thead>
            </table>
           </div>   
           
                
                <div class="clearfix">
                                 <div class="form-label">Route</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>

                     </div>

                <div class="clearfix">
                                 <div class="form-label">Baggage Service</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Baggage_Service" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
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
                                <asp:Button ID="BUT_Link_Baggage_to_Route" UseSubmitBehavior="true" class="fr"  runat="server" Text="Link Baggage to Route" />
                              

                            </div>
                    </div>

        
                        </div>   	



<div class="form has-validation">
        <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Baggage Links to a Route</th>
						
					</tr>
				</thead>
            </table>
           </div>  
    </div>
           <div style="overflow-x:auto;">
            <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id,routename,extraservicename"
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
                        <asp:Label ID="LABEL_Route" runat="server" Text='<%# Eval("routename")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnRoute" runat="server" Value='<%# Eval("route_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Baggage Service">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_BaggageService" runat="server" Text='<%# Eval("extraservicename")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnBaggageService" runat="server" Value='<%# Eval("extras_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_BaggageService" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
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
