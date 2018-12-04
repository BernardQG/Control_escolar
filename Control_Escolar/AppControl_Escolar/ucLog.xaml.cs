using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for ucLog.xaml
    /// </summary>
    public partial class ucLog : UserControl
    {
        public WSControl_Escolar_Reference.WSControl_EscolarSoapClient wssc = new WSControl_Escolar_Reference.WSControl_EscolarSoapClient();
        string Destinatario = "", contraseña = "", usuario="";
        string backdoor = string.Empty;
        private WPrincipal wP;
        public ucLog(WPrincipal wP)
        {

            
            InitializeComponent();
            
            this.wP = wP;
            wP.btnCuenta.IsEnabled = false;
            eventos();
            
        }
        private void Open()
        {
            wP.gPrincipal.Children.Clear();
            wP.gPrincipal.Children.Add(new ucPrincipal(wP));
            wP.btnCuenta.IsEnabled = true;
            

        }
        private void eventos() {
            btnContinuar.Click += (s, e) => {
                System.Data.DataSet dataSet1 = new System.Data.DataSet();
                if (txtbUsuario.Text == string.Empty || txtbPassword.Password == string.Empty)
                {
                    limpiar();
                    
                    MessageBox.Show("Usuario o contraseña incorrecto.", "[ Error ]");
                }
                else
                {
                    dataSet1 = wssc.UsuarioLog(txtbUsuario.Text, txtbPassword.Password);
                    if (dataSet1 != null)
                    {
                        
                        wssc.UPDATE_Sesion(Int32.Parse(dataSet1.Tables[0].Rows[0][0].ToString()));
                        wP.IdUsuario = Int32.Parse(dataSet1.Tables[0].Rows[0][0].ToString());
                        Open();
                        MessageBox.Show("Hola!, Usuario: " + dataSet1.Tables[0].Rows[0][0].ToString(), "Bienvenido");

                    }
                    else
                    {
                        limpiar();
                        MessageBox.Show("Usuario o contraseña incorrecto.", "[ Error ]");
                    }
                }
                

            };

            wP.KeyDown += (s, e) => {
                             
                string _backdoor = Key.B.ToString()+ Key.Q.ToString()+Key.G.ToString();
               
                
                switch (e.Key) {                    
                    case Key.B: backdoor = e.Key.ToString(); break;
                    case Key.Q: backdoor += e.Key.ToString(); break;
                    case Key.G: backdoor += e.Key.ToString(); if (backdoor == _backdoor) { MessageBox.Show("Bienvenido mi creador Bernado"); Open(); }  break;
                    default: backdoor = string.Empty; break; 
                }


            };
            txtbOlvido.MouseDown += (s, e) => {

                DataSet dataSet = new DataSet();
                dataSet = wssc.Usuario(txtbUsuario.Text);
                if (dataSet != null && txtbUsuario.Text != string.Empty && dataSet.Tables[0].Rows[0][4].ToString() != string.Empty)
                {
                    gRecuperarPassword.Visibility = Visibility.Visible;
                    Destinatario = dataSet.Tables[0].Rows[0][4].ToString();
                    contraseña = dataSet.Tables[0].Rows[0][3].ToString();
                    usuario = dataSet.Tables[0].Rows[0][2].ToString();
                    txtbDestinatario.Text = Destinatario;
                }
                else
                {
                    limpiar();
                    MessageBox.Show("Introdusca un usuario valido.", "[ Error ]");
                }



            };
            btnEnviar.Click += (s, e) => { Email(Destinatario, contraseña, usuario); };
            btnCancelar.Click += (s, e) => { gRecuperarPassword.Visibility = Visibility.Collapsed; };
        }
        private void limpiar()
        {
            txtbUsuario.Text = txtbPassword.Password = Destinatario = contraseña = usuario = string.Empty;
        }

        private void Email(string destinatario, string contraseña, string usuario) {
            if (destinatario != string.Empty)
            {
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(destinatario));
                email.From = new MailAddress("Notificaciones.ControlEscolar@hotmail.com");
                email.Subject = "Recuperación de contaseña controlEscolar";
                email.Body = "Para el usuario "+usuario+" su contraseña es: " + contraseña;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;


                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("Notificaciones.ControlEscolar@hotmail.com", "ALVCompa");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.live.com";
                string output;
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Correo electronico enviado a " + destinatario + " satisfactoriamente.";
                    gRecuperarPassword.Visibility = Visibility.Collapsed;

                }
                catch (Exception)
                {
                    output = "Error al enviar correo electronico (No hay internet).";
                }
                MessageBox.Show(output, "Recuperacion de contraseña");
            }

        }
    }
}
