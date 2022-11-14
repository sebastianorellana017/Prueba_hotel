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
    internal class Usuarios
    {
        public void mostrarUsuarios(DataGridView users_user)
        {
            try
            {
                Conexion db = new Conexion();

                String query = "select * from users_user";

                users_user.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                users_user.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }

        public void seleccionarUsuario(DataGridView users_user, TextBox id)
        {
            try
            {
                id.Text = users_user.CurrentRow.Cells[0].Value.ToString();
                
            }
            catch (Exception)
            {
                MessageBox.Show("no se logro seleccionar");
            }
        }

        public void eliminarrUsuario(TextBox id)
        {
            try
            {
                Conexion db = new Conexion();

                String query = "delete from usuarios  where id = '" + id.Text + "'; ";
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
