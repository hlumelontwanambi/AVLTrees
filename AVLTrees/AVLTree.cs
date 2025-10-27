using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees
{
    class AVLTree
    {
        public Node root;

        //Helper function to get the height of a node
        private int GetHeight(Node node)
        {
            return node?.Height ?? 0;
        }

        //Helper function to get the balance factor of a node
        private int GetBalance(Node node)
        {
            if (node == null)
                return 0;
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        //A utility function to right rotate subtree rooted with y
        private Node RightRotate(Node y)
        {
            Console.WriteLine($"--- Performing Right Rotation on Node. {y.Key} ---");
            Node x = y.Left;
            Node T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = x;

            //Update heights
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            //Return new root
            return x;
        }

        //A utility function to left rotate subtree rooted with x
        private Node LeftRotate(Node x)
        {
            Console.WriteLine($"---- Performing Left Rotatin on Node {x.Key} ---");
            Node y = x.Left;
            Node T2 = y.Right;

            // Perform rotation
            y.Right = x;
            x.Left = y;

            //Update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            //Return new root
            return y;
        }
    }
}