using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Habitaciones.Regla
{
    internal class Reglas
    {
        public void mostrarReglas(DataGridView rooms_houserule)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "select * from rooms_houserule";

                rooms_houserule.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rooms_houserule.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }

        public void seleccionarReglas(DataGridView rooms_houserule, TextBox id, TextBox creado, TextBox actualizado, TextBox instalacion)
        {
            try
            {
                id.Text = rooms_houserule.CurrentRow.Cells[0].Value.ToString();
                creado.Text = rooms_houserule.CurrentRow.Cells[1].Value.ToString();
                actualizado.Text = rooms_houserule.CurrentRow.Cells[2].Value.ToString();
                instalacion.Text = rooms_houserule.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("no se logro seleccionar");
            }
        }

        public void guardarReglas(TextBox reglas)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                //String query = "INSERT INTO usuarios (nombre, apellido, edad) VALUES ('" + nombre.Text + "', '" + apellido.Text + "', " + Convert.ToInt32(edad.Text) + ");";
                String query = "INSERT INTO rooms_houserule (name) VALUES ('" + reglas.Text + "');";
                MySqlCommand cmd = new MySqlCommand(query, db.establecerConexion());
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("se guardo");

                while (reader.Read()) { }

                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("no se guardo");
            }
        }

        public void modificarReglas(TextBox id, TextBox reglas)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "update rooms_houserule set name='" + reglas.Text + "'  where id = '" + id.Text + "'; ";
                MySqlCommand cmd = new MySqlCommand(query, db.establecerConexion());
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("se modifico");

                while (reader.Read()) { }

                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("no se modifico");
            }
        }

        public void eliminarReglas(TextBox id)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "delete from rooms_houserule  where id = '" + id.Text + "'; ";
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
