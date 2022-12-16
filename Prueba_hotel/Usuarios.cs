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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();


        }

        //ConnectionStrings
        readonly string stdPGcon = ConfigurationManager.ConnectionStrings["PGcon"].ConnectionString;

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ReadRecords();
        }

        // ***************** DATAGRID ********************
        private void ReadRecords()
        {
            try
            {
                using (NpgsqlConnection myPGConnection = new NpgsqlConnection(stdPGcon))
                {
                    myPGConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from users_user", myPGConnection);
                    DataTable dt = new DataTable();
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    mostrarUser.DataSource = dt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("no pudiste conectarte", "data base error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private void btnBorrarUser_Click(object sender, EventArgs e)
        {

        }

        private void mostrarUser_DoubleClick(object sender, EventArgs e)
        {

        }

       
    }
}
