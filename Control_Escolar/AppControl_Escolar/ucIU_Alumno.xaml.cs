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
using MaterialDesignThemes.Wpf;
using System.Data;

namespace AppControl_Escolar
{
    /// <summary>
    /// Interaction logic for ucIU_Alumno.xaml
    /// </summary>
    public partial class ucIU_Alumno : UserControl
    {
        //private WSControl_Escolar_Reference.WSControl_EscolarSoapClient wssc = new WSControl_Escolar_Reference.WSControl_EscolarSoapClient();
        public enum Accion { INSERT, UPDATE };
        private string errorMensaje = string.Empty;
        private WPrincipal wP;


        private DataSet dsCarrera, dsPais, dsEstado, dsMunicipio, dsAcentamiento;

        private bool buscarXCP = false;
        private int IdAlumno, IdCarrera = 0;
        private int IdAcentamiento;

        public ucIU_Alumno(WPrincipal wP, Accion _accion, int? IdAlumno)
        {
            InitializeComponent();
            this.wP = wP;
            dsCarrera = wP.wssc.SELECT_Carrera();
            dsPais = wP.wssc.SELECT_Pais();
            dsEstado = wP.wssc.SELECT_Estado(1000);
            inicializarCB();
            if (_accion == Accion.INSERT) {
                sId.Visibility = Visibility.Collapsed;
                btnIU.Content = "Agregar";
            }
            if (_accion == Accion.UPDATE) {
                sId.Visibility = Visibility.Visible;
                btnIU.Content = "Actualizar";
                tbId.Text = IdAlumno.ToString();
                this.IdAlumno = (int)IdAlumno;
                infoAlumno();

            }

            eventos();

        }

        public void infoAlumno() {
            DataSet ds1 = wP.wssc.SELECT_Alumno(IdAlumno.ToString(), "", "", "", "");

            DataSet ds2 = wP.wssc.SELECT_IAlumno(IdAlumno);

            string[] Nombre = (ds1.Tables[0].Rows[0]["Nombre"].ToString()).Split(' ');
            tbNombre.Text = Nombre[0];
            tbAPaterno.Text = Nombre[1];
            tbAMaterno.Text = Nombre[2];

            string[] auxNacimiento = (ds2.Tables[0].Rows[0]["Nacimiento"].ToString()).Split(' ');
            string[] Nacimiento = auxNacimiento[0].Split('/');
            tbFn_d.SelectedItem = Nacimiento[1];
            tbFn_m.SelectedItem = Nacimiento[0];
            tbFn_a.SelectedItem = Nacimiento[2];
            cbSexo.SelectedItem = ds2.Tables[0].Rows[0]["Sexo"].ToString();

            tbCP.Text = ds2.Tables[0].Rows[0]["CP"].ToString();
            if (tbCP.Text != string.Empty) 
            methodCP();



            cbAcentamiento.SelectedItem = ds2.Tables[0].Rows[0]["Acentamiento"].ToString();
            tbTipo_acentamiento.Text = ds2.Tables[0].Rows[0]["Tipo de acentamiento"].ToString();
            tbCalle.Text = ds2.Tables[0].Rows[0]["Calle"].ToString();
            tbNumero.Text = ds2.Tables[0].Rows[0]["Numero"].ToString();
            tbTelefono.Text = ds2.Tables[0].Rows[0]["Telefono"].ToString();
            tbCelular.Text = ds2.Tables[0].Rows[0]["Celular"].ToString();
            tbCorreo.Text = ds2.Tables[0].Rows[0]["Correo"].ToString();
            cbCarrera.SelectedItem = ds1.Tables[0].Rows[0]["Carrera"].ToString();




            string[] auxInscripcion = (ds1.Tables[0].Rows[0]["Fecha de inscripcion"].ToString()).Split(' ');
            string[] Inscripcion = auxInscripcion[0].Split('/');
            tbFi_d.SelectedItem = Inscripcion[1];
            tbFi_m.SelectedItem = Inscripcion[0];
            tbFi_a.SelectedItem = Inscripcion[2];


        }

