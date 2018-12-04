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
using System.Data;

namespace AppControl_Escolar
{
    /// <summary>
    /// Interaction logic for ucAuditoria.xaml
    /// </summary>
    public partial class ucAuditoria : UserControl
    {
        private WPrincipal wP;
        private DataGrid dg;       

        public ucAuditoria(WPrincipal wP)
        {



            InitializeComponent();
            this.wP = wP;
            dg = dgA;
            cargarDatos();
            eventos();
        }


        public void eventos()
        {
           
            btnCancelar.Click += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));

            };



        }
       


        public bool cargarDatos()
        {

            DataSet ds = wP.wsAu.SELECT_Auditoria();
            if (ds == null)
            {

                ds = new DataSet();
                ds.Tables.Add(new DataTable());
                dg.ItemsSource = ds.Tables[0].DefaultView;
                dg.SelectedItem = null;
                MessageBox.Show("No hay resultados", "[Error]");
                return false;

                //ds.Tables[0].Rows.Add();                               
            }
            dg.SelectedItem = null;
            dg.ItemsSource = ds.Tables[0].DefaultView;
            return true;
        }

      
    }
}