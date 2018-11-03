using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppControl_Escolar
{
    /// <summary>
    /// Interaction logic for WPrincipal.xaml
    /// </summary>
    public partial class WPrincipal : Window
    {
        private Boolean Normal = false;
        public WSControl_Escolar_Reference.WSControl_EscolarSoapClient wssc = new WSControl_Escolar_Reference.WSControl_EscolarSoapClient();
        public int IdUsuario;
        
        
        public WPrincipal()
        {
            InitializeComponent();
            if (!wssc.conexionMysql())
                if (MessageBox.Show("No hay conexion con mysql", " [ Error ]",MessageBoxButton.OK) == MessageBoxResult.OK)
                    Application.Current.Shutdown();
                

            if (!wssc.conexionDataBase())                
            if (MessageBox.Show("No existe la base de datos!", " [ Error ]", MessageBoxButton.OK) == MessageBoxResult.OK)
                Application.Current.Shutdown();

                
                gPrincipal.Children.Add(new ucLog(this));
                
            eventos();
            


        }

        private void eventos() {
            btnCerrar.Click += (s, e) => {
                Application.Current.Shutdown();
            };
            btnMax.Click += (s, e) => {
                if (Normal) { this.WindowState = WindowState.Normal; Normal = false; }
                else
                {
                    this.WindowState = WindowState.Maximized; Normal = true;

                }
            };
            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };

            rPrincipal.MouseDown += (s, e) => {
                this.DragMove();
            };
            btnCuenta.Click += (s, e) => {
                if (MessageBox.Show("¿Desea cerrar sesion?", "Sesion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    btnCuenta.IsEnabled = false;
                    gPrincipal.Children.Clear();
                    gPrincipal.Children.Add(new ucLog(this));
                }
            };
        }
    }
}
