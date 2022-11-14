using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Prueba_hotel
{
    public partial class Hoteles : Form
    {
        

        public Hoteles()
        {
            InitializeComponent();

            
            Clases.Hoteles reserva = new Clases.Hoteles();
            reserva.mostrarHoteles(dataGridView1);

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Hoteles hoteles = new Clases.Hoteles();
            hoteles.seleccionarHotel(dataGridView1, txtID, txtCreated, txtUpdate, txtDay, txtReservationID);
        }

        private void btnBorrarReserva_Click(object sender, EventArgs e)
        {
            Clases.Hoteles hoteles = new Clases.Hoteles();
            hoteles.eliminarrHotel(txtID);
            hoteles.mostrarHoteles(dataGridView1);

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCreated.Clear();
            txtUpdate.Clear();
            txtDay.Clear();
            txtReservationID.Clear();
        }
    }
}
