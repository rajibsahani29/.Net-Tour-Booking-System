<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="general_diary_view.aspx.vb" Inherits="general_diary_view"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href='../calendarlib/fullcalendar.min.css' rel='stylesheet' />
<link href='../calendarlib/fullcalendar.print.min.css' rel='stylesheet' media='print' />
<script src='../calendarlib/moment.min.js' type="text/javascript"></script>
<%--<script src='../Calendarlib/lib/jquery.min.js' type="text/javascript"></script>--%>
<script src='../calendarlib/fullcalendar.min.js' type="text/javascript"></script>

<style type="text/css">

    #calendar {
		padding-right:10px;
	}
	.fc table{
	    margin-left:0;
	}
    .fc-content
	{
	    font-size:13px;    
	}
</style>
    
<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="bookings_enquiry.aspx" data-html="true" data-offset="20" title="" 

rel="popover" data-original-title="Add New Enquiry">Add New Enquiry</a> 
                               </li> 

                                

    <li class="no_colour">
                                    <a  href="bookings_search.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Booking</a> 
                               </li> 

       <li class="no_colour">
                                    <a  href="bookings_new_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add a New Client</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="bookings_edit_client.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View & Edit Client</a> 
                               </li> 

    
                 
      <li class="no_colour">
                                    <a  href="accom_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Accom Diary Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="accom_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Accommodation Diary</a> 
                               </li>    
                                  
       <li class="no_colour">
                                    <a  href="general_diary_add.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >Add Diary General Event</a> 
                               </li> 

                                       <li class="no_colour">
                                    <a  href="general_diary_view.aspx" data-html="true" data-offset="20" title="" 

rel="popover" >View Diary General Event</a> 
                               </li>  
                                
                                
                                 
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

    <h1 class="page-title">View General Diary</h1>


      <div class="container_12 clearfix leading">

             
                    <div class="grid_12">

                 
<div class="form has-validation">

      <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View General Diary</th>
						
					</tr>
				</thead>
            </table>
           </div>                   
               <div class="clearfix">
                                 <div class="form-label">Select Stage</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Stage" required="required" 
                                          style="font-size:18px;  margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>
                                
                          </div>

                     </div>
         
      
        <div class="clearfix">
                                 <div class="form-label">Select Accommodation</div>
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Accom_Name" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                
                          </div>

                     </div>
         
                            <div class="clearfix">
                          
                                <div class="form-label">From</div>
                               
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_From_Date" class="date" type="date" name="date" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                                 
         
                                        
                                </div>

                            </div>
    </div>
                           <div class="form has-validation">
    <div class="clearfix" style="background:#808080;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View Calendar</th>
						
					</tr>
				</thead>
            </table>
           </div>                

           <div id="calendar" class="show_calendar"></div>
          

                        </div>   	

                    
                        

          </div></div>

