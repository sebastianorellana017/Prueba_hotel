using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel.Habitaciones.Comodidad
{
    public partial class Amenity : Form
    {
        public Amenity()
        {
            InitializeComponent();

            Comodidades comodidad = new Comodidades();
            comodidad.mostrarComodidad(dataGridView1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Comodidades comodidad = new Comodidades();
            comodidad.guardarComodidad(txtComodidad);
            comodidad.mostrarComodidad(dataGridView1);

            LimpiarCampos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Comodidades comodidad = new Comodidades();
            comodidad.modificarInstalacion(txtID, txtComodidad);
            comodidad.mostrarComodidad(dataGridView1);

            LimpiarCampos();

        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCreado.Clear();
            txtActualizado.Clear();
            txtComodidad.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Comodidades comodidad = new Comodidades();
            comodidad.eliminarComodidad(txtID);
            comodidad.mostrarComodidad(dataGridView1);

            LimpiarCampos();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Comodidades comodidad = new Comodidades();
            comodidad.seleccionarInstalacion(dataGridView1, txtID, txtCreado, txtActualizado, txtComodidad);
        }
    }
}
