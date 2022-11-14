using MySql.Data.MySqlClient;
using Prueba_hotel.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Clases
{
    internal class Hoteles
    {
        public void mostrarHoteles(DataGridView reservations_bookedday)
        {
            try
            {
                Conexion db = new Conexion();

                String query = "select * from reservations_bookedday";

                reservations_bookedday.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                reservations_bookedday.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }

        public void seleccionarHotel(DataGridView reservations_bookedday, TextBox id, TextBox created, TextBox updated, TextBox day, TextBox reservationid)
        {
            try
            {
                id.Text = reservations_bookedday.CurrentRow.Cells[0].Value.ToString();
                created.Text = reservations_bookedday.CurrentRow.Cells[1].Value.ToString();
                updated.Text = reservations_bookedday.CurrentRow.Cells[2].Value.ToString();
                day.Text = reservations_bookedday.CurrentRow.Cells[3].Value.ToString();
                reservationid.Text = reservations_bookedday.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("no se logro seleccionar");
            }
        }

        public void eliminarrHotel(TextBox id)
        {
            try
            {
                Conexion db = new Conexion();

                String query = "delete from reservations_bookedday  where id = '" + id.Text + "'; ";
                MySqlCommand cmd = new MySqlCommand(query, db.establecerConexion());
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("se elimino");

                while (reader.Read()) { }

                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("no se elimino");
            }
        }
    }
}
