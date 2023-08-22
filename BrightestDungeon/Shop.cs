namespace BrightestDungeon;
    public class Shop
    {

        //load that ding up
        public static void LoadShop(Player p)
        {
  
            RunShop(p);
        }
        
        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
            potionP = 20 + 10 * p.mods;
            armorP = 100 * (p.armorValue + 1);
            weaponP = 100 * p.weaponValue;
            difP = 300 + 100 * p.mods;
            Console.Clear();
            Console.WriteLine("            Shop            ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("| (W)eapon     : $" + weaponP);
            Console.WriteLine("| (A)rmor  :     $" + armorP);
            Console.WriteLine("| (P)otion :     $" + potionP);
            Console.WriteLine("| (D)ifficulty : $" + difP);
            Console.WriteLine("----------------------------");
            Console.WriteLine("| (E)xit");
            Console.WriteLine("| (Q)uit game");

            Console.WriteLine(p.name + "'s Stats");
            Console.WriteLine("----------------------------");
            Console.WriteLine(" Current Health: " + p.health);
            Console.WriteLine("Current Coins: $" + p.Coins);
            Console.WriteLine("| Weapon : " + p.weaponValue);
            Console.WriteLine("| Armor  : " + p.armorValue);
            Console.WriteLine("| Potion : " + p.potion);
            Console.WriteLine("| Difficulty : " + p.mods);
            Console.WriteLine("----------------------------");
            //Waiting for input
            string input = Console.ReadLine().ToLower();
            
            if (input == "w" || input == "weapon")
            {
                TryBuy("weapon", weaponP, p);
            }
            else if (input == "a" || input == "armor")
            {
                TryBuy("armor", armorP, p);
            }
            else if (input == "p" || input == "potion")
            {
                TryBuy("potion", potionP, p);
            }
            else if (input == "d" || input == "difficulty")
            {
                TryBuy("difficulty", difP, p);
            }
            else if(input == "e" || input == "exit")
            break;
            else if (input == "q" || input == "quit")
            {
                Program.Quit();
            }

            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if(p.Coins >= cost)
            {
                if(item == "potion")
                    p.potion++;
                else if (item == "weapon")
                p.weaponValue++;
                else if (item == "armor")
                p.armorValue++;
                else if (item == "difficulty")
                p.mods++;

                p.Coins -= cost;
            }
            else{
                Console.WriteLine("You don't have enough gold to purchase the " + item);
                Console.ReadKey();
            
            }
        }
    }


