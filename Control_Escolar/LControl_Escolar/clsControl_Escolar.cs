using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LControl_Escolar
{
    public class clsControl_Escolar
    {
        clsHConexion contrato = new clsHConexion();
        
       
        string StoreProcedure;

        
        public Boolean conexionMysql()
        {                       
             return contrato.Abrir();            
        }

        public Boolean conexionDataBase()
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_DataBase();";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);

            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            _mySqlDataAdapter.SelectCommand = comando;
            if (contrato.Abrir())
            {

                _mySqlDataAdapter.Fill(_dataSet);
                contrato.Cerrar();
                if(_dataSet.Tables[0].Rows.Count!=0)
                return true;
                else return false;
            }
            else return false;
        }

      

        public DataSet UsuarioLog(string Usuario, string Password)
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_UsuarioLog('" + Usuario + "','"+Password+"','"+ contrato.Llave+"');";
            MySqlCommand comando = new MySqlCommand(StoreProcedure, contrato.conexion);
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            _mySqlDataAdapter.SelectCommand = comando;
            if (contrato.Abrir())
            {
                _mySqlDataAdapter.Fill(_dataSet);
                contrato.Cerrar();
                if (_dataSet.Tables[0].Rows.Count !=0)
                    return _dataSet;
                else return null;
            }
            else return null;
        
        }
        public DataSet Usuario(string Usuario)
        {
            DataSet _dataSet = new DataSet();
            StoreProcedure = "CALL SP_SELECT_Usuario('" + Usuario + "','" + contrato.Llave + "');";
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
