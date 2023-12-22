<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="WebAppSysBiblio.FrmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Usuarios</h2>
    
    <div class="container row g-0 gy-1">           
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <input ID="txtNombre" class="form-control" type="text" runat="server" />
            
            <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            <input ID="txtApellido" class="form-control" type="text" runat="server" />
            
            <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electronico"></asp:Label>
            <input ID="txtCorreoElectronico" class="form-control" type="text" runat="server" />             
            
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
            <input ID="txtTelefono" class="form-control" type="text" runat="server" /> 
    </div>
    
    <div class="my-3">
        <asp:Button ID="btnInsertUsuarios" runat="server" Text="Agregar" class="btn btn-primary mx-3" OnClick="btnInsertUsuarios_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-primary mx-3" OnClick="btnLimpiar_Click" />
        <br />
        <br />
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvUsuarios_RowCancelingEdit" OnRowDeleting="gvUsuarios_RowDeleting" OnRowEditing="gvUsuarios_RowEditing" OnRowUpdated="gvUsuarios_RowUpdated" OnRowUpdating="gvUsuarios_RowUpdating" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="ID_Usuario" HeaderText="ID Usuario" SortExpression="IdUsuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Correo_Electronico" HeaderText="Correo Electrónico" SortExpression="Correo_Electronico" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
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
    </div>
</asp:Content>
