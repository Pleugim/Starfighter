using System;
using System.Collections.Generic;
using System.Text;

namespace Starfighter.Core.Starfield
{
    public class StarNode
    {
        public const int Directions = 8;

        public int Id { get; set; }
        public List<StarNode> Adjacents = new List<StarNode>();

        public StarNode GetAdjacent(int position)
        {
            position = position % Directions;

            if (position < this.Adjacents.Count)
            {
                return this.Adjacents[position];
            }

            return null;
        }

    }
}
