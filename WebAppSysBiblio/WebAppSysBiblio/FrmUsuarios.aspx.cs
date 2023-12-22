using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;

namespace WebAppSysBiblio
{
    public partial class FrmUsuarios : System.Web.UI.Page
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


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Value = "";
            txtApellido.Value = "";
            txtCorreoElectronico.Value = "";
            txtTelefono.Value = "";
        }

        void CargaDataGrid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlDataAdapter da = new SqlDataAdapter("SelectUsuarios", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Clear();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvUsuarios.DataSource = dt;
                    gvUsuarios.DataBind();
                }
            }
        }
       
        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = int.Parse(gvUsuarios.Rows[e.RowIndex].Cells[0].Text);
                if (Regex.Match(Convert.ToString(id), @"^[0-9]+$").Success)
                {
                    DeleteUsuarios(id);
                    CargaDataGrid();
                }
                else
                {
                    Response.Write("Entrada Incorrecta");
                }

            }
            catch (Exception ex) 
            {
                Response.Write(ex.ToString());
            }
        }

        protected void gvUsuarios_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {
                gvUsuarios.EditIndex = -1;
                CargaDataGrid();
            }
            else
            {
                gvUsuarios.EditIndex = 0;
                CargaDataGrid();
                Response.Write("Error : " + e.Exception.Message);
            }
        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsuarios.EditIndex = -1;
            CargaDataGrid();
        }

        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.NewValues["ID_Usuario"].ToString());
                string nombre = e.NewValues["Nombre"].ToString();
                string apellido = e.NewValues["Nombre"].ToString();
                string correo = e.NewValues["Correo_Electronico"].ToString();
                string telefono = e.NewValues["Telefono"].ToString();

                bool validationId = Regex.IsMatch(Convert.ToString(id), @"^[0-9]+$");
                bool validationNombre = Regex.IsMatch(nombre, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationApellido = Regex.IsMatch(apellido, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationCorreo = Regex.IsMatch(correo, @"^[a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,15})$");
                bool validationTelefono = Regex.IsMatch(telefono, @"^[0-9]+$");

                if (validationId && validationNombre && validationApellido && validationCorreo && validationTelefono) 
                {
                    UpdateUsuarios(id, nombre, apellido, correo, telefono);
                    gvUsuarios.EditIndex = -1;
                    CargaDataGrid();                 
                }
                else
                {
                    Response.Write("Entrada Incorrecta");
                }

            }
            catch (Exception ex) 
            {
                Response.Write(ex.Message.ToString());
            }
        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsuarios.EditIndex = e.NewEditIndex;
            CargaDataGrid();
        }

        

        private void InsertUsuarios(string nombre, string apellido, string correo, string telefono){
            using (SqlConnection conn = new SqlConnection(cs)) 
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "InsertUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Correo_Electronico", correo);
                cmd.Parameters.AddWithValue("@Telefono", telefono);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Un nuevo usuario se agrego");
                CargaDataGrid();

            }
        }


        private void UpdateUsuarios(int id, string nombre, string apellido, string correo, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Usuario", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Correo_Electronico", correo);
                cmd.Parameters.AddWithValue("@Telefono", telefono);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("Un usuario se actualizo");

            }
        }

        private void DeleteUsuarios(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Usuario", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Un usuario se elimino");
            }
        }



        protected void btnInsertUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Value.ToString();
                string apellido = txtApellido.Value.ToString();
                string correo = txtCorreoElectronico.Value.ToString();
                string telefono = txtTelefono.Value.ToString();

                bool validationNombre = Regex.IsMatch(nombre, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationApellido = Regex.IsMatch(apellido, @"^[a-zA-Z-àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+$");
                bool validationCorreo = Regex.IsMatch(correo, @"^[a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,15})$");
                bool validationTelefono = Regex.IsMatch(telefono, @"^[0-9]+$");

                if (validationNombre && validationApellido && validationCorreo && validationTelefono)
                {
                    InsertUsuarios(nombre, apellido, correo, telefono);
                    CargaDataGrid();
                }
                else
                {
                    Response.Write("Entrada Incorrecta");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

    }
}