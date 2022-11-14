using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Habitaciones.Tipo
{
    internal class Tipos
    {
        public void mostrarTipos(DataGridView rooms_roomtype)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "select * from rooms_roomtype";

                rooms_roomtype.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.establecerConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rooms_roomtype.DataSource = dt;
                db.cerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("deconectado");
            }
        }

        public void seleccionarTipos(DataGridView rooms_roomtype, TextBox id, TextBox creado, TextBox actualizado, TextBox tipos)
        {
            try
            {
                id.Text = rooms_roomtype.CurrentRow.Cells[0].Value.ToString();
                creado.Text = rooms_roomtype.CurrentRow.Cells[1].Value.ToString();
                actualizado.Text = rooms_roomtype.CurrentRow.Cells[2].Value.ToString();
                tipos.Text = rooms_roomtype.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("no se logro seleccionar");
            }
        }

        public void guardarTipos(TextBox tipos)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                //String query = "INSERT INTO usuarios (nombre, apellido, edad) VALUES ('" + nombre.Text + "', '" + apellido.Text + "', " + Convert.ToInt32(edad.Text) + ");";
                String query = "INSERT INTO rooms_roomtype (name) VALUES ('" + tipos.Text + "');";
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

        public void modificarTipos(TextBox id, TextBox tipos)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "update rooms_roomtype set name='" + tipos.Text + "'  where id = '" + id.Text + "'; ";
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

        public void eliminarTipos(TextBox id)
        {
            try
            {
                Clases.Conexion db = new Clases.Conexion();

                String query = "delete from rooms_roomtype  where id = '" + id.Text + "'; ";
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
