using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Przedszkole.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        /// <summary>
        /// Metoda na utworzenie contextu bazy danych na podstawie opcji
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server=.; Database=Przedszkole; Trusted_Connection=True");
            return new AppDbContext(options.Options);

        }
    }
}
