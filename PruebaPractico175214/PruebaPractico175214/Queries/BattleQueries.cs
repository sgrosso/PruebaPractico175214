using Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public class BattleQueries
    {

        public Weapon GetTheWeakestWeapon()
        {
            using (var context = new BattleContext()) {
                return context.Weapons.OrderBy(weapon => weapon.Power).FirstOrDefault();
            }
        }

        public List<Villain> VillainsThatContainsAInNameAndHaveWonAtLeast3Battles ()
        {
            using (var context = new BattleContext())
            {
                var returnList =  context.Villains.Include(Villain => Villain.Heroes)
                                                  .Where(villain => villain.Name.Contains("A") && 
                                                         villain.NumberOfBattles >= 3)
                                                   .ToList();
                return returnList;
            }
        }

    }
}
