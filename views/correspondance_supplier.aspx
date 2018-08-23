<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="correspondance_supplier.aspx.vb" Inherits="correspondance_supplier"  ValidateRequest="false" %>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../ckeditor/ckeditor.js"></script>
    
<style type="text/css">
    .aiLoading::before {
        background-position: 50% 15%;
    }
</style>


<asp:HiddenField ID="hdnAccordianStatus" runat="server" Value="" />
<asp:HiddenField ID="hdnAccomId" runat="server" Value="" />
<asp:HiddenField ID="hdnAccomDropdownId" runat="server" Value="" />
<asp:HiddenField ID="hdnExtraId" runat="server" Value="" />
<asp:HiddenField ID="hdnBaggageExtraId" runat="server" Value="" />

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



<div style="overflow-x:auto;">
            <asp:GridView ID="GRID_Correspondance_Supplier" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
              AllowPaging="true" PageSize="2000" AutoGenerateColumns="false" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" >
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
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Direction" runat="server" Text='<%# Eval("SupplierName")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:Label ID="LABEL_Subject" runat="server" Text='<%# Eval("subjectx")%>'/>
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


				<a href="#two">SUPPLIERS - Send Correspondence</a>
           <ul class="sub-menu">
   
				<div class="form has-validation">

               <div class="clearfix">
                                <div class="form-label">Select Accommodation:</div>
                               
                               
                                <div class="form-input">
                              
          <asp:DropDownList ID="DROP_Accommodation" 
                                        style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                        AutoPostBack="True">
                               
                            </asp:DropDownList>
                                        
                                </div></div>

                                   <div class="clearfix">
                                <div class="form-label">OR Select Extras Supplier:</div>
                               
                               
                                <div class="form-input">
                                   
             <asp:DropDownList ID="DROP_Extras_Supplier" 
                                        style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                        AutoPostBack="True">
                               
                            </asp:DropDownList>
                                        
                                </div></div>

                     <div class="clearfix">
                                <div class="form-label">OR Select Baggage Supplier:</div>
                               
                               
                                <div class="form-input">
                                   
             <asp:DropDownList ID="DROP_Baggage_Supplier" 
                                        style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                        AutoPostBack="True">
                               
                            </asp:DropDownList>
                                        
                                </div></div>


               <div class="clearfix">
                                <div class="form-label">Enter Subject:</div>
                               
                               
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Subject" name="email_subject" placeholder="Subject" runat="server"></asp:TextBox>   
         
                                        
                                </div></div>

                            <div class="clearfix">
                                <div class="form-label">Email Address:</div>
                                <div class="form-input">
                                    <asp:TextBox ID="TB_Email_Address" name="email_address" placeholder="Email Address" runat="server" ReadOnly="true"></asp:TextBox>   
                                </div>
                            </div>

                            <div class="clearfix">
                                 <div class="form-label">Select Email</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Correspondance_Supplier" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                      <asp:ListItem Value="">Select Correspondence</asp:ListItem>
                                      <%--<asp:ListItem Value="11.html">To Supplier - Accom Booking General</asp:ListItem>
                                      <asp:ListItem Value="12.html">To Supplier - Accom Booking after Phone Call</asp:ListItem>
                                      <asp:ListItem Value="13.html">Send Booking Confirmation to Supplier</asp:ListItem>
                                      <asp:ListItem Value="14.html">Send Booking Cancellation to Supplier</asp:ListItem>
                                      <asp:ListItem Value="22.html">Email Taxi Company - Individual Booking</asp:ListItem>
                                      <asp:ListItem Value="24.html">Email Baggage Company - Individual Booking</asp:ListItem>--%>
            
              
                                  
                                  </asp:DropDownList>
                                 <asp:HiddenField runat="server"  id="HiddenField2" Value="" />
                          </div>

                     </div>


                          <asp:TextBox ID="TB_Editor" name="editor" runat="server" Rows="5" 
                TextMode="MultiLine" Width="100%"></asp:TextBox>   





                    <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT_Send" runat="server" Text="Send Email" /> 

                    </div>

                    </div>
                    </ul>
             
			</li>


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

    $("#<%= DROP_Accommodation.ClientID %>").change(function () {
        var AccomId = $("#<%= DROP_Accommodation.ClientID %> option:selected").data("id");
        //alert(AccomId);
        $("#<%= hdnAccomId.ClientID %>").val(AccomId);
        $("#<%= hdnAccomDropdownId.ClientID %>").val($("#<%= DROP_Accommodation.ClientID %>").val());
        
        //alert(AccomId);
    });

    /*$("# DROP_Extras_Supplier.ClientID ").change(function () {
    var ExtraId = $("# DROP_Extras_Supplier.ClientID  option:selected").data("id");
    $("# hdnExtraId.ClientID ").val(ExtraId)
    alert(ExtraId);
    });

    $("# DROP_Baggage_Supplier.ClientID ").change(function () {
    var BaggageExtraId = $("# DROP_Baggage_Supplier.ClientID  option:selected").data("id");
    $("# hdnExtraId.ClientID ").val(BaggageExtraId)
    //alert(BaggageExtraId);
    });*/

</script>

</asp:Content>
