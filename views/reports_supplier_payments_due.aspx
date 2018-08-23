<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_supplier_payments_due.aspx.vb" Inherits="reports_supplier_payments_due"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Easyway.BE" %>
<%@ Import Namespace="Easyway.DL" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <h1 class="page-title">Payments Due to Supplier</h1>

  
      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                 
                        
     	 <div class="form has-validation">

        <div class="clearfix">
                          
         <div class="form-label">Month</div>
                               
                               
          <div class="form-input">
               <asp:DropDownList ID="DROP_Month" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">  
                    <asp:ListItem Text="&nbsp;01" Value="1"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;02" Value="2"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;03" Value="3"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;04" Value="4"></asp:ListItem>
                   <asp:ListItem Text="&nbsp;05" Value="5"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;06" Value="6"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;07" Value="7"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;08" Value="8"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;09" Value="9"></asp:ListItem>
                   <asp:ListItem Text="&nbsp;10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;12" Value="12"></asp:ListItem>
               </asp:DropDownList>                    
             </div>

             </div>

        <div class="clearfix">
                          
         <div class="form-label">Year</div>
                               
                               
          <div class="form-input">
          <asp:DropDownList ID="DROP_Year" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">    
                    <asp:ListItem Text="&nbsp;2017" Value="2017"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2018" Value="2018"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2019" Value="2019"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2020" Value="2020"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2021" Value="2021"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2022" Value="2022"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2023" Value="2023"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2024" Value="2024"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;2025" Value="2025"></asp:ListItem>
          </asp:DropDownList>    
         
                                        
             </div>

             </div>

              <div class="clearfix">
                          
         <div class="form-label">Supplier Type</div>
                               
                               
          <div class="form-input">
          <asp:DropDownList ID="DROP_Supplier_Type" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">    
                    <asp:ListItem Text="&nbsp;Accommodation" Value="1"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;Baggage" Value="2"></asp:ListItem>
                    <asp:ListItem Text="&nbsp;Taxi" Value="3"></asp:ListItem>
          </asp:DropDownList>    
         
                                        
             </div>

             </div>

             <div class="clearfix">
                          
         <div class="form-label">Unpaid</div>
                               
          <div class="form-input">
                 <asp:CheckBox ID="CHK_Unpaid" runat="server" />                       
             </div>
                 
             </div>

               <div class="clearfix">
                               
                               <asp:Button ID="BUT_View"   class="fr"  runat="server" Text="View" />
                              
                            </div>
              
              <div class="clearfix">
                               
                               <%--<asp:Button ID="BUT_Print"   class="fr"  runat="server" Text="Print Summary" />--%>
                               <input type="button" id="Button1" class="fr" name="BUT_Print" value="Print Summary" onclick="window.open('reports_supplier_payments_due_print.aspx','_blank');" />
                              
                            </div>

