using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Practica231013
{
    public partial class Form1 : Form
    {
        int i = 1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public static String ExecuteServer()
        {
            //MessageBox.Show("iniciando conexion ...");
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 5000);

            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);
            

            try
            {

               
                listener.Bind(localEndPoint);

                listener.Listen(10);

                Console.WriteLine("Waiting connection ... ");


                Socket clientSocket = listener.Accept();
                   

                byte[] bytes = new Byte[1024];
                String data = null;

                String data2 = decodificarData(data, clientSocket, bytes);

                //Console.WriteLine("Text received -> {0} ", data);
                //byte[] message = Encoding.ASCII.GetBytes("Test Server");

                //clientSocket.Send(message);

                clientSocket.Shutdown(SocketShutdown.Both);
                
                clientSocket.Dispose();
                clientSocket.Close();
                listener.Dispose();
                listener.Close();
                return data2;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "-1";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Label label = new Label();
            //label.Name = "test";            
            //label.Text = "Hola";

            //Form1.ActiveForm.Controls.Add(label);

            //MessageBox.Show("Data");

            //while (true)
            //{
            //    String data = ExecuteServer();
            //    if (data != "-1")
            //    {
            //        //MessageBox.Show("Mensaje recibido");                    
            //        Label label = new Label();
            //        label.Name = "test";
            //        label.Text = data;
            //        label.Location = new Point(0, i * 40);
            //        //LogMensajes.Visible = true;

            //        //label.ControlAdded((obj)=> this.Show=true);
            //        LogMensajes.Controls.Add(label);

            //        i++;
            //        //MessageBox.Show("Label Creado");
            //        //render(data);
            //    }
            //}

            server();

        }

        private void LogMensajes_ControlAdded(object sender, ControlEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static String decodificarData(String data, Socket clientSocket, byte[] bytes)
        {
            while (true)
            {

                int numByte = clientSocket.Receive(bytes);

                data += Encoding.ASCII.GetString(bytes,
                                           0, numByte);

                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            return data;
        }

        private async void server()
        {
            while (true)
            {
                Task<String> task = new Task<string>(ExecuteServer);
                task.Start();
                String data = await task;

                if (data != "-1")
                {
                    Label label = new Label();
                    label.Name = "test";
                    label.Text = data.Replace("<EOF>", "");
                    label.AutoSize = true;
                    label.Location = new Point(0, i * 40);
                    LogMensajes.Controls.Add(label);
                    i++;
                }
            }
        }
    }
}
