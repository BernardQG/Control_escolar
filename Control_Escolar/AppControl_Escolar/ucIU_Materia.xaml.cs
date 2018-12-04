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
    /// Interaction logic for ucIU_Materia.xaml
    /// </summary>
    public partial class ucIU_Materia : UserControl
    {
        private string errorMensaje = string.Empty;
        private WPrincipal wP;
        
        private int Id;
        
        public ucIU_Materia(WPrincipal wP, string _accion, int? Id)
        {
            InitializeComponent();
            this.wP = wP;
            
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
            DataSet ds1 = wP.wsM.SELECT_Materia(Id.ToString(), "");

              

          
            tbNombre.Text = ds1.Tables[0].Rows[0]["Nombre"].ToString();
            tbCreditos.Text = ds1.Tables[0].Rows[0]["Creditos"].ToString();



        }

     
        public void eventos()
        {


            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucMaterias(wP));
            };

         
            btnIU.Click += (s, e) => { jalarDatos(); };


        }  

              

  



        public string validadTb(TextBox tb)
        {

            if (tb.Text != string.Empty)
                return tb.Text;
            errorMensaje += "No permite valores vacios en " + tb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;
            return string.Empty;
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
            validadTb(tbNombre);            
         
            validadNumero(tbCreditos);

          


            if (errorMensaje != string.Empty) { MessageBox.Show(errorMensaje, "Error"); errorMensaje = string.Empty; }
            else
            {
                             




                if (btnIU.Content.ToString() != "Agregar")
                {
                    try
                    {
                        wP.wsM.UPDATE_Materia(Id,
                                                tbNombre.Text,
                                                NumeroNull(tbCreditos)
                                                );
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


                        wP.wsM.INSERT_Materia(      tbNombre.Text,
                                                NumeroNull(tbCreditos)
                                                );
                        MessageBox.Show("Listo", "Notificacion");


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al insertar", "Error");
                    }

                }
                tbCreditos.Text = tbNombre.Text = String.Empty;
            }

        }

    }
}
