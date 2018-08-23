<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_add_stages.aspx.vb" Inherits="bookings_add_stages"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Easyway.BE" %>
<%@ Import Namespace="Easyway.DL" %> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:HiddenField ID="hdnShowAccordian" Value="" runat="server" />

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

rel="popover" >Add Accom Diary Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Accommodation Diary</a> 
                               </li>    

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Diary General Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="general_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary General Event</a> 
                               </li>   
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div> 

   <h1 class="page-title" style="text-align:center;">Edit Stage To Booking</h1>


<div id="theme_dropdown2" class="theme_dropdown2">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current2" class="active_theme" href="#">Select Booking Diary Options</a> 
                            <ul style="opacity:1; display:block;">  
                                
       <li class="no_colour">
                                    <a  href="accom_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add to this Accommodation's Diary</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View this Accommodation's Diary</a> 
                               </li>    

                                <li class="no_colour">
                                    <a  href="accom_diary_edit.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Edit this Accommodation's Diary</a> 
                               </li>    

       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add to this Stage's Diary</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="general_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View this Stage's Diary</a> 
                               </li>   
                                
                                       <li class="no_colour">
                                    <a  href="general_diary_edit.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Edit this Stage's Diary</a> 
                               </li>   
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div> 
    <div class="form-input fl">
    <asp:Button ID="BUT_Back_to_Booking" 
            Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" 
            runat="server" Text="&nbsp;Back to Booking" UseSubmitBehavior="False" /> </div>

    <div class="container_12 clearfix leading">
        
            

 <section class="grid_12">

     <div class="message info">

                         
            <table id="booking_tables" border="1">
              
                <tr><th colspan="4" style="height:30px;">Booking Information</th></tr>
                   <tr><td>&nbsp;Booking ID:</td>
                    <td><asp:Label ID="LABEL_Booking_ID" runat="server" Text="&nbsp;Booking ID&nbsp;"></asp:Label></td>
                       <td>&nbsp;Route:</td>
                    <td><asp:Label ID="LABEL_Tour_and_Stage" runat="server" Text="&nbsp;Route & Stage #"></asp:Label></td>
                    
                </tr>

                 <tr>
                     <td>&nbsp;Client Name:</td>
                    <td><asp:Label ID="LABEL_Client_Name" runat="server" Text="&nbsp;Client Name"></asp:Label></td>
                       <td>&nbsp;Stage</td>
                    <td><asp:Label ID="LABEL_Stage" runat="server" Text="&nbsp;Stage #"></asp:Label></td>
               
                </tr>
                  <tr>
                 <td>&nbsp;Males:</td>
                    <td><asp:Label ID="LABEL_No_of_Males" runat="server" Text="&nbsp;Males"></asp:Label></td>
                      <td>&nbsp;Total Amount Payable:</td>
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td>
               
</tr>

                 <tr>
                 <td>&nbsp;Females:</td>
                    <td><asp:Label ID="LABEL_No_of_Females" runat="server" Text="&nbsp;Females"></asp:Label></td>
                      <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td>
               
</tr>

                   <tr>
                         <td>&nbsp;Unspecified:</td>
                    <td><asp:Label ID="LABEL_No_of_Unspecified" runat="server" Text="&nbsp;Unspecified"></asp:Label></td>
                <td>&nbsp;Customised?</td>
                    <td><asp:CheckBox ID="CHK_Customised"  enabled=false style="margin-left:2%;" runat="server" /></td>
                   </tr>

                   <tr>
                 
                <td>&nbsp;Total Number:</td>
                    <td><asp:Label ID="LABEL_Total_no_People" runat="server" Text=""></asp:Label></td>
                               <td>&nbsp;En-suite Preference:</td>
                    <td><asp:Label ID="LABEL_En_Suite_Preference" runat="server" Text="&nbsp;En-suite Preference"></asp:Label></td>

                   </tr>

            </table>

                 <div class="section group">
         <div class="row" style="align-content:center;">

        
         <div class="col span_2_of_2 text-center"> </div>

          

      
                </div>

       

                         <div class="row" style="color:#fff">
            
         
          <div class="col span_1_of_3 text-center">  Check-In Date&nbsp;&nbsp; <asp:TextBox ID="TB_Check_IN_Date" class="date" type="date" name="date" placeholder="Check-In Date"  runat="server"></asp:TextBox>  </div>

          <div class="col span_1_of_3 text-center">  Check-Out Date&nbsp;&nbsp;<asp:TextBox ID="TB_Check_OUT_Date" class="date" type="date" name="date" placeholder="Check-Out Date"   runat="server"></asp:TextBox>   </div>

             <div class="col span_1_of_3 text-center" > <asp:Button ID="BUT_Confirm_Date" Style="font-size:11px;width:150px;" runat="server" Text="Confirm Dates" />  </div>  
      </div> 
     </div>            