        public int buscarEnCB(DataSet ds, ComboBox cb, string en, string que_cosa) {
            if (ds != null && cb.SelectedItem != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    if (cb.Items.Count > 0 && cb.SelectedItem.ToString() == item[en].ToString())
                        return Int32.Parse(item[que_cosa].ToString());
            return 0;
        }
        public void eventos() {


            btnCancelar.Click += (s, e) => {
                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucAlumnos(wP));
            };

            tbCP.TextChanged += (s, e) => {

                methodCP();

            };
            cbEstado.SelectionChanged += (s, e) => {
                if (!buscarXCP && cbEstado.Items.Count > 0)
                {
                    int IdEstado = buscarEnCB(dsEstado, cbEstado, "Nombre", "IdEstado");
                    
                    dsMunicipio = wP.wssc.SELECT_Municipio(IdEstado);
                    llenarCBconDS(dsMunicipio, cbMunicipio, "Nombre");
                   
                }
                else tbTipo_acentamiento.Text = "#";
            };
            cbMunicipio.SelectionChanged += (s, e) => {
                if (!buscarXCP && cbMunicipio.Items.Count > 0)
                {

                    int IdMunicipio = buscarEnCB(dsMunicipio, cbMunicipio, "Nombre", "IdMunicipio");

                  
                    
                        dsAcentamiento = wP.wssc.SELECT_Acentamiento(IdMunicipio);
                        if (dsAcentamiento != null && dsAcentamiento.Tables[0].Rows.Count > 0)
                            llenarCBconDS(dsAcentamiento, cbAcentamiento, "Acentamiento");

                  
                }
                else tbTipo_acentamiento.Text = "#";
            };

            cbAcentamiento.SelectionChanged += (s, e) => { ID_CP(); };
            btnIU.Click += (s, e) => { jalarDatos(); };
            cbCarrera.SelectionChanged += (s, e) =>
            {
                IdCarrera = buscarEnCB(dsCarrera, cbCarrera, "Nombre", "IdCarrera");

            };
        }

        private void ID_CP() {

            string Tipo = string.Empty;
            if (dsAcentamiento != null && dsAcentamiento.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow item in dsAcentamiento.Tables[0].Rows)
                    if (cbAcentamiento.Items.Count > 0 && item["Acentamiento"].ToString() == cbAcentamiento.SelectedItem.ToString())
                        Tipo = item["Tipo"].ToString();

            }

            if (Tipo != string.Empty) tbTipo_acentamiento.Text = Tipo;
            else tbTipo_acentamiento.Text = "#";                      


        }



        public void enableCb(bool enable) {
            cbPais.IsEnabled = enable;
            cbEstado.IsEnabled = enable;
            cbMunicipio.IsEnabled = enable;
        }


        public void methodCP() {



            llenarCBconDS(dsEstado, cbEstado, "Nombre");
            cbMunicipio.Items.Clear();
            cbAcentamiento.Items.Clear();

            if (tbCP.Text.Length == 5)
            {

                dsAcentamiento = wP.wssc.SELECT_CP(tbCP.Text);
                buscarXCP = true;
                enableCb(false);

                if (dsAcentamiento != null)
                {
                    DataRow dr = dsAcentamiento.Tables[0].Rows[0];
                    cbPais.SelectedItem = dr["Pais"].ToString();
                    cbEstado.SelectedItem = dr["Estado"].ToString();


                    int IdEstado = buscarEnCB(dsEstado, cbEstado, "Nombre", "IdEstado");


                    dsMunicipio = wP.wssc.SELECT_Municipio(IdEstado);
                    llenarCBconDS(dsMunicipio, cbMunicipio, "Nombre");

                    cbMunicipio.SelectedItem = dr["Municipio"].ToString();
                    llenarCBconDS(dsAcentamiento, cbAcentamiento, "Acentamiento");


                }
            }
            else
            {
                enableCb(true); buscarXCP = false;
            }

        }
        public void inicializarCB() {

            llenarCB(tbFn_d, 1, 31);
            llenarCB(tbFi_d, 1, 31);
            llenarCB(tbFn_m, 1, 12);
            llenarCB(tbFi_m, 1, 12);
            llenarCB(tbFn_a, 1980, 2020);
            llenarCB(tbFi_a, 2010, 2030);
            cbSexo.Items.Add("F");
            cbSexo.Items.Add("M");

            llenarCBconDS(dsCarrera, cbCarrera, "Nombre");

            llenarCBconDS(dsPais, cbPais, "Nombre");
            cbPais.Text = cbPais.Items[0].ToString();

            llenarCBconDS(dsEstado, cbEstado, "Nombre");

        }

