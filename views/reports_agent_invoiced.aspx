<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_agent_invoiced.aspx.vb" Inherits="reports_agent_invoiced"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Agents Invoiced (12th of each month)</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


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
                                  <asp:Label ID="LABEL_Agent" runat="server" class="form-label" Text="Agent"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:DropDownList ID="DROP_Agent" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                                  </asp:DropDownList>
                                </div>

                            </div>
                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__View" UseSubmitBehavior="true" runat="server" Text="View" />
                          
</div></div>

<div id="Show_Report">
       
         

                                    

                    
    <br />

<div style="overflow-x:auto;">
    <asp:GridView ID="GRID_Agent_Invoiced" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="booking_id" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
        OnSelectedIndexChanging="GRID_Agent_Invoiced_SelectedIndexChanged" OnPageIndexChanging="GRID_Agent_Invoiced_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
        <Columns>
            <asp:BoundField DataField="unique_id" HeaderText="Booking Id" ReadOnly="true" />
            <asp:TemplateField HeaderText="Start Date">
                <ItemTemplate>
                    <asp:Label ID="LABEL_StartDate" runat="server" Text='<%# SetDateVal(Eval("checkin_earliest")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="codex" HeaderText="Route" ReadOnly="true" />
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

				</div>
    </section>

 </div>        
    

</asp:Content>
