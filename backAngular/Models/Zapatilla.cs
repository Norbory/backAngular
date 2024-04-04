using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backAngular.Models
{
    public class Zapatilla
    {
        public int Id { get; set; }
        public required string Product { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Stock { get; set; } = 0;
        public string Price { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

    }
}
