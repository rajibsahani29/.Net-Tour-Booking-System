<%@ Page Language="VB" MasterPageFile="../blank.master" AutoEventWireup="false" CodeFile="booking_info_baggage.aspx.vb" Inherits="booking_info_baggage"  ValidateRequest="false"%>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="../css/new.css" media="screen" />
    <link rel="stylesheet" href="../css/device/general.css" media="screen" />
    <link rel="stylesheet" href="../css/common.css" media="screen" />


  <div id="wrapper" >

           <div class="payment-btn-container" style="float:left;">
                           <div class="pull-right btn-group btn-group-sm hidden-print">
                <a href="javascript:printDiv('wrapper')"  style="color:#000;font-weight:bold;" class="btn btn-default"><i class="fa fa-print"></i> Print</a>
               
            </div>
                        </div>
        <div style="text-align:center">
            <h2 class="page-title" style="border:none;">
                <asp:Label ID="LABEL_Baggage_Supplier_Name" runat="server"  Text="Supplier Name"></asp:Label>&nbsp;&mdash;&nbsp;Invoice Easyways </h2>
            <h2 class="page-title" style="border:none;"> <asp:Label ID="LABEL_Client_Name" runat="server"  Text="Client Name"></asp:Label>&nbsp;&mdash;&nbsp;<asp:Label ID="LABEL_Total_Number_People" runat="server"  Text="3"></asp:Label>&nbsp;x&nbsp;person(s)&nbsp;&mdash;&nbsp;<asp:Label ID="LABEL_No_of_Bags" runat="server" Text="Number of bags"></asp:Label>&nbsp;x&nbsp;Bags&nbsp;&#61;&nbsp;&#0163; <asp:Label ID="LABEL_Total_Cost_Bags" runat="server"  Text="Total Cost of Bags"></asp:Label> </h2>
        </div>

        <hr class="style3">
        <div id="Stagex_Baggage"><h5>
    <b><asp:Label ID="LABEL_Day_of_Travel" runat="server"  Text="Day of Travel"></asp:Label>&#44;&nbsp;<asp:Label ID="LABEL_Date_of_Travel" runat="server"  Text="Date of Travel"></asp:Label>&nbsp;Overnight Stay:</b>&nbsp;<asp:Label ID="LABEL_Accomx_City" runat="server"  Text="Accomx City"></asp:Label><br /><br />
    <asp:Label ID="LABEL_Accomx_Contact_Name" runat="server"  Text="Accomx Contact Name"></asp:Label>&#44;&nbsp;<asp:Label ID="LABEL_Accomx_Name" runat="server"  Text="Accomx Name"></asp:Label>&#44;&nbsp;<asp:Label ID="LABEL_Accomx_Address" runat="server"  Text="Accomx Address"></asp:Label><br /><br />

    <asp:Label ID="LABEL_Accomx_Phone" runat="server"  Text="Accomx Phone"></asp:Label>
</h5>
        </div>

        <hr class="style3">
</div>


</asp:Content>
