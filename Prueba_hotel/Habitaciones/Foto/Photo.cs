using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            cargarRooms2();
            ReadRecords();
        }

        readonly string stdPGcon = ConfigurationManager.ConnectionStrings["PGcon"].ConnectionString;

        private void ReadRecords()
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from rooms_photo", myPGConnection);
                    DataTable dt = new DataTable();
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dgv.DataSource = dt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("no pudiste conectarte", "data base error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idRooms = int.Parse(cbxRoom.SelectedValue.ToString());

            try
            {
                string query = "INSERT INTO rooms_photo (caption, file, room_id) VALUES ('" + txtCaption.Text + "', '" + Path.GetFileName(pbImagen.ImageLocation) + "', '" + idRooms + "')";
                NpgsqlConnection conn = new NpgsqlConnection(stdPGcon);
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Succesfully saved");
                conn.Close();

                ReadRecords();

                File.Copy(txtImage.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pbImagen.ImageLocation));

            }
            catch (Exception)
            {
                MessageBox.Show("no subida");
            }

            LimpiarCampos();
        }

        private void cargarRooms2()
        {
            cbxRoom.DataSource = null;
            cbxRoom.Items.Clear();
            string sql = "select id, name from rooms_room ORDER BY name ASC";

            //string connection = "server=dpg-cealsuirrk0bbtcnfe40-a.oregon-postgres.render.com;user id=copo; password=iRsuOOu5zeLdT7medvUhcQL2JJuGPHnn; ; database=copo";
            NpgsqlConnection conn = new NpgsqlConnection(stdPGcon);
            conn.Open();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbxRoom.ValueMember = "id";
                cbxRoom.DisplayMember = "name";
                cbxRoom.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No pudiste subirlo", "Data base error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            finally
            {
                conn.Close();
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
     

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtCaption.Clear();
            
        }

        private void Photo_Load(object sender, EventArgs e)
        {
            cargarRooms2();
            ReadRecords();
        }
    }
}
