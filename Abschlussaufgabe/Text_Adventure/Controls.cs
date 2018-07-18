using System;
using System.Collections.Generic;


namespace Text_Adventure
{
    class Controls
    {

        // show aviable commands
        public static void ShowCommands()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("'l' / 'look':        Shows you a Description of the room you are in and its Contents.");
            Console.WriteLine("'Look at X':         Gives you information about a specific item in your \n                     inventory, where X is the items name.");
            Console.WriteLine("'pick up X':         Attempts to pick up an item, where X is the items name.");
            Console.WriteLine("'use X':             Attempts to use an item, where X is the items name.");
            Console.WriteLine("'drop X':            Attempts to drop an item, where X is the items name.");
            Console.WriteLine("'attack X':          Attacks another character, where X stands for \n                           the characters name");
            Console.WriteLine("'i' / 'inventory':   Allows you to see the items in your inventory.");
            Console.WriteLine("'status':            Tells you the name and condition of your character.");
            Console.WriteLine("'q' / quit':         Quits the game.");
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

            if (currentRoom.GetInventory().Exists(x => x.Name == command.Substring(8)) && currentRoom.GetInventory().Exists(x => x.Useable == true))
            {
                if (command.Substring(8).ToLower() == "papers")
                {
                    currentCharacter.AddItem(currentRoom.TakeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + "and hear the sound of something metallic falling.");
                    Item big_key = new Item("big key", true, true, "A big key with many ornaments.");
                    currentRoom.AddItem(big_key);
                    return;
                }
                else
                {
                    currentCharacter.AddItem(currentRoom.TakeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + ".\n");
                    return;
                }
            }

            if (currentRoom.GetInventory().Exists(x => x.Name == command.Substring(8)) && currentRoom.GetInventory().Exists(item => item.Useable == false))
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
            if (currentCharacter.GetInventory().Exists(item => item.Name == command.Substring(5)))
            {
                currentRoom.AddItem(currentCharacter.TakeItem(command.Substring(5)));
                Console.WriteLine("\n{0} droped the " + command.Substring(5) + ".\n",currentCharacter.Name);
                return;
            }
            if (currentCharacter.GetInventory().Exists(item => item.Name == command.Substring(5)) && currentCharacter.GetInventory().Exists(item => item.KeyItem == true))
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

