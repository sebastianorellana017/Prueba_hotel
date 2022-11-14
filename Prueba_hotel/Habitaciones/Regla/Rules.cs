using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel.Habitaciones.Regla
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();

            Reglas reglas = new Reglas();
            reglas.mostrarReglas(dataGridView1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Reglas reglas = new Reglas();
            reglas.guardarReglas(txtReglas);
            reglas.mostrarReglas(dataGridView1);

            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Reglas reglas = new Reglas();
            reglas.modificarReglas(txtID, txtReglas);
            reglas.mostrarReglas(dataGridView1);

            LimpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Reglas reglas = new Reglas();
            reglas.eliminarReglas(txtID);
            reglas.mostrarReglas(dataGridView1);

            LimpiarCampos();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Reglas reglas = new Reglas();
            reglas.seleccionarReglas(dataGridView1, txtID, txtCreado, txtActualizado, txtReglas);
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCreado.Clear();
            txtActualizado.Clear();
            txtReglas.Clear();
        }
    }
}
