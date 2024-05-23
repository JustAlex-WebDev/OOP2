using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Hammer : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public Hammer(string name)
        {
            Name = name;
            AttackDamage = 30;
            BlockingPower = 1;
        }

        // Method to determine if the Hammer stuns the opponent
        public bool Stun()
        {
            Random random = new Random();
            double probability = random.NextDouble();

            // 50% chance to stun the opponent
            return probability < 0.50;
        }
    }
}
