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

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMensaje_Click(object sender, EventArgs e)
        {
            String msg = txtMensaje.Text; 
            ExecuteClient(msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void ExecuteClient(String msg)
        {

            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[1];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 5000);

                Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(localEndPoint);

                    byte[] messageSent = Encoding.ASCII.GetBytes(msg + "<EOF>");
                    sender.Send(messageSent);

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }


                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
