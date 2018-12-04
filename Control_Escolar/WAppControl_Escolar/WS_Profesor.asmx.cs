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
    /// Summary description for WS_Profesor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Profesor : System.Web.Services.WebService
    {

        #region "Consultas"
        [WebMethod]
        public DataSet SELECT_Profesor(string id, string nombre)
        {
            return new clsProfesor().SELECT_Profesor(id, nombre);
            
        }
        [WebMethod]
        public DataSet SELECT_IProfesor(int id)
        {
            return new clsProfesor().SELECT_IProfesor(id);
        }
   
        #endregion
        #region "Eliminaciones"
        [WebMethod]
        public void DELETE_Profesor(int id)
        {
            new clsProfesor().DELETE_Profesor(id);
        }
        #endregion
        #region "Actualizaciones"
        [WebMethod]
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
            new clsProfesor().UPDATE_Profesor(IdProfesor,
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
                                    Grado_estudios,
                                    Especialidad,Folio_titulo);
        }
        #endregion

        #region "Insertados"
        [WebMethod]
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
            new clsProfesor().INSERT_Profesor(Nombre,
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
                                      Grado_estudios,
                                      Especialidad, Folio_titulo);
        }


        #endregion
    }
}
