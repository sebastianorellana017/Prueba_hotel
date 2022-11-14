using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Habitaciones.Instalacion
{
    internal class Instalaciones
    {
        public void mostrarInstalacion(DataGridView rooms_facility)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "select * from rooms_facility";

                rooms_facility.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rooms_facility.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }

        public void seleccionarInstalacion(DataGridView rooms_facility, TextBox id, TextBox creado, TextBox actualizado, TextBox instalacion)
        {
            try
            {
                id.Text = rooms_facility.CurrentRow.Cells[0].Value.ToString();
                creado.Text = rooms_facility.CurrentRow.Cells[1].Value.ToString();
                actualizado.Text = rooms_facility.CurrentRow.Cells[2].Value.ToString();
                instalacion.Text = rooms_facility.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("no se logro seleccionar");
            }
        }

        public void guardarInstalacion(TextBox instalacion)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                //String query = "INSERT INTO usuarios (nombre, apellido, edad) VALUES ('" + nombre.Text + "', '" + apellido.Text + "', " + Convert.ToInt32(edad.Text) + ");";
                String query = "INSERT INTO rooms_facility (name) VALUES ('" + instalacion.Text + "');";
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

        public void modificarInstalacion(TextBox id, TextBox instalacion)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "update rooms_facility set name='" + instalacion.Text + "'  where id = '" + id.Text + "'; ";
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

        public void eliminarInstalacion(TextBox id)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "delete from rooms_facility  where id = '" + id.Text + "'; ";
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
