<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PremiosForm.aspx.cs" Inherits="Grupo_7A.PremiosForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        <h1>Elegí tu premio!</h1>
    </div>
    <div class="carruseles-container">
        <asp:PlaceHolder ID="phCarruseles" runat="server" />
    </div>
</asp:Content>
