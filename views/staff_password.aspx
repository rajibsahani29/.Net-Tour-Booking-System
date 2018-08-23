<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="staff_password.aspx.vb" Inherits="staff_password"  ValidateRequest="false"%>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div id="theme_dropdown" class="theme_dropdown">
       
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
 


    <h1 class="page-title">Update Password</h1>

  
      <div class="container_12 clearfix leading">

             
      <div class="grid_12">
                        


   

                     
     	  <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Update Password</th>
						
					</tr>
				</thead>
            </table>
           </div> 
                     

                   <div class="clearfix">

                                <asp:Label ID="LABEL_Current_Password" class="form-label" runat="server" Text="Current Password" ></asp:Label>

                            <div class="form-input">
                            <asp:TextBox ID="TB_Current_Password" class="full"  TextMode="Password" runat="server"  placeholder="Current Password" name="password" required="required"></asp:TextBox>
                         
                               </div></div>

                     <div class="clearfix">

                                <asp:Label ID="LABEL_New_Password" class="form-label" runat="server" Text="New Password" ></asp:Label>

                            <div class="form-input">
                            <asp:TextBox ID="TB_New_Password" class="full"  TextMode="Password" runat="server"  placeholder="New Password" name="password" required="required"></asp:TextBox>
                         
                               </div></div>

                      <div class="clearfix">

                                <asp:Label ID="LABEL_Repeat_Password" class="form-label" runat="server" Text="Repeat New Password" ></asp:Label>

                            <div class="form-input">
                            <asp:TextBox ID="TB_Repeat_Password" class="full"  TextMode="Password" runat="server"  placeholder="Repeat New Password" name="password" required="required"></asp:TextBox>
                         
                               </div></div>
              <p class="clearfix ac">
                        <span style="line-height: 23px; font-size:14px;color:red;">
                            <%--Password is incorrect.--%>
                             <asp:Label ID="LABEL_Password_Error" runat="server"  Text="" ></asp:Label>  

                              
                            
                        </span> 
						    <div class="form-action clearfix">
     
                        <asp:Button ID="BUT_Change_Password" runat="server" class="fr" type="submit" Text="Change My Password" />
                      </div> 
		    
       </div></div></div>
       
       <script type="text/javascript">
           
           $("#<%= BUT_Change_Password.ClientID %>").click(function () {
               //alert("Hello");

               var NewPassword = $("#<%= TB_New_Password.ClientID %>").val();
               var RepeatPassword = $("#<%= TB_Repeat_Password.ClientID %>").val();

               if (NewPassword.length < 8) {
                   $("#<%= LABEL_Password_Error.ClientID %>").html("New password must have atleast 8 characters");
                   return false;
               }

               if (NewPassword != null && RepeatPassword != null) {
                   if (NewPassword != "" && RepeatPassword != "") {
                       if (NewPassword != RepeatPassword) {
                           $("#<%= LABEL_Password_Error.ClientID %>").html("New Password & Repeat Password do not match.");
                           return false;
                       }
                   }
               }
           });

       </script>   

</asp:Content>