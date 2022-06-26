using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przedszkole.Database.Models
{
    public class Obecnosc
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int DzieckoId { get; set; }
        public Dziecko Dziecko { get; set; }
        public bool Obecny { get; set; }
    }
}
