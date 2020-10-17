using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectosSoft.CapaDominio.Entidades;
using ProyectosSoft.CapaAplicacion.Servicios;

namespace ProyectosSoft.CapaPresentacion
{
    public partial class FormRegistrarProyecto : Form
    {
        public FormRegistrarProyecto()
        {
            InitializeComponent();
            this.cmbZonaConstruccion.Items.AddRange(new object[] { "RURAL", "URBANA" });
            this.cmbZonaConstruccion.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbZonaConstruccion.SelectedIndex = 0;
        }

        private void btnRegistrarContrato_Click(object sender, EventArgs e)
        {
            String nombre = "";
            String zonaConstruccion = "";
            double presupuestoGeneral = 0.0;
            double presupuestoMaterial = 0.0;
            double presupuestoProfesional = 0.0;
            double presupuestoPeones = 0.0;
            int duracion = 0;
            int cantidadProfesionales = 0;
            int cantidadPeones = 0;

            String mensajeError = "";
            //Obteniendo los datos
            if (txtNombre.Text == null || txtNombre.Text == "")
            {
                mensajeError = mensajeError + "Nombre";
            }
            else
            {
                nombre = txtNombre.Text;
            }
            if (txtPresupuestoGeneral.Text == null || txtPresupuestoGeneral.Text == "")
            {
                mensajeError = mensajeError + "\n Presupuesto General(este campo es obligatorio)";
            }
            else
            {
                try
                {
                    presupuestoGeneral = Double.Parse(txtPresupuestoGeneral.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Presupuesto General(ha ingresado caracteres, ingrese solo numeros)";
                }
            }
            if (txtPresupuestoMaterial.Text == null || txtPresupuestoMaterial.Text == "")
            {
                mensajeError = mensajeError + "\n Presupuesto Material(este campo es obligatorio)";
            }
            else
            {
                try
                {
                    presupuestoMaterial = Double.Parse(txtPresupuestoMaterial.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Presupuesto Material(ha ingresado caracteres, ingrese solo numeros)";
                }
            }
            if (txtPresupuestoProfesionales.Text == null || txtPresupuestoProfesionales.Text == "")
            {
                mensajeError = mensajeError + "\n Presupuesto Profesionales(este campo es obligatorio)";
            }
            else
            {
                try
                {
                    presupuestoProfesional = Double.Parse(txtPresupuestoProfesionales.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Presupuesto Profesionales(ha ingresado caracteres, ingrese solo numeros)";
                }
            }
            if (txtPresupuestoPeones.Text == null || txtPresupuestoPeones.Text == "")
            {
                mensajeError = mensajeError + "\n Presupuesto Peones(este campo es obligatorio)";
            }
            else
            {
                try
                {
                    presupuestoPeones = Double.Parse(txtPresupuestoPeones.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Presupuesto Peones(ha ingresado caracteres, ingrese solo numeros)";
                }
            }
            if (txtDuracion.Text == null || txtDuracion.Text == "")
            {
                mensajeError = mensajeError + "\n Duracion(este campo debe ser completado)";
            }
            else
            {
                try
                {
                    duracion = Int32.Parse(txtDuracion.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Duracion(ha ingresado caracteres, solo ingrese numeros)";
                }
            }
            if (txtCantidadProfesionales.Text == null || txtCantidadProfesionales.Text == "")
            {
                mensajeError = mensajeError + "\n Cantidad Profesionales(este campo debe ser completado)";
            }
            else
            {
                try
                {
                    cantidadProfesionales = Int32.Parse(txtCantidadProfesionales.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Cantidad Profesionales(ha ingresado caracteres, solo ingrese numeros)";
                }
            }
            if (txtCantidadPeones.Text == null || txtCantidadPeones.Text == "")
            {
                mensajeError = mensajeError + "\n Cantidad Peones(este campo debe ser completado)";
            }
            else
            {
                try
                {
                    cantidadPeones = Int32.Parse(txtCantidadPeones.Text);
                }
                catch (Exception)
                {
                    mensajeError = mensajeError + "\n Cantidad Peones(ha ingresado caracteres, solo ingrese numeros)";
                }
            }
            if (cmbZonaConstruccion.SelectedItem == null)
            {
                mensajeError = mensajeError + "\n Selecione una zona de construccion";
            }
            else
            {
                zonaConstruccion = cmbZonaConstruccion.SelectedItem.ToString();
            }

            if (mensajeError == "")
            {
                //Guardamos Contrato Trabajador
                try
                {
                    ContratoProyecto contratoProyecto = new ContratoProyecto(nombre, zonaConstruccion, presupuestoGeneral, presupuestoMaterial, presupuestoProfesional, presupuestoPeones, duracion, cantidadProfesionales, cantidadPeones);
                    RegistrarProyectoServicio registrarProyectoServicio = new RegistrarProyectoServicio();
                    registrarProyectoServicio.RegistrarContratoProyecto(contratoProyecto);
                    eliminarDatos();
                    MessageBox.Show("El contrato se guardo exitasamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Excepcion Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Se encontraron diversos problemas con los datos ingresados : " + mensajeError, "Datos Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarDatos()
        {
            this.txtNombre.Text = "";
            this.txtPresupuestoGeneral.Text = "";
            this.txtPresupuestoMaterial.Text = "";
            this.txtPresupuestoPeones.Text = "";
            this.txtPresupuestoProfesionales.Text = "";
            this.txtDuracion.Text = "";
            this.txtCantidadPeones.Text = "";
            this.txtCantidadProfesionales.Text = "";
            this.cmbZonaConstruccion.SelectedIndex = 0;
        }

        private void btnEliminarDatos_Click(object sender, EventArgs e)
        {
            eliminarDatos();
        }

        private void FormRegistrarProyecto_Load(object sender, EventArgs e)
        {

        }
    }
}