<div class="supplier_payments">
<%
    If objFunction.CheckDataSet(dstData) Then
        
        Dim dtDataTable As DataTable
        If CHK_Unpaid.Checked = True Then
            Dim dt1 As DataTable = dstData.Tables(0)
            dt1.DefaultView.RowFilter = "paid <> 1 OR paid IS NULL"
            dtDataTable = dt1.DefaultView.ToTable()
        Else
            dtDataTable = dstData.Tables(0)
        End If
        
        Trace.Warn("Count = " + objFunction.ReturnString(dtDataTable.Rows.Count))
        Dim dtDistinctData As DataTable = dtDataTable.DefaultView.ToTable(True, "supplier_id")
        Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))
        
        If objFunction.CheckDataTable(dtDistinctData) Then
        
            Dim intIndex As Integer = 1
            
            For i = 0 To dtDistinctData.Rows.Count - 1
                Dim dtTemp As DataTable = dtDataTable
                dtTemp.DefaultView.RowFilter = "supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")) + " AND supplier_id <> 0"
                Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                
                Trace.Warn("supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")))
                If objFunction.CheckDataTable(dtData) Then
                    
                    Trace.Warn("dtData Count = " + objFunction.ReturnString(dtData.Rows.Count))
                    
                    TB_supplier_name.Text=objFunction.ReturnString(dtData.Rows(0)("SupplierName"))
                    GRID_Supplier_Payments_Due.DataSource = dtData
                    GRID_Supplier_Payments_Due.DataBind()
                    
                    Dim objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal = New clsBEPaymentToSupplierTotal
                    objBEPaymentToSupplierTotal.SupplierId = objFunction.ReturnInteger(dtData.Rows(0)("supplier_id"))
                    objBEPaymentToSupplierTotal.MonthVal = objFunction.ReturnInteger(DROP_Month.SelectedItem.Value)
                    objBEPaymentToSupplierTotal.YearVal = objFunction.ReturnInteger(DROP_Year.SelectedItem.Value)
                    objBEPaymentToSupplierTotal.SupplierType = objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value)
                    Dim dstPaymentData As DataSet = (New clsDLPaymentToSupplierTotal()).GetSupplierDetailByMonthYearSupplierIdAndSupplierType(objBEPaymentToSupplierTotal)
                    
                    Dim dblPaidAmount As Double = 0
                    If objFunction.CheckDataSet(dstPaymentData) Then
                        GRID_Supplier_Payments_Amount.DataSource = dstPaymentData
                        GRID_Supplier_Payments_Amount.DataBind()
                        dblPaidAmount = objFunction.ReturnDouble(dstPaymentData.Tables(0).Compute("SUM(total_amount)", String.Empty))
                    Else
                        GRID_Supplier_Payments_Amount.DataSource = Nothing
                        GRID_Supplier_Payments_Amount.DataBind()
                    End If
                    
                    Dim dblTotalCost As Double = 0
                    Dim strDatePaid As String = DateTime.Now.ToString("yyyy-MM-dd")
                    Dim strDatePaidStatus As String = ""
                    Dim strPaid As String = ""
                    Dim strPaidStatus As String = ""
                    Dim strButtonStatus As String = ""
                    
                    'If objFunction.ReturnString(dtData.Rows(0)("DatePaidTotal")) <> "" Then
                    '    Dim dtDate As DateTime = Convert.ToDateTime(dtData.Rows(0)("DatePaidTotal"))
                    '    strDatePaid = dtDate.ToString("yyyy-MM-dd")
                    'End If
                    
                    'If objFunction.ReturnString(dtData.Rows(0)("PaidTotal")) <> "" Then
                    '    If Convert.ToBoolean(dtData.Rows(0)("PaidTotal")) = True Then
                    '        strPaid = "checked"
                    '        strPaidStatus = "disabled"
                    '        strDatePaidStatus = "readonly"
                    '        strButtonStatus = "style='display:none;'"
                    '    End If
                    'End If
                    
                    For j = 0 To dtData.Rows.Count-1
                        Dim gRow As GridViewRow = GRID_Supplier_Payments_Due.Rows(j)
                        Dim lblTotalCostToEasyways As Label = DirectCast(gRow.FindControl("LABEL_TotalCostToEasyways"), Label)
                        
                        If objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value) = 1 Then
                            Dim lngNoOfNight As Long = 0
                            If objFunction.ReturnString(dtData.Rows(j)("checkin")) <> "" And objFunction.ReturnString(dtData.Rows(j)("checkout")) <> "" Then
                                lngNoOfNight = DateDiff(DateInterval.Day, Convert.ToDateTime(dtData.Rows(j)("checkin")), Convert.ToDateTime(dtData.Rows(j)("checkout")))
                            End If
                            Trace.Warn("lngNoOfNight = " + objFunction.ReturnString(lngNoOfNight))
                            
                            Dim objBEAccomStageRoom As clsBEAccomStageRoom = New clsBEAccomStageRoom
                            objBEAccomStageRoom.AccomStageId = objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id"))
                            Dim dstTotalCostToEasyways As DataSet = (New clsDLAccomStageRoom()).GetAccomStageRoomByAccomStageId(objBEAccomStageRoom)
                            Dim dblCost As Double = 0
                            If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
                                For k = 0 To dstTotalCostToEasyways.Tables(0).Rows.Count - 1
                                    dblCost += (objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(k)("cost_easyways")) + objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(k)("total_cost_dogs"))) * lngNoOfNight
                                Next
                            End If
                            dblTotalCost += dblCost
                            lblTotalCostToEasyways.Text = dblCost.ToString("0.00")
                            
                            Dim lblNoteToSupplier As Label = DirectCast(gRow.FindControl("LABEL_NoteToSupplier"), Label)
                            lblNoteToSupplier.Text = objFunction.ReturnString(dtData.Rows(j)("supplier_note"))
                            
                            TB_bank_account_name.Text = objFunction.ReturnString(dtData.Rows(j)("account_name"))
                            TB_supplier_payment_method.Text = objFunction.ReturnString(dtData.Rows(j)("payment_prefer"))
                            
                            'If dblCost <= 0 Then
                            '    GRID_Supplier_Payments_Due.Rows(j).Visible = False
                            'End If
                            
                            'Dim lblBankAccountName As Label = DirectCast(gRow.FindControl("LABEL_BankAccountName"), Label)
                            'lblBankAccountName.Text = objFunction.ReturnString(dtData.Rows(j)("account_name"))
                            
                            'Dim lblSupplierPaymentMethod As Label = DirectCast(gRow.FindControl("LABEL_SupplierPaymentMethod"), Label)
                            'lblSupplierPaymentMethod.Text = objFunction.ReturnString(dtData.Rows(j)("payment_prefer"))
                        ElseIf objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value) = 2 Then
                            Dim dstTotalCostToEasyways As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingById(objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id")))
                            Dim dblCost As Double = 0
                            If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
                                dblCost = objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(0)("cost_easyways"))
                            End If
                            dblTotalCost += dblCost
                            lblTotalCostToEasyways.Text = dblCost.ToString("0.00")
                            If GRID_Supplier_Payments_Due.Columns.Count > 0 Then
                                GRID_Supplier_Payments_Due.Columns(4).Visible = False
                                'GRID_Supplier_Payments_Due.Columns(5).Visible = False
                                'GRID_Supplier_Payments_Due.Columns(6).Visible = False
                                DIV_bank_account_name.Attributes.Add("style", "display:none")
                                DIV_supplier_payment_method.Attributes.Add("style", "display:none")
                                TB_bank_account_name.Text = ""
                                TB_supplier_payment_method.Text = ""
                            End If
                            'If dblCost <= 0 Then
                            '    GRID_Supplier_Payments_Due.Rows(j).Visible = False
                            'End If
                        ElseIf objFunction.ReturnInteger(DROP_Supplier_Type.SelectedItem.Value) = 3 Then
                            Dim dstTotalCostToEasyways As DataSet = (New clsDLExtrasBooking()).GetExtrasBookingById(objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id")))
                            Dim dblCost As Double = 0
                            If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
                                dblCost = objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(0)("cost_easyways"))
                            End If
                            dblTotalCost += dblCost
                            lblTotalCostToEasyways.Text = dblCost.ToString("0.00")
                            If GRID_Supplier_Payments_Due.Columns.Count > 0 Then
                                GRID_Supplier_Payments_Due.Columns(4).Visible = False
                                'GRID_Supplier_Payments_Due.Columns(5).Visible = False
                                'GRID_Supplier_Payments_Due.Columns(6).Visible = False
                                DIV_bank_account_name.Attributes.Add("style", "display:none")
                                DIV_supplier_payment_method.Attributes.Add("style", "display:none")
                                TB_bank_account_name.Text = ""
                                TB_supplier_payment_method.Text = ""
                            End If
                            'If dblCost <= 0 Then
                            '    GRID_Supplier_Payments_Due.Rows(j).Visible = False
                            'End If
                        End If
                    Next
                    Trace.Warn("dblTotalCost = " + objFunction.ReturnString(dblTotalCost))
                    'TB_Total_Amount.Text = dblTotalCost.ToString("0.00")
                    
                    If objFunction.ReturnDouble(dblTotalCost) <= dblPaidAmount Then
                        strPaid = "checked"
                        strPaidStatus = "disabled"
                        strDatePaidStatus = "readonly"
                        strButtonStatus = "style='display:none;'"
                    End If
                    
                    If objFunction.ReturnDouble(dblTotalCost) <= 0 Then
                        GRID_Supplier_Payments_Due.DataSource = New List(Of String)
                        GRID_Supplier_Payments_Due.DataBind()
                    End If
                    
