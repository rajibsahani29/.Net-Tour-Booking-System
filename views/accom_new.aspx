<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_new.aspx.vb" Inherits="accom_new"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style type="text/css">
    .hideGridColumn
    {
        display: none;
    }
</style>

<div id="theme_dropdown" class=" theme_dropdown">
       
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
    

 


    <h1 class="page-title">Add New Accommodation</h1>

  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    

   <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_New_Accommodation">

                     
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
                                    <asp:TextBox ID="TB_name" name="name" required="required" placeholder="Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_contact_name" name="contact_name" required="required" placeholder="Contact Name" runat="server"></asp:TextBox>   


                                </div></div>



                                <div class="clearfix">
                          
                                <div class="form-label">Address Line 1</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Address1" name="address1" required="required" placeholder="Address Line 1" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Address Line 2</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Address2" name="address2" placeholder="Address Line 2" runat="server"></asp:TextBox>   


                                </div> </div>


                                         <div class="clearfix">
                          
                                 <div class="form-label">City /Town</div> 
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_city" name="city"  placeholder="City /Town" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                               <div class="clearfix">
                          
                                <div class="form-label">Postcode</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_postcode" name="postcode" required="required" placeholder="Postcode" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                              <div class="clearfix">
                                   <div class="form-label">Country</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Country" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" required>
                                  </asp:DropDownList>

                          </div> </div>

                            <div class="clearfix">

                                  <div class="form-label">Email Address</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_email" name="email" required="required" placeholder="Email Address" runat="server"></asp:TextBox>   
                                   

                            </div> </div>                             

                            <div class="clearfix">

                                  <div class="form-label">Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone1" name="phone1" required="required" placeholder="Main Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Mobile Phone</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Mobile_Phone" name="mobile_phone"  placeholder="Mobile Phone Number" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Total Number of Rooms</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Accom_Total_no_Rooms" name="accom_total_rooms"  placeholder="Total Number of Rooms" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Bedroom Configuration</div>


                                <div class="form-input">
                            <asp:TextBox ID="TB_Room_Config" TextMode="MultiLine" name="room_config" rows="5" placeholder="Enter details here" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Open From (e.g. March)</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Open_From" name="open_from"  placeholder="Open From" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Open To (e.g. October)</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Open_To" name="open_to" placeholder="Open To" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

                           <div class="clearfix">

                                  <div class="form-label">Comments</div>


                                <div class="form-input">
                            <asp:TextBox ID="TB_Accom_Comments" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Leave blank if you do not want this to show" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                <div class="clearfix">

                                  <div class="form-label">Dog Friendly?</div>


                                <div class="form-input">
                                    <asp:CheckBox ID="CHK_Dog_Friendly" style="margin-left:2%;" runat="server" />
                                   

                            </div> </div>

                <div class="clearfix">

                                  <div class="form-label">Dog Price</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Dog_Price" name="dog_price"  placeholder="Dog Price" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

               <div class="clearfix">

                                  <div class="form-label">Dog Constraints</div>


                                <div class="form-input">
                            <asp:TextBox ID="TB_Dog_Constraints" TextMode="MultiLine" name="dog_constraints" rows="5" placeholder="Enter details here" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                   <div class="clearfix">

                                  <div class="form-label">Star Rating</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Star_Rating" name="star_rating"  placeholder="Star Rating" runat="server"></asp:TextBox>   
                                   

                            </div> </div>
                     <div class="clearfix">

                                  <div class="form-label">Google Map Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Google_Map_Link" name="google_map_link"  placeholder="Enter Link Here" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

             </div>
 	<div class="form has-validation">           
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
                       <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal" 
                             AutoGenerateColumns="false" DataKeyNames="id,name" PageSize="2000" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
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
                                  </asp:GridView></div>
                  </div>             
         	<div class="form has-validation">                          
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
                              <asp:TextBox ID="TB_Description" TextMode="MultiLine" name="description" rows="10" placeholder="Description" runat="server"></asp:TextBox>   

                         

                            </div> </div>
                    
               <div class="clearfix">

                                <div class="form-label">Directions Option 1</div>

                                <div class="form-input form-textarea" id="form-textarea2">
                              <asp:TextBox ID="TB_Directions" TextMode="MultiLine" name="directions" rows="10" placeholder="Directions" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                                                  <div class="clearfix">

                                <div class="form-label">Directions Option 2</div>

                                <div class="form-input form-textarea" id="form-textarea3">
                              <asp:TextBox ID="TB_Directions2" TextMode="MultiLine" name="directions" rows="10" placeholder="Directions Option 2" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                                                  <div class="clearfix">

                                <div class="form-label">Directions Option 3</div>

                                <div class="form-input form-textarea" id="form-textarea4">
                              <asp:TextBox ID="TB_Directions3" TextMode="MultiLine" name="directions" rows="10" placeholder="Directions Option 3" runat="server"></asp:TextBox>   

                         

                            </div> </div>

                                                  <div class="clearfix">

                                <div class="form-label">Directions Option 4</div>

                                <div class="form-input form-textarea" id="form-textarea5">
                              <asp:TextBox ID="TB_Directions4" TextMode="MultiLine" name="directions" rows="10" placeholder="Directions Option 4" runat="server"></asp:TextBox>   

                         

                            </div> </div>


               <div class="clearfix">

                                  <div class="form-label">Earliest Time for Arrival</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_arrival_time" name="arrival_time"  placeholder="Earliest Time for Arrival" runat="server"></asp:TextBox>   
                                   

                            </div> </div>


