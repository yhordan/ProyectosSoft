using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosSoft.CapaDominio.Entidades
{
    public class Trabajador
    {
        private String dni;
        private String nombre;
        private String aplellidoPaterno;
        private String apellidoMaterno;
        private DateTime fechaNacimiento;
        private String direccion;
        private String telefono;
        private String estadoCivil;
        private int añosExperiencia;
        private List<ContratoTrabajador> contratos;
        public int idTrabajador { get; set; }

        /*
        public Trabajador(string dni, string nombre, string aplellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string direccion, string telefono, string estadoCivil, int añosExperiencia, List<ContratoTrabajador> contratos)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.aplellidoPaterno = aplellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.estadoCivil = estadoCivil;
            this.añosExperiencia = añosExperiencia;
            this.contratos = contratos;
           
        }*/

        public Trabajador() { }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string AplellidoPaterno { get => aplellidoPaterno; set => aplellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public int AñosExperiencia { get => añosExperiencia; set => añosExperiencia = value; }

        internal List<ContratoTrabajador> Contratos { get => contratos; set => contratos = value; }

        /*public Boolean esCargoValido()
        {
            if (this.cargo == "PEON")
            {
                return true;
            }
            if (this.cargo == "PROFESIONAL")
            {
                return true;
            }
            return false;
        }*/
        public int calcularEdad()
        {
            DateTime thisDay = DateTime.Today;
            TimeSpan age = thisDay - this.FechaNacimiento;

            DateTime totalTime = new DateTime(age.Ticks);
            int añosResultantes = totalTime.Year - 1;
            return añosResultantes;
        }

        public double calcularSueldoNeto()
        {
            double montoNeto = 0.0;
            DateTime hoy = DateTime.Today;

            if (this.contratos != null)
            {
                foreach (ContratoTrabajador contrato in this.contratos)
                {
                    if (contrato.FechaFin.CompareTo(hoy) <= 0)
                    {
                        montoNeto = montoNeto + contrato.esSueldoNeto();
                    }
                }
            }
            else
            {
                return 0.0;
            }
            return montoNeto;
        }
    }
}
