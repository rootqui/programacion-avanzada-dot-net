<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormTipoCambio.aspx.cs" Inherits="WebAppTipoCambio.FormTipoCambio" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Fecha inicial</h2>
        <div class="item">
            <p>Año</p>
            <select name="anio" id="SelectAnioInicio" runat="server" >
            </select>

            <p>Mes</p>
            <select name="mes" id="SelectMesInicio" runat="server">
            </select>
        </div>
        <h2>Fecha final</h2>
        <div class="item">
            <p>Año</p>
            <select name="anio" id="SelectAnioFin" runat="server">     
            </select>

            <p>Mes</p>
            <select name="mes" id="SelectMesFin" runat="server">
            </select>
        </div>

        <h2>Moneda</h2>
        <div class="item">            
            <select name="moneda" id="SelectMoneda" runat="server">                     
            </select>
        </div>

        <button id="BtnConsultar" runat="server">Consulta</button>
        <h4 id="TituloMoneda" runat="server"></h4>
        <div class="container" id="ContainerTable" runat="server"></div>
    </div>
</asp:Content>
