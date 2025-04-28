using Shared.Entities;

namespace Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            // Busca por un TipoDocumento
            if (context.TipoDocumento.Any())
            {
                return; // La tabla TipoDocumento fue inicializada
            }
            // Busca por un TipoDocumento
            if (context.Ciudades.Any())
            {
                return; // La tabla TipoDocumento fue inicializada
            }

            var tiposDocumento = new TipoDocumento[]
            {
                new TipoDocumento { NombreTipoDocumento = "DNI" },
                new TipoDocumento { NombreTipoDocumento = "LDE" },
                new TipoDocumento { NombreTipoDocumento = "Pasaporte" },
                new TipoDocumento { NombreTipoDocumento = "etc" },
            };

            context.TipoDocumento.AddRangeAsync(tiposDocumento).Wait();

            var ciudades = new Ciudades[]
            {
                new Ciudades { Nombre = "Sunchales" },
                new Ciudades { Nombre = "Rafaela" },
                new Ciudades { Nombre = "Ceres" },
                new Ciudades { Nombre = "Capibara" },
            };

            context.Ciudades.AddRangeAsync(ciudades).Wait();


            context.SaveChangesAsync();
        }
    }
}
