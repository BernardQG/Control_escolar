using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    public class clsHistorial_alumno
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        #region "Consultas"
        public DataSet SELECT_Historial_alumno(string Id, string nombre,string idProfesor, string idGrupo)
        {
            DataSet _dataSet = new DataSet();
            //Operador ternario ?
            StoreProcedure = "CALL SP_SELECT_Historial_alumno('" + Id.ToString() + "','" + nombre + "','"+idProfesor+"','" + idGrupo + "');";
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
    
        #endregion

        #region "Actualizaciones"
        public void UPDATE_Historial_alumno(int nIdAlumno, int nIdGrupo, int IdAlumno, int IdGrupo, double Calificacion, int Oportunidad)
        {
            StoreProcedure = "CALL SP_UPDATE_Historial_alumno(" + nIdAlumno.ToString() +
                                                    "," + nIdGrupo.ToString() +
                                                    "," + IdAlumno.ToString() +
                                                    "," + IdGrupo.ToString() +
                                                    "," + Calificacion.ToString() +
                                                    "," + Oportunidad.ToString() + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Insertados"
        public void INSERT_Historial_alumno(int IdAlumno, int IdGrupo, double Calificacion, int Oportunidad)
        {
            StoreProcedure = "CALL SP_INSERT_Historial_alumno(" + IdAlumno.ToString() +
                                                    "," + IdGrupo.ToString() +
                                                    "," + Calificacion.ToString() +
                                                    "," + Oportunidad.ToString() + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion
    }
}
