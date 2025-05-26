using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IEmpleadoRepositorio
    {
        Task<List<Empleado>> ObtenerEmpleados();
        Task<Empleado> ObtenerEmpleadoPorId(int id);
        Task<Empleado> CrearEmpleado(Empleado empleado);
        void ActualizarEmpleado(Empleado empleado);
        void EliminarEmpleado(int id);
        Task<List<Empleado>> ObtenerEmpleadosPorDni(string dni);
    }
}
