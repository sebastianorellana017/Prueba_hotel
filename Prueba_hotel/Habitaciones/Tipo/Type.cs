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

namespace Prueba_hotel.Habitaciones.Tipo
{
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();

        }

        //ConnectionStrings
        readonly string stdPGcon = ConfigurationManager.ConnectionStrings["PGcon"].ConnectionString;

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            StateTextBoxes(true);
            btnNew.Enabled = false;
            btnModificar.Enabled = true;
            btnClear.Enabled = true;
            btnBorrar.Enabled = true;


            txtID.Text = dgv.CurrentRow.Cells["Id"].Value.ToString();
            txtCreado.Text = dgv.CurrentRow.Cells["Created"].Value.ToString();
            txtActualizado.Text = dgv.CurrentRow.Cells["updated"].Value.ToString();
            txtComodidad.Text = dgv.CurrentRow.Cells["name"].Value.ToString();

        }

        private void Type_Load(object sender, EventArgs e)
        {
            ReadRecords();
            InitButtons();
            StateTextBoxes(false);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            StateTextBoxes(true);
            btnGuardar.Enabled = true;
        }

        private void ClearTextBoxes()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }
            StateTextBoxes(false);
        }

        // BOTONES 
        private void InitButtons()
        {
            btnNew.Enabled = true;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnClear.Enabled = false;
            btnBorrar.Enabled = false;

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

        //********************************** LEER DATAGRID **********************************************
        private void ReadRecords()
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from rooms_roomtype", myPGConnection);
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
            SaveRecord();
            ReadRecords();
            ClearTextBoxes();
            btnGuardar.Enabled = false;
        }

        private void SaveRecord()
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();

                    string sql_query = "INSERT INTO rooms_roomtype(name) VALUES" +
                                       "('" + txtComodidad.Text + "')";
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int recordId = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            UpdateRecord(recordId);

            ReadRecords();
            ClearTextBoxes();
            InitButtons();
        }

        private void UpdateRecord(int id)
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();

                    string sql_query = ("UPDATE rooms_roomtype SET name='" + txtComodidad.Text + "' WHERE id=" + id);
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

        private void btnBorrar_Click(object sender, EventArgs e)
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
                    string sql_query = "DELETE FROM rooms_roomtype WHERE id=" + id;
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
