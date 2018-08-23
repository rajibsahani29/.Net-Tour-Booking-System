<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="staff_view.aspx.vb" Inherits="staff_view"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style type="text/css">
    .aiLoading::before {
        background-position: 50% 20%;
    }
</style>
  
<div id="theme_dropdown" class=" theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="staff_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Staff">Add New Staff</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="staff_password.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Update Password">Update Password</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="staff_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View Staff">View Staff</a> 
                               </li> 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    


    <h1 class="page-title">View Staff</h1>

  
      <div class="container_12 clearfix leading">

       <div class="grid_12">
                        


   

                     
     	<div class="form has-validation">
  <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Staff</th>
						
					</tr>
				</thead>
            </table>
           </div> 
                     
               <div class="clearfix">
                                 <div class="form-label">Choose Staff</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Staff_Name" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                  <asp:HiddenField runat="server"  id="hdnStaffId" Value="" />
                                  <asp:HiddenField runat="server"  id="hdnStaffRecStatus" Value="" />
                          </div>

                     </div>

                <div id="DIV_staff_view_hide" class="staff_view_hide" style="display:none;">

<div class="form has-validation">
                    
                            <div class="clearfix">
                          
                                <div class="form-label">First Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_firstname" name="firstname" required="required" placeholder="First Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Surname</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_surname" name="surname" required="required" placeholder="Surname" runat="server"></asp:TextBox>   


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
                          
                                 <div class="form-label">City</div> 
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_city" name="city" required="required" placeholder="City" runat="server"></asp:TextBox>   
         
                                        
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
                                  <asp:DropDownList ID="DROP_Country" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" required="required">
                                  </asp:DropDownList>
                          </div> </div>

                                    <div class="clearfix">
                                  <div class="form-label">Gender</div>
                              
                                   <div class="form-input"  >

                                
                          <asp:RadioButtonList ID="RADIO_Gender" class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server" required="required"> 
                            <%--<asp:ListItem Text="&nbsp;Male" Value="0"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Female" Value="1"></asp:ListItem>--%>
                           </asp:RadioButtonList>

                          </div> 




                            </div>

                            <div class="clearfix">

                                  <div class="form-label">Main Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone1" name="phone1" required="required" placeholder="Main Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

                         <div class="clearfix">

                                  <div class="form-label">Secondary Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone2" name="phone2"  placeholder="Secondary Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>


                                <div class="clearfix">

                                <div class="form-label">Additional Information</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>


                                <div class="clearfix">

                                 <div class="form-label">Password</div>
                            <div class="form-input">
                            <asp:TextBox ID="TB_Password" class="full" runat="server"  placeholder="Password" name="password" required="required"></asp:TextBox>
                         
                               </div></div>



                              <div class="clearfix">
                                   <div class="form-label">Role</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Role" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" required="required">
                                  </asp:DropDownList>

                          </div> </div>


                                    <div class="clearfix">
                            <div class="form-label">Date Started</div>
                             <div class="form-input" >
                         
                                 <asp:TextBox ID="TB_Date_Started"  class="date" name="date" type="date"  placeholder="dd/mm/yyyy" required="required" runat="server"></asp:TextBox>
                             
                              

                            </div></div>

                       <div class="clearfix">
                          <div class="form-label">Date Ended</div>
                             <div class="form-input" >
                         
                                
                                 <asp:TextBox ID="TB_Date_Ended"  class="date" name="date" type="date"  placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                             
                              

                            </div></div>


                     <div class="clearfix">
                           
                          <div class="form-label">Last Login</div>
                             <div class="form-input" >
                         
                                 <asp:Label ID="LABEL_Last_Login" runat="server" class="form-label" Text=""></asp:Label>
                              

                            </div></div>


                    
                     <div class="clearfix">
                         <div class="form-label">Date Added</div>

                             <div class="form-input" >
                         
                               <asp:Label ID="LABEL_Date_Added" runat="server" class="form-label" Text=""></asp:Label>
                             
                              

                            </div></div>

                           <div class="clearfix">
                           <div class="form-label">Last Updated</div>


                             <div class="form-input" >
                         
                                <asp:Label ID="LABEL_Last_Updated" runat="server" class="form-label" Text=""></asp:Label>
                              

                            </div></div>

                           <div class="clearfix">
                            
                                <div class="form-label">Username</div>
                             <div class="form-input" >
                         
                               <asp:Label ID="LABEL_Username" runat="server" class="form-label" Text=""></asp:Label>

                            </div></div>




                        
             <div class="clearfix">

