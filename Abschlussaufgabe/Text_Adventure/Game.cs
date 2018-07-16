using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Game
    {
        // Gamestatus
        Room currentRoom;

        Character currentCharacter;
        Character currentEnemy;
        Item currentWeapon;
        Room neighbour;
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
            Console.WriteLine("You are standing in front of the entrance to an old Mansion.\nThere is a storm raging on and the otherwise dark building gets clad in white light, everytime the lightning strikes.\nYou were sent to find two people, who survived a helicopter crash and found refuge in this Mansion.\nBut this old Mansion seems to have some kind of darker secret you can't ignore.\nYou walk up the stairs and push against the big, old Entrance door.\nWith a loud crunch the door opens and after some hesitation you walk into the dark Entry Hall.");
        }

        // Room overview
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
            if (currentRoom.getCharacters().Count > 0)
            {
                Console.WriteLine("\nAs you enter the room, you notice these characters:\n");

                for (int i = 0; i < currentRoom.getCharacters().Count; i++)
                {
                    Console.WriteLine(currentRoom.getCharacters()[i].Name);
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

            Room living_Room = new Room("Living Room", "A very spacious living-room in an Victorian style getup.\nIn the middle of the room is a big Desk ");
            Item Clock = new Item("clock", true, "An antique looking clock. It doesnt seem to work anymore.");
            living_Room.addItem(Clock);

            Room kitchen = new Room("Kitchen", "This is the Kitchen. It has two big oven and in the middle a cooking field.\nIt is rather old school, like everything in the house.");
            Item knife = new Item("knife", true, "A very sharp kitchen Knife. It can even cut bones!",30);
            kitchen.addItem(knife);


            Room storeroom = new Room("Storeroom", "A storeroom for food. Nothing special seems to be here");
            Item shelf = new Item("Shelf", true, "A normal shelf for storing. Weirdly it seems a bit slanted and at the moment not usable.");
            storeroom.addItem(shelf);

            Room bedroom = new Room("Bedroom", "The only Bedroom in the Mansion. It is spacious with a big bed and many drawers.");
            Item amethyst = new Item("amethyst", true, "A beautiful gem. Should you take it? But it's heavy and it isn't yours.");
            bedroom.addItem(amethyst);

            Room bath = new Room("Bath", "A rather luxurious bath with gold and silver everywhere. There is a bathtub and a shower!");
            Item bathtub = new Item("bathtub", false, "A big old fashioned bathtub with paintings of flowers and animals all over it.\nIt is filled to the brim with a dark liquid. Hopefully still water.");
            bath.addItem(bathtub);


            Room study = new Room("Study", "A study with a big desk in the middle. Papers and books are scattered everywhere.");
            Item papers = new Item("Papers", false, " Some kind of Studies about the human brain and the effects of sleep deprevation.\nNot really weird for research.");
            study.addItem(papers);
        
            Room atelier = new Room("Atelier", "The Atelier. Many pictures from famous painters are hanging here.\nThe fromer Lord of this Mansion must have been a great art lover.");
            Item window = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            atelier.addItem(window);

            // add Doors
            entry_Hall.addDoor(new Door(Door.Directions.North, living_Room, false));

            living_Room.addDoor(new Door(Door.Directions.East, kitchen, false));
            living_Room.addDoor(new Door(Door.Directions.North, bedroom, false));
            living_Room.addDoor(new Door(Door.Directions.West, atelier, true));
            living_Room.addDoor(new Door(Door.Directions.South, entry_Hall, false));

            kitchen.addDoor(new Door(Door.Directions.North, storeroom, false));
            kitchen.addDoor(new Door(Door.Directions.West, living_Room, false));

            
            storeroom.addDoor(new Door(Door.Directions.South, kitchen, false));
            bedroom.addDoor(new Door(Door.Directions.West, bath, false));
            bedroom.addDoor(new Door(Door.Directions.East, study, true));

            bedroom.addDoor(new Door(Door.Directions.South, living_Room, false));

            bath.addDoor(new Door(Door.Directions.East, bedroom, false));

            study.addDoor(new Door(Door.Directions.West, bedroom, false));
            study.addDoor(new Door(Door.Directions.South, storeroom, false));

            atelier.addDoor(new Door(Door.Directions.East, living_Room, false));

            currentRoom = entry_Hall;
            neighbour = study;

            showLocation();

            // Characters
            Character protagonist = new Character();
            protagonist.name = charname;
            Character sarah = new Character("Sarah Hardy", true, true, "One of the few survivors. She has long brown hair and a small figure,\n but her eyes are gleaming with determination.", 120, 120, 10);
            Character sean = new Character("Sean Michals", true, true, "One of the few survivors. He is a tall and muscular man, probably a Marine.", 150, 150, 30);
            Item health = new Item("Painkiller", true, "Painkiller, which you can get nearly everywhere. Still they do their job.", 20);
            sean.addItem(health);
            currentCharacter = protagonist;

            // Monsters
            Character zombie = new Character("Zombie", true, false, "One of the many Corpses walking around the Mansion. The flesh is already peeling from his bones.", 50, 50, 20);
            Character dog = new Character("Dog", true, false, "They are trained Guard dogs. But why are they inside the Mansion? ", 20, 20, 25);

            // add Characters to room
            study.addCharacter(sarah);
            atelier.addCharacter(sean);
            kitchen.addCharacter(zombie);
            living_Room.addCharacter(dog);

            currentEnemy = dog;


        }


        //commands for player
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
                Console.WriteLine("'status':            Tells you the name and condition of your character.");
                Console.WriteLine("'attack with':       Attacks another character.");
                Console.WriteLine("'q' / quit':        Quits the game.");
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
                Character.showStatus(currentCharacter);
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
                    if(command.Substring(8)== "papers")
                    {
                    currentCharacter.addItem(currentRoom.takeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + "and hear the sound of something metallic falling.");
                    Item big_key = new Item("big key",true,true,"A big key with many ornaments.");
                    currentRoom.addItem(big_key);
                    showLocation();
                    return;
                    }
                    else{
                    currentCharacter.addItem(currentRoom.takeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + ".\n");
                    return;
                    }
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

            // look command
            if (command == "look" || command == "l")
            {
                showLocation();
                if (currentRoom.getInventory().Count == 0 && currentRoom.getCharacters().Count == 0)
                {
                    Console.WriteLine("There are no items of interest in the room.\n");
                }
                return;
            }

            //look At command
            if (command.Length >= 7 && command.Substring(0, 7) == "look at")
            {
                if (command == "look at")
                {
                    Console.WriteLine("\nPlease specify what you wish to look at.\n");
                    return;
                }

                if (currentRoom.getCharacters().Exists(x => x.Name.ToLower().Equals(command.ToLower().Substring(8))))
                {
                    Console.WriteLine("\n" + currentRoom.getCharacters().Find(x => x.Name.ToLower().Equals(command.ToLower().Substring(8))).Description + "\n");
                    return;
                }
                if (currentRoom.getInventory().Exists(x => x.Name.ToLower() == command.ToLower().Substring(8)))
                {
                    Console.WriteLine("\n" + currentRoom.getInventory().Find(x => x.Name.ToLower().Equals(command.ToLower().Substring(8))).Description + "\n");
                    return;
                }
                if (currentCharacter.getInventory().Exists(x => x.Name.ToLower() == command.ToLower().Substring(8)))
                {
                    Console.WriteLine("\n" + currentCharacter.getInventory().Find(x => x.Name.ToLower().Equals(command.ToLower().Substring(8))).Description + "\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nThat item does not exist in this location or your inventory.\n");
                    return;
                }
            }

            // use command
            if (command.Length >= 3 && command.Substring(0, 3) == "use")
            {
                if (command == "use")
                {
                    Console.WriteLine("\nPlease specify what you wish to use.\n");
                    return;
                }
                if (currentCharacter.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    if(currentRoom.getTitle() == "Bedroom"&&command.ToLower().Substring(4)=="small key")
                        {
                            Door studydoor = currentRoom.getDoors().Find(x => x.getDirection().Equals(Door.Directions.East));
                            studydoor.SetLocked(false);
                            showLocation();
                        return;
                        }

                    if(currentRoom.getTitle() == "Living Room"&&command.ToLower().Substring(4)=="big key")
                        {
                            Door atelierdoor = currentRoom.getDoors().Find(x => x.getDirection().Equals(Door.Directions.West));
                            atelierdoor.SetLocked(false);
                            showLocation();
                        return;
                        }

                    Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                    string secondItem = Console.ReadLine();
                    if (currentRoom.getInventory().Exists(x => x.Name == secondItem))
                    {
                        if (secondItem == "window" && command.Substring(4) == "amethyst")
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

                                if (item.Name.ToLower() == "amethyst")
                                {
                                    currentRoom.removeItem(item);
                                    break;
                                }

                            }
                            Console.WriteLine("\nYou smash in the window.\n");
                            return;
                        }


                        if (secondItem == "Shelf" && command.Substring(4) == "weights")
                        {
                           
                            //currentRoom.addDoor(new Door(Door.Directions.South, neighbour, false));
                            Console.WriteLine("\nThe secret passage has opened.\n");
                            showLocation();
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
                    switch (command.ToLower().Substring(4))
                    {
                        case ("bathtub"):

                            Console.WriteLine("Slowy the water begins sinking and you can see a key on the ground\n");
                            Item small_key = new Item("small key", true, "A small key, for one of the closed rooms in the Mansion.\nBut which one?");
                            currentRoom.addItem(small_key);
                            Item bathtub = currentRoom.getInventory().Find(x => x.Name.Contains("bathtub"));
                            currentRoom.removeItem(bathtub);
                            showLocation();

                            return;

                        case ("smashed window"):

                            Console.WriteLine("\nYou clamber out the window. Victory is yours!");
                            _gameOver = true;


                            return;

                        case ("light switch"):

                            Console.WriteLine("You turned the light on.");
                            currentRoom.setDescription("You are standing in the Entry Hall.\nIt's a room with a high ceiling and the floor was made from marble.\nThere are a wardrobe an a hatstand in the corner of the room\nand you notice some shoe prints leading deeper into the mansion.");
                            Item umbrella = new Item("umbrella", true, "An classic umbrella with a sharp end.", 10);
                            currentRoom.addItem(umbrella);
                            Item light = currentRoom.getInventory().Find(x => x.Name.Contains("light"));
                            currentRoom.removeItem(light);
                            showLocation();
                            return;

                        case ("clock"):

                            Console.WriteLine("You opened the clock and found some weights.");
                            Item weights = new Item("weights", true, "These weights are normally used to adjust the clock.\nI wonder if they could be used for other things?", 10);
                            currentRoom.addItem(weights);
                            Item clock = currentRoom.getInventory().Find(x => x.Name.Contains("clock"));
                            currentRoom.removeItem(clock);
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


            // attack command
            if (command.Length >= 6 && command.Substring(0, 6) == "attack")
            {
                if (command == "attack")
                {
                    Console.WriteLine("\nPlease specify what you wish to use.\n");
                    return;
                }
                if (currentRoom.getCharacters().Exists(x => x.Name.ToLower().Equals(command.ToLower().Substring(7))))
                {

                    Console.WriteLine("\nattack " + command.Substring(7) + " with?\n");
                    string weapon = Console.ReadLine();
                    if (currentCharacter.getInventory().Exists(x => x.Name == weapon))
                    {
                        currentEnemy = currentRoom.getCharacters().Find(x => x.Name.ToLower().Equals(command.ToLower().Substring(7)));

                        if (currentCharacter.Char_HP_Current > 0 && currentEnemy.Char_HP_Current > 0)
                        {

                            switch (weapon)
                            {
                                case ("umbrella"):

                                    currentWeapon = currentCharacter.getInventory().Find(x => x.Name.Contains("umbrella"));

                                    int attackmodifier = currentWeapon.Weapon_bonus;

                                    int damage = currentCharacter.attack_value + attackmodifier;

                                    int hp = currentEnemy.Char_HP_Current - damage;

                                    currentEnemy.Char_HP_Current = hp;

                                    Console.WriteLine("You hit {0} for {1} Damage!", currentEnemy.name, damage);

                                    int myhp = currentCharacter.Char_HP_Current - currentEnemy.attack_value;

                                    currentCharacter.Char_HP_Current = myhp;

                                    Console.WriteLine("{0} hit you for {1} Damage!", currentEnemy.name, currentEnemy.attack_value);

                                    return;

                                case ("knife"):

                                    currentWeapon = currentCharacter.getInventory().Find(x => x.Name.Contains("Knife"));

                                    attackmodifier = currentWeapon.Weapon_bonus;

                                    damage = currentCharacter.attack_value + attackmodifier;

                                    currentEnemy.Char_HP_Current = currentEnemy.Char_HP_Current - damage;

                                    Console.WriteLine("You hit {0} for {1} Damage!", currentEnemy, damage);

                                    currentCharacter.Char_HP_Current = currentCharacter.Char_HP_Current - currentEnemy.attack_value;

                                    Console.WriteLine("{0} hit you for {1} Damage!", currentEnemy, currentEnemy.attack_value);

                                    return;
                            }
                        }
                        if (currentCharacter.Char_HP_Current > 0 && currentEnemy.Char_HP_Current <= 0)
                        {
                            currentRoom.removeCharacter(currentEnemy);
                            Console.WriteLine("Enemy defeated!");
                            return;
                        }
                        else
                        {
                            _gameOver = true;
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot do the thing.");
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("\nThere is nothing to use.\n");
                    return;
                }
            }
            //move into other room
            moveRoom(command);

        }

        // move Method
        private void moveRoom(string command)
        {

            foreach (Door door in currentRoom.getDoors())
            {
                if (!door.GetLocked())
                {
                    if (command == door.ToString().ToLower() || command == door.getShortDirection().ToLower())
                    {
                        currentRoom = door.getLeadsTo();
                        Console.WriteLine("\nYou move " + door.ToString() + " to the:\n");
                        showLocation();

                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Door is closed!");
                }
            }

        }



        // update repeats itself
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
                Environment.Exit(0);
            }
        }

    }

}