using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Habitaciones.Foto
{
    internal class Fotos
    {
        public void mostrarFotos(DataGridView rooms_photo)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "select id, caption, file, room_id from rooms_photo";

                rooms_photo.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rooms_photo.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }
    }
}
