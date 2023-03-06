<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListarID.aspx.cs" Inherits="Almacen.Almacen.ClienteWeb.ListarID" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="d-flex justify-content-center align-items-center mb-3">
        <p id="busqueda">Búsqueda ID</p>
    </div>
    <div class="mb-0">
        <label id="bid" class="form-label" for="TextBox1"></label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <br />
    <hr />
    <div class="mb-5">
        <asp:Button ID="Button1" runat="server" onClick="Button1_Click" Text="Button" CssClass="btn-outline-warning"/>
    </div>
    <div class="mb-3">
        <label class="form-label" for="Label1">Nombre</label>
        <asp:Label ID="Label1" runat="server" CssClass="form-control" Height="30"></asp:Label>
    </div>
    <div class="mb-3">
        <label class="form-label" for="Label1">Presentación</label>
        <asp:Label ID="Label2" runat="server" CssClass="form-control" Height="30"></asp:Label>
    </div>
    <div class="mb-3">
        <label class="form-label" for="Label1">CostoUnitario</label>
        <asp:Label ID="Label3" runat="server" CssClass="form-control" Height="30"></asp:Label>
    </div>
    <div class="mb-3">
        <label class="form-label" for="Label1">Precio Mayoreo</label>
        <asp:Label ID="Label4" runat="server" CssClass="form-control" Height="30"></asp:Label>
    </div>
    <div class="mb-3">
        <label class="form-label" for="Label1">Precio Menudeo</label>
        <asp:Label ID="Label5" runat="server" CssClass="form-control" Height="30"></asp:Label>
    </div>
</asp:Content>
