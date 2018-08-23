<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_view.aspx.vb" Inherits="accom_view"  ValidateRequest="false"%>
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
    

 


    <h1 class="page-title">View & Edit Accommodation</h1>

   
    	<div class="form has-validation">

      <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Accommodation</th>
						
					</tr>
				</thead>
            </table>
           </div>                   
               <div class="clearfix">
                                 <div class="form-label">Select Accommodation</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accommodation_Name" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                  <asp:HiddenField ID="hdnAccomId" runat="server" Value="" />
                                  <asp:HiddenField ID="hdnEditAccomId" runat="server" Value="" />
                          </div>

                     </div>
            </div>

                <div id="DIV_accom_view_hide" class="accom_view_hide" style="display:none;">

              
     	<div class="form has-validation">

                     
          <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Update">  

              
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
                                  <asp:DropDownList ID="DROP_Country" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
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
           <asp:GridView ID="GridView1" Width="98%" runat="server" CellPadding="5" pagesize="2000" ForeColor="#00A19C" GridLines="Horizontal" 
                             AutoGenerateColumns="false" DataKeyNames="id,name" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
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




               <div class="clearfix">
                                   <div class="form-label">Breakfast</div>
                              
<div style="overflow-x:auto;">
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
                                <asp:Button ID="BUT_Update" UseSubmitBehavior="true" class="fr"  runat="server" Text="Update Accommodation" />
                              

                            </div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_Delete" UseSubmitBehavior="true" class="fr"  runat="server" Text="Delete Accommodation" />
                              

                            </div>

                 </asp:Panel>
                       
                        </div>   	

          

           

		    
       </div></div>

    <script type="text/javascript">

        $(document).ready(function () {
            var hdnEditAccomId = $("#<%= hdnEditAccomId.ClientID %>").val();
            //alert(hdnEditAccomId);
            if (hdnEditAccomId != "") {
                var accomId = $("#<%= hdnEditAccomId.ClientID %>").val();
                $('#<%= DROP_Accommodation_Name.ClientID %> option[value="' + hdnEditAccomId + '"]').attr('selected', true)
                GetAccommodationDetail(accomId);
            }
        });

        $("#<%= DROP_Accommodation_Name.ClientID %>").change(function () {
            var accomId = $("#<%= DROP_Accommodation_Name.ClientID %>").val();
            GetAccommodationDetail(accomId);
        });

        function GetAccommodationDetail(accomId) 
        {
            //alert("Hello");
            //alert(extraId);
            if (accomId != "" && accomId > 0) {

                var doaction = "getAccommodationDetail";

                $(document).ajaxStart(function () {
                    $(".accom_view_hide").addClass("aiLoading");
                });
                $(document).ajaxComplete(function () {
                    $(".accom_view_hide").removeClass("aiLoading");
                    $(document).unbind("ajaxStart ajaxStop");
                });
                $.post('GetAjaxData.aspx', { DoAction: doaction, AccomId: accomId }, function (responseText) {
                    //alert(responseText.toString());
                    if (responseText.toString() != "Error") {
                        var objAccommodationDetail = JSON.parse(responseText)
                        $("#DIV_accom_view_hide").show();

                        //Accommodation Detail
                        $("#<%= hdnAccomId.ClientID %>").val(objAccommodationDetail.AccomId);
                        $("#<%= TB_name.ClientID %>").val(objAccommodationDetail.Name);
                        $("#<%= TB_contact_name.ClientID %>").val(objAccommodationDetail.Contact);
                        $("#<%= TB_Address1.ClientID %>").val(objAccommodationDetail.Address1);
                        $("#<%= TB_Address2.ClientID %>").val(objAccommodationDetail.Address2);
                        $("#<%= TB_city.ClientID %>").val(objAccommodationDetail.City);
                        $("#<%= TB_postcode.ClientID %>").val(objAccommodationDetail.Postcode);
                        $("#<%= DROP_Country.ClientID %>").val(objAccommodationDetail.CountryId);
                        $("#<%= TB_email.ClientID %>").val(objAccommodationDetail.Email);
                        $("#<%= TB_phone1.ClientID %>").val(objAccommodationDetail.Phone);
                        $("#<%= TB_Description.ClientID %>").val(objAccommodationDetail.Description);
                        $("#<%= TB_Directions.ClientID %>").val(objAccommodationDetail.Direction);
                        $("#<%= TB_Star_Rating.ClientID %>").val(objAccommodationDetail.StarRating);
                        $("#<%= TB_arrival_time.ClientID %>").val(objAccommodationDetail.EarliestTimeArrival);
                        $("#<%= TB_Directions2.ClientID %>").val(objAccommodationDetail.Direction2);
                        $("#<%= TB_Directions3.ClientID %>").val(objAccommodationDetail.Direction3);
                        $("#<%= TB_Directions4.ClientID %>").val(objAccommodationDetail.Direction4);
                        $("#<%= TB_Mobile_Phone.ClientID %>").val(objAccommodationDetail.Mobilex);
                        $("#<%= TB_Open_From.ClientID %>").val(objAccommodationDetail.OpenFrom);
                        $("#<%= TB_Open_To.ClientID %>").val(objAccommodationDetail.OpenTo);
                        $("#<%= TB_Accom_Comments.ClientID %>").val(objAccommodationDetail.AccomComment);
                        $("#<%= TB_Accom_Website.ClientID %>").val(objAccommodationDetail.WebsiteLink);
                        if (objAccommodationDetail.DogFriendly == "True") {
                            $("#<%= CHK_Dog_Friendly.ClientID %>").attr('checked', true);
                        }
                        else {
                            $("#<%= CHK_Dog_Friendly.ClientID %>").attr('checked', false);
                        }
                        $("#<%= TB_Dog_Price.ClientID %>").val(objAccommodationDetail.DogPrice);
                        $("#<%= TB_Accom_Total_no_Rooms.ClientID %>").val(objAccommodationDetail.NoRoom);
                        $("#<%= TB_Google_Map_Link.ClientID %>").val(objAccommodationDetail.GoogleMapLink);
                        $("#<%= TB_Room_Config.ClientID %>").val(objAccommodationDetail.BedroomConfig);
                        $("#<%= TB_Dog_Constraints.ClientID %>").val(objAccommodationDetail.DogConstraints);
                        $("#<%= TB_Supplier_Payment_Method.ClientID %>").val(objAccommodationDetail.PaymentPrefer);

                        //Accommodation Bank Detail
                        $("#<%= TB_Bank_Account_Name.ClientID %>").val(objAccommodationDetail.AccountName);
                        $("#<%= TB_Bank_Account_Number.ClientID %>").val(objAccommodationDetail.AccountNo);
                        $("#<%= TB_Bank_Account_Sort_Code.ClientID %>").val(objAccommodationDetail.SortCode);

                        //Accommodation App Detail
                        $("#<%= TB_Apple_Link.ClientID %>").val(objAccommodationDetail.IosLink);
                        $("#<%= TB_Android_Link.ClientID %>").val(objAccommodationDetail.AndroidLink);

                        GetAccommodationFacility(objAccommodationDetail.AccomId)
                        GetAccommodationBreakfast(objAccommodationDetail.AccomId)
                        GetAccommodationPaymentMethod(objAccommodationDetail.AccomId)
                        GetAccommodationMembership(objAccommodationDetail.AccomId)

                    }
                    else {
                        alert("There was a system error. If this error persists please contact technical support.");
                        $("#DIV_extras_view_hide").hide();
                    }
                });
            }
            else {
                $("#DIV_extras_view_hide").hide();
            }    
        }

        function GetAccommodationFacility(accomId)
        {
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

    </script>

</asp:Content>
