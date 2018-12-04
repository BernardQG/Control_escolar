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
    /// Interaction logic for ucIU_Grupo.xaml
    /// </summary>
    public partial class ucIU_Grupo : UserControl
    {
        private string errorMensaje = string.Empty;
        private WPrincipal wP;
        private DataSet dsPeriodo,dsMateria,dsProfesor;
        
        private int Id, IdProfesor, IdMateria, IdPeriodo;
        

        public ucIU_Grupo(WPrincipal wP, string _accion, int? Id)
        {
            InitializeComponent();
            this.wP = wP;

            dsPeriodo = wP.wssc.SELECT_Periodo("");
            dsMateria = wP.wsM.SELECT_Materia("","");
            dsProfesor = wP.wsP.SELECT_Profesor("", "");
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
        public void info()
        {
            DataSet ds1 = wP.wsG.SELECT_Grupo(Id.ToString(), "", "");                       

            cbMateria.SelectedItem = ds1.Tables[0].Rows[0]["Materia"].ToString();
            cbPeriodo.SelectedItem = ds1.Tables[0].Rows[0]["Periodo"].ToString();
            cbProfesor.SelectedItem = ds1.Tables[0].Rows[0]["Profesor"].ToString();

        }

        public int buscarEnCB(DataSet ds, ComboBox cb, string en, string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == item[en].ToString())
                        return Int32.Parse(item[que_cosa].ToString());
            return 0;
        }
        public int buscarEnCB_XD(DataSet ds, ComboBox cb, string campo, string campo1, string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item[campo].ToString() + "-" + item[campo].ToString()))
                        return Int32.Parse(item[que_cosa].ToString());
            return 0;
        }
        public void eventos()
        {


            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucGrupos(wP));
            };
            btnIU.Click += (s, e) => { jalarDatos(); };



        }   
        
  

        public void inicializarCB()
        {

 

            llenarCBconDS(dsProfesor, cbProfesor, "Nombre");            
            llenarCBconDS(dsMateria, cbMateria, "Nombre");
            llenarCBconDS_XD(dsPeriodo, cbPeriodo, "Fecha_inicio","Fecha_fin");


        }

        private void llenarCBconDS(DataSet ds, ComboBox cb, string campo)
        {
            cb.Items.Clear();
            if (ds != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    cb.Items.Add(item[campo].ToString());
        }
        private void llenarCBconDS_XD(DataSet ds, ComboBox cb, string campo,string campo2)
        {
            cb.Items.Clear();
            if (ds != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    cb.Items.Add(item[campo].ToString()+"-"+ item[campo].ToString());
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
                if (!Int64.TryParse(tb.Text, out Int64 aux))
                {
                    tb.Text = string.Empty;
                    errorMensaje += "Solo se permite digitos en " + tb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;
                }
                else
                if ((aux = Int64.Parse(tb.Text)) < 0 || aux > 9999999999)
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
            
            
            validadCb(cbMateria);
            validadCb(cbPeriodo);
            validadCb(cbProfesor);


            if (errorMensaje != string.Empty) { MessageBox.Show(errorMensaje, "Error"); errorMensaje = string.Empty; }
            else
            {

                


              IdMateria = buscarEnCB(dsMateria, cbMateria, "Nombre", "ID");
                IdProfesor = buscarEnCB(dsProfesor, cbProfesor, "Nombre", "ID");
                IdPeriodo = buscarEnCB_XD(dsPeriodo, cbPeriodo, "Fecha_inicio", "Fecha_fin", "IdPeriodo");
                



                if (btnIU.Content.ToString() != "Agregar")
                {
                    try
                    {
                        wP.wsG.UPDATE_Grupo(Id, IdMateria, IdPeriodo, IdProfesor);
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


                        wP.wsG.INSERT_Grupo(IdMateria, IdProfesor,IdPeriodo);
                        MessageBox.Show("Listo", "Notificacion");


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al insertar", "Error");
                    }

                }
                cbMateria.SelectedItem = cbPeriodo.SelectedItem = cbProfesor.SelectedItem = string.Empty;
            }

        }

    }
}
