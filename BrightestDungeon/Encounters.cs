using System.Collections;
using System.Security.Cryptography.X509Certificates;


namespace BrightestDungeon
{
    public class Encounters
    {
        static Random rand = new Random();
        public static void firstEncounter()
        {
            Console.WriteLine("You try to kick the door down, but to no avail.");
            Console.WriteLine("The winged being notices you and attacks!");
            Console.ReadKey();
            Combat(false, "Lesser angel" , 1, 4);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine(" As you walk around, something descends upon you.");
            Console.ReadKey();
            Combat(true, "" , 0,0);
        }
        /* public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
            Combat(false, "name",  p, h);
            */

        //Encounter tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0,1))
            {
                case 0:
                    BasicFightEncounter();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while(h > 0)
            {
                //Combat Interface
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + " / " + h);
                Console.WriteLine("-------------------------");
                Console.WriteLine("| (A)ttack,       (D)efend |");
                Console.WriteLine("| (R)un           (H)eal   |");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion +  " Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if(input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("You surge forth, swinging your weapon wildly! As you pass, the " + n + " strikes you!");
                    int damage = p - Program.currentPlayer.armorValue;
                    if(damage < 0)
                    damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if(input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defense
                    Console.WriteLine("You wait in anticipation, preparing to block any incoming attack.. You have successfully blocked " + n +" attack!");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if(damage < 0)
                    damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if(input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    Console.WriteLine("You attempt to escape...");
                    if(rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", its strike catches you in the back, sending you onto the ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(" You managed to escape the " + n + "!");
                        Console.ReadKey();
                        //go to store
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if(input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.potion ==0)
                    {
                        Console.WriteLine("You are searching for a potion in your equipment, but only found empty glass flasks!");
                        int damage = p - Program.currentPlayer.armorValue;
                        Console.WriteLine("The " + n + ", using your desperation, delivers a mighty blow and you lose " + damage +" health!");
                        if(damage < 0 )
                        damage = 0;
                    }
                    else
                    {
                        Console.WriteLine("You reach into your back and successfully pulled out a glowing, golden flask. You take a sip..");
                        //Potion Value
                        int potionV = 5;
                        Console.WriteLine("You gain "+ potionV + " health");
                        Program.currentPlayer.potion += potionV;
                        Console.WriteLine("As you were occupied, the " + n + " landed a wicked blow for");
                        int damage = (p/2)-Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health");
                    }
                    Console.ReadKey();
                }
                //Death check
                if(Program.currentPlayer.health<=0)
                {
                    Console.WriteLine(" As the " + n + " looks down on you, you can see the madness in its eyes. Its the last thing you see.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            
            int c = Program.currentPlayer.Coins;
            Console.WriteLine("As you stand victorious over the " + n + ", it dissolves to golden dust and " + c + " gold coins.");
            Program.currentPlayer.Coins += c;
            Shop.LoadShop(Program.currentPlayer);
            Console.ReadKey();
            
        }
        }

         public static string GetName()
        {
            switch(rand.Next(0, 12))
            {
                case 0: 
                    return "Footmen of Raphael";
                break;
                case 1:
                    return "Splinter of Barachiel";
                break;
                case 2:
                    return "Jehudiels feather";
                break;
                case 3: 
                    return "Uriels Dominance";
                break;
                case 4:
                    return "Sealtiels trooper";
                break;
                case 5:
                    return "Michaels brilliance";
                case 6:
                    return "Gabriels shepherd";
                case 7:
                    return "Lesser angel";
                case 8:
                    return "Aggeloi warrior";
                case 9:
                    return "Lesser ophanim";
                case 10:
                    return "Lesser seraphim";
                case 11:
                    return "Godly figure";

            } return "Why tho?";
            //no, for real, why does nothing work when i delete this? Questions for l8r 
            Console.ReadKey();
        }
    }

}
