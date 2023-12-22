<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="FrmCatalogo.aspx.cs" Inherits="WebAppSysBiblio.FrmCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Catálogo de Libros</h2>
    <br />

<asp:GridView ID="gvCatalogo" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:BoundField DataField="Titulo" HeaderText="Título" SortExpression="Titulo" />
        <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
        <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" SortExpression="Disponibilidad" />
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
