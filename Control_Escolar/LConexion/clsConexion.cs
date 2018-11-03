using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LConexion
{
    public class clsConexion
    {
        public MySqlConnection conexion;
        private string cadenaConexion;
        public string Llave { get; }
        public clsConexion() {
            cadenaConexion = "datasource=localhost;" +
                             "port=3306;" +
                             "username=root;" +
                             "password=;" +
                             "database=ControlEscolar;" +
                             "SslMode=none;";
            Llave="BQG";
            conexion = new MySqlConnection(cadenaConexion);
        }
        public Boolean Abrir() {
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        public void Cerrar() {
            conexion.Close();
        }
    }
}
