using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button btnFirst = new Button();
        Button btnLast = new Button();
        Button btnPrevious = new Button();
        Button btnNext = new Button();
        LinkedList<DataRow> listaRegistros;
        List<String> listaCampos;
        LinkedListNode<DataRow> nodeReg;
        DataSet ds = new DataSet();
        SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Pachacamac;Integrated Security=True");
        SqlCommand sqlCommand;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dabasedatos = new SqlDataAdapter("select dbid,name from sys.sysdatabases", sqlConnection);
            dabasedatos.Fill(ds, "dbs");
            cbBaseDatos.DataSource = ds.Tables["dbs"];
            cbBaseDatos.DisplayMember = "name";
            cbBaseDatos.ValueMember = "dbid";
        }

        private void btnObtenerTablas_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Cast<DataTable>().Any(t => t.TableName == "tablas"))
            {
                ds.Tables.Remove("tablas");
            }

            SqlDataAdapter dabasedatos = new SqlDataAdapter("select object_id as id, name from " + cbBaseDatos.Text + ".sys.tables", sqlConnection);
            dabasedatos.Fill(ds, "tablas");
            cbTablas.DataSource = ds.Tables["tablas"];
            cbTablas.DisplayMember = "name";
            cbTablas.ValueMember = "id";
        }

        private void btnObtenerRegistros_Click(object sender, EventArgs e)
        {
            PanelRegistros.Controls.Clear();
            PanelRegistros.AutoSize = true;

            if (ds.Tables.Cast<DataTable>().Any(t => t.TableName == "campos"))
            {
                ds.Tables.Remove("campos");
            }

            SqlDataAdapter dabasedatos = new SqlDataAdapter("select colid, name from " + cbBaseDatos.Text + ".sys.syscolumns where id = " + cbTablas.SelectedValue + " order by colid", sqlConnection);
            dabasedatos.Fill(ds, "campos");

            listaCampos = new List<String>();
            foreach (DataRow r in ds.Tables["campos"].Rows)
            {
                listaCampos.Add(r["name"].ToString());
            }

            // db + esquema + nombre tabla
            string nombreTabla = "select TABLE_CATALOG + \'.\' + TABLE_SCHEMA + \'.\' + TABLE_NAME" +
                                " from " + cbBaseDatos.Text + ".INFORMATION_SCHEMA.TABLES" +
                                " where TABLE_NAME = \'" + cbTablas.Text + "\'";

            sqlConnection.Open();

            sqlCommand = new SqlCommand(nombreTabla, sqlConnection);
            SqlDataReader tabla = sqlCommand.ExecuteReader();
            tabla.Read();
            String nombreCompletoTabla = tabla.GetValue(0).ToString();
            tabla.Close();

            sqlConnection.Close();

            String todosCampos = String.Join(",", listaCampos);
            String query = "select " + todosCampos +
                            " from " + nombreCompletoTabla +
                            " order by " + listaCampos[0];

            if (ds.Tables.Cast<DataTable>().Any(t => t.TableName == "registros"))
            {
                ds.Tables.Remove("registros");
            }

            SqlDataAdapter da2 = new SqlDataAdapter(query, sqlConnection);
            da2.Fill(ds, "registros");



            listaRegistros = new LinkedList<DataRow>();

            foreach (DataRow r in ds.Tables["registros"].Rows)
            {
                listaRegistros.AddLast(r);
            }


            nodeReg = listaRegistros.First;
            String campo = "";

            for (int i = 0; i < listaCampos.Count; i++)
            {
                campo = listaCampos[i].ToString();
                Label l = new Label();
                l.Text = campo;
                l.Name = "l" + campo.ToString();
                PanelRegistros.Controls.Add(l);
                l.Location = new Point(5, i * 27);
                l.Visible = true;
            }

            poblarCampos(PanelRegistros, listaCampos, nodeReg);


            btnFirst.Click -= btnFirst_Click;
            btnPrevious.Click -= btnPrevious_Click;
            btnNext.Click -= btnNext_Click;
            btnLast.Click -= btnLast_Click;

            // Boton Primero
            btnFirst.Text = "Primero";
            btnFirst.Name = "btnFirst";
            PanelRegistros.Controls.Add(btnFirst);
            btnFirst.Location = new Point(5, 27 * (listaCampos.Count + 1));
            btnFirst.Visible = true;
            btnFirst.Click += new EventHandler(btnFirst_Click);

            // Boton Anterior
            btnPrevious.Text = "Anterior";
            btnPrevious.Name = "btnPrevious";
            PanelRegistros.Controls.Add(btnPrevious);
            btnPrevious.Location = new Point(100, 27 * (listaCampos.Count + 1));
            btnPrevious.Visible = true;
            btnPrevious.Click += new EventHandler(btnPrevious_Click);


            // Boton Siguiente          
            btnNext.Text = "Siguiente";
            btnNext.Name = "btnNext";
            PanelRegistros.Controls.Add(btnNext);
            btnNext.Location = new Point(195, 27 * (listaCampos.Count + 1));
            btnNext.Visible = true;
            btnNext.Click += new EventHandler(btnNext_Click);


            // Boton Ultimo
            btnLast.Text = "Ultimo";
            btnLast.Name = "btnLast";
            PanelRegistros.Controls.Add(btnLast);
            btnLast.Location = new Point(290, 27 * (listaCampos.Count + 1));
            btnLast.Visible = true;
            btnLast.Click += new EventHandler(btnLast_Click);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            eliminarControles<TextBox>(PanelRegistros);
            nodeReg = listaRegistros.First;
            poblarCampos(PanelRegistros, listaCampos, nodeReg);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            eliminarControles<TextBox>(PanelRegistros);
            nodeReg = listaRegistros.Last;
            poblarCampos(PanelRegistros, listaCampos, nodeReg);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            eliminarControles<TextBox>(PanelRegistros);

            if (nodeReg != null && nodeReg.Previous != null)
            {
                nodeReg = nodeReg.Previous;
                poblarCampos(PanelRegistros, listaCampos, nodeReg);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            eliminarControles<TextBox>(PanelRegistros);

            if (nodeReg != null && nodeReg.Next != null)
            {
                nodeReg = nodeReg.Next;
                poblarCampos(PanelRegistros, listaCampos, nodeReg);
            }
        }

        private void eliminarControles<T>(Control contenedor) where T : Control
        {
            foreach (Control item in contenedor.Controls.OfType<T>().ToList())
            {
                contenedor.Controls.Remove(item);
            }
        }

        private void poblarCampos(Control contenedor, List<String> lista, LinkedListNode<DataRow> node)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                String campo = lista[i].ToString();
                TextBox tb = new TextBox();
                tb.Name = "txt" + campo;
                tb.Text = node.Value[campo].ToString();
                contenedor.Controls.Add(tb);
                tb.Location = new Point(140, i * 27);
                tb.Visible = true;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();

                String res = "";
                List<String> listaValores = new List<string>();
                String tabla = cbTablas.Text;
                String valores = "";
                foreach (Control item in PanelRegistros.Controls)
                {
                    if (item is TextBox)
                    {
                        res = "'" + item.Text + "'";
                        listaValores.Add(res);
                    }
                }

                valores = String.Join(",", listaValores);

                String query = String.Format("INSERT INTO {0} VALUES({1})", tabla, valores);

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Registro insertado");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                String tabla = cbTablas.Text;
                List<String> lista = new List<string>();
                String valores = "";
                String id = "";

                int i = 0;
                foreach (Control item in PanelRegistros.Controls)
                {
                    String val = "";
                    if (item is TextBox)
                    {
                        if (i == 0)
                        {
                            id = listaCampos[i] + " = '" + item.Text + "'";
                        }
                        else
                        {
                            val = listaCampos[i] + " = '" + item.Text + "'";
                            lista.Add(val);
                        }

                        i++;
                    }
                }

                valores = String.Join(",", lista);

                String query = String.Format("UPDATE {0} SET {1} WHERE {2}", tabla, valores, id);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                String tabla = cbTablas.Text;
                String id = "";
                foreach (Control item in PanelRegistros.Controls)
                {
                    if (item is TextBox && item.Name.Replace("txt", "").Equals(listaCampos[0]))
                    {
                        id = listaCampos[0] + " = '" + item.Text + "'";
                        break;
                    }
                }

                String query = String.Format("DELETE FROM {0} WHERE {1}", tabla, id);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Registro eliminado");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control item in PanelRegistros.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";                                        
                }
            }
        }
    }
}
