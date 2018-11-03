using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    public class clsDelete
    {
        clsHConexion contrato = new clsHConexion();
        string StoreProcedure;
        public Boolean DELETE_Alumno(int id)
        {                        
            StoreProcedure = "CALL SP_DELETE_Alumno('"+id+"');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);
           
            contrato.Abrir();
            try
            {
                comando.ExecuteReader();
                contrato.Cerrar();
                return true;
            }
            catch (Exception)
            {
                contrato.Cerrar();
                return false;
            }           
            
            
        }
    }
}
