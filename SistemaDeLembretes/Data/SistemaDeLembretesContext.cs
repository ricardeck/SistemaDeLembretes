using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeLembretes.Models
{
    public class SistemaDeLembretesContext : DbContext
    {
        public SistemaDeLembretesContext (DbContextOptions<SistemaDeLembretesContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaDeLembretes.Models.Lembrete> Lembrete { get; set; }
    }
}
