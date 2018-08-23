<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="correspondance.aspx.vb" Inherits="correspondance"  ValidateRequest="false" %>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../ckeditor/ckeditor.js"></script>
    
<style type="text/css">
    .aiLoading::before {
        background-position: 50% 15%;
    }
</style>


<asp:HiddenField ID="hdnAccordianStatus" runat="server" Value="" />

    <h1 class="page-title">Add and View Correspondence</h1>

    <div class="form-input fl">
    <asp:Button ID="BUT_Back_to_Booking" Style="font-size:11px;width:150px;margin-bottom:5%;margin-left:5%;" runat="server" Text="&nbsp;Back to Booking" /> </div>


    <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">

                         
            <table id="booking_tables" border="1">
              
                <tr><th colspan="4" style="height:30px;">Booking Information</th></tr>
                   <tr><td>&nbsp;Booking ID:</td>
                    <td><asp:Label ID="LABEL_Booking_ID" runat="server" Text="&nbsp;Booking ID&nbsp;"></asp:Label></td>
                       <td>&nbsp;Tour:</td>
                    <td><asp:Label ID="LABEL_Tour_and_Stage" runat="server" Text="&nbsp;Tour & Stage #"></asp:Label></td>
                    
                </tr>

                 <tr>
                     <td>&nbsp;Client Name:</td>
                    <td><asp:Label ID="LABEL_Client_Name" runat="server" Text="&nbsp;Client Name"></asp:Label></td>
                       <td>&nbsp;Stage #</td>
                    <td><asp:Label ID="LABEL_Stage" runat="server" Text="&nbsp;Stage #"></asp:Label></td>
               
                </tr>
                  <tr>
                 <td>&nbsp;Total Number in Party:</td>
                    <td><asp:Label ID="LABEL_Total_Number_in_Party" runat="server" Text="&nbsp;Total Number in Party"></asp:Label></td>
                      <td>&nbsp;Total Amount Payable:</td>
                    <td><asp:Label ID="LABEL_Total_Payable" runat="server" Text="&nbsp;Total"></asp:Label></td>
               
</tr>

                   <tr>
                <td>&nbsp;Customised?</td>
                    <td><asp:CheckBox ID="CHK_Customised" enabled="false" style="margin-left:2%;" runat="server" /></td>
                   <td>&nbsp;Total Balance Remaining:</td>
                    <td><asp:Label ID="LABEL_Balance_Remaining" runat="server" Text="&nbsp;Balance"></asp:Label></td></tr>
            </table>
          
</div>
   </section>  
     
    
    	<div class="form has-validation">
              


<ul class="accordion">
			
			<li id="one" class="files" >


				<a href="#one" >View Correspondence</a>
                <ul class="sub-menu">

   
				<div class="form has-validation">


   <div class="clearfix">
                          
                                <div class="form-label">Select Type:</div>
                               
                               
                                <div class="form-input">
                                   
                            <asp:DropDownList ID="DROP_Correspondance_Type" 
                                        style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                        AutoPostBack="True">
                                <asp:ListItem Text="Select Type" Value=""></asp:ListItem>
                                <asp:ListItem Text="Received" Value="Received"></asp:ListItem>
                                <asp:ListItem Text="Sent" Value="Sent"></asp:ListItem>
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>

         
                                        
                                </div>

                            </div>

<div style="overflow-x:auto;">
            <asp:GridView ID="GRID_Correspondance" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
              AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" 
              OnPageIndexChanging="GRID_Correspondance_PageIndexChanging">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" HorizontalAlign="Center" />
                <Columns>
                    <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Date" runat="server" Text='<%# SetDateVal(Eval("datex"))%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Type" runat="server" Text='<%# Eval("CorrespondenceTypeName")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direction">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Direction" runat="server" Text='<%# SetValue(Eval("directionx"))%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Subject" runat="server" Text='<%# Eval("subjectx")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Type">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_EmailType" runat="server" Text='<%# Eval("email_type")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notes">
                        <ItemTemplate>
                            <a href="javascript:;" onclick="javascript: ViewNotes('<%# Eval("id")%>');">Show Text</a>
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
<div id="view_correspondance_popup" runat="server" class="cls_correspondance_notes basic">
<div id='content'>

		<div id='basic-modal'>
   

    		<!-- modal content -->
		<div id="basic-modal-content">

		  <div class="container_12 clearfix leading">
            

 <section class="grid_12">
     <div class="form has-validation">
     <div class="clearfix">
