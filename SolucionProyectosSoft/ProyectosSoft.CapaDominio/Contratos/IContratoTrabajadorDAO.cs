using ProyectosSoft.CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectosSoft.CapaDominio.Contratos
{
    public interface IContratoTrabajadorDAO
    {
        void GuardarContratoTrabajador(ContratoTrabajador contratoTrabajador);
        List<ContratoTrabajador> ObtenerContratoTrabajadorPeriodo(string periodo);
    }
}
