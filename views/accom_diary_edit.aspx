<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_diary_edit.aspx.vb" Inherits="accom_diary_edit"  ValidateRequest="false"%>
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
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Diary General Event</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary</a> 
                               </li>    
                                                                 <li class="no_colour">
                                    <a  href="walkers_diary.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Walkers Diary</a> 
                               </li>    


                                
                              
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>     
    


    <h1 class="page-title">Edit Accommodation Diary</h1>


      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">

                 
<div class="form has-validation">

      <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Accommodation Diary</th>
						
					</tr>
				</thead>
            </table>
           </div>                   
               <div class="clearfix">
                                 <div class="form-label">Select Accommodation</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accom_Name" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>
                                
                          </div>

                     </div>
         
      

         
                            <div class="clearfix">
                          
                                <div class="form-label">From</div>
                               
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_From_Date" class="date" type="date" name="date" 
                                          placeholder="dd/mm/yyyy" runat="server" AutoPostBack="True"></asp:TextBox>
                                 
         
                                        
                                </div>

                            </div>
 <div class="clearfix">
                          
                                <div class="form-label">View ALL events in this Stage?</div>
                               
                                  <div class="form-input">
                                 
                                      <asp:CheckBox ID="CHK_View_All_Accom_Diary" runat="server" 
                                          AutoPostBack="True" />
                                        
                                </div>

                            </div>
    
    <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Diary</th>
						
					</tr>
				</thead>
            </table>
           </div>                

           <br />
<div style="overflow-x:auto;">
           <asp:GridView ID="GRID_Accom_Diary_Edit" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal" 
                AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" DataKeyNames="id,AccomDiaryEventStatusName,AccomName" 
                OnPageIndexChanging="GRID_Accom_Diary_Edit_PageIndexChanging" OnRowCancelingEdit="GRID_Accom_Diary_Edit_RowCancelingEdit" 
                OnRowEditing="GRID_Accom_Diary_Edit_RowEditing" OnRowUpdating="GRID_Accom_Diary_Edit_RowUpdating" OnRowDeleting="GRID_Accom_Diary_Edit_RowDeleting" 
                OnRowDataBound="GRID_Accom_Diary_Edit_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
             <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Notes">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Note" runat="server" Text='<%# Eval("notes_x")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Note" TextMode="MultiLine" runat="server" Text='<%# Eval("notes_x")%>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_GridDiaryEventStatus" runat="server" Text='<%# Eval("AccomDiaryEventStatusName")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnDiaryEventStatusId" runat="server" Value='<%# Eval("accom_diaryevent_status_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_GridDiaryEventStatus" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_From" runat="server" Text='<%# SetDateVal(Eval("from_date")) %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_From" type="date" class="date" runat="server" Text='<%# SetDateControlVal(Eval("from_date")) %>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_To" runat="server" Text='<%# SetDateVal(Eval("to_date")) %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_To" type="date" class="date" runat="server" Text='<%# SetDateControlVal(Eval("to_date")) %>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Accommodation">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_GridAccommodation" runat="server" Text='<%# Eval("AccomName")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnAccomId" runat="server" Value='<%# Eval("accom_id")%>'></asp:HiddenField>
                            <asp:DropDownList ID="DROP_GridAccommodation" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" >
                            </asp:DropDownList>
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

                    </div></div>
          </div></div>

</asp:Content>
