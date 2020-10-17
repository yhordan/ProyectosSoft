using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosSoft.CapaDominio.Entidades
{
    public class ContratoTrabajador
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private double sueldo;
        private String cargo;
        private String fondoPension;
        private ContratoProyecto proyecto;
        private Trabajador trabajador;
        public string areaTrabajador { get; set; }


        /*public ContratoTrabajador(DateTime fechaInicio, DateTime fechaFin, double sueldo, string cargo, string fondoPension, ContratoProyecto proyecto, Trabajador trabajador,string areaTrabajador)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.sueldo = sueldo;
            this.cargo = cargo;
            this.fondoPension = fondoPension;
            this.proyecto = proyecto;
            this.areaTrabajador = areaTrabajador;
            this.trabajador = trabajador;
        }*/

        public double Sueldo { get => sueldo; set => sueldo = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string FondoPension { get => fondoPension; set => fondoPension = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public ContratoProyecto Proyecto { get => proyecto; set => proyecto = value; }
        public Trabajador Trabajador { get => trabajador; set => trabajador = value; }

        public double montoAFP()
        {
            return sueldo * 0.05;
        }

        public double esSueldoNeto()
        {
            double SueldoNeto;
            SueldoNeto = this.sueldo - montoAFP();

            return SueldoNeto;
        }

        public Boolean tieneEdadValida()
        {
            if (trabajador.calcularEdad() >= 21)
            {
                return true;
            }
            return false;
        }

        public Boolean esTiempoDuracionValido()
        {
            TimeSpan interval = this.fechaFin - this.fechaFin;
            DateTime totalTime = new DateTime(interval.Ticks);
            int mesesDiferencia = totalTime.Month - 1;

            if (mesesDiferencia >= 5 && mesesDiferencia < 24)
            {
                return true;
            }
            return false;
        }

        public Boolean esCargoContratoValido()
        {
            if (this.cargo == "PEON")
            {
                if (this.sueldo > 2000)
                {
                    return true;
                }
                return false;
            }
            if (this.cargo == "PROFESIONAL")
            {
                if (this.sueldo > 5000)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public Boolean esContratoValido()
        {
            return true;
        }
    }
}
