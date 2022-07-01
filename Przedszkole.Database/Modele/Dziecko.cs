using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przedszkole.Database.Models
{
    /// <summary>
    /// Klasa tworzaca rekordy w tabeli Dzieci w bazie danych
    /// </summary>
    public class Dziecko
    {
        [Key]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int RodziceId { get; set; }
        public Rodzice Rodzice { get; set; }
        public int WychowawcaId { get; set; }
        public Wychowawca Wychowawca { get; set; }


        
    }
}
