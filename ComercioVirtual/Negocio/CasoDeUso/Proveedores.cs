namespace Negocio.CasoDeUso
{
    public static class Proveedores
    {
        public static async Task Crear(Shared.Dtos.Proveedores.CrearDTO proveedor)
        {
            ArgumentNullException.ThrowIfNull(proveedor);
            if (proveedor.Nombre == null)
                throw new ArgumentNullException(nameof(proveedor.Nombre));

            await Repositorio.Proveedores.Create(proveedor);
        }

        public static async Task Modificar(int id, Shared.Dtos.Proveedores.ModificarDTO proveedor)
        {
            ArgumentNullException.ThrowIfNull(proveedor);
            if (proveedor.Nombre == null)
                throw new ArgumentNullException(nameof(proveedor.Nombre));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Proveedores.Update(id, proveedor);
        }

        public static async Task<List<Shared.Entities.Proveedores>> ObtenerTodo()
        {
            return await Repositorio.Proveedores.Get();
        }

        public static async Task<Shared.Entities.Proveedores?> obtenerPorId(int id)
        {
            return await Repositorio.Proveedores.Get(id);
        }

        public static async Task<List<Shared.Entities.Proveedores>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Proveedores.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Proveedores.Delete(id);
        }
    }
}
