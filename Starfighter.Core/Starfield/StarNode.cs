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

        public StarNode()
        {
            for (int i = 0; i < 8; i++)
            {
                Adjacents.Add(null);
            }
        }

        public StarNode GetAdjacent(int position)
        {
            position = position % Directions;

            if (position < this.Adjacents.Count)
            {
                return this.Adjacents[position];
            }

            return null;
        }

        public List<int> GetDirectionsFilled()
        {
            var result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                if (this.Adjacents[i] != null)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        public List<int> GetDirectionsEmpty()
        {
            var result = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                if (this.Adjacents[i] == null)
                {
                    result.Add(i);
                }
            }

            return result;
        }

    }
}
