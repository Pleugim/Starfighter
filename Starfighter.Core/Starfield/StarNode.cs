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
            for (int i = 0; i < Directions; i++)
            {
                this.Adjacents.Add(null);
            }
        }

        public StarNode GetAdjacent(int position)
        {
            position = NormalizePosition(position);

            if (position < this.Adjacents.Count)
            {
                return this.Adjacents[position];
            }

            return null;
        }

        private static int NormalizePosition(int positionToNormalize)
        {
            return Math.Abs(positionToNormalize % Directions);
        }

        public static int GetOppositePosition(int position)
        {
            position = NormalizePosition(position);
            return NormalizePosition(position - Directions / 2);
        }

        public bool Attach(StarNode nodeToAttach, int positionToAttachTo)
        {
            positionToAttachTo = NormalizePosition(positionToAttachTo);

            if (this.GetAdjacent(positionToAttachTo) == null &&
                nodeToAttach.GetAdjacent(GetOppositePosition(positionToAttachTo)) == null)
            {
                this.Adjacents[positionToAttachTo] = nodeToAttach;
                nodeToAttach.Adjacents[GetOppositePosition(positionToAttachTo)] = this;
                return true;
            }

            return false;
        }

    }
}
