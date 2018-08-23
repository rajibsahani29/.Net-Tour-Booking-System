<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_view_client.aspx.vb" Inherits="bookings_view_client"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

 <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="bookings_enquiry.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add New Enquiry">Add New Enquiry</a> 
                               </li> 

                                

    <li class="no_colour">
                                    <a  href="bookings_search.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Booking</a> 
                               </li> 

                                  

  <li class="no_colour"><a href="reports_status_all.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Booking Status Report</a></li> 

       <li class="no_colour">
                                    <a  href="bookings_new_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add a New Client</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="bookings_edit_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View & Edit Client</a> 
                               </li> 

    
                 
          <li class="no_colour">
                                    <a  href="accom_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add/Edit Accom Diary Event</a> 
                               </li> 

                                      
                                  

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add/Edit General Diary Event</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary</a> 
                               </li>    
                                                                 <li class="no_colour">
                                    <a  href="reports_live_walkers.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Walkers Diary</a> 
                               </li>    
                                
                                 
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>   
    
    <h1 class="page-title" style="text-align:center;">Search for Client</h1>
  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    
    <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Search for Client</th>
						
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



                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Search_Name" UseSubmitBehavior="true" runat="server" Text="Search System" />
                              

                            </div>

               </asp:Panel>
               
                        </div> 
                      

       
 <div class="check_client_system"   >               
 

         <asp:GridView ID="GridView1"  Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
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

