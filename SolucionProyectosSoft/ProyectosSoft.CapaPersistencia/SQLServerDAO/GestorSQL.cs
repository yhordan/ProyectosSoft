using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyectosSoft.CapaDominio.Contratos;

namespace ProyectosSoft.CapaPersistencia.SQLServerDAO
{
    public class GestorSQL : IGestorDAO
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;

        public void AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = "Data Source=(local);Initial Catalog=BDProyectoConstructora;Integrated Security=true";
                conexion.Open();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error en la conexión con la Base de Datos.", err);
            }

        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al cerrar la conexión con la Base de Datos.", err);
            }

        }

        public void IniciarTransaccion()
        {
            try
            {
                AbrirConexion();
                transaccion = conexion.BeginTransaction();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al iniciar la transacción con la Base de Datos.", err);
            }
        }

        public void TerminarTransaccion()
        {
            try
            {
                transaccion.Commit();
                conexion.Close();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al terminar la transacción con la Base de Datos.", err);
            }
        }

        public void CancelarTransaccion()
        {
            try
            {
                transaccion.Rollback();
                conexion.Close();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al cancelar la transacción con la Base de Datos.", err);
            }
        }

        public SqlDataReader EjecutarConsulta(String sentenciaSQL)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                    comandoSQL.Transaction = transaccion;
                comandoSQL.CommandText = sentenciaSQL;
                comandoSQL.CommandType = CommandType.Text;
                return comandoSQL.ExecuteReader();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al ejecutar consulta en la Base de Datos.", err);
            }
        }

        public SqlCommand ObtenerComandoSQL(String sentenciaSQL)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                    comandoSQL.Transaction = transaccion;
                comandoSQL.CommandText = sentenciaSQL;
                comandoSQL.CommandType = CommandType.Text;
                return comandoSQL;
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al ejecutar comando en la Base de Datos.", err);
            }
        }

        public SqlCommand ObtenerComandoDeProcedimiento(String procedimientoAlmacenado)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                    comandoSQL.Transaction = transaccion;
                comandoSQL.CommandText = procedimientoAlmacenado;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                return comandoSQL;
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Error al ejecutar comando en la Base de Datos.", err);
            }
        }
    }
}
