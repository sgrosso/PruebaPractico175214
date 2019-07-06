using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;
using Persistence;
using System.Data.Entity.Infrastructure;

namespace Repositories
{
    public class WeaponRepository : IRepository<Weapon>
    {
        public void Create(Weapon aWeapon)
        {
            using (var context = new BattleContext())
            {
                context.Weapons.Add(aWeapon);
                context.SaveChanges();
            }
        }

        public void Delete(int anId)
        {
            using (var context = new BattleContext())
            {
                Weapon weaponToDelete = context.Weapons.Find(anId);
                if (weaponToDelete != null)
                {
                    context.Weapons.Remove(weaponToDelete);
                    context.SaveChanges();
                }
            }
        }

        public Weapon Get(int anId)
        {
            using (var context = new BattleContext())
            {
                return context.Weapons.Find(anId);
            }
        }

        public void Update(Weapon aWeapon)
        {
            using (var context = new BattleContext())
            {
                DbEntityEntry<Weapon> WeaponToUpdate = context.Entry(aWeapon);
                WeaponToUpdate.CurrentValues.SetValues(aWeapon);
                context.SaveChanges();
            }
        }
    }
}
