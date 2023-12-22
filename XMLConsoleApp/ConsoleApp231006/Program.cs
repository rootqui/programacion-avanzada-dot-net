using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoSerializacion
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //// Serealizar
            //Curso micurso = new Curso();
            //micurso.id = 1;
            //micurso.name = "CTA";  
            //MemoryStream memorystream = new MemoryStream();
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(memorystream, micurso);                
            //byte[] bytes = memorystream.ToArray();

            //bytes.ToList().ForEach(b => Console.Write(b));  
            //Console.WriteLine();

            //// Desearilizar
            //MemoryStream memorystreamd = new MemoryStream(bytes);
            //BinaryFormatter bfd = new BinaryFormatter();
            //Curso deserealizar = bfd.Deserialize(memorystreamd) as Curso;
            //Console.WriteLine(deserealizar.ToString());            
            ////Console.ReadLine();

            //XmlSerializer x = new XmlSerializer(micurso.GetType());
            ////TextWriter writer = new StreamWriter("D:\\Isur\\Cursos2023-2\\ProgramacionAvanzadaDotNet\\Labs\\ConsoleApp231006\\ConsoleApp231006\\curso.xml");
            //x.Serialize(Console.Out, micurso);
            ////x.Serialize(writer, micurso);
            ////writer.Close();

            ////Deserealizar XML
            //FileStream fs = new FileStream("D:\\Isur\\Cursos2023-2\\ProgramacionAvanzadaDotNet\\Labs\\ConsoleApp231006\\ConsoleApp231006\\curso.xml", FileMode.Open);

            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //byte[] bytes = File.ReadAllBytes(@"D:\Isur\Cursos2023-2\ProgramacionAvanzadaDotNet\Labs\ConsoleApp231006\ConsoleApp231006\Persona.bin");
            //MemoryStream ms = new MemoryStream(bytes);
            //clsPersona P = (clsPersona)binaryFormatter.Deserialize(ms);


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(clsPersona));
            byte[] bytes = File.ReadAllBytes(@"D:\Isur\Cursos2023-2\ProgramacionAvanzadaDotNet\Labs\ConsoleApp231006\ConsoleApp231006\Persona.xml");
            MemoryStream ms = new MemoryStream(bytes);
            clsPersona P = (clsPersona)xmlSerializer.Deserialize(ms);
            Console.WriteLine(P.Name);
            Console.WriteLine(P.DNI);


            Console.ReadLine();




        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            byte[] bytes = File.ReadAllBytes(@"C:\Demos2023-2\DemoSerializacion\Persona.bin");
            MemoryStream ms = new MemoryStream(bytes);
            clsPersona P = (clsPersona)binaryFormatter.Deserialize(ms);
            //txtId.Text = P.Id.ToString();
            //txtNombres.Text = P.Name;
            //txtApellidos.Text = P.Apellido.ToString();
            //txtDNI.Text = P.DNI.ToString();




        }
    }

    [Serializable]
    public class Curso { 
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return "Curso id: " + id + 
                "\nnombre: " + name;
        }
    }

    [Serializable]
    public class clsPersona
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
    }
}
