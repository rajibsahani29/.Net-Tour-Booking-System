<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_add_baggage.aspx.vb" Inherits="bookings_add_baggage"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:HiddenField ID="hdnAccordianStatus" runat="server" Value="" />
<asp:HiddenField ID="hdnExtraId" runat="server" Value="" />

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

   <h1 class="page-title" style="text-align:center;">Add Baggage to Booking</h1>


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
                 <td>&nbsp;Total Number in Party:</td>
                    <td><asp:Label ID="LABEL_Total_Number_in_Party" runat="server" Text="&nbsp;Total Number in Party"></asp:Label></td>
                      <td>&nbsp;Total Amount Payable:</td>
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td>
               
</tr>

                   <tr>
                <td>&nbsp;Customised?</td>
                    <td><asp:CheckBox ID="CHK_Customised"  enabled=false style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>

                 <div class="section group">
         <div class="row" style="align-content:center;">

        
         <div class="col span_2_of_2 text-center"> </div>

          

      
                </div>

       

     </div>            
</div>

       <div id="DIV_below_content" runat="server">

     <div class="form has-validation">

 <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Baggage</th>
						
					</tr>
				</thead>
            </table>
           </div>     

<div style="overflow-x:auto;">
      <asp:GridView ID="GRID_View_Baggage" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal" 
              AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
              OnPageIndexChanging="GRID_View_Baggage_PageIndexChanging" OnRowCancelingEdit="GRID_View_Baggage_RowCancelingEdit" 
              OnRowEditing="GRID_View_Baggage_RowEditing" OnRowUpdating="GRID_View_Baggage_RowUpdating" OnRowDeleting="GRID_View_Baggage_RowDeleting" 
              OnRowDataBound="GRID_View_Baggage_OnRowDataBound" OnSelectedIndexChanging="GRID_View_Baggage_SelectedIndexChanged"
              emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" >
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                <asp:CommandField ShowSelectButton="true" SelectText="Email" />
                <asp:BoundField DataField="ExtraName" HeaderText="Extra Name" ReadOnly="true" />
                <asp:TemplateField HeaderText="Total No. of Bags">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_TotalBags" runat="server" Text='<%# Eval("no_bags")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TB_TotalBags" runat="server" Text='<%# Eval("no_bags")%>'/>
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
                <asp:TemplateField HeaderText="Info Supplier Email">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_InfoSupplierEmail" runat="server" Text='<%# FormatEmailText(Eval("info_supplier_email"))%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TB_InfoSupplierEmail" runat="server" TextMode="MultiLine" Text='<%# Eval("info_supplier_email")%>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Instructions for Booking Confirmation">
                    <ItemTemplate>
                    <asp:Label ID="LABEL_InsBookingConf" runat="server" Text='<%# FormatEmailText(Eval("instructionsx"))%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TB_InsBookingConf" runat="server" TextMode="MultiLine" Text='<%# Eval("instructionsx")%>'/>
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
                             


         <div id="div_accordions" runat="server">
     	<ul class="accordion">
        	
			<li id="one" class="files">

				<a href="#one">Add Baggage</a>
             	<ul class="sub-menu">
                    <li>
					
				 <div class="form has-validation">

                         <div class="clearfix">
                          
                                <div class="form-label">Baggage Services</div>
                             
                               
                                <div class="form-input">
                                  
          <asp:DropDownList ID="DROP_Baggage_Services" style="font-size:18px; margin-top:2%;margin-left:2%;" 
                                        runat="server" AutoPostBack="True"></asp:DropDownList>
                                        
                                </div>

                            </div>
                      <div class="clearfix">
                      <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Baggage_Internal_Google_Doc_Link" runat="server" Text="Internal Google Doc Link" /> 

                    </div>
</div>

                        <div class="clearfix">
                          
                                <div class="form-label">Select Booking Letter Instructions</div>
                             
                               
                                <div class="form-input">
                                  
          <asp:DropDownList ID="DROP_Instructions" style="font-size:18px; margin-top:2%;margin-left:2%;" 
                                        runat="server" AutoPostBack="True" >
              <asp:ListItem Text="&nbsp;First Stage" Value="0"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;No First Stage" Value="1"></asp:ListItem>
          </asp:DropDownList>
                                        
                                </div>

                            </div>


                                                     <div class="clearfix">

                                <div class="form-label">Instructions for Booking Confirmation </div>

                                <div class="form-input form-textarea" id="form-textarea4">
                              <asp:TextBox ID="TB_Instructions" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Instructions for Booking Confirmation Letter" runat="server"></asp:TextBox>   

                         

                            </div> </div>

 <div class="clearfix">
                          
                                <div class="form-label">Total No. of Bags</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Total_No_of_Bags" placeholder="" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                      <div class="clearfix">
                          
                                <div class="form-label">Maximum Weight</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Max_no_of_Bags" placeholder="" runat="server" ReadOnly="true"></asp:TextBox>   
         
                                        
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

                                <div class="form-input form-textarea" id="form-textarea2">
                              <asp:TextBox ID="TB_From_To_Stages" TextMode="MultiLine" name="additional_notes_extras"  rows="5" placeholder="Additional Notes" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                     
  <div class="clearfix">

                                <div class="form-label">Notes for Baggage Supplier Email</div>

                                <div class="form-input form-textarea" id="form-textarea3">
                              <asp:TextBox ID="TB_Baggage_Email_Notes" TextMode="MultiLine" name="additional_notes_extras"  rows="5" placeholder="Notes for Baggage Supplier" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                       <div class="clearfix">
                          
                                <div class="form-label">Do Not Show in Invoice</div>
                               
                               
                                <div class="form-input">
                     <asp:CheckBox ID="CHK_Show_in_Invoice"  style="margin-left:2%;" runat="server" />
                    </div>

                            </div>
                      <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Baggage_to_Booking" runat="server" Text="Add Baggage to this Booking" /> 

                    </div>
                    </div>

                   

				</ul>
			</li>

		</ul>
</div>
                    </div>

</div>
</section>
        </div>

<script type="text/javascript">
    $(document).ready(function () {
        var AccordianStatus = $("#<%= hdnAccordianStatus.ClientID %>").val();
        if (AccordianStatus != "") {
            //alert(AccordianStatus);
            parent.location.hash = AccordianStatus;
        }
    });
</script>

</asp:Content>