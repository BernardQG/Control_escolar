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
    /// Interaction logic for ucPrincipal.xaml
    /// </summary>
    public partial class ucPrincipal : UserControl
    {
        public ucPrincipal(WPrincipal wP)
        {

            InitializeComponent();
            DataSet ds1 = wP.wssc.SELECT_Admin();
            if (ds1 == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                int acceso = Int32.Parse(ds1.Tables[0].Rows[0]["Admin"].ToString());
                wP.btnCuenta.IsEnabled = true;


                gAlumnos.MouseDown += (s, e) =>
                {
                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucAlumnos(wP));
                };

                gPeriodo.MouseDown += (s, e) =>
                {
                    if (acceso == 2)
                    {
                        wP.gPrincipal.Children.Clear();
                        wP.gPrincipal.Children.Add(new ucPeriodos(wP));
                    }
                    else
                    {
                        MessageBox.Show("Necesitas un nivel de acceso mas alto");
                    }



                };
                gEmpleados.MouseDown += (s, e) =>
                {

                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucEmpleados(wP));

                };
                gProfesores.MouseDown += (s, e) =>
                {

                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucProfesores(wP));

                };
                gUsuarios.MouseDown += (s, e) =>
                {

                    if (acceso == 2)
                    {
                        wP.gPrincipal.Children.Clear();
                        wP.gPrincipal.Children.Add(new ucUsuarios(wP));
                    }
                    else
                    {
                        MessageBox.Show("Necesitas un nivel de acceso mas alto");
                    }

                };

                gMateria.MouseDown += (s, e) =>
                {


                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucMaterias(wP));

                };
                gGrupos.MouseDown += (s, e) =>
                {

                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucGrupos(wP));

                };
                gHistorial_alumno.MouseDown += (s, e) =>
                {

                    wP.gPrincipal.Children.Clear();
                    wP.gPrincipal.Children.Add(new ucHistorial_alumno(wP));

                };
                gAuditoria.MouseDown += (s, e) =>
                {


                    if (acceso == 2)
                    {
                        wP.gPrincipal.Children.Clear();
                        wP.gPrincipal.Children.Add(new ucAuditoria(wP));
                    }
                    else
                    {
                        MessageBox.Show("Necesitas un nivel de acceso mas alto");
                    }

                };
            }
            gAcercaDE.MouseDown += (s, e) => {

                wP.gPrincipal.Children.Clear();
                wP.gPrincipal.Children.Add(new ucAcercaDe(wP));

            };



        }
    }
}
