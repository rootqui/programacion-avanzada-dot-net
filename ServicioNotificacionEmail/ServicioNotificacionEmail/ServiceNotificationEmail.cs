using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading;
using System.Timers;
using System.Configuration;

namespace ServicioNotificacionEmail
{
    public partial class ServiceNotificationEmail : ServiceBase
    {
        private FileSystemWatcher fileSystemWatcher;

        String emailOrigen = "rr.tz.test94@outlook.com";
        String emailDestino = "rr.tz.test94@outlook.com";
        String password = ConfigurationManager.AppSettings["password"];
        String directorioOrigen = @"D:\Isur\Cursos2023-2\ProgramacionAvanzadaDotNet\Ejercicios\Trabajo";
        String directorioDestino = @"D:\Isur\Cursos2023-2\ProgramacionAvanzadaDotNet\Ejercicios\Backup";
        int tamanioAnterior = 0;
        LinkedList<String> log = new LinkedList<string>();
        private static System.Timers.Timer aTimer;

        public ServiceNotificationEmail()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {
            fileSystemWatcher = new FileSystemWatcher(directorioOrigen);
            fileSystemWatcher.Filter = "*.*";

            fileSystemWatcher.Changed += new FileSystemEventHandler(OnFileActions);
            fileSystemWatcher.Renamed += new RenamedEventHandler(OnFileActions);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(OnFileActions);


            fileSystemWatcher.EnableRaisingEvents = true;

            
            EventLog.WriteEntry("ServiceNotificationEmailLog", "El servico se ha iniciado");

            Thread background = new Thread(new ThreadStart(this.SetTimer));
            background.Start();

        }

        protected override void OnStop()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Dispose();
            EventLog.WriteEntry("ServiceNotificationEmailLog", "El servico se ha detenido");
        }

        private void OnFileActions(object sender, FileSystemEventArgs e)
        {
            try
            {
                DateTime localDate = DateTime.Now;
                String timestamp = localDate.ToString("[dd/MM/yyyy HH:mm:ss] ");
                String msg = "";
                string destino = Path.Combine(directorioDestino, e.Name);
                Thread.Sleep(1000);

                if (e.ChangeType == WatcherChangeTypes.Renamed || e.ChangeType == WatcherChangeTypes.Changed)
                {                   
                    File.Copy(e.FullPath, destino, true);
                    msg = e.ChangeType.ToString() + " Archivo copiado " + destino;                    
                }

                if (e.ChangeType == WatcherChangeTypes.Deleted)
                {
                    msg = e.ChangeType.ToString() + " Archivo eliminado " + destino;
                }

                if (!string.IsNullOrEmpty(msg))
                {
                    timestamp += msg;                
                    log.AddLast(timestamp);
                    EventLog.WriteEntry("ServiceNotificationEmailLog", timestamp);
                }

            }
            catch(Exception ex)
            {
                EventLog.WriteEntry("ServiceNotificationEmailLog", "Error al copiar el archivo " + Path.Combine(directorioDestino, Path.GetFileName(e.FullPath)) + ex.Message, EventLogEntryType.Error);
            }
        }


        public void enviarNotificacion(string emailOrigen, string emailDestino, string titulo, string mensaje, string password)
        {
            MailMessage mailMessage = new MailMessage(emailOrigen, emailDestino, titulo, mensaje);

            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.office365.com");

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(emailOrigen, password);

            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
        }

        private String reporte(LinkedList<string> collection)
        {
            String log = "";
            
            foreach (string l in collection)
            {
                log += "<p>" + l + "</p>";
            }

            return log;
        }


        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);            
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            String data = reporte(log);
            if (data.Length > 0 && tamanioAnterior < data.Length)
            {
                tamanioAnterior = data.Length;
                enviarNotificacion(emailOrigen, emailDestino, "Servicio Email", data, password);
            }
        }
    }
}
