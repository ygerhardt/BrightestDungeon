using System.Runtime.Serialization.Formatters.Binary;

namespace BrightestDungeon
{   //defining the player class
    public class Program
    {
        
        //makes you the player
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if(!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if(newP)
            {
                Encounters.firstEncounter();
            }
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }

        }
        static Player NewStart(int i) 
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("You awake on solid, but mossy ground.");
            Console.WriteLine("Your head is spinning and your body hurts.");
            Console.WriteLine("You try to remember your name...:");
            //self-insert time
            p.name = Console.ReadLine();
            p.ID = i;
            Console.Clear();
            // haha did the funny
            if (p.name == "Claudio")
            {
                Console.WriteLine(" Your name is  " + p.name + "? You are not allowed here, back to Final Fantasy with you!");
            }
            //Can't stop me now
            if (p.name == "Yasha")
            {
                Console.WriteLine("My lord, you have returned!");
            }
            if (p.name == "")
            {
                Console.WriteLine("...but you can't.");
            }
            else 
            {
            Console.WriteLine("You remember your name being "+ p.name);
            Console.ReadKey();
            Console.Clear();
             


            }
            Console.WriteLine("You try to stand up. You see a door at the end of the room.");
            Console.WriteLine("You can feel some resistance as you turn the handle.");
            Console.WriteLine("It won't budge so easily.");   
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You can see a winged being though the bars of the door");
            return p;
            Console.ReadKey();
            
        }
        public static void Quit()
        {
            Save(binForm);
            Environment.Exit(0);
        }
        //saving the game bois
        public static void Save(BinaryFormatter binForm)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.ID.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }
        //Loading a saved game..?
        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int iDCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                //Still work 2 do bois, error when saved game
                FileStream file = File.Open(p, FileMode.Open);
                // damn you break the game at launch bro
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }
            iDCount = players.Count;
             
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose your life: ");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.ID + ": " + p.name);
                }
                Console.WriteLine("Please input player name or ID:(ID:# or playername) Additionally, 'create' will start a new life!");
                string[] data = Console.ReadLine().Split(':');
                Console.WriteLine("Start a new life or continue an existing one: ");
                string Data = Console.ReadLine();
                try
                {
                    if(data[0] == "ID")
                    {
                        if(int.TryParse(data [1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.ID == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that ID!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your ID needs to be a number! Press any key to continue..");
                            Console.ReadKey();
                        }
                    }
                    else if(data[0] == "create")
                    {
                        Player newPlayer = NewStart(iDCount);
                        newP = true;
                        return newPlayer;
                        
                    }
                    else
                    {
                        foreach(Player player in players)
                        {
                            if(player.name == data[0])
                            {
                                return player;
                                
                            }
                        }
                        Console.WriteLine("There is not player with that name");
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your ID needs to be a number! Press any key to continue..");
                    Console.ReadKey();
                }
            }


        }
    }
}
