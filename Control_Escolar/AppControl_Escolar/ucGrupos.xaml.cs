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
    /// Interaction logic for ucGrupos.xaml
    /// </summary>
    public partial class ucGrupos : UserControl
    {

        private WPrincipal wP;
        private DataGrid dg;
        private int idPeriodo;
        private DataSet dsPeriodo;
        private DataSet dss;
        private int acceso;
        public ucGrupos(WPrincipal wP)
        {



            InitializeComponent();
            this.wP = wP;
            dss = wP.wssc.SELECT_Admin();
            if (dss == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                acceso = Int32.Parse(dss.Tables[0].Rows[0]["Admin"].ToString());
                this.dg = dgGrupos;
                cargarComboBox();
                cargarDatos();
                eventos();
            }
        }


        public void eventos()
        {
            dg.SelectionChanged += (s, e) => {
                //if()
                if (dg.Items.Count > 0 && dg.SelectedItem != null)
                    txtId.Text = ((DataRowView)dg.SelectedItem)[0].ToString();

                else
                    txtId.Text = "#";
            };
            tbID.TextChanged += (s, e) => { if (!cargarDatos()) tbID.Text = string.Empty; };
            tbBuscar.TextChanged += (s, e) => { if (!cargarDatos()) tbBuscar.Text = string.Empty; };

            btnFiltrar.Click += (s, e) => {
                if (!cargarDatos()) { cbPeriodo.Text = string.Empty; cargarDatos(); }
                if (cbPeriodo.Text == string.Empty)
                {
                    MessageBox.Show("Ningun filtro aplicado", "Notificacion");
                }
            };
            btnEliminar.Click += (s, e) => {
                if (txtId.Text != "#")
                {

                    if (acceso >= 1)
                    {
                        wP.wsG.DELETE_Grupo(Int32.Parse(txtId.Text)); cargarDatos();
                        MessageBox.Show("Eliminacion efectuada", "Notificación");
                    }
                    else
                    {
                        MessageBox.Show("Necesitas un nivel de acceso mas alto");
                    }
                   
                }
                else mensaje1();
            };
           
            btnCancelar.Click += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));

            };
            btnNuevo.MouseDown += (s, e) => {
                if (acceso >= 1)
                {
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucIU_Grupo(wP, "Insertar", null));
                }
                else
                {
                    MessageBox.Show("Necesitas un nivel de acceso mas alto");
                }

               


            };
            btnActualizar.Click += (s, e) => {
                if (txtId.Text != "#")
                {
                    if (acceso >= 1)
                    {
                        wP.gPrincipal.Children.Clear();
                        wP.gPrincipal.Children.Add(new ucIU_Grupo(wP, "Actualizar", Int32.Parse(txtId.Text)));
                    }
                    else
                    {
                        MessageBox.Show("Necesitas un nivel de acceso mas alto");
                    }
                  
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
            cbPeriodo.Items.Add("Todos");
            dsPeriodo = wP.wssc.SELECT_Periodo("");

            foreach (DataRow item in dsPeriodo.Tables[0].Rows)                
                    cbPeriodo.Items.Add(item["Fecha_inicio"].ToString() +" - "+item["Fecha_fin"].ToString());
        }      

        public int buscarEnCB_XD(DataSet ds, ComboBox cb,  string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item["Fecha_inicio"].ToString() + " - " + item["Fecha_fin"].ToString()))
                        return Int32.Parse(item[que_cosa].ToString());
            return 0;
        }

        public bool cargarDatos()
        {
            
            DataSet ds = wP.wsG.SELECT_Grupo(Numero(tbID.Text), tbBuscar.Text, ((cbPeriodo.Text == "Todos") ? string.Empty : buscarEnCB_XD(dsPeriodo,cbPeriodo,"IdPeriodo").ToString()));
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