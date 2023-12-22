using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppWCF
{
    public partial class Form1 : Form
    {
        ServicePachacamac.Service1Client xwfc = new ServicePachacamac.Service1Client(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPachacamac.DataSource = xwfc.getCategorias();            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePachacamac.clsCategoria xnewcate = new ServicePachacamac.clsCategoria();
                xnewcate.Nombre = txtNombre.Text;
                xnewcate.Descrip = txtDescrip.Text;
                xnewcate.ArchivoImagen = txtArchivoImagen.Text;
                xwfc.insertCategorias(xnewcate);
                MessageBox.Show("Se inserto una categoria");
                dgvPachacamac.DataSource = null;
                dgvPachacamac.DataSource = xwfc.getCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescrip.Text = "";
            txtArchivoImagen.Text = "";
        }

        private void dgvPachacamac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dgvPachacamac.Rows[i];
            txtArchivoImagen.Text = row.Cells[0].Value.ToString();
            txtDescrip.Text = row.Cells[1].Value.ToString();
            txtNombre.Text = row.Cells[2].Value.ToString();
            txtId.Text = row.Cells[3].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {            
            try
            {
                ServicePachacamac.clsCategoria xnewcate = new ServicePachacamac.clsCategoria();
                xnewcate.id = Convert.ToInt32(txtId.Text);
                xnewcate.Nombre = txtNombre.Text;
                xnewcate.Descrip = txtDescrip.Text;
                xnewcate.ArchivoImagen = txtArchivoImagen.Text;
                xwfc.updateCategorias(xnewcate);
                MessageBox.Show("Se actualizo la categoria");
                dgvPachacamac.DataSource = null;
                dgvPachacamac.DataSource = xwfc.getCategorias();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {                
                int id = Convert.ToInt32(txtId.Text);
                xwfc.deleteCategorias(id);
                MessageBox.Show("Se elimino la categoria");
                dgvPachacamac.DataSource = null;
                dgvPachacamac.DataSource = xwfc.getCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
