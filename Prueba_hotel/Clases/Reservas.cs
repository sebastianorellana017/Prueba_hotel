using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Clases
{
    internal class Reservas
    {
        public void mostrarReservas(DataGridView rooms_room)
        {
            try
            {
                Conexion db = new Conexion();

                String query = "select * from rooms_room";

                rooms_room.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rooms_room.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }


    }
}
