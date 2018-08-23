<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="agents_view.aspx.vb" Inherits="agents_view"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<style type="text/css">
    .aiLoading::before {
        background-position: 50% 15%;
    }
</style>

<div id="theme_dropdown" class=" theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="agents_new.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Add Agent">Add Agent</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="agents_view.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="View & Edit Agent">View & Edit Agent</a> 
                               </li> 

                                  <li class="no_colour">
                                    <a  href="agent_photos.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Add & Edit Agent Logo">Add & Edit Agent Logo</a> 
                               </li> 

                                 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 


    <h1 class="page-title">View & Edit Agent</h1>

  
    
    	<div class="form has-validation">

      <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Agent</th>
						
					</tr>
				</thead>
            </table>
           </div>                   
               <div class="clearfix">
                                 <div class="form-label">Select Agent</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Agent_Name" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                 <asp:HiddenField runat="server"  id="hdnAgentId" Value="" />
                          </div>

                     </div>
            </div>

                <div id="DIV_agents_view_hide" class="agents_view_hide" style="display:none;">

              
     	<div class="form has-validation">

           <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Edit Agent</th>
						
					</tr>
				</thead>
            </table>
           </div>             

           <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Update">
                    
                            <div class="clearfix">
                          
                                <div class="form-label">Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_name" name="name" required="required" placeholder="Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                                                          <div class="clearfix">
                          
                                <div class="form-label">Buy From?</div>
                               
                               
                                <div class="form-input">
                                 
                                    <asp:CheckBox ID="CHK_Buy_From" style="margin-left:2%;" runat="server" />
                                        
                                </div>

                            </div>



                         
                          <div class="clearfix" style="display:none">

                                <div class="form-label">Contact Name</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_contact_name" name="contact_name" required="required" placeholder="Contact Name" runat="server">N/A</asp:TextBox>   


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

                                  <div class="form-label">Bank Charge</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Agent_Bank_Charge" name="agent_bank_charge"  placeholder="Bank Charge if applicable" runat="server"></asp:TextBox>   
                                   

                            </div> </div>

             
                <div class="clearfix">

                                <div class="form-label">Additional Information</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>



                <div class="clearfix">
                          
                                <div class="form-label">Contact Name Correspondence</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact1" class="CLS_Agent_Contact1" name="name"  placeholder="Name" runat="server"></asp:TextBox>   
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name 1 Job Title</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact1_Job_Title" class="CLS_Agent_Contact1_Job_Title" name="contact1_job_title" placeholder="Job Title" runat="server"></asp:TextBox>   


                                </div></div>



                                <div class="clearfix">
                          
                                <div class="form-label">Contact Name Correspondence Email</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact1_Email" class="CLS_Agent_Contact1_Email" name="contact1_email"  placeholder="Email" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name 1 Phone </div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact1_Phone" class="CLS_Agent_Contact1_Phone" name="contact1_phone" placeholder="Phone Number" runat="server"></asp:TextBox>   


                                </div> </div>

                <div class="clearfix">
                          
                                <div class="form-label">Contact Name Invoice</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact2" class="CLS_Agent_Contact2" name="name"  placeholder="Name" runat="server"></asp:TextBox>   
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name 2 Job Title</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact2_Job_Title" class="CLS_Agent_Contact2_Job_Title" name="contact2_job_title" placeholder="Job Title" runat="server"></asp:TextBox>   


                                </div></div>



                                <div class="clearfix">
                          
                                <div class="form-label">Contact Name Invoice Email</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact2_Email" class="CLS_Agent_Contact2_Email" name="contact2_email"  placeholder="Email" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name 2 Phone </div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact2_Phone" class="CLS_Agent_Contact2_Phone" name="contact2_phone" placeholder="Phone Number" runat="server"></asp:TextBox>   


                                </div> </div>

                             <div class="clearfix">
                          
                                <div class="form-label">Contact Name 3</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact3" class="CLS_Agent_Contact3" name="name"  placeholder="Name" runat="server"></asp:TextBox>   
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name 3 Job Title</div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact3_Job_Title" class="CLS_Agent_Contact3_Job_Title" name="contact2_job_title" placeholder="Job Title" runat="server"></asp:TextBox>   


                                </div></div>



                                <div class="clearfix">
                          
                                <div class="form-label">Contact Name 3 Email</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact3_Email" class="CLS_Agent_Contact3_Email" name="contact3_email"  placeholder="Email" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                          <div class="clearfix">

                                <div class="form-label">Contact Name 3 Phone </div>


                                <div class="form-input">
                                    <asp:TextBox ID="TB_Agent_Contact3_Phone" class="CLS_Agent_Contact3_Phone" name="contact3_phone" placeholder="Phone Number" runat="server"></asp:TextBox>   


                                </div> </div>



                                  <div class="clearfix">
                         <div class="form-label">Date Created</div>

                             <div class="form-input" >
                         
                               <asp:Label ID="LABEL_Date_Created" runat="server" class="form-label" Text=""></asp:Label>
                             
                              

                            </div></div>

                           <div class="clearfix">
                           <div class="form-label">Last Updated</div>


                             <div class="form-input" >
                         
                                <asp:Label ID="LABEL_Last_Updated" runat="server" class="form-label" Text=""></asp:Label>
                              

                            </div></div>
               
             <div class="clearfix">
             <div class="form-label"></div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_Update" UseSubmitBehavior="true" class="fr"  runat="server" Text="Update" />
                            </div>
                      <div class="form-action clearfix">
                                <asp:Button ID="BUT_Cancel" class="fr"  runat="server" Text="Cancel" />
                            </div>
                        <div class="form-action clearfix">
                                <asp:Button ID="BUT_Archive" class="fr"  runat="server" Text="Archive" />
                            </div>
                 </div>


              </asp:Panel>

                        </div>   	

                    
                        

          </div>

   <script type="text/javascript">
       $("#<%= DROP_Agent_Name.ClientID %>").change(function () {
           //alert("Hello");
           var agentId = $("#<%= DROP_Agent_Name.ClientID %>").val();
           //alert(extraId);
           if (agentId != "" && agentId > 0) {

               var doaction = "getAgentDetail";

               $(document).ajaxStart(function () {
                   $(".agents_view_hide").addClass("aiLoading");
               });
               $(document).ajaxComplete(function () {
                   $(".agents_view_hide").removeClass("aiLoading");
                   $(document).unbind("ajaxStart ajaxStop");
               });
               $.post('GetAjaxData.aspx', { DoAction: doaction, AgentId: agentId }, function (responseText) {
                   //alert(responseText.toString());
                   if (responseText.toString() != "Error") {
                       var objExtraDetail = JSON.parse(responseText)
                       $("#DIV_agents_view_hide").show();
                       //alert(objExtraDetail.StaffId);
                       $("#<%= hdnAgentId.ClientID %>").val(objExtraDetail.AgentId);
                       $("#<%= TB_name.ClientID %>").val(objExtraDetail.Name);
                       $("#<%= TB_contact_name.ClientID %>").val(objExtraDetail.ContactName);
                       $("#<%= TB_Address1.ClientID %>").val(objExtraDetail.Address1);
                       $("#<%= TB_Address2.ClientID %>").val(objExtraDetail.Address2);
                       $("#<%= TB_city.ClientID %>").val(objExtraDetail.City);
                       $("#<%= TB_postcode.ClientID %>").val(objExtraDetail.Postcode);
                       $("#<%= TB_email.ClientID %>").val(objExtraDetail.Email);
                       $("#<%= TB_phone1.ClientID %>").val(objExtraDetail.Phone);
                       $("#<%= DROP_Country.ClientID %>").val(objExtraDetail.CountryId);
                       $("#<%= TB_Info.ClientID %>").val(objExtraDetail.AddiInfo);
                       $("#<%= LABEL_Date_Created.ClientID %>").html(objExtraDetail.DateCreated);
                       $("#<%= LABEL_Last_Updated.ClientID %>").html(objExtraDetail.LastUpdated);
                       $("#<%= TB_Agent_Bank_Charge.ClientID %>").val(objExtraDetail.BankCharge);
                       if (objExtraDetail.Buyx == "True") {
                           $('#<%= CHK_Buy_From.ClientID %>').prop('checked', true);
                       }
                       else {
                           $('#<%= CHK_Buy_From.ClientID %>').prop('checked', false);
                       }

                       GetAgentContactDetail(objExtraDetail.AgentId)
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
       });

        function GetAgentContactDetail(agentId) {
            //alert(accomId);
            var doaction = "getAgentContactDetail";

            $(document).ajaxStart(function () {
                $(".agents_view_hide").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".agents_view_hide").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AgentId: agentId }, function (responseText) {
                //alert(responseText.toString());
                if (responseText.toString() != "") {
                    $("*[class^='CLS_Agent_Contact']").val("");
                    var ResponseRow = responseText.split("rowSplit");
                    for (i = 0; i < ResponseRow.length - 1; i++) {
                        var ResponseCol = ResponseRow[i].split("colSplit");
                        //var index = i + 1;
                        var index = parseInt(ResponseCol[4]);
                        $(".CLS_Agent_Contact" + index).val(ResponseCol[0]);
                        $(".CLS_Agent_Contact" + index + "_Job_Title").val(ResponseCol[1]);
                        $(".CLS_Agent_Contact" + index + "_Email").val(ResponseCol[2]);
                        $(".CLS_Agent_Contact" + index + "_Phone").val(ResponseCol[3]);
                    }
                }
            });
        }

    </script>

</asp:Content>
