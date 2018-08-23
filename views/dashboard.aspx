<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="true" CodeFile="dashboard.aspx.vb" Inherits="dashboard"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   <h1 class="page-title" style="text-align:center;">Dashboard</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">
  <h2 style="text-align:center;font-weight:bold;color:#fff;text-shadow: 0 1px 1px #000;">Quick Stats</h2>
         <div class="section group">
         
          <div class="row">
        <div class="col span_1_of_4">
          <div class="well">
              # of Walks Today
          <div class="stats">
                <asp:Label ID="LABEL_No_Walks_Week" class="stats" runat="server" Text="N/A"></asp:Label></div>
         
</div>
             
          </div></div>

        <div class="col span_1_of_4">
          <div class="well">
           # of Enquiries this Week
            <div class="stats">
                <asp:Label ID="LABEL_No_Enquiries_Week" class="stats" runat="server" Text="N/A"></asp:Label></div>
         </div></div>


  
  <div class="col span_1_of_4">
          <div class="well">
              # of Partally Paid Bookings
            <div class="stats">
                <asp:Label ID="LABEL_No_Partially_Paid_Bookings" class="stats" runat="server" Text="N/A"></asp:Label></div>
          </div>
        </div>

        <div class="col span_1_of_4">
          <div class="well">
              Confirmed Bookings this week
         <div class="stats">
                <asp:Label ID="LABEL_No_Confirmed_Bookings_Week" class="stats" runat="server" Text="N/A"></asp:Label></div>
          </div>
        </div>

       
         <div class="section group">
         
          <div class="row">


                 <div class="col span_1_of_4">
          <div class="well">
              # of Walks To Date
                <div class="stats">
          <asp:Label ID="LABEL_No_Walks_To_Date" class="stats" runat="server" Text="N/A"></asp:Label></div>
          </div></div>


              <div class="col span_1_of_4">
          <div class="well">
              # of Open Enquiries
          <div class="stats">
                <asp:Label ID="LABEL_No_Open_Enquiries" class="stats" runat="server" Text="N/A"></asp:Label></div>
        </div>
      </div> 

               <div class="col span_1_of_4">
          <div class="well">
              # of Bookings Not Paid Deposit
            <div class="stats">
                <asp:Label ID="LABEL_Bookings_Not_Paid_Deposit" class="stats" runat="server" Text="N/A"></asp:Label></div>
          </div>









        </div>
          

   
      <div class="col span_1_of_4">
          <div class="well">
              Confirmed Bookings this month
         <div class="stats">
                <asp:Label ID="LABEL_No_Confirmed_Bookings_Month" class="stats" runat="server" Text="N/A"></asp:Label></div>
          </div>
        </div>
      </div> </div></div></div>
		<ul class="accordion" style="display:none;">
			
			<li id="one1" class="files">

				<a href="#one1">New Enquiry</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">

                              <div class="clearfix">
                                  <asp:Label ID="Label_Route" runat="server" class="form-label" Text="Route"></asp:Label>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_TourList" style="font-size:18px; margin-top:2%;" runat="server">
                                     
                                  </asp:DropDownList>

                          </div> </div>




                           

                           <div class="clearfix">
                            <asp:Label ID="Label_Date_of_Travel" runat="server" class="form-label" Text="Date of Travel"></asp:Label>
                             <div class="form-input" id="form-birthday">
                         
                                 <asp:TextBox ID="TB_Date_of_Travel" class="form-input" name="date" placeholder="mm/dd/yyyy" runat="server"></asp:TextBox>
                             
                              

                            </div></div>

                          
                            <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Submit" runat="server" Text="Continue" />
                          


                            </div>

                       
</ul>
			</li>
			
			<li id="two2" class="mail">

				<a href="#two2">Search Options</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">

                        <asp:Panel ID="pnlSearchName" runat="server" DefaultButton="BUT_Search_Name">

                         <div class="clearfix">
                             <div class="form-label">Search By Name</div>
                      
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Name" class="form-input" name="name" placeholder="Search By Name" runat="server"></asp:TextBox>

                                       <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Search_Name" UseSubmitBehavior="true" runat="server" Text="Search" />
                
                            </div>

                          </div> </div>

                          </asp:Panel>

                          <asp:Panel ID="pnlSearchBooking" runat="server" DefaultButton="BUT__Search_Booking">
                    	<div class="form has-validation">

                               <div class="clearfix">
                             <div class="form-label">Search By Booking Reference</div>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Booking" class="form-input" name="name" placeholder="Search By Booking Reference" runat="server"></asp:TextBox>

                                       <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Search_Booking" UseSubmitBehavior="true" runat="server" Text="Search" />
                          
                            </div>

                          </div> </div>
                            </div>

                            </asp:Panel>

                            <asp:Panel ID="pnlSearchDate" runat="server" DefaultButton="BUT__Search_Date">

                            <div class="form has-validation">

                               <div class="clearfix">
                             <div class="form-label">Search By Date - dd/mm/yyyy</div>
                                 
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Date" class="form-input" name="date" placeholder="Search By Booking Reference" runat="server"></asp:TextBox>

                                       <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Search_Date" UseSubmitBehavior="true" runat="server" Text="Search" />
                          
</div>

                            </div>

                          </div> </div>
                       
                       </asp:Panel>
                </div>
</ul>
			</li>
		</ul>
		
	<div id="dashboard_accordion" runat="server">
		<ul class="accordion">
			
            <div id="DIV_UnconfirmedNewEnquiryOverSevenDayOld" runat="server">

			<li id="one" class="files">

				<a href="#one">Unconfirmed New Enquiries over 7 Days Old</a>
                <ul class="sub-menu">
   
				<div class="form has-validation">
                    <div style="overflow-x:auto;">
           <asp:GridView ID="GRID_Enquiries_over_7_Days_Old" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanging="GRID_Enquiries_over_7_Days_Old_SelectedIndexChanged" OnPageIndexChanging="GRID_Enquiries_over_7_Days_Old_PageIndexChanging"
             >
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="unique_id" HeaderText="Booking Ref." ReadOnly="true" />
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Booking Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_DateCreated" runat="server" Text='<%# SetDateVal(Eval("datecreated")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" />
              </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" Font-Size="Small" Height="50px"/>
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#E9E7E2" />
             <SortedAscendingHeaderStyle BackColor="#506C8C" />
             <SortedDescendingCellStyle BackColor="#FFFDF8" />
             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
         </asp:GridView>

                        </div>

                       </div>
                       
</ul>
			</li>
			
            </div>

            <div id="DIV_OutstandingBalancesSixWeeksBeforeStart" runat="server">

			<li id="two" class="mail">

				<a href="#two">Outstanding Balances 6 Weeks Before Start</a>
                <ul class="sub-menu">
   
				<div class="form has-validation">
                    <div style="overflow-x:auto;">
         <asp:GridView ID="GRID_Outstanding_6_Weeks_Before" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanging="GRID_Outstanding_6_Weeks_Before_SelectedIndexChanged" OnPageIndexChanging="GRID_Outstanding_6_Weeks_Before_PageIndexChanging"
             >
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="unique_id" HeaderText="Booking Ref." ReadOnly="true" />
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="CheckIn Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_DateCreated" runat="server" Text='<%# SetDateVal(Eval("checkin_earliest")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" />
              </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" Font-Size="Small" Height="50px"/>
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#E9E7E2" />
             <SortedAscendingHeaderStyle BackColor="#506C8C" />
             <SortedDescendingCellStyle BackColor="#FFFDF8" />
             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
         </asp:GridView>

                        </div>

                       </div>
                     
