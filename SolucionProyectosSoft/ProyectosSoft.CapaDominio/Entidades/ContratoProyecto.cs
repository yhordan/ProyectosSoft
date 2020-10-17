using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosSoft.CapaDominio.Entidades
{
    public class ContratoProyecto
    {
        public int idProyecto { get; set; }

        private String nombre;
        private String zonaConstruccion;
        private double presupuestoGeneral;
        private double presupuestoMaterial;
        private double presupuestoProfesionales;
        private double presupuestoPeones;
        private int duracionMeses;
        private int cantidadProfesionales;
        private int cantidadPeones;
        private List<ContratoTrabajador> trabajadores;
        private List<Material> materiales;

        public ContratoProyecto()
        {

        }

        public ContratoProyecto(string nombre, string zonaConstruccion, double presupuestoGeneral, double presupuestoMaterial, double presupuestoProfesionales, double presupuestoPeones, int duracionMeses, int cantidadProfesionales, int cantidadPeones)
        {
            this.nombre = nombre;
            this.zonaConstruccion = zonaConstruccion;
            this.presupuestoGeneral = presupuestoGeneral;
            this.presupuestoMaterial = presupuestoMaterial;
            this.presupuestoProfesionales = presupuestoProfesionales;
            this.presupuestoPeones = presupuestoPeones;
            this.duracionMeses = duracionMeses;
            this.cantidadProfesionales = cantidadProfesionales;
            this.cantidadPeones = cantidadPeones;
        }
        /*
        public ContratoProyecto(string nombre, string zonaConstruccion, double presupuestoGeneral, double presupuestoMaterial, double presupuestoProfesionales, double presupuestoPeones, int duracionMeses, int cantidadProfesionales, int cantidadPeones, List<ContratoTrabajador> trabajadores)
        {
            this.nombre = nombre;
            this.zonaConstruccion = zonaConstruccion;
            this.presupuestoGeneral = presupuestoGeneral;
            this.presupuestoMaterial = presupuestoMaterial;
            this.presupuestoProfesionales = presupuestoProfesionales;
            this.presupuestoPeones = presupuestoPeones;
            this.duracionMeses = duracionMeses;
            this.cantidadProfesionales = cantidadProfesionales;
            this.cantidadPeones = cantidadPeones;
            this.trabajadores = trabajadores;
        }*/

        // public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ZonaConstruccion { get => zonaConstruccion; set => zonaConstruccion = value; }
        public double PresupuestoGeneral { get => presupuestoGeneral; set => presupuestoGeneral = value; }
        public double PresupuestoMaterial { get => presupuestoMaterial; set => presupuestoMaterial = value; }
        public int DuracionMeses { get => duracionMeses; set => duracionMeses = value; }
        public int CantidadProfesionales { get => cantidadProfesionales; set => cantidadProfesionales = value; }
        public int CantidadPeones { get => cantidadPeones; set => cantidadPeones = value; }
        public double PresupuestoProfesionales { get => presupuestoProfesionales; set => presupuestoProfesionales = value; }
        public double PresupuestoPeones { get => presupuestoPeones; set => presupuestoPeones = value; }
        public List<ContratoTrabajador> Trabajadores { get => trabajadores; set => trabajadores = value; }
        public List<Material> Materiales { get => materiales; set => materiales = value; }

        public Boolean esPresupuestoGeneralValido()
        {
            if (this.presupuestoGeneral <= 15000 && this.presupuestoGeneral < calcularPresupuestoGeneral())
            {
                return false;
            }
            return true;
        }

        public Boolean esZonaValida()
        {
            if (this.zonaConstruccion == "RURAL" || this.ZonaConstruccion == "URBANA")
            {
                return true;
            }
            return false;
        }

        public Boolean esPresupuestoMaterialValido()
        {
            if (this.zonaConstruccion == "URBANA" && this.presupuestoMaterial <= 0.4 * this.presupuestoGeneral)
            {
                return true;
            }
            if (this.zonaConstruccion == "RURAL" && this.presupuestoMaterial <= 0.6 * this.presupuestoGeneral)
            {
                return true;
            }
            return false;
        }

        public Boolean esPresupuestoPeonesValido()
        {
            if (this.presupuestoPeones >= (this.presupuestoGeneral * 0.15) && this.presupuestoPeones <= (this.presupuestoGeneral * 0.25))
            {
                return true;
            }
            return false;
        }

        public Boolean esDuracionProyectoValida()
        {
            if (this.duracionMeses > 5 && this.duracionMeses < 24)
            {
                return true;
            }
            return false;
        }

        public Boolean esContratoProyectoValido()
        {
            if (esPresupuestoGeneralValido() && esPresupuestoMaterialValido() && esPresupuestoPeonesValido() && esDuracionProyectoValida())
            {
                return true;
            }
            return false;
        }

        public double calcularPresupuestoProfesionales()
        {
            double presupuestoCalculado = 0.0;
            foreach (ContratoTrabajador trabajador in this.trabajadores)
            {
                if (trabajador.Cargo.Equals("PROFESIONAL"))
                {
                    presupuestoCalculado = presupuestoCalculado + trabajador.esSueldoNeto();
                }
            }
            return presupuestoCalculado;
        }

        public double calcularPresupuestoPeones()
        {
            double presupuestoCalculado = 0.0;
            foreach (ContratoTrabajador trabajador in this.trabajadores)
            {
                if (trabajador.Cargo.Equals("PEON"))
                {
                    presupuestoCalculado = presupuestoCalculado + trabajador.esSueldoNeto();
                }
            }
            return presupuestoCalculado;
        }

        public double calcularPresupuestoGeneral()
        {
            return this.presupuestoMaterial + this.presupuestoPeones + this.presupuestoProfesionales;
        }
    }
}
