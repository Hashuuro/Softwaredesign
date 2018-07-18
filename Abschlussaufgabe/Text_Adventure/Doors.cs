using System;
using System.Collections.Generic;


namespace Text_Adventure
{
    class Door
    {
        public enum Directions
        {
            Undefined, North, South, East, West
        };

        public static string[] ShortDirections = { "Null", "N", "S", "E", "W" };

        private Room _leadsTo;
        private Directions _Direction;

        private bool _locked = true;


        public Door(Directions _direction, Room newLeadsTo, bool keyhole)
        {
            _Direction = _direction;
            _leadsTo = newLeadsTo;
            _locked = keyhole;

        }

        public override string ToString()
        {
            return _Direction.ToString();
        }

        public void SetDirection(Directions _direction)
        {
            _Direction = _direction;
        }

        public Directions GetDirection()
        {
            return _Direction;
        }

        public string GetShortDirection()
        {
            return ShortDirections[(int)_Direction].ToLower();
        }

        public void SetLeadsTo(Room leadsTo)
        {
            _leadsTo = leadsTo;
        }

        public Room GetLeadsTo()
        {
            return _leadsTo;
        }
        
        public void SetLocked(bool locked)
        {
            _locked = locked;
        }

        public bool GetLocked()
        {
            return _locked;
}
		
    }
}