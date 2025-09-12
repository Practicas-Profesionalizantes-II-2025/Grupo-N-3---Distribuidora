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

        // Endpoints FacturaCabecera
        public string FacturaCabeceraGet { get; set; } = string.Empty;
        public string FacturaCabeceraPost { get; set; } = string.Empty;
        public string FacturaCabeceraPut { get; set; } = string.Empty;
        public string FacturaCabeceraDelete { get; set; } = string.Empty;

        // Endpoints OrdenDeCompra
        public string OrdenDeCompraGet { get; set; } = string.Empty;
        public string OrdenDeCompraPost { get; set; } = string.Empty;
        public string OrdenDeCompraPut { get; set; } = string.Empty;
        public string OrdenDeCompraDelete { get; set; } = string.Empty;

        // Endpoints OrdenDeCompraProducto
        public string OrdenDeCompraProductoGet { get; set; } = string.Empty;
        public string OrdenDeCompraProductoPost { get; set; } = string.Empty;
        public string OrdenDeCompraProductoPut { get; set; } = string.Empty;
        public string OrdenDeCompraProductoDelete { get; set; } = string.Empty;

        // Endpoints OrdenDeVenta
        public string OrdenDeVentaGet { get; set; } = string.Empty;
        public string OrdenDeVentaPost { get; set; } = string.Empty;
        public string OrdenDeVentaPut { get; set; } = string.Empty;
        public string OrdenDeVentaDelete { get; set; } = string.Empty;

        // Endpoints OrdenDeVentaProducto
        public string OrdenDeVentaProductoGet { get; set; } = string.Empty;
        public string OrdenDeVentaProductoPost { get; set; } = string.Empty;
        public string OrdenDeVentaProductoPut { get; set; } = string.Empty;
        public string OrdenDeVentaProductoDelete { get; set; } = string.Empty;

        // Endpoints Persona
        public string PersonaGet { get; set; } = string.Empty;
        public string PersonaPost { get; set; } = string.Empty;
        public string PersonaPut { get; set; } = string.Empty;
        public string PersonaDelete { get; set; } = string.Empty;

        // Endpoints Producto
        public string ProductoGet { get; set; } = string.Empty;
        public string ProductoPost { get; set; } = string.Empty;
        public string ProductoPut { get; set; } = string.Empty;
        public string ProductoDelete { get; set; } = string.Empty;

        // Endpoints Proveedor
        public string ProveedorGet { get; set; } = string.Empty;
        public string ProveedorPost { get; set; } = string.Empty;
        public string ProveedorPut { get; set; } = string.Empty;
        public string ProveedorDelete { get; set; } = string.Empty;

        // Endpoints Sector
        public string SectorGet { get; set; } = string.Empty;
        public string SectorPost { get; set; } = string.Empty;
        public string SectorPut { get; set; } = string.Empty;
        public string SectorDelete { get; set; } = string.Empty;

        // Endpoints TipoDocumento
        public string TipoDocumentoGet { get; set; } = string.Empty;
        public string TipoDocumentoPost { get; set; } = string.Empty;
        public string TipoDocumentoPut { get; set; } = string.Empty;
        public string TipoDocumentoDelete { get; set; } = string.Empty;

        // Endpoints Usuario
        public string UsuarioGet { get; set; } = string.Empty;
        public string UsuarioPost { get; set; } = string.Empty;
        public string UsuarioPut { get; set; } = string.Empty;
        public string UsuarioDelete { get; set; } = string.Empty;

        // agregá más endpoints según se necesite
    }
}