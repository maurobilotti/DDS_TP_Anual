using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TP_Anual_DDS_E4
{

    public class BaseDatos
    {
        private enum TipoQuery
        {
            Obtener, Ejecutar
        }

        private string CadenaConexion = Properties.Settings.Default.ConnectionString;
        public string pComando { get; set; }
        public List<SqlParameter> pParametros = new List<SqlParameter>();
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
            SqlConnection SqlConnection = new SqlConnection();
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection.ConnectionString = this.CadenaConexion;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandType = this.GetCommandType(BaseDatos.TipoQuery.Obtener);
                sqlCommand.CommandText = this.pComando;
                SqlCommand selectCommand = sqlCommand;
                selectCommand.CommandTimeout = this.pTimeOut;
                if (this.pParametros != null)
                {
                    foreach (SqlParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                SqlConnection.Open();
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
            }
            return dataTable;
        }
        public object ObtenerUnicoCampo()
        {
            SqlConnection SqlConnection = new SqlConnection();
            object obj;
            try
            {
                SqlConnection.ConnectionString = this.CadenaConexion;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandType = this.GetCommandType(BaseDatos.TipoQuery.Obtener);
                sqlCommand.CommandText = this.pComando;
                sqlCommand.CommandTimeout = this.pTimeOut;
                if (this.pParametros != null)
                {
                    foreach (SqlParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                SqlConnection.Open();
                obj = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + Environment.NewLine + pComando);
            }
            finally
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
            }
            return obj;
        }
        public bool Ejecutar()
        {
            int num = 1;
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = this.CadenaConexion;
                SqlCommand sqlCommand = new SqlCommand(this.pComando, connection);
                if (this.pParametros != null)
                {
                    foreach (SqlParameter sqlParameter in this.pParametros)
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
            if (this.pComando.TrimStart(new char[1] { ' ' }).StartsWith("exec ", StringComparison.InvariantCultureIgnoreCase))
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