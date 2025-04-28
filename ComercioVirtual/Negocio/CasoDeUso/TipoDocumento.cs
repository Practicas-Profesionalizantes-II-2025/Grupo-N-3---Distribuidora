namespace Negocio.CasoDeUso
{
    public static class TipoDocumento
    {
        public static async Task Crear(Shared.Dtos.TipoDocumento.CrearDTOTipoDocumento tipoDocumento)
        {
            ArgumentNullException.ThrowIfNull(tipoDocumento);
            if (tipoDocumento.NombreTipoDocumento == null)
                throw new ArgumentNullException(nameof(tipoDocumento.NombreTipoDocumento));

            await Repositorio.TipoDocumento.Create(tipoDocumento);
        }

        public static async Task Modificar(int id, Shared.Dtos.TipoDocumento.ModificarDTOTipoDocumento tipoDocumento)
        {
            ArgumentNullException.ThrowIfNull(tipoDocumento);
            if (tipoDocumento.NombreTipoDocumento == null)
                throw new ArgumentNullException(nameof(tipoDocumento.NombreTipoDocumento));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.TipoDocumento.Update(id, tipoDocumento);
        }

        public static async Task<List<Shared.Entities.TipoDocumento>> ObtenerTodo()
        {
            return await Repositorio.TipoDocumento.Get();
        }

        public static async Task<Shared.Entities.TipoDocumento?> obtenerPorId(int id)
        {
            return await Repositorio.TipoDocumento.Get(id);
        }

        public static async Task<List<Shared.Entities.TipoDocumento>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.TipoDocumento.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.TipoDocumento.Delete(id);
        }
    }
}
