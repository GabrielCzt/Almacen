<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="Almacen.Almacen.ClienteWeb.Listar" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ListView ID="productList" runat="server"
        GroupItemCount="3"
        ItemType="Almacen.Almacen.Entities.Producto" SelectMethod="ObtenerProductos">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>Ningún dato fue devuelto</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceHolder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td runat="server">
                <a href="#">
                    <img src="../Imagenes/<%#:Item.ImagenPath %>" width="100" height="100"
                        style="border: 1px solid black"/>
                </a>
                <br />
                <a href="#">
                    <span>
                        <%#:Item.Nombre %>
                    </span>
                </a>
                <br />
                <span>
                    <b>Precio: </b><%#:Item.Presentacion %>
                </span>
                <br />
                <span>
                    <b>Costo: </b><%#:String.Format("{0:c}",Item.CostoUnitario) %>
                </span>
                <br />

            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="groupPlaceholderContainer" runat="server" style="width:100%;"
                class="table table-striped table-responsive-sm table-responsive-md table-hover table-bordered">
                <tr id="groupPlaceholder">

                </tr>

            </table>
        </LayoutTemplate>      
    </asp:ListView>
</asp:Content>
