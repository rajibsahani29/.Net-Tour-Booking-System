<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="correspondance_system.aspx.vb" Inherits="correspondance_system"  ValidateRequest="false" %>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../ckeditor/ckeditor.js"></script>

    <h1 class="page-title">System Level Correspondance</h1>

    
  <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
     
    
    	<div class="form has-validation">

                            <div class="clearfix">
                                <div class="form-label">Supplier/Agent:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Supplier_Agent" name="supplier_agent" placeholder="Name of Supplier / Agent" ReadOnly="true" runat="server"></asp:TextBox>   
                                </div>
                            </div>
                            <div class="clearfix">
                                <div class="form-label">Email Address:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Address" name="email_address" placeholder="Email Address of Supplier / Agent" ReadOnly="true" runat="server"></asp:TextBox>   
                                </div>
                            </div>
                            <div class="clearfix">
                                <div class="form-label">Enter Subject:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Subject" name="email_subject" placeholder="Subject" runat="server"></asp:TextBox>   
                                </div>
                            </div>

                          <asp:TextBox ID="TB_Editor" name="editor" runat="server" Rows="5" 
                TextMode="MultiLine" Width="100%"></asp:TextBox>   

                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Send" runat="server" Text="Send Email" /> 

                    </div>

                    </div>
                  
         
</div>
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
