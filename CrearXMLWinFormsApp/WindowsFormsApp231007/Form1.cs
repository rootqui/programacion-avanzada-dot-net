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
using System.Xml;
namespace WindowsFormsApp231007
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createXML_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlElement = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(xmlElement);

            //XmlElement childElement = xmlDoc.CreateElement("Child");
            //childElement.InnerText = "Hello, XML";
            //childElement.SetAttribute("Nombres", "Juan");
            //childElement.SetAttribute("Apellidos", "Flores");

            //xmlElement.AppendChild(childElement);

            //xmlDoc.Save(@"D:\Isur\Cursos2023-2\ProgramacionAvanzadaDotNet\Labs\WindowsFormsApp231007\WindowsFormsApp231007\prueba.xml");

            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Pachacamac;Integrated Security=True");
            DataSet ds = new DataSet();
            SqlDataAdapter dabasedatos = new SqlDataAdapter("select * from categorias", sqlConnection);
            dabasedatos.Fill(ds, "categorias");
            XmlElement xmlRoot = xmlDoc.CreateElement("Categorias");
            foreach (DataRow r in ds.Tables["categorias"].Rows)
            {
                XmlElement childElement = xmlDoc.CreateElement("Categoria");
                childElement.SetAttribute("Id", r["Id"].ToString());
                childElement.SetAttribute("Nombre", r["Nombre"].ToString());
                childElement.SetAttribute("ArchivoImagen", r["ArchivoImagen"].ToString());
                xmlElement.AppendChild(childElement);

                //listaCampos.Add(r["name"].ToString());
            }

            xmlDoc.Save(@"D:\Isur\Cursos2023-2\ProgramacionAvanzadaDotNet\Labs\WindowsFormsApp231007\WindowsFormsApp231007\categorias.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Pachacamac;Integrated Security=True");
            //DataSet ds = new DataSet();
            //SqlDataAdapter dabasedatos = new SqlDataAdapter("select dbid,name from sys.sysdatabases", sqlConnection);
            //dabasedatos.Fill(ds, "categorias");
            //cbBaseDatos.DataSource = ds.Tables["categorias"];

        }
    }
}
