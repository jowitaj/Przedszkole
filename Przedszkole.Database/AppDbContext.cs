using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przedszkole.Database
{
    public class AppDbContext:DbContext
    {
        // Konstruktor bez parametrów
        public AppDbContext()
        {
        }


         // Konstruktor z parametrami z dziedziczacej klasy 
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }



    }
}
