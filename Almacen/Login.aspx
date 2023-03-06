<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Almacen.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h4 style="font-size:medium">Iniciar Sesion</h4>
    <hr />
    <asp:PlaceHolder ID="LoginStatus" Visible="false" runat="server">
    <p>
        <asp:Literal ID="StatusText" runat="server"></asp:Literal>
    </p>
    </asp:PlaceHolder>
    <div id="LoginForm">
        <div style="margin-bottom:10px">

            <asp:Label AssociatedControlID="UserName" runat="server">Usuario</asp:Label>
         <div>
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        </div>
    </div>

        <div style="margin-bottom:10px">
            <asp:Label  runat="server" AssociatedContolID="Password">Password</asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        
        </div>


         <div style="margin-bottom:10px">
             <asp:Button ID="Iniciar_Sesion" runat="server" Text="Iniciar Sesion" OnClick="Iniciar_Sesion_Click"/>
        </div>
</div>

</asp:Content>