<script type="text/javascript">

    $("#<%= TB_From_Date.ClientID %>, #<%= DROP_Accom_Name.ClientID %>").change(function () {

        GetCalendarData("");

    });

    function GetCalendarData(DateValue) {

        var stageId = $("#<%= DROP_Stage.ClientID %>").val();
        //alert(stageId);

        var fromDate = "";
        if (DateValue != "") {
            fromDate = DateValue;
        }
        else {
            fromDate = $("#<%= TB_From_Date.ClientID %>").val();
        }
        //alert(fromDate);

        //if (stageId != "" && fromDate != "") {
        if (fromDate != "") {

            var accomId = $("#<%= DROP_Accom_Name.ClientID %>").val();
            //alert(accomId);
            if (accomId == "") {
                accomId = 0;
            } 

            var doaction = "getGeneralDiaryCalander";

            $(document).ajaxStart(function () {
                $(".show_calendar").addClass("aiLoading");
            });
            $(document).ajaxComplete(function () {
                $(".show_calendar").removeClass("aiLoading");
                $(document).unbind("ajaxStart ajaxStop");
            });
            $.post('GetAjaxData.aspx', { DoAction: doaction, StageId: stageId, AccomId: accomId, FromDate: fromDate }, function (responseText) {
                //alert(responseText.toString());
                $('#calendar').fullCalendar('destroy');
                if (responseText.toString() != "") {
                    var objResponce = JSON.parse(responseText)
                    var CalendarData = [];
                    for (var i = 0; i < objResponce.length; i++) {
                        CalendarData[i] = objResponce[i].data;
                        //console.log(objResponce[i].id);
                        //console.log(objResponce[i].color);
                    }
                    //console.log(JSON.stringify(CalendarData));
                    //alert(JSON.stringify(CalendarData));
                    SetCalendarData(CalendarData);
                }
                else {
                    $('#calendar').fullCalendar({
                        customButtons: {
                            prevButton: {
                                text: 'Prev',
                                click: function () {
                                    var fromDate = $("#<%= TB_From_Date.ClientID %>").val();
                                    var CurrentDate = new Date(fromDate);
                                    var NewDate = formatDate(CurrentDate, "Remove");
                                    $("#<%= TB_From_Date.ClientID %>").val(NewDate);
                                    GetCalendarData(NewDate);
                                }
                            },
                            nextButton: {
                                text: 'Next',
                                click: function () {
                                    var fromDate = $("#<%= TB_From_Date.ClientID %>").val();
                                    var CurrentDate = new Date(fromDate);
                                    var NewDate = formatDate(CurrentDate, "Add");
                                    $("#<%= TB_From_Date.ClientID %>").val(NewDate);
                                    GetCalendarData(NewDate);
                                }
                            }
                        },
                        header: {
                            left: 'prevButton, nextButton',
                            center: 'title',
                            //right: 'month,agendaWeek,agendaDay,listWeek'
                            //right: 'month,basicWeek,basicDay,listWeek'
                            right: 'month,basicWeek,listWeek'
                        },
                        defaultDate: fromDate, //'2017-05-29',
                        navLinks: true, // can click day/week names to navigate views
                        editable: true,
                        eventLimit: true, // allow "more" link when too many events
                        events: ''
                    });
                }
            });
        }
        else {
            //$("#DIV_staff_view_hide").hide();
        }

    }

    function SetCalendarData(CalendarDataJson) {
        //var dt = new Date();
        //var FullDate = dt.getFullYear() + "-" + (dt.getMonth() + 1) + "-" + dt.getDate();

        //alert(CalendarDataJson);
        //alert(JSON.stringify(CalendarDataJson));
        //console.log(JSON.stringify(CalendarDataJson));
        var fromDate = $("#<%= TB_From_Date.ClientID %>").val();
        $('#calendar').fullCalendar({
            customButtons: {
                prevButton: {
                    text: 'Prev',
                    click: function () {
                        var fromDate = $("#<%= TB_From_Date.ClientID %>").val();
                        var CurrentDate = new Date(fromDate);
                        var NewDate = formatDate(CurrentDate, "Remove");
                        $("#<%= TB_From_Date.ClientID %>").val(NewDate);
                        GetCalendarData(NewDate);
                    }
                },
                nextButton: {
                    text: 'Next',
                    click: function () {
                        var fromDate = $("#<%= TB_From_Date.ClientID %>").val();
                        var CurrentDate = new Date(fromDate);
                        var NewDate = formatDate(CurrentDate, "Add");
                        $("#<%= TB_From_Date.ClientID %>").val(NewDate);
                        GetCalendarData(NewDate);
                    }
                }
            },
            header: {
                left: 'prevButton, nextButton',
                center: 'title',
                //right: 'month,agendaWeek,agendaDay,listWeek'
                //right: 'month,basicWeek,basicDay,listWeek'
                right: 'month,basicWeek,listWeek'
            },
            defaultDate: fromDate, //'2017-05-29',
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: CalendarDataJson, //JSON.stringify(CalendarDataJson)
            editable: false
        });
    }

    function formatDate(date, MonthVal) {
        //alert(date);
        var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

        if (MonthVal == "Add") {
            month = (parseInt(month) + 1).toString();
            if (parseInt(month) > 12) {
                month = "1";
                year = (parseInt(year) + 1).toString();
            }
        }
        else if (MonthVal == "Remove") {
            month = (parseInt(month) - 1).toString();
            if (parseInt(month) < 1) {
                month = "12";
                year = (parseInt(year) - 1).toString();
            }
        }

        if (month.length < 2) {
            month = '0' + month;
        }
        if (day.length < 2) day = '0' + day;

        //alert(year);
        //alert(month);
        //alert(day);
        return [year, month, day].join('-');
    }

</script>

</asp:Content>
