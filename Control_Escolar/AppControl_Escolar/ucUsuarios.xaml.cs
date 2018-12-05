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
    /// Interaction logic for ucUsuarios.xaml
    /// </summary>
    public partial class ucUsuarios : UserControl
    {
        private WPrincipal wP;
        private DataGrid dg;
        public ucUsuarios(WPrincipal wP)
        {

            InitializeComponent();
            this.wP = wP;
            this.dg = dgUsuario;
            cargarComboBox();
            cargarDatos();
            eventos();
        }

        public void eventos()
        {
            dg.SelectionChanged += (s, e) => {
                //if()
                if (dg.Items.Count > 0 && dg.SelectedItem != null)
                    txtId.Text = ((DataRowView)dg.SelectedItem)["ID"].ToString();

                else
                    txtId.Text = "#";
            };
            tbID.TextChanged += (s, e) => { if (!cargarDatos()) tbID.Text = string.Empty; };
            tbBuscar.TextChanged += (s, e) => { if (!cargarDatos()) tbBuscar.Text = string.Empty; };

            btnEliminar.Click += (s, e) => {
                if (txtId.Text != "#")
                {
                    wP.wsU.DELETE_Usuario(Int32.Parse(txtId.Text)); cargarDatos();
                    MessageBox.Show("Eliminacion efectuada", "Notificación");
                }
                else mensaje1();
            };
           
            btnCancelar.Click += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));

            };
            btnNuevo.MouseDown += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucIU_Usuario(wP, "Insertar", null));


            };
            btnActualizar.Click += (s, e) => {
                if (txtId.Text != "#")
                {
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucIU_Usuario(wP, "Actualizar", Int32.Parse(txtId.Text)));
                }
                else mensaje1();
            };



        }
        public void mensaje1()
        {
            MessageBox.Show("Se requiere de un Id para continuar, seleccione un registro", "Notificacion");
        }
        public void cargarComboBox()
        {


        }

        public bool cargarDatos()
        {
            DataSet ds;
            ds = wP.wsU.SELECT_Usuario(Numero(tbID.Text), tbBuscar.Text,tbUsuario.Text);
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

        #region "validaciones"
        public string Numero(string n)
        {

            if (n != string.Empty && int.TryParse(n, out int aux))
            {
                if ((aux = Int32.Parse(n)) >= 0 && aux <= 100000)
                    return aux.ToString();
                return string.Empty;
            }
            return string.Empty;

        }
        #endregion
    }
}

