<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="accom_search.aspx.vb" Inherits="accom_search"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   <h1 class="page-title" style="text-align:center;">Search For an Accommodation</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">

                <asp:Panel ID="pnlForm" runat="server" DefaultButton="BUT__Search_Accom">
          
                              <div class="clearfix">
                                  <asp:Label ID="Label_Search_Name" runat="server" class="form-label" Text="Search By Name"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Name" class="form-input" name="name" placeholder="Search By Name" runat="server"></asp:TextBox>

                                     

                          </div> </div>
            

       

                   

                              <div class="clearfix">
                                  <asp:Label ID="Label_Search_Stage" runat="server" class="form-label" Text="AND / OR Search By Stage"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Stage" class="form-input" name="name" placeholder="Search By Stage" runat="server"></asp:TextBox>


                          </div> </div>
                         
          

                       

                              <div class="clearfix">
                                  <asp:Label ID="Label_Search_Postcode" runat="server" class="form-label" Text="AND / OR Search By Postcode"></asp:Label>
                              
                                  <div class="form-input">
                                 <asp:TextBox ID="TB_Search_Postcode" class="form-input" name="name" placeholder="Search By Postcode" runat="server"></asp:TextBox>

                                </div>

                            </div>
                          
                 

                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__Search_Accom" UseSubmitBehavior="true" runat="server" Text="Search" />
                          
</div></div>
              
                       
                </asp:Panel>


			
  <div style="overflow-x:auto;">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
        <asp:GridView ID="GRID_Accom_Search"  Width="98%" runat="server" CellPadding="5" ForeColor="#ABC4DC" GridLines="Horizontal"  
                AllowPaging="true" pagesize="2000" AutoGenerateColumns="false" DataKeyNames="AccomId" 
                emptydatatext="No Records Found" ShowHeaderWhenEmpty="True" OnRowCommand="GRID_Accom_Search_RowCommand"
                OnPageIndexChanging="GRID_Accom_Search_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <HeaderStyle BackColor="#ABC4DC" Font-Bold="True" Font-Size="Large"  ForeColor="White" Height="25px" />
                <Columns>
                    <%--<asp:BoundField DataField="datecreated" HeaderText="Booking Date" ReadOnly="true" />--%>
                    <asp:BoundField DataField="AccomName" HeaderText="Accommodation Name" ReadOnly="true" />
                    <asp:BoundField DataField="StageName" HeaderText="Stage" ReadOnly="true" />
                    <asp:BoundField DataField="postcode" HeaderText="Postcode" ReadOnly="true" />
                    <%--<asp:CommandField ShowSelectButton="true" SelectText="View Accommodation" />--%>
                    <asp:ButtonField ButtonType="Button" CommandName="EditAccommodation" Text="Edit Accommodation" />
                    <asp:ButtonField ButtonType="Button" CommandName="ViewAccommodation" Text="View Accommodation" />
              </Columns>
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Medium" Height="50px"/>
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView></div>
	        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BUT__Search_Accom" />                        
                    </Triggers>
            </asp:UpdatePanel>

      </div>
       	</div>
        </section>

 </div>        
    

</asp:Content>
