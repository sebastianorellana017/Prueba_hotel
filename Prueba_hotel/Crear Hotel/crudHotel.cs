using MySql.Data.MySqlClient;
using Prueba_hotel.Habitaciones.Regla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel.Crear_Hotel
{
    public partial class crudHotel : Form
    {
        public crudHotel()
        {
            InitializeComponent();
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void crudHotel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            

        }

        private void cargarSuperuser()
        {
            

           
        }

        private void cargarRoomid()
        {
            


        }

        private void LimpiarCampos()
        {
           

        }
    }
}
