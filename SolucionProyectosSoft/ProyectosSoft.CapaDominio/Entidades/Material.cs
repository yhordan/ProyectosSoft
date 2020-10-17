using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosSoft.CapaDominio.Entidades
{
    public class Material
    {
        String codigo;
        int cantidadDisponible;
        int cantidadContable;
        double costo;
        String descripcion;

        public string Codigo { get => codigo; set => codigo = value; }
        public int CantidadDisponible { get => cantidadDisponible; set => cantidadDisponible = value; }
        public int CantidadContable { get => cantidadContable; set => cantidadContable = value; }
        public double Costo { get => costo; set => costo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public double calcularCantidadDisponible()
        {
            return 0.0;
        }

        public Boolean tieneStock()
        {
            return true;
        }
    }
}