<div class="button_container clearfix" >
    <div style="display: table-cell;width: 80%;padding-right:10px; "> <asp:Button ID="BUT_Update"   class="fr"  runat="server" Text="Update" /></div>
    <div style="width: 8%; display: table-cell;padding-right:10px;"><asp:Button ID="BUT_Cancel"   class="fr"  runat="server" Text="Cancel" /></div>
    <div style="width: 10%; display: table-cell; padding-right:8px;"> <asp:Button ID="BUT_Deactivate"   class="fr"  runat="server" Text="DEACTIVATE" /></div>
  
</div>

                

                        </div>   	

                     
                        </div>   	
       </div></div></div>

    <script type="text/javascript">
        $("#<%= DROP_Staff_Name.ClientID %>").change(function () {
            //alert("Hello");
            var staffId = $("#<%= DROP_Staff_Name.ClientID %>").val();
            //alert(staffId);
            if (staffId != "" && staffId > 0) {

                var doaction = "getStaffMemberDetail";

                $(document).ajaxStart(function () {
                    $(".staff_view_hide").addClass("aiLoading");
                });
                $(document).ajaxComplete(function () {
                    $(".staff_view_hide").removeClass("aiLoading");
                    $(document).unbind("ajaxStart ajaxStop");
                });
                $.post('GetAjaxData.aspx', { DoAction: doaction, StaffId: staffId }, function (responseText) {
                    //alert(responseText.toString());
                    if (responseText.toString() != "Error") {
                        var objStaffDetail = JSON.parse(responseText)
                        $("#DIV_staff_view_hide").show();
                        //alert(objStaffDetail.StaffId);
                        $("#<%= hdnStaffId.ClientID %>").val(objStaffDetail.StaffId);
                        $("#<%= TB_firstname.ClientID %>").val(objStaffDetail.FirstName);
                        $("#<%= TB_surname.ClientID %>").val(objStaffDetail.Surname);
                        $("#<%= TB_Address1.ClientID %>").val(objStaffDetail.Address1);
                        $("#<%= TB_Address2.ClientID %>").val(objStaffDetail.Address2);
                        $("#<%= TB_city.ClientID %>").val(objStaffDetail.City);
                        $("#<%= TB_postcode.ClientID %>").val(objStaffDetail.Postcode);
                        $("#<%= DROP_Country.ClientID %>").val(objStaffDetail.CountryId);
                        if (objStaffDetail.GenderId > 0) {
                            $("#<%= RADIO_Gender.ClientID %> input[value='" + objStaffDetail.GenderId + "']").attr('checked', true);
                        }
                        $("#<%= TB_phone1.ClientID %>").val(objStaffDetail.PhoneNo1);
                        $("#<%= TB_phone2.ClientID %>").val(objStaffDetail.PhoneNo2);
                        $("#<%= TB_Info.ClientID %>").val(objStaffDetail.AddInfo);
                        $("#<%= TB_Password.ClientID %>").val(objStaffDetail.Password);
                        $("#<%= DROP_Role.ClientID %>").val(objStaffDetail.RoleId);
                        var dateSplit = objStaffDetail.DateStarted.split('-');
                        var DateStarted = dateSplit[2] + '-' + dateSplit[1] + '-' + dateSplit[0];
                        $("#<%= TB_Date_Started.ClientID %>").val(DateStarted);
                        var dateSplit = objStaffDetail.DateEnded.split('-');
                        var DateEnded = dateSplit[2] + '-' + dateSplit[1] + '-' + dateSplit[0];
                        $("#<%= TB_Date_Ended.ClientID %>").val(DateEnded);
                        $("#<%= LABEL_Last_Login.ClientID %>").html(objStaffDetail.LastLogin);
                        $("#<%= LABEL_Date_Added.ClientID %>").html(objStaffDetail.DateAdded);
                        $("#<%= LABEL_Last_Updated.ClientID %>").html(objStaffDetail.LastUpdated);
                        $("#<%= LABEL_Username.ClientID %>").html(objStaffDetail.Username);
                        $("#<%= hdnStaffRecStatus.ClientID %>").val(objStaffDetail.RecStatus);
                        if (objStaffDetail.RecStatus == "True") {
                            $("#<%= BUT_Deactivate.ClientID %>").val("DEACTIVATE");
                        }
                        else {
                            $("#<%= BUT_Deactivate.ClientID %>").val("ACTIVATE");
                        }
                    }
                    else {
                        alert("There was a system error. If this error persists please contact technical support.");
                        $("#DIV_staff_view_hide").hide();
                    }
                });
            }
            else {
                $("#DIV_staff_view_hide").hide();
            }
        });

        $("#<%= BUT_Update.ClientID %>").click(function () {
            //alert("Hello");

            var Password = $("#<%= TB_Password.ClientID %>").val();

            if (Password.length < 8) {
                alert("Password must have atleast 8 characters");
                return false;
            }

        });

    </script>

</asp:Content>
