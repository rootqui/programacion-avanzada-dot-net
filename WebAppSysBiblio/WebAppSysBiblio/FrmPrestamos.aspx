<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="FrmPrestamos.aspx.cs" Inherits="WebAppSysBiblio.FrmPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Libros Prestados</h2>
    <br />
    <asp:GridView ID="gvPrestamos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="Fecha_Prestamo" HeaderText="Fecha del Préstamo" SortExpression="Fecha_Prestamo" />
            <asp:BoundField DataField="Nombre_Completo" HeaderText="Nombre Completo" SortExpression="Nombre_Completo" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
            <asp:BoundField DataField="Correo_Electronico" HeaderText="Correo Electrónico" SortExpression="Correo_Electronico" />
            <asp:BoundField DataField="Titulo" HeaderText="Título del Libro" SortExpression="Titulo" />
            <asp:BoundField DataField="Autor" HeaderText="Autor del Libro" SortExpression="Autor" />
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

</asp:Content>
