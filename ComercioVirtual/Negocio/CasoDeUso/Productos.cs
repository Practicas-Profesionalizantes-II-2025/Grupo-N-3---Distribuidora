namespace Negocio.CasoDeUso
{
    public static class Productos
    {
        public static async Task Crear(Shared.Dtos.Productos.CrearDTOProductos producto)
        {
            ArgumentNullException.ThrowIfNull(producto);
            if (producto.Nombre == null)
                throw new ArgumentNullException(nameof(producto.Nombre));

            await Repositorio.Productos.Create(producto);
        }

        public static async Task Modificar(int id, Shared.Dtos.Productos.ModificarDTOProductos producto)
        {
            ArgumentNullException.ThrowIfNull(producto);
            if (producto.Nombre == null)
                throw new ArgumentNullException(nameof(producto.Nombre));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Productos.Update(id, producto);
        }

        public static async Task<List<Shared.Entities.Productos>> ObtenerTodo()
        {
            return await Repositorio.Productos.Get();
        }

        public static async Task<Shared.Entities.Productos?> obtenerPorId(int id)
        {
            return await Repositorio.Productos.Get(id);
        }

        public static async Task<List<Shared.Entities.Productos>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Productos.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Productos.Delete(id);
        }
    }
}
