using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectosSoft.CapaDominio.Entidades;

namespace TestProyecto_Soft
{
    [TestClass]
    public class ContratoProyectoTest
    {
        [TestMethod]
        public void esPresupuestoGeneralValidoTest()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoMaterial = 10000;
            contratoProyecto.PresupuestoPeones = 20000;
            contratoProyecto.PresupuestoProfesionales = 18000;
            contratoProyecto.PresupuestoGeneral = 14999;
            bool expected = false;
            bool resultado = contratoProyecto.esPresupuestoGeneralValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esZonaValidaTest()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.ZonaConstruccion = "RURAL";
            bool expected = true;
            bool resultado = contratoProyecto.esZonaValida();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esPresupuestoMaterialValidoTest_01()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.ZonaConstruccion = "URBANA";
            contratoProyecto.PresupuestoMaterial = 30000;
            contratoProyecto.PresupuestoGeneral = 50000;
            bool expected = false;
            bool resultado = contratoProyecto.esPresupuestoMaterialValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esPresupuestoMaterialValidoTest_02()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.ZonaConstruccion = "RURAL";
            contratoProyecto.PresupuestoMaterial = 10000;
            contratoProyecto.PresupuestoGeneral = 50000;
            bool expected = true;
            bool resultado = contratoProyecto.esPresupuestoMaterialValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esPresupuestoPeonesValidoTest()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoPeones = 5000;
            contratoProyecto.PresupuestoGeneral = 100000;
            bool expected = false;
            bool resultado = contratoProyecto.esPresupuestoPeonesValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esDuracionProyectoValida()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.DuracionMeses = 15;
            bool expected = true;
            bool resultado = contratoProyecto.esDuracionProyectoValida();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esContratoProyectoValidoTest_01()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoGeneral = 100000;
            contratoProyecto.ZonaConstruccion = "RURAL";
            contratoProyecto.PresupuestoMaterial = 30000;
            contratoProyecto.PresupuestoPeones = 20000;
            contratoProyecto.PresupuestoProfesionales = 20000;
            contratoProyecto.DuracionMeses = 15;

            bool expected = true;
            bool resultado = contratoProyecto.esContratoProyectoValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esContratoProyectoValidoTest_02()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoGeneral = 14999;
            contratoProyecto.ZonaConstruccion = "RURAL";
            contratoProyecto.PresupuestoMaterial = 30000;
            contratoProyecto.PresupuestoPeones = 20000;
            contratoProyecto.PresupuestoProfesionales = 20000;
            contratoProyecto.DuracionMeses = 15;

            bool expected = false;
            bool resultado = contratoProyecto.esContratoProyectoValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esContratoProyectoValidoTest_03()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoGeneral = 100000;
            contratoProyecto.ZonaConstruccion = "RURAL";
            contratoProyecto.PresupuestoMaterial = 60001;
            contratoProyecto.PresupuestoPeones = 20000;
            contratoProyecto.PresupuestoProfesionales = 20000;
            contratoProyecto.DuracionMeses = 15;

            bool expected = false;
            bool resultado = contratoProyecto.esContratoProyectoValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esContratoProyectoValidoTest_04()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoGeneral = 100000;
            contratoProyecto.ZonaConstruccion = "RURAL";
            contratoProyecto.PresupuestoMaterial = 30000;
            contratoProyecto.PresupuestoPeones = 10000;
            contratoProyecto.PresupuestoProfesionales = 20000;
            contratoProyecto.DuracionMeses = 15;

            bool expected = false;
            bool resultado = contratoProyecto.esContratoProyectoValido();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void esContratoProyectoValidoTest_05()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoGeneral = 100000;
            contratoProyecto.ZonaConstruccion = "RURAL";
            contratoProyecto.PresupuestoMaterial = 30000;
            contratoProyecto.PresupuestoPeones = 20000;
            contratoProyecto.PresupuestoProfesionales = 20000;
            contratoProyecto.DuracionMeses = 3;

            bool expected = false;
            bool resultado = contratoProyecto.esContratoProyectoValido();
            Assert.AreEqual(expected, resultado);
        }

        private List<ContratoTrabajador> trabajadoresContratados()
        {
            List<ContratoTrabajador> contratosDeTrabajadores = new List<ContratoTrabajador>();

            contratosDeTrabajadores.Add(new ContratoTrabajador(1000, "PEON"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(3000, "PROFESIONAL"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(1200, "PEON"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(930, "PEON"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(3500, "PROFESIONAL"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(2800, "PROFESIONAL"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(1300, "PEON"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(3700, "PROFESIONAL"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(1900, "PEON"));
            contratosDeTrabajadores.Add(new ContratoTrabajador(2000, "PEON"));

            return contratosDeTrabajadores;
        }

        [TestMethod]
        public void calcularPresupuestoProfesionalesTest()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.Trabajadores = trabajadoresContratados();

            //double expected = 13000;
            double expected = 12350;
            double resultado = contratoProyecto.calcularPresupuestoProfesionales();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void calcularPresupuestoPeonesTest()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.Trabajadores = trabajadoresContratados();

            //double expected = 8330;
            double expected = 7913.5;
            double resultado = contratoProyecto.calcularPresupuestoPeones();
            Assert.AreEqual(expected, resultado);
        }

        [TestMethod]
        public void calcularPresupuestoGeneralTest()
        {
            ContratoProyecto contratoProyecto = new ContratoProyecto();
            contratoProyecto.PresupuestoPeones = 5000;
            contratoProyecto.PresupuestoMaterial = 18000;
            contratoProyecto.PresupuestoProfesionales = 17000;
            double expected = 40000;
            double resultado = contratoProyecto.calcularPresupuestoGeneral();
            Assert.AreEqual(expected, resultado);
        }
    }
}
