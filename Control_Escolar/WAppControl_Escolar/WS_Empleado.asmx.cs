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
    /// Summary description for WS_Empleado
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Empleado : System.Web.Services.WebService
    {

        #region "Consultas"
        [WebMethod]
        public DataSet SELECT_Empleado(string id, string nombre, string puesto)
        {
            return new clsSelect().SELECT_Empleado(id, nombre, puesto);
        }
        [WebMethod]
        public DataSet SELECT_IEmpleado(int id)
        {
            return new clsSelect().SELECT_IEmpleado(id);
        }
        [WebMethod]
        public DataSet SELECT_Puesto()
        {
            return new clsSelect().SELECT_Puesto();
        }
        #endregion
        #region "Eliminaciones"
        [WebMethod]
        public void DELETE_Empleado(int id)
        {
            new clsDelete().DELETE_Empleado(id);
        }
        #endregion
        #region "Actualizaciones"
        [WebMethod]
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
            new clsUpdate().UPDATE_Empleado(IdEmpleado,
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
                                    IdPuesto,
                                    Grado_estudios);
        }
        #endregion

        #region "Insertados"
        [WebMethod]
        public void INSERT_Empleado(string Nombre,
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
            new clsInsert().INSERT_Empleado(Nombre,
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
                                    IdPuesto,
                                    Grado_estudios);
        }


        #endregion
    }
}
