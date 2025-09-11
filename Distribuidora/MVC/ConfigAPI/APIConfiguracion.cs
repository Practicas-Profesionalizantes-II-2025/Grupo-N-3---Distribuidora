namespace MVC.ConfigAPI
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        // Endpoints Categorias
        public string CategoriasGet { get; set; } = string.Empty;
        public string CategoriasPost { get; set; } = string.Empty;
        public string CategoriasPut { get; set; } = string.Empty;
        public string CategoriasDelete { get; set; } = string.Empty;

        // Endpoints Ciudades
        public string CiudadesGet { get; set; } = string.Empty;
        public string CiudadesPost { get; set; } = string.Empty;
        public string CiudadesPut { get; set; } = string.Empty;
        public string CiudadesDelete { get; set; } = string.Empty;

        // Endpoints Clientes
        public string ClientesGet { get; set; } = string.Empty;
        public string ClientesPost { get; set; } = string.Empty;
        public string ClientesPut { get; set; } = string.Empty;
        public string ClientesDelete { get; set; } = string.Empty;

        // Endpoints Empleado 
        public string EmpleadosGet { get; set; } = string.Empty;
        public string EmpleadosPost { get; set; } = string.Empty;
        public string EmpleadosPut { get; set; } = string.Empty;
        public string EmpleadosDelete { get; set; } = string.Empty;
        // agregá más endpoints según se necesite
    }
}