</div>

   <div class="form-input fl">
    <asp:Button ID="Button2" 
            Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" 
            runat="server" Text="&nbsp;Previous"  /> </div>
        <div class="form-input fr">
    <asp:Button ID="Button3" 
            Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" 
            runat="server" Text="&nbsp;Next" /> </div>

     </section>

       <div id="DIV_below_content" runat="server">

     <div class="form has-validation">
         <div id="DIV_bookings_select_accom" class="bookings_select_accom" runat="server" style="display:block;">
 <div class="clearfix">
<div class="form-label">Dog Friendly?</div>
      <div class="form-input" >
     <asp:CheckBox ID="CHK_Dog_Friendly" runat="server" AutoPostBack="True" /></div>

     </div>


     <div class="clearfix">
                                 <div class="form-label">Select Accommodation</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accommodation_Name" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>
                                  <asp:HiddenField ID="hdnAccomId" runat="server" Value="" />
                          </div>

                     </div>
                                 <div id="DIV_accom_comments" runat="server" style="display:block;"><div class="clearfix">

                                  <div class="form-label">Comments</div>


                                <div class="form-input">
                             <asp:TextBox ID="TB_Accom_Comments" TextMode="MultiLine" name="additional_info" rows="5" ReadOnly="true" placeholder="Leave blank if you do not want this to show" runat="server"></asp:TextBox>   
                                   

                            </div> </div></div>

                      <div class="clearfix">

<div class="button_container clearfix" >

    <div style="width: 80%; display: table-cell;padding-right:10px;"><asp:Button ID="BUT_View_Accom"  class="fr"  runat="server" Style="font-size:11px;width:150px;" Text="View" /></div>
    <div style="width: 10%; display: table-cell; padding-right:8px;"> <asp:Button ID="BUT_Confirm_Accom"   class="fr"  runat="server" Style="font-size:11px;width:150px;" Text="Confirm" /></div>
  
</div>

                

                        </div>  
             </div>
  

                <div id="DIV_bookings_accom_show" class="bookings_accom_show" runat="server" style="display:block;">
            
                    <div id="DIV_View_Accom" runat="server">
                
                    <div class="clearfix">
                          
                                <div class="form-label">Accommodation Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Accom_Name" readonly="true" name="accommodation name"  placeholder="Accommodation Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

