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
    /// Interaction logic for ucAlumnos.xaml
    /// </summary>
    public partial class ucAlumnos : UserControl
    {

        private WSControl_Escolar_Reference.WSControl_EscolarSoapClient wssc = new WSControl_Escolar_Reference.WSControl_EscolarSoapClient();
        private WPrincipal wP;
        public ucAlumnos(WPrincipal wP)
        {
            
            InitializeComponent();
            this.wP = wP;
            dgAlumnos.Items.Clear();
            cargarComboBox();



            cargarDatos();
            eventos();
        }

        public void eventos() {
            dgAlumnos.SelectionChanged += (s, e) => {
                //if()
                if (dgAlumnos.Items.Count > 0 && dgAlumnos.SelectedItem != null)
                    txtId.Text = ((DataRowView)dgAlumnos.SelectedItem)[0].ToString();

                else
                    txtId.Text = "#";
            };
            tbID.TextChanged += (s, e) => { if (!cargarDatos()) tbID.Text = string.Empty; };
            tbBuscar.TextChanged += (s, e) => { if (!cargarDatos()) tbBuscar.Text = string.Empty; };
            btnFiltrar.Click += (s, e) => { if (!cargarDatos()) { cbCarrera.Text = cbinscripcion.Text = cbPagado.Text = string.Empty; cargarDatos(); }
                if (cbCarrera.Text==string.Empty && cbPagado.Text ==string.Empty && cbinscripcion.Text==string.Empty) {
                    MessageBox.Show("Ningun filtro aplicado","Notificacion");
                }
            };
            btnEliminar.Click += (s, e) => {
                if (txtId.Text != "#")
                {
                    wssc.DELETE_Alumno(Int32.Parse(txtId.Text)); cargarDatos();
                    MessageBox.Show("Eliminacion efectuada", "Notificación");
                }
                else mensaje1();
            };
            btnInformacion.Click += (s, e) => {
                string m = string.Empty;
                if (txtId.Text != "#")
                {

                    DataSet _dataSet = wssc.SELECT_IAlumno(Int32.Parse(txtId.Text));
                    if (_dataSet != null)
                    {
                        DataRow dataRow = _dataSet.Tables[0].Rows[0];
                        for (int i = 0; i < _dataSet.Tables[0].Columns.Count; i++)
                        {
                            m += _dataSet.Tables[0].Columns[i].ColumnName + ": " + dataRow[i].ToString() + Environment.NewLine;

                        }
                        MessageBox.Show(m, "Informacion de un alumno");
                    }
                    else MessageBox.Show("Error desconocido","Error");
                }
                else mensaje1();
            };
            btnCancelar.Click += (s,e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));

            };
            btnNuevo.MouseDown += (s, e) => {
                
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucIU_Alumno(wP, ucIU_Alumno.Accion.INSERT, null));
             
                
            };
            btnActualizar.Click += (s, e) => {
                if (txtId.Text != "#")
                {
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucIU_Alumno(wP, ucIU_Alumno.Accion.UPDATE, Int32.Parse(txtId.Text)));
                }
                else mensaje1();
            };
            btnPadado.Click += (s, e) => 
            {
                if (txtId.Text != "#")
                {

                    if (((DataRowView)dgAlumnos.SelectedItem)["Pagado"].ToString() == "Si")
                        wssc.UPDATE_Inscripcion(Int32.Parse(txtId.Text), 0);
                    else
                        wssc.UPDATE_Inscripcion(Int32.Parse(txtId.Text), 1);

                    cargarDatos();
                    MessageBox.Show("Modificacion efectuada", "Notificación");
                }
                else mensaje1();

            };


        }
        public void mensaje1()
        {
            MessageBox.Show("Se requiere de un Id de una alumno para continuar, seleccione un registro","Notificacion");
        }

            public void cargarComboBox() {
            cbinscripcion.Items.Add("Todos");
            for (int i = 1; i <=16; i++)            
                cbinscripcion.Items.Add(i.ToString());
            cbPagado.Items.Add("Ambos");
            cbPagado.Items.Add("Si");
            cbPagado.Items.Add("No");
            cbCarrera.Items.Add("Todas");
            foreach (DataRow item in wssc.SELECT_Carrera().Tables[0].Rows)
                  cbCarrera.Items.Add(item[1]);          
        }
        
        public bool cargarDatos() {
            DataSet ds;
            
            if ((ds = wssc.SELECT_Alumno(Numero(tbID.Text),
                                            tbBuscar.Text,
                                            ((cbinscripcion.Text == "Todos") ? string.Empty : Numero(cbinscripcion.Text)),
                                            ((cbPagado.Text == "Ambos") ? string.Empty : cbPagado.Text),
                                            ((cbCarrera.Text == "Todas") ? string.Empty : cbCarrera.Text))) == null)
            {
                
                ds = new DataSet();
                ds.Tables.Add(new DataTable());
                dgAlumnos.ItemsSource = ds.Tables[0].DefaultView;
                dgAlumnos.SelectedItem = null;
                MessageBox.Show("No hay resultados","[Error]");
                return false;
                
                //ds.Tables[0].Rows.Add();                               
            }
            dgAlumnos.SelectedItem = null;
            dgAlumnos.ItemsSource = ds.Tables[0].DefaultView;
            return true;           
        }
        
        public string Numero(string n) {
            
            if (n!=string.Empty  && int.TryParse(n, out int aux)) {
                if ((aux = Int32.Parse(n)) >= 0 && aux <= 100000)
                    return aux.ToString();                
                return string.Empty;
            }
            return string.Empty;
            
        }
    }
}
