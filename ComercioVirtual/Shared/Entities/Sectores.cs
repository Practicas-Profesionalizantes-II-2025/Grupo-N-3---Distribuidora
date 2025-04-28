namespace Shared.Entities
{
    public class Sectores : EntityBase
    {
        public string? Nombre {  get; set; }
        public Estados? estado { get; set; } = new Estados()
        {
            Descripcion = "'De alta"
        };
        //public ICollection<Empleado> Empleados { get; } = new List<Empleado>(); // 1:n con Empleados

    }
}