<div class="clearfix">

                                  <div class="form-label">Main Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone1" readonly="true" name="phone1" placeholder="Main Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>


                      <div class="clearfix ac">
                          <asp:Button ID="BUT_Remove_Accom" Style="margin-right:50px;font-size:small" runat="server" Text="Remove This Accommodation"  />  

                          <asp:Button ID="BUT_View_Accom2" Style="margin-left:50px;font-size:small" runat="server" Text="View This Accommodation" />
                          
                          <div  style="width:100%;color:red;font-weight:bold; text-align:center;">  WARNING: By pressing remove, ALL rooms for the Accommodation for this Stage will be deleted. This CANNOT be undone.</div>
                    </div>

                        <div class="clearfix">

                                  <div class="form-label">Note to Supplier</div>


                                <div class="form-input">
                         <asp:TextBox ID="TB_Note_to_Supplier" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Notes to Supplier" runat="server"></asp:TextBox> 
                                   

                            </div> </div>
                          <div class="form-action clearfix">
                               
                               <asp:Button ID="BUT_Add_Note_to_Supplier"   class="fr"  runat="server" Text="Add Note to Supplier" />
                              
                            </div>

                         <div class="clearfix">

                                  <div class="form-label">Client Note for URL</div>


                                <div class="form-input">
                         <asp:TextBox ID="TB_Client_Note_URL" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Notes to Client" runat="server"></asp:TextBox> 
                                   

                            </div> </div>
                          <div class="form-action clearfix">
                               
                               <asp:Button ID="BUT_Add_Note_Client"   class="fr"  runat="server" Text="Add Client Note for URL" />
                              
                            </div>


 <div class="clearfix">

                                  <div class="form-label">Client Note for Invoice</div>


                                <div class="form-input">
                         <asp:TextBox ID="TB_Client_Note_invoice" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Notes for Client Invoice" runat="server"></asp:TextBox> 
                                   

                            </div> </div>
                          <div class="form-action clearfix">
                               
                               <asp:Button ID="BUT_Add_Note_Invoice"   class="fr"  runat="server" Text="Add Client Note for Invoice" />
                              
                            </div>




</div>
                    
                    </div>
 
 <div id="DIV_View_Room" runat="server">

 <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Rooms</th>
						
					</tr>
				</thead>
            </table>
           </div>         
  
<div style="overflow-x:auto;">                 
<asp:GridView ID="GRID_View_Rooms" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal"  
                        AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                        OnPageIndexChanging="GRID_View_Rooms_PageIndexChanging" OnRowCancelingEdit="GRID_View_Rooms_RowCancelingEdit" 
                        OnRowEditing="GRID_View_Rooms_RowEditing" OnRowUpdating="GRID_View_Rooms_RowUpdating" OnRowDeleting="GRID_View_Rooms_RowDeleting" 
                        OnRowDataBound="GRID_View_Rooms_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                       <Columns>
                        <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                        <asp:BoundField DataField="RoomTypeName" HeaderText="Room Type" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Occupancy">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_Males" runat="server" Text='<%# Eval("no_males")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_Males" runat="server" Text='<%# Eval("no_males")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Females">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_Females" runat="server" Text='Eval("no_females")'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_Females" runat="server" Text='Eval("no_females")'/>
                            </EditItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Children">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_Children" runat="server" Text='<%# Eval("no_of_children")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_Children" runat="server" Text='<%# Eval("no_of_children")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dogs">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_Dogs" runat="server" Text='<%# Eval("no_dogs")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_Dogs" runat="server" Text='<%# Eval("no_dogs")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dogs Cost">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_DogsCost" runat="server" Text='<%# Eval("total_cost_dogs")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_DogsCost" runat="server" Text='<%# Eval("total_cost_dogs")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost Easyways">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_CostEasyways" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_CostEasyways" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost Client">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notes">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_Notes" runat="server" Text='<%# Eval("additional_notes")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_Notes" runat="server" Text='<%# Eval("additional_notes")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room Option">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="javascript: ViewRoomFacilities('<%# Eval("id")%>','<%# Eval("accom_roomtype_id")%>');">View Room Facilities</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room Option">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="javascript: ViewRoomOption('<%# Eval("id")%>','<%# Eval("accom_roomtype_id")%>');">View Room Options</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
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

<div id="div_popup" class="cls_popup button_container clearfix basic" >
<div id='content'>


		<div id='basic-modal'>
   

    		<!-- modal content -->
		<div id="basic-modal-content">

		  <div class="container_12 clearfix leading">
            

 <section class="grid_12">
     <div class="form has-validation">
     <div class="clearfix">
<div id="divCheckBoxList" class="form-input">
    <%--<asp:CheckBoxList ID="CHKLIST_Room_Options" runat="server"></asp:CheckBoxList>--%>
