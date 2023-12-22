using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DemoWPF231020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var op = new DbContextOptionsBuilder<AppDBContext>()
            .UseSqlServer("Data Source=.;Initial Catalog=pruebaWPF;Integrated Security=True;TrustServerCertificate=true")
            .Options;
            using (var dbcontext = new AppDBContext(op))
            {
                var users = dbcontext.GetUsersSP();                
                foreach (var user in users)
                {
                    if (user.Usuario == txtUsuario.Text && user.Clave == txtClave.Password)
                    {
                        MessageBox.Show("usuario ok");
                    }
                }

            }
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            var op = new DbContextOptionsBuilder<AppDBContext>()
             .UseSqlServer("Data Source=.;Initial Catalog=pruebaWPF;Integrated Security=True;TrustServerCertificate=true")
             .Options;
            using (var dbcontext = new AppDBContext(op))
            {
                String usuario = txtUsuario.Text;
                String clave = txtClave.Password;
                if (!usuario.IsNullOrEmpty() && !clave.IsNullOrEmpty() && Regex.IsMatch(usuario, @"^[a-zA-Z ]+$"))
                {
                    dbcontext.InsertUserSP(usuario, clave);
                    MessageBox.Show("Registro insertado");
                }
                else
                {
                    MessageBox.Show("Solo se permiten letras en el usuario, ni valores en blanco");
                }

            }
        }
    }

    public class AppDBContext: DbContext
    {
        
        public DbSet<User> Users { get; set; }  
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            
        }

        public IList<User> GetUsersSP()
        {
            var users = new List<User>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select_usuarios";
                command.CommandType = System.Data.CommandType.StoredProcedure;                
                
                this.Database.OpenConnection();
                
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var user = new User();
                        {
                            user.Id = result.GetInt32(0);
                            user.Usuario = result.GetString(1);
                            user.Clave = result.GetString(2);
                        }

                        users.Add(user);
                    }
                }
            }


            return users;
        }


        public void InsertUserSP(String usuario, String clave)
        {
           
            this.Database.OpenConnection();

            this.Database
                .ExecuteSqlInterpolated($"exec insertar_usuario @usuario={usuario}, @clave={clave}");

        } 

    }

    public class User
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }


}
