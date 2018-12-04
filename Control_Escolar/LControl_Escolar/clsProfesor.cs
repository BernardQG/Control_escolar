using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
   
   public class clsProfesor
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        #region "Consultas"
        public DataSet SELECT_Profesor(string Id,string nombre)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Profesor('" + Id.ToString() + "','"+nombre+"');";
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
        public DataSet SELECT_IProfesor(int Id)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_IProfesor('" + Id.ToString() + "');";
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
        public Boolean DELETE_Profesor(int id)
        {
            StoreProcedure = "CALL SP_DELETE_Profesor('" + id + "');";
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
        public void UPDATE_Profesor(int IdProfesor,
                                  string Nombre,
                                  string APaterno,
                                  string AMaterno,
                                  string Fecha_nacimiento,
                                  string Sexo,
                                  string Calle,
                                  string Numero,
                                  int? Telefono,
                                  int? Celular,
                                  string Correo,
                                  int? IdAcentamiento,                                  
                                  string Grado_estudios,
                                  string Especialidad,
                                  int? Folio_titulo)
        {
            StoreProcedure = "CALL SP_UPDATE_Profesor(" + IdProfesor.ToString() +
                                                    ",'" + Nombre +
                                                    "','" + APaterno +
                                                    "','" + AMaterno +
                                                    "','" + Fecha_nacimiento +
                                                    "','" + Sexo +
                                                    "','" + Calle +
                                                    "','" + Numero +
                                                    "'," + ((Telefono == null) ? "null" : Telefono.ToString()) +
                                                    "," + ((Celular == null) ? "null" : Celular.ToString()) +
                                                    ",'" + Correo +
                                                    "'," + IdAcentamiento.ToString() +                                                    
                                                    ",'" + Grado_estudios +
                                                    "','"+Especialidad+
                                                    "',"+ ((Folio_titulo == null) ? "null" :Folio_titulo.ToString()) + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Insertados"
        public void INSERT_Profesor(string Nombre,
                                 string APaterno,
                                 string AMaterno,
                                 string Fecha_nacimiento,
                                 string Sexo,
                                 string Calle,
                                 string Numero,
                                 int? Telefono,
                                 int? Celular,
                                 string Correo,
                                 int? IdAcentamiento,
                                 string Grado_estudios,
                                 string Especialidad,
                                 int? Folio_titulo)
        {
            StoreProcedure = "CALL SP_INSERT_Profesor('" + Nombre +
                                                    "','" + APaterno +
                                                    "','" + AMaterno +
                                                    "','" + Fecha_nacimiento +
                                                    "','" + Sexo +
                                                    "','" + Calle +
                                                    "','" + Numero +
                                                    "'," + ((Telefono == null) ? "null" : Telefono.ToString()) +
                                                    "," + ((Celular == null) ? "null" : Celular.ToString()) +
                                                    ",'" + Correo +
                                                    "'," + IdAcentamiento.ToString() +
                                                    ",'" + Grado_estudios +
                                                    "','" + Especialidad +
                                                    "'," + ((Folio_titulo == null) ? "null" : Folio_titulo.ToString()) + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion
    }
}
