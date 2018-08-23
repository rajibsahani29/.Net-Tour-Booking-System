<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_room_view.aspx.vb" Inherits="accom_room_view"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="accom_new.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add New Accommodation">Add New Accommodation</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_view_all.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View Accommodation">View Accommodation</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Edit Accommodation">Edit Accommodation</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_photos.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add & Delete Accommodation Imagery">Add & Delete Accommodation Imagery</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_docs.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add & Delete Accommodation Docs">Add & Delete Accommodation Docs</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_add_rooms.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add a New Room Type for an Acccommodation">Add New Room Type for an Accom.</a> 
                               </li>  
               <li class="no_colour">
                                    <a  href="accom_room_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="View Room Types for an Accommodation">View Room Types for an Accom.</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_link.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Assign Accommodation to a Route and Stage">Assign Accommodation to Route and Stage</a> 
                               </li>                
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 

    <h1 class="page-title">View & Edit Room Types for an Accommodation</h1>
    <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                    
 

              <div class="form has-validation">
                <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View & Edit Room Types for an Accommodation</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   
        
                   <div class="clearfix">
                                   <div class="form-label">Select Accommodation</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accommodation" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>


                <div style="overflow-x:auto;" >
            <asp:GridView ID="GRID_Accom_Rooms" Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal" 
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id" 
                OnPageIndexChanging="GRID_Accom_Rooms_PageIndexChanging" OnRowCancelingEdit="GRID_Accom_Rooms_RowCancelingEdit" 
                OnRowEditing="GRID_Accom_Rooms_RowEditing" OnRowUpdating="GRID_Accom_Rooms_RowUpdating" OnRowDeleting="GRID_Accom_Rooms_RowDeleting" 
                OnRowDataBound="GRID_Accom_Rooms_OnRowDataBound" emptydatatext="No Records Found" ShowHeaderWhenEmpty="True">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
               <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
                <Columns>
                        <%--<asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />--%>
                        <asp:TemplateField HeaderText="Room Type">
                            <ItemTemplate>
                                <asp:Label ID="LABEL_RoomType" runat="server" Text='<%# Eval("RoomTypeName")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost Easyways">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_CostEasyways" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_CostEasyways" runat="server" Text='<%# Eval("cost_easyways")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost Client">
                            <ItemTemplate>
                            <asp:Label ID="LABEL_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="TB_CostClient" runat="server" Text='<%# Eval("cost_client")%>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room Facilities">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="javascript: ViewRoomFacilitiesAndOptions('<%# Eval("id")%>','<%# Eval("roomtype_id")%>');">View Room Facilities and Options</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Room Options">
                            <ItemTemplate>
                                <a href="javascript:;" onclick="javascript: ViewRoomOption(' Eval("id")',' Eval("roomtype_id")');">View Room Option</a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
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


                <div id="div_popup" class="cls_popup button_container clearfix basic" >
<div id='content'>

		<div id='basic-modal'>
    		<!-- modal content -->
		<div id="basic-modal-content">

		  <div class="container_12 clearfix leading">

 <section class="grid_12">
     <div class="form has-validation">
     <div class="clearfix">

<div id="divCheckBoxList" class="form-input">
    <div>
        Room Facilities
        <div id="divRoomFacilitiesCheckBoxList" class="form-input"></div>
         
    </div>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div>
        Room Options
        <div id="divRoomOptionsCheckBoxList" class="form-input"></div>
    </div>
    
    <%--<asp:CheckBoxList ID="CHKLIST_Room_Options" runat="server"></asp:CheckBoxList>--%>
</div>
     </div>
     <input type="hidden" id="hdnAccomRoomTypeId" name="hdnAccomRoomTypeId" value="" />
     <input type="button" id="btnSubmitRoomFacilitiesAndOptions" name="btnSubmitRoomFacilitiesAndOptions" value="Update Room Facilites And Options" />
     </div>

 </section></div>

            
    		<!-- preload the images -->
		<div style='display:none'>
			<img src='../views/img/basic/x.png' alt='' />
		</div>
</div>

</div>
</div></div>
                          
            
                        </div>  
		    
       </div></div>

