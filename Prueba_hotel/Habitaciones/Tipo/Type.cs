using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel.Habitaciones.Tipo
{
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();

            Tipos tipos = new Tipos();
            tipos.mostrarTipos(dataGridView1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Tipos tipos = new Tipos();
            tipos.guardarTipos(txtTiposs);
            tipos.mostrarTipos(dataGridView1);

            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Tipos tipos = new Tipos();
            tipos.modificarTipos(txtID, txtTiposs);
            tipos.mostrarTipos(dataGridView1);

            LimpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Tipos tipos = new Tipos();
            tipos.eliminarTipos(txtID);
            tipos.mostrarTipos(dataGridView1);

            LimpiarCampos();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tipos tipos = new Tipos();
            tipos.seleccionarTipos(dataGridView1, txtID, txtCreado, txtActualizado, txtTiposs);
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCreado.Clear();
            txtActualizado.Clear();
            txtTiposs.Clear();
        }
    }
}
