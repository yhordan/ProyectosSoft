using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectosSoft.CapaDominio.Contratos;
using ProyectosSoft.CapaDominio.Entidades;
using ProyectosSoft.CapaPersistencia.SQLServerDAO;

namespace ProyectosSoft.CapaAplicacion.Servicios
{
    public class RegistrarProyectoServicio
    {
        private readonly IContratoProyectoDAO contratoProyectoDAO;
        private readonly IGestorDAO gestorDAO;

        public RegistrarProyectoServicio()
        {
            gestorDAO = new GestorSQL();
            contratoProyectoDAO = new ContratoProyectoDAO(gestorDAO);
        }

        public void RegistrarContratoProyecto(ContratoProyecto contratoProyecto)
        {
            if (contratoProyecto.esContratoProyectoValido())
            {
                gestorDAO.AbrirConexion();
                contratoProyectoDAO.GuardarContratoProyecto(contratoProyecto);
                gestorDAO.CerrarConexion();
            }
            else
            {
                throw new Exception("Los datos ingresados no cumplen con las reglas de negocio");
            }
        }
    }
}
