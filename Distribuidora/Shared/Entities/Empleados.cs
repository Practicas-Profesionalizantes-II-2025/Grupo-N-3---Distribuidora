using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Empleados 
    {
        public int IdEmpleado { get; set; }
        public Persona Persona { get; set; }
        public int PersonaId { get; set; }
        public string Foto { get; set; } //Ver tema foto 
                                          //string ubicación de foto, ruta
        public Estado EstadoEmpleado { get; set; } = new Estado() { Descripcion = "Alta" }; 
        public int SectorId { get; set; }
        public Sectores Sector { get; set; } = null!; // 1:n con Sector

        public ICollection<OrdenDeVenta>? OrdenesDeVenta { get; } = new List<OrdenDeVenta>(); // 1:n con OrdenDeVenta
        public ICollection<OrdenDeCompra>? OrdenesDeCompra { get;} = new List<OrdenDeCompra>(); // 1:n con OrdenDeCompra


    }
}
