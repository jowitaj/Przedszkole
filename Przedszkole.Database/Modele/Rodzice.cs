using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przedszkole.Database.Models
{/// <summary>
 /// Klasa tworzaca rekordy w tabeli Rodzice w bazie danych
 /// </summary>
    public class Rodzice
    {
        [Key]
        public int Id { get; set; }
        public string ImieMatki { get; set; }
        public string NazwiskoMatki { get; set; }
        public string ImieOjca { get; set; }
        public string NazwiskoOjca { get; set; }
    }
}
