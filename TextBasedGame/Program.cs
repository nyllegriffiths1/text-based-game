using System;
using System.Collections.Generic;

namespace TextBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Game class and start the game
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private string playerName; // Store the player's name
        private bool isPlaying; // Control the main game loop
        private Dictionary<string, string> inventory = new Dictionary<string, string>(); // Store player's inventory items
        private int playerHealth = 100; // Initialize player's health

        // The main entry point to start the game
        public void Start()
        {
            Console.WriteLine("Welcome to the Text-Based Adventure Game!");
            Console.Write("What is your name, adventurer? ");
            playerName = Console.ReadLine();

            Console.WriteLine($"Greetings, {playerName}! Your adventure begins now...");
            isPlaying = true;

            // Start the main menu loop
            ShowMainMenu();
        }

        // Main menu where the player can choose actions
        private void ShowMainMenu()
        {
            while (isPlaying)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. Check Inventory");
                Console.WriteLine("3. Check Health");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                // Handle menu choices
                switch (choice)
                {
                    case "1":
                        Explore();
                        break;
                    case "2":
                        CheckInventory();
                        break;
                    case "3":
                        CheckHealth();
                        break;
                    case "4":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // The exploration logic where the player can choose where to go
        private void Explore()
        {
            Console.WriteLine("\nYou are standing at a crossroads. You can go:");
            Console.WriteLine("1. North to the Dark Forest");
            Console.WriteLine("2. East to the Quiet Village");
            Console.WriteLine("3. South to the Riverbank");
            Console.WriteLine("4. West to the Abandoned Castle");

            Console.Write("Which direction do you want to go? ");
            string choice = Console.ReadLine();

            // Handle exploration choices
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

        // Visit the Dark Forest and potentially find a mysterious object
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

            // Adding a potential combat scenario
            Console.WriteLine("Suddenly, a wild wolf appears! It looks aggressive.");
            Combat("Wolf", 20); // Engage in combat with a wolf with 20 health
        }

        // Visit the Quiet Village, where you can interact with the villagers
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

        // Visit the Riverbank and potentially find a valuable item
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

        // Visit the Abandoned Castle, which could hold treasures or dangers
        private void VisitAbandonedCastle()
        {
            Console.WriteLine("\nYou approach the Abandoned Castle. The structure is old and crumbling, with an eerie silence surrounding it.");
            Console.WriteLine("You feel a chill in the air as you stand before the entrance.");

            Console.Write("Do you want to enter the castle? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.WriteLine("You step inside the castle, the darkness enveloping you.");
                Console.WriteLine("As you explore, you find a dusty old chest.");

                Console.Write("Do you want to open the chest? (yes/no): ");
                string chestChoice = Console.ReadLine().ToLower();

                if (chestChoice == "yes")
                {
                    AddToInventory("Ancient Sword", "A rusty but powerful sword.");
                    Console.WriteLine("You open the chest and find an Ancient Sword. It might come in handy later.");
                }
                else
                {
                    Console.WriteLine("You decide to leave the chest unopened and continue exploring.");
                }

                // Potential for another combat scenario
                Console.WriteLine("As you turn to leave, a skeleton warrior emerges from the shadows!");
                Combat("Skeleton Warrior", 30); // Engage in combat with a skeleton warrior with 30 health
            }
            else
            {
                Console.WriteLine("You decide not to enter the castle and turn back.");
            }
        }

        // Simple combat system where the player fights a monster
        private void Combat(string enemyName, int enemyHealth)
        {
            Console.WriteLine($"You are now in combat with a {enemyName}!");

            while (enemyHealth > 0 && playerHealth > 0)
            {
                Console.WriteLine($"\n{enemyName} Health: {enemyHealth}");
                Console.WriteLine($"Your Health: {playerHealth}");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Run");

                Console.Write("What do you want to do? ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Basic attack: reduce the enemy's health
                    int damage = new Random().Next(10, 20); // Random damage between 10 and 20
                    enemyHealth -= damage;
                    Console.WriteLine($"You hit the {enemyName} for {damage} damage!");

                    if (enemyHealth > 0)
                    {
                        // Enemy attacks back
                        int enemyDamage = new Random().Next(5, 15); // Random damage between 5 and 15
                        playerHealth -= enemyDamage;
                        Console.WriteLine($"The {enemyName} hits you for {enemyDamage} damage!");
                    }
                    else
                    {
                        Console.WriteLine($"You have defeated the {enemyName}!");
                    }
                }
                else if (choice == "2")
                {
                    // The player chooses to run away
                    Console.WriteLine("You run away from the fight!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("You have been defeated. Game Over.");
                isPlaying = false; // End the game if the player dies
            }
        }

        // Check the player's inventory
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

        // Check the player's health
        private void CheckHealth()
        {
            Console.WriteLine($"\nYour current health is: {playerHealth}");
        }

        // Add an item to the player's inventory
        private void AddToInventory(string itemName, string itemDescription)
        {
            if (!inventory.ContainsKey(itemName))
            {
                inventory.Add(itemName, itemDescription);
                Console.WriteLine($"{itemName} has been added to your inventory.");
            }
            else
            {
                Console.WriteLine("You already have this item in your inventory.");
            }
        }

        // Exit the game
        private void ExitGame()
        {
            Console.WriteLine("\nThank you for playing! Farewell, adventurer.");
            isPlaying = false; // Stop the game loop
        }
    }
}
