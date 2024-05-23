using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public abstract class Hero : IHero
    {
        protected Random random = new Random();
        public string Name { get; private set; }
        public double Health { get; private set; }
        public double Armor { get; private set; }
        public double Strenght { get; private set; }
        public IWeapon Weapon { get; private set; }
        public bool IsAlive

        // New property to track if the hero is stunned
        public bool IsStunned { get; set; }
        {
            get
            {
                return Health > 0;
            }
        }

        public Hero(string name, double armor, double strenght, IWeapon weapon)
        {
            Health = 100;
            Name = name;
            Armor = armor;
            Strenght = strenght;
            Weapon = weapon;

            // Initialize as not stunned
            IsStunned = false;
        }


        // returns actual damage
        public virtual double Attack()
        {
            // If stunned, skip attack and recover from stun
            if (IsStunned)
            {
                IsStunned = false;

                return 0;
            }

            double totalDamage = Strenght + Weapon.AttackDamage;
            double coef = random.Next(80, 120 + 1);
            double realDamage = totalDamage * (coef / 100);

            // Check if weapon is Hammer and if it stuns the opponent
            if (Weapon is Hammer hammer && hammer.Stun())
            {
                Console.WriteLine($"{Name} stunned the opponent!");

                return realDamage;
            }

            return realDamage;
        }

        public virtual double Defend(double damage)
        {
            double coef = random.Next(80, 120 + 1);
            double defendPower = (Armor + Weapon.BlockingPower) * (coef / 100);
            double realDamage = damage - defendPower;
            if (realDamage < 0) realDamage = 0;
            Health -= realDamage;

            return realDamage;
        }

        public override string ToString()
        {
            return $"{Name} with health {Math.Round(Health,2)}";
        }
    }
}
