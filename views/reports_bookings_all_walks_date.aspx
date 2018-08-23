<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_bookings_all_walks_date.aspx.vb" Inherits="reports_bookings_all_walks_date"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Easyway.BE" %>
<%@ Import Namespace="Easyway.DL" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
   <h1 class="page-title" style="text-align:center;">All Walks by Date</h1>
   
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

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Show_All_Walks" UseSubmitBehavior="true" runat="server" Text="Show All Walks" />
                          
</div></div>      
                    
 

		</div>
     <br />
         <div class="container-fluid invoice-container" id="printablediv"   style="position:relative;">
 
<div class="pull-right btn-group btn-group-sm hidden-print">
                <a href="javascript:printDiv('printablediv')"  style="color:#000;font-weight:bold;" class="btn btn-default"><i class="fa fa-print"></i> Print</a>
                
            </div>
<div id="DIV_All_Walks_Date" runat="server">

<% 
    If objFunction.CheckDataSet(dstReportBookingAllWalksDate) Then
        Trace.Warn("Count = " + objFunction.ReturnString(dstReportBookingAllWalksDate.Tables(0).Rows.Count))
        Dim dtDistinctData As DataTable = dstReportBookingAllWalksDate.Tables(0).DefaultView.ToTable(True, "RouteId")
        Trace.Warn("dtDistinctData Count = " + objFunction.ReturnString(dtDistinctData.Rows.Count))
        
        If objFunction.CheckDataTable(dtDistinctData) Then
            For i = 0 To dtDistinctData.Rows.Count - 1
                Dim dtTemp As DataTable = dstReportBookingAllWalksDate.Tables(0)
                dtTemp.DefaultView.RowFilter = "RouteId = " + objFunction.ReturnString(dtDistinctData.Rows(i)("RouteId"))
                Dim dtData As DataTable = dtTemp.DefaultView.ToTable()
                
                Trace.Warn("RouteId = " + objFunction.ReturnString(dtDistinctData.Rows(i)("RouteId")))
                If objFunction.CheckDataTable(dtData) Then
                    dtData = dtData.Select("", "AgentName", DataViewRowState.CurrentRows).CopyToDataTable()
                    Trace.Warn("dtData Count = " + objFunction.ReturnString(dtData.Rows.Count))
                    LABEL_Route_Name.Text = objFunction.ReturnString(dtData.Rows(0)("RouteName"))
%>

<table id="reports" style="width: 100%;text-align: center;">
    <tr>
        <th colspan="10"> <asp:Label ID="LABEL_Route_Name" runat="server"  Text="Route Name"></asp:Label></th>
    </tr>
    <tr style ="background-color:#dafbfb;">
        <td>
            Start Date
        </td>
        <td>
            Finish Date
        </td>
        <td>
            Name
        </td>
        <td>
            M
        </td>
        <td>
            F
        </td>
        <td>
            Other
        </td>
        <td>
            Ref:
        </td>
        <td>
            Agent
        </td>
        <td>
            Cancelled?
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <% 
        For j = 0 To dtData.Rows.Count - 1
            LABEL_Start_Date.Text = SetDateVal(objFunction.ReturnString(dtData.Rows(j)("checkin_earliest")))
            LABEL_Finish_Date.Text = SetDateVal(objFunction.ReturnString(dtData.Rows(j)("checkout_latest")))
            LABEL_Client_Name.Text = objFunction.ReturnString(dtData.Rows(j)("ClientName"))
            LABEL_Males.Text = objFunction.ReturnString(dtData.Rows(j)("NoOfMale"))
            LABEL_Females.Text = objFunction.ReturnString(dtData.Rows(j)("NoOfFemale"))
            LABEL_Others.Text = objFunction.ReturnString(dtData.Rows(j)("NoOfOther"))
            LABEL_Booking_Ref.Text = objFunction.ReturnString(dtData.Rows(j)("unique_id"))
            LABEL_Agent_Name.Text = objFunction.ReturnString(dtData.Rows(j)("AgentName"))
            If Convert.ToBoolean(dtData.Rows(j)("Cancelled")) = True Then
                CHK_Cancelled.Checked = True
            Else
                CHK_Cancelled.Checked = False
            End If
    %>
    <tr>
        <td>
            <asp:Label ID="LABEL_Start_Date" runat="server" Text="mm/dd/yyyy"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Finish_Date" runat="server" Text="mm/dd/yyyy"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Client_Name" runat="server" Text="Andrew Fernie"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Males" runat="server" Text="1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Females" runat="server" Text="1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Others" runat="server" Text="1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Booking_Ref" runat="server" Text="JB19061756"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LABEL_Agent_Name" runat="server" Text="Agent Name"></asp:Label>
        </td>
        <td>
            <%--<asp:Label ID="LABEL_Cancelled" runat="server" Text="No"></asp:Label>--%>
            <asp:CheckBox ID="CHK_Cancelled" runat="server" Enabled="false" />
        </td>
        <td>
            <a href="javascript:;" onclick="RedirectToBookingView('<%= objFunction.ReturnString(dtData.Rows(j)("id")) %>')">Select</a>
        </td>
    </tr>
    <%
        Next    
    %>
</table>
<br />
<%
End If
    Next
End If
End If
%>
    <%--<asp:GridView ID="GRID_Bookings_All_Walks_Date" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
        AllowPaging="true" PageSize="20" AutoGenerateColumns="false" DataKeyNames="id" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
        OnSelectedIndexChanging="GRID_Bookings_All_Walks_Date_SelectedIndexChanged" OnPageIndexChanging="GRID_Bookings_All_Walks_Date_PageIndexChanging"
        >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
        <Columns>
            <asp:TemplateField HeaderText="Start Date">
                <ItemTemplate>
                    <asp:Label ID="LABEL_StartDate" runat="server" Text='<%# SetDateVal(Eval("checkin_earliest")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Finish Date">
                <ItemTemplate>
                    <asp:Label ID="LABEL_FinishDate" runat="server" Text='<%# SetDateVal(Eval("checkout_latest")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ClientName" HeaderText="Name" ReadOnly="true" />
            <asp:BoundField DataField="NoOfMale" HeaderText="Male" ReadOnly="true" />
            <asp:BoundField DataField="NoOfFemale" HeaderText="Female" ReadOnly="true" />
            <asp:BoundField DataField="NoOfOther" HeaderText="Other" ReadOnly="true" />
            <asp:BoundField DataField="unique_id" HeaderText="Ref" ReadOnly="true" />
            <asp:BoundField DataField="AgentName" HeaderText="Agent" ReadOnly="true" />
            <asp:TemplateField HeaderText="Invoice">
                <ItemTemplate>
                    <asp:CheckBox ID="CHK_Invoice" runat="server" Enabled="false" />
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
    </asp:GridView>--%>

</div>
 
</div>
    </section>

 </div>        

<script type="text/javascript">
    function RedirectToBookingView(bookingId) {
        //alert(bookingId);
        if (bookingId != "" && bookingId > 0) {

            var doaction = "RedirectToBookingView";

            /*$(document).ajaxStart(function () {
                $(".agents_view_hide").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".agents_view_hide").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });*/

            $.post('GetAjaxData.aspx', { DoAction: doaction, BookingId: bookingId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() == "Success") {
                    window.location.href = "bookings_view.aspx";
                }
                else {
                    alert("There was a system error. If this error persists please contact technical support.");
                }
            });
        }
        else {
            alert("There was a system error. If this error persists please contact technical support.");
        }
    }
</script>    

</asp:Content>
