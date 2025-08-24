namespace MVC.ConfigAPI
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        // Endpoints
        public string CategoriasGet { get; set; } = string.Empty;
        public string CategoriasPost { get; set; } = string.Empty;
        public string CategoriasPut { get; set; } = string.Empty;
        public string CategoriasDelete { get; set; } = string.Empty;
        // agregá más endpoints según se necesite
    }
}