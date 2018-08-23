<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_bookings_indepth_search.aspx.vb" Inherits="reports_bookings_indepth_search"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">In-Depth Booking Search</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">


              
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_Created" runat="server" class="form-label" Text="Date Created"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_Created" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>

                                    

                          </div> </div>
               

               

                   

                                <div class="clearfix">
                                  <asp:Label ID="LABEL_Last_Payment_Date" runat="server" class="form-label" Text="Last Payment Date"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Last_Payment_Date" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>


                                     

                          </div> </div>
                         
              

               

                              <div class="clearfix">
                                  <asp:Label ID="LABEL_No_of_People" runat="server" class="form-label" Text="Number of People"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_No_of_People" placeholder="Search By Number of People" runat="server"></asp:TextBox>

                                </div>

                            </div>
                          
                 
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Route" runat="server" class="form-label" Text="Route"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                </div>

                            </div>


                     <div class="clearfix">
                                  <asp:Label ID="LABEL_Show_Customised_Fixed" runat="server" class="form-label" Text="Only Show:"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:RadioButtonList ID="RADIO_Customised_Fixed"  class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server"> 
                          <asp:ListItem Selected="True" Text="&nbsp;Customised" Value="0"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Fixed" Value="1"></asp:ListItem>
                          </asp:RadioButtonList>
                                </div>

                            </div>

                     <div class="clearfix">
                                  <asp:Label ID="LABEL_Agent_or_Not" runat="server" class="form-label" Text="Only Show:"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:RadioButtonList ID="RADIO_Agent_or_Not"  class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server"> 
                          <asp:ListItem Selected="True" Text="&nbsp;Easyways" Value="0"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Agent" Value="1"></asp:ListItem>
                          </asp:RadioButtonList>
                                </div>

                            </div>




                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Show_Bookings" UseSubmitBehavior="true" runat="server" Text="Show Bookings" />
                          
</div></div>
              <div style="overflow-x:auto;">
                  
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="overflow-x:auto;">
        <asp:GridView ID="GridView1"  Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal"  
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanging="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:TemplateField HeaderText="Booking Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_DateCreated" runat="server" Text='<%# SetDateVal(Eval("datecreated")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="datecreated" HeaderText="Booking Date" ReadOnly="true" />--%>
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                    <asp:BoundField DataField="unique_id" HeaderText="Booking Ref." ReadOnly="true" />
                    <%--<asp:BoundField DataField="checkin" HeaderText="Check-In Date" ReadOnly="true" />--%>
                    <%--<asp:TemplateField HeaderText="Check-In Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_CheckInDate" runat="server" Text=''/>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="TourName" HeaderText="Tour Name" ReadOnly="true" />
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
                        </asp:GridView></div>
	        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BUT__Show_Bookings" />
                    </Triggers>
            </asp:UpdatePanel>   
                             </div>    



				</div>
    </section>

 </div>        
    

</asp:Content>
