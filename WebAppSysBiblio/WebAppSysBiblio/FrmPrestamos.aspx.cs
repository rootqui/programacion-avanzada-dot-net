using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSysBiblio
{
    public partial class FrmPrestamos : System.Web.UI.Page
    {
        String cs = "Data Source=.;Initial Catalog=Biblioteca;Integrated Security=True";
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaDataGrid();
            }
        }

        void CargaDataGrid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlDataAdapter da = new SqlDataAdapter("SelectPrestamos", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Clear();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvPrestamos.DataSource = dt;
                    gvPrestamos.DataBind();
                }
            }
        }
    }
}