<div class="form-input form-textarea" id="form-textarea">
                              <%--<asp:TextBox ID="TB_Info" TextMode="MultiLine" name="additional_info"  ReadOnly="true" placeholder="Additional Information"></asp:TextBox>   --%>
                              <textarea id="TB_Info" name="TB_Info" class="form-control" rows="5"></textarea>
                              <%--<div id="TB_Info">
                                
                              </div>--%>
   
</div>
     </div>
     </div>

 </section></div>

            
    		<!-- preload the images -->
		<div style='display:none'>
			<img src='../views/img/basic/x.png' alt='' />
		</div>
</div>

</div>
</div>
    </div>


                    </div></ul>
             
			</li>

    <li id="two" class="mail">


				<a href="#two">Correspondence Received</a>
           <ul class="sub-menu">

   
				<div class="form has-validation">

     
                     <div class="clearfix">
                          
                                <div class="form-label">Enter Subject:</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Subject" name="email_subject" placeholder="Subject" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>

                 
             <asp:TextBox ID="TB_Editor" name="TB_Editor" runat="server" Rows="5" 
                TextMode="MultiLine" Width="100%"></asp:TextBox>   

                     




                       <div class="clearfix">
                          
                                <div class="form-label">Date Received:</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Date_Received" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>   
         
                                        
                                </div>

                            </div>


                                           <div class="clearfix">
                          
                                <div class="form-label">How did they contact?</div>
                               
                               
                                <div class="form-input">
                                   
                            <asp:DropDownList ID="DROP_Contact_Method" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server"></asp:DropDownList>

         
                                        
                                </div>

                            </div>

                     <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Add_Communication" runat="server" Text="Add Communication" /> 

                    </div>
                        

 </div> 
                       
</ul>
                 
			</li>

 <div id="DIV_send_correspondance_clients" runat="server">
<li id="three" class="additional_people" >


				<a href="#three">CLIENTS - Send Correspondence</a>


    <ul class="sub-menu">

   
				<div class="form has-validation">
                            


                            <div class="clearfix">
                                <div class="form-label">Enter Subject:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Subject2" name="email_subject" placeholder="Subject" runat="server"></asp:TextBox>   
                                </div>
                            </div>

                            <div class="clearfix">
                                <div class="form-label">Email Address:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Address2" name="email_address" placeholder="Email Address" runat="server" ReadOnly="true"></asp:TextBox>   
                                </div>
                            </div>

                            <div class="clearfix">
                                 <div class="form-label">Select Email to Send</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Correspondance" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                      <asp:ListItem Value="">Select Correspondence</asp:ListItem>
                                      <asp:ListItem Value="1.html">Customised Reply</asp:ListItem>
                                      <asp:ListItem Value="2.html">Fixed Price Reply</asp:ListItem>
                                      <asp:ListItem Value="3.html">Customised Confirmation</asp:ListItem>
                                      <asp:ListItem Value="4.html">Fixed Price Confirmation</asp:ListItem>
                                      <asp:ListItem Value="5.html">Send Invoice Letter</asp:ListItem>
                                      <asp:ListItem Value="6.html">Thank you for Full Payment</asp:ListItem>
                                      <asp:ListItem Value="7.html">UK URL</asp:ListItem>
                                      <asp:ListItem Value="8.html" style="display:none">No Overnight in Milngavie</asp:ListItem>
                                      <asp:ListItem Value="9.html">Follow Up Email on Walk Completion</asp:ListItem>
                                      <asp:ListItem Value="10.html">Online Evaluation - Thank You</asp:ListItem>
                                      <asp:ListItem Value="15.html">Customer Cancellation Receipt Letter</asp:ListItem>
                                      <asp:ListItem Value="16.html">C/C Details Request to Hold Room</asp:ListItem> 
                                      <asp:ListItem Value="18.html">Received Changed Booking</asp:ListItem>
                                      <asp:ListItem Value="19.html">Changed Booking - Successful</asp:ListItem>
                                      <asp:ListItem Value="20.html">Changed Booking - Unsuccessful</asp:ListItem>
                                      <asp:ListItem Value="21.html">Deposit Received</asp:ListItem>
                                  
                                  </asp:DropDownList>
                                 <asp:HiddenField runat="server"  id="HiddenField1" Value="" />
                          </div>

                     </div>


                          <asp:TextBox ID="TB_Editor2" name="TB_Editor2" runat="server" Rows="5" 
                TextMode="MultiLine" Width="100%"></asp:TextBox>   





                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Send" runat="server" Text="Send Email" /> 

                    </div>

                    </div>
                    </ul>
             </li>

    </div>

     <div id="DIV_send_correspondance_agents" runat="server">
    <li id="four" class="additional_extras" >

   
				<a href="#four">AGENTS - Send Correspondence</a>


    <ul class="sub-menu">

   
				<div class="form has-validation">


                            <div class="clearfix">
                                <div class="form-label">Enter Subject:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Subject4" name="email_subject" placeholder="Subject" runat="server"></asp:TextBox>   
                                </div>
                            </div>

                            <div class="clearfix">
                                <div class="form-label">Email Address:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Address4" name="email_address" placeholder="Email Address" runat="server" ReadOnly="true"></asp:TextBox>   
                                </div>
                            </div>

                            <div class="clearfix">
                                 <div class="form-label">Select Email</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Correspondance_Agent" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                       <asp:ListItem Value="">Select Correspondence</asp:ListItem>
                                      <asp:ListItem Value="17.html">Confirmation to Agent</asp:ListItem>
                                      <asp:ListItem Value="28.html">Agent UK URL</asp:ListItem>
                                    
                                  
                                  </asp:DropDownList>
                                 <asp:HiddenField runat="server"  id="HiddenField3" Value="" />
                          </div>

                     </div>


                          <asp:TextBox ID="TB_Editor4" name="TB_Editor4" runat="server" Rows="5" 
                TextMode="MultiLine" Width="100%"></asp:TextBox>   





                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Send3" runat="server" Text="Send Email" /> 

                    </div>

                    </div>
                    </ul>
           
          </li>
     </div>
    </ul>

         
