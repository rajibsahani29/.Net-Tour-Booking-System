<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_search.aspx.vb" Inherits="bookings_search"  ValidateRequest="false"%>
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
    

        
   <h1 class="page-title" style="text-align:center;">Search For a Booking</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">

                <asp:Panel ID="pnlSearchName" runat="server" DefaultButton="BUT__Search_Date">
    
                      <div class="clearfix">
                                  <asp:Label ID="Label_Search_Name" runat="server" class="form-label" Text="Search By First Name"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Name" class="form-input" name="name" placeholder="Search By First Name" runat="server"></asp:TextBox>

                                       <div class="form-action clearfix " style="float:right;display:none;">
                                <asp:Button ID="BUT_Search_Name" UseSubmitBehavior="true" runat="server" Text="Search" />
                          


                            </div>

                          </div> </div>
            
                   
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Search_Surname" runat="server" class="form-label" Text="Search By Surname"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Surname" class="form-input" name="name" placeholder="Search By Surname" runat="server"></asp:TextBox>

                  

                          </div> </div>
             

            
                              <div class="clearfix">
                                  <asp:Label ID="Label_Search_Booking" runat="server" class="form-label" Text="AND / OR Search By Booking Reference"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Booking" class="form-input" name="name" placeholder="Search By Booking Reference" runat="server"></asp:TextBox>

                                       <div class="form-action clearfix " style="float:right;display:none;">
                                <asp:Button ID="BUT__Search_Booking" UseSubmitBehavior="true" runat="server" Text="Search" />
                          
                            </div>

                          </div> </div>
                         
            
                      <div class="clearfix">
                                  <asp:Label ID="LABEL_Postcode" runat="server" class="form-label" Text="Search By Postcode"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Postcode" class="form-input" name="name" placeholder="Search By Postcode" runat="server"></asp:TextBox>

                  

                          </div> </div>
             

                      <div class="clearfix">
                                  <asp:Label ID="LABEL_Search_Email" runat="server" class="form-label" Text="Search By Email Address"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Email" class="form-input" name="name" placeholder="Search By Email Address" runat="server"></asp:TextBox>

                  

                          </div> </div>
             

                              <div class="clearfix">
                                  <asp:Label ID="Label_Search_Date" runat="server" class="form-label" Text="AND / OR Search By Date - dd/mm/yyyy"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Date" class="date" type="date" name="date" placeholder="Search By Booking Reference" runat="server"></asp:TextBox>

                                </div>

                            </div>
                          
                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Search_Date" UseSubmitBehavior="true" runat="server" Text="Search" />
                          
</div></div>
              
                       
                </asp:Panel>


				</div>

                <%--AutoGenerateSelectButton="true"--%>
                <div style="overflow-x:auto;">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
        <asp:GridView ID="GridView1"  Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal"  
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True"
                OnSelectedIndexChanging="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:TemplateField HeaderText="Booking Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_DateCreated" runat="server" Text='<%# SetDateVal(Eval("datecreated")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="datecreated" HeaderText="Booking Date" ReadOnly="true" />--%>
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                    <asp:BoundField DataField="unique_id" HeaderText="Booking Ref." ReadOnly="true" />
                    <%--<asp:BoundField DataField="checkin" HeaderText="Check-In Date" ReadOnly="true" />--%>
                    <%--<asp:TemplateField HeaderText="Check-In Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_CheckInDate" runat="server" Text=''/>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:BoundField DataField="TourName" HeaderText="Tour Name" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Tour Name">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_TourName" runat="server" Text=''/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AgentName" HeaderText="Agent Name" ReadOnly="true" />
                    <asp:CommandField ShowSelectButton="true" />
              </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Medium" Height="50px"/>
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView></div>
	        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BUT_Search_Name" />
                        <asp:AsyncPostBackTrigger ControlID="BUT__Search_Booking" />
                        <asp:AsyncPostBackTrigger ControlID="BUT__Search_Date" />
                    </Triggers>
            </asp:UpdatePanel>

        </section>

 </div>        
    

</asp:Content>
