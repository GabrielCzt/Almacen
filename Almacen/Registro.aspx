<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Almacen.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4 style="font-size:medium">Registrar nuevo usuario:</h4>
        <hr />
        <p>
            <asp:Literal ID="StatusMessage" runat="server" ></asp:Literal>
        </p>
        <div  style="margin-bottom:10px">
            <asp:Label AssociatedControlID="Username" runat="server" >Usuario</asp:Label>
        <div>
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        </div>
      </div>

        <div style="margin-bottom:10px">
            <asp:Label AssociatedControlID="Password" runat="server" >Password</asp:Label>
            <div>
                <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
            </div>
        
        </div>

        <div style="margin-bottom:10px">
            <asp:Label AssociatedControlID="ConfirmPassword" runat="server" >Confirmar password</asp:Label>
            <div>
                <asp:TextBox ID="Confirmpassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div>
            <div>
                <asp:Button ID="Registrar_Usuario" runat="server" Text="Registrar" OnClick="Registrar_Usuario_Click"/>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