</div>
<div class="form has-validation">  
               <div class="clearfix">
                                   <div class="form-label">Breakfast</div>
                              
                   <asp:GridView ID="GRID_Breakfast" Width="98%" runat="server" CellPadding="5" ForeColor="#00A19C" GridLines="Horizontal" PageSize="2000"
                            AutoGenerateColumns="false" DataKeyNames="ID,Value" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       <EditRowStyle BackColor="#999999" />
                       <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                       <Columns>
                            <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
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
                       <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Medium" Height="50px"/>
                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                       <SortedAscendingCellStyle BackColor="#E9E7E2" />
                       <SortedAscendingHeaderStyle BackColor="#506C8C" />
                       <SortedDescendingCellStyle BackColor="#FFFDF8" />
                       <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                   </asp:GridView>

                                   </div>
    </div>
                        <div class="form has-validation">  
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
                            <asp:CheckBoxList ID="CHKLIST_Payment_Method" runat="server"></asp:CheckBoxList>
                                     </div> </div>

                              <div class="clearfix">

                                  <div class="form-label">Supplier Payment Method</div>

                    
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Supplier_Payment_Method" placeholder="Payment Method for Payments to Supplier" runat="server"></asp:TextBox>
                                     </div> </div>
                            
             
                <div class="clearfix">

                                 <div class="form-label">Bank Account Name</div>
                            <div class="form-input">
                            <asp:TextBox ID="TB_Bank_Account_Name" class="full" runat="server"  placeholder="Bank Account Name" name="bank_account_name" required="required"></asp:TextBox>
                         
                               </div></div>



                              <div class="clearfix">
                                 
                                 <div class="form-label">Bank Account Number</div>

                            <div class="form-input">
                            <asp:TextBox ID="TB_Bank_Account_Number" class="full" runat="server"  placeholder="Bank Account Number" name="bank_account_number" required="required"></asp:TextBox>
                         
                               </div></div>

                             <div class="clearfix">
                                   <div class="form-label">Bank Account Sort Code</div>
                              
                       
                            <div class="form-input">
                            <asp:TextBox ID="TB_Bank_Account_Sort_Code" class="full" runat="server"  placeholder="Bank Account Sort Code" name="bank_account_sort_code" required="required"></asp:TextBox>
                         
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
                            <asp:CheckBoxList ID="CHKLIST_Memberships" runat="server"></asp:CheckBoxList>
                                     </div> </div>




                            <div class="clearfix">

                                  <div class="form-label">Apple iOS Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Apple_Link" name="apple_link" placeholder="Apple iOS Link" runat="server"></asp:TextBox>   
                                   

                            </div> </div>                             

                            <div class="clearfix">

                                  <div class="form-label">Android App Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Android_Link" name="android_link" placeholder="Android App Link" runat="server"></asp:TextBox>   
                                   

                            </div> </div>
                               <div class="clearfix">

                                  <div class="form-label">Website Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Accom_Website" name="website"  placeholder="Website Link" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>                



                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_New_Accommodation" UseSubmitBehavior="true" class="fr"  runat="server" Text="Add New Accomodation" />
                              

                            </div>

                        </div>   	

          
          </asp:Panel>
           

		    
       </div></div>


</asp:Content>
