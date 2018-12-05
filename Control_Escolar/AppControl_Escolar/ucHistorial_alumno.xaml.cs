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
    /// Interaction logic for ucHistorial_alumno.xaml
    /// </summary>
    public partial class ucHistorial_alumno : UserControl
    {
        private WPrincipal wP;
        private DataGrid dg;        
        private DataSet dsGrupo,dsProfesor;
        private DataSet dss;
        private int acceso;
        public ucHistorial_alumno(WPrincipal wP)
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
                this.dg = dgH;
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
                if (!cargarDatos()) { cbGrupo.Text = string.Empty; cbProfesor.Text = string.Empty; cargarDatos(); }
                if (cbGrupo.Text == string.Empty)
                {
                    MessageBox.Show("Ningun filtro aplicado", "Notificacion");
                }
            };

            btnCancelar.Click += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucPrincipal(wP));

            };
            btnNuevo.MouseDown += (s, e) => {

                if (acceso >= 1)
                {
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucIU_Historial_alumno(wP, "Insertar", null));
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
                        wP.gPrincipal.Children.Add(new ucIU_Historial_alumno(wP, "Actualizar", Int32.Parse(txtId.Text)));
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
            cbGrupo.Items.Add("Todos");
            dsGrupo = wP.wsG.SELECT_Grupo("", "", "");

            foreach (DataRow item in dsGrupo.Tables[0].Rows)
                cbGrupo.Items.Add(item["IdGrupo"].ToString() + " - " + item["Materia"].ToString());

            cbProfesor.Items.Add("Todos");
            dsProfesor = wP.wsP.SELECT_Profesor("", "");

            foreach (DataRow item in dsProfesor.Tables[0].Rows)
                cbProfesor.Items.Add(item["ID"].ToString() + " - " + item["Nombre"].ToString());
        }

        public string buscarGrupo(DataSet ds, ComboBox cb, string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item["IdGrupo"].ToString() + " - " + item["Materia"].ToString()))
                        return item[que_cosa].ToString();
            return "";
        }
        public string buscarPofesor(DataSet ds, ComboBox cb, string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item["ID"].ToString() + " - " + item["Nombre"].ToString()))
                        return item[que_cosa].ToString();
            return "";
        }
        public bool cargarDatos()
        {

            DataSet ds = wP.wsH.SELECT_Historial_alumno(Numero(tbID.Text), tbBuscar.Text, ((cbProfesor.Text == "Todos") ? string.Empty : buscarPofesor(dsProfesor, cbProfesor, "ID").ToString()), ((cbGrupo.Text == "Todos") ? string.Empty : buscarGrupo(dsGrupo, cbGrupo, "IdGrupo").ToString()));
           /// DataSet ds = wP.wsH.SELECT_Historial_alumno(Numero(tbID.Text), tbBuscar.Text, ((cbProfesor.Text == "Todos") ? string.Empty : buscarPofesor(dsProfesor, cbProfesor, "ID").ToString()), "");
            //MessageBox.Show(((cbProfesor.Text == "Todos") ? string.Empty : buscarPofesor(dsProfesor, cbProfesor, "ID").ToString()));
            //MessageBox.Show(((cbGrupo.Text == "Todos") ? string.Empty : buscarGrupo(dsGrupo, cbGrupo, "IdGrupo").ToString()));
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
