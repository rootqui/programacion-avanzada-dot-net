using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using WebAppTipoCambio.Entidades;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebAppTipoCambio
{
    public partial class FormTipoCambio : System.Web.UI.Page
    {
        Dictionary<string, string> tiposMoneda = new Dictionary<string, string>();
        

        protected async void Page_Load(object sender, EventArgs e)
        {
            tiposMoneda.Add("Dólar Americano", "PN01234PM");
            tiposMoneda.Add("Euro", "PN01235PM");
            tiposMoneda.Add("Yen", "PN01236PM");
            tiposMoneda.Add("Real Brasileño", "PN01237PM");
            tiposMoneda.Add("Libra Esterlina", "PN01238PM");
            tiposMoneda.Add("Peso Chileno", "PN01239PM");
            tiposMoneda.Add("Yuan Chino", "PN01240PM");
            tiposMoneda.Add("Peso Colombiano", "PN01241PM");
            tiposMoneda.Add("Peso Mexicano", "PN01242PM");
            tiposMoneda.Add("Franco Suizo", "PN01243PM");
            tiposMoneda.Add("Dólar Canadiense", "PN01244PM");



            if (!IsPostBack) {

                CargaListaAnios();
                CargaListaMeses();
                CargaListaMonedas(tiposMoneda.Keys.ToList());
                
            }
            
            BtnConsultar.ServerClick += BtnConsultar_ServerClick;
            
        }


        private async void BtnConsultar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                ContainerTable.InnerText = SelectAnioInicio.Value;
                ContainerTable.InnerText += " " + tiposMoneda[SelectMoneda.Value];

                String Codigo = tiposMoneda[SelectMoneda.Value];


                String PeriodoInicial = SelectAnioInicio.Value + "-" + SelectMesInicio.Value;

                String PeriodoFinal = SelectAnioFin.Value + "-" + SelectMesFin.Value;

                if (SelectAnioFin.Value == "" && SelectMesFin.Value == "")
                {
                    PeriodoFinal = PeriodoInicial;
                }

                String res = await ConsultarTipoCambio(Codigo, PeriodoInicial, PeriodoFinal);
            }
            catch (Exception ex)
            {
                Response.Write("Entradas incorrectas");
            }
            
        }

        private void CargaListaAnios()
        {
            SelectAnioInicio.Items.Add("");
            SelectAnioFin.Items.Add("");

            for (int anioInicio = 1992; anioInicio <= DateTime.Now.Year; anioInicio++)
            {
                SelectAnioInicio.Items.Add(anioInicio.ToString());
                SelectAnioFin.Items.Add(anioInicio.ToString());
            }
        }

        private void CargaListaMeses()
        {
            SelectMesInicio.Items.Add("");
            SelectMesFin.Items.Add("");

            for (int mesInicio = 1; mesInicio <= 12; mesInicio++)
            {
                SelectMesInicio.Items.Add(mesInicio.ToString());

                if (mesInicio < DateTime.Now.Month)
                {
                    SelectMesFin.Items.Add(mesInicio.ToString());
                }
            }
        }

        private void CargaListaMonedas(List<String> lista)
        {
            SelectMoneda.Items.Add("");

            foreach (string moneda in lista)
            {
                SelectMoneda.Items.Add(moneda);
            }
        }
    
        private String CrearTabla(List<clsPeriod> periodos)
        {
            String table = @"<table border='1'><tr><th>Fecha</th><th>Tipo de Cambio(S/ por UM)</th></tr>";
            foreach (var item in periodos)
            {
                table += String.Format("<tr><td>{0}</td> <td>{1}</td></tr>", item.name, item.values[0]);
            }

            table += "</table>";

            return table;
        }
        
        private async Task<String> ConsultarTipoCambio(String codigo, String inicio, String fin)
        {
            String url = String.Format("https://estadisticas.bcrp.gob.pe/estadisticas/series/api/{0}/json/{1}/{2}", codigo, inicio, fin);

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            

            if (response.IsSuccessStatusCode)
            {

                String responseString = await response.Content.ReadAsStringAsync();

                int index = responseString.IndexOf("<");

                responseString = responseString.Substring(0, index).Replace("\n", "");

                clsTiposCambio json = JsonConvert.DeserializeObject<clsTiposCambio>(responseString);

                TituloMoneda.InnerHtml = json.config.series[0].name;

                ContainerTable.InnerHtml = CrearTabla(json.periods);
                
                SelectAnioInicio.Value = "";
                SelectAnioFin.Value = "";
                SelectMesInicio.Value = "";
                SelectMesFin.Value = "";
                SelectMoneda.Value = "";

            }

            return response.StatusCode.ToString();

        }
    
    }

}