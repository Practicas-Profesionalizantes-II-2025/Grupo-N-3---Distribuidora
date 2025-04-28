namespace Shared.Entities
{
    public class OrdenesDeCompra_Producto : EntityBase
    {
        public Productos? Producto { get; set; }
        public OrdenesDeCompra? OrdenDeCompra { get; set; }
        //  EF
        //public int IdProducto { get; set; }
        //public int IdOrdenDeCompra { get; set; }
        //  EF

        //public int CantidadProducto {  get; set; }

    }
}
