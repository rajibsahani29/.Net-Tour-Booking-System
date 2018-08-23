<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_status_all.aspx.vb" Inherits="reports_status_all"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Report by Walk Start Date / Route / Booking Status</h1>
   
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
                                   <div class="form-label">Route</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>

                     <div class="clearfix">
                                   <div class="form-label">Booking Status</div>
                              
                                  <div class="form-input" ><div class="form-label">Clients</div>
                                  <asp:DropDownList ID="DROP_Clients_Status"   style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>

                         <br />
                         <div class="form-input" ><div class="form-label">Baggage</div>
                                  <asp:DropDownList ID="DROP_Baggage_Status"   style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>
                         <br />
                         <div class="form-input" ><div class="form-label">Extras</div>
                                  <asp:DropDownList ID="DROP_Extras_Status"   style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>
                         <br />
                         <div class="form-input" ><div class="form-label">Changes</div>
                                  <asp:DropDownList ID="DROP_Changes"   style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>



                     </div>     
               
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Show_All" UseSubmitBehavior="true" runat="server" Text="Show All" />
                          
</div></div>      
                    
    <div style="overflow-x:auto;">

            <asp:GridView ID="GRID_Reports_Status" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                 AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                 emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                 OnSelectedIndexChanging="GRID_Reports_Status_SelectedIndexChanged" OnPageIndexChanging="GRID_Reports_Status_PageIndexChanging">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <EditRowStyle BackColor="#999999" />
                 <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                 <Columns>
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" ReadOnly="true" />
                    <asp:BoundField DataField="unique_id" HeaderText="Booking Id" ReadOnly="true" />
                    <asp:BoundField DataField="RouteName" HeaderText="Route" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Start Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_StartDate" runat="server" Text='<%# SetDateVal(Eval("checkin_earliest")) %>'/>                
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BookingStatus" HeaderText="Next Booking Status" ReadOnly="true" />
                    <%--<asp:TemplateField HeaderText="Next Booking Status">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_NextBookingStatus" runat="server" Text="" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
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
    
<script type="text/javascript">

    $("#<%= DROP_Clients_Status.ClientID %>").change(function () {
        $("#<%= DROP_Baggage_Status.ClientID %>").val("");
        $("#<%= DROP_Extras_Status.ClientID %>").val("");
        $("#<%= DROP_Changes.ClientID %>").val("");
    });
    $("#<%= DROP_Baggage_Status.ClientID %>").change(function () {
        $("#<%= DROP_Clients_Status.ClientID %>").val("");
        $("#<%= DROP_Extras_Status.ClientID %>").val("");
        $("#<%= DROP_Changes.ClientID %>").val("");
    });
    $("#<%= DROP_Extras_Status.ClientID %>").change(function () {
        $("#<%= DROP_Clients_Status.ClientID %>").val("");
        $("#<%= DROP_Baggage_Status.ClientID %>").val("");
        $("#<%= DROP_Changes.ClientID %>").val("");
    });
    $("#<%= DROP_Changes.ClientID %>").change(function () {
        $("#<%= DROP_Clients_Status.ClientID %>").val("");
        $("#<%= DROP_Baggage_Status.ClientID %>").val("");
        $("#<%= DROP_Extras_Status.ClientID %>").val("");
    });

    $("#<%= BUT__Show_All.ClientID %>").click(function () {
        //alert("Hello");
        if ($("#<%= DROP_Clients_Status.ClientID %>").val() == "" && $("#<%= DROP_Baggage_Status.ClientID %>").val() == "" && $("#<%= DROP_Extras_Status.ClientID %>").val() == "" && $("#<%= DROP_Changes.ClientID %>").val() == "") {
            alert("Please Select Booking Status");
            return false;
        }
    });

</script>

</asp:Content>
