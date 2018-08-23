<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="booking_options_payment.aspx.vb" Inherits="booking_options_payment"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <div id="theme_dropdown" class="  theme_dropdown">      
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


    <h1 class="page-title">Add & Edit Payment Methods for Clients</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        


   

                     
 <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Payment Methods</th>
						
					</tr>
				</thead>
            </table>
           </div> 
                    <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Payment_Method">
                            <div class="clearfix">
                          
                                <div class="form-label">Payment Method Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Booking_Payment_Method" name="booking_payment_method" required="required" placeholder="Enter Payment Method Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                              <div class="clearfix">
                          
                                <div class="form-label">Charge (%)</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Charge" name="booking_payment_method_charge"  placeholder="Enter Charge (%)" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Payment_Method" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Payment Method" />
                              

                            </div>
                    </asp:Panel>

                        </div>   	


                         
                         <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Payment Methods</th>
						
					</tr>
				</thead>
            </table>
           </div> 
          </div>

          <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id,name" 
                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
                OnRowDataBound="GridView1_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
             <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
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
                    <asp:TemplateField HeaderText="Charge (%)">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_Commision" runat="server" Text='<%# Eval("commision")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_Commision" runat="server" Text='<%# Eval("commision")%>'/>
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
