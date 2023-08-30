using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security;
using Newtonsoft;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Mime;

namespace BrightestDungeon
{   //defining the player class
    public class Program
    {
        
        //makes you the player
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if(File.Exists("saveFile.txt"))
            {
                
                Program.Load();
            }
            else Program.NewStart();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
            
        }
        //saving the game ig
        public static void Save()
        {
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(currentPlayer);
            string path = null;
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(path, "saveFile.txt");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(serializedObject);
            }
        }
        //I guess loading can be fun too... if it works
        public static void Load()
        {
            string content = null;
            using (StreamReader sr = new StreamReader("saveFile.txt"))
            {
                content = sr.ReadToEnd();
            }

        }
            public static Object NewStart() 
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("You awake on solid, but mossy ground.");
            Console.WriteLine("Your head is spinning and your body hurts.");
            Console.WriteLine("You try to remember your name...:");
            //self-insert time
            p.name = Console.ReadLine();
            Console.Clear();
            // haha did the funny
            if (p.name == "Claudio")
            {
                Console.WriteLine(" Your name is  " + p.name + "? You are not allowed here, back to ESO with you!");
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
            Console.ReadKey();
            Encounters.firstEncounter();
            return p;
            
        }
        
            
        

    }   

}      

                
            


        
    
