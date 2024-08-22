using System;
using System.Collections.Generic;

namespace TextBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private string playerName;
        private bool isPlaying;
        private Dictionary<string, string> inventory = new Dictionary<string, string>();

        public void Start()
        {
            Console.WriteLine("Welcome to the Text-Based Adventure Game!");
            Console.Write("What is your name, adventurer? ");
            playerName = Console.ReadLine();

            Console.WriteLine($"Greetings, {playerName}! Your adventure begins now...");
            isPlaying = true;

            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            while (isPlaying)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. Check Inventory");
                Console.WriteLine("3. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Explore();
                        break;
                    case "2":
                        CheckInventory();
                        break;
                    case "3":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void Explore()
        {
            Console.WriteLine("\nYou are standing at a crossroads. You can go:");
            Console.WriteLine("1. North to the Dark Forest");
            Console.WriteLine("2. East to the Quiet Village");
            Console.WriteLine("3. South to the Riverbank");
            Console.WriteLine("4. West to the Abandoned Castle");

            Console.Write("Which direction do you want to go? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    VisitDarkForest();
                    break;
                case "2":
                    VisitQuietVillage();
                    break;
                case "3":
                    VisitRiverbank();
                    break;
                case "4":
                    VisitAbandonedCastle();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void VisitDarkForest()
        {
            Console.WriteLine("\nYou venture into the Dark Forest. The trees are tall and ominous, blocking out most of the sunlight.");
            Console.WriteLine("As you walk deeper into the forest, you find a strange glowing object on the ground.");

            Console.Write("Do you want to pick it up? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                AddToInventory("Glowing Stone", "A mysterious stone that emits a faint, eerie light.");
                Console.WriteLine("You pick up the Glowing Stone and put it in your inventory.");
            }
            else
            {
                Console.WriteLine("You decide to leave the strange object and walk away.");
            }
        }

        private void VisitQuietVillage()
        {
            Console.WriteLine("\nYou arrive at the Quiet Village. The villagers are friendly, and the atmosphere is peaceful.");
            Console.WriteLine("You find a market stall selling various items.");

            Console.Write("Do you want to buy a health potion for 10 gold? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                AddToInventory("Health Potion", "Restores 50 health points.");
                Console.WriteLine("You buy a Health Potion and put it in your inventory.");
            }
            else
            {
                Console.WriteLine("You decide not to buy anything and continue exploring.");
            }
        }

        private void VisitRiverbank()
        {
            Console.WriteLine("\nYou walk along the Riverbank. The sound of the flowing water is soothing.");
            Console.WriteLine("You notice something shiny in the water.");

            Console.Write("Do you want to reach into the water and grab it? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                AddToInventory("Silver Coin", "An old, worn silver coin.");
                Console.WriteLine("You retrieve the Silver Coin from the water and put it in your inventory.");
            }
            else
            {
                Console.WriteLine("You decide not to disturb the water and continue on your way.");
            }
        }

        private void VisitAbandonedCastle()
        {
            Console.WriteLine("\nYou approach the Abandoned Castle. The structure is old and crumbling, with an eerie silence surrounding it.");
            Console.WriteLine("You feel a chill in the air as you stand before the entrance.");

            Console.Write("Do you want to enter the castle? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.WriteLine("You step inside the castle, the darkness enveloping you.");
                // Add more logic here for exploring the castle
            }
            else
            {
                Console.WriteLine("You decide not to enter the castle and turn back.");
            }
        }

        private void CheckInventory()
        {
            Console.WriteLine("\nInventory:");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

        private void AddToInventory(string itemName, string itemDescription)
        {
            if (!inventory.ContainsKey(itemName))
            {
                inventory.Add(itemName, itemDescription);
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("\nThank you for playing! Farewell, adventurer.");
            isPlaying = false;
        }
    }
}
