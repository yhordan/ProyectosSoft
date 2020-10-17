using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectosSoft.CapaDominio.Contratos;
using ProyectosSoft.CapaDominio.Entidades;


namespace ProyectosSoft.CapaPersistencia.SQLServerDAO
{
    public class ContratoTrabajadorDAO : IContratoTrabajadorDAO
    {
        private readonly GestorSQL gestorSQL;

        public ContratoTrabajadorDAO(IGestorDAO gestorSQL)
        {
            this.gestorSQL = (GestorSQL)gestorSQL;
        }

        public void GuardarContratoTrabajador(ContratoTrabajador contratoTrabajador)
        {

            try
            {
                gestorSQL.AbrirConexion();
                SqlCommand comando;
                //Guardar la Proyecto
                comando = gestorSQL.ObtenerComandoDeProcedimiento("sp_crearContratoTrabajador");
                comando.Parameters.AddWithValue("@fechaInicio", contratoTrabajador.FechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", contratoTrabajador.FechaFin);
                comando.Parameters.AddWithValue("@sueldo", contratoTrabajador.Sueldo);
                comando.Parameters.AddWithValue("@cargo", contratoTrabajador.Cargo);
                comando.Parameters.AddWithValue("@FondoPension", contratoTrabajador.FondoPension);
                comando.Parameters.AddWithValue("@AreaTrabajador", contratoTrabajador.areaTrabajador);
                comando.Parameters.AddWithValue("@IdTrabajador", contratoTrabajador.Trabajador.idTrabajador);
                comando.Parameters.AddWithValue("@IdProyecto", contratoTrabajador.Proyecto.idProyecto);
                comando.ExecuteNonQuery();

            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Ocurrio un problema al guardar el proyecto.", err);
            }
            finally
            {
                gestorSQL.CerrarConexion();
            }
        }
        /*
        public ContratoTrabajador ObtenerContratoPorDNI(String dni)
        {
            Trabajador trabajador = new Trabajador();
            try
            {
                ContratoTrabajador contratoTrabajador;
                gestorSQL.AbrirConexion();
                SqlCommand comando;
                //Guardar la Proyecto
                comando = gestorSQL.ObtenerComandoDeProcedimiento("obtener_contrato_por_dni");
                comando.Parameters.AddWithValue("@dni", dni);
 
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    contratoTrabajador = new ContratoTrabajador(Convert.ToDateTime(dr["fechaInicio"]),
                                                                 Convert.ToDateTime(dr["fechaFin"]),
                                                                 Convert.ToDouble(dr["sueldo"]),
                                                                 Convert.ToString(dr["cargo"]),
                                                                 Convert.ToDateTime(dr["fechaInicio"]));
                                                                
                }

            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Ocurrio un problema al buscar.", err);
            }
            finally
            {
                gestorSQL.CerrarConexion();
            }

            
        }
        */
        
        public List<ContratoTrabajador> ObtenerContratoTrabajadorPeriodo(string periodo)
        {

            return null;
        }
    }
}
