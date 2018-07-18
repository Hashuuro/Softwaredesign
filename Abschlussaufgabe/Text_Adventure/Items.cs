using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Item
    {

        private string _name;
        private bool _useable;
        private bool _needsItem;
        private string _description;
        private int _attackBonus;

        public Item(string name, bool canUse, bool neededItem, string description)
        {
            _name = name;
            _useable = canUse;
            _needsItem = neededItem;
            _description = description;
        }
        public Item(string name, bool canUse, string description, int attack_Bonus)
        {
            _name = name;
            _useable = canUse;
            _description = description;
            _attackBonus = attack_Bonus;
        }


        public Item(string name, bool canUse, string description)
        {
            _name = name;
            _useable = canUse;
            _description = description;
        }

        public string Name
        {
            get { return _name; }
        }

        public bool Useable
        {
            get { return _useable; }
        }

        public bool KeyItem
        {
            get { return _needsItem; }
        }

        public int WeaponBonus
        {
            get { return _attackBonus; }
        }
        public string Description
        {
            get { return _description; }
        }
    }
}