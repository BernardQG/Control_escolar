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
    /// Interaction logic for ucIU_Historial_alumno.xaml
    /// </summary>
    public partial class ucIU_Historial_alumno : UserControl
    {

        private string errorMensaje = string.Empty;
        private WPrincipal wP;
        private DataSet dsAlumno, dsGrupo;

        private int Id, IdAlumno, IdGrupo, oldIdAlumno, oldIdGrupo;

        public ucIU_Historial_alumno(WPrincipal wP, string _accion, int? Id)
        {
            InitializeComponent();
            
            this.wP = wP;

            dsAlumno = wP.wssc.SELECT_Alumno("", "", "","","");
            dsGrupo = wP.wsG.SELECT_Grupo("", "", "");
            
            inicializarCB();
            if (_accion == "Insertar")
            {
                sId.Visibility = Visibility.Collapsed;
                btnIU.Content = "Agregar";
            }
            if (_accion == "Actualizar")
            {
                sId.Visibility = Visibility.Visible;
                btnIU.Content = "Actualizar";
                tbId.Text = Id.ToString();
                this.Id = (int)Id;
                info();

            }

            eventos();
        }
      

        public int buscarEnCB(DataSet ds, ComboBox cb, string en, string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == item[en].ToString())
                        return Int32.Parse(item[que_cosa].ToString());
            return 0;
        }
      
        public void eventos()
        {


            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucHistorial_alumno(wP));
            };
            btnIU.Click += (s, e) => { jalarDatos(); };



        }
        public int buscarAlumno()
        {
            DataSet ds = dsAlumno;
            ComboBox cb = cbAlumno;
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item["ID"].ToString() + "-" + item["Nombre"].ToString()))
                        return Int32.Parse(item["ID"].ToString());
            return 0;
        }
        public int buscarGrupo()
        {
            DataSet ds = dsGrupo;
            ComboBox cb = cbGrupo;
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item["IdGrupo"].ToString() + "-" + item["Materia"].ToString() + "-" + item["Profesor"].ToString()))
                        return Int32.Parse(item["IdGrupo"].ToString());
            return 0;
        }

        public void info()
        {
            DataSet ds1 = wP.wsH.SELECT_Historial_alumno(Id.ToString(), "", "", "");
            oldIdAlumno = Int32.Parse(ds1.Tables[0].Rows[0]["IdAlumno"].ToString());
            cbAlumno.SelectedItem = ds1.Tables[0].Rows[0]["IdAlumno"] + "-" + ds1.Tables[0].Rows[0]["Alumno"];
            oldIdGrupo = Int32.Parse(ds1.Tables[0].Rows[0]["IdGrupo"].ToString());
            cbGrupo.SelectedItem = ds1.Tables[0].Rows[0]["IdGrupo"].ToString() + "-" + ds1.Tables[0].Rows[0]["Materia"].ToString() + "-" + ds1.Tables[0].Rows[0]["Profesor"].ToString();
            tbCalificacion.Text = ds1.Tables[0].Rows[0]["Calificacion"].ToString();
            cbOportunidad.SelectedItem = ds1.Tables[0].Rows[0]["Oportunidad"].ToString();


        }

        public void inicializarCB()
        {

            cbAlumno.Items.Clear();
            if (dsAlumno != null)
                foreach (DataRow item in dsAlumno.Tables[0].Rows)
                    cbAlumno.Items.Add(item["ID"].ToString()+"-"+ item["Nombre"].ToString());
            cbGrupo.Items.Clear();
            if (dsGrupo != null)
                foreach (DataRow item in dsGrupo.Tables[0].Rows)
                    cbGrupo.Items.Add(item["IdGrupo"].ToString() + "-" + item["Materia"].ToString() + "-" + item["Profesor"].ToString());
            cbOportunidad.Items.Clear();
            llenarCB(cbOportunidad, 1, 4);

        }

        private void llenarCBconDS(DataSet ds, ComboBox cb, string campo)
        {
            cb.Items.Clear();
            if (ds != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    cb.Items.Add(item[campo].ToString());
        }
        private void llenarCBconDS_XD(DataSet ds, ComboBox cb, string campo, string campo2)
        {
            cb.Items.Clear();
            if (ds != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    cb.Items.Add(item[campo].ToString() + "-" + item[campo].ToString());
        }
        public void llenarCB(ComboBox cb, int inicio, int fin)
        {
            for (int i = inicio; i <= fin; i++) cb.Items.Add(i.ToString());

            cb.SelectedItem = inicio.ToString();

        }


        public string validadTb(TextBox tb)
        {

            if (tb.Text != string.Empty)
                return tb.Text;
            errorMensaje += "No permite valores vacios en " + tb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;
            return string.Empty;
        }
        public void validadCb(ComboBox cb)
        {

            if (cb.SelectedItem == null || cb.SelectedItem.ToString() == string.Empty)
                errorMensaje += "No permite valores vacios en " + cb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;

        }
        public void validadNumero(TextBox tb)
        {

            if (tb.Text != string.Empty)
            {
                if (!double.TryParse(tb.Text, out double aux))
                {
                    tb.Text = string.Empty;
                    errorMensaje += "Solo se permite digitos en " + tb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;
                }
                else
                if ((aux = double.Parse(tb.Text)) < 0 || aux > 10)
                {
                    tb.Text = string.Empty;
                    errorMensaje += "No se permite esos valores en " + tb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;
                }
            }



        }
        public int? NumeroNull(TextBox tb)
        {
            if (tb.Text == string.Empty)
                return null;
            return Int32.Parse(tb.Text);
        }


        public void jalarDatos()
        {


            validadCb(cbAlumno);
            validadCb(cbGrupo);
            validadCb(cbOportunidad);
            validadTb(tbCalificacion);
            validadNumero(tbCalificacion);

            if (errorMensaje != string.Empty) { MessageBox.Show(errorMensaje, "Error"); errorMensaje = string.Empty; }
            else
            {




                IdAlumno = buscarAlumno();
                IdGrupo = buscarGrupo();
                




                if (btnIU.Content.ToString() != "Agregar")
                {
                    try
                    {
                        wP.wsH.UPDATE_Historial_alumno(IdAlumno,IdGrupo,oldIdAlumno,oldIdGrupo,double.Parse(tbCalificacion.Text),int.Parse(cbOportunidad.SelectedItem.ToString()));
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


                        wP.wsH.INSERT_Historial_alumno(IdAlumno, IdGrupo, double.Parse(tbCalificacion.Text), int.Parse(cbOportunidad.SelectedItem.ToString()));
                        MessageBox.Show("Listo", "Notificacion");


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al insertar", "Error");
                    }

                }
                cbAlumno.Text = cbGrupo.Text = cbOportunidad.Text = string.Empty;
                tbCalificacion.Text = string.Empty;
            }

        }
        
        }
    
}
