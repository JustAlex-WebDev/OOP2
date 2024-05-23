using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name, double armor, double strenght, IWeapon weapon) : 
            base(name, armor, strenght, weapon)
        {
        }

        public override double Defend(double damage)
        {
            if (Weapon is Staff staff)
            {
                double healProbability = random.NextDouble();
                if (healProbability < 0.15)
                {
                    // 15% chance to heal instead of taking damage
                    Health += staff.Heal();
                    Console.WriteLine($"{Name} used healing staff and restored health.");
                }
            }
            return base.Defend(damage);
        }
    }
}
