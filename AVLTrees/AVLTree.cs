using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees
{
    class AVLTree
    {
        private Node root;

        //Helper function to get the height of a node
        private int GetHeight(Node node)
        {
            return node?.Height ?? 0;
        }

        //Helper function to get the balance factor of a node
        private int GetBalance(Node node)
        {
            if (node == null) return 0;
            return GetHeight(node.Left) - GetHeight(node.Right);
        }
        //A utility function to right rotate subtree rooted with y
        private Node RightRotate(Node y)
        {
            Console.WriteLine($"--- Performing Right Rotation on Node {y.Key} ---");
            Node x = y.Left;
            Node T2 = x.Right;
            //Peform rotation
            x.Right = y;
            y.Left = T2;

            //Update heights
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            //Return new root
            return x;
        }

        //A utility function to left rotate subtree rooted with x
        private Node LeftRotate(Node x)
        {
            Console.WriteLine($"--- Performing Left Rotation on Node {x.Key} ---");
            Node y = x.Right;
            Node T2 = y.Left;

            //Perform rotation
            y.Left = x;
            x.Right = T2;

            //Update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            //Return new root
            return y;
        }
        public void Insert(int key)
        {
            Console.WriteLine($"\nInserting {key}...");
            root = Insert(root, key);
        }

        public Node Insert(Node node, int key)
        {
            //1. Perform standard BST insertion
            if (node == null) return new Node(key);

            if (key < node.Key) node.Left = Insert(node.Left, key);
            else if (key > node.Key) node.Right = Insert(node.Right, key);
            //Duplicate keys not allowed
            else return node;

            //2. Update height of this ancestor node
            node.Height = 1 + Math.Max(GetHeight(node.Left),
                GetHeight(node.Right));

            // 3. Get the balance factor of this ancestor node
            int balance = GetBalance(node);

            //4. If th enode becomes unbalanced, then there are 4 cases
            //Left Left Case
            if (balance > 1 && key < node.Left.Key) return RightRotate(node);

            //Right Right Case
            if (balance < -1 && key > node.Right.Key) return LeftRotate(node);

            //Left Right Case
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            //Right Left Case
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            //return the (unchanged) node pointer
            return node;
        }

        //Helper function to print the tree in-order (sorted)
        public void InOrderTraversal()
        {
            Console.WriteLine("\nIn-Order Traversal (sorted view)");
            InOrderTraversal(root);
            Console.WriteLine();
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Key + " ");
                InOrderTraversal(node.Right);
            }
        }
    }
}