</div>
     </div>
     <input type="hidden" id="hdnAccomStageRoomId" name="hdnAccomStageRoomId" value="" />
     <input type="button" id="btnSubmitRoomOption" name="btnSubmitRoomOption" value="Update" />
     </div>

 </section></div>

            
    		<!-- preload the images -->
		<div style='display:none'>
			<img src='../views/img/basic/x.png' alt='' />
		</div>
</div>

</div>
</div></div>

</div>

<div id="DIV_View_Extra" runat="server">

 <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Extras</th>
						
					</tr>
				</thead>
            </table>
           </div>     

<div style="overflow-x:auto;">
      <asp:GridView ID="GRID_View_Extras" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
              AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
              OnPageIndexChanging="GRID_View_Extras_PageIndexChanging" OnRowCancelingEdit="GRID_View_Extras_RowCancelingEdit" 
              OnRowEditing="GRID_View_Extras_RowEditing" OnRowUpdating="GRID_View_Extras_RowUpdating" OnRowDeleting="GRID_View_Extras_RowDeleting" 
              OnRowDataBound="GRID_View_Extras_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" >
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
              <Columns>
                <asp:BoundField DataField="ExtraName" HeaderText="Extra Name" ReadOnly="true" />
                <asp:TemplateField HeaderText="Cost Easyways">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_CostEasyways" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TB_CostEasyways" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cost Client">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TB_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Booked?">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_BookedYN" runat="server" Text='<%# SetValue(Eval("booked_yn"))%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hdnBookedYN" runat="server" Value='<%# Eval("booked_yn")%>'></asp:HiddenField>
                        <asp:CheckBox ID="CHK_BookedYN" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_Invoice" runat="server" Text='<%# SetValue(Eval("invoicex"))%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hdnInvoice" runat="server" Value='<%# Eval("invoicex")%>'></asp:HiddenField>
                        <asp:CheckBox ID="CHK_Invoice" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
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

        <asp:HiddenField ID="hdnAccordianStatus" runat="server" Value="" />

         <div id="div_accordions" runat="server">
     	<ul class="accordion">
        	
			<li id="one" class="files">

				<a href="#one">Add a Room</a>
                <ul class="sub-menu">

   
				<div class="form has-validation cls_RoomType">

 


        <table id="roomtypetable" style="width:100%;border-collapse:collapse;font-size:small">
      
            <tr style="background-color: #BED0EB;">
               
                 <td style="padding:10px;">
                   <b>Select?</b>
                </td>
                <td>
                    <b>Room Type</b>
                </td>
                
                <td style="padding:10px;">
                   <b>Facilities</b>
                </td>
                <td style="padding:10px;">
                   <b>Options</b>
                </td>
               
            </tr>
            <% 
                If objFunction.CheckDataSet(dstRoomType) Then
                    'Trace.Warn("Value of dstRoomType = "+objFunction.ReturnString(dstRoomType.Tables(0).Rows.Count))
                    
                    For i = 0 To dstRoomType.Tables(0).Rows.Count - 1
                        
                        LABEL_Room_Type.Text = objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("Value"))
                        'RADIO_Select.Text = objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("Id"))
                        
                        CHKBOXLIST_Room_Facilities.Items.Clear()
                        Dim dstRoomFacilities As DataSet = (New clsDLAccomRooms()).GetRoomTypeFacilitiesByAccomRoomTypeIdFillInDD(objFunction.ReturnInteger(dstRoomType.Tables(0).Rows(i)("ID")))
                        If objFunction.CheckDataSet(dstRoomFacilities) Then
                            For j = 0 To dstRoomFacilities.Tables(0).Rows.Count - 1
                                Dim item As New ListItem()
                                item.Text = objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(j)("Value"))
                                item.Value = objFunction.ReturnString(dstRoomFacilities.Tables(0).Rows(j)("ID"))
                                item.Selected = True
                                CHKBOXLIST_Room_Facilities.Items.Add(item)
                            Next
                        End If
                        CHKBOXLIST_Room_Facilities.Enabled = False
                        
                        'CHKBOXLIST_Room_Options.Items.Clear()
                        Dim objBERoomTypeOptions As clsBERoomTypeOptions = New clsBERoomTypeOptions
                        objBERoomTypeOptions.RoomTypeOptionsId = objFunction.ReturnInteger(dstRoomType.Tables(0).Rows(i)("ID"))
                        objBERoomTypeOptions.CompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                        Dim dstRoomtypeOptionsDesc As DataSet = (New clsDLRoomTypeOptions()).GetRoomTypeOptionsByIdFillInDD(objBERoomTypeOptions)
                        'If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then
                        '    For k = 0 To dstRoomtypeOptionsDesc.Tables(0).Rows.Count - 1
                        '        Dim item As New ListItem()
                        '        item.Text = objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(k)("Value"))
                        '        item.Value = objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(k)("Id"))
                        '        CHKBOXLIST_Room_Options.Items.Add(item)
                        '    Next
                        'End If
                        
            %>
            <tr style="background-color: #d4e3e5;border:1px  solid #BED0EB"">
              <td style="padding:10px;">
                    <%--<asp:RadioButton ID="RADIO_Select" runat="server" />--%>
                    <input type="radio" id="RADIO_Select_<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("ID")) %>" name="rb_Room_Select" value="<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("ID")) + "^" + objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("RoomTypeId")) %>" onclick="GetRoomPricesByRoomTypeId('<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("ID")) %>')" />
                </td>
                <td >
                    <asp:Label ID="LABEL_Room_Type" runat="server" Text="Double"></asp:Label>
                </td>

                
                <td style="padding:10px;">
                    <asp:CheckBoxList ID="CHKBOXLIST_Room_Facilities" runat="server" style="font-size: small;"></asp:CheckBoxList>
                </td>
                <td style="padding:10px;">
                    <%--<asp:CheckBoxList ID="CHKBOXLIST_Room_Options" runat="server"></asp:CheckBoxList>--%>
                    <%
                        If objFunction.CheckDataSet(dstRoomtypeOptionsDesc) Then
                    %>
                        <input type="hidden" name="hdnRoomOptionCount_<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("Id")) %>" value="<%= objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows.Count) %>" />
                    <%
                            For k = 0 To dstRoomtypeOptionsDesc.Tables(0).Rows.Count - 1
                    %>
                    <input type="checkbox" id="CHKBOXLIST_Room_Options_<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("Id")) %>_<%= k %>" name="CHKBOXLIST_Room_Options_<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("Id")) %>_<%= k %>" value="<%= objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(k)("Id")) + "^" + objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(k)("AoomtypeOptionsDescId")) %>" /><label for="CHKBOXLIST_Room_Options_<%= objFunction.ReturnString(dstRoomType.Tables(0).Rows(i)("Id")) %>_<%= k %>"><%= objFunction.ReturnString(dstRoomtypeOptionsDesc.Tables(0).Rows(k)("Value")) %></label><br />
                    <%
                            Next
                        End If
                    %>
                </td>
               
            </tr>
            <%
                    Next

                End If
            %>
        </table>