</div>

<script type="text/javascript">

    $(document).ready(function () {
        var AccordianStatus = $("#<%= hdnAccordianStatus.ClientID %>").val();
        if (AccordianStatus != "") {
            //alert(AccordianStatus);
            parent.location.hash = AccordianStatus;
        }
    });

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

    CKEDITOR.replace('<%= TB_Editor2.ClientID %>', {
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

    CKEDITOR.replace('<%= TB_Editor4.ClientID %>', {
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

    /*CKEDITOR.replace('TB_Info', {
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
    });*/
    
    function ViewNotes(BookingCorrespondenceId) {
        //alert("BookingCorrespondenceId = " + BookingCorrespondenceId);
        //alert("AccomRoomtypeId = " + AccomRoomtypeId);
        $('#<%= view_correspondance_popup.ClientID %>').modal();
        $('#basic-modal-content').css("display", "block");
        //$("#TB_Info").val("");

        var doaction = "getBookingCorrespondenceNoteById";

        $(document).ajaxStart(function () {
            $(".cls_correspondance_notes").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_correspondance_notes").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, BookingCorrespondenceId: BookingCorrespondenceId }, function (responseText) {
            //alert(responseText.toString());
            //if (responseText.toString() != "") {
                //$("#TB_Info.ClientID").val($(responseText).text());
                //$("#TB_Info").val(responseText.replace(/<[^>]*>/g, ''));

                $("#TB_Info").val(responseText);

                if (CKEDITOR.instances.TB_Info) {
                    CKEDITOR.remove(CKEDITOR.instances.TB_Info);
                }

                CKEDITOR.replace('TB_Info', {
                    // Define the toolbar groups as it is a more accessible solution.
                    toolbarGroups: [
			            { "name": "basicstyles", "groups": ["basicstyles"] },
			            { "name": "links", "groups": ["links"] },
			            { "name": "paragraph", "groups": ["list", "blocks"] },
			            { "name": "document", "groups": ["mode"] },
			            { "name": "insert", "groups": ["insert"] },
			            { "name": "styles", "groups": ["styles"] }
                    //{"name":"about","groups":["about"]}
		            ],
                    // Remove the redundant buttons from toolbar groups defined above.
                    //removeButtons: 'Bold,Italic,Format,Size,Underline,Strike,Subscript,Superscript,Anchor,Styles,Specialchar,Save,Print,Font,Link,Unlink,Source,Preview,Image,Flash,Table,Smiley,Iframe,FontSize,NewPage,NumberedList,BulletedList,Blockquote,CreateDiv,HorizontalRule,SpecialChar,PageBreak'
                    removeButtons: 'Format,Size,Underline,Strike,Subscript,Superscript,Anchor,Styles,Specialchar,Save,Print,Font,Unlink,Source,Preview,Flash,Smiley,Iframe,FontSize,NewPage,NumberedList,BulletedList,Blockquote,CreateDiv,HorizontalRule,SpecialChar,PageBreak'
                });
                CKEDITOR.instances.TB_Info.config.readOnly = true;
            //}
        });
    }
</script>

</asp:Content>