</ul>
			</li>

            </div>

            <div id="DIV_SendClientURLEmail" runat="server">

            <li id="three" class="additional_people">

				<a href="#three">Send Client URL email</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">
                    <div style="overflow-x:auto;">
         <asp:GridView ID="GRID_Send_Client_URL" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanging="GRID_Send_Client_URL_SelectedIndexChanged" OnPageIndexChanging="GRID_Send_Client_URL_PageIndexChanging"
             >
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <EditRowStyle BackColor="#999999" />
                <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="unique_id" HeaderText="Booking Ref." ReadOnly="true" />
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="CheckIn Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_DateCreated" runat="server" Text='<%# SetDateVal(Eval("checkin_earliest")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" />
              </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" Font-Size="Small" Height="50px"/>
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#E9E7E2" />
             <SortedAscendingHeaderStyle BackColor="#506C8C" />
             <SortedDescendingCellStyle BackColor="#FFFDF8" />
             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
         </asp:GridView>

                        </div>

                       </div>
                     
</ul>
			</li>

            </div>

             <div id="DIV_AgentsMonthly" runat="server">

            <li id="four" class="additional_extras">

				<a href="#four">12th - Agents Monthly</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">
                    <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Agents_Monthly" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" OnRowCommand="GRID_Agents_Monthly_RowCommand"
                        OnSelectedIndexChanging="GRID_Agents_Monthly_SelectedIndexChanged" OnPageIndexChanging="GRID_Agents_Monthly_PageIndexChanging"
                      >
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="AgentName" HeaderText="Name" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Bookings Until">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_BookingsUntil" runat="server" Text='<%# LastDayOfMonthByMonthAndYear(Eval("MM"), Eval("YYYY")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="date_lastupdated" HeaderText="Last Updated" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy hh:mm:ss}" />
                            <asp:BoundField DataField="date_sent" HeaderText="Date Emailed" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy hh:mm:ss}" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Email" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary"  CommandName="RefreshData" Text="Refresh" HeaderText="" >
                                <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:ButtonField>
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
                     
</ul>
			</li>

            </div>

                         <div id="DIV_BaggageMonthly" runat="server">

            <li id="five" class="payments">

				<a href="#five">15th - Baggage Services Monthly</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">
                   <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Baggage_Services_Monthly" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" OnRowCommand="GRID_Baggage_Services_Monthly_RowCommand"
                        OnSelectedIndexChanging="GRID_Baggage_Services_Monthly_SelectedIndexChanged" OnPageIndexChanging="GRID_Baggage_Services_Monthly_PageIndexChanging"
                      >
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="ExtraName" HeaderText="Name" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Bookings Until">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_BookingsUntil" runat="server" Text='<%# LastDayOfMonthByMonthAndYear(Eval("MM"), Eval("YYYY")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="date_lastupdated" HeaderText="Last Updated" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy hh:mm:ss}" />
                            <asp:BoundField DataField="date_sent" HeaderText="Date Emailed" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy hh:mm:ss}" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Email" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary"  CommandName="RefreshData" Text="Refresh" HeaderText="" >
                                <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:ButtonField>
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
                     
</ul>
			</li>

            </div>


                 <div id="DIV_ExtraServicesMonthly" runat="server">

            <li id="six" class="correspondance">

				<a href="#six">18th - Extra Services Monthly</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">
                   <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Extra_Services_Monthly" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" OnRowCommand="GRID_Extra_Services_Monthly_RowCommand"
                        OnSelectedIndexChanging="GRID_Extra_Services_Monthly_SelectedIndexChanged" OnPageIndexChanging="GRID_Extra_Services_Monthly_PageIndexChanging"
                      >
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="ExtraName" HeaderText="Name" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Bookings Until">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_BookingsUntil" runat="server" Text='<%# LastDayOfMonthByMonthAndYear(Eval("MM"), Eval("YYYY")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="date_lastupdated" HeaderText="Last Updated" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy hh:mm:ss}" />
                            <asp:BoundField DataField="date_sent" HeaderText="Date Emailed" ReadOnly="true" DataFormatString="{0:dd MMMM yyyy hh:mm:ss}" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Email" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary"  CommandName="RefreshData" Text="Refresh" HeaderText="" >
                                <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:ButtonField>
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
                     
