<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_financial.aspx.vb" Inherits="reports_financial"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    

        
   <h1 class="page-title" style="text-align:center;">Financial Summary Report</h1>
   
    <div class="container_12 clearfix leading">
            

 <section class="grid_12">


				<div class="form has-validation">


              
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_From" runat="server" class="form-label" Text="Date From"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_From" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>

                                    

                          </div> </div>
               

               

                   

                                <div class="clearfix">
                                  <asp:Label ID="LABEL_Date_To" runat="server" class="form-label" Text="Date To"></asp:Label>
                              
                                  <div class="form-input">
                                <asp:TextBox ID="TB_Date_To" class="date" type="date" name="date" placeholder="mm/dd/yyyy"   runat="server"></asp:TextBox>


                                     

                          </div> </div>
                         
              
                 
                              <div class="clearfix">
                                  <asp:Label ID="LABEL_Route" runat="server" class="form-label" Text="Route"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:DropDownList ID="DROP_Route" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                </div>

                            </div>


                            <div class="clearfix">
                                  <asp:Label ID="LABEL_Agent" runat="server" class="form-label" Text="Agent"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:DropDownList ID="DROP_Agent" style="font-size:18px; margin-top:2%;margin-left:2%;" runat="server">
                                  </asp:DropDownList>
                                </div>

                            </div>


                     <div class="clearfix">
                                  <asp:Label ID="LABEL_Show_Customised_Fixed_All" runat="server" class="form-label" Text="Only Show:"></asp:Label>
                              
                                  <div class="form-input">
                                   <asp:RadioButtonList ID="RADIO_Customised_Fixed_All"  class="radiogroup" RepeatDirection="Vertical" RepeatLayout="Table" runat="server"> 
                          <asp:ListItem Selected="True" Text="&nbsp;Customised" Value="1"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Fixed" Value="0"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;All" Value="2"></asp:ListItem>
                          </asp:RadioButtonList>
                                </div>

                            </div>





                  
                     <div class="clearfix">

                                <div class="form-action clearfix " style="float:right;">
                                <asp:Button ID="BUT__View" UseSubmitBehavior="true" runat="server" Text="View" />
                          
</div></div>
<div id="Show_Report">

     <div class="message info">

           
              
<div class="form has-validation">   
             <div class="section group">
         
                    

               <div class="row">

          <div class="col span_1_of_2">
          <div class="clearfix">
                                   <div class="form-label" style="width:300px;">Total Number of Bookings</div>
                               </div>  </div>

         <div class="col span_1_of_2"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Oldest_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Oldest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

              </div>    
                  <div class="row">

          <div class="col span_1_of_2">
          <div class="clearfix">
                                   <div class="form-label" style="width:300px;">Total Booking Fee</div>
                               </div>  </div>

         <div class="col span_1_of_2"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Newest__Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Newest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

      
              </div> 


  
          <div class="row">

          <div class="col span_1_of_2">
          <div class="clearfix">
                                   <div class="form-label" style="width:300px;">Total Credit Card Commission</div>
                               </div>  </div>

         <div class="col span_1_of_2"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Smallest_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Smallest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>


              </div>   

          <div class="row">

          <div class="col span_1_of_2">
          <div class="clearfix">
                                   <div class="form-label" style="width:300px;">Total Cost to Easyways</div>
                               </div>  </div>

         <div class="col span_1_of_2"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Largest_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Largest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

              </div>   

          <div class="row">

          <div class="col span_1_of_2">
          <div class="clearfix">
                                   <div class="form-label" style="width:300px;">Total Cost to Client</div>
                               </div>  </div>

         <div class="col span_1_of_2"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_No_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Total_No_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

      
              </div>   

   <div class="row">

          <div class="col span_1_of_2">
          <div class="clearfix">
                                   <div class="form-label" style="width:300px;">Profit / Loss</div>
                               </div></div>

         <div class="col span_1_of_2"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_Agent_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Total_Agent_Value" runat="server" value=""></asp:Label> 
                                   </div>
                              
                                   </div>  </div>

      
              </div>   

           
              


</div></div></div>

</div>






				</div>
    </section>

 </div>        
    

</asp:Content>
