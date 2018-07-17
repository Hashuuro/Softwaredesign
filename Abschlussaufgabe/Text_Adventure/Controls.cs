using System;
using System.Collections.Generic;


namespace Text_Adventure
{
    class Controls
    {

        private List<Room> map = new List<Room>();

        // show aviable commands
        public static void ShowCommands()
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
        }

        // pick up items
        public static void PickUp(string command, Room currentRoom, Character currentCharacter)
        {
            if (command == "pick up")
            {
                Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                return;
            }

            if (currentRoom.getInventory().Exists(x => x.Name == command.Substring(8)) && currentRoom.getInventory().Exists(x => x.Useable == true))
            {
                if (command.Substring(8).ToLower() == "papers")
                {
                    currentCharacter.addItem(currentRoom.takeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + "and hear the sound of something metallic falling.");
                    Item big_key = new Item("big key", true, true, "A big key with many ornaments.");
                    currentRoom.addItem(big_key);
                    return;
                }
                else
                {
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

        //Drop items
        public static void Drop(string command, Room currentRoom, Character currentCharacter)
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

        // look at items or characters
        public static void LookAt(string command, Room currentRoom, Character currentCharacter)
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

        // use objects 
        public static void Use(string command, Room currentRoom, Character currentCharacter)
        {
            if (command == "use")
            {
                Console.WriteLine("\nPlease specify what you wish to use.\n");
                return;
            }

            if (currentCharacter.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
            {

                if (currentRoom.getTitle() == "Bedroom" && command.ToLower().Substring(4) == "small key")
                {
                    Door studydoor_east = currentRoom.getDoors().Find(x => x.getDirection().Equals(Door.Directions.East));
                    studydoor_east.SetLocked(false);
                    Console.WriteLine("you unlocked the Door!");
                    return;
                }

                 if (command.ToLower().Substring(4) == "painkiller")
                {
                    healing(currentCharacter,"painkiller");
                    return;          
                }

                if (currentRoom.getTitle() == "Living Room" && command.ToLower().Substring(4) == "big key")
                {
                    Door atelierdoor = currentRoom.getDoors().Find(x => x.getDirection().Equals(Door.Directions.West));
                    atelierdoor.SetLocked(false);
                    Console.WriteLine("you unlocked the Door!");

                    return;
                }

                Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                
                string secondItem = Console.ReadLine();

                if (currentRoom.getInventory().Exists(x => x.Name == secondItem.ToLower()))
                {
                    if (secondItem == "podest" && command.Substring(4) == "amethyst")
                    {
                        Item  escapeRoute= new Item("passage", false, "A long and dark Passage. In the distance you can see a little light glowing.");
                        
                        currentRoom.addItem(escapeRoute);
                        currentRoom.removeItem(currentRoom.getInventory().Find(x=>x.name =="Podest"));     
                        currentRoom.removeItem(currentCharacter.getInventory().Find(x=>x.name =="amethyst"));
                        Console.WriteLine("\nYou placed the amethyst on the Podest. It sinks slowly in to the ground and reaveals a dark Passageway.\n");
                        return;
                    }


                    if (secondItem == "shelf" && command.Substring(4) == "weights")
                    {
                        Console.WriteLine("You throw the weights on top of the shelf and it comes crushing down, revealing some painkillers");
                        Item health = new Item("painkiller", true, "Painkiller, which you can get nearly everywhere. Still they do their job.",30);
                        currentRoom.addItem(health);

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
                    case ("light switch"):

                        Console.WriteLine("You turned the light on.");
                        currentRoom.setDescription("You are standing in the Entry Hall.\nIt's a room with a high ceiling and the floor was made from marble.\nThere are a wardrobe an a hatstand in the corner of the room\nand you notice some shoe prints leading deeper into the mansion.");
                        Item umbrella = new Item("umbrella", true, "An classic umbrella with a sharp end.", 10);
                        currentRoom.addItem(umbrella);
                        Item light = currentRoom.getInventory().Find(x => x.Name.Contains("light"));
                        currentRoom.removeItem(light);

                    return;

                    case ("clock"):

                        Console.WriteLine("You opened the clock and found some weights.");
                        Item weights = new Item("weights", true, "These weights are normally used to adjust the clock.\nI wonder if they could be used for other things?", 10);
                        currentRoom.addItem(weights);
                        Item clock = currentRoom.getInventory().Find(x => x.Name.Contains("clock"));
                        currentRoom.removeItem(clock);

                    return;

                    case ("bathtub"):

                        Console.WriteLine("Slowy the water begins sinking and you can see a key on the ground\n");
                        Item small_key = new Item("small key", true, "A small key, for one of the closed rooms in the Mansion.\nBut which one?");
                        currentRoom.addItem(small_key);
                        Item bathtub = currentRoom.getInventory().Find(x => x.Name.Contains("bathtub"));
                        currentRoom.removeItem(bathtub);


                    return;

                    case ("passage"):

                        Console.WriteLine("\nAt the End of the Passage you get in to the open.\nYou squeeze your eyes and look around.\nBehind you is a large forest and if you look close,\nyou can see the Mansion in the Distance.\nYou begin to walk away from the Mansion,\nnot turning back once. You live and that is all that matters.");
                        Game.gameOver = true;


                    return;

                }

            }
            else
            {
                Console.WriteLine("\nThere is nothing to use.\n");
                return;
            }
        }

        //Attack other characters 
        public static void Attack(string command, Room currentRoom, Character currentCharacter, Character currentEnemy)
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

                    Item currentWeapon = currentCharacter.getInventory().Find(x => x.Name.Contains(weapon));

                    int attackmodifier = currentWeapon.Weapon_bonus;

                    if (currentCharacter.Char_HP_Current > 0 && currentEnemy.Char_HP_Current > 0)
                    {

                        int damage = currentCharacter.attack_value + attackmodifier;

                        int hp_enemy = currentEnemy.Char_HP_Current - damage;

                        currentEnemy.Char_HP_Current = hp_enemy;

                        int myhp = currentCharacter.Char_HP_Current - currentEnemy.attack_value;

                        currentCharacter.Char_HP_Current = myhp;


                        switch (currentEnemy.name)
                        {
                            case ("Dog"):

                                Console.WriteLine("You hit {0} for {1} Damage!", currentEnemy.name, damage);
                                Console.WriteLine("\n");
                                Console.WriteLine("Woof. Grr!!");
                                Console.WriteLine("\n");
                                Console.WriteLine("{0} hit you for {1} Damage!", currentEnemy.name, currentEnemy.attack_value);

                            return;

                            case ("Zombie"):

                                Console.WriteLine("You hit {0} for {1} Damage!", currentEnemy.name, damage);
                                Console.WriteLine("\n");
                                Console.WriteLine("Urrrga. Graa!!");
                                Console.WriteLine("\n");
                                Console.WriteLine("{0} hit you for {1} Damage!", currentEnemy.name, currentEnemy.attack_value);

                            return;

                            case ("Sean Michals"):

                                Console.WriteLine("You hit {0} for {1} Damage!",currentEnemy.name, damage);
                                Console.WriteLine("\n");
                                Console.WriteLine("What are you doing you bastard. Here come and get it!");
                                Console.WriteLine("\n");
                                Console.WriteLine("{0} hit you for {1} Damage!", currentEnemy.name, currentEnemy.attack_value);

                            return;

                            case ("Sarah Hardy"):

                                Console.WriteLine("You hit {0} for {1} Damage!", currentEnemy.name, damage);
                                Console.WriteLine("\n");
                                Console.WriteLine("Ouch that hurt! That should bring you back to your senses!");
                                Console.WriteLine("\n");
                                Console.WriteLine("{0} hit you for {1} Damage!", currentEnemy.name, currentEnemy.attack_value);

                            return;
                        }
                    }
                    if (currentCharacter.Char_HP_Current > 0 && currentEnemy.Char_HP_Current <= 0)
                    {
                        switch (currentEnemy.name)
                        {
                            case("Dog"):

                            Console.WriteLine("Feeep. Wimper.");

                            break;

                            case("Zombie"):
                            
                            Console.WriteLine("Guaahh. Uurgs.");

                            break;

                            case("Sean Michals"):

                            Console.WriteLine("You son of a....i hope you'll rot in hell!");

                            break;

                            case("Sarah Hardy"):

                            Console.WriteLine("Why must it end here? What evil has befallen you?");

                            break;
                        }
                        currentRoom.removeCharacter(currentEnemy);
                        Console.WriteLine("Enemy defeated!");
                        return;
                    }
                    else
                    {
                        Game.gameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("You have no weapon to fight with!");
                    return;
                }

            }
            else
            {
                Console.WriteLine("\nThere is nobody to attack.\n");
                return;
            }
        }

        private static void healing(Character currentCharacter, string Item)
        {
            Item healitem = currentCharacter.getInventory().Find(x => x.name == Item);

            int healing = currentCharacter.Char_HP_Current + healitem.Weapon_bonus;
            
            currentCharacter.Char_HP_Current = healing;

            currentCharacter.removeItem(currentCharacter.getInventory().Find(x=>x.name == Item));

            Console.WriteLine("You healed yourself for " + healitem.Weapon_bonus);
        }

        //show Character status
        public static void ShowStatus(Character character)
        {
            Console.WriteLine("Your Status: ");
            Console.WriteLine("\n");
            Console.WriteLine("Name: " + character.name);
            Console.WriteLine("\n");
            Console.WriteLine("Health: {0}/{1}", character.Char_HP_Current, character.Char_HP_Full);
            Console.WriteLine("\n");
            character.ShowInventory();
            Console.WriteLine();
        }

        
    }

    
}