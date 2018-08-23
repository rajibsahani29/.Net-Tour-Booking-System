<%@ Page Title="" Language="VB" MasterPageFile="~/main.master" AutoEventWireup="false" CodeFile="bulk_email.aspx.vb" Inherits="views_bulk_email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Button ID="BUT_Send_Email" runat="server" Text="Button" style="display:none;"/>

    <asp:Label ID="LABEL_Send_Email_Count" runat="server" Text=""></asp:Label>
    <asp:Label ID="LABEL_Send_Email_Status" runat="server" Text="" style="font-size:16px;"></asp:Label>

    <script type="text/javascript">
        function SendEmail_JS() {
            document.getElementById("<%= BUT_Send_Email.ClientID %>").click();
        }
    </script>

</asp:Content>

