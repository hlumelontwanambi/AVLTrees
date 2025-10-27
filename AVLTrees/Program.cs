namespace AVLTrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();

            Console.WriteLine("Building an AVL Tree by inserting nodes in a skewed order (10, 20, 30, etc.)");

            tree.Insert(10);
            tree.InOrderTraversal();
            tree.Insert(20);
            tree.InOrderTraversal();

            //The inserton will cause an imbalance and trigger a rotation!
            tree.Insert(30);
            tree.InOrderTraversal();
            tree.Insert(40);
            tree.InOrderTraversal();

            //This insertion will also trigger a rotation.
            tree.Insert(50);
            tree.InOrderTraversal();
            tree.Insert(25);
            tree.InOrderTraversal();
        }
    }
}