%>  
<div id="DIV_show_payments">

    <div class="clearfix">
        <div class="form-label">Supplier Name</div>
        <div class="form-input">
            <input type="hidden" id="hdnSupplierId_<%= intIndex %>" value="<%= objFunction.ReturnString(dtData.Rows(0)("supplier_id")) %>" />
            <asp:TextBox ID="TB_supplier_name" name="suppliername" ReadOnly="true" placeholder="Supplier Name" runat="server"></asp:TextBox>   
        </div>
    </div>
    <div id="DIV_bank_account_name" runat="server" class="clearfix">
        <div class="form-label">Bank Account Name</div>
        <div class="form-input">
            <asp:TextBox ID="TB_bank_account_name" name="bankaccountname" ReadOnly="true" placeholder="Bank Account Name" runat="server"></asp:TextBox>   
        </div>
    </div>
    <div id="DIV_supplier_payment_method" runat="server" class="clearfix">
        <div class="form-label">Supplier Payment Method</div>
        <div class="form-input">
            <asp:TextBox ID="TB_supplier_payment_method" name="supplierpaymentmethod" ReadOnly="true" placeholder="Supplier Payment Method" runat="server"></asp:TextBox>   
        </div>
    </div>

    <div style="overflow-x:auto;">
        <asp:GridView ID="GRID_Supplier_Payments_Due" PageSize="2000" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            AutoGenerateColumns="false" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
            <Columns>
                <asp:BoundField DataField="unique_id" HeaderText="Booking ID" ReadOnly="true" />
                <asp:TemplateField HeaderText="Check-In Date">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_DateStarted" runat="server" Text='<%# SetDateVal(Eval("DateStarted")) %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ClientName" HeaderText="Client name" ReadOnly="true" />
                <asp:TemplateField HeaderText="Total Cost to Easyways">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_TotalCostToEasyways" runat="server" Text="0"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Note to Supplier">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_NoteToSupplier" runat="server" Text=""/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="date_paid" HeaderText="Date Paid" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy}" />
                <%--<asp:TemplateField HeaderText="Bank Account Name">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_BankAccountName" runat="server" Text=""/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier Payment Method">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_SupplierPaymentMethod" runat="server" Text=""/>
                    </ItemTemplate>
                </asp:TemplateField>--%>
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
    
    <div class="clearfix">
        <div class="form-label" >Total Amount to be paid</div>
        <div class="form-input">
            <%--<asp:TextBox ID="TB_Total_Amount" name="totalamount"   placeholder="Total Amount" ReadOnly="true" runat="server"></asp:TextBox>   --%>
            <input type="text" id="txtTotalAmount_<%= intIndex %>" value="<%= (dblTotalCost - dblPaidAmount).ToString("0.00") %>" readonly />
        </div>
    </div>
    <div class="clearfix">
        <div class="form-label" >Payment Amount</div>
        <div class="form-input">
            <input type="hidden" id="hdnPaymentAmount_<%= intIndex %>" value="<%= (dblTotalCost - dblPaidAmount).ToString("0.00") %>" />
            <input type="text" id="txtPaymentAmount_<%= intIndex %>" value="" placeholder="0.00" <%= strDatePaidStatus %> />
        </div>
    </div>
        <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_Paid" runat="server" class="form-label" Text="Date Paid" ReadOnly="true"></asp:Label>
                              
                                  <div class="form-input">
                                <%--<asp:TextBox ID="TB_Date_Paid" class="date" type="date" name="date" placeholder="mm/dd/yyyy" ReadOnly="true"  runat="server"></asp:TextBox>--%>
                                <input type="date" class="date" id="txtDatePaid_<%= intIndex %>" value="<%= strDatePaid %>" <%= strDatePaidStatus %> />
                              
                              
