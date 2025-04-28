using CPresentacion;
using VirtualCommerce.TipoDoc;

namespace VirtualCommerce
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
            // Interfaz Principal //Application.Run(new CU_003____Cliente____Armado_interfaz_principal__Encargado());
            Application.Run(new CU_008___Empleado___Armado_interfaz());
        }
    }
}