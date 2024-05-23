using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace ConsoleArenaGame
{
    class Program
    {
        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack,2)} and caused {Math.Round(args.Damage,2)} damage.");
            Console.WriteLine($"Attacker: {args.Attacker}");
            Console.WriteLine($"Defender: {args.Defender}");
        }

        static void Main(string[] args)
        {
            // First fight: Knight vs Archer
            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Knight("Knight", 10, 20, new Sword("Sword")),
                HeroB = new Assassin("Assassin", 10, 5, new Dagger("Dagger")),
                NotificationsCallBack = ConsoleNotification
            };

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");

            // Second fight: Mage vs Assassin
            gameEngine.HeroA = new Mage("Mage", 5, 10, new Staff("Magic Staff"));
            gameEngine.HeroB = new Assassin("Assassin", 10, 5, new Dagger("Shadow Dagger"));

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");

            // Third fight: Knight vs Mage with the new Hammer weapon
            gameEngine.HeroA = new Knight("Knight", 10, 20, new Hammer("War Hammer"));
            gameEngine.HeroB = new Mage("Mage", 5, 10, new Staff("Mystic Staff"));

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");
        }
    }
}