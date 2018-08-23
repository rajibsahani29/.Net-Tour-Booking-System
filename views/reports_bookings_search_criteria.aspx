<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_bookings_search_criteria.aspx.vb" Inherits="views_reports_bookings_search_criteria" ValidateRequest="false" %>
<%@ MasterType virtualpath="~/main.master" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   <h1 class="page-title" style="text-align:center;">Search by Criteria</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">

           
              
<div class="form has-validation">              
             <div class="section group">
         
         

          <div class="col span_1_of_2" style="display:none;">
          <div class="clearfix">
                                   <div class="form-label">By Status:</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Booking_Status" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>  </div>

      <div class="clearfix">
                                   <div class="form-label">By Route:</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>  


          
         <div class="clearfix">
                                   <div class="form-label">By Agent:</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Agent" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>   
           


         
        
      
     

                       <div class="clearfix">
                                   <div class="form-label">By Nationality:</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Country" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>     
      


     <div class="clearfix">
                                   <div class="form-label">By Start Date:</div>
                              
                                  <div class="form-input" >
                                   <asp:TextBox ID="TB_Start_Date" class="date" type="date" name="date" 
                                          placeholder="mm/dd/yyyy"  runat="server" AutoPostBack="True"></asp:TextBox>

                          </div>  
        </div>

</div>

     </div>
                 

         </div>


<%--<div id="Div1" class="report_viewer" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="rptBookingSearchCriteria.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        TypeName="ReportBookingSearchCriteriaDataSetTableAdapters.">
    </asp:ObjectDataSource>

</div>--%>

    <asp:GridView ID="GRID_Bookings_Search_Criteria" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
        OnSelectedIndexChanging="GRID_Bookings_Search_Criteria_SelectedIndexChanged" OnPageIndexChanging="GRID_Bookings_Search_Criteria_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
        <Columns>
            <asp:BoundField DataField="unique_id" HeaderText="Booking Id" ReadOnly="true" />
            <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
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
            <asp:BoundField DataField="AgentName" HeaderText="Agent" ReadOnly="true" />
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


 </section></div>



</asp:Content>

