namespace Negocio.CasoDeUso
{
    public static class Ciudades
    {
        public static async Task Crear(Shared.Dtos.Ciudades.CrearDTOCiudades persona)
        {
            ArgumentNullException.ThrowIfNull(persona);
            if (persona.Nombre == null)
                throw new ArgumentNullException(nameof(persona.Nombre));

            await Repositorio.Ciudades.Create(persona);
        }

        public static async Task Modificar(int id, Shared.Dtos.Ciudades.ModificarDTOCiudades personaModificar)
        {
            ArgumentNullException.ThrowIfNull(personaModificar);
            if (personaModificar.Nombre == null)
                throw new ArgumentNullException(nameof(personaModificar.Nombre));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Ciudades.Update(id, personaModificar);
        }

        public static async Task<List<Shared.Entities.Ciudades>> ObtenerTodo()
        {
            return await Repositorio.Ciudades.Get();
        }

        public static async Task<Shared.Entities.Ciudades?> obtenerPorId(int id)
        {
            return await Repositorio.Ciudades.Get(id);
        }

        public static async Task<List<Shared.Entities.Ciudades>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Ciudades.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Ciudades.Delete(id);
        }
    }
}