</div>     </div>     
    
    <div style="overflow-x:auto;">
        <asp:GridView ID="GRID_Supplier_Payments_Amount" PageSize="2000" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            AutoGenerateColumns="false" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
            <Columns>
                <asp:BoundField DataField="date_paid" HeaderText="Date Paid" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy}" />
                <asp:BoundField DataField="total_amount" HeaderText="Payment Amount" ReadOnly="true" />
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

             <div class="clearfix">
                                
                          <asp:Label ID="LABEL_Paid" runat="server" class="form-label" Text="Paid?" ></asp:Label>      
                              
                                  <div class="form-input">
                                      <%--<asp:CheckBox ID="CHK_Paid"  style="margin-top:2%;margin-left:2%;" runat="server" />--%>
                                      <input type="checkbox" id="chkPaid_<%= intIndex %>" style="margin-top:2%;margin-left:2%;" <%= strPaid %> <%= strPaidStatus %> disabled/>
                                </div>

                            </div>
     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <%--<asp:Button ID="BUT_Mark_as_Paid" UseSubmitBehavior="true" runat="server" Text="Mark as Paid" />--%>
                                <input type="button" name="BUT_Mark_as_Paid" id="BUT_Mark_as_Paid_<%= intIndex %>" value="Mark as Paid" onclick='MarkAsPaid_Click("<%= intIndex %>")' <%= strButtonStatus %> />
                          
