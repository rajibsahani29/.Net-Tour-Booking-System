<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="extras_baggage_new.aspx.vb" Inherits="extras_baggage_new"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
<div id="theme_dropdown" class=" theme_dropdown">
       
                                        <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;"> 
                                                         
                                <li class="no_colour">
                                    <a  href="extras_baggage_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add New Baggage Supplier/Service">Add New Baggage Supplier/Service</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="extras_baggage_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View & Edit Baggage Supplier/Service">View & Edit Baggage Supplier/Service</a> 
                               </li> 

                                   <li class="no_colour">
                                    <a  href="extras_baggage_link.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Baggage to a Route-Stage">Add & Edit Baggage Link to Route</a> 
                               </li> 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 


    <h1 class="page-title">Add New Baggage Supplier/Service</h1>

  
    

      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                        
                        
    

   

                     
     	<div class="form has-validation">

                     
            
   <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add New Baggage Supplier/Service</th>
						
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
                   <div class="form-label">Mobile Phone</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Mobile_Phone" name="mobile_phone"  placeholder="Mobile Phone Number" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

                                <div class="clearfix">

                                  <div class="form-label">Open From</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Open_From" name="open_from"  placeholder="Open From" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

              <div class="clearfix">

                                  <div class="form-label">Open To</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_Open_To" name="open_to" placeholder="Open To" runat="server" value=""></asp:TextBox>   
                                   

                            </div> </div>

                                <div class="clearfix">

                                <div class="form-label">Number of Transfers</div>

                              <div class="form-input">
                              <asp:TextBox ID="TB_No_of_Stages" name="no_of_stages"  placeholder="Number of Transfers" runat="server"></asp:TextBox>
                         

                            </div> </div>

                  <div class="clearfix">

                                <div class="form-label">Maximum Weight</div>

                              <div class="form-input">
                              <asp:TextBox ID="TB_Max_no_of_Bags" name="max-bags"  placeholder="Maximum Weight" runat="server"></asp:TextBox>
                         

                            </div> </div>

                  <div class="clearfix">

                                <div class="form-label">Price per Bag</div>

                              <div class="form-input">
                              <asp:TextBox ID="TB_Price_per_Bag" name="price_bag"  placeholder="Price per Bag" runat="server"></asp:TextBox>
                         

                            </div> </div>



                  
                                <div class="clearfix">

                                <div class="form-label">Instructions for Booking Confirmation 1</div>

                                <div class="form-input form-textarea" id="form-textarea2">
                              <asp:TextBox ID="TB_Instructions_1" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

                            </div> </div>


                  
                                <div class="clearfix">

                                <div class="form-label">Instructions for Booking Confirmation 2</div>

                                <div class="form-input form-textarea" id="form-textarea3">
                              <asp:TextBox ID="TB_Instructions_2" TextMode="MultiLine" name="additional_info" rows="5" placeholder="Additional Information" runat="server"></asp:TextBox>   

                         

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
                             <div class="form-label">Internal Google Doc Link</div>
                              
                                  <div class="form-input">
                                    <asp:TextBox ID="TB_Extras_Google_Link" name="extras_google_link" placeholder="Enter Internal Google Doc Link" runat="server"></asp:TextBox>   

                          </div> </div>

                  <div class="clearfix">
                             <div class="form-label">External Google Doc Link</div>
                              
                                  <div class="form-input">
                                    <asp:TextBox ID="TB_Extras_External_Google_Link" name="extras_external_google_link" placeholder="Enter External Google Doc Link" runat="server"></asp:TextBox>   

                          </div> </div>

                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Extra_Supplier_Service"   class="fr"  runat="server" Text="Add New Extra Supplier/Service" />
                              

                            </div>

                </asp:Panel>

                        </div>   	

          

           

		    
       </div></div>
       

</asp:Content>
