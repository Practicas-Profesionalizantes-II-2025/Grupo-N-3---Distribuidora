using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Models.Entities.Ciudad> Ciudad { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Usuario> Usuario { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Empleado> Empleado { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Categoria> Categoria { get; set; } = default!;
    }
}
