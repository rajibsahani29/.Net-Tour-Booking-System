<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="extras_new_type.aspx.vb" Inherits="extras_new_type"  ValidateRequest="false"%>
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
    

 


    <h1 class="page-title">Add New Extra Type Service</h1>

  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    

   

                     
     	<div class="form has-validation">

                     
            
   <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add New Extra Type Service</th>
						
					</tr>
				</thead>
            </table>
           </div> 
              

              <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Extra_Type_Service">
                    
                            <div class="clearfix">
                          
                                <div class="form-label">Type of Service (e.g. Taxi)</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Service_Type" name="name" required="required" placeholder="Type of Service" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                       



                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Extra_Type_Service" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Extra Type of Service" />
                              

                            </div>

            </asp:Panel>
                        </div>   	
                          <div class="form-action clearfix">
                      <div class="form-label" style="text-transform:capitalize; font-weight:bold;">Do not Delete or Edit Taxi Service or Baggage Handling</div>
                              </div>
           

		    
       </div>
       <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Extra Type Service</th>
						
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
                    <asp:TemplateField HeaderText="Extra Type Service">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_Name" runat="server" Text='<%# Eval("name")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_Name" runat="server" Text='<%# Eval("name")%>'/>
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
       </div>

      

       

</asp:Content>
