<%@ Page Title="" Language="VB" MasterPageFile="~/main.master" AutoEventWireup="false" CodeFile="reports_supplier_payments_due_print.aspx.vb" Inherits="views_reports_supplier_payments_due_print" %>
<%@ MasterType virtualpath="~/main.master" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Easyway.BE" %>
<%@ Import Namespace="Easyway.DL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="page-title" style="text-align:center;">Payments Due to Supplier</h1>
    <input type="button" class="fr" name="BUT_Print" id="BUT_Print" value="Print" onclick="javascript:PrintElem()" />
    <br /><br />
    <div class="container_12 clearfix leading PrintElement">

        <style type="text/css">
            @media print {
                .print_border th, .print_border td
                {
                    border:1px solid black;
                }
                .print_border
                {
                    border-collapse: collapse;
                    padding:20px;
                }
                #DIV_show_payments
                {
                    padding: 50px;
                }
                table { page-break-inside:auto }
                tr    { page-break-inside:avoid; page-break-after:auto; page-break-before:auto;}
            }
        </style>

        <%
            If objFunction.CheckDataSet(dstData) Then
        
                Dim dtReportData As DataTable = New DataTable
                Dim colSupplierId As DataColumn = New DataColumn("supplier_id", Type.GetType("System.String"))
                Dim colSupplierName As DataColumn = New DataColumn("SupplierName", Type.GetType("System.String"))
                Dim colBankAccountName As DataColumn = New DataColumn("BankAccountName", Type.GetType("System.String"))
                Dim colSupplierPaymentMethod As DataColumn = New DataColumn("SupplierPaymentMethod", Type.GetType("System.String"))
                Dim colRemainingTotalAmount As DataColumn = New DataColumn("RemainingTotalAmount", Type.GetType("System.String"))
                dtReportData.Columns.Add(colSupplierId)
                dtReportData.Columns.Add(colSupplierName)
                dtReportData.Columns.Add(colBankAccountName)
                dtReportData.Columns.Add(colSupplierPaymentMethod)
                dtReportData.Columns.Add(colRemainingTotalAmount)
                
                Dim dtDataTable As DataTable = dstData.Tables(0)
                Trace.Warn("Count = " + objFunction.ReturnString(dtDataTable.Rows.Count))
                Dim dtDistinctData As DataTable = dtDataTable.DefaultView.ToTable(True, "supplier_id")
                Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))
        
                If objFunction.CheckDataTable(dtDistinctData) Then
        
                    For i = 0 To dtDistinctData.Rows.Count - 1
                        Dim dtTemp As DataTable = dtDataTable
                        dtTemp.DefaultView.RowFilter = "supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")) + " AND supplier_id <> 0"
                        Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                
                        Trace.Warn("supplier_id = " + objFunction.ReturnString(dtDistinctData.Rows(i)("supplier_id")))
                        If objFunction.CheckDataTable(dtData) Then
                    
                            Trace.Warn("dtData Count = " + objFunction.ReturnString(dtData.Rows.Count))
                            
                            Dim objBEPaymentToSupplierTotal As clsBEPaymentToSupplierTotal = New clsBEPaymentToSupplierTotal
                            objBEPaymentToSupplierTotal.SupplierId = objFunction.ReturnInteger(dtData.Rows(0)("supplier_id"))
                            objBEPaymentToSupplierTotal.MonthVal = objFunction.ReturnInteger(intMonth)
                            objBEPaymentToSupplierTotal.YearVal = objFunction.ReturnInteger(intYear)
                            objBEPaymentToSupplierTotal.SupplierType = objFunction.ReturnInteger(intSupplierType)
                            Dim dstPaymentData As DataSet = (New clsDLPaymentToSupplierTotal()).GetSupplierDetailByMonthYearSupplierIdAndSupplierType(objBEPaymentToSupplierTotal)
                    
                            Dim dblPaidAmount As Double = 0
                            If objFunction.CheckDataSet(dstPaymentData) Then
                                dblPaidAmount = objFunction.ReturnDouble(dstPaymentData.Tables(0).Compute("SUM(total_amount)", String.Empty))
                            End If
                            
                            Dim dblTotalCost As Double = 0
                            
                            For j = 0 To dtData.Rows.Count-1
                                
                                If intSupplierType = 1 Then
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
                                ElseIf intSupplierType = 2 Then
                                    Dim dstTotalCostToEasyways As DataSet = (New clsDLExtrasBaggageBooking()).GetExtrasBaggageBookingById(objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id")))
                                    Dim dblCost As Double = 0
                                    If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
                                        dblCost = objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(0)("cost_easyways"))
                                    End If
                                    dblTotalCost += dblCost
                                ElseIf intSupplierType = 3 Then
                                    Dim dstTotalCostToEasyways As DataSet = (New clsDLExtrasBooking()).GetExtrasBookingById(objFunction.ReturnInteger(dtData.Rows(j)("accom_stage_id")))
                                    Dim dblCost As Double = 0
                                    If objFunction.CheckDataSet(dstTotalCostToEasyways) Then
                                        dblCost = objFunction.ReturnDouble(dstTotalCostToEasyways.Tables(0).Rows(0)("cost_easyways"))
                                    End If
                                    dblTotalCost += dblCost
                                End If
                            Next
                            Trace.Warn("dblTotalCost = " + objFunction.ReturnString(dblTotalCost))
                            'TB_Total_Amount.Text = dblTotalCost.ToString("0.00")
                    
                            Dim dr As DataRow = dtReportData.NewRow()
                            dr("supplier_id") = objFunction.ReturnString(dtData.Rows(0)("supplier_id"))
                            dr("SupplierName") = objFunction.ReturnString(dtData.Rows(0)("SupplierName"))
                            dr("BankAccountName") = objFunction.ReturnString(dtData.Rows(0)("account_name"))
                            dr("SupplierPaymentMethod") = objFunction.ReturnString(dtData.Rows(0)("payment_prefer"))
                            dr("RemainingTotalAmount") = (dblTotalCost - dblPaidAmount).ToString("0.00")
                            dtReportData.Rows.Add(dr)
                        End If
                    Next
                End If
                GRID_Supplier_Payments_Due.DataSource = dtReportData
                GRID_Supplier_Payments_Due.DataBind()
            Else
                GRID_Supplier_Payments_Due.DataSource = New List(Of String)
                GRID_Supplier_Payments_Due.DataBind()
            End If
        %>  
        <div id="DIV_show_payments">

            <div style="overflow-x:auto;">
                <asp:GridView ID="GRID_Supplier_Payments_Due" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="2000"
                    AutoGenerateColumns="false" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" CssClass="print_border">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                    <Columns>
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" ReadOnly="true" />
                        <asp:BoundField DataField="BankAccountName" HeaderText="Bank Account Name" ReadOnly="true" />
                        <asp:BoundField DataField="SupplierPaymentMethod" HeaderText="Supplier Payment Method" ReadOnly="true" />
                        <asp:BoundField DataField="RemainingTotalAmount" HeaderText="Total Amount to be paid" ReadOnly="true" />
                        <%--<asp:TemplateField HeaderText="Supplier Name">
                            <ItemTemplate>
                                <asp:Label ID="LABEL_SupplierName" runat="server" Text=""/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bank Account Name">
                            <ItemTemplate>
                                <asp:Label ID="LABEL_BankAccountName" runat="server" Text=""/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Payment Method">
                            <ItemTemplate>
                                <asp:Label ID="LABEL_SupplierPaymentMethod" runat="server" Text=""/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount to be paid">
                            <ItemTemplate>
                                <asp:Label ID="LABEL_TotalAmount" runat="server" Text=""/>
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
        </div>
    </div>

    <script type="text/javascript">
        function PrintElem() {
            Popup($(".PrintElement").html());
        }
        function Popup(data) {
            <!--$("#<%= GRID_Supplier_Payments_Due.ClientID %>").attr("border","1")-->
            var mywindow = window.open('', '_blank');
            mywindow.document.write(data);
            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10
            mywindow.print();
            mywindow.close();
            return true;
        }
    </script>

</asp:Content>