            if (currentRoom.GetCharacters().Exists(character => character.Name.ToLower().Equals(command.ToLower().Substring(8))))
            {
                Console.WriteLine("\n" + currentRoom.GetCharacters().Find(character => character.Name.ToLower().Equals(command.ToLower().Substring(8))).Description + "\n");
                return;
            }
            if (currentRoom.GetInventory().Exists(item => item.Name.ToLower() == command.ToLower().Substring(8)))
            {
                Console.WriteLine("\n" + currentRoom.GetInventory().Find(item => item.Name.ToLower().Equals(command.ToLower().Substring(8))).Description + "\n");
                return;
            }
            if (currentCharacter.GetInventory().Exists(item => item.Name.ToLower() == command.ToLower().Substring(8)))
            {
                Console.WriteLine("\n" + currentCharacter.GetInventory().Find(item => item.Name.ToLower().Equals(command.ToLower().Substring(8))).Description + "\n");
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

            if (currentCharacter.GetInventory().Exists(item => item.Name == command.ToLower().Substring(4)))
            {

                if (currentRoom.GetTitle() == "Bedroom" && command.ToLower().Substring(4) == "small key")
                {
                    Door studydoor_east = currentRoom.GetDoors().Find(door => door.GetDirection().Equals(Door.Directions.East));
                    studydoor_east.SetLocked(false);
                    Console.WriteLine("\nyou unlocked the Door!\n");
                    return;
                }

                 if (command.ToLower().Substring(4) == "painkiller")
                {
                    Healing(currentCharacter,"painkiller");
                    return;          
                }

                if (currentRoom.GetTitle() == "Living Room" && command.ToLower().Substring(4) == "big key")
                {
                    Door atelierdoor = currentRoom.GetDoors().Find(door => door.GetDirection().Equals(Door.Directions.West));
                    atelierdoor.SetLocked(false);
                    Console.WriteLine("\nyou unlocked the Door!\n");

                    return;
                }

                Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                
                string secondItem = Console.ReadLine();

                if (currentRoom.GetInventory().Exists(item => item.Name == secondItem.ToLower()))
                {
                    if (secondItem == "podest" && command.Substring(4) == "amethyst")
                    {
                        Item  escapeRoute= new Item("passage", false, "A long and dark Passage. In the distance you can see a little light glowing.");
                        
                        currentRoom.AddItem(escapeRoute);
                        currentRoom.RemoveItem(currentRoom.GetInventory().Find(item=>item.Name =="Podest"));     
                        currentRoom.RemoveItem(currentCharacter.GetInventory().Find(item=>item.Name =="amethyst"));
                        Console.WriteLine("\nYou placed the amethyst on the Podest. It sinks slowly in to the ground and reaveals a dark Passageway.\n");
                        return;
                    }


                    if (secondItem == "shelf" && command.Substring(4) == "weights")
                    {
                        Console.WriteLine("\n\nYou throw the weights on top of the shelf and it comes crushing down, revealing some painkillers\n\n");
                        Item health = new Item("painkiller", true, "Painkiller, which you can get nearly everywhere. Still they do their job.",30);
                        currentRoom.AddItem(health);

                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nCannot do the thing.\n");
                    return;
                }
            }
            if (currentRoom.GetInventory().Exists(item => item.Name == command.ToLower().Substring(4)))
            {
                switch (command.ToLower().Substring(4))
                {
                    case ("light switch"):

                        Console.WriteLine("\n\nYou turned the light on.\n\n");
                        currentRoom.SetDescription("You are standing in the Entry Hall.\nIt's a room with a high ceiling and the floor was made from marble.\nThere are a wardrobe an a hatstand in the corner of the room\nand you notice some shoe prints leading deeper into the mansion.");
                        Item umbrella = new Item("umbrella", true, "An classic umbrella with a sharp end.", 10);
                        currentRoom.AddItem(umbrella);
                        Item light = currentRoom.GetInventory().Find(item => item.Name.Contains("light"));
                        currentRoom.RemoveItem(light);

                    return;

                    case ("clock"):

                        Console.WriteLine("\n\nYou opened the clock and found some weights.\n\n");
                        Item weights = new Item("weights", true, "These weights are normally used to adjust the clock.\nI wonder if they could be used for other things?", 10);
                        currentRoom.AddItem(weights);
                        Item clock = currentRoom.GetInventory().Find(item => item.Name.Contains("clock"));
                        currentRoom.RemoveItem(clock);

                    return;

                    case ("bathtub"):

                        Console.WriteLine("\n\nSlowy the water begins sinking and you can see a key on the ground\n\n");
                        Item small_key = new Item("small key", true, "A small key, for one of the closed rooms in the Mansion.\nBut which one?");
                        currentRoom.AddItem(small_key);
                        Item bathtub = currentRoom.GetInventory().Find(item => item.Name.Contains("bathtub"));
                        currentRoom.RemoveItem(bathtub);


                    return;

                    case ("passage"):

                        Console.WriteLine("\n\nAt the End of the Passage you get in to the open.\nYou squeeze your eyes and look around.\nBehind you is a large forest and if you look close,\nyou can see the Mansion in the Distance.\nYou begin to walk away from the Mansion,\nnot turning back once. You live and that is all that matters.\n\n");
                        Game.GameOver = true;


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
            if (currentRoom.GetCharacters().Exists(character => character.Name.ToLower().Equals(command.ToLower().Substring(7))))
            {

                Console.WriteLine("\nattack " + command.Substring(7) + " with?\n");

                string weapon = Console.ReadLine();

                if (currentCharacter.GetInventory().Exists(item => item.Name == weapon))
                {
                    currentEnemy = currentRoom.GetCharacters().Find(character => character.Name.ToLower().Equals(command.ToLower().Substring(7)));

                    Item currentWeapon = currentCharacter.GetInventory().Find(item => item.Name.Contains(weapon));

                    int attackmodifier = currentWeapon.WeaponBonus;

                    if (currentCharacter.CharHpCurrent > 0 && currentEnemy.CharHpCurrent > 0)
                    {

                        int damage = currentCharacter.AttackValue + attackmodifier;

                        int hp_enemy = currentEnemy.CharHpCurrent - damage;

                        currentEnemy.CharHpCurrent = hp_enemy;

                        int myhp = currentCharacter.CharHpCurrent - currentEnemy.AttackValue;

                        currentCharacter.CharHpCurrent = myhp;


                        switch (currentEnemy.Name)
                        {
                            case ("Dog"):

                                Console.WriteLine("\nYou hit {0} for {1} Damage!\n", currentEnemy.Name, damage);
                                Console.WriteLine("Woof. Grr!!");
                                Console.WriteLine("\n{0} hit you for {1} Damage!\n", currentEnemy.Name, currentEnemy.AttackValue);

                            return;

                            case ("Zombie"):

                                Console.WriteLine("\nYou hit {0} for {1} Damage!\n", currentEnemy.Name, damage);
                                Console.WriteLine("Urrrga. Graa!!");
                                Console.WriteLine("\n{0} hit you for {1} Damage!\n", currentEnemy.Name, currentEnemy.AttackValue);

                            return;

                            case ("Sean Michals"):

                                Console.WriteLine("\nYou hit {0} for {1} Damage!\n",currentEnemy.Name, damage);
                                Console.WriteLine("What are you doing you bastard. Here come and get it!");
                                Console.WriteLine("\n{0} hit you for {1} Damage!\n", currentEnemy.Name, currentEnemy.AttackValue);

                            return;

                            case ("Sarah Hardy"):

                                Console.WriteLine("\nYou hit {0} for {1} Damage!\n", currentEnemy.Name, damage);
                                Console.WriteLine("Ouch that hurt! That should bring you back to your senses!");
                                Console.WriteLine("\n{0} hit you for {1} Damage!\n", currentEnemy.Name, currentEnemy.AttackValue);

                            return;
                        }
                    }
                    if (currentCharacter.CharHpCurrent > 0 && currentEnemy.CharHpCurrent <= 0)
                    {
                        switch (currentEnemy.Name)
                        {
                            case("Dog"):

                            Console.WriteLine("\nFeeep. Wimper.\n");

                            break;

                            case("Zombie"):
                            
                            Console.WriteLine("\nGuaahh. Uurgs.\n");

                            break;

                            case("Sean Michals"):

                            Console.WriteLine("\nYou son of a....i hope you'll rot in hell!\n");

                            Drop("drop pistol", currentRoom,currentEnemy);

                            break;

                            case("Sarah Hardy"):

                            Console.WriteLine("\nWhy must it end here? What evil has befallen you?\n");

                            break;
                        }
                        currentRoom.RemoveCharacter(currentEnemy);
                        Console.WriteLine("\nEnemy defeated!\n");
                        return;
                    }
                    else
                    {
                        Game.GameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have no weapon to fight with!\n");
                    return;
                }

            }
            else
            {
                Console.WriteLine("\nThere is nobody to attack.\n");
                return;
            }
        }

        // Heal yourself
        private static void Healing(Character currentCharacter, string Item)
        {
            Item healitem = currentCharacter.GetInventory().Find(item => item.Name == Item);

            int healing = currentCharacter.CharHpCurrent + healitem.WeaponBonus;
            
            currentCharacter.CharHpCurrent = healing;

            currentCharacter.RemoveItem(currentCharacter.GetInventory().Find(item=>item.Name == Item));

            Console.WriteLine("\nYou healed yourself for " + healitem.WeaponBonus+"\n");
        }

        //show Character status
        public static void ShowStatus(Character character)
        {
            Console.WriteLine("\nYour Status: ");
            Console.WriteLine("Name: " + character.Name+"\n");
            Console.WriteLine("Health: {0}/{1}", character.CharHpCurrent, character.CharHpFull+"\n");
            character.ShowInventory();
        }

        
    }

    
}