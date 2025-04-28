namespace Negocio.CasoDeUso
{
    public static class Personas
    {
        public static async Task Crear(Shared.Dtos.Personas.CrearDTOPersonas persona)
        {
            ArgumentNullException.ThrowIfNull(persona);
            if (persona.Nombre == null)
                throw new ArgumentNullException(nameof(persona.Nombre));

            await Repositorio.Personas.Create(persona);
        }

        public static async Task Modificar(int id, Shared.Dtos.Personas.ModificarDTOPersonas personaModificar)
        {
            ArgumentNullException.ThrowIfNull(personaModificar);
            if (personaModificar.Nombre == null)
                throw new ArgumentNullException(nameof(personaModificar.Nombre));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Personas.Update(id, personaModificar);
        }

        public static async Task<List<Shared.Entities.Personas>> ObtenerTodo()
        {
            return await Repositorio.Personas.Get();
        }

        public static async Task<Shared.Entities.Personas?> obtenerPorId(int id)
        {
            return await Repositorio.Personas.Get(id);
        }

        public static async Task<List<Shared.Entities.Personas>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Personas.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Personas.Delete(id);
        }
    }
}
