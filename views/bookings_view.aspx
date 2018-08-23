<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="bookings_view.aspx.vb" Inherits="bookings_view"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type = "text/javascript">
    function Confirm() {
        var hdnOldRouteId = $("#<%= hdnOldRouteId.ClientID %>").val();
        var hdnNewRouteId = $("#<%= DROP_Route.ClientID %>").val();

        if (hdnOldRouteId != hdnNewRouteId) {
            if (!confirm("Are you sure you wish to change the route? This will delete all accommodation, stages, extras and baggage details already entered. This is irreversible.")) {
                return false;
            }
        }
    }
</script>

<asp:HiddenField ID="hdnOldRouteId" runat="server" Value="" />
<asp:HiddenField ID="hdnTempRouteCostEasyway" runat="server" Value="" />

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

   <h1 class="page-title" style="text-align:center;">View Booking</h1>
     <div class="form-input">
              <asp:Button ID="BUT_Back_to_Search" UseSubmitBehavior="true" Style="margin:0; margin-bottom:5px;margin-left:10px;" class="fl"  runat="server" Text="Back to Search" />                    
                    </div>
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">

                         
            <table id="booking_tables" border="1">
              
                <tr><th colspan="4" style="height:30px;">Booking Information</th></tr>
                   <tr>
                       
                       <td>&nbsp;Booking ID:</td>
                    
                       <td><asp:Label ID="LABEL_Booking_ID" runat="server" Text="&nbsp;Booking ID&nbsp;"></asp:Label></td>
                   
                       <td>&nbsp;Client Name:</td>
                    
                       <td><asp:Label ID="LABEL_Client_Name" runat="server" Text="&nbsp;Client Name"></asp:Label></td>
                </tr>

                 <tr>
                     <td>&nbsp;Tour:</td>
                   
                     <td><asp:Label ID="LABEL_Tour2" runat="server" Text="&nbsp;Tour"></asp:Label></td>
                   
                     <td>&nbsp;Staff Name:</td>
                    
                     <td><asp:Label ID="LABEL_Staff_Name" runat="server" Text="&nbsp;Staff Name"></asp:Label></td>
                </tr>

                 <tr>
                          
                     <td>&nbsp;Total Amount Payable:</td>
                   
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td> 
                   
                     <td>&nbsp;Date Created:</td>
                   
                     <td><asp:Label ID="LABEL_Date_Booking_Created" runat="server" Text="&nbsp;dd/mm/yyyy&nbsp;"></asp:Label></td>
                </tr>
                <tr>
                   <td>&nbsp;Total Balance Remaining:</td>
                   
                      <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td> 
                   
                    <td>&nbsp;Agent ID:</td>
                   
                    <td><asp:Label ID="LABEL_Agent_ID" runat="server" Text="&nbsp;Agent ID"></asp:Label></td>
                </tr>

                  <tr>
                     <td>&nbsp;No. of Booking Notes</td>
                    
                        <td><asp:Label ID="LABEL_No_of_Booking_Notes" runat="server" Text="&nbsp;No. of Booking Notes"></asp:Label></td>
                    
                      <td>&nbsp;URL Visited?</td>
                   
                      <td><asp:CheckBox ID="CHK_URL"  enabled=false style="margin-left:2%;" runat="server" /></td>
                </tr>

                    <tr>
               
                         <td>&nbsp;Booking Status:</td>
                   
                     <td><asp:Label ID="LABEL_Booking_Status" runat="server" Text="&nbsp;Status"></asp:Label></td>
                    
                        <td>&nbsp;Customised?</td>
                  
                        <td><asp:CheckBox ID="CHK_Customised"  enabled=false style="margin-left:2%;" runat="server" /></td>
                </tr>
                <tr>
              <td>&nbsp;Baggage Booking Status</td>

                    <td><asp:Label ID="LABEL_Baggage_Booking_Status" runat="server" Text="&nbsp;Pay Baggage"></asp:Label></td>

                    <td>&nbsp;Price Band</td>
                    
                    <td><asp:Label ID="LABEL_Accom_Band" runat="server" Text="&nbsp;A"></asp:Label></td>
                </tr>
                    <tr>
                     

                    <td>&nbsp;Extras Booking Status</td>
                    
                    <td><asp:Label ID="LABEL_Extras_Booking_Status" runat="server" Text="&nbsp;Pay Extras"></asp:Label></td>
                        <td></td>
                        <td></td>
                </tr>

            </table>

         </div>


        <div class="message info">     
                 <div class="section group">
         
          <div class="row">

                <div class="col span_1_of_5">
         <asp:Button ID="BUT_Booking_Status" Style ="font-size:11px;width:140px;" runat="server" Text="&nbsp;View Booking Status" />   </div>

          <div class="col span_1_of_5">
         <asp:Button ID="BUT_Client_View" Style ="font-size:11px;width:140px;" runat="server" Text="&nbsp;View Client Details" />   </div>

         <div class="col span_1_of_5"> <asp:Button ID="BUT_View_Breakdown" 
                 Style="font-size:11px;width:140px;" runat="server" 
                 Text="&nbsp;View Invoice" />  </div>

          <div class="col span_1_of_5"> <asp:Button ID="BUT_Payments" Style="font-size:11px;width:140px;" runat="server" Text="&nbsp;Payments" />   

          </div>
           

         <div class="col span_1_of_5"> <asp:Button ID="BUT_View_URL" 
                 Style="font-size:11px;width:140px;"   runat="server" 
                 Text="&nbsp;View URL" />   </div>
         
        
      
                </div>
                           
         
          <div class="row">
        <div class="col span_1_of_5"><asp:Button ID="BUT_Additional_Info"  Style="font-size:11px;width:140px;" runat="server" Text="&nbsp;Additional Info" />
        </div>

           

           <div class="col span_1_of_5"> <asp:Button ID="BUT_Additional_Extras" Style="font-size:11px;width:140px;" runat="server" Text="&nbsp;Additional Extras" />    </div>
         
         
           <div class="col span_1_of_5"><asp:Button ID="BUT_Correspondance" 
                   Style="font-size:11px;width:140px;" runat="server" Text="&nbsp;Correspondence" 
                   />       </div>

           <div class="col span_1_of_5"> <asp:Button ID="BUT_Add_Note_Booking" Style="font-size:11px;width:140px;" runat="server" Text="&nbsp;Add Note on Booking" />     </div>
                  
         
              <div class="col span_1_of_5"> <asp:Button ID="BUT_TBC" 
                      Style="font-size:11px;width:140px;" runat="server" Text="&nbsp;Apply Baggage" 
                       />   </div>
               <div class="row">

          <div class="col span_1_of_5">
         <asp:Button ID="BUT_Email_Suppliers" Style ="font-size:11px;width:140px;" runat="server" Text="&nbsp;Email Suppliers" />   </div>

     
                    
                   <div class="col span_1_of_5"><asp:Button ID="BUT_View_Evaluation" 
                   Style="font-size:11px;width:140px;" runat="server" 
                   Text="&nbsp;View Evaluation" Enabled="False" />      </div>  
                    
                     <div class="col span_1_of_5">
         <asp:Button ID="BUT_Cancel_Booking" Style ="font-size:11px;width:140px;" runat="server" Text="&nbsp;Cancel Booking" />   </div>

                     <div class="col span_1_of_5">
         <asp:Button ID="BUT_Delete_Booking" Style ="font-size:11px;width:140px;" runat="server" Text="&nbsp;Delete Booking" />   </div>
                                   <div class="col span_1_of_5" style="display:none">
         <asp:Button ID="BUT_Resequence_Stages" Style ="font-size:11px;width:140px;" runat="server" Text="&nbsp;Resequence Stages" />   </div>

      </div></div>
                 
   </div></div>
                      
  <div class="container_12 clearfix leading">
