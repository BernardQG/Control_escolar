using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using LControl_Escolar;

namespace WAppControl_Escolar
{
    /// <summary>
    /// Summary description for WSControl_Escolar
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSControl_Escolar : System.Web.Services.WebService
    {
        #region "Control escolar"
        [WebMethod]
        public Boolean conexionMysql()
        {
            return new clsControl_Escolar().conexionMysql();
        }
        [WebMethod]
        public Boolean conexionDataBase()
        {
            return new clsControl_Escolar().conexionDataBase();
        }
      
        [WebMethod]
        public DataSet UsuarioLog(string Usuario, string Password)
        {
            return new clsControl_Escolar().UsuarioLog(Usuario, Password);
        }
        [WebMethod]
        public DataSet Usuario(string Usuario)
        {
            return new clsControl_Escolar().Usuario(Usuario);
        }
        [WebMethod]
        public DataSet SELECT_Admin()
        {
            return new clsControl_Escolar().SELECT_Admin();
        }

        #endregion

        #region "SELECT"
        #region "Localidad"
        [WebMethod]
                public DataSet SELECT_Pais()
                {
                    return new clsSelect().SELECT_Pais();
                }
                [WebMethod]
                public DataSet SELECT_Estado(int IdPais)
                {
                    return new clsSelect().SELECT_Estado(IdPais);
                }
                [WebMethod]
                public DataSet SELECT_Municipio(int IdEstado)
                {
                    return new clsSelect().SELECT_Municipio(IdEstado);
                }
                [WebMethod]
                public DataSet SELECT_Acentamiento(int IdMunicipio)
                {
                    return new clsSelect().SELECT_Acentamiento(IdMunicipio);
                }
                [WebMethod]
                public DataSet SELECT_CP(string cp)
                {
                    return new clsSelect().SELECT_CP(cp);
                }
            #endregion

            #region "Alumno"
                [WebMethod]
                public DataSet SELECT_Alumno(string id, string nombre, string inscripcion, string pagado, string carrera)
                {
                    return new clsSelect().SELECT_Alumno(id,nombre,inscripcion, pagado, carrera);
                }
                [WebMethod]
                public DataSet SELECT_Carrera()
                {
                    return new clsSelect().SELECT_Carrera();
                }
                [WebMethod]
                public DataSet SELECT_IAlumno(int id)
                {
                    return new clsSelect().SELECT_IAlumno(id);
                }
            #endregion
            #region "Periodo"
                [WebMethod]
                public DataSet SELECT_Periodo(string id)
                {
                    return new clsSelect().SELECT_Periodo(id);
                }
        #endregion
       

        #endregion



        #region "DELETE"
        [WebMethod]
        public void DELETE_Alumno(int id)
        {
            new clsDelete().DELETE_Alumno(id);
        }

       
        #endregion



        #region "UPDATE"
        [WebMethod]
            public void UPDATE_Sesion(int IdUsuario)
            {
                new clsUpdate().UPDATE_Sesion(IdUsuario);
            }
            [WebMethod]

            #region "Alumno"
        
                public void UPDATE_Inscripcion(int IdAlumno, int Estatus)
                {
                    new clsUpdate().UPDATE_Inscripcion(IdAlumno,Estatus);
                }
                [WebMethod]
                public void UPDATE_Alumno(int IdAlumno,
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
                                            int IdAcentamiento,
                                            int IdCarrera,
                                            string Fecha_inscripcion)
                {
                    new clsUpdate().UPDATE_Alumno(IdAlumno,
                                             Nombre,
                                             APaterno,
                                             AMaterno,
                                             Fecha_nacimiento,
                                             Sexo,
                                             Calle,
                                             Numero,
                                             Telefono,
                                             Celular,
                                             Correo,
                                             IdAcentamiento,
                                             IdCarrera,
                                             Fecha_inscripcion);
                }
        #endregion
        #region "Periodo"
        [WebMethod]
        public void UPDATE_Periodo(int IdPeriodo, string Fecha_inicio,string Fecha_fin)
                {
                    new clsUpdate().UPDATE_Periodo(IdPeriodo, Fecha_inicio, Fecha_fin);
                }
        #endregion
       
        #endregion



        #region "INSERT"
        [WebMethod]
        public void INSERT_Alumno(  string Nombre,
                                    string APaterno,
                                    string AMaterno,
                                    string Fecha_nacimiento,
                                    string Sexo,
                                    string Calle,
                                    string Numero,
                                    int? Telefono,
                                    int? Celular,
                                    string Correo,
                                    int IdAcentamiento,
                                    int IdCarrera,
                                    string Fecha_inscripcion)
        {
            new clsInsert().INSERT_Alumno(Nombre,
                                     APaterno,
                                     AMaterno,
                                     Fecha_nacimiento,
                                     Sexo,
                                     Calle,
                                     Numero,
                                     Telefono,
                                     Celular,
                                     Correo,
                                     IdAcentamiento,
                                     IdCarrera,
                                     Fecha_inscripcion);
        }
        #region "Periodo"
        [WebMethod]
        public void INSERT_Periodo(string Fecha_inicio, string Fecha_fin)
            {
                new clsInsert().INSERT_Periodo(Fecha_inicio, Fecha_fin);
            }
        #endregion
       
        #endregion



    }
}
