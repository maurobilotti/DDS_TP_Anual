using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace TP_Anual_DDS_Desktop
{

    public class BaseDatos
    {
        private enum TipoQuery
        {
            Obtener, Ejecutar
        }

        string CadenaConexion = TP_Anual_DDS_Desktop.Properties.Settings.Default.BaseDatos_DDSConnectionString;
        public string pComando { get; set; }
        public List<SqlCeParameter> pParametros = new List<SqlCeParameter>();
        public int pTimeOut = 0;
        public CommandType? pTipoComando;
        
        public BaseDatos()
        {

        }

        public BaseDatos(string _Comando)
        {
            this.pComando = _Comando;
        }
        
        public DataTable ObtenerDataTable()
        {
            SqlCeConnection sqlConnection = new SqlCeConnection();
            DataTable dataTable = new DataTable();
            try
            {
                sqlConnection.ConnectionString = this.CadenaConexion;
                SqlCeCommand sqlCommand = new SqlCeCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = this.GetCommandType(BaseDatos.TipoQuery.Obtener);
                sqlCommand.CommandText = this.pComando;
                SqlCeCommand selectCommand = sqlCommand;
                selectCommand.CommandTimeout = this.pTimeOut;
                if (this.pParametros != null)
                {
                    foreach (SqlCeParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlConnection.Open();
                new SqlCeDataAdapter(selectCommand).Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return dataTable;
        }

        public object ObtenerUnicoCampo()
        {
            SqlCeConnection sqlConnection = new SqlCeConnection();
            object obj;
            try
            {
                sqlConnection.ConnectionString = this.CadenaConexion;
                SqlCeCommand sqlCommand = new SqlCeCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = this.GetCommandType(BaseDatos.TipoQuery.Obtener);
                sqlCommand.CommandText = this.pComando;
                sqlCommand.CommandTimeout = this.pTimeOut;
                if (this.pParametros != null)
                {
                    foreach (SqlCeParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlConnection.Open();
                obj = sqlCommand.ExecuteScalar();
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + Environment.NewLine+ pComando);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return obj;
        }

        public bool Ejecutar()
        {
            int num = 1;
            SqlCeConnection connection = new SqlCeConnection();
            try
            {
                connection.ConnectionString = this.CadenaConexion;
                SqlCeCommand sqlCommand = new SqlCeCommand(this.pComando, connection);
                if (this.pParametros != null)
                {
                    foreach (SqlCeParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlCommand.CommandTimeout = this.pTimeOut;
                sqlCommand.CommandType = this.GetCommandType(BaseDatos.TipoQuery.Ejecutar);
                connection.Open();
                num = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return (num == 1);
        }

        private CommandType GetCommandType(BaseDatos.TipoQuery _TipoQuery)
        {
            if (this.pTipoComando.HasValue)
                return this.pTipoComando.Value;
            if (this.pComando.TrimStart(new char[1]{' '}).StartsWith("exec ", StringComparison.InvariantCultureIgnoreCase))
            {
                this.pComando = this.pComando.Remove(0, 5);
                return CommandType.StoredProcedure;
            }
            else
            {
                switch (_TipoQuery)
                {
                    case BaseDatos.TipoQuery.Ejecutar:
                        return this.pComando.ToLowerInvariant().Contains("update ") || this.pComando.ToLowerInvariant().Contains("insert ") 
                            || this.pComando.ToLowerInvariant().Contains("delete ") ? CommandType.Text : CommandType.StoredProcedure;
                    default:
                        return this.pComando.ToLowerInvariant().Contains("select ") ? CommandType.Text : CommandType.StoredProcedure;
                }
            }
        }
    }
}