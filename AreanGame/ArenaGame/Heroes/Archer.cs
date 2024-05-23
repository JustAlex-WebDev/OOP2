using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Archer : Hero
    {
        public Archer(string name, double armor, double strenght, IWeapon weapon) : 
            base(name, armor, strenght, weapon)
        {
        }

        public override double Attack()
        {
            if (Weapon is Bow bow)
            {
                double specialProbability = random.NextDouble();
                if (specialProbability < 0.20)
                {
                    // 20% chance to use special attack
                    return bow.SpecialAttack();
                }
            }
            return base.Attack();
        }
    }
}
