<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_agents_route_date.aspx.vb" Inherits="reports_agents_route_date"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
   <h1 class="page-title" style="text-align:center;">All Agents by Route and Date </h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">

                      <div class="clearfix">
                                   <div class="form-label">Route</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>
              
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
<div id="DIV_Agent_Route_Date" runat="server">
<%--<table id="reports" >
   
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
    </tr>
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
<asp:Label ID="LABEL_Cancelled" runat="server" Text="No"></asp:Label>
</td>
    </tr>

</table>--%>

    <asp:GridView ID="GRID_Agents_Route_Date" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
        OnSelectedIndexChanging="GRID_Agents_Route_Date_SelectedIndexChanged" OnPageIndexChanging="GRID_Agents_Route_Date_PageIndexChanging"
        >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
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
    </asp:GridView>

</div>
 
</div>
    </section>

 </div>        
    

</asp:Content>