</div> 
      
   <div class="clearfix">
                                <div class="form-label">Number of Identical Rooms Required</div>
                               
                               
                                <div class="form-input">
                                  <asp:DropDownList ID="DROP_No_of_Rooms" style="font-size:18px; margin-top:2%;margin-left:2%;" 
                                        runat="server" >
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                  </asp:DropDownList>
         
                                        
                                </div>

                            </div>

      <div class="clearfix">
                                <div class="form-label">Occupancy</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_No_of_Males" name="name" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                   <div class="clearfix" style="display:none">
                          
                                <div class="form-label">Number of Females</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_No_of_Females" name="name" placeholder="" runat="server">0</asp:TextBox>   
         
                                        
                                </div>

                            </div>

                   <div class="clearfix">
                          
                                <div class="form-label">Number of Children</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_No_of_Children" name="name" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                   <div class="clearfix">
                          
                                <div class="form-label">Number of Dogs</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_No_of_Dogs" name="name" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                    <div class="clearfix">
                          
                                <div class="form-label">Total Cost of Dogs</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Total_Cost_Dogs" name="cost_dogs"  placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                       <div class="clearfix">
                          
                                <div class="form-label">Cost to Easyways</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_EW_Cost" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>


                       <div class="clearfix">
                          
                                <div class="form-label">Cost to Client</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Client_Cost" name="name" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                     <div class="clearfix">

                                <div class="form-label">Additional Notes</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Additional_Notes" TextMode="MultiLine" name="additional_notes"  rows="5" placeholder="Additional Notes" runat="server"></asp:TextBox>   

                         

                            </div> </div>