<script type="text/javascript">

    function ViewRoomFacilitiesAndOptions(AccomRoomTypeId, RoomtypeId) {
        ViewRoomFacilities(AccomRoomTypeId, RoomtypeId);
        //ViewRoomOption(AccomRoomTypeId, RoomtypeId);
    }

    $("#btnSubmitRoomFacilitiesAndOptions").click(function () {
        SubmitRoomFacilities();
    });
    
    function ViewRoomFacilities(AccomRoomTypeId, RoomtypeId) {
        //alert("AccomRoomTypeId = " + AccomRoomTypeId);
        //alert("AccomRoomtypeId = " + AccomRoomtypeId);

        //$("#btnSubmitRoomFacilities").show();
        //$("#btnSubmitRoomOption").hide();

        $("#hdnAccomRoomTypeId").val(AccomRoomTypeId);
        $('#div_popup').modal();
        $('#basic-modal-content').css("display", "block");
        $("#divRoomFacilitiesCheckBoxList").html("");

        var doaction = "getRoomFacilitiesByCompanyId";

        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                //$("*[class^='clsMembershipId_'] input[type='checkbox']").attr('checked', false);
                var controlString = "";
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    //$(".clsMembershipId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                    controlString += "<input type='checkbox' id='CHK_RoomFacilities_" + ResponseCol[0] + "'  name='CHK_RoomFacilities_" + ResponseCol[0] + "' value='" + ResponseCol[0] + "' class='clsCHK_Room_Facility_List'><label for='CHK_RoomFacilities_" + ResponseCol[0] + "'>" + ResponseCol[1] + "</label><br/>";
                }
                //alert("controlString = "+controlString);
                $("#divRoomFacilitiesCheckBoxList").html(controlString);
            }
        }).done(function () {
            CheckedSelectedRoomFacilities(AccomRoomTypeId, RoomtypeId)
        });

    }

    function CheckedSelectedRoomFacilities(AccomRoomTypeId, RoomtypeId) {
        //alert(AccomRoomTypeId);
        var doaction = "getRoomTypeFacilitiesByAccomRoomTypeId";

        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomTypeId: AccomRoomTypeId }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    $("#CHK_RoomFacilities_" + ResponseCol[1]).attr('checked', true);
                }
            }
        }).done(function () {
            ViewRoomOption(AccomRoomTypeId, RoomtypeId); 
        });
    }

    //$("#btnSubmitRoomFacilities").click(function () {});
    function SubmitRoomFacilities()
    {
        var AccomRoomTypeId = $("#hdnAccomRoomTypeId").val();

        if (AccomRoomTypeId > 0) {

            var CheckBoxListVal = "";

            $(".clsCHK_Room_Facility_List:checked").each(function () {
                CheckBoxListVal += $(this).val() + ","
            });
            //alert(CheckBoxListVal);

            var doaction = "updateAccomRoomTypeFacilitiesDetails";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomTypeId: AccomRoomTypeId, CheckBoxListVal: CheckBoxListVal }, function (responseText) {
                //alert(responseText.toString());
                //return responseText.toString();
                if (responseText.toString() == "Success") {
                    alert("Room facilities has been amended");
                }
                else if (responseText.toString() == "Blank") {
                    alert("Room facilities has been amended");
                }
                else {
                    alert("There was a system error. If this error persists please contact technical support.");
                }
            }).done(function () {
                SubmitRoomOption();
            });
        }
    }

    function ViewRoomOption(AccomRoomTypeId, RoomtypeId) {
        //alert("AccomStageRoomId = " + AccomStageRoomId);
        //alert("AccomRoomtypeId = " + AccomRoomtypeId);

        //$("#btnSubmitRoomFacilities").hide();
        //$("#btnSubmitRoomOption").show();

        $("#hdnAccomRoomTypeId").val(AccomRoomTypeId);
        $('#div_popup').modal();
        $('#basic-modal-content').css("display", "block");
        $("#divRoomOptionsCheckBoxList").html("");

        var doaction = "getRoomTypeOptionsByCompanyId";

        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                //$("*[class^='clsMembershipId_'] input[type='checkbox']").attr('checked', false);
                var controlString = "";
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    //$(".clsMembershipId_" + ResponseRow[i] + " input[type='checkbox']").attr('checked', true);
                    controlString += "<input type='checkbox' id='CHK_RoomOption_" + ResponseCol[0] + "'  name='CHK_RoomOption_" + ResponseCol[0] + "' value='" + ResponseCol[0] + "' class='clsCHK_Room_Option_List'><label for='CHK_RoomOption_" + ResponseCol[0] + "'>" + ResponseCol[1] + "</label><br/>";
                }
                //alert("controlString = "+controlString);
                $("#divRoomOptionsCheckBoxList").html(controlString);
            }
        }).done(function () {
            CheckedSelectedRoomTypeOption(AccomRoomTypeId);
        });

    }

    function CheckedSelectedRoomTypeOption(AccomRoomTypeId) {
        //alert(AccomRoomTypeId);
        var doaction = "getRoomTypeOptionByAccomRoomTypeId";

        $(document).ajaxStart(function () {
            $(".cls_popup").addClass("aiLoading");
        });
        $(document).ajaxComplete(function () {
            $(".cls_popup").removeClass("aiLoading");
            $(document).unbind("ajaxStart ajaxStop");
        });
        $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomTypeId: AccomRoomTypeId }, function (responseText) {
            //alert(responseText.toString());
            if (responseText.toString() != "") {
                var ResponseRow = responseText.split("rowSplit");
                for (i = 0; i < ResponseRow.length - 1; i++) {
                    var ResponseCol = ResponseRow[i].split("colSplit");
                    $("#CHK_RoomOption_" + ResponseCol[1]).attr('checked', true);
                }
            }
        });
    }

    //$("#btnSubmitRoomOption").click(function () {});
    function SubmitRoomOption(){
        var AccomRoomTypeId = $("#hdnAccomRoomTypeId").val();

        if (AccomRoomTypeId > 0) {

            var CheckBoxListVal = "";

            $(".clsCHK_Room_Option_List:checked").each(function () {
                CheckBoxListVal += $(this).val() + ","
            });
            //alert(CheckBoxListVal);

            var doaction = "updateAccomRoomTypeOptionDetails";

            $(document).ajaxStart(function () {
                $(".cls_popup").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".cls_popup").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, AccomRoomTypeId: AccomRoomTypeId, CheckBoxListVal: CheckBoxListVal }, function (responseText) {
                //alert(responseText.toString());
                //return responseText.toString();
                if (responseText.toString() == "Success") {
                    alert("Room Options has been amended");
                }
                else if (responseText.toString() == "Blank") {
                    alert("Room Options has been amended");
                }
                else {
                    alert("There was a system error. If this error persists please contact technical support.");
                }
            });
        }
    }

</script>

</asp:Content>
