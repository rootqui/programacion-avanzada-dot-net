using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSysBiblio
{
    public partial class FrmLibros : System.Web.UI.Page
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

        protected void gvLibros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLibros.EditIndex = -1;
            CargaDataGrid();
        }

        protected void gvLibros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = int.Parse(gvLibros.Rows[e.RowIndex].Cells[0].Text);
                bool validationId = Regex.IsMatch(Convert.ToString(id), @"^[0-9]+$");
                if (validationId)
                {
                    DeleteLibros(id);
                    CargaDataGrid();
                }
                else
                {
                    Response.Write("Entrada Incorrecta");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

        protected void gvLibros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLibros.EditIndex = e.NewEditIndex;
            CargaDataGrid();

        }

        protected void gvLibros_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {
                gvLibros.EditIndex = -1;
                CargaDataGrid();
            }
            else
            {
                gvLibros.EditIndex = 0;
                CargaDataGrid();
                Response.Write("Error : " + e.Exception.Message);
            }
        }

        protected void gvLibros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try 
            {
                int id = Convert.ToInt32(e.NewValues["ID_Libro"].ToString());
                string autor = e.NewValues["Autor"].ToString();
                string titulo = e.NewValues["Titulo"].ToString();
                string isbn = e.NewValues["ISBN"].ToString();
                int cantDisponible = Convert.ToInt32(e.NewValues["Cantidad_Disponible"].ToString());
                int cantTotal = Convert.ToInt32(e.NewValues["Cantidad_Total"].ToString());

                bool validationId = Regex.IsMatch(Convert.ToString(id), @"^[0-9]+$");
                bool validationAutor = Regex.IsMatch(autor, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationTitulo = Regex.IsMatch(titulo, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationISBN = Regex.IsMatch(isbn, @"^[0-9-]{17}$");            
                bool validationCantDisponible = Regex.IsMatch(Convert.ToString(cantDisponible), @"^[0-9]+$");
                bool validationCantTotal = Regex.IsMatch(Convert.ToString(cantTotal), @"^[0-9]+$");

                if (validationId && validationAutor && validationTitulo && validationISBN && validationCantDisponible && validationCantTotal) 
                {
                    UpdateLibros(id, titulo, autor, isbn, cantDisponible, cantTotal);
                    gvLibros.EditIndex = -1;
                    CargaDataGrid();
                }
                else
                {
                    Response.Write("Entrada Incorrecta");
                }

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

        void CargaDataGrid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlDataAdapter da = new SqlDataAdapter("SelectLibros", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Clear();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvLibros.DataSource = dt;
                    gvLibros.DataBind();
                }
            }
        }

        protected void btnInsertLibros_Click(object sender, EventArgs e)
        {
            try 
            {
                string titulo = txtTitulo.Value.ToString();
                string autor = txtAutor.Value.ToString();
                string isbn = txtISBN.Value.ToString();
                int cantDisponible = Convert.ToInt32(txtCantidadDisponible.Value.ToString());
                int cantTotal= Convert.ToInt32(txtCantidadTotal.Value.ToString());

                bool validationAutor = Regex.IsMatch(autor, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationTitulo = Regex.IsMatch(titulo, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationISBN = Regex.IsMatch(isbn, @"^[0-9-]{17}$");
                bool validationCantDisponible = Regex.IsMatch(Convert.ToString(cantDisponible), @"^[0-9]+$");
                bool validationCantTotal = Regex.IsMatch(Convert.ToString(cantTotal), @"^[0-9]+$");

                if (validationAutor && validationTitulo && validationISBN && validationCantDisponible && validationCantTotal)
                {
                    InsertLibros(titulo, autor, isbn, cantDisponible, cantTotal);
                    CargaDataGrid();
                }
                else
                {
                    Response.Write("Entrada Incorrecta");
                }

            }
            catch(Exception ex) 
            {
                Response.Write(ex.Message.ToString());
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTitulo.Value = "";
            txtAutor.Value = "";
            txtISBN.Value = "";
            txtCantidadDisponible.Value = "";
            txtCantidadTotal.Value = "";            
        }

        private void InsertLibros(string titulo, string autor, string isbn, int cantidadDisponible, int cantidadTotal)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "InsertLibros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Autor", autor);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Cantidad_Disponible", cantidadDisponible);
                cmd.Parameters.AddWithValue("@Cantidad_Total", cantidadTotal);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Un nuevo libro se agrego");
                CargaDataGrid();

            }
        }

        private void UpdateLibros(int id, string titulo, string autor, string isbn, int cantidadDisponible, int cantidadTotal)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateLibros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Libro", id);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Autor", autor);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Cantidad_Disponible", cantidadDisponible);
                cmd.Parameters.AddWithValue("@Cantidad_Total", cantidadTotal);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("Un libro se actualizo");

            }
        }

        private void DeleteLibros(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteLibros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Libro", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Un libro se elimino");
            }
        }

        protected void gvLibros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}