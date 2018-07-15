using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Game
    {
        // Gamestatus
        Room currentRoom;

        Character currentCharacter;
        public static bool game_running = true;
        private bool _gameOver = false;

        //character name
        public static string charname = "John Doe";
       // private List<Item> inventory;

        //print out game title and overview
        public static void StartGame()
        {

            //statements
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "Hollow Mansion";
            string title = @"
                  _______  _        _        _______          
        |\     /|(  ___  )( \      ( \      (  ___  )|\     /|
        | )   ( || (   ) || (      | (      | (   ) || )   ( |
        | (___) || |   | || |      | |      | |   | || | _ | |
        |  ___  || |   | || |      | |      | |   | || |( )| |
        | (   ) || |   | || |      | |      | |   | || || || |
        | )   ( || (___) || (____/\| (____/\| (___) || () () |
        |/     \|(_______)(_______/(_______/(_______)(_______)
                                                      
         _______  _______  _        _______ _________ _______  _       
        (       )(  ___  )( (    /|(  ____ \\__   __/(  ___  )( (    /|
        | () () || (   ) ||  \  ( || (    \/   ) (   | (   ) ||  \  ( |
        | || || || (___) ||   \ | || (_____    | |   | |   | ||   \ | |
        | |(_)| ||  ___  || (\ \) |(_____  )   | |   | |   | || (\ \) |
        | |   | || (   ) || | \   |      ) |   | |   | |   | || | \   |
        | )   ( || )   ( || )  \  |/\____) |___) (___| (___) || )  \  |
        |/     \||/     \||/    )_)\_______)\_______/(_______)|/    )_)";
            Console.WriteLine(title);
            Console.ResetColor();
            Console.Write("\n\n\n");
            Console.Write("                          Press Enter to Play!");
            Console.ReadKey();
            Console.Clear();
            NameCharacter();

        }

        //ask player for a name, and save it
        static void NameCharacter()
        {
            Console.Write("Please enter your Name: ");
            charname = Console.ReadLine();
            //Intro
            Console.WriteLine("Hello " + charname + ". It's nice to meet you.");
            Console.Write("\n\n\n");
            Console.WriteLine("You are standing in front of the entrance to an old Mansion.\nThere is a storm raging on and the otherwise dark building gets clad in white light, everytime the lightning strikes.\nYou don't know, why you're here or how you even got here, \nbut this old Mansion seems to have some kind of attraction you can't ignore.\nYou walk up the stairs and push against the big, old Entrance door.\nWith a loud crunch the door opens and after some hesitation you walk into the dark Entry Hall.");
        }
        public void showLocation()
        {
            Console.WriteLine("\n" + currentRoom.getTitle() + "\n");
            Console.WriteLine(currentRoom.getDescription());

            if (currentRoom.getInventory().Count > 0)
            {
                Console.WriteLine("\nThe room contains the following:\n");

                for (int i = 0; i < currentRoom.getInventory().Count; i++)
                {
                    Console.WriteLine(currentRoom.getInventory()[i].Name);
                }
            }

            Console.WriteLine("\nThere are doors in these Directions: \n");

            foreach (Door door in currentRoom.getDoors())
            {
                Console.WriteLine(door.getDirection());
            }

            Console.WriteLine();
        }

        public Game()
        {
            StartGame();
        
            Console.WriteLine("\n\n");
            Console.WriteLine("Press 'c' or type commands' to get an overview of the input options.");

            // build the "map"

            Room entry_Hall = new Room("Entry Hall", "You are standing in the dark Entry Hall.\nYou can't see anything, except for the few seconds,\nwhen a new lightning strikes.");
            Item light = new Item("light switch", true, "An old light switch, barely noticeable in the darkness.");
            entry_Hall.addItem(light);

            Room living_Room = new Room("Living Room", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            living_Room.addItem(window);

            Room kitchen = new Room("Kitchen", "This is a small and cluttered study, containing a desk covered with\npapers. Though they no doubt are of some importance,\nyou cannot read their writing");
            Item knife = new Item("knife", false, "A single sheet of glass. It seems sealed up.");
            kitchen.addItem(knife);

            Room storeroom = new Room("Storeroom", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window2 = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            storeroom.addItem(window2);

            Room bedroom = new Room("Bedroom", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window3 = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            bedroom.addItem(window3);

            Room bath = new Room("Bath", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window4 = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            bath.addItem(window4);

            Room study = new Room("Study", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window5 = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            study.addItem(window5);

            Room atelier = new Room("Atelier", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window6 = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            atelier.addItem(window6);


            entry_Hall.addDoor(new Door(Door.Directions.North, living_Room));

            living_Room.addDoor(new Door(Door.Directions.East, kitchen));
            living_Room.addDoor(new Door(Door.Directions.North, bedroom));
            living_Room.addDoor(new Door(Door.Directions.West, atelier, true, false));
            living_Room.addDoor(new Door(Door.Directions.South, entry_Hall));

            kitchen.addDoor(new Door(Door.Directions.North, storeroom));
            kitchen.addDoor(new Door(Door.Directions.West, living_Room));

            storeroom.addDoor(new Door(Door.Directions.North, study, false, true));
            storeroom.addDoor(new Door(Door.Directions.South, kitchen));

            bedroom.addDoor(new Door(Door.Directions.West, bath));
            bedroom.addDoor(new Door(Door.Directions.East, study,true,false));
            bedroom.addDoor(new Door(Door.Directions.South, living_Room));

            bath.addDoor(new Door(Door.Directions.East, bedroom));

            study.addDoor(new Door(Door.Directions.West, bedroom));
            study.addDoor(new Door(Door.Directions.South, storeroom));

            atelier.addDoor(new Door(Door.Directions.East, living_Room));

            currentRoom = entry_Hall;
            showLocation();

            // Characters
            Character protagonist = new Character();
            protagonist.name = charname;
            Character sarah = new Character();
            Character sean = new Character();
            currentCharacter = protagonist;

            // Monsters
            Character zombie = new Character();
            Character dog = new Character();


        }



        public void doAction(string command)
        {

            if (command == "commands" || command == "c")
            {
                Console.WriteLine("Menu");
                Console.WriteLine("------------------------------------------------------------------------------------------");
                Console.WriteLine("'l' / 'look':        Shows you a Description of the room you are in and its Contents.");
                Console.WriteLine("'Look at X':         Gives you information about a specific item in your \n                     inventory, where X is the items name.");
                Console.WriteLine("'pick up X':         Attempts to pick up an item, where X is the items name.");
                Console.WriteLine("'use X':             Attempts to use an item, where X is the items name.");
                Console.WriteLine("'i' / 'inventory':   Allows you to see the items in your inventory.");
                Console.WriteLine("'q' / 'quit':        Quits the game.");
                Console.WriteLine("'status':            Tells you the name and condition of your character.");
                Console.WriteLine("Directions can be input as either the full word, or the abbriviation, \ne.g. 'North or N'");
                return;
            }

            //If statement to access the player inventory
            if (command == "inventory" || command == "i")
            {
                currentCharacter.showInventory();
                Console.WriteLine();
                return;
            }

            if (command == "status")
            {
                showStatus();
                return;
            }

            //If statement for player to pick up objects
            if (command.Length >= 7 && command.Substring(0, 7) == "pick up")
            {
                if (command == "pick up")
                {
                    Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                    return;
                }
                if (currentRoom.getInventory().Exists(x => x.Name == command.Substring(8)) && currentRoom.getInventory().Exists(x => x.Useable == true))
                {
                    currentCharacter.addItem(currentRoom.takeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + ".\n");
                    return;
                }
                if (currentRoom.getInventory().Exists(x => x.Name == command.Substring(8)) && currentRoom.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + command.Substring(8) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(8) + " does not exist.\n");
                    return;
                }
            }

            // drop command
            if (command.Length >= 4 && command.Substring(0, 4) == "drop")
            {
                if (command == "drop")
                {
                    Console.WriteLine("\nPlease specify what you would like to drop.\n");
                    return;
                }
                if (currentCharacter.getInventory().Exists(x => x.Name == command.Substring(5)))
                {
                    currentRoom.addItem(currentCharacter.takeItem(command.Substring(5)));
                    Console.WriteLine("\nYou droped the " + command.Substring(5) + ".\n");
                    return;
                }
                if (currentRoom.getInventory().Exists(x => x.Name == command.Substring(5)) && currentRoom.getInventory().Exists(x => x.KeyItem == true))
                {
                    Console.WriteLine("\nYou cannot drop the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(5) + " does not exist.\n");
                    return;
                }
            }

            if (command == "look" || command == "l")
            {
                showLocation();
                if (currentRoom.getInventory().Count == 0)
                {
                    Console.WriteLine("There are no items of interest in the room.\n");
                }
                return;
            }

            if (command.Length >= 7 && command.Substring(0, 7) == "look at")
            {
                if (command == "look at")
                {
                    Console.WriteLine("\nPlease specify what you wish to look at.\n");
                    return;
                }
                if (currentRoom.getInventory().Exists(x => x.Name == command.Substring(8)) || currentCharacter.getInventory().Exists(x => x.Name == command.ToLower().Substring(8)))
                {
                    switch(command.Substring(8).ToLower())
                    {
                        case("rock"):
                            Console.WriteLine("\n" + currentRoom.getInventory().Find(x => x.Name.Contains("rock")).Description + "\n");
                        return;

                        case("window"):
                            Console.WriteLine("\n" + currentRoom.getInventory().Find(x => x.Name.Contains("window")).Description + "\n");
                        return;

                        case("smashed window"):
                            Console.WriteLine("\n" + currentRoom.getInventory().Find(x => x.Name.Contains("smashed window")).Description + "\n");
                        return;
                    }
                    
                }
                else
                {
                    Console.WriteLine("\nThat item does not exist in this location or your inventory.\n");
                    return;
                }
            }

            if (command.Length >= 3 && command.Substring(0, 3) == "use")
            {
                if (command == "use")
                {
                    Console.WriteLine("\nPlease specify what you wish to use.\n");
                    return;
                }
                if (currentCharacter.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                    string secondItem = Console.ReadLine();
                    if (currentRoom.getInventory().Exists(x => x.Name == secondItem))
                    {
                        if (secondItem == "window" && command.Substring(4) == "rock")
                        {
                            Item smashedWindow = new Item("smashed window", false, "A window frame with broken pieces of glass inside.");
                            currentRoom.addItem(smashedWindow);
                            foreach (Item item in currentRoom.getInventory())
                            {
                                if (item.Name.ToLower() == "window")
                                {
                                    currentRoom.removeItem(item);
                                    break;
                                }

                                if (item.Name.ToLower() == "rock")
                                {
                                    currentRoom.removeItem(item);
                                    break;
                                }

                            }
                            Console.WriteLine("\nYou smash in the window.\n");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot do the thing.");
                        return;
                    }
                }
                if (currentRoom.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    switch(command.ToLower().Substring(4))
                    {
                        case("window"):

                            Console.WriteLine("\nThe window's locked tight, with no way of opening it.\n");
                        
                        return;
                        case("smashed window"):

                            Console.WriteLine("\nYou clamber out the window. Victory is yours!");
                        _gameOver = true;
                        
                        
                        return;
                        case("light switch"):

                             Console.WriteLine("You turned the light on.");
                        currentRoom.setDescription("You are standing in the Entry Hall.\nIt's a room with a high ceiling and the floor was made from marble.\nThere are a wardrobe an a hatstand in the corner of the room\nand you notice some shoe prints leading deeper into the mansion.");
                        Item umbrella = new Item("umbrella", true, "An classic umbrella with a sharp end.");
                        currentRoom.addItem(umbrella);
                        Item light = currentRoom.getInventory().Find(x => x.Name.Contains("light"));
                        currentRoom.removeItem(light);
                        showLocation();
                        return;
                        
                    }
                            
                }
                else
                {
                    Console.WriteLine("\nThere is nothing to use.\n");
                    return;
                }
            }

            if (moveRoom(command))
                return;

            Console.WriteLine("\nInvalid command, are you confused?\n");
        }

        private bool moveRoom(string command)
        {
            foreach (Door door in currentRoom.getDoors())
            {
                if(!door.getLock())
                {
                    if (command == door.ToString().ToLower() || command == door.getShortDirection().ToLower())
                    {
                        currentRoom = door.getLeadsTo();
                        Console.WriteLine("\nYou move " + door.ToString() + " to the:\n");
                        showLocation();
                        return true;
                    }
                }
            }
            return false;
        }

        private void showStatus()
        {
            Console.WriteLine("Your Status: ");
            Console.WriteLine("\n");
            Console.WriteLine("Name: " + currentCharacter.name);
            Console.WriteLine("\n");
            Console.WriteLine("Health: {0}/{1}", currentCharacter.Char_HP_Current, currentCharacter.Char_HP_Full);
            Console.WriteLine("\n");
            Console.WriteLine("Weapon: " + currentCharacter.weapon);
            Console.WriteLine("\n");
            currentCharacter.showInventory();
            Console.WriteLine();
        }
        public void Update()
        {
            string currentCommand = Console.ReadLine().ToLower();

            // instantly check for a quit
            if (currentCommand == "quit" || currentCommand == "q")
            {
                game_running = false;
                return;
            }


            if (!_gameOver)
            {
                // otherwise, process commands.
                doAction(currentCommand);
            }
            else
            {
                Console.WriteLine("\nGame Over!\n");
            }
        }

    }

}