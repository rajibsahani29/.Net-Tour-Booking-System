<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="staff_new.aspx.vb" Inherits="staff_new"  ValidateRequest="false" %>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
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
    

 


    <h1 class="page-title">Add New Staff</h1>

  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    

   

                 
<div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add New Staff</th>
						
					</tr>
				</thead>
            </table>
           </div> 
              

                     
            

              


                    
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
                                  <asp:DropDownList ID="DROP_Country" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                    
                                  </asp:DropDownList>

                          </div> </div>

                                    <div class="clearfix">
                                  <div class="form-label">Gender</div>
                              
                                   <div class="form-input"  >

                                
                          <asp:RadioButtonList ID="RADIO_Gender"  class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server"> 
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
                              <asp:TextBox ID="TB_phone2" name="phone2"  placeholder="Secondary Phone Number" autocomplete="off" runat="server"></asp:TextBox>   
                                   

                            </div> </div>


                                <div class="clearfix">

                                <div class="form-label">Additional Information</div>

                                <div class="form-input form-textarea" id="form-textarea">
                              <asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>


                                <div class="clearfix">

                                 <div class="form-label">Password</div>
                            <div class="form-input">
                            <asp:TextBox ID="TB_Password" class="full" runat="server"  placeholder="Password" 
                                    name="password" autocomplete="off" required="required" TextMode="Password"></asp:TextBox>
                         
                               </div></div>



                              <div class="clearfix">
                                   <div class="form-label">Role</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Role" style="font-size:18px; margin-top:2%;margin-left:2%;" required="required" runat="server">
                                  </asp:DropDownList>

                          </div> </div>


                                    <div class="clearfix">
                            <div class="form-label">Date Started</div>
                             <div class="form-input" >
                         
                                 <asp:TextBox ID="TB_Date_Started" class="date" type="date" name="date" placeholder="mm/dd/yyyy" required="required"  runat="server"></asp:TextBox>
                             
                              

                            </div></div>

                            <div class="form-action clearfix">
                               
                               <asp:Button ID="BUT_Add_Staff"   class="fr"  runat="server" Text="Add New Staff Member" />
                              
                            </div>

                        </div>   	

          

           

		    
       </div></div>
       
       <script type="text/javascript">

           $("#<%= BUT_Add_Staff.ClientID %>").click(function () {
               //alert("Hello");

               var Password = $("#<%= TB_Password.ClientID %>").val();

               if (Password.length < 8) {
                   alert("Password must have atleast 8 characters");
                   return false;
               }

           });

       </script>

</asp:Content>
