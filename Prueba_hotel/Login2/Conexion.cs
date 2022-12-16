using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_hotel.Login
{
    internal class Conexion
    {
        public static NpgsqlConnection getConexion()
        {
            string servidor = "dpg-cealsuirrk0bbtcnfe40-a.oregon-postgres.render.com";
            string puerto = "5432";
            string usuario = "copo";
            string password = "iRsuOOu5zeLdT7medvUhcQL2JJuGPHnn";
            string bd = "copo";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;

            NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);

            return conexion;

        }
    }
}
