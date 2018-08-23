<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_baggage_financial.aspx.vb" Inherits="reports_baggage_financial"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Baggage Financial Summary Report</h1>
   
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



                     <%--<div class="clearfix">
                                  <asp:Label ID="LABEL_Route" runat="server" class="form-label" Text="Route"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                </div>

                            </div>--%>

                       <div class="clearfix">
                          
         <div class="form-label">Baggage</div>
                               
                               
          <div class="form-input">
               <asp:DropDownList ID="DROP_Baggage" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" required >  
               </asp:DropDownList>                    
             </div>

             </div>
                         
              
                 

                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__View" UseSubmitBehavior="true" runat="server" Text="View" />
                          
</div></div>

<div id="Show_Report">
<div style="overflow-x:auto;">
    <asp:GridView ID="GRID_Taxi_Financial" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" OnPageIndexChanging="GRID_Taxi_Financial_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
         <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
            <Columns>
                <asp:BoundField DataField="unique_id" HeaderText="Booking ID" ReadOnly="true" />
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_Date" runat="server" Text='<%# SetDateVal(Eval("checkin_earliest")) %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount Made">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_AmountMade" runat="server" Text='<%# (Eval("cost_client") - Eval("cost_easyways")) %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
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
    </section>

 </div>        
    

</asp:Content>
