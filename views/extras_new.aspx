<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="extras_new.aspx.vb" Inherits="extras_new"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
<div id="theme_dropdown" class=" theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                                          <li class="no_colour">
                                    <a  href="extras_new_type.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Extra Type of Service">Add New Extra Type of Service</a> 
                               </li> 
                                <li class="no_colour">
                                    <a  href="extras_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Extra Supplier/Service">Add New Extra Supplier/Service</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="extras_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View & Edit Extra Supplier/Service">View & Edit Extra Supplier/Service</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="extras_link.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit to a Route-Stage">Add & Edit Extras Link to Route-Stage</a> 
                               </li> 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 


    <h1 class="page-title">Add New Extra Supplier/Service</h1>

  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    

   

                     
     	<div class="form has-validation">

                     
            
   <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add New Extra Supplier/Service</th>
						
					</tr>
				</thead>
            </table>
           </div> 
              

              <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT_Add_Extra_Supplier_Service">
                    
                            <div class="clearfix">
                          
                                <div class="form-label">Name</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_name" name="name" required="required" placeholder="Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

             
                            <div class="clearfix">
                          
                                <div class="form-label">Type</div>
                               
                               
                                <div class="form-input">
                                    <asp:DropDownList ID="DROP_Service_Type"  style="font-size:18px; margin-top:2%;margin-left:2%;"  runat="server"></asp:DropDownList>
         
                                        
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

                                  <div class="form-label">Website Link</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Website" name="website" required="required" placeholder="Website Link" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>                

                            <div class="clearfix">

                                  <div class="form-label">Phone Number</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_phone1" name="phone1" required="required" placeholder="Main Phone Number" runat="server"></asp:TextBox>   
                                   

                            </div> </div>




                                <div class="clearfix">

                                <div class="form-label">Maximum Number</div>

                              <div class="form-input">
                              <asp:TextBox ID="TB_Maximum_Number" name="maximum_number"  placeholder="Maximum Number (optional)" runat="server"></asp:TextBox>
                         

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

                  <div class="clearfix">
                             <div class="form-label">Google Doc Link</div>
                              
                                  <div class="form-input">
                                    <asp:TextBox ID="TB_Extras_Google_Link" name="extras_google_link" placeholder="Enter Google Doc Link" runat="server"></asp:TextBox>   

                          </div> </div>

                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Extra_Supplier_Service"   class="fr"  runat="server" Text="Add New Extra Supplier/Service" />
                              

                            </div>

                </asp:Panel>

                        </div>   	

          

           

		    
       </div></div>
       

</asp:Content>
