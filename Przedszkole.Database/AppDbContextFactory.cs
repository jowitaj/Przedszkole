using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Przedszkole.Database
{
    public class AppDbContextFactory : IDesignTimeContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer("Server=.; Database=Przedszkole; Trusted_Connection=True");
            return new AppDbContext(options.Options);

        }
    }
}
