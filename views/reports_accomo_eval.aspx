<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_accomo_eval.aspx.vb" Inherits="reports_accomo_eval"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Accommodation Evaluation Results</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">


              
                                     <div class="clearfix">
                          
         <div class="form-label">Accommodation</div>
                               
                               
          <div class="form-input">
               <asp:DropDownList ID="DROP_Accom" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server" required>  
               </asp:DropDownList>                    
             </div>

             </div>


                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__View" UseSubmitBehavior="true" runat="server" Text="View" />
                          
</div></div>

<div id="Show_Report">

                    <div class="section group" style="font-weight:bold;">
	<div class="col span_1_of_6">
	
	</div>
	<div class="col span_1_of_6">
	Welcome
	</div>
	<div class="col span_1_of_6">
    Cleanliness
	</div>
	<div class="col span_1_of_6">
	Breakfast
	</div>
	<div class="col span_1_of_6">
	Facilities
	</div>
	<div class="col span_1_of_6">
	Overall
	
</div></div><br />
    <div class="section group">
        <div class="col span_1_of_6" style="font-weight:bold;">
	     Average Result
	    </div>
	    <div class="col span_1_of_6" >
            <asp:Label ID="Label_Accom_Average_Welcome" runat="server" Style="color:red" Text="0"></asp:Label> 
	    </div>
         <div class="col span_1_of_6">
        <asp:Label ID="Label_Accom_Average_Cleanliness" runat="server" Style="color:red"  Text="0"></asp:Label>
       </div>
        <div class="col span_1_of_6">
            <asp:Label ID="Label_Accom_Average_Breakfast" runat="server" Style="color:red"  Text="0"></asp:Label>

        </div>
	    <div class="col span_1_of_6" >
            <asp:Label ID="Label_Accom_Average_Facilities" runat="server" Style="color:red"  Text="0"></asp:Label> 
        </div>
        <div class="col span_1_of_6">
            <asp:Label ID="Label_Accom_Average_Overall" runat="server" Style="color:red"  Text="0"></asp:Label>

        </div>

       

        <br />
    </div>








<div style="overflow-x:auto;">
    <asp:GridView ID="GRID_Accom_Eval" runat="server" CellPadding="4" pagesize="2000" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#00A19C" Font-Bold="True" Font-Size="Medium"  ForeColor="White" Height="25px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" Height="50px"/>
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </div>

</div>

				</div>
    </section>

 </div>        
    

</asp:Content>
