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
    /// Summary description for WS_Grupo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Grupo : System.Web.Services.WebService
    {
        #region "Consultas"
        [WebMethod]
        public DataSet SELECT_Grupo(string id, string nombre,string idperiodo)
        {
            return new clsGrupo().SELECT_Grupo(id, nombre,idperiodo);

        }

        #endregion
        #region "Eliminaciones"
        [WebMethod]
        public void DELETE_Grupo(int id)
        {
            new clsGrupo().DELETE_Grupo(id);
        }
        #endregion
        #region "Actualizaciones"
        [WebMethod]
        public void UPDATE_Grupo(int IdGrupo, int IdMateria, int IdProfesor, int IdPeriodo)
        {
            new clsGrupo().UPDATE_Grupo(IdGrupo, IdMateria, IdProfesor, IdPeriodo);
        }
        #endregion

        #region "Insertados"
        [WebMethod]

        public void INSERT_Grupo(int IdMateria, int IdProfesor, int IdPeriodo)
        {
            new clsGrupo().INSERT_Grupo(IdMateria, IdProfesor, IdPeriodo);
        }

        #endregion
    }
}

