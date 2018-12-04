using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace LControl_Escolar
{
    
    public class clsUpdate
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;

        public void UPDATE_Sesion(int IdUsuario)
        {

            StoreProcedure = "CALL SP_UPDATE_Sesion(" + IdUsuario.ToString() + ");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);
            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }

        #region "Alumnos"

        public void UPDATE_Inscripcion(int IdAlumno, int Estatus)
        {
            StoreProcedure = "CALL SP_UPDATE_Inscripcion(" +IdAlumno.ToString()+","+Estatus.ToString()+");";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            
            
                comando.ExecuteReader();
                contrato.Cerrar();            
        }

        public void UPDATE_Alumno(  int IdAlumno,
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
					                int IdCarrera,
					                string Fecha_inscripcion)
        {
            StoreProcedure = "CALL SP_UPDATE_Alumno(" + IdAlumno.ToString()+
                                                    ",'"+ Nombre +
                                                    "','" + APaterno +
                                                    "','" + AMaterno +
                                                    "','" + Fecha_nacimiento +
                                                    "','" + Sexo +
                                                    "','" + Calle +
                                                    "','" + Numero +
                                                    "'," + ((Telefono == null) ? "null" : Telefono.ToString()) +
                                                    "," + ((Celular == null) ? "null" : Celular.ToString()) +                                                    
                                                    ",'" + Correo +
                                                    "'," +  IdAcentamiento.ToString() +
                                                    "," + IdCarrera.ToString() +
                                                    ",'" + Fecha_inscripcion + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Periodos"

        public void UPDATE_Periodo(int IdPeriodo,                                  
                                  string Fecha_inicio,
                                  string Fecha_fin)
        {
            StoreProcedure = "CALL SP_UPDATE_Periodo(" + IdPeriodo.ToString() +
                                                    ",'" + Fecha_inicio.ToString() +
                                                    "','" + Fecha_fin.ToString() + "');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            contrato.Abrir();
            comando.ExecuteReader();
            contrato.Cerrar();
        }
        #endregion

        #region "Empleado"

        public void UPDATE_Empleado(int IdEmpleado,
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
                                   int? IdPuesto,
                                   string Grado_estudios)
        {
            StoreProcedure = "CALL SP_UPDATE_Empleado(" + IdEmpleado.ToString() +
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
