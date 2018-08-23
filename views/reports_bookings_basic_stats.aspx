<%@ Page Language="VB" MasterPageFile="../main.master" AutoEventWireup="false" CodeFile="reports_bookings_basic_stats.aspx.vb" Inherits="reports_bookings_basic_stats"  ValidateRequest="false"%>
<%@ MasterType virtualpath="~/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container-fluid print-container" style="position:relative;">
     
   <h1 class="page-title" style="text-align:center;">Live Bookings</h1>
       <div class="container_12 clearfix leading">
            

 <section class="grid_12">

     <div class="message info">

           
              
<div class="form has-validation">              
             <div class="section group">
         
          <div class="row">

          <div class="col span_1_of_3" >
          <div class="clearfix" >
                                   <div class="form-label" style="width:130px;color:black;">Criteria</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" style="width:130px;color:black;">Value</div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" style="width:130px;color:black;">Booking ID</div>
                              
                               
              </div>
           </div></div>
              

               <div class="row">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Oldest</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Oldest_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Oldest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Oldest_Booking_ID" style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Oldest_Booking_ID" runat="server" value=""></asp:Label>
                                   </div>
                              
                                 </div>
              </div>
              </div>    
                  <div class="row">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Newest</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Newest__Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Newest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Newest_Booking_ID" style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Newest_Booking_ID" runat="server" value=""></asp:Label>
                                   </div>
                              
                                 </div>
              </div>
              </div> 


  
          <div class="row" style="display:none;">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Smallest</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Smallest_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Smallest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Smallest_Booking_ID" style="width:130px;color:red;">&nbsp;</div>
                              
                                 </div>
              </div>
              </div>   

          <div class="row" style="display:none;">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Largest</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Largest_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Largest_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Largest_Booking_ID" style="width:130px;color:red;">&nbsp;</div>
                              
                                 </div>
              </div>
              </div>   

          <div class="row">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Total Number</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_No_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Total_No_Value" runat="server" value=""></asp:Label>
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_No_Booking_ID" style="width:130px;color:red;">&nbsp;</div>
                              
                                 </div>
              </div>
              </div>   

   <div class="row">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Total Agent</div>
                               </div></div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_Agent_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Total_Agent_Value" runat="server" value=""></asp:Label> 
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_Agent_Booking_ID" style="width:130px;color:red;">&nbsp;</div>
                              
                                 </div>
              </div>
              </div>   

                    <div class="row">

          <div class="col span_1_of_3">
          <div class="clearfix">
                                   <div class="form-label" style="width:130px;">Total Easyways</div>
                               </div>  </div>

         <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_Non_Agent_Value"   style="width:130px;color:red;">&nbsp;
                                    <asp:Label ID="LABEL_Total_Non_Agent_Value" runat="server" value=""></asp:Label> 
                                   </div>
                              
                                   </div>  </div>

        <div class="col span_1_of_3"> <div class="clearfix">
                                   <div class="form-label" runat="server" id="Total_Non_Agent_Booking_ID" style="width:130px;color:red;">&nbsp;</div>
                              
                                 </div>
              </div>
              </div>   
              


</div>
                 

         </div>
</div>
     </section>
</div>
    </</div>


   



	

   

</asp:Content>
