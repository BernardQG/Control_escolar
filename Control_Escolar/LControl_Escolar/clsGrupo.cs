using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace LControl_Escolar
{
    public class clsGrupo
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        #region "Consultas"
        public DataSet SELECT_Grupo(string Id, string nombre,string periodo)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Grupo('" + Id.ToString() + "','" + nombre + "','"+periodo+"');";
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
        public Boolean DELETE_Grupo(int id)
        {
            StoreProcedure = "CALL SP_DELETE_Grupo('" + id + "');";
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
        public void UPDATE_Grupo(int IdGrupo, int IdMateria, int IdProfesor, int IdPeriodo)
        {
            StoreProcedure = "CALL SP_UPDATE_Grupo(" + IdMateria.ToString() +
                                                    "," + IdMateria.ToString() +
                                                    "," + IdProfesor.ToString() +
                                                    "," + IdPeriodo.ToString() + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Insertados"
        public void INSERT_Grupo(int IdMateria, int IdProfesor, int IdPeriodo)
        {
            StoreProcedure = "CALL SP_INSERT_Grupo(" + IdMateria.ToString() +
                                                    "," + IdProfesor.ToString() +
                                                    "," + IdPeriodo.ToString() + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion
    }
}
