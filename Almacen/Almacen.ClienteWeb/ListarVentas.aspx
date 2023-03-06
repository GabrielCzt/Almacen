<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListarVentas.aspx.cs" Inherits="Almacen.Almacen.ClienteWeb.ListarVentas"  Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="d-flex justify-content-center align-items-center mb-3"> 
        <p id="busqueda">Busqueda por fecha</p>
    </div>
    <div class="mb-0 justify-content-center align-items-center">
        <label id="bid" class="form-label" for="TextBox1">Seleccione una fecha</label>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
    </div>
    <br />
    <hr />
    <div class="d-flex justify-content-center align-items-center">
        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-responsive table-warning table-hover"
            HeaderStyle-BackColor="#ffe28a"
            GridLines="Vertical"
            Font-Size="Small"
            HeaderStyle-Font-Size="Medium"></asp:GridView>
    </div>
</asp:Content>