<div class="clearfix">
<div class="two_buttons">
                     <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Room_to_Booking" runat="server" Text="Add Room to this Booking" /> 

                    </div> 
                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Room_All_Stages" runat="server" Text="Add the same Room to all Stages" /> 

                    </div>
                    </div>
                    </div>

                        
                       
</ul>
			</li>

			<li id="two" class="accordion2 mail">

				<a href="#two" >Add an Extra</a>

				<ul class="sub-menu">
                    <li>
					
				 <div class="form has-validation">

                         <div class="clearfix">
                          
                                <div class="form-label">Extra Services</div>
                             
                               
                                <div class="form-input">
                                  
          <asp:DropDownList ID="DROP_Extra_Services" style="font-size:18px; margin-top:2%;margin-left:2%;" 
                                        runat="server" AutoPostBack="True"></asp:DropDownList>
                                        
                                </div>

                            </div>

                      <div class="clearfix">
                          
                                <div class="form-label">Cost to Easyways</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_EW_Cost2" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>


                       <div class="clearfix">
                          
                                <div class="form-label">Cost to Client</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Client_Cost2" name="name" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>
                      
                     <div class="clearfix">

                                <div class="form-label">From To Stages</div>

                                <div class="form-input">  <asp:TextBox ID="TB_From_To_Stages" name="name" placeholder="" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                       <div class="clearfix">

                                <div class="form-label">Additional Notes</div>

                                <div class="form-input form-textarea" id="form-textarea2">
                              <asp:TextBox ID="TB_Additional_Notes_Extras" TextMode="MultiLine" name="additional_notes_extras"  rows="5" placeholder="Additional Notes" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                       <div class="clearfix" style="display:none">
                          
                                <div class="form-label">Do Not Show in Invoice</div>
                               
                               
                                <div class="form-input">
                     <asp:CheckBox ID="CHK_Show_in_Invoice" checked="true"  style="margin-left:2%;" runat="server" />
                    </div>

                            </div>
                      <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Extra_to_Booking" runat="server" Text="Add Extra to this Booking" /> 

                    </div>
                    </div>

                   </li>

				</ul>

			</li>

			<li id="three" class="accordion2 additional_people">

				<a href="#three" >URL Options</a>

				<ul class="sub-menu">
                    <li>
					
				 <div class="form has-validation">


                        <div class="clearfix">
                          
                                <div class="form-label">Select Directions</div>
                             
                               
                                <div class="form-input">
                                  
          <asp:DropDownList ID="DROP_Instructions" style="font-size:18px; margin-top:2%;margin-left:2%;" 
                                        runat="server" AutoPostBack="True" >
              <asp:ListItem Text="&nbsp;Select Option" Value="0"></asp:ListItem>
              <asp:ListItem Text="&nbsp;On Foot" Value="1"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;By Transfer" Value="2"></asp:ListItem>
               <asp:ListItem Text="&nbsp;Alt 1" Value="3"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Alt 2" Value="4"></asp:ListItem>
          </asp:DropDownList>
                                        
                                </div>

                            </div>

                       <div class="clearfix">

                                <div class="form-label">Instructions for client (can be edited)</div>

                                <div class="form-input form-textarea" id="form-textarea4_1">
                              <asp:TextBox ID="TB_Instructions" TextMode="MultiLine" name="booking_instructions"  rows="5" placeholder="Instructions" runat="server"></asp:TextBox>   

                         

                            </div> </div>

               
                      <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Update" runat="server" Text="Update" /> 

                    </div>
                    </div>

                   </li>

				</ul>

			</li>

			<li id="four" class="accordion2 additional_extras">

				<a href="#four">View All Stages of Booking</a>

				<ul class="sub-menu">
                    <li>
					
				 <div class="form has-validation">


                     <div style="overflow-x:auto;">
                      <asp:GridView ID="GRID_All_Booking_Stages" Width="98%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                          AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id, seq" 
                          emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
                          OnRowDeleting="GRID_All_Booking_Stages_RowDeleting" OnRowDataBound="GRID_All_Booking_Stages_OnRowDataBound"
                          OnSelectedIndexChanging="GRID_All_Booking_Stages_SelectedIndexChanged" OnPageIndexChanging="GRID_All_Booking_Stages_PageIndexChanging">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                         <EditRowStyle BackColor="#999999" />
                          <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                          <Columns>
                            <asp:CommandField ShowSelectButton="true" />
                            <asp:BoundField DataField="seq" HeaderText="Sequence" ReadOnly="true" />
                            <asp:BoundField DataField="StageName" HeaderText="Stage Name" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Accomodation Name">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_AccomodationName" runat="server" Text='<%# SetAccomValue(Eval("AccomName")) %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CheckIn & CheckOut Date">
                                <ItemTemplate>
                                    <asp:Label ID="LABEL_Dates" runat="server" Text='<%# SetDateVal(Eval("checkin")) + " " + SetDateVal(Eval("checkout"))%>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="true" />
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

                       <div class="clearfix">

                                <div class="form-label">Instructions for client (can be edited)</div>

                                <div class="form-input form-textarea" id="form-textarea4">
                              <asp:TextBox ID="TextBox1" TextMode="MultiLine" name="booking_instructions"  rows="5" placeholder="Instructions" runat="server"></asp:TextBox>   

                         

                            </div> </div>

               
                      <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="Button1" runat="server" Text="Update" /> 

                    </div>
                    </div>

                   </li>

				</ul>

			</li>
		</ul>
