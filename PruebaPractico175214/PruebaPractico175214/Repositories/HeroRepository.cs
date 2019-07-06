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
    public class HeroRepository : IRepository<Hero>
    {
        public void Create(Hero aHero)
        {
            using(var context = new BattleContext())
            {
                context.Heroes.Add(aHero);
                context.SaveChanges();
            }
        }

        public void Delete(int anId)
        {
            using (var context = new BattleContext())
            {
                Hero heroToDelete = context.Heroes.Find(anId);
                if (heroToDelete != null)
                {
                    context.Heroes.Remove(heroToDelete);
                    context.SaveChanges();
                }
            }
        }

        public Hero Get(int anId)
        {
            using (var context = new BattleContext())
            {
                return context.Heroes.Find(anId);
            }
        }

        public void Update(Hero aHero)
        {
            using (var context = new BattleContext())
            {
                DbEntityEntry<Hero> heroToUpdate = context.Entry(aHero);
                heroToUpdate.CurrentValues.SetValues(aHero);
                context.SaveChanges();
            }
        }
    }
}
