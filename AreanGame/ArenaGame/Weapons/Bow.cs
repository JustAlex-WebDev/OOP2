using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Bow : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public Bow(string name)
        {
            Name = name;
            AttackDamage = 20;
            BlockingPower = 5;
        }

        // Special attack method for the Bow
        public double SpecialAttack()
        {
            // Deals 1.5 times the normal damage
            return AttackDamage * 1.5;
        }
    }
}
