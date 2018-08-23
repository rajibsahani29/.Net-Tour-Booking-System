<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_bookings_cost_comparison.aspx.vb" Inherits="reports_bookings_cost_comparison"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Cost Comparison</h1>
   
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
                                <asp:Button ID="BUT__Show_Cost_Comparison" UseSubmitBehavior="true" runat="server" Text="Show Cost Comparison" />
                          
</div></div>                   


                          

              <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Cost_Comparison" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
                      AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                      emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                      OnSelectedIndexChanging="GRID_Cost_Comparison_SelectedIndexChanged" OnPageIndexChanging="GRID_Cost_Comparison_PageIndexChanging"
                      >
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                        <Columns>
                            <asp:BoundField DataField="unique_id" HeaderText="Booking Id" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Cost to Easyways">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_CostToEasyways" runat="server" Text='<%# objFunction.ReturnDouble(objPaymentCalculation.GetCostToEasyway(Eval("id"))).toString("0.00") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost to Clients">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_CostToClients" runat="server" Text='<%# objFunction.ReturnDouble(objPaymentCalculation.GetTotalAmountPayable(Eval("id"))).toString("0.00") %>'/>
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
