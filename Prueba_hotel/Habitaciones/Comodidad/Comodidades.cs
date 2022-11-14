using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Habitaciones.Comodidad
{
    internal class Comodidades
    {
        public void mostrarComodidad(DataGridView rooms_amenity)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "select * from rooms_amenity";

                rooms_amenity.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rooms_amenity.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }

        public void seleccionarInstalacion(DataGridView rooms_amenity, TextBox id, TextBox creado, TextBox actualizado, TextBox comodidad)
        {
            try
            {
                id.Text = rooms_amenity.CurrentRow.Cells[0].Value.ToString();
                creado.Text = rooms_amenity.CurrentRow.Cells[1].Value.ToString();
                actualizado.Text = rooms_amenity.CurrentRow.Cells[2].Value.ToString();
                comodidad.Text = rooms_amenity.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("no se logro seleccionar");
            }
        }

        public void guardarComodidad(TextBox comodidad)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                //String query = "INSERT INTO usuarios (nombre, apellido, edad) VALUES ('" + nombre.Text + "', '" + apellido.Text + "', " + Convert.ToInt32(edad.Text) + ");";
                String query = "INSERT INTO rooms_amenity (name) VALUES ('" + comodidad.Text + "');";
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

        public void modificarInstalacion(TextBox id, TextBox comodidad)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "update rooms_amenity set name='" + comodidad.Text + "'  where id = '" + id.Text + "'; ";
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

        public void eliminarComodidad(TextBox id)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "delete from rooms_amenity  where id = '" + id.Text + "'; ";
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
