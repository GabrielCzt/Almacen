<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Almacen.Almacen.ClienteWeb.Ventas"  Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center mb-3">
        <p id="busqueda">Venta de un Producto</p>
    </div>
    <div class="mb-2">
        <label id="bid" class="form-label" for="TextBox1">Seleccione Id del Producto</label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
    </div>
    <div class="mb-0">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <br />
    <hr />
    <div class="container">
        <div class="row border mb-2">
            <div class="col-sm-12 col-md-12">
                <asp:Label ID="Label2" runat="server" Text="Label">
                </asp:Label> &nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="50"></asp:TextBox>
            </div>
        </div>
        <div class="row border border-warning">
            <div class="col-sm-6 col-md-6 mt-3">
                <div class="card text-dark bg-light mb-3" style="max-width:18rem;">
                    <div class="card-header text-center">Precio Mayoreo</div>
                    <div class="card-body text-center">
                        <asp:RadioButton ID="RadioButton1" runat="server" />
                    </div>
                </div>
            </div>

             <div class="col-sm-6 col-md-6 mt-3">
                <div class="card text-dark bg-light mb-3" style="max-width:18rem;">
                    <div class="card-header text-center">Precio Menudeo</div>
                    <div class="card-body text-center">
                        <asp:RadioButton ID="RadioButton2" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row border border-warning">
            <div class="col-sm-12 col-md-12 mt-3">
                <div class="card text-dark bg-light mb-3" style="max-width:18rem;">
                    <div class="card-header text-center">Descuento 20%</div>
                    <div class="card-body text-center">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row border border-warning mt-2">
            <div class="col-sm-12 col-md-12">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-sm-12 col-md-12">
                <asp:Button ID="Button1" runat="server" Text="Button"  CssClass="btn-outline-warning"
                    OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Button"  CssClass="btn-outline-warning" OnClick="Button2_Click"/>
            </div>
        </div>

    </div>
    <%--Ventana Modal--%>

    <div class="modal fade" id="Pregunta" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header mx-auto">
                    <h6 class="modal-title" style="color:blue" id="exampleModalLabel">Pregunta</h6>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row mt-2">
                            <div class="col-sm-12 col-md-12 d-flex justify-content-center align-items-center">
                                <p class="text-primary text-center ms-2">¿Desea registrar la venta?</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button3" runat="server" Text="Registrar" Style="font-size:small" CssClass="btn btn-outline-primary"
                         OnClick="Button3_Click"/>&nbsp;
                        &nbsp; <button type="button" class="btn btn-outline-primary" style="font-size:small" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
