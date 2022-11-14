using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_hotel.Habitaciones.Foto
{
    public partial class Photo : Form
    {
        public Photo()
        {
            InitializeComponent();

            Fotos fotos = new Fotos();
            fotos.mostrarFotos(dataGridView1);
            cargarRooms();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            int idRooms = int.Parse(cbxRoom.SelectedValue.ToString());

            try 
            {
                Fotos fotos = new Fotos();

                string connection = "server=localhost;user id=root; password=; database=hotel3";
                string query = "INSERT INTO rooms_photo (caption, file, room_id) VALUES ('" + txtCaption.Text + "', '" + Path.GetFileName(pbImagen.ImageLocation) + "', '" + idRooms + "')";
                MySqlConnection conn = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Succesfully saved");
                conn.Close();

                fotos.mostrarFotos(dataGridView1);

                File.Copy(txtImage.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pbImagen.ImageLocation));

            }
            catch (Exception)
            {
                MessageBox.Show("no subida");
            }

            LimpiarCampos();



        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*jpeg;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtImage.Text = ofd.FileName;
                pbImagen.Image = new Bitmap(ofd.FileName);
                pbImagen.ImageLocation = ofd.FileName;
                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void cargarRooms() 
        {
            cbxRoom.DataSource = null;
            cbxRoom.Items.Clear();
            string sql = "select id, name from rooms_room ORDER BY name ASC";

            string connection = "server=localhost;user id=root; password=; database=hotel3";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            try 
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbxRoom.ValueMember = "id";
                cbxRoom.DisplayMember = "name";
                cbxRoom.DataSource = dt;
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show("no subida" + ex.Message);
            }
            finally 
            {
                conn.Close();
            }

            LimpiarCampos();

        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCaption.Clear();
            
        }
    }
}
