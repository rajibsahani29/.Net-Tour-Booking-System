<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_additional_extras.aspx.vb" Inherits="bookings_additional_extras"  ValidateRequest="false"%>
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

       

 <section class="grid_12">
     <div class="form has-validation">

            <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Extra_to_Booking">

                         <div class="clearfix">
                             <div class="form-label">Small Description</div>
                      
                                  <div class="form-input">
                      <asp:TextBox ID="TB_Extras_Description" name="extras_description" placeholder="Small Description" runat="server"></asp:TextBox>   

                     </div> </div>

                      <div class="clearfix">
                             <div class="form-label">Cost to Easyways</div>
                      
                                  <div class="form-input">
                      <asp:TextBox ID="TB_EW_Cost" name="ew_cost" placeholder="Cost to Easyways" runat="server"></asp:TextBox>   

                     </div> </div>


                       <div class="clearfix">
                             <div class="form-label">Cost to Client</div>
                      
                                  <div class="form-input">
                      <asp:TextBox ID="TB_Client_Cost" name="client_cost" placeholder="Cost to Client" runat="server"></asp:TextBox>   

                     </div> </div>



          <div class="clearfix">
                          
                                <div class="form-label">Do Not Show in Invoice</div>
                               
                               
                                <div class="form-input">
                     <asp:CheckBox ID="CHK_Show_in_Invoice"  style="margin-left:2%;" runat="server" />
                    </div>

                            </div>
                    
                      <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Extra_to_Booking" UseSubmitBehavior="true" runat="server" Text="Add Extra to Booking" /> 

                    </div>

                </asp:Panel>

           <asp:GridView ID="GRID_Bookings_Additional_Extras" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal"  
              AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
              OnPageIndexChanging="GRID_Bookings_Additional_Extras_PageIndexChanging" OnRowCancelingEdit="GRID_Bookings_Additional_Extras_RowCancelingEdit" 
              OnRowEditing="GRID_Bookings_Additional_Extras_RowEditing" OnRowUpdating="GRID_Bookings_Additional_Extras_RowUpdating" OnRowDeleting="GRID_Bookings_Additional_Extras_RowDeleting" 
              OnRowDataBound="GRID_Bookings_Additional_Extras_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                <Columns>
                    <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_Description" runat="server" Text='<%# Eval("descx")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_Description" runat="server" Text='<%# Eval("descx")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost to Easyways">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_CostEw" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_CostEw" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost to Client">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="TB_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice">
                        <ItemTemplate>
                        <asp:Label ID="LABEL_Invoice" runat="server" Text='<%# SetValue(Eval("invoicex"))%>'/>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:CheckBox ID="CHK_Invoice" runat="server" />
                        </EditItemTemplate>--%>
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

  </section>      
</div>




</asp:Content>