<div style="overflow-x:auto;">
     <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
              AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id, seq" 
              emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
              OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_OnRowDataBound"
              OnSelectedIndexChanging="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"
              OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px"  />
              <Columns>
                    <asp:CommandField ShowSelectButton="true" />
                    <%--<asp:BoundField DataField="seq" HeaderText="Seq" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Seq">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Sequence" runat="server" Text='<%# Eval("seq")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Sequence" runat="server" Text='<%# Eval("seq")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StageName" HeaderText="Stage" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Accommodation">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_AccomodationName" runat="server" Text='<%# SetValue(Eval("AccomName")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dates">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Dates" runat="server" Text='<%# SetDateVal(Eval("checkin")) + " " + SetDateVal(Eval("checkout"))%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Paid">
                        <ItemTemplate>
                            <asp:CheckBox ID="CHK_Paid" runat="server" Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Paid Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_PaidDate" runat="server" Text=''/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
              </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="left" Font-Size="Small" Height="50px"/>
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>      
    </div>
                    <div class="grid_12">
  

     	<ul class="accordion">
			
			<li id="one" class="files">

				<a href="#one">Add a Stage to this Booking</a>

				<ul class="sub-menu">
			<div class="form has-validation">

            <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Accom_to_Stage">

          <div class="clearfix">
                                   <div class="form-label">Select Stage</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Stage" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>    
      



             <div class="clearfix">
                          
                                <div class="form-label">Sequence in Route</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Sequence_in_Route" name="sequence_in_route" placeholder="Sequence in Route" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

       <div class="clearfix">
             <div class="form-label"></div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Accom_to_Stage" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Stage to this Booking" />
                              

                            </div>
                  
                              

                            </div>
      
            </asp:Panel>

      </div>		
				
				</ul>
                </li>

             	<li id="two" class="mail">

				<a href="#two">Modify Booking</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">

                   <asp:Panel ID="pnlForm1" runat="server" DefaultButton="BUT__Update">     

                         <div class="clearfix">
                          
                                <div class="form-label">Number of Males</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Number_of_Males" name="no_of_males"   placeholder="Number of Males" runat="server"></asp:TextBox>   
                      
                                </div>

                            </div>

                 <div class="clearfix">
                          
                                <div class="form-label">Number of Females</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Number_of_Females" name="no_of_females"   placeholder="Number of Females" runat="server"></asp:TextBox>   
                      
                                </div>

                            </div>

                 <div class="clearfix">
                          
                                <div class="form-label">Number of Unspecified</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Number_of_Unspecified" name="no_of_unspecified"   placeholder="Number of Unspecified" runat="server"></asp:TextBox>   
                      
                                </div>

                            </div>


                       
                 <div class="clearfix">
                          
                                <div class="form-label">Tour Cost</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Tour_Cost" name="tour_cost"   placeholder="Tour Cost" runat="server"></asp:TextBox>   
                      
                                </div>

                            </div>

    <div class="clearfix">
                                   <div class="form-label">Route</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Route"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>


                         <div class="clearfix">
                                   <div class="form-label">Agent</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Agent"   style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div> </div>     


  <div class="clearfix">
                          
                                <div class="form-label">Price Band:</div>
                               
                                <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accom_Band"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                      <asp:ListItem Text="Select Band" Value="0"></asp:ListItem>
                                <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                <asp:ListItem Text="B" Value="B"></asp:ListItem>
                                <asp:ListItem Text="C" Value="C"></asp:ListItem>
                                  </asp:DropDownList>

                          </div>

                            </div>

                        <div class="clearfix">
                          
                                <div class="form-label">En-suite Preference:</div>
                               
                              <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Ensuite"  style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                      <asp:ListItem Text="Select Preference" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Essential" Value="Essential"></asp:ListItem>
                                <asp:ListItem Text="Preferred" Value="Preferred"></asp:ListItem>
                                <asp:ListItem Text="Not Essential" Value="Not Essential"></asp:ListItem>
                                  </asp:DropDownList>

                          </div>

                            </div>

                        
                        <div class="clearfix">
                          
                                <div class="form-label">Customised?</div>
                               
                               
                                <div class="form-input">
                              
                                    <asp:CheckBox ID="CHK_Customised2" style="margin-left:2%;" runat="server"  />
                                        
                                </div>

                            </div>

                       
                        <div class="clearfix">
                          
                                <div class="form-label">Dog Friendly</div>
                               
                               
                                <div class="form-input">
                              
                                    <asp:CheckBox ID="CHK_Dog_Friendly" style="margin-left:2%;" runat="server"  />
                                        
                                </div>

                            </div>






                   <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Update" UseSubmitBehavior="true" runat="server" Text="Update" OnClientClick="javascript:return Confirm()" />
                          
                            </div>

                    </asp:Panel>

                          </div> 
</ul>
			</li>



     	</ul></div></div>

 </section></div>

<script type="text/javascript">
    $("#<%= BUT_Cancel_Booking.ClientID %>").click(function () {
        if (!confirm("Are you sure? This operation cannot be undone.")) {
            return false;
        }
    });
    $("#<%= BUT_Delete_Booking.ClientID %>").click(function () {
        if (!confirm("Are you sure? You will not be able to access this booking again.")) {
            return false;
        } 
    });
</script>

</asp:Content>
