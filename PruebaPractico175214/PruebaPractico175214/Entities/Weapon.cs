using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Weapon
    {
        public Weapon () {
            Power = 1;
        }
        
        public int Id { get; set; }
        public string Name { get; set;}
        [Range(1, 10)]
        public int Power { get; set; }
    }
}
