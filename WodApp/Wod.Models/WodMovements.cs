using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WodApp.Data.Domain
{
    public class WodMovements
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
