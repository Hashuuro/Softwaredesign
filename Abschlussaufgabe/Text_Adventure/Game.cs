using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Game
    {
        // Gamestatus
        Room currentRoom;

        Room currentRoomNPC;

        Room oldRoomNPC;

        private List<Room> map = new List<Room>();

        Character currentCharacter;
        Character currentEnemy;

        Character currentNPC; 
        public static bool game_running = true;
        public static bool gameOver = false;
        //character name
        public static string charname = "John Doe";
        

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
        public void ShowLocation()
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

            Room living_Room = new Room("Living Room", "A very spacious living-room in an Victorian style setup.\nIn the middle of the room is a big Desk ");
            Item Clock = new Item("clock", true, "An antique looking clock. It doesnt seem to work anymore.");
            living_Room.addItem(Clock);

            Room kitchen = new Room("Kitchen", "This is the Kitchen. It has two big oven and in the middle a cooking field.\nIt is rather old school, like everything in the house.");
            Item knife = new Item("knife", true, "A very sharp kitchen Knife. It can even cut bones!",30);
            kitchen.addItem(knife);


            Room storeroom = new Room("Storeroom", "A storeroom for food. Nothing special seems to be here");
            Item shelf = new Item("shelf", true, "A normal shelf for storing. Weirdly it seems a bit slanted and at the moment not usable.");
            storeroom.addItem(shelf);

            Room bedroom = new Room("Bedroom", "The only Bedroom in the Mansion. It is spacious with a big bed and many drawers.");
            Item amethyst = new Item("amethyst", true, "A beautiful gem. Should you take it? But it's heavy and it isn't yours.");
            bedroom.addItem(amethyst);

            Room bath = new Room("Bath", "A rather luxurious bath with gold and silver everywhere. There is a bathtub and a shower!");
            Item bathtub = new Item("bathtub", false, "A big old fashioned bathtub with paintings of flowers and animals all over it.\nIt is filled to the brim with a dark liquid. Hopefully still water.");
            bath.addItem(bathtub);


            Room study = new Room("Study", "A study with a big desk in the middle. Papers and books are scattered everywhere.");
            Item papers = new Item("papers", true, "Some kind of Studies about the human brain and the effects of sleep deprevation.\nNot really weird for research.");
            study.addItem(papers);
        
            Room atelier = new Room("Atelier", "The Atelier. Many pictures from famous painters are hanging here.\nThe fromer Lord of this Mansion must have been a great art lover.");
            Item podest = new Item("podest", false, "A podest used to show art or other valuable things. It seems to have something missing.");
            atelier.addItem(podest);


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

            // Characters
            Character protagonist = new Character();
            protagonist.name = charname;
            Character sarah = new Character("Sarah Hardy", true, true, "One of the few survivors. She has long brown hair and a small figure,\nbut her eyes are gleaming with determination.", 120, 120, 10);
            Character sean = new Character("Sean Michals", true, true, "One of the few survivors. He is a tall and muscular man, probably a Marine.", 150, 150, 30);
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

            // add Rooms to overall Map
            map.Add(atelier);
            map.Add(entry_Hall);
            map.Add(living_Room);
            map.Add(kitchen);
            map.Add(storeroom);
            map.Add(bedroom);
            map.Add(bath);
            map.Add(study);

            ShowLocation();
        }


        //commands for player
        public void doAction(string command)
        {

            if (command == "commands" || command == "c")
            {
                Controls.ShowCommands();
                return;
            }

            //If statement to access the player inventory
            if (command == "inventory" || command == "i")
            {
                currentCharacter.ShowInventory();
                return;
            }

            if (command == "status")
            {
                Controls.ShowStatus(currentCharacter);
                return;
            }

            //If statement for player to pick up objects
            if (command.Length >= 7 && command.Substring(0, 7) == "pick up")
            {
                Controls.PickUp(command, currentRoom, currentCharacter);
                ShowLocation();
                return;
            }

            // drop command
            if (command.Length >= 4 && command.Substring(0, 4) == "drop")
            {
               Controls.Drop(command, currentRoom, currentCharacter);
               ShowLocation();
               return;
            }

            // look command
            if (command == "look" || command == "l")
            {
                ShowLocation();
                if (currentRoom.getInventory().Count == 0 && currentRoom.getCharacters().Count == 0)
                {
                    Console.WriteLine("There are no items of interest in the room.\n");
                }
                return;
            }

            //look At command
            if (command.Length >= 7 && command.Substring(0, 7) == "look at")
            {
               Controls.LookAt(command, currentRoom, currentCharacter);
               return;
            }

            // use command
            if (command.Length >= 3 && command.Substring(0, 3) == "use")
            {
                Controls.Use(command, currentRoom, currentCharacter);
            
               if(!gameOver)
               {
                ShowLocation();
               }
                return;
            }


            // attack command
            if (command.Length >= 6 && command.Substring(0, 6) == "attack")
            {
                Controls.Attack(command, currentRoom, currentCharacter, currentEnemy);
                return;
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
       
                        moveNPC("Sarah Hardy");
                        moveNPC("Sean Michals");

                        ShowLocation();

                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Door is closed!");
                }
            }
        }
        private void moveNPC(string NPC)
        {

            if(map.Exists(x => x.getCharacters().Exists(y => y.name == NPC)))
            {
                currentRoomNPC = map.Find(Room => Room.getCharacters().Exists(x => x.name == NPC));
               
                currentNPC = currentRoomNPC.getCharacters().Find(x => x.Name == NPC);
               
                string[] direction = new string[] { "North","South","West","East" };

                Random random = new Random();
                    
                int randomDirection = random.Next(0, direction.Length);
                 
                string randomDoor = direction[randomDirection];
                    
                foreach (Door door in currentRoomNPC.getDoors())
                {

                    if(!door.GetLocked())
                    {
                        if (randomDoor == door.ToString())
                        {   
                            oldRoomNPC = currentRoomNPC;
                            currentRoomNPC = door.getLeadsTo();
                            
                            currentRoomNPC.addCharacter(currentNPC);
                            oldRoomNPC.removeCharacter(currentNPC);

                        return;
                        }
                    }
                    else
                    {
                        moveNPC(NPC);
                        
                    }
                   
                }
                return;
            }
            else
            {
                return;
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


            if (!gameOver)
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