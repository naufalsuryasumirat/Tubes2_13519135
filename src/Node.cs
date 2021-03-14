using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    // Define classes here

	public class Node
    {
        private string Name;
		private bool Visited;
        private List<Node> CNodes; // Array of connected nodes
        private int Count;
        public Node() // Default Constructor
        {
            this.Name = null;
            this.CNodes = null;
            this.Visited = false;
        }
        public Node(string Name) // User-defined Constructor
        {
            this.Name = Name;
            this.CNodes = new List<Node>();
            this.Visited = false;
            this.Count = 0;
        }
        public string getName() // Get string Name
        {
            return this.Name;
        }
        public bool getStatus() // Get bool Visited
        {
            return this.Visited;
        }
        public void setVisited() // Set bool Visited = true
        {
            this.Visited = true;
        }
        public void setUnvisited() // Set bool Visited = false
        {
            this.Visited = false;
        }
        public void addCount() // Add int Count by 1
        {
            this.Count++;
        }
        public void subtractCount() // Subtract int Count by 1
        {
            this.Count--;
        }
        public int getCount() // Get Count
        {
            return this.Count;
        }
        public void addEdge(Node node) // Add connection / edge
        {
            if (!this.IsConnected(node.getName()) && getName() != )
            {
                this.CNodes.Add(node);
                node.CNodes.Add(this);
                addCount();
                node.addCount();
                this.SortConnected();
                node.SortConnected();
            }
        }
        public void removeNode(string name)
        {
            this.CNodes.RemoveAt(findNode(name));
            subtractCount();
        }
        public void removeConnection(string name)
        {

            (this.CNodes[findNode(name)]).removeNode(getName());
            removeNode(name);
        }
        public int findNode (string name)
        {
            for (int i = 0; i < this.CNodes.Count; i++)
            {
                if (this.CNodes[i].getName() == name)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool IsConnected(string name)
        {
            foreach (Node node in this.CNodes)
            {
                if (node.getName() == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void SortConnected()
        {
            this.CNodes.Sort((x, y) => x.getName().CompareTo(y.getName()));
        }
        public void print()
        {
            Console.WriteLine("Name     : " + this.Name);
            Console.WriteLine("Count    : " + this.Count);
            Console.Write("Connected: ");
            for (int i = 0; i < this.CNodes.Count; i++)
            {
                if (i != this.CNodes.Count - 1)
                {
                    Console.Write(this.CNodes[i].getName() + " ,");
                }
                else
                {
                    Console.Write(this.CNodes[i].getName() + ".");
                }
            }
            Console.WriteLine();
            Console.Write("Status   : ");
            if (this.Visited)
            {
                Console.WriteLine("Visited");
            }
            else
            {
                Console.WriteLine("Unvisited");
            }
            Console.WriteLine(); //////////
        }
    }

	class Program
    {
        static void Main(string[] args) // Main
        {
            Node testNode = new Node("testNode");
            Node testNode2 = new Node("testNode2");
            Node testNode3 = new Node("testNode3");
            Node testNode4 = new Node("testNode4");
            testNode.print();
            testNode2.print();
            testNode3.print();

            testNode.addEdge(testNode2); // indeks 0
            testNode.addEdge(testNode3); // indeks 1

            testNode.print();

            // testNode.CNodes[0].setVisited();
            // testNode.CNodes[1].setVisited();

            testNode2.print();
            testNode3.print();

            testNode.removeConnection("testNode2");
            testNode.print();
            testNode2.print();

            testNode2.addEdge(testNode);
            testNode2.addEdge(testNode); // works
            testNode2.print();

            testNode4.addEdge(testNode3);
            testNode4.addEdge(testNode2);
            testNode4.addEdge(testNode);

            testNode4.print();

            testNode4.SortConnected();
            testNode4.print();
            

            Console.ReadLine();
        }
    }
}