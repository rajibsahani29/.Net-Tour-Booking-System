<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_additional_info.aspx.vb" Inherits="bookings_additional_info"  ValidateRequest="false"%>
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
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Accommodation Diary</a> 
                               </li>    

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Diary General Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="general_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary General Event</a> 
                               </li>   
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div> 

   <h1 class="page-title" style="text-align:center;">Booking Additional Extras</h1>


    <div class="form-input fl">
    <asp:Button ID="BUT_Back_to_Booking" Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" runat="server" Text="&nbsp;Back to Booking" /> </div>


    <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">

                         
            <table id="booking_tables" border="1">
              
                <tr><th colspan="4" style="height:30px;">Booking Information</th></tr>
                   <tr><td>&nbsp;Booking ID:</td>
                    <td><asp:Label ID="LABEL_Booking_ID" runat="server" Text="&nbsp;Booking ID&nbsp;"></asp:Label></td>
                       <td>&nbsp;Tour:</td>
                    <td><asp:Label ID="LABEL_Tour_and_Stage" runat="server" Text="&nbsp;Tour & Stage #"></asp:Label></td>
                    
                </tr>

                 <tr>
                     <td>&nbsp;Client Name:</td>
                    <td><asp:Label ID="LABEL_Client_Name" runat="server" Text="&nbsp;Client Name"></asp:Label></td>
                       <td>&nbsp;Stage #:</td>
                    <td><asp:Label ID="LABEL_Stage" runat="server" Text="&nbsp;Stage #"></asp:Label></td>
               
                </tr>
                  <tr>
                 <td>&nbsp;Total Number in Party:</td>
                    <td><asp:Label ID="LABEL_Total_Number_in_Party" runat="server" Text="&nbsp;Total Number in Party"></asp:Label></td>
                      <td>&nbsp;Total Amount Payable:</td>
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td>
               
</tr>

                   <tr>
                <td>&nbsp;Customised?</td>
                    <td><asp:CheckBox ID="CHK_Customised"  enabled="false" style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>
          
</div>
   </section>  

       <asp:HiddenField ID="hdnAccordianStatus" runat="server" Value="" />

 <section class="grid_12">
     <div class="form has-validation">

<ul class="accordion">
			
			<li id="one" class="files">


				<a href="#one" >Additional Info</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">

                <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Update_Additional_Info">

                         <div class="clearfix">
                             <div class="form-label">Dietary Need for Person Booking</div>
                      
                                  <div class="form-input">
                            <asp:TextBox ID="TB_Dietary_Needs_Main_Person" name="dietary_needs_main" placeholder="Enter Dietary Needs Here" runat="server"></asp:TextBox> 

                     </div> </div>
                                    
                                      <div class="clearfix">
                             <div class="form-label">Voluntary Contribution</div>
                        
                     <div class="form-input">
                      <asp:TextBox ID="TB_Voluntary_Contribution" name="voluntary_contribution" placeholder="Voluntary Contribution Amount" runat="server"></asp:TextBox>   


                     </div></div>

                      <div class="clearfix">
                             <div class="form-label">Agent Reference</div>
                        
                     <div class="form-input">
                      <asp:TextBox ID="TB_Agent_Ref" name="agent_ref" placeholder="Agent Reference" runat="server"></asp:TextBox>   


                     </div></div>


                    
                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Update_Additional_Info" UseSubmitBehavior="true" runat="server" Text="Update Information" />
                          


                            </div>

                </asp:Panel>
                          </div> 
                       
</ul>
			</li>

			
			<li id="two" class="mail">


				<a href="#two">Additional People</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">

                <asp:Panel ID="pnlForm1" runat="server" DefaultButton="BUT_Add_Additional_Person">

                         <div class="clearfix">
                             <div class="form-label">Name</div>
                      
                                  <div class="form-input">
                      <asp:TextBox ID="TB_Additional_Name" name="additional_name" placeholder="Additional Name" runat="server"></asp:TextBox>   

                     </div> </div>
                                      <div class="clearfix">
                             <div class="form-label">Gender</div>
                      
                                  <div class="form-input">
                         <asp:DropDownList ID="DROP_Gender" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server"></asp:DropDownList>

                     </div> </div>
                    
                          
                        <div class="clearfix">
                             <div class="form-label">Dietary Needs</div>
                      
                                  <div class="form-input">
                         
                            <asp:TextBox ID="TB_Dietary_Needs_Extra" name="dietary_needs_extra" placeholder="Enter Dietary Needs Here" runat="server"></asp:TextBox> 
</div>
                     </div> 
                    
                    
                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Additional_Person" UseSubmitBehavior="true" runat="server" Text="Add Additional Person" /> 

                    </div>
                </asp:Panel>
          
          
          <asp:GridView ID="GRID_Bookings_Additional_People" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal"  
              AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id,gendername" 
              OnPageIndexChanging="GRID_Bookings_Additional_People_PageIndexChanging" OnRowCancelingEdit="GRID_Bookings_Additional_People_RowCancelingEdit" 
              OnRowEditing="GRID_Bookings_Additional_People_RowEditing" OnRowUpdating="GRID_Bookings_Additional_People_RowUpdating" OnRowDeleting="GRID_Bookings_Additional_People_RowDeleting" 
              OnRowDataBound="GRID_Bookings_Additional_People_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                <Columns>
                    <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_Name" runat="server" Text='<%# Eval("name")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_Name" runat="server" Text='<%# Eval("name")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_Gender" runat="server" Text='<%# Eval("gendername")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnGenderId" runat="server" Value='<%# Eval("sex_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_GridGender" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dietary Needs">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_DietaryNeeds" runat="server" Text='<%# Eval("dietaryneeds")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_DietaryNeeds" runat="server" Text='<%# Eval("dietaryneeds")%>'/>
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

                       
</ul>
			</li>
    </ul>

         </div></section>

			 
</div>


<script type="text/javascript">
    $(document).ready(function () {
        var AccordianStatus = $("#<%= hdnAccordianStatus.ClientID %>").val();
        if (AccordianStatus != "") {
            //alert(AccordianStatus);
            parent.location.hash = AccordianStatus;
        }
    });
</script>

</asp:Content>
