<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_incomplete.aspx.vb" Inherits="bookings_incomplete"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

                                   <li class="no_colour"><a href="bookings_incomplete.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Incomplete Bookings</a></li>   

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

rel="popover" >Add Accom Diary Event</a> 
                               </li> 

                                      
                                  

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Diary General Event</a> 
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

        
   <h1 class="page-title" style="text-align:center;">View Incomplete Bookings, Search by Date Created</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">


             

                              <div class="clearfix">
                                  <asp:Label ID="Label_Date_From" runat="server" class="form-label" Text="Date Created: From"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Date_From" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>

                                </div>

                            </div>

                     <div class="clearfix">
                                  <asp:Label ID="Label_Date_To" runat="server" class="form-label" Text="Date Created: To"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Date_To" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>

                                </div>

                            </div>

                       <div class="clearfix">
                                  <asp:Label ID="Label_Accommodation" runat="server" class="form-label" Text="Accommodation"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Accom"  style="margin-top:2%;margin-left:2%;" runat="server" />

                                     

                          </div> </div>

                       <div class="clearfix">
                                  <asp:Label ID="Label_Baggage" runat="server" class="form-label" Text="Baggage"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Baggage"  style="margin-top:2%;margin-left:2%;" runat="server" />

                                     

                          </div> </div>

                       <div class="clearfix">
                                  <asp:Label ID="Label_Extras" runat="server" class="form-label" Text="Extras"></asp:Label>
                              
                                  <div class="form-input">
                                    <asp:CheckBox ID="CHK_Extras"  style="margin-top:2%;margin-left:2%;" runat="server" />

                                     

                          </div> </div>
                          
                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Search" UseSubmitBehavior="true" runat="server" Text="Search" />
                          
</div></div>
              
                       
              


				</div>

                <div style="overflow-x:auto;">
             
                    <asp:GridView ID="GRID_Bookings_Incomplete" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"  
                        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="BookingId" 
                        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True"
                        OnSelectedIndexChanging="GRID_Bookings_Incomplete_SelectedIndexChanged" OnPageIndexChanging="GRID_Bookings_Incomplete_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                        <Columns>
                            <asp:TemplateField HeaderText="Booking Date">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_DateCreated" runat="server" Text='<%# SetDateVal(Eval("DateCreated")) %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="datecreated" HeaderText="Booking Date" ReadOnly="true" />--%>
                            <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                            <asp:BoundField DataField="BookingUniqueId" HeaderText="Booking Ref." ReadOnly="true" />
                            <%--<asp:BoundField DataField="checkin" HeaderText="Check-In Date" ReadOnly="true" />--%>
                            <%--<asp:TemplateField HeaderText="Check-In Date">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_CheckInDate" runat="server" Text=''/>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="TourName" HeaderText="Tour Name" ReadOnly="true" />
                            <%--<asp:TemplateField HeaderText="Tour Name">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_TourName" runat="server" Text=''/>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:CommandField ShowSelectButton="true" />
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
	     

        </section>

 </div>        
    

</asp:Content>
