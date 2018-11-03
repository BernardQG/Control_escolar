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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppControl_Escolar
{
    /// <summary>
    /// Interaction logic for ucPrincipal.xaml
    /// </summary>
    public partial class ucPrincipal : UserControl
    {
        public ucPrincipal(WPrincipal wP)
        {
            InitializeComponent();
            wP.btnCuenta.IsEnabled = true;
            
            
            gAlumnos.MouseDown += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucAlumnos(wP));
            };

            gPeriodo.MouseDown += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPeriodos(wP));

            };
        }
    }
}