</div>
                    </div>

</div></div>
</section>
        </div>


<script type="text/javascript">

    $(document).ready(function () {
        var AccordianStatus = $("#<%= hdnAccordianStatus.ClientID %>").val();
        if (AccordianStatus != "") {
            //alert(AccordianStatus);
            parent.location.hash = AccordianStatus;
        }

        var ShowAccordian = $("#<%= hdnShowAccordian.ClientID %>").val();
        if (ShowAccordian != "" && ShowAccordian == "Two") {
            $("#one").hide();
            //$("#two").hide();
            $("#three").hide();
            $("#four").hide();
        }
    });

    function ViewRoomFacilities(AccomStageRoomId, AccomRoomtypeId) {
        //alert("AccomRoomtypeId = " + AccomRoomtypeId);

        $("#btnSubmitRoomOption").hide();
        
        //$("#hdnAccomRoomTypeId").val(AccomRoomTypeId);
        $('#div_popup').modal();
        $('#basic-modal-content').css("display", "block");
        $("#divCheckBoxList").html("");

        var doaction = "getRoomTypeFacilitiesByAccomRoomTypeIdFillInDD";
        
        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomtypeId: AccomRoomtypeId }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                //$("*[class^='clsMembershipId_'] input[type='checkbox']").attr('checked', false);
                var controlString = "";
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    //$(".clsMembershipId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                    controlString += "<input type='checkbox' id='CHK_RoomFacilities_" + ResponseCol[0] + "'  name='CHK_RoomFacilities_" + ResponseCol[0] + "' value='" + ResponseCol[0] + "' class='clsCHK_Room_Facility_List' checked disabled><label for='CHK_RoomFacilities_" + ResponseCol[0] + "'>" + ResponseCol[1] + "</label><br/>";
                }
                //alert("controlString = "+controlString);
                $("#divCheckBoxList").html(controlString);
            }
        });
    }

    function ViewRoomOption(AccomStageRoomId, AccomRoomtypeId) {
        //alert("AccomStageRoomId = " + AccomStageRoomId);
        //alert("AccomRoomtypeId = " + AccomRoomtypeId);
        $("#hdnAccomStageRoomId").val(AccomStageRoomId);
        $('#div_popup').modal();
        $('#basic-modal-content').css("display", "block");
        $("#divCheckBoxList").html("");

        var doaction = "getRoomTypeOptionsById";

        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomtypeId: AccomRoomtypeId }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                //$("*[class^='clsMembershipId_'] input[type='checkbox']").attr('checked', false);
                var controlString = "";
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    //$(".clsMembershipId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                    controlString += "<input type='checkbox' id='CHK_RoomOption_" + ResponseCol[0] + "'  name='CHK_RoomOption_" + ResponseCol[0] + "' value='" + ResponseCol[0] + "' class='clsCHK_Room_Option_List' disabled><label for='CHK_RoomOption_" + ResponseCol[0] + "'>" + ResponseCol[1] + "</label><br/>";
                }
                //alert("controlString = "+controlString);
                $("#divCheckBoxList").html(controlString);
            }
        });

        CheckedSelectedRoomOption(AccomStageRoomId)
    }

    function CheckedSelectedRoomOption(AccomStageRoomId) {
        var doaction = "getAccomStageRoomOptions";

        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, AccomStageRoomId: AccomStageRoomId }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    $("#CHK_RoomOption_" + ResponseCol[1]).attr('checked', true);
                }
            }
        });
    }

    $("#btnSubmitRoomOption").click(function () {

        var AccomStageRoomId = $("#hdnAccomStageRoomId").val();

        if (AccomStageRoomId > 0) {

            var CheckBoxListVal = "";

            $(".clsCHK_Room_Option_List:checked").each(function () {
                CheckBoxListVal += $(this).val() + ","
            });
            //alert(CheckBoxListVal);

            var doaction = "updateAccomStageRoomOptions";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomStageRoomId: AccomStageRoomId, CheckBoxListVal: CheckBoxListVal }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() == "Success") {
                    alert("Room Options has been amended");
                }
                else {
                    alert("There was a system error. If this error persists please contact technical support.");
                }
            });
        }
    });

    $("#<%= TB_Check_IN_Date.ClientID %>").change(function () {
        var CheckInDate = $("#<%= TB_Check_IN_Date.ClientID %>").val();
        var CurrentDate = new Date(CheckInDate);
        var AddedDateVal = CurrentDate.addDays(1);
        //alert(formatDate(AddedDateVal));
        $("#<%= TB_Check_OUT_Date.ClientID %>").val(formatDate(AddedDateVal));
    });

    Date.prototype.addDays = function (days) {
        this.setDate(this.getDate() + parseInt(days));
        return this;
    };

    function formatDate(date) {
        var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        return [year, month, day].join('-');
    }

    function GetRoomPricesByRoomTypeId(AccomRoomtypeId) {
        //alert(AccomRoomtypeId);
        
        var doaction = "getRoomPricesByRoomTypeId";

        $(document).ajaxStart(function () {
            $(".cls_RoomType").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_RoomType").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomtypeId: AccomRoomtypeId }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                var ResponseCol = responseText.split("colSplit");
                $("#<%= TB_No_of_Males.ClientId %>").val(ResponseCol[0]);
                $("#<%= TB_EW_Cost.ClientId %>").val(ResponseCol[1]);
                $("#<%= TB_Client_Cost.ClientId %>").val(ResponseCol[2]);
            }
        });
    }

</script>

</asp:Content>