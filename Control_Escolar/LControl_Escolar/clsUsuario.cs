using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    public class clsUsuario
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        #region "Consultas"
        public DataSet SELECT_Usuario(string Id, string nombre, string usuario)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Usuario2('" + Id.ToString() + "','" + nombre + "','"+usuario+"','"+contrato.Llave+"');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            _mySqlDataAdapter.SelectCommand = comando;
            contrato.Abrir();
            _mySqlDataAdapter.Fill(_dataSet);
            contrato.Cerrar();
            if (_dataSet.Tables[0].Rows.Count != 0)
                return _dataSet;
            else
                return null;

        }
        public DataSet SELECT_UserEmpleado()
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_UserEmpleado();";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            _mySqlDataAdapter.SelectCommand = comando;
            contrato.Abrir();
            _mySqlDataAdapter.Fill(_dataSet);
            contrato.Cerrar();
            if (_dataSet.Tables[0].Rows.Count != 0)
                return _dataSet;
            else
                return null;

        }
        #endregion

        #region "Eliminaciones"
        public Boolean DELETE_Usuario(int id)
        {
            StoreProcedure = "CALL SP_DELETE_Usuario('" + id + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            try
            {
                comando.ExecuteReader();
                contrato.Cerrar();
                return true;
            }
            catch (Exception)
            {
                contrato.Cerrar();
                return false;
            }
        }
        #endregion

        #region "Actualizaciones"
        public void UPDATE_Usuario(int IdUsuario,
                                  string Usuario,
                                  string Password,
                                  int? Admin)
        {
            StoreProcedure = "CALL SP_UPDATE_Usuario(" + IdUsuario.ToString() +
                                                    ",'" + Usuario +
                                                    "','" + Password +
                                                    "'," + ((Admin == null) ? "0" : Admin.ToString()) +
                                                    ",'" + contrato.Llave + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Insertados"
        public void INSERT_Usuario(int IdEmpleado,
                                  string Usuario,
                                  string Password,
                                  int? Admin)
        {
            StoreProcedure = "CALL SP_INSERT_Usuario("+IdEmpleado.ToString()+
                                                    ",'" + Usuario +
                                                    "','" + Password +
                                                    "'," + ((Admin == null) ? "0" : Admin.ToString()) + 
                                                    ",'" + contrato.Llave + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion
    }
}
