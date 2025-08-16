namespace MVC.Models.Entities
{
    public class EstadoPedido
    {
        int Id { get; set; }
        string Descripcion { get; set; }  // "Pendiente" - "Finalizado" - "Cancelado"
    }
}
