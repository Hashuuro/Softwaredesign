using System;
using System.Collections.Generic;
using System.Collections;


namespace Text_Adventure
{
    class Room
    {
        private string _roomTitle;
        private string _roomDescription;
        private List<Door> _doors;
        private List<Item> _inventory;
        private List<Character> _characters;

        public Room()
        {
            // Blank out the title and description at start
            _roomTitle = "";
            _roomDescription = "";
            _doors = new List<Door>();
            _inventory = new List<Item>();
            _characters = new List<Character>();
        }

        public Room(string title)
        {
            _roomTitle = title;
            _roomDescription = "";
            _doors = new List<Door>();
            _inventory = new List<Item>();
            _characters = new List<Character>();
        }

        public Room(string title, string description)
        {
            _roomTitle = title;
            _roomDescription = description;
            _doors = new List<Door>();
            _inventory = new List<Item>();
            _characters = new List<Character>();
        }

        public override string ToString()
        {
            return _roomTitle;
        }

        public void AddDoor(Door door)
        {
            _doors.Add(door);
        }

        public void RemoveDoor(Door door)
        {
            if (_doors.Contains(door))
            {
                _doors.Remove(door);
            }
        }

        public List<Door> GetDoors()
        {
            return new List<Door>(_doors);
        }

        public List<Item> GetInventory()
        {
            return new List<Item>(_inventory);
        }


        public void AddItem(Item itemToAdd)
        {
            _inventory.Add(itemToAdd);
        }

        public void RemoveItem(Item itemToRemove)
        {
            if (_inventory.Contains(itemToRemove))
            {
                _inventory.Remove(itemToRemove);
            }
        }

        public List<Character> GetCharacters()
        {
            return new List<Character>(_characters);
        }

        public void AddCharacter(Character characterToAdd)
        {
            _characters.Add(characterToAdd);
        }

        public void RemoveCharacter(Character characterToRemove)
        {
            if (_characters.Contains(characterToRemove))
            {
                _characters.Remove(characterToRemove);
            }
        }

        public Item TakeItem(string name)
        {
            foreach (Item _item in _inventory)
            {
                if (_item.Name.ToLower() == name)
                {
                    Item temp = _item;
                    _inventory.Remove(temp);
                    return temp;
                }
            }

            return null;
        }

        public string GetTitle()
        {
            return _roomTitle;
        }

        public void SetTitle(string title)
        {
            _roomTitle = title;
        }

        public string GetDescription()
        {
            return _roomDescription;
        }

        public void SetDescription(string description)
        {
            _roomDescription = description;
        }
    }
}