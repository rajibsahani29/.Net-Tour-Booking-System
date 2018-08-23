<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_view_all.aspx.vb" Inherits="accom_view_all"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<style type="text/css">
    .aiLoading::before {
        background-position: 50% 7%;
    }
    .hideGridColumn
    {
        display: none;
    }
</style>

<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="accom_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Accommodation">Add New Accommodation</a> 
                               </li> 

                                <li class="no_colour">
                                    <a  href="accom_view_all.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View Accommodation">View Accommodation</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Edit Accommodation">Edit Accommodation</a> 
                               </li> 

                                    

                                 <li class="no_colour">
                                    <a  href="accom_photos.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Delete Accommodation Imagery">Add & Delete Accommodation Imagery</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_docs.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Delete Accommodation Docs">Add & Delete Accommodation Docs</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_add_rooms.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add a New Room Type for an Acccommodation">Add New Room Type for an Accom.</a> 
                               </li>  
               <li class="no_colour">
                                    <a  href="accom_room_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View Room Types for an Accommodation">View Room Types for an Accom.</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_link.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Assign Accommodation to a Route and Stage">Assign Accommodation to Route and Stage</a> 
                               </li>                
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 


    <h1 class="page-title">View Accommodation Complete</h1>

    <div class="form-input fl">
    <asp:Button ID="BUT_Back_to_Search" Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" runat="server" Text="&nbsp;Back to Search" /> </div> 




    <div class="container_12 clearfix leading">
<section class="grid_12">
    	<div class="form has-validation">

               
  

          
<div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Basic Details</th>
						
					</tr>
				</thead>
            </table>
           </div>         
                            <div class="clearfix">
                          
                                <div class="form-label">Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_name" name="name" ReadOnly="true" placeholder="Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_contact_name" name="contact_name" ReadOnly="true" placeholder="Contact Name" runat="server"></asp:TextBox>   


                                </div></div>



                                <div class="clearfix">
                          
                                <div class="form-label">Address Line 1</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Address1" name="address1" ReadOnly="true" placeholder="Address Line 1" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Address Line 2</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Address2" name="address2" ReadOnly="true" placeholder="Address Line 2" runat="server"></asp:TextBox>   


                                </div> </div>


                                         <div class="clearfix">
                          
                                 <div class="form-label">City</div> 
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_city" name="city" ReadOnly="true" placeholder="City" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                               <div class="clearfix">
                          
                                <div class="form-label">Postcode</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_postcode" name="postcode" ReadOnly="true" placeholder="Postcode" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                              <div class="clearfix">
                                   <div class="form-label">Country</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Country" style="font-size:18px; margin-top:2%;margin-left:2%;" enabled="false" runat="server">
                                  </asp:DropDownList>

                          </div> </div>

                            <div class="clearfix">

                                  <div class="form-label">Email Address</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_email" name="email" ReadOnly="true" placeholder="Email Address" runat="server"></asp:TextBox>   
                                   

                            </div> </div>                             

                            <div class="clearfix">

                                  <div class="form-label">Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone1" name="phone1" ReadOnly="true" placeholder="Main Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                            <div class="clearfix">

                                  <div class="form-label">Mobile Phone</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Mobile_Phone" name="mobile_phone"  placeholder="Mobile Phone Number" ReadOnly="true" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

               <div class="clearfix">

                                  <div class="form-label">Total Number of Rooms</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Accom_Total_no_Rooms" name="accom_total_rooms"  placeholder="Total Number of Rooms" ReadOnly="true" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

               <div class="clearfix">

                                  <div class="form-label">Bedroom Configuration</div>


                                <div class="form-input">
                            <asp:TextBox ID="TB_Room_Config" TextMode="MultiLine" name="room_config" rows="5" ReadOnly="true" placeholder="Enter details here" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Open From (e.g. March)</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Open_From" name="open_from"  placeholder="Open From" runat="server" ReadOnly="true" value=""></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Open To (e.g. October)</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Open_To" name="open_to" placeholder="Open To" runat="server" ReadOnly="true" value=""></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Comments</div>


                                <div class="form-input">
                                <asp:TextBox ID="TB_Accom_Comments" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Leave blank if you do not want this to show" ReadOnly="true" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

               <div class="clearfix">

                                  <div class="form-label">Dog Friendly?</div>


                                <div class="form-input">
                                    <asp:CheckBox ID="CHK_Dog_Friendly" style="margin-left:2%;" enabled="false" runat="server" />
                                   

                            </div> </div>

                <div class="clearfix">

                                  <div class="form-label">Dog Price</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Dog_Price" ReadOnly="true" name="dog_price"  placeholder="Dog Price" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Dog Constraints</div>


                                <div class="form-input">
                            <asp:TextBox ID="TB_Dog_Constraints" ReadOnly="true" TextMode="MultiLine" name="dog_constraints" rows="5" placeholder="Enter details here" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                   <div class="clearfix">

                                  <div class="form-label">Star Rating</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Star_Rating" ReadOnly="true" name="star_rating"  placeholder="Star Rating" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

            <div class="clearfix">

                                  <div class="form-label">Google Map Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Google_Map_Link" name="google_map_link"  placeholder="Enter Link Here" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

             <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Facilities</th>
						
					</tr>
				</thead>
            </table>
           </div>       
  <div style="overflow-x:auto;">
           <asp:GridView ID="GRID_Accom_Facilities" PageSize="2000" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C"  GridLines="Horizontal" 
                             AutoGenerateColumns="false" DataKeyNames="id,name" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" Enabled="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                        <Columns>
                            <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                            <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Select This?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CHK_SelectFacilities" runat="server" Text='' />
                                    <asp:HiddenField ID="hdnSelectFacilities" runat="server" Value='<%# Eval("id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost to Easyways" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn">
                                <ItemTemplate>
                                    <asp:TextBox ID="TB_CostEw" runat="server" Text='0'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost to Client">
                                <ItemTemplate>
                                    <asp:TextBox ID="TB_CostClient" runat="server" Text=''/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comment">
                                <ItemTemplate>
                                    <asp:TextBox ID="TB_Comment" runat="server" Text=''/>
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
                                  </div>
                <%--<div class="clearfix">

                                  <div class="form-label">Facilities</div>

                    
                                <div class="form-input">
                            <asp:CheckBoxList ID="CHKLIST_Facilities" runat="server"></asp:CheckBoxList>
                                     </div> </div>--%>
                                   
      <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">For Tour Pack</th>
						
					</tr>
				</thead>
            </table>
           </div>       

                        <div class="clearfix">

                                <div class="form-label">Description</div>

                                <div class="form-input form-textarea" id="form-textarea1">
                              <asp:TextBox ID="TB_Description" TextMode="MultiLine" name="description" rows="10" ReadOnly="true" placeholder="Description" runat="server"></asp:TextBox>   

                         

                            </div> </div>
                    
                                    <div class="clearfix">

                                <div class="form-label">Directions Option 1</div>

                                <div class="form-input form-textarea" id="form-textarea2">
                              <asp:TextBox ID="TB_Directions" TextMode="MultiLine" name="directions" rows="10" ReadOnly="true" placeholder="Directions" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                                                  <div class="clearfix">

                                <div class="form-label">Directions Option 2</div>

                                <div class="form-input form-textarea" id="form-textarea3">
                              <asp:TextBox ID="TB_Directions2" TextMode="MultiLine" name="directions" rows="10" ReadOnly="true" placeholder="Directions Option 2" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                                                  <div class="clearfix">

                                <div class="form-label">Directions Option 3</div>

                                <div class="form-input form-textarea" id="form-textarea4">
                              <asp:TextBox ID="TB_Directions3" TextMode="MultiLine" name="directions" rows="10" ReadOnly="true" placeholder="Directions Option 3" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                                                  <div class="clearfix">

                                <div class="form-label">Directions Option 4</div>

                                <div class="form-input form-textarea" id="form-textarea5">
                              <asp:TextBox ID="TB_Directions4" TextMode="MultiLine" name="directions" rows="10" ReadOnly="true" placeholder="Directions Option 4" runat="server"></asp:TextBox>   

                         

                            </div> </div>


               <div class="clearfix">

                                  <div class="form-label">Earliest Time for Arrival</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_arrival_time" name="arrival_time"  placeholder="Earliest Time for Arrival" ReadOnly="true" runat="server"></asp:TextBox>   
                                   

                            </div> </div>




               <div class="clearfix">
                                   <div class="form-label">Breakfast</div>
                              <div style="overflow-x:auto;">
                                <asp:GridView ID="GRID_Breakfast" Enabled="False" PageSize="2000" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal"
                            AutoGenerateColumns="false" DataKeyNames="ID,Value" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       <EditRowStyle BackColor="#999999" />
                       <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                       <Columns>
                            <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                            <asp:BoundField DataField="Value" HeaderText="Description" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Select This?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CHK_SelectBreakfast" runat="server" Text=''/>
                                    <asp:HiddenField ID="hdnSelectBreakfast" runat="server" Value='<%# Eval("ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="TB_Amount" runat="server" Text=''/>
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
                                  </div>
                                  <%--<div class="form-input" >
                                  <asp:DropDownList ID="DROP_Breakfast" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>

                          </div>--%> </div>

              <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Banking</th>
						
					</tr>
				</thead>
            </table>
           </div>       
                <div class="clearfix">

                                  <div class="form-label">Payment Method</div>

                    
                                <div class="form-input">
                            <asp:CheckBoxList ID="CHKLIST_Payment_Method" enabled="false" runat="server"></asp:CheckBoxList>
                                     </div> </div>

                <div class="clearfix">

                                  <div class="form-label">Supplier Payment Method</div>

                    
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Supplier_Payment_Method" placeholder="Payment Method for Payments to Supplier" runat="server" ReadOnly="true"></asp:TextBox>
                                     </div> </div>
                            
             
                <div class="clearfix">

                                 <div class="form-label">Bank Account Name</div>
                            <div class="form-input">
                            <asp:TextBox ID="TB_Bank_Account_Name" class="full" runat="server"  placeholder="Bank Account Name"  name="bank_account_name" ReadOnly="true"></asp:TextBox>
                         
                               </div></div>



                              <div class="clearfix">
                                 
                                 <div class="form-label">Bank Account Number</div>

                            <div class="form-input">
                            <asp:TextBox ID="TB_Bank_Account_Number" class="full" runat="server"  placeholder="Bank Account Number" name="bank_account_number" ReadOnly="true"></asp:TextBox>
                         
                               </div></div>

                             <div class="clearfix">
                                   <div class="form-label">Bank Account Sort Code</div>
                              
                       
                            <div class="form-input">
                            <asp:TextBox ID="TB_Bank_Account_Sort_Code" class="full" runat="server"  placeholder="Bank Account Sort Code" name="bank_account_sort_code" ReadOnly="true"></asp:TextBox>
                         
                               </div></div>

   <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Extra Details</th>
						
					</tr>
				</thead>
            </table>
           </div>       

                             <div class="clearfix">

                                  <div class="form-label">Memberships</div>

                    
                                <div class="form-input">
                            <asp:CheckBoxList ID="CHKLIST_Memberships" Enabled="false" runat="server"></asp:CheckBoxList>
                                     </div> </div>




                            <div class="clearfix">

                                  <div class="form-label">Apple iOS Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Apple_Link" name="apple_link" ReadOnly="true" placeholder="Apple iOS Link" runat="server"></asp:TextBox>   
                                   

                            </div> </div>                             

                            <div class="clearfix">

                                  <div class="form-label">Android App Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Android_Link" name="android_link" ReadOnly="true" placeholder="Android App Link" runat="server"></asp:TextBox>   
                                   

                            </div> </div>
                 <div class="clearfix">

                                  <div class="form-label">Website Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Accom_Website" name="website"  placeholder="Website Link" ReadOnly="true" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>                

                         
                
                 	

                          

                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Existing Photos</th>
						
					</tr>
				</thead>
            </table>
           </div> 

       
<div style="overflow-x:auto;">
            <asp:GridView ID="GRID_Accom_Photos" Enabled="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
                AutoGenerateColumns="false" DataKeyNames="id,photoLoc"  PageSize="2000"
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Main Image">
                        <ItemTemplate>
                            <asp:Image ID="IMG_Photo" runat="server" Height="100" Width="100" />
                            <asp:HiddenField ID="hdnImageName" runat="server" Value='<%# Eval("photoLoc")%>' />
                            <asp:HiddenField ID="hdnAccomPhotoId" runat="server" Value='<%# Eval("id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Main Image">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Default" runat="server" Text='<%# SetDefaultVal(Eval("default_x")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>    
                    <%--<asp:CommandField ShowDeleteButton="true" />--%>
                 </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

      </div>  

                                       <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Room Types

						</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   

                <div style="overflow-x:auto;">
            <asp:GridView ID="GRID_Accom_Rooms" Enabled="False" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal"  PageSize="2000"
                AutoGenerateColumns="false" DataKeyNames="id" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
               <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                        <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                        <asp:TemplateField HeaderText="Room Type">
                            <ItemTemplate>
                                <asp:Label ID="LABEL_RoomType" runat="server" Text='<%# Eval("RoomTypeName")%>'/>
                            </ItemTemplate>
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
                        <asp:TemplateField HeaderText="Room Facilities">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="javascript: ViewRoomFacilities('<%# Eval("id")%>','<%# Eval("roomtype_id")%>');">View Room Facilities</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room Options">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="javascript: ViewRoomOption('<%# Eval("id")%>','<%# Eval("roomtype_id")%>');">View Room Option</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />--%>
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
    
