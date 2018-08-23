<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_payments.aspx.vb" Inherits="bookings_payments"  ValidateRequest="false"%>
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

   <h1 class="page-title" style="text-align:center;">Booking Payments</h1>


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
                       <td>&nbsp;Stage #</td>
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
                    <td><asp:CheckBox ID="CHK_Customised" enabled="false" style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_RemainingTop" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>
          
</div>
   </section>  

       

 <section class="grid_12">
     <div class="form has-validation">

     <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Payment">

     <div class="clearfix">
                                 <div class="form-label">Balance Remaining</div>
                                  <div class="form-label" >
                                  
                                <asp:Label ID="LABEL_Balance_Remaining" runat="server" class="form-label" Text=""></asp:Label>
                                  
                          </div>

                     </div>


           <div class="clearfix">
                                 <div class="form-label">Amount Received</div>
                                  <div class="form-input" >
                                  
                                <asp:TextBox ID="TB_Amount_to_Pay" runat="server"></asp:TextBox>
                                  
                          </div>

                     </div>
          <div class="clearfix">
                                 <div class="form-label">Date Received</div>
                                  <div class="form-input" >
                                  
                                <asp:TextBox ID="TB_Date_Payment_Received" class="date" type="date" name="date" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                  
                          </div>

                     </div>

          <div class="clearfix">
                                 <div class="form-label">First Data Ref.</div>
                                  <div class="form-input" >
                                  
                                <asp:TextBox ID="TB_First_Data_Ref" runat="server"></asp:TextBox>
                                  
                          </div>

                     </div>

                    <div class="clearfix">
                                 <div class="form-label">Payment Method</div>
                                  <div class="form-input" >
                                  
                               <asp:DropDownList ID="DROP_Payment_Method" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>
                                  
                          </div>

                     </div>

 <div class="clearfix">
                         <div class="form-label">Payment Charge</div>

                             <div class="form-input" >
                         
                               <asp:Label ID="LABEL_Payment_Charge" runat="server" class="form-label" Text=""></asp:Label>
                             
                              

                            </div></div>

 <div class="clearfix">
                         <div class="form-label">Amount to Charge</div>

                             <div class="form-input" >
                         
                               <asp:Label ID="LABEL_Amount_to_Charge" runat="server" class="form-label" Text=""></asp:Label>
                               

                            </div></div>


                 <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Payment" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add Payment" />
                              

                            </div>
        
        </asp:Panel>

<div id="gridview">
         <asp:GridView ID="GRID_Bookings_Payments_Made" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
              AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
              OnPageIndexChanging="GRID_Bookings_Payments_Made_PageIndexChanging" OnRowDeleting="GRID_Bookings_Payments_Made_RowDeleting" 
              OnRowDataBound="GRID_Bookings_Payments_Made_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" >
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
              <Columns>
                <asp:BoundField DataField="booking_id" HeaderText="Booking Id" ReadOnly="true" />
                <asp:BoundField DataField="first_data" HeaderText="First Data Ref" ReadOnly="true" />
                <asp:TemplateField HeaderText="Date Received">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_DateReceived" runat="server" Text='<%# SetDateVal(Eval("date_received"))%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PaymentMethodName" HeaderText="Payment Method" ReadOnly="true" />
                <asp:BoundField DataField="balance_before_payment" HeaderText="Balance Before Payment" ReadOnly="true" />
                <asp:BoundField DataField="amount_wish_to_pay" HeaderText="Amount Wish To Pay" ReadOnly="true" />
                <asp:BoundField DataField="cc_charge" HeaderText="Payment Charge" ReadOnly="true" />
                <asp:BoundField DataField="amount_paid" HeaderText="Amount Paid" ReadOnly="true" />
                <asp:CommandField ShowDeleteButton="true" />
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

</section>
</div>

<script type="text/javascript">
    $("#<%= TB_Amount_to_Pay.ClientID %>").change(function () {
        var AmountWishingToPay = 0;
        var PaymentCharge = 0
        if ($("#<%= TB_Amount_to_Pay.ClientID %>").val() != "") {
            AmountWishingToPay = parseFloat($("#<%= TB_Amount_to_Pay.ClientID %>").val());
        }
        if ($("#<%= LABEL_Payment_Charge.ClientID %>").html() != "") {
            PaymentCharge = parseFloat($("#<%= LABEL_Payment_Charge.ClientID %>").html());
        }
        $("#<%= LABEL_Amount_to_Charge.ClientID %>").html((AmountWishingToPay + PaymentCharge).toFixed(2));
    });

    $("#<%= BUT_Add_Payment.ClientID %>").click(function () {
        var AmountWishingToPay = parseFloat($("#<%= TB_Amount_to_Pay.ClientID %>").val());
        var BalanceRemaining = parseFloat($("#<%= LABEL_Balance_Remaining.ClientID %>").html());

        if (AmountWishingToPay > BalanceRemaining) {
            alert("Amount exceeds balance due");
            return false;
        }
    });
</script>

</asp:Content>
