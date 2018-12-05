﻿using System;
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
    /// Interaction logic for ucProfesores.xaml
    /// </summary>
    public partial class ucProfesores : UserControl
    {
        private WPrincipal wP;
        private DataGrid dg;
        private DataSet dss;
        private int acceso;
        public ucProfesores(WPrincipal wP)
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
                this.dg = dgProfesor;
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

            btnEliminar.Click += (s, e) => {

                if (txtId.Text != "#")
                {
                    if (acceso >= 2)
                    {
                        wP.wsP.DELETE_Profesor(Int32.Parse(txtId.Text)); cargarDatos();
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
                        DataSet _dataSet = wP.wsP.SELECT_IProfesor(Int32.Parse(txtId.Text));
                        if (_dataSet != null)
                        {
                            DataRow dataRow = _dataSet.Tables[0].Rows[0];
                            for (int i = 0; i < _dataSet.Tables[0].Columns.Count; i++)
                            {
                                m += _dataSet.Tables[0].Columns[i].ColumnName + ": " + dataRow[i].ToString() + Environment.NewLine;

                            }
                            MessageBox.Show(m, "Informacion");
                        }
                        else
                            MessageBox.Show("Error desconocido", "Error");
                        
                        
                    }
                    else MessageBox.Show("Necesitas un nivel de acceso mas alto");
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
                    wP.gPrincipal.Children.Add(new ucIU_Profesor(wP, "Insertar", null));
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
                        wP.gPrincipal.Children.Add(new ucIU_Profesor(wP, "Actualizar", Int32.Parse(txtId.Text)));
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
            

        }

        public bool cargarDatos()
        {
            DataSet ds;
            ds = wP.wsP.SELECT_Profesor(Numero(tbID.Text), tbBuscar.Text);
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
