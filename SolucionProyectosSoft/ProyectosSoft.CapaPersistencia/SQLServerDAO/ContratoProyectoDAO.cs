using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectosSoft.CapaDominio.Contratos;
using ProyectosSoft.CapaDominio.Entidades;

namespace ProyectosSoft.CapaPersistencia.SQLServerDAO
{
    public class ContratoProyectoDAO : IContratoProyectoDAO
    {
        private readonly GestorSQL gestorSQL;

        public ContratoProyectoDAO(IGestorDAO gestorSQL)
        {
            this.gestorSQL = (GestorSQL)gestorSQL;
        }

        public void GuardarContratoProyecto(ContratoProyecto contratoProyecto)
        {

            string consultaSQL = "insert into ContratoProyecto ( nombre, zonaDeConstruccion, presupuestoGeneral, presupuestoMaterial, presupuestoProfesionales, presupuestoPeones, mesesProyecto, cantidadProfesionales, cantidadPeones) " +
                                 //" values( ' @nombre ','@zona_construccion', @presupuesto_general, @presupuesto_material, @presupuesto_profesionales, @presupuesto_peones, @meses_proyecto, @cantidad_profesionales, @cantidad_peones) ";
                                 " values( '" + contratoProyecto.Nombre + "','" + contratoProyecto.ZonaConstruccion + "', @presupuesto_general, @presupuesto_material, @presupuesto_profesionales, @presupuesto_peones, @meses_proyecto, @cantidad_profesionales, @cantidad_peones) ";

            try
            {
                SqlCommand comando;
                //Guardar la Proyecto
                comando = gestorSQL.ObtenerComandoSQL(consultaSQL);
                //comando.Parameters.AddWithValue("@nombre", contratoProyecto.Nombre);
                //comando.Parameters.AddWithValue("@zona_construccion", contratoProyecto.ZonaConstruccion);
                comando.Parameters.AddWithValue("@presupuesto_general", contratoProyecto.PresupuestoGeneral);
                comando.Parameters.AddWithValue("@presupuesto_material", contratoProyecto.PresupuestoMaterial);
                comando.Parameters.AddWithValue("@presupuesto_profesionales", contratoProyecto.PresupuestoProfesionales);
                comando.Parameters.AddWithValue("@presupuesto_peones", contratoProyecto.PresupuestoPeones);
                comando.Parameters.AddWithValue("@meses_proyecto", contratoProyecto.DuracionMeses);
                comando.Parameters.AddWithValue("@cantidad_profesionales", contratoProyecto.CantidadProfesionales);
                comando.Parameters.AddWithValue("@cantidad_peones", contratoProyecto.CantidadPeones);
                comando.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                throw new InvalidOperationException("Ocurrio un problema al guardar el proyecto.", err);
            }
        }

        public List<ContratoProyecto> ObtenerContratoProyectoPeriodo(string periodo)
        {

            return null;
        }

   
    }
}
