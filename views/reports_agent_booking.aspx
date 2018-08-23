<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_agent_booking.aspx.vb" Inherits="reports_agent_booking"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Bookings per Agent </h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">


              
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_From" runat="server" class="form-label" Text="Start Date"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_From" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>

                                    

                          </div> </div>
               
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_To" runat="server" class="form-label" Text="End Date"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_To" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>

                                    

                          </div> </div>

                   

                 
               
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Show_All" UseSubmitBehavior="true" runat="server" Text="Show All" />
                          
</div></div>      
                    
 

		</div>
     <br />
         <div class="container-fluid invoice-container" id="printablediv"   style="position:relative;">
 
<div class="pull-right btn-group btn-group-sm hidden-print">
                <a href="javascript:printDiv('printablediv')"  style="color:#000;font-weight:bold;" class="btn btn-default"><i class="fa fa-print"></i> Print</a>
                
            </div><br />
<div id="DIV_bookings_per_agent" runat="server">
<%--<table id="reports" >
    <col width="50%">
   <tr>
        <th colspan="2"> Bookings per Agent</th>
    </tr>
  
    <tr style ="background-color:#dafbfb;">
<td >
Agent Name
</td>
        <td>
Total
</td>

    </tr>
        <tr>
<td>
<asp:Label ID="LABEL_Agent_Name" runat="server" Text="Agent Name"></asp:Label>
</td>
<td>
<asp:Label ID="LABEL_Total_agent_bookings" runat="server" Text="123"></asp:Label>
</td>
    </tr>

</table>--%>

    <asp:GridView ID="GRID_Agent_Bookings" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
        OnSelectedIndexChanging="GRID_Agent_Bookings_SelectedIndexChanged" OnPageIndexChanging="GRID_Agent_Bookings_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
        <Columns>
            <asp:BoundField DataField="AgentName" HeaderText="Agent Name" ReadOnly="true" />
            <asp:BoundField DataField="AgentTotalBooking" HeaderText="Total" ReadOnly="true" />
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
    

</asp:Content>
