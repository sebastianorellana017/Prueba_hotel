using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


namespace Prueba_hotel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible=true;  
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            //Submenu.Visible = true;

            if(!Submenu.Visible)
                Submenu.Visible = true;
            else
                Submenu.Visible = false;
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            //Submenu.Visible = false;
            AbrirFormHija(new Habitaciones.Comodidad.Amenity());
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            //Submenu.Visible = false;
            AbrirFormHija(new Habitaciones.Instalacion.Facility());
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            //Submenu.Visible = false;
            AbrirFormHija(new Habitaciones.Tipo.Type());
        }
       
        private void AbrirFormHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Hoteles());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Logo());
        }

        private void btnReservas2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Reservas());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Usuarios());
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Habitaciones.Regla.Rules());
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Habitaciones.Foto.Photo());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //pictureBox2.LinkVisited = true;
            //System.Diagnostics.Process.Start("www.github.com/sebastianorellana017/Prueba_hotel");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("www.github.com/sebastianorellana017/Prueba_hotel");
        }
    }
}