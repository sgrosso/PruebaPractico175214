using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Villain
    {
        public Villain () {
            Heroes = new List<Hero>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfBattles { get; set; }
        public List<Hero> Heroes { get; set; }
        public Weapon Weapon { get; set; }
    }
}
