using Prueba_hotel.Crear_Hotel;
using Prueba_hotel.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();

            Clases.Reservas reservas = new Clases.Reservas();
            reservas.mostrarReservas(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            crudHotel crudhotel = new crudHotel();
            crudhotel.ShowDialog();     
        }

        
    }
}