</div></div>
           
       <br />   <br />
   <div class="clearfix" style="height:5px;background-color:#000; ">
    
       </div>
 
</div>
<% 
                    intIndex = intIndex + 1
                End If
            Next
        End If
    Else
%>
    <h4>No record found</h4>
<%
    End If
%>      
</div>
               
       </div></div>
       </div>

<script type="text/javascript">

    //code to handle setting page offset on load
    $(function () {
        if (window.location.href.indexOf('pos') != -1) {
            //gets the number from end of url
            var match = window.location.href.split('?')[1].match(/\d+$/);
            var page_y = match[0];

            //sets the page offset 
            $('html, body').scrollTop(page_y);
        }
    });

    function MarkAsPaid_Click(index) {
        //alert(index);
        //alert($("#hdnSupplierId_" + index).val());
        //alert($("#txtTotalAmount_" + index).val());
        //alert($("#txtDatePaid_" + index).val());

        var monthVal = $("#<%= DROP_Month.ClientID %>").val();
        var yearVal = $("#<%= DROP_Year.ClientID %>").val();
        var supplierType = $("#<%= DROP_Supplier_Type.ClientID %>").val();
        var supplierId = $("#hdnSupplierId_" + index).val();
        //var totalAmount = $("#txtTotalAmount_" + index).val();
        var totalAmount = $("#txtPaymentAmount_" + index).val();
        var hdnPaymentAmount = $("#hdnPaymentAmount_" + index).val();
        var datePaid = $("#txtDatePaid_" + index).val();
        var chkPaid = true;
        /*if ($("#chkPaid_" + index).prop("checked") == true) {
            chkPaid = true;
        }
        else {
            chkPaid = false;
        }*/

        //alert(totalAmount);
        //alert(hdnPaymentAmount);

        if (datePaid == "") {
            alert("Please select a date");
            $("#txtDatePaid_" + index).focus();
        }
        else if (totalAmount == "" || parseFloat(totalAmount) <= 0) {
            alert("Please enter amount to pay.");
            $("#txtPaymentAmount_" + index).focus();
        }
        else if (parseFloat(totalAmount) > parseFloat(hdnPaymentAmount))
        {
            alert("You have only £" + hdnPaymentAmount + " left to pay. Please check and try again.");
            $("#txtPaymentAmount_" + index).val("");
            $("#txtPaymentAmount_" + index).focus();
        }
        /*else if (chkPaid == false) {
            alert("Please tick the Paid box");
            $("#chkPaid_" + index).focus();
        }*/
        else {

            var paidStatus = ""
            if (parseFloat(totalAmount) == parseFloat(hdnPaymentAmount)) {
                paidStatus = "FullPaid";
            }
            //alert(paidStatus);

            var doaction = "ManagePaymentToSupplierTotal";

            $(document).ajaxStart(function () {
                $(".supplier_payments").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".supplier_payments").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, MonthVal: monthVal, YearVal: yearVal, SupplierType: supplierType, SupplierId: supplierId, TotalAmount: totalAmount, DatePaid: datePaid, ChkPaid: chkPaid, PaidStatus: paidStatus }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    alert("Payment has been applied successfully");
                    //window.location.hash = "#mypara"
                    //location.reload(true);

                    //code to refresh the page
                    var pos = $(document).scrollTop();
                    var url = window.location.href;
                    var a = url.indexOf("?");
                    var b = url.substring(a);
                    var strUrl = url.replace(b, "");
                    window.location.href = strUrl;
                    window.location.href = window.location.href + '?pos=' + pos;
                    location.reload(true);

                    /*if ($("#chkPaid_" + index).prop("checked") == true) {
                    $("#chkPaid_" + index).checked = true;
                    $("#chkPaid_" + index).attr("disabled", "disabled")
                    $("#txtDatePaid_" + index).attr("readonly", "readonly")
                    $("#BUT_Mark_as_Paid_" + index).attr("style", "display:none;")
                    }*/
                }
                else {
                    alert("There was a system error. If this error persists please contact technical support.");
                }
            });
        }
    }
</script>

</asp:Content>
