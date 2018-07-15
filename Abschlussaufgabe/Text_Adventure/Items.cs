using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Item
    {

        public string name;
        private bool useable;
        private bool needsItem;
        private string description;
        private int attack_bonus;

        public Item(string _name, bool canUse, bool neededItem, string _description)
        {
            name = _name;
            useable = canUse;
            needsItem = neededItem;
            description = _description;
        }

        public Item(string _name, bool canUse, string _description, int attack_Bonus)
        {
            name = _name;
            useable = canUse;
            description = _description;
            attack_bonus = attack_Bonus;
        }

        public Item(string _name, bool canUse, string _description)
        {
            name = _name;
            useable = canUse;
            description = _description;
        }

        public string Name
        {
            get { return name; }
        }

        public bool Useable
        {
            get { return useable; }
        }

        public bool KeyItem
        {
            get { return needsItem; }
        }

        public string Description
        {
            get { return description; }
        }
    }
}