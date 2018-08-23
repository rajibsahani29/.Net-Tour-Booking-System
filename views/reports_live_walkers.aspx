<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_live_walkers.aspx.vb" Inherits="reports_live_walkers"  ValidateRequest="false"%>
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

        
   <h1 class="page-title" style="text-align:center;">Live Walkers Report</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">


              
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_From" runat="server" class="form-label" Text="Date From"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_From" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>

                                    

                          </div> </div>
               

               

                   

                                <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_To" runat="server" class="form-label" Text="Date To"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_To" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>


                                     

                          </div> </div>



                    <div class="clearfix">
                                  <asp:Label ID="LABEL_Route" runat="server" class="form-label" Text="Route"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                                  </asp:DropDownList>
                                </div>

                            </div>

                       <div class="clearfix">
                          
         <div class="form-label">Stage</div>
                               
                               
          <div class="form-input">
               <asp:DropDownList ID="DROP_Stage" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >  
               </asp:DropDownList>                    
             </div>

             </div>
                         
                        <div class="clearfix">
                          
         <div class="form-label">Accommodation</div>
                               
                               
          <div class="form-input">
               <asp:DropDownList ID="DROP_Accom" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >  
               </asp:DropDownList>                    
             </div>

             </div>             
                 

                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__View" UseSubmitBehavior="true" runat="server" Text="View" />
                          
</div></div>
        <br />
     
<div id="Show_Report">
<div style="overflow-x:auto;">
    <asp:GridView ID="GRID_Live_Walkers" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
        OnSelectedIndexChanging="GRID_Live_Walkers_SelectedIndexChanged" OnPageIndexChanging="GRID_Live_Walkers_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
        <Columns>
            <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:Label ID="LABEL_CheckInDate" runat="server" Text='<%# SetDateVal(Eval("checkin")) %>'/>                
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RouteName" HeaderText="Route" ReadOnly="true" />
            <asp:BoundField DataField="StageName" HeaderText="Stage" ReadOnly="true" />
            <asp:BoundField DataField="AccomName" HeaderText="Accom" ReadOnly="true" />
            <asp:TemplateField HeaderText="Rooms">
                <ItemTemplate>
                    <asp:Label ID="LABEL_Rooms" runat="server" Text=""/>                
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ClientName" HeaderText="Client" ReadOnly="true" />
            <asp:BoundField DataField="unique_id" HeaderText="Booking Id" ReadOnly="true" />
            <asp:BoundField DataField="AgentName" HeaderText="Agent" ReadOnly="true" />
            <asp:TemplateField HeaderText="Cancelled">
                <ItemTemplate>
                    <asp:CheckBox ID="CHK_Cancelled" runat="server" Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
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

</div>

				</div>
    </section>

 </div>        
    

</asp:Content>
