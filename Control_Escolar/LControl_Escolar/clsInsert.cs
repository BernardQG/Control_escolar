using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    public class clsInsert
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        #region "Alumno"
        public void INSERT_Alumno(string Nombre,
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
                                  int IdCarrera,
                                  string Fecha_inscripcion)
        {
            StoreProcedure = "CALL SP_INSERT_Alumno('" + Nombre +
                                                    "','" + APaterno +
                                                    "','" + AMaterno +
                                                    "','" + Fecha_nacimiento +
                                                    "','" + Sexo +
                                                    "','" + Calle +
                                                    "','" + Numero +
                                                    "'," + ((Telefono==null)?"null":Telefono.ToString()) +
                                                    "," + ((Celular==null)?"null":Celular.ToString()) +
                                                    ",'" + Correo +
                                                    "'," + IdAcentamiento.ToString() +                                                    
                                                    "," + IdCarrera.ToString() +
                                                    ",'" + Fecha_inscripcion + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion
        #region "Periodo"

        public void INSERT_Periodo( string Fecha_inicio,
                                 string Fecha_fin)
        {
            StoreProcedure = "CALL SP_INSERT_Periodo('"  + Fecha_inicio.ToString() +
                                                    "','" + Fecha_fin.ToString() + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Empleado"

        public void INSERT_Empleado(     string Nombre,
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
                                         int? IdPuesto,
                                         string Grado_estudios)
        {
            StoreProcedure = "CALL SP_INSERT_uEmpleado('" + Nombre +
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
                                                    "," + IdPuesto.ToString() +
                                                    ",'" + Grado_estudios + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion
    }
}
