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
    /// Interaction logic for ucIU_Usuario.xaml
    /// </summary>
    public partial class ucIU_Usuario : UserControl
    {
        private string errorMensaje = string.Empty;
        private WPrincipal wP;
        private DataSet dsEmpleados;
        private int Id;        
        public ucIU_Usuario(WPrincipal wP, string _accion, int? Id)
        {
            InitializeComponent();
            this.wP = wP;


            dsEmpleados = wP.wsU.SELECT_UserEmpleado();            
            inicializarCB();
            if (_accion == "Insertar")
            {
                cbEmpleado.Visibility = Visibility.Visible;
                stInsert.Visibility = Visibility.Hidden;
                btnIU.Content = "Agregar";
            }
            if (_accion == "Actualizar")
            {
                cbEmpleado.Visibility = Visibility.Collapsed;
                btnIU.Content = "Actualizar";
                stInsert.Visibility = Visibility.Visible;
                tbId.Text = Id.ToString();
                this.Id = (int)Id;
                info();

            }

            eventos();
        }
        public void info()
        {
            DataSet ds1 = wP.wsU.SELECT_Usuario(Id.ToString(), "","");

            tbUsuario.Text = ds1.Tables[0].Rows[0]["Usuario"].ToString();
            tbPassword.Text = ds1.Tables[0].Rows[0]["Password"].ToString();
            cbAdmin.SelectedItem = ds1.Tables[0].Rows[0]["Admin"].ToString();

           


        }
        public int buscarEnCB(DataSet ds, ComboBox cb, string en, string que_cosa)
        {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == (item[que_cosa].ToString()+" - "+ item[en].ToString()))
                        return Int32.Parse(item[que_cosa].ToString());
            return 0;
        }

        public void eventos()
        {


            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucUsuarios(wP));
            };

           cbEmpleado.SelectionChanged += (s, e) => {
                if (cbEmpleado.Items.Count > 0)
                {                    
                   Id = buscarEnCB(dsEmpleados, cbEmpleado, "Nombre", "IdEmpleado");
                   tbId.Text = Id.ToString();
                   stInsert.Visibility = Visibility.Visible;
                }
                
            };
            btnIU.Click += (s, e) => { jalarDatos(); };


        }

       


   
        public void inicializarCB()
        {

            llenarCB(cbAdmin, 0, 2);
            llenarCBconDS(dsEmpleados, cbEmpleado,"IdEmpleado", "Nombre");
        }

        private void llenarCBconDS(DataSet ds, ComboBox cb, string campo, string campo2)
        {
            cb.Items.Clear();
            if (ds != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    cb.Items.Add(item[campo].ToString()+" - "+item[campo2].ToString());
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
        public int? NumeroNull(ComboBox tb)
        {
            if (tb.Text == string.Empty)
                return null;
            return Int32.Parse(tb.Text);
        }


        public void jalarDatos()
        {
            validadTb(tbUsuario);
            validadTb(tbPassword);
            
            validadCb(cbAdmin);





            if (errorMensaje != string.Empty) { MessageBox.Show(errorMensaje, "Error"); errorMensaje = string.Empty; }
            else
            {

                




                if (btnIU.Content.ToString() != "Agregar")
                {
                    try
                    {
                        wP.wsU.UPDATE_Usuario(Id, tbUsuario.Text,
                                                tbPassword.Text,
                                                NumeroNull(cbAdmin));
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


                        wP.wsU.INSERT_Usuario(Id, tbUsuario.Text,
                                                tbPassword.Text,
                                                NumeroNull(cbAdmin));
                        MessageBox.Show("Listo", "Notificacion");


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al insertar", "Error");
                    }

                }
                tbUsuario.Text = tbPassword.Text = string.Empty;
                
            }

        }

    }
}
