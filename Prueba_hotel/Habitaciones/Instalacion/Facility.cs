using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel.Habitaciones.Instalacion
{
    public partial class Facility : Form
    {
        public Facility()
        {
            InitializeComponent();

            Instalaciones instalaciones = new Instalaciones();
            instalaciones.mostrarInstalacion(dataGridView1);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Instalaciones instalaciones = new Instalaciones();
            instalaciones.seleccionarInstalacion(dataGridView1, txtID, txtCreado, txtActualizado, txtInstalacion);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Instalaciones instalacion = new Instalaciones();
            instalacion.guardarInstalacion(txtInstalacion);
            instalacion.mostrarInstalacion(dataGridView1);

            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Instalaciones instalacion = new Instalaciones();
            instalacion.modificarInstalacion(txtID, txtInstalacion);
            instalacion.mostrarInstalacion(dataGridView1);

            LimpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Instalaciones instalacion = new Instalaciones();
            instalacion.eliminarInstalacion(txtID);
            instalacion.mostrarInstalacion(dataGridView1);

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCreado.Clear();
            txtActualizado.Clear();
            txtInstalacion.Clear();
        }
    }
}
