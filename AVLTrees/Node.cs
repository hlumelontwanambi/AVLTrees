using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees
{
    internal class Node
    {
        public int Key;
        public Node Left;
        public Node Right;
        public int Height;
        public Node(int key)
        {
            Key = key;            
            Height = 1; // A new node is initially added at height 1
        }
    }
}