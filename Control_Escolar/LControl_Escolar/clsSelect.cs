using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    
    public class clsSelect
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        //int= es un tipo de dato Nullable
        #region "Localidad"
        public DataSet SELECT_Pais()
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Pais();";
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
        public DataSet SELECT_Estado(int Id)
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_Estado(" + Id.ToString() + ");";
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
        public DataSet SELECT_Municipio(int Id)
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_Municipio(" + Id + ");";
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
        public DataSet SELECT_Acentamiento(int Id)
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_Acentamiento(" + Id + ");";
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

        public DataSet SELECT_CP(string cp)
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_CP('" + cp + "');";
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
        


        #region "Alumnos"
        public DataSet SELECT_Alumno(string id, string nombre, string inscripcion, string pagado, string carrera)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?

            StoreProcedure = "CALL SP_SELECT_Alumno('" + id +
                                                 "','" + nombre +
                                                 "','" + inscripcion +
                                                 "','" + pagado +
                                                 "','" + carrera + "');";
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

        public DataSet SELECT_Carrera()
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Carrera();";
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

        public DataSet SELECT_IAlumno(int Id)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_IAlumno("+Id.ToString()+");";
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

        #region "Periodo"
        public DataSet SELECT_Periodo(string Id)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Periodo('" + Id.ToString() + "');";
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

        #region "Empleado"
        public DataSet SELECT_Empleado(string id, string nombre, string puesto)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Empleado('" + id + "','"+nombre+"','"+puesto+"');";
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


        public DataSet SELECT_IEmpleado(int id)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_IEmpleado('" + id + "');";
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

        public DataSet SELECT_Puesto()
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Puesto();";
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


    }
}
