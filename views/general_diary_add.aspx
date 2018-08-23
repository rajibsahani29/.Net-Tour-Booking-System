<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="general_diary_add.aspx.vb" Inherits="general_diary_add"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
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
    

    <h1 class="page-title">Add & Edit Diary General Event</h1>


      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">

                 
<div class="form has-validation">

      <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Diary General Event</th>
						
					</tr>
				</thead>
            </table>
           </div>           
    
    
                   <div class="clearfix">
                                 <div class="form-label">Stage</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Stage" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>
                                
                          </div>

                     </div>      

               <div class="clearfix">
                                 <div class="form-label">Select Accommodation</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accom_Name" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                
                          </div>

                     </div>
         
    

         
                            <div class="clearfix">
                          
                                <div class="form-label">From</div>
                               
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_From_Date" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                                 
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">To</div>


                                <div class="form-input">
                                 <asp:TextBox ID="TB_To_Date" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                                 
         


                                </div></div>

                <div class="clearfix">

                                <div class="form-label">Notes</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                              <div class="clearfix">

                                <div class="form-label">Select to Apply Diary Event</div>


                                <div class="form-input">
                                 
                                      <asp:RadioButtonList ID="RADIO_Apply_Diary_Event"  class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server"> 
                           <asp:ListItem Text="&nbsp;Apply to this Accommodation Only" Value="0"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Apply to Stage" Value="1"></asp:ListItem>
                          </asp:RadioButtonList>
                                 

                                </div></div>


                              

             <div class="clearfix">
             <div class="form-label"></div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_General_Diary_Event"  class="fr"  runat="server" Text="Add Stage Diary Event" />
                               

                            </div>
                 </div>


 <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View & Edit Diary General Event</th>
						
					</tr>
				</thead>
            </table>
           </div>           
              
      <div class="clearfix">
                          
                                <div class="form-label">From</div>
                               
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Date_From" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                                 
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">To</div>


                                <div class="form-input">
                                 <asp:TextBox ID="TB_Date_To" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                                 
         


                                </div></div>

     <div class="clearfix">
             <div class="form-label"></div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_View" UseSubmitBehavior="true" class="fr"  runat="server" Text="View & Edit General Diary Event" />
                               

                            </div>
                 </div>
    <br />


    <div style="overflow-x:auto;">
          <asp:GridView ID="GRID_General_Diary_Edit" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal" 
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                OnPageIndexChanging="GRID_General_Diary_Edit_PageIndexChanging" OnRowCancelingEdit="GRID_General_Diary_Edit_RowCancelingEdit" 
                OnRowEditing="GRID_General_Diary_Edit_RowEditing" OnRowUpdating="GRID_General_Diary_Edit_RowUpdating" OnRowDeleting="GRID_General_Diary_Edit_RowDeleting" 
                OnRowDataBound="GRID_General_Diary_Edit_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
              <Columns>
                <asp:BoundField DataField="StageName" HeaderText="Stage" ReadOnly="true" />
                <asp:BoundField DataField="AccomName" HeaderText="Accommodation" ReadOnly="true" />
                <asp:TemplateField HeaderText="From Date">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_FromDate" runat="server" Text='<%# SetDateVal(Eval("from_date")) %>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_GridFromDate" class="date" type="date" runat="server" Text='<%# SetDateValEdit(Eval("from_date")) %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="To Date">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_ToDate" runat="server" Text='<%# SetDateVal(Eval("to_date")) %>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_GridToDate" class="date" type="date" runat="server" Text='<%# SetDateValEdit(Eval("to_date")) %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Notes">
                    <ItemTemplate>
                        <asp:Label ID="LABEL_Notes" runat="server" Text='<%# Eval("notes_x") %>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_GridNotes" runat="server" TextMode="MultiLine" Text='<%# Eval("notes_x") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="All Accom">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_GridAllAccom" runat="server" Text='<%# SetAccomRadioVal(Eval("all_accom")) %>'/>
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

                        </div>   	

                    
                        

          </div></div>

</asp:Content>
