using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Empleados : EntityBase
    {
        public Persona Persona { get; set; }

        public string Foto { get; set; } //Ver tema foto 
                                          //string ubicación de foto, ruta
        public Estado EstadoEmpleado { get; set; } = new Estado() { Descripcion = "Alta" };


    }
}
