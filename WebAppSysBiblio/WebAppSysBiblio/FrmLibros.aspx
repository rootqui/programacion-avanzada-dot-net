<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="FrmLibros.aspx.cs" Inherits="WebAppSysBiblio.FrmLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Libros</h2>
    
    <div class="container row g-0 gy-1">                       
            <asp:Label ID="lblTitulo" runat="server" Text="Titulo"></asp:Label>
            <input ID="txtTitulo" class="form-control" type="text" runat="server" />

            <asp:Label ID="lblAutor" runat="server" Text="Autor"></asp:Label>
            <input ID="txtAutor" class="form-control" type="text" runat="server" />

            <asp:Label ID="lblISBN" runat="server" Text="ISBN"></asp:Label>
            <input ID="txtISBN" class="form-control" type="text" runat="server" />

            <asp:Label ID="lblCantidadDisponible" runat="server" Text="Cantidad Disponible"></asp:Label>
            <input ID="txtCantidadDisponible" class="form-control" type="text" runat="server" />
            
            <asp:Label ID="lblCantidadTotal" runat="server" Text="Cantidad Total"></asp:Label>
            <input ID="txtCantidadTotal" class="form-control" type="text" runat="server" />
    </div>
    
    <div class="my-3">
        <asp:Button ID="btnInsertLibros" runat="server" Text="Agregar" class="btn btn-primary mx-3" OnClick="btnInsertLibros_Click"/>
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-primary mx-3" OnClick="btnLimpiar_Click"/>
        <br />
        <br />
        <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCancelingEdit="gvLibros_RowCancelingEdit" OnRowDeleting="gvLibros_RowDeleting" OnRowEditing="gvLibros_RowEditing" OnRowUpdated="gvLibros_RowUpdated" OnRowUpdating="gvLibros_RowUpdating">
            <AlternatingRowStyle BackColor="#F7F7F7" />

            <Columns>
                <asp:BoundField DataField="ID_Libro" HeaderText="ID Libro" SortExpression="IdLibro" />
                <asp:BoundField DataField="Titulo" HeaderText="Título" SortExpression="Titulo" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" SortExpression="CantidadDisponible" />
                <asp:BoundField DataField="Cantidad_Total" HeaderText="Cantidad Total" SortExpression="CantidadTotal" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>

            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>
</asp:Content>
