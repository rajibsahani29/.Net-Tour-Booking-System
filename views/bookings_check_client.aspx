<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_check_client.aspx.vb" Inherits="bookings_check_client"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      

    <h1 class="page-title" style="text-align:center;">Check if Client Exists</h1>
  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    
    <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Check if Client Exists</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   
                <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Search_Name">    
                    
                            <div class="clearfix">
                          
                                <div class="form-label">First Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_firstname" name="firstname" placeholder="First Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Surname</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_surname" name="surname" placeholder="Surname" runat="server"></asp:TextBox>   


                                </div></div>

                    <div class="form-label"></div><div class="form-label">
                        Do not put extra spaces after names</div>
                                <div class="form-action clearfix " style="float:right;"> 
                                <asp:Button ID="BUT_Search_Name" UseSubmitBehavior="true" runat="server" Text="Search System" />
                              

                            </div>

               </asp:Panel>
               
                        </div> 
                      

       
 <div class="check_client_system"   >               
 <div class="form has-validation">
                <div class="clearfix"> 
                     <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Check_Client_System" runat="server" Text="Client Not in System?" />
                              

                            </div>
   </div>
       
                     </div>

         <asp:GridView ID="GridView1"  Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanging="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="true">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
              <Columns>
                    <asp:BoundField DataField="name1" HeaderText="First Name" ReadOnly="true" />
                    <asp:BoundField DataField="name2" HeaderText="Surname" ReadOnly="true" />
                    <asp:BoundField DataField="phone1" HeaderText="Phone No" ReadOnly="true" />
                    <asp:BoundField DataField="city" HeaderText="City" ReadOnly="true" />
                    <asp:BoundField DataField="postcode" HeaderText="Postcode" ReadOnly="true" />
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

                       

           
		    
       </div>



      </div>
       


</asp:Content>
