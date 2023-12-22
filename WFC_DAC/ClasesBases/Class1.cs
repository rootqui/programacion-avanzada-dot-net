using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBases
{
    public class clsCategoria
    {
        public int id { get; set; }
        public String Nombre { get; set; }
        public String Descrip { get; set; }
        public String ArchivoImagen { get; set; }

        public clsCategoria()
        {
        }
        public clsCategoria(int id, String nombre, String descrip, String archivoImagen)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Descrip = descrip;
            this.ArchivoImagen = archivoImagen;
        }
    }

    public class clsCategorias
    {

    }
}
