using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Shared.Entities;

namespace CDatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        //public DbSet<Animals> Animals { get; set; } = null!; Copiar asi para entidades

    }
}
