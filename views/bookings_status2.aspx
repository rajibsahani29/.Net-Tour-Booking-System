<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_status2.aspx.vb" Inherits="bookings_status2"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="bookings_enquiry.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add New Enquiry">Add New Enquiry</a> 
                               </li> 

                                

    <li class="no_colour">
                                    <a  href="bookings_search.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Booking</a> 
                               </li> 

                                  

  <li class="no_colour"><a href="reports_status_all.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Booking Status Report</a></li> 

       <li class="no_colour">
                                    <a  href="bookings_new_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add a New Client</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="bookings_edit_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View & Edit Client</a> 
                               </li> 

    
                 
          <li class="no_colour">
                                    <a  href="accom_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add/Edit Accom Diary Event</a> 
                               </li> 

                                      
                                  

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add/Edit General Diary Event</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary</a> 
                               </li>    
                                                                 <li class="no_colour">
                                    <a  href="reports_live_walkers.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Walkers Diary</a> 
                               </li>    
                                
                                 
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>  
    

        
   <h1 class="page-title" style="text-align:center;">View Booking Status</h1>

        <div class="form-input fl">
    <asp:Button ID="BUT_Back_to_Booking" Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" runat="server" Text="&nbsp;Back to Booking" /> </div>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">
      <div class="message info">

                         
            <table id="booking_tables" border="1">
              
                <tr><th colspan="4" style="height:30px;">Booking Information</th></tr>
                   <tr><td>&nbsp;Booking ID:</td>
                    <td><asp:Label ID="LABEL_Booking_ID" runat="server" Text="&nbsp;Booking ID&nbsp;"></asp:Label></td>
                       <td>&nbsp;Tour:</td>
                    <td><asp:Label ID="LABEL_Tour_and_Stage" runat="server" Text="&nbsp;Tour & Stage #"></asp:Label></td>
                    
                </tr>

                 <tr>
                     <td>&nbsp;Client Name:</td>
                    <td><asp:Label ID="LABEL_Client_Name" runat="server" Text="&nbsp;Client Name"></asp:Label></td>
                       <td>&nbsp;Stage #:</td>
                    <td><asp:Label ID="LABEL_Stage" runat="server" Text="&nbsp;Stage #"></asp:Label></td>
               
                </tr>
                  <tr>
                 <td>&nbsp;Total Number in Party:</td>
                    <td><asp:Label ID="LABEL_Total_Number_in_Party" runat="server" Text="&nbsp;Total Number in Party"></asp:Label></td>
                      <td>&nbsp;Total Amount Payable:</td>
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td>
               
</tr>

                   <tr>
                <td>&nbsp;Customised?</td>
                    <td><asp:CheckBox ID="CHK_Customised"  enabled="false" style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>
          
</div>
   </section>
        <div class="form-input fl">

    <asp:Button ID="BUT_Baggage_Not_Required" 
            Style="font-size:14px;width:200px;margin-bottom:5%;margin-left:5%;display:none" 
            runat="server" Text="Baggage Not Required"  /> 

        </div>
 
        <div class="form-input fr" style="margin-right:2%;">

    <asp:Button ID="BUT_Extras_Not_Required" 
            Style="font-size:14px;width:200px;margin-bottom:5%;margin-left:5%;display:none" 
            runat="server" Text="Extras Not Required" />

        </div>



         <section class="grid_12">



					<ul class="accordion cls_blur" >
			
			<li id="one" class="files">

				<a href="#one">Clients</a>
                <ul class="sub-menu">
<div class="form has-validation">
                    <div style="overflow-x:auto;">

             <asp:GridView ID="GRID_Clients" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                 AutoGenerateColumns="false" DataKeyNames="id" pagesize="2000" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <EditRowStyle BackColor="#999999" />
                 <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                 <Columns>
                    <asp:BoundField DataField="name" HeaderText="Status Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:CheckBox ID="CHK_CheckStatus" runat="server" />
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


                        </div></div>

 
</ul>
			</li>
			
			<li id="two" class="mail">

				<a href="#two">Baggage</a>
                <ul class="sub-menu">

   <div class="form has-validation">
                    <div style="overflow-x:auto;">

            <asp:GridView ID="GRID_Baggage" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                 AutoGenerateColumns="false" PageSize="2000" DataKeyNames="id" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <EditRowStyle BackColor="#999999" />
                 <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                 <Columns>
                    <asp:BoundField DataField="name" HeaderText="Status Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnBaggageBSCId" runat="server" Value=""></asp:HiddenField>
                            <asp:CheckBox ID="CHK_CheckStatus" runat="server" />
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

                        </div></div>
</ul>
			</li>

                     

            <li id="three" class="additional_people">

				<a href="#three">Extras (Taxis)</a>
                <ul class="sub-menu">
<div class="form has-validation">
                    <div style="overflow-x:auto;">
             <asp:GridView ID="GRID_Extras" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                 AutoGenerateColumns="false" PageSize="2000" DataKeyNames="id" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <EditRowStyle BackColor="#999999" />
                 <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                 <Columns>
                    <asp:BoundField DataField="name" HeaderText="Status Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnExtraBSCId" runat="server" Value=""></asp:HiddenField>
                            <asp:CheckBox ID="CHK_CheckStatus" runat="server" />
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


                        </div></div>
   
                     
</ul>
			</li>

              <li id="four" class="additional_extras" style="display:none">

				<a href="#four">Changes</a>
                <ul class="sub-menu">

   <div class="form has-validation">
                    <div style="overflow-x:auto;">

            <asp:GridView ID="GRID_Changes" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                 AutoGenerateColumns="false" PageSize="2000" DataKeyNames="id" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <EditRowStyle BackColor="#999999" />
                 <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                 <Columns>
                    <asp:BoundField DataField="name" HeaderText="Status Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:CheckBox ID="CHK_CheckStatus" runat="server" />
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


                        </div></div>
                     
</ul>
			</li>
   
		</ul>
		


        </section>
</div>     
    
<script type="text/javascript">
    function AddRemoveBookingStatusBookings(bookingId, bscId) {
        //alert(bookingId);
        //alert(bscId);

        var recStatus = "";
        //alert($(".Chk_" + bscId + " input").prop("checked"));
        if ($(".Chk_" + bscId + " input").prop("checked") == true) {
            recStatus = "AddRecord";
        }
        else {
            recStatus = "RemoveRecord";
        }
        //alert(recStatus);

        var doaction = "AddRemoveBookingStatusBookings";

        $(document).ajaxStart(function () {
            $(".cls_blur").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_blur").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, BookingId: bookingId, BscID: bscId, RecStatus: recStatus }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() == "Error") {
                alert("There was a system error. If this error persists please contact technical support.");
            }
        });
    }
</script>

</asp:Content>
