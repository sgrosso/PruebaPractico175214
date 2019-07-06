using Entities;
using Queries;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPractico175214
{
    public class Program
    {
        static void Main(string[] args)
        {

            Weapon stormBreaker = new Weapon
            {
                Name = "StormBreaker",
                Power = 10
            };

            Hero thor = new Hero
            {
                Name = "Thor",
                Planet = Planet.Earth,
                Weapon = stormBreaker
            };

            Weapon shield = new Weapon
            {
                Name = "Escudo del capitán",
                Power = 5
            };

            Hero captainAmerica = new Hero
            {
                Name = "Capitán América",
                Planet = Planet.Earth,
                Weapon = shield
            };

            Villain redSkull = new Villain
            {
                Name = "Red Skull",
                NumberOfBattles = 2
            };

            Villain thanos = new Villain
            {
                Name = "THANOS",
                NumberOfBattles = 5
            };


            thanos.Heroes.Add(captainAmerica);
            thanos.Heroes.Add(thor);

            IRepository<Hero> heroesRepository = new HeroRepository();
            heroesRepository.Create(thor);
            heroesRepository.Create(captainAmerica);

            IRepository<Villain> villainsRepository = new VillainRepository();
            villainsRepository.Create(redSkull);
            villainsRepository.Create(thanos);

            BattleQueries queries = new BattleQueries();

            Console.WriteLine("================================ RESULTADO DE CONSULTAS ================================ ");
            Console.WriteLine("CONSULTA 1:");
            Console.WriteLine("");
            Console.WriteLine("");

            Weapon weakestWeapon = queries.GetTheWeakestWeapon();
            Console.WriteLine($"Arma más débil: {weakestWeapon.Name}, poder: {weakestWeapon.Power} ");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("CONSULTA 2:");

            List<Villain> villainsResult = queries.VillainsThatContainsAInNameAndHaveWonAtLeast3Battles();
            foreach(var villain in villainsResult)
            {
                Console.WriteLine($"Villano: {villain.Name}");
                Console.WriteLine($"Sus héroes:");
                foreach (var hero in villain.Heroes)
                {
                    Console.WriteLine($"Nombre: {hero.Name} ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.ReadLine();


        }
    }
}
