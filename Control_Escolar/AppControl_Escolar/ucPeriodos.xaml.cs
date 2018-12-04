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
    /// Interaction logic for ucPeriodos.xaml
    /// </summary>
    public partial class ucPeriodos : UserControl
    {

        WPrincipal wP;
        string idPeriodo;
        public ucPeriodos(WPrincipal wP)
        {
            this.wP = wP;
            InitializeComponent();
            cargarDatos(dgPeriodos);
            eventos();
            inicializarCB();


        }

        private void eventos()
        {

            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));
            };
            rbActualizar.Checked += (s,e) => { RBChecked(s as RadioButton); };
            rbAgregar.Checked += (s, e) => { RBChecked(s as RadioButton); };
            dgPeriodos.SelectionChanged += (s, e) => {
                if (dgPeriodos.Items.Count > 0 && dgPeriodos.SelectedItem != null)
                {
                    idPeriodo = ((DataRowView)dgPeriodos.SelectedItem)[0].ToString();
                    infoPeriodo();
                }

                else
                    idPeriodo = "#";
            };
            btnIU.Click += (s, e) =>
            {
                jalarDatos();


            };

        }
        private void RBChecked(RadioButton rb)
        {
            if (rb == rbActualizar)
            {
                btnIU.Content = "Actualizar";
                tbId.Visibility = Visibility.Visible;
              
                

            }
            else {
                inicializarCB();
                btnIU.Content = "Agregar";
                tbId.Visibility = Visibility.Collapsed;

            }
            spIU.Visibility = Visibility.Visible;
        }


        public void infoPeriodo() {
        
                DataSet ds = wP.wssc.SELECT_Periodo(idPeriodo);
                tbId.Text = idPeriodo;
                string[] auxFecha_inicio = (ds.Tables[0].Rows[0]["Fecha_inicio"].ToString()).Split(' ');
                string[] Fecha_inicio = auxFecha_inicio[0].Split('/');
                cbFi_d.SelectedItem = Fecha_inicio[1];
                cbFi_m.SelectedItem = Fecha_inicio[0];
                cbFi_a.SelectedItem = Fecha_inicio[2];

                string[] auxFecha_fin = (ds.Tables[0].Rows[0]["Fecha_Fin"].ToString()).Split(' ');
                string[] Fecha_fin = auxFecha_fin[0].Split('/');
                cbFf_d.SelectedItem = Fecha_fin[1];
                cbFf_m.SelectedItem = Fecha_fin[0];
                cbFf_a.SelectedItem = Fecha_fin[2];
            

        }

        public bool cargarDatos(DataGrid dg)
        {
            DataSet ds;

            if ((ds = wP.wssc.SELECT_Periodo("")) == null)
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
        public void inicializarCB()
        {
            llenarCB(cbFf_a,2010,2030);
            llenarCB(cbFf_m, 1, 12);
            llenarCB(cbFf_d, 1, 31);
            llenarCB(cbFi_a, 2010, 2030);
            llenarCB(cbFi_m, 1, 12);
            llenarCB(cbFi_d, 1, 31);

        }
        public void llenarCB(ComboBox cb, int inicio, int fin)
        {
            if(cb.Items.Count>0) cb.Items.Clear();
            for (int i = inicio; i <= fin; i++) cb.Items.Add(i.ToString());

           // cb.SelectedItem = inicio.ToString();

        }
        public bool validadCb(ComboBox cb)
        {

            if (cb.SelectedItem == null || cb.SelectedItem.ToString() == string.Empty)
                return false;
            return true;

        }


        public void jalarDatos()
        {
            
            if (validadCb(cbFi_a) && validadCb(cbFi_m) && validadCb(cbFi_d) && (validadCb(cbFf_a) && validadCb(cbFf_m) && validadCb(cbFf_d)))
            {

                string Fecha_inicio = cbFi_a.SelectedItem.ToString() +
                               "-" + cbFi_m.SelectedItem.ToString() +
                               "-" + cbFi_d.SelectedItem.ToString();
                string Fecha_fin = cbFf_a.SelectedItem.ToString() +
                       "-" + cbFf_m.SelectedItem.ToString() +
                       "-" + cbFf_d.SelectedItem.ToString();

                if (btnIU.Content.ToString() != "Agregar")
                {
                    try
                    {

                        wP.wssc.UPDATE_Periodo(Int32.Parse(idPeriodo) , Fecha_inicio, Fecha_fin);
                        cargarDatos(dgPeriodos);
                        MessageBox.Show("Listo", "Notificacion");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al actualizar", "Error");
                    }


                }
                else
                {
                    try
                    {
                        wP.wssc.INSERT_Periodo(Fecha_inicio, Fecha_fin);
                        cargarDatos(dgPeriodos);
                        MessageBox.Show("Listo", "Notificacion");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al insertar", "Error");
                    }

                }

            }
            else
            {
                MessageBox.Show("Debera llenar todos los campos", "[Error]");
            }


        }

    }
}
