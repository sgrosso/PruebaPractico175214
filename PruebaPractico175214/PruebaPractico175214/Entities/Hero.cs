using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Hero
    {
        public Hero () {
            Villains = new List<Villain>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Planet Planet { get; set; }
        public List<Villain> Villains { get; set; }
        public Weapon Weapon { get; set; }

    }
}