</div>
     </div>
     <input type="hidden" id="hdnAccomRoomTypeId" name="hdnAccomRoomTypeId" value="" />
     </div>

 </section></div>

            
    		<!-- preload the images -->
		<div style='display:none'>
			<img src='../views/img/basic/x.png' alt='' />
		</div>
</div>

</div>
</div></div>
                         <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Links </th>
						
					</tr>
				</thead>
            </table>
           </div> 
                    <div style="overflow-x:auto;">
                     <asp:GridView ID="GRID_Accom_Links" Enabled="False" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal"   PageSize="2000"
                AutoGenerateColumns="false" DataKeyNames="id,AccomName" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                    <asp:BoundField DataField="AccomName" HeaderText="Accommodation" ReadOnly="true" />
                    <asp:BoundField DataField="StageName" HeaderText="Stage" ReadOnly="true" />
                    <%--<asp:CommandField ShowDeleteButton="true" />--%>
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

		      
                        </div>  </section>     
</div>
    <script type="text/javascript">
        function GetAccommodationFacility(accomId) {
            //alert(accomId);
            var doaction = "getAccommodationFacility";

            $(document).ajaxStart(function () {
                $(".accom_view_hide").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".accom_view_hide").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomId: accomId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    $("*[class^='clsFacilityId_'] input[type='checkbox']").attr('checked', false);
                    $("*[class^='clsCostEw_']").val("");
                    $("*[class^='clsCostClient_']").val("");
                    $("*[class^='clsComment_']").val("");
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        var ResponseCol = ResponseRow[i].split("colSplit");
                        $(".clsFacilityId_" + ResponseCol[0] + " input[type='checkbox']").attr('checked', true);
                        $(".clsCostEw_" + ResponseCol[0]).val(ResponseCol[1]);
                        $(".clsCostClient_" + ResponseCol[0]).val(ResponseCol[2]);
                        $(".clsComment_" + ResponseCol[0]).val(ResponseCol[3]);
                    }
                }
            });
        }

        function GetAccommodationBreakfast(accomId) {
            //alert(accomId);
            var doaction = "getAccommodationBreakfast";

            $(document).ajaxStart(function () {
                $(".accom_view_hide").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".accom_view_hide").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomId: accomId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    $("*[class^='clsBreakfastId_'] input[type='checkbox']").attr('checked', false);
                    $("*[class^='clsBreakfastAmount_']").val("");
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        var ResponseCol = ResponseRow[i].split("colSplit");
                        $(".clsBreakfastId_" + ResponseCol[0] + " input[type='checkbox']").attr('checked', true);
                        $(".clsBreakfastAmount_" + ResponseCol[0]).val(ResponseCol[1]);
                    }
                }
            });
        }

        function GetAccommodationPaymentMethod(accomId) {
            //alert(accomId);
            var doaction = "getAccommodationPaymentMethod";

            $(document).ajaxStart(function () {
                $(".accom_view_hide").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".accom_view_hide").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomId: accomId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    $("*[class^='clsPaymentMethodId_'] input[type='checkbox']").attr('checked', false);
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        $(".clsPaymentMethodId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                    }
                }
            });
        }

        function GetAccommodationMembership(accomId) {
            //alert(accomId);
            var doaction = "getAccommodationMembership";

            $(document).ajaxStart(function () {
                $(".accom_view_hide").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".accom_view_hide").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomId: accomId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    $("*[class^='clsMembershipId_'] input[type='checkbox']").attr('checked', false);
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        $(".clsMembershipId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                    }
                }
            });
        }

        function ViewRoomFacilities(AccomRoomTypeId, RoomtypeId) {
            //alert("AccomRoomTypeId = " + AccomRoomTypeId);
            //alert("AccomRoomtypeId = " + AccomRoomtypeId);

            $("#hdnAccomRoomTypeId").val(AccomRoomTypeId);
            $('#div_popup').modal();
            $('#basic-modal-content').css("display", "block");
            $("#divCheckBoxList").html("");

            var doaction = "getRoomFacilitiesByCompanyId";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    //$("*[class^='clsMembershipId_'] input[type='checkbox']").attr('checked', false);
                    var controlString = "";
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        var ResponseCol = ResponseRow[i].split("colSplit");
                        //$(".clsMembershipId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                        controlString += "<input type='checkbox' id='CHK_RoomFacilities_" + ResponseCol[0] + "'  name='CHK_RoomFacilities_" + ResponseCol[0] + "' value='" + ResponseCol[0] + "' class='clsCHK_Room_Facility_List' disabled><label for='CHK_RoomFacilities_" + ResponseCol[0] + "'>" + ResponseCol[1] + "</label><br/>";
                    }
                    //alert("controlString = "+controlString);
                    $("#divCheckBoxList").html(controlString);
                }
            });

            CheckedSelectedRoomFacilities(AccomRoomTypeId)
        }

        function CheckedSelectedRoomFacilities(AccomRoomTypeId) {
            //alert(AccomRoomTypeId);
            var doaction = "getRoomTypeFacilitiesByAccomRoomTypeId";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomTypeId: AccomRoomTypeId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        var ResponseCol = ResponseRow[i].split("colSplit");
                        $("#CHK_RoomFacilities_" + ResponseCol[1]).attr('checked', true);
                    }
                }
            });
        }

        function ViewRoomOption(AccomRoomTypeId, RoomtypeId) {
            //alert("AccomStageRoomId = " + AccomStageRoomId);
            //alert("AccomRoomtypeId = " + AccomRoomtypeId);

            $("#hdnAccomRoomTypeId").val(AccomRoomTypeId);
            $('#div_popup').modal();
            $('#basic-modal-content').css("display", "block");
            $("#divCheckBoxList").html("");

            var doaction = "getRoomTypeOptionsByCompanyId";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction }, function (responseText) {
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

            CheckedSelectedRoomTypeOption(AccomRoomTypeId)
        }

        function CheckedSelectedRoomTypeOption(AccomRoomTypeId) {
            //alert(AccomRoomTypeId);
            var doaction = "getRoomTypeOptionByAccomRoomTypeId";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomTypeId: AccomRoomTypeId }, function (responseText) {
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

    </script>

</asp:Content>
