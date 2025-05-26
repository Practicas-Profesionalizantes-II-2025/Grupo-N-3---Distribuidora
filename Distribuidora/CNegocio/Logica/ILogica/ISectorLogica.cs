using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface ISectorLogica
    {
        Task<List<SectorDTO>> ObtenerSectores();
        Task<SectorDTO> ObtenerSectorPorId(int id);
        Task CrearSector(SectorDTO sectorDTO);
        Task ActualizarSector(SectorDTO sectorDTO);
        Task EliminarSector(int id);
    }
}
