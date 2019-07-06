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
    public class VillainRepository : IRepository<Villain>
    {
        public void Create(Villain aVillain)
        {
            using (var context = new BattleContext())
            {
                context.Villains.Add(aVillain);
                context.SaveChanges();
            }
        }

        public void Delete(int anId)
        {
            using (var context = new BattleContext())
            {
                Villain villainToDelete = context.Villains.Find(anId);
                if (villainToDelete != null)
                {
                    context.Villains.Remove(villainToDelete);
                    context.SaveChanges();
                }
            }
        }

        public Villain Get(int anId)
        {
            using (var context = new BattleContext())
            {
                return context.Villains.Find(anId);
            }
        }

        public void Update(Villain aVillain)
        {
            using (var context = new BattleContext())
            {
                DbEntityEntry<Villain> villainToUpdate = context.Entry(aVillain);
                villainToUpdate.CurrentValues.SetValues(aVillain);
                context.SaveChanges();
            }
        }
    }
}
