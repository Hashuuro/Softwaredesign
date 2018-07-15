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

        public static string[] shortDirections = { "Null", "N", "S", "E", "W" };

        private Room leadsTo;
        private Directions direction;

		private bool locked = true;
		private bool hidden = true;
        public Door()
        {
            direction = Directions.Undefined;
            leadsTo = null;
        }

        public Door(Directions _direction, Room newLeadsTo)
        {
            direction = _direction;
            leadsTo = newLeadsTo;
        }

		public Door(Directions _direction, Room newLeadsTo, bool keyhole, bool _hidden)
        {
            direction = _direction;
            leadsTo = newLeadsTo;
			locked = keyhole;
			hidden = _hidden;
        }

        public override string ToString()
        {
            return direction.ToString();
        }

        public void setDirection(Directions _direction)
        {
            direction = _direction;
        }

        public Directions getDirection()
        {
            return direction;
        }

        public string getShortDirection()
        {
            return shortDirections[(int)direction].ToLower();
        }

        public void setLeadsTo(Room _leadsTo)
        {
            leadsTo = _leadsTo;
        }

        public Room getLeadsTo()
        {
            return leadsTo;
        }

		public bool  getLock()
        {
            return locked;
        }

		public bool  gethidden()
        {
            return hidden;
        }
    }
}