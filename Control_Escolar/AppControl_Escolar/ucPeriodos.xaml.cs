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
    /// Interaction logic for ucPeriodos.xaml
    /// </summary>
    public partial class ucPeriodos : UserControl
    {

        WPrincipal wP;
        public ucPeriodos(WPrincipal wP)
        {
            this.wP = wP;
            InitializeComponent();
            eventos();
        }

        private void eventos()
        {

            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));
            };
            rbActualizar.Checked += (s,e) => { RBChecked(s as RadioButton); };
            rbAgregar.Checked += (s, e) => { RBChecked(s as RadioButton); };

        }
        private void RBChecked(RadioButton rb)
        {
            if (rb == rbActualizar)
            {
                btnIU.Content = "Actualizar";
                tbId.Visibility = Visibility.Visible;
                
            }
            else {
                btnIU.Content = "Agregar";
                tbId.Visibility = Visibility.Collapsed;

            }
            spIU.Visibility = Visibility.Visible;
        }

    }
}
