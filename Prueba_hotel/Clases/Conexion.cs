using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Prueba_hotel.Clases
{
    internal class Conexion
    {
        static MySqlConnection Conex = new MySqlConnection();
        static string serv = "Server=localhost;";
        static string db = "Database=hotel3;";
        static string usuario = "UID=root;";
        static string pwd = "Password = ;";

        string CadenaDeConexion = serv + db + usuario + pwd;


        public MySqlConnection establecerConexion()
        {
            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception)
            {
                MessageBox.Show("Cargando");
            }

            return Conex;

        }

        public void cerrarConexion()
        {
            Conex.Close();
        }

    }
}
