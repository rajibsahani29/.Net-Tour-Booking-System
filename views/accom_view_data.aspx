<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_view_data.aspx.vb" Inherits="accom_view_data"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<style type="text/css">
    .aiLoading::before {
        background-position: 50% 7%;
    }
    .hideGridColumn
    {`
        display: none;
    }
</style>

<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="accom_new.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Add New Accommodation">Add New Accommodation</a> 
                               </li> 

     <li class="no_colour">
                                    <a  href="accom_view_all.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="View Accommodation">View Accommodation</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_view.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Download Accommodation Data">Download Accommodation Data</a> 
                               </li> 

                                 <li class="no_colour">
                                    <a  href="accom_photos.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Add & Delete Accommodation Imagery">Add & Delete Accommodation Imagery</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="accom_docs.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Add & Delete Accommodation Docs">Add & Delete Accommodation Docs</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_add_rooms.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Add a New Room Type for an Acccommodation">Add New Room Type for an Accom.</a> 
                               </li>  
               <li class="no_colour">
                                    <a  href="accom_room_view.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="View Room Types for an Accommodation">View Room Types for an Accom.</a> 
                               </li>  
                          <li class="no_colour">
                                    <a  href="accom_link.aspx" data-html="true" data-offset="20" title="" rel="popover" data-original-title="Assign Accommodation to a Route and Stage">Assign Accommodation to Route and Stage</a> 
                               </li>                
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>    
    

 


    <h1 class="page-title">View & Edit Accommodation</h1>

   
    	<div class="form has-validation">

      <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Download Accommodation Data</th>
						
					</tr>
				</thead>
            </table>
           </div>                   
               <div class="clearfix">
                    <div class="form-input">
                        <asp:Button ID="BUT_Download_Accom_Data" UseSubmitBehavior="true" Style="margin:0; margin-bottom:5px;margin-left:10px;" class="fl"  runat="server" Text="Download Accommodation Data" />                    
                    </div>
                    <div class="form-input">
                        <asp:Button ID="BUT_Download_Agents_Data" UseSubmitBehavior="true" Style="margin:0; margin-bottom:5px;margin-left:10px;" class="fl"  runat="server" Text="Download Agent Data" />                    
                    </div>
                    <div class="form-input">
                        <asp:Button ID="BUT_Download_BaggageAndTaxis_Data" UseSubmitBehavior="true" Style="margin:0; margin-bottom:5px;margin-left:10px;" class="fl"  runat="server" Text="Download Baggage And Taxis Data" />                    
                    </div>
                </div>
            </div>

</asp:Content>
