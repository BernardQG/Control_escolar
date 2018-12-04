using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    public class clsAuditria
    {
        clsHConexion contrato = new clsHConexion();


        string StoreProcedure;
        public DataSet SELECT_Auditoria()
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_Auditoria();";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            _mySqlDataAdapter.SelectCommand = comando;
            if (contrato.Abrir())
            {
                _mySqlDataAdapter.Fill(_dataSet);
                contrato.Cerrar();
                if (_dataSet.Tables[0].Rows.Count > 0)
                    return _dataSet;
                else
                    return null;
            }
            else return null;

        }
    }
}
