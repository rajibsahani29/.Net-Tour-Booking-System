<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="agent_photos.aspx.vb" Inherits="agent_photos"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="theme_dropdown" class="theme_dropdown">
       
                      <ul   class="dropdowns_ew">
 
                        <li class="top_level">
                            <a id="theme_current" class="active_theme" href="#">Select Sub Menu Options</a> 
                            <ul style="opacity:1; display:block;">  
                                <li class="no_colour">
                                    <a  href="agents_new.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add Agent">Add Agent</a> 
                               </li> 

    <li class="no_colour">
                                    <a  href="agents_view.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="View & Edit Agent">View & Edit Agent</a> 
                               </li> 

                                <li class="no_colour">
                                    <a  href="agent_photos.aspx" data-html="true" data-offset="20" title="" 
rel="popover" data-original-title="Add & Edit Agent Logo">Add & Edit Agent Logo</a> 
                               </li> 

                                 
                         
   
                            </ul> 
                        </li>
                         
                      </ul> 
                    
                    </div>  
    

 

    <h1 class="page-title">Add & Edit Agent Logo</h1>
    <div class="container_12 clearfix leading">

             
                    <div class="grid_12">
                    
 

              <div class="form has-validation">
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">Add Agent Logo</th>
						
					</tr>
				</thead>
            </table>
           </div> 
   

                   <div class="clearfix">
                                   <div class="form-label">Select Agent</div>
                              
                                  <div class="form-input" >
                                  <asp:DropDownList ID="DROP_Agent" 
                                          style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" 
                                          AutoPostBack="True">
                                  </asp:DropDownList>

                          </div> </div>

                            <div class="clearfix">
                          
                                <div class="form-label">Upload a New Logo</div>
                               
                              
                                <div class="form-input">
                                 <asp:FileUpload ID="FILE_Logo" style="margin-top:2%;margin-left:2%;"  runat="server" />
         
                                        
                                </div>

                            </div>



                         

                            <div class="form-action clearfix">
                                <asp:Button ID="BUT_Add_Logo"   class="fr"  runat="server" 
                                    Text="Add Logo" Enabled="False" />
                              

                            </div>

                        </div>  

                        
               <div class="form has-validation">
                <div class="clearfix" style="background:#5E249F;color:#DAE5EB;">
        <table class="basic-table"  ;>
				<thead>
					<tr>
						<th style="width:100%; ">View & Delete Existing Logo - Only 1 logo allowed per Agent</th>
						
					</tr>
				</thead>
            </table>
           </div> 
          </div>

                        <asp:GridView ID="GRID_Agent_Logo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="id,image_loc" 
                                OnRowDeleting="GRID_Agent_Logo_RowDeleting" OnRowDataBound="GRID_Agent_Logo_OnRowDataBound" 
                                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True"
                            >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                             <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Logo Image">
                                    <ItemTemplate>
                                        <asp:Image ID="IMG_Photo" runat="server" Height="100" Width="100" />
                                        <asp:HiddenField ID="hdnImageName" runat="server" Value='<%# Eval("image_loc")%>' />
                                        <asp:HiddenField ID="hdnAccomPhotoId" runat="server" Value='<%# Eval("id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:CommandField ShowDeleteButton="true" />
                             </Columns>
                          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Medium" Height="50px"/>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
       </div></div>



</asp:Content>
