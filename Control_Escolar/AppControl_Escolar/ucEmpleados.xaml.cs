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
    /// Interaction logic for ucEmpleados.xaml
    /// </summary>
    public partial class ucEmpleados : UserControl
    {
        
        private WPrincipal wP;
        private DataGrid dg;
        private DataSet dss;
        private int acceso;
        public ucEmpleados(WPrincipal wP)
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

                this.dg = dgEmpleados;
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
                if (!cargarDatos()) { cbPuesto.Text = string.Empty; cargarDatos(); }
                if (cbPuesto.Text == string.Empty)
                {
                    MessageBox.Show("Ningun filtro aplicado", "Notificacion");
                }
            };
            btnEliminar.Click += (s, e) => {
               
                if (txtId.Text != "#")
                {
                    if (acceso >= 2)
                    {
                        wP.wsE.DELETE_Empleado(Int32.Parse(txtId.Text)); cargarDatos();
                        MessageBox.Show("Eliminacion efectuada", "Notificación");
                    }
                    else
                    {
                        MessageBox.Show("Necesitas un nivel de acceso mas alto");
                    }
                   
                }
                else mensaje1();
            };
            btnInformacion.Click += (s, e) => {
                string m = string.Empty;
                if (txtId.Text != "#")
                {
                    if (acceso >= 2)
                    {
                        DataSet _dataSet = wP.wsE.SELECT_IEmpleado(Int32.Parse(txtId.Text));
                        if (_dataSet != null)
                        {
                            DataRow dataRow = _dataSet.Tables[0].Rows[0];
                            for (int i = 0; i < _dataSet.Tables[0].Columns.Count; i++)
                            {
                                m += _dataSet.Tables[0].Columns[i].ColumnName + ": " + dataRow[i].ToString() + Environment.NewLine;

                            }
                            MessageBox.Show(m, "Informacion");
                        }
                        else MessageBox.Show("Error desconocido", "Error");
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
                if (acceso >= 2)
                {
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucIU_Empleado(wP, "Insertar", null));
                }
                else
                {
                    MessageBox.Show("Necesitas un nivel de acceso mas alto");
                }

               


            };
            btnActualizar.Click += (s, e) => {
                if (txtId.Text != "#")
                {
                    if (acceso >= 2)
                    {
                        wP.gPrincipal.Children.Clear();
                        wP.gPrincipal.Children.Add(new ucIU_Empleado(wP, "Actualizar", Int32.Parse(txtId.Text)));
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
            MessageBox.Show("Se requiere de un Id de una empleado para continuar, seleccione un registro", "Notificacion");
        }
        public void cargarComboBox()
        {
            cbPuesto.Items.Add("Todos");            
           
            foreach (DataRow item in wP.wsE.SELECT_Puesto().Tables[0].Rows)
                if(!(item[1].ToString()=="Profesor"))
                cbPuesto.Items.Add(item[1].ToString());
        }

        public bool cargarDatos()
        {
            DataSet ds;
            ds = wP.wsE.SELECT_Empleado(Numero(tbID.Text), tbBuscar.Text, ((cbPuesto.Text == "Todos") ? string.Empty : cbPuesto.Text));
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
