<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="correspondance.aspx.vb" Inherits="correspondance"  ValidateRequest="false" %>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../ckeditor/ckeditor.js"></script>
    
<style type="text/css">
    .aiLoading::before {
        background-position: 50% 15%;
    }
</style>




    <h1 class="page-title">Correspondance Test</h1>

  
    
    	<div class="form has-validation">

      <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Correspondance Test</th>
						
					</tr>
				</thead>
            </table>
           </div>                   
               <div class="clearfix">
                                 <div class="form-label">Select Correspondance</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Correspondance" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                      <asp:ListItem Value="">Select Correspondance</asp:ListItem>
                                      <asp:ListItem Value="1.html">Customised Reply</asp:ListItem>
                                      <asp:ListItem Value="2.html">Fixed Price Reply</asp:ListItem>
                                      <asp:ListItem Value="3.html">Customised Confirmation</asp:ListItem>
                                      <asp:ListItem Value="4.html">Fixed Price Confirmation</asp:ListItem>
                                      <asp:ListItem Value="5.html">Previously Invoiced Clients Email</asp:ListItem>
                                      <asp:ListItem Value="6.html">Thanks for Payment - Full Payment</asp:ListItem>
                                      <asp:ListItem Value="7.html">UK URL</asp:ListItem>
                                      <asp:ListItem Value="8.html">No Overnight in Milngavie</asp:ListItem>
                                      <asp:ListItem Value="9.html">Follow Up Email on Walk Completion</asp:ListItem>
                                      <asp:ListItem Value="10.html">Online Evaluation - Thank You</asp:ListItem>
                                      <asp:ListItem Value="11.html">To Supplier - Accom Booking General</asp:ListItem>
                                      <asp:ListItem Value="12.html">To Supplier - Accom Booking after Phone Call</asp:ListItem>
                                      <asp:ListItem Value="13.html">Send Booking Confirmation to Supplier</asp:ListItem>
                                      <asp:ListItem Value="14.html">Send Booking Cancellation to Supplier</asp:ListItem>
                                      <asp:ListItem Value="15.html">Customer Cancellation Receipt Letter</asp:ListItem>
                                      <asp:ListItem Value="16.html">C/C Details Request to Hold Room</asp:ListItem> 
                                      <asp:ListItem Value="17.html">Confirmation to Agent</asp:ListItem>
                                      
                                      <asp:ListItem Value="18.html">Receive Changed Booking</asp:ListItem>
                                      <asp:ListItem Value="19.html">Confirm Changed Booking to Customer - Successful</asp:ListItem>
                                      <asp:ListItem Value="20.html">Confirm Changed Booking to Customer - NOT Successful</asp:ListItem>
                                      <asp:ListItem Value="21.html">Deposit Received</asp:ListItem>
                                  
                                  </asp:DropDownList>
                                 <asp:HiddenField runat="server"  id="hdnAgentId" Value="" />
                          </div>

                     </div>
          

               
                    
                            <div class="clearfix">
                          
                                <div class="form-label">Name of Client</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_name" name="name" required="required" placeholder="Name" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>



                            <div class="clearfix">

                                  <div class="form-label">Email to Send To</div>


                                <div class="form-input">
                              <asp:TextBox ID="TB_email" name="email" required="required" placeholder="Email Address" runat="server"></asp:TextBox>   
                                   

                            </div> </div>                             

                       
               
             <div class="clearfix">
             <div class="form-label"></div>

                          <div class="form-action clearfix">
                                <asp:Button ID="BUT_Show_Email"   class="fr"  runat="server" Text="Show Email" />
                              

                            </div>
                <div class="form-action clearfix">
                                <asp:Button ID="BUT_Send_Email"  class="fr"  runat="server" Text="Send Email" />
                               

                            </div>
             </div>

             <%--<textarea rows="5" name="txtDescription" id="editor" class="form-control" ></textarea>--%>
             <asp:TextBox ID="TB_Editor" name="editor" runat="server" Rows="5" 
                TextMode="MultiLine" Width="100%"></asp:TextBox>   

            </div>

            <script type="text/javascript">
                CKEDITOR.replace('<%= TB_Editor.ClientID %>', {
                    // Define the toolbar groups as it is a more accessible solution.
                    toolbarGroups: [
			            { "name": "basicstyles", "groups": ["basicstyles"] },
			            { "name": "links", "groups": ["links"] },
			            { "name": "paragraph", "groups": ["list", "blocks"] },
			            { "name": "document", "groups": ["mode"] },
			            { "name": "insert", "groups": ["insert"] },
			            { "name": "styles", "groups": ["styles"] },
                                //{"name":"about","groups":["about"]}
		            ],
                    // Remove the redundant buttons from toolbar groups defined above.
                    removeButtons: 'Underline,Strike,Subscript,Superscript,Anchor,Styles,Specialchar,Save,Print,Font'
                });

            </script>

</asp:Content>
