using Prueba_hotel.Login;
using Prueba_hotel.Login2;

namespace Prueba_hotel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //plication.Run(new Form1());
            Application.Run(new Ingreso());

        }
    }
}