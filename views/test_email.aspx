<%@ Page Title="" Language="VB" MasterPageFile="~/main.master" AutoEventWireup="false" CodeFile="test_email.aspx.vb" Inherits="views_test_email" %>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="page-title" style="text-align:center;">Test Email</h1>
    <div class="container_12 clearfix leading">
    <section class="grid_12">
	    <div class="form has-validation">
          <div style="overflow-x:auto;">
            <asp:GridView ID="GRID_Test_Email" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="supplier_id, SupplierEmail" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanging="GRID_Test_Email_SelectedIndexChanged" OnPageIndexChanging="GRID_Test_Email_PageIndexChanging"
                >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" ReadOnly="true" />
                    <asp:BoundField DataField="SupplierEmail" HeaderText="Email Address" ReadOnly="true" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Email" />
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