</ul>
			</li>

            </div>
    

    <div id="DIV_AccountPayable" runat="server">
            <li id="seven" class="evaluation">

				<a href="#seven">Account Payable</a>
                <ul class="sub-menu">
              
    <div id="DIV_PaymentsDueAccomMonthly" runat="server">
			
            <div class="clearfix" style="background:#fff;color:#808080;">
                    <table class="basic-table">
				            <thead>
					            <tr>
						            <td style="width:60%; ">21st - Payments Due to Accommodations</td>

                      
						            <td style="width:10%; ">
                                        <asp:Button ID="BUT_Report_Not_Ready" runat="server" enabled="false"  Text="Report not ready yet"/></td> 
                             <td style="width:10%; ">
                                        <asp:Button ID="BUT_Email_All" runat="server" Style="display:none; float:right"  Text="Email All" /></td> 
 <td style="width:10%; ">
                                        <asp:Button ID="BUT_Test_Email" runat="server" Style="display:none; float:right"  Text="Test Email" /></td> 
 <td style="width:10%; ">
                                        <asp:Button ID="BUT_Report_Ready" runat="server" Style="display:none; float:right"  Text="Click for Report" /></td> 
                                <td style="width:10%; ">         <asp:Button ID="btn_Refresh_21PDTA" runat="server" Style="float:right"  Text="Refresh" />
                                    </td> 
                        
                       
					            </tr>
				            </thead>
                        </table>
                </div>   
            	
                <div class="form has-validation">
                    <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Payments_Due_Accom" PageSize="2000" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
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

             <div id="DIV_BaggageServicesAccountPayable" runat="server">

       <div class="clearfix" style="background:#fff;color:#808080;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<td style="width:80%; ">28th - Baggage Services Account Payable</td>
						<td style="width:10%; ">
            <asp:Button ID="BUT_Report_Not_Ready2" runat="server" enabled="false"  Text="Report not ready yet" />
<asp:Button ID="BUT_Report_Ready2" runat="server" Style="display:none; float:right"  Text="Click for Report" />
</td>
                       
              <td style="width:10%; ">  
            <asp:Button ID="btn_Refresh_28BSAP" runat="server" Style="float:right"  Text="Refresh" />
                        </td> 
                        
                       
					</tr>
				</thead>
            </table>
           </div>   
				<div class="form has-validation">
                    <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Baggage_Services_Account_Payable"  PageSize="2000" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
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

             <div id="DIV_ExtraServicesAccountPayable" runat="server">
  <div class="clearfix" style="background:#fff;color:#808080;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<td style="width:80%; ">28th - Extras Services Account Payable</td>
                        <td style="width:10%; ">
            <asp:Button ID="BUT_Report_Not_Ready3" runat="server" enabled="false"  Text="Report not ready yet" />  <asp:Button ID="BUT_Report_Ready3" runat="server" Style="display:none; float:right"  Text="Click for Report" /></td>
	
                       
           <td style="width:10%; ">
            <asp:Button ID="btn_Refresh_28ESAP" runat="server" Style="float:right"  Text="Refresh" />
                        </td>
						
					</tr>
				</thead>
            </table>
           </div>   
  
   
				<div class="form has-validation">
                    <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Extra_Services_Account_Payable" PageSize="2000" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
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
                </ul>
            </li>
    </div>

  <div id="DIV_EvalReportsReminders" runat="server">

          <li id="eight" class="eight">

				<a href="#eight">Eval Reports Reminders</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">
                   <div style="overflow-x:auto;">
                  <asp:GridView ID="GRID_Eval_Report_Reminders" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                      AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                        emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                        OnSelectedIndexChanging="GRID_Extra_Services_Monthly_SelectedIndexChanged" OnPageIndexChanging="GRID_Extra_Services_Monthly_PageIndexChanging"
                      >
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Client Name">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_ClientName" runat="server" Text='<%# Eval("ClientName1") + " " + Eval("ClientName2") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="unique_id" HeaderText="Booking Id" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Last Overnight">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_CheckoutLatest" runat="server" Text='<%# SetDateVal(Eval("checkout_latest")) %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RouteName" HeaderText="Route" ReadOnly="true" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Email Reminder" />
                      </Columns>
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
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
                     
</ul>
			</li>

            </div>
		</ul>
		
        </div>
        </section>

 </div>        


</asp:Content>
