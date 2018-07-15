using System;
using System.Collections.Generic;
using System.Collections;


namespace Text_Adventure
{
    class Room
    {
        private string roomTitle;
        private string roomDescription;
        private List<Door> doors;
        private List<Item> inventory;
		private List<Character> characters;

        public Room()
        {
            // Blank out the title and description at start
            roomTitle = "";
            roomDescription = "";
            doors = new List<Door>();
            inventory = new List<Item>();
			characters = new List<Character>();
        }

        public Room(string title)
        {
            roomTitle = title;
            roomDescription = "";
            doors = new List<Door>();
            inventory = new List<Item>();
			characters = new List<Character>();
        }

        public Room(string title, string description)
        {
            roomTitle = title;
            roomDescription = description;
            doors = new List<Door>();
            inventory = new List<Item>();
			characters = new List<Character>();
        }

        public override string ToString()
        {
            return roomTitle;
        }

        public void addDoor(Door door)
        {
            doors.Add(door);
        }

        public void removeDoor(Door door)
        {
            if (doors.Contains(door))
            {
                doors.Remove(door);
            }
        }

        public List<Door> getDoors()
        {
            return new List<Door>(doors);
        }

        public List<Item> getInventory()
        {
            return new List<Item>(inventory);
        }

        public void addItem(Item itemToAdd)
        {
            inventory.Add(itemToAdd);
        }

        public void removeItem(Item itemToRemove)
        {
            if (inventory.Contains(itemToRemove))
            {
                inventory.Remove(itemToRemove);
            }
        }

		public List<Character> getCharacters()
        {
            return new List<Character>(characters);
        }

        public void addCharacter(Character characterToAdd)
        {
            characters.Add(characterToAdd);
        }

        public void removeCharacter(Character characterToRemove)
        {
            if (characters.Contains(characterToRemove))
            {
                characters.Remove(characterToRemove);
            }
        }

        public Item takeItem(string name)
        {
            foreach (Item _item in inventory)
            {
                if (_item.Name.ToLower() == name)
                {
                    Item temp = _item;
                    inventory.Remove(temp);
                    return temp;
                }
            }

            return null;
        }

        public string getTitle()
        {
            return roomTitle;
        }

        public void setTitle(string title)
        {
            roomTitle = title;
        }

        public string getDescription()
        {
            return roomDescription;
        }

        public void setDescription(string description)
        {
            roomDescription = description;
        }
    }
}