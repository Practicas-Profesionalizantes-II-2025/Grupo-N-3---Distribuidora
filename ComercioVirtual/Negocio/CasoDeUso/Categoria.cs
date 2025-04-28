namespace Negocio.CasoDeUso
{
    public static class Categorias
    {
        public static async Task Crear(Shared.Dtos.Categorias.CrearDTO persona)
        {
            ArgumentNullException.ThrowIfNull(persona);
            if (persona.Nombre == null)
                throw new ArgumentNullException(nameof(persona.Nombre));

            await Repositorio.Categorias.Create(persona);
        }

        public static async Task Modificar(int id, Shared.Dtos.Categorias.ModificarDTO personaModificar)
        {
            ArgumentNullException.ThrowIfNull(personaModificar);
            if (personaModificar.Nombre == null)
                throw new ArgumentNullException(nameof(personaModificar.Nombre));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Categorias.Update(id, personaModificar);
        }

        public static async Task<List<Shared.Entities.Categorias>> ObtenerTodo()
        {
            return await Repositorio.Categorias.Get();
        }

        public static async Task<Shared.Entities.Categorias?> obtenerPorId(int id)
        {
            return await Repositorio.Categorias.Get(id);
        }

        public static async Task<List<Shared.Entities.Categorias>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Categorias.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Categorias.Delete(id);
        }
    }
}
