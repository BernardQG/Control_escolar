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
    /// Summary description for WS_Materia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Materia : System.Web.Services.WebService
    {

        #region "Consultas"
        [WebMethod]
        public DataSet SELECT_Materia(string id, string nombre)
        {
            return new clsMateria().SELECT_Materia(id, nombre);

        }

        #endregion
        #region "Eliminaciones"
        [WebMethod]
        public void DELETE_Materia(int id)
        {
            new clsMateria().DELETE_Materia(id);
        }
        #endregion
        #region "Actualizaciones"
        [WebMethod]
        public void UPDATE_Materia(int IdMateria,
                                  string Nombre,
                                  int? Creditos)
        {
            new clsMateria().UPDATE_Materia(IdMateria,Nombre, Creditos);
        }
        #endregion

        #region "Insertados"
        [WebMethod]
     
        public void INSERT_Materia(
                                string Nombre,
                                int? Creditos)
        {
            new clsMateria().INSERT_Materia(Nombre, Creditos);
        }

        #endregion
    }
}
