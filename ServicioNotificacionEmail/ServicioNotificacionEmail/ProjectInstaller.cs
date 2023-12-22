using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;

namespace ServicioNotificacionEmail
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            serviceInstaller.ServiceName = "ServiceBackup";
            serviceInstaller.DisplayName = "ServiceBackup v1.0";
            serviceInstaller.Description = "Esto es un servicio que realiza backup";
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.StartType = ServiceStartMode.Manual;

            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