        private void llenarCBconDS(DataSet ds, ComboBox cb, string campo) {
            cb.Items.Clear();
            if (ds != null)
                foreach (DataRow item in ds.Tables[0].Rows)
                    cb.Items.Add(item[campo].ToString());
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
                if ( (aux = Int64.Parse(tb.Text)) < 0 || aux > 9999999999)
                {
                    tb.Text = string.Empty;
                    errorMensaje += "No se permite esos valores en " + tb.GetValue(MaterialDesignThemes.Wpf.HintAssist.HintProperty) + Environment.NewLine;
                }
            }
            


        }
        public int? NumeroNull(TextBox tb){
            if(tb.Text==string.Empty)
            return null;
            return Int32.Parse(tb.Text);
        }


        public void jalarDatos() {
            validadTb(tbNombre);
            validadTb(tbAPaterno);
            validadCb(cbSexo);
            validadCb(cbAcentamiento);
            validadCb(cbCarrera);
            if (tbNumero.Text.Length > 5) errorMensaje += "En Numero solo se pueden ingresar 5 caracteres" + Environment.NewLine ;
            validadNumero(tbTelefono);
            validadNumero(tbCelular);            
            

            string fechaNacimiento = tbFn_a.SelectedItem.ToString() +
                    "-" + tbFn_m.SelectedItem.ToString() +
                    "-" + tbFn_d.SelectedItem.ToString();
            string fechaInscripcion = tbFi_a.SelectedItem.ToString() +
                "-" + tbFi_m.SelectedItem.ToString() +
                "-" + tbFi_d.SelectedItem.ToString();


            
            

            if (errorMensaje != string.Empty) { MessageBox.Show(errorMensaje, "Error"); errorMensaje = string.Empty; }
            else{

                IdAcentamiento = buscarEnCB(dsAcentamiento, cbAcentamiento, "Acentamiento", "IdAcentamiento");
                IdCarrera = buscarEnCB(dsCarrera, cbCarrera, "Nombre", "IdCarrera");

                

                if (btnIU.Content.ToString() != "Agregar")
                {                    
                    try
                    {
                        wP.wssc.UPDATE_Alumno(IdAlumno,
                                                tbNombre.Text,
                                                tbAPaterno.Text,
                                                tbAMaterno.Text,
                                                fechaNacimiento,
                                                cbSexo.SelectedItem.ToString(),
                                                tbCalle.Text,
                                                tbNumero.Text,
                                                NumeroNull(tbTelefono),
                                                NumeroNull(tbCelular),
                                                tbCorreo.Text,
                                                IdAcentamiento,
                                                IdCarrera,
                                                fechaInscripcion);
                        MessageBox.Show("Listo", "Notificacion");
                    }
                    catch (Exception) {
                        MessageBox.Show("Error al actualizar","Error");
                    }


                }
                else {
                    try
                    {
                        wP.wssc.INSERT_Alumno(tbNombre.Text,
                                          tbAPaterno.Text,
                                          tbAMaterno.Text,
                                          fechaNacimiento,
                                          cbSexo.SelectedItem.ToString(),
                                          tbCalle.Text,
                                          tbNumero.Text,
                                                NumeroNull(tbTelefono),
                                                NumeroNull(tbCelular),
                                          tbCorreo.Text,
                                          IdAcentamiento,
                                          IdCarrera,
                                          fechaInscripcion);
                    MessageBox.Show("Listo", "Notificacion");
                }
                    catch (Exception)
                {
                    MessageBox.Show("Error al actualizar", "Error");
                }

            }
            }
          
       }
    }
}
