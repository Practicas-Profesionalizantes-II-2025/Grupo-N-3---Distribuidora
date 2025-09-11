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
        // agregá más endpoints según se necesite
    }
}