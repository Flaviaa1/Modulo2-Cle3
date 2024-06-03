using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase3Modulo2EFCore
{
    public class BDContext:DbContext
    {
        public DbSet<Actor> actor { get; set; }
       public BDContext(DbContextOptions<BDContext>options):base (options)
        { 
        
        }   
    }
}
