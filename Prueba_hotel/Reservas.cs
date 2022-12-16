using Npgsql;
using Prueba_hotel.Crear_Hotel;
using Prueba_hotel.Login;
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

namespace Prueba_hotel
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            crudHotel crudhotel = new crudHotel();
            crudhotel.ShowDialog();
        }

        //ConnectionStrings
        readonly string stdPGcon = ConfigurationManager.ConnectionStrings["PGcon"].ConnectionString;

        private void Reservas_Load(object sender, EventArgs e)
        {
            InitButtons();
            ClearTextBoxes();
            ReadRecords();
            cargarRoomId();
            cargarHostId();
        }

        // BOTONES 
        private void InitButtons()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
        }

        // INHABILITAR TEXTBOXES 
        private void StateTextBoxes(bool state)
        {
            if (state == false)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    tb.Enabled = false;
                }
            }
            else if (state == true)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    tb.Enabled = true;
                }
            }
        }

        // LIMPIAR
        private void ClearTextBoxes()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }
            StateTextBoxes(false);
        }

        //********************************** LEER DATAGRID **********************************************
        private void ReadRecords()
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from rooms_room", myPGConnection);
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

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            StateTextBoxes(true);
            btnNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnClear.Enabled = true;
            btnDelete.Enabled = true;


            txtId.Text = dgv.CurrentRow.Cells["Id"].Value.ToString();
            txtName.Text = dgv.CurrentRow.Cells["name"].Value.ToString();
            txtDescripcion.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            txtPais.Text = dgv.CurrentRow.Cells["country"].Value.ToString();
            txtCiudad.Text = dgv.CurrentRow.Cells["city"].Value.ToString();
            txtPrecio.Text = dgv.CurrentRow.Cells["price"].Value.ToString();
            txtDireccion.Text = dgv.CurrentRow.Cells["address"].Value.ToString();

            upHuespedes.Text = dgv.CurrentRow.Cells["guests"].Value.ToString();
            upDormitorios.Text = dgv.CurrentRow.Cells["bedrooms"].Value.ToString();
            upBanos.Text = dgv.CurrentRow.Cells["baths"].Value.ToString();
            upEstacionamientos.Text = dgv.CurrentRow.Cells["parking"].Value.ToString();
            upCamas.Text = dgv.CurrentRow.Cells["beds"].Value.ToString();

            txtIn.Text = dgv.CurrentRow.Cells["created"].Value.ToString();
            txtOut.Text = dgv.CurrentRow.Cells["updated"].Value.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            StateTextBoxes(true);
            btnSave.Enabled = true;
        }

        // CARGAR COMBOBOX
        private void cargarRoomId()
        {
            cbRoomid.DataSource = null;
            cbRoomid.Items.Clear();
            string sql = "select id, name from rooms_roomtype ORDER BY name ASC";

            NpgsqlConnection conn = new NpgsqlConnection(stdPGcon);
            conn.Open();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbRoomid.ValueMember = "id";
                cbRoomid.DisplayMember = "name";
                cbRoomid.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No pudiste subirlo", "Data base error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cargarHostId()
        {
            cbHost.DataSource = null;
            cbHost.Items.Clear();
            string sql = "select id, username from users_user WHERE is_staff = true ORDER BY username ASC";

            NpgsqlConnection conn = new NpgsqlConnection(stdPGcon);
            conn.Open();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbHost.ValueMember = "id";
                cbHost.DisplayMember = "username";
                cbHost.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No pudiste subirlo", "Data base error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRecord();
            ReadRecords();
            ClearTextBoxes();
            btnSave.Enabled = false;
        }

        private void SaveRecord()
        {
            int hostId = int.Parse(cbHost.SelectedValue.ToString());
            int roomId = int.Parse(cbRoomid.SelectedValue.ToString());

            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    // "INSERT INTO rooms_room (name, description, city, price, address, guests, bedrooms, beds, baths, parking) VALUES ('" + txtName.Text + "', '" + txtDescripcion.Text + "', '" + txtCiudad.Text + "' , " + Convert.ToInt32(txtPrecio.Text) + ", '" + txtDireccion.Text + "' , " + Convert.ToInt32(upHuespedes.Text) + ", " + Convert.ToInt32(upDormitorios.Text) + " , " + Convert.ToInt32(upCamas.Text) + "," + Convert.ToInt32(upBanos.Text) + ", " + Convert.ToInt32(upEstacionamientos.Text) + ");";
                    string sql_query = "INSERT INTO rooms_room (name, description, country,city, price, address, guests, bedrooms, beds, baths, parking, host_id, room_type_id) VALUES ('" + txtName.Text + "', '" + txtDescripcion.Text + "', '" + txtPais.Text + "','" + txtCiudad.Text + "' , '" + txtPrecio.Text + "', '" + txtDireccion.Text + "' , '" + upHuespedes.Text + "', '" + upDormitorios.Text + "' , '" + upCamas.Text + "','" + upBanos.Text + "', '" + upEstacionamientos.Text + "', '" + hostId + "', '" + roomId + "');";
                    cmd = new NpgsqlCommand(sql_query, myPGConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Guardado");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("No pudiste agregarlo", "Data base error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int recordId = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            UpdateRecord(recordId);

            ReadRecords();
            ClearTextBoxes();
            InitButtons();
        }

        private void UpdateRecord(int id)
        {
            int hostId = int.Parse(cbHost.SelectedValue.ToString());
            int roomId = int.Parse(cbRoomid.SelectedValue.ToString());

            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();

                    string sql_query = ("UPDATE rooms_room SET name='" + txtName.Text + "', description='" + txtDescripcion.Text + "', country='" + txtPais.Text + "', city='" + txtCiudad.Text + "' , price='" + txtPrecio.Text + "', address='" + txtDireccion.Text + "' , guests='" + upHuespedes.Text + "', bedrooms='" + upDormitorios.Text + "' , beds='" + upCamas.Text + "', baths='" + upBanos.Text + "', parking='" + upEstacionamientos.Text + "', host_id='" + hostId + "' ,room_type_id='" + roomId + "' WHERE id=" + id);
                    cmd = new NpgsqlCommand(sql_query, myPGConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Actualizado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no se pudo actualizar", "data error", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas seguro de borrar", "Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int recordId = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                DeleteRecord(recordId);
                ReadRecords();
            }
            ClearTextBoxes();
            StateTextBoxes(false);
            InitButtons();
        }

        private void DeleteRecord(int id)
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    string sql_query = "DELETE FROM rooms_room WHERE id=" + id;
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd = new NpgsqlCommand(sql_query, myPGConnection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Borrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo borrar", "data error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            InitButtons();
        }
    }
}
