using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przedszkole.Database.Models
{
    public class Wychowawca
    {
        [Key]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
