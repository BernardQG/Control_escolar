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
    /// Summary description for WS_Historial_alumno
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Historial_alumno : System.Web.Services.WebService
    {

        #region "Consultas"
        [WebMethod]
        public DataSet SELECT_Historial_alumno(string id, string nombre,string idProfesore, string idGrupo)
        {
            return new clsHistorial_alumno().SELECT_Historial_alumno(id, nombre,idProfesore, idGrupo);

        }

        #endregion
        #region "Eliminaciones"
      
        #endregion
        #region "Actualizaciones"
        [WebMethod]
        public void UPDATE_Historial_alumno(int nIdAlumno, int nIdGrupo, int IdAlumno, int IdGrupo, double Calificacion, int Oportunidad)
        {
            new clsHistorial_alumno().UPDATE_Historial_alumno(nIdAlumno, nIdGrupo, IdAlumno, IdGrupo, Calificacion, Oportunidad);
        }
        #endregion

        #region "Insertados"
        [WebMethod]

        public void INSERT_Historial_alumno(int IdAlumno, int IdGrupo, double Calificacion, int Oportunidad)
        {
            new clsHistorial_alumno().INSERT_Historial_alumno(IdAlumno, IdGrupo, Calificacion, Oportunidad);
        }

        #endregion
    }
}
