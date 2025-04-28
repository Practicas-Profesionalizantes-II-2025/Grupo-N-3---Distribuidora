namespace Negocio.CasoDeUso
{
    public static class Empleados
    {
        public static async Task Crear(Shared.Dtos.Empleados.CrearDTOEmpleados empleado)
        {
            ArgumentNullException.ThrowIfNull(empleado);
            if (empleado.Persona == null)
                throw new ArgumentNullException(nameof(empleado.Persona));

            await Repositorio.Empleados.Create(empleado);
        }

        public static async Task Modificar(int id, Shared.Dtos.Empleados.ModificarDTOEmpleados empleadoModificar)
        {
            ArgumentNullException.ThrowIfNull(empleadoModificar);
            if (empleadoModificar.Persona == null)
                throw new ArgumentNullException(nameof(empleadoModificar.Persona));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Empleados.Update(id, empleadoModificar);
        }

        public static async Task<List<Shared.Entities.Empleados>> ObtenerTodo()
        {
            return await Repositorio.Empleados.Get();
        }

        public static async Task<Shared.Entities.Empleados?> obtenerPorId(int id)
        {
            return await Repositorio.Empleados.Get(id);
        }

        public static async Task<List<Shared.Entities.Empleados>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Empleados.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Empleados.Delete(id);
        }
    }
}
