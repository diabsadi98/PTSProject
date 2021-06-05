<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHomeWebForm.aspx.cs" Inherits="PTSJadaraWebApplication.AdminHomeWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 82px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Welcome"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelFullName" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
