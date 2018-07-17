using System;
using System.Collections.Generic;

namespace Text_Adventure
{



    class Character
    {
        //Int
        public int Char_HP_Current = 100;
        public int Char_HP_Full = 100;
        public int Attack_value = 1;
        private List<Item> _inventory;
        private string _name;
        private bool _fightable;
        private bool _needsItem;
        private string _description;


        public Character()
        {
            // Blank out the title and description at start
            _name = "";
            _fightable = true;
            _inventory = new List<Item>();


        }

        public Character(string name, bool canFight, bool neededItem, string description, int hp_current, int hp_full, int attack)
        {
            _name = name;
            _fightable = canFight;
            _needsItem = neededItem;
            _description = description;
            Char_HP_Current = hp_current;
            Char_HP_Full = hp_full;
            Attack_value = attack;
            _inventory = new List<Item>();
        }

        public string Name
        {
            get { return _name; }
        }


        public string Description
        {
            get { return _description; }
        }

         public void SetName(string Name)
        {
            _name = Name;
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

        public void ShowInventory()
        {
            if (_inventory.Count > 0)
            {
                Console.WriteLine("\nA quick look in your bag reveals the following:\n");

                foreach (Item item in _inventory)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("\nYour bag is empty.\n");
            }
        }

    }


}
