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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Prueba_hotel
{
    public partial class Hoteles : Form
    {
        

        public Hoteles()
        {
            InitializeComponent();


        }
       
        private void Hoteles_Load(object sender, EventArgs e)
        {
            ReadRecords();
            InitButtons();
        }

        //ConnectionStrings
        readonly string stdPGcon = ConfigurationManager.ConnectionStrings["PGcon"].ConnectionString;

        // BOTONES
        private void InitButtons()
        {
            btnBorrarReserva.Enabled = false;
        }


        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            btnBorrarReserva.Enabled = true;

            txtID.Text = dgv.CurrentRow.Cells["Id"].Value.ToString();
            txtCreated.Text = dgv.CurrentRow.Cells["Created"].Value.ToString();
            txtUpdate.Text = dgv.CurrentRow.Cells["updated"].Value.ToString();
            txtDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            txtReservationID.Text = dgv.CurrentRow.Cells["reservation_id"].Value.ToString();
        }

        private void btnBorrarReserva_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas seguro de borrar", "Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int recordId = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                DeleteRecord(recordId);
                ReadRecords();
            }
            ClearTextBoxes();
            //StateTextBoxes(false);
            InitButtons();

        }

        private void DeleteRecord(int id)
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    string sql_query = "DELETE FROM reservations_bookedday WHERE id=" + id;
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

        private void ClearTextBoxes()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
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
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from reservations_bookedday", myPGConnection);
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

    }
}
