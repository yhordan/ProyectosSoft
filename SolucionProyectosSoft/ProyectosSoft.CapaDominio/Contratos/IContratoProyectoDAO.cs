using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectosSoft.CapaDominio.Entidades;

namespace ProyectosSoft.CapaDominio.Contratos
{
    public interface IContratoProyectoDAO
    {
        void GuardarContratoProyecto(ContratoProyecto contratoProyecto);
        List<ContratoProyecto> ObtenerContratoProyectoPeriodo(string periodo);
    }


}
