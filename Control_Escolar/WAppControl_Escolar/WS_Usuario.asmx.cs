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
    /// Summary description for WS_Usuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Usuario : System.Web.Services.WebService
    {
        #region "Consultas"
        [WebMethod]
        public DataSet SELECT_Usuario(string id, string nombre,string usuario)
        {
            return new clsUsuario().SELECT_Usuario(id, nombre,usuario);

        }
        [WebMethod]
        public DataSet SELECT_UserEmpleado()
        {
            return new clsUsuario().SELECT_UserEmpleado();
        }

        #endregion
        #region "Eliminaciones"
        [WebMethod]
        public void DELETE_Usuario(int id)
        {
            new clsUsuario().DELETE_Usuario(id);
        }
        #endregion
        #region "Actualizaciones"
        [WebMethod]
        public void UPDATE_Usuario(int IdUsuario,
                                  string Usuario,
                                  string Password,
                                  int? Admin)
        {
            new clsUsuario().UPDATE_Usuario(IdUsuario, Usuario, Password, Admin);
        }
        #endregion

        #region "Insertados"
        [WebMethod]
        public void INSERT_Usuario(int IdEmpleado,
                                  string Usuario,
                                  string Password,
                                  int? Admin)
        {
            new clsUsuario().INSERT_Usuario(IdEmpleado, Usuario, Password, Admin);
        }


            #endregion
        }
}
