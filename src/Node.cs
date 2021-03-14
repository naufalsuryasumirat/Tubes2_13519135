using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    // Define classes here
    // nanti yang ditandain TEST diapus
	public class Node
    {
        private Node fromNode; // node / string?
        private string Name;
		private bool Visited;
        private List<Node> CNodes; // Array of connected nodes
        private int Count;
        public Node() // Default Constructor
        {
            this.fromNode = null;
            this.Name = null;
            this.CNodes = null;
            this.Visited = false;
        }
        public Node(string Name) // User-defined Constructor
        {
            this.fromNode = null;
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
        public Node getFromNode()
        {
            return this.fromNode;
        }
        public void setFromNode(Node node)
        {
            this.fromNode = node;
        }
        public void setFromNodeNull()
        {
            this.fromNode = null;
        }
        public void addEdge(Node node) // Add connection / edge
        {
            if (!this.IsConnected(node.getName()) && getName() != node.getName())
            {
                this.CNodes.Add(node);
                node.CNodes.Add(this);
                addCount();
                node.addCount();
                this.SortConnected();
                node.SortConnected();
            }
        }
        public void removeNode(string name) // Remove a node from CNode
        {
            this.CNodes.RemoveAt(findNode(name));
            subtractCount();
        }
        public void removeConnection(string name) // Remove a connection between nodes
        {
            (this.CNodes[findNode(name)]).removeNode(getName());
            removeNode(name);
        }
        public int findNode (string name) // Returns the index of a node in CNodes (-1) if not found
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
        public List<Node> getCNodes()
        {
            return this.CNodes;
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
                    Console.Write(this.CNodes[i].getName() + ", ");
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
            Console.Write("From     : ");
            if (this.fromNode == null)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(this.fromNode.getName());
            }
            Console.WriteLine(); // TEST
        }
    }
    class Graph
    {
        private List<Node> NodeList;
        public Graph()
        {
            this.NodeList = new List<Node>();
        }
        public void addNode(Node node)
        {
            NodeList.Add(node);
        }
        public Node findNode(string name)
        {
            foreach (Node node in this.NodeList)
            {
                if (node.getName() == name)
                {
                    return node;
                }
            }
            return null;
        }
        public void addConnection(string nodeOne, string nodeTwo)
        {
            if (findNode(nodeOne) == null)
            {
                Node newNode = new Node(nodeOne);
                addNode(newNode);
            }
            if (findNode(nodeTwo) == null)
            {
                Node newNode = new Node(nodeTwo);
                addNode(newNode);
            }
            findNode(nodeOne).addEdge(findNode(nodeTwo));
        }
        public void print()
        {
            foreach (Node node in NodeList)
            {
                node.print();
            }
        }
        public List<string> BFS(string from, string to)
        {
            List<Node> list = new List<Node>();
            if (findNode(from) == null || findNode(to) == null || from == to)
            {
                return null;
            } 
            Console.WriteLine("Visiting " + findNode(from).getName()); // TEST
            findNode(from).setVisited();
            list.Add(findNode(from));
            while (list.Count > 0)
            {
                foreach (Node node in list[0].getCNodes())
                {
                    if (!node.getStatus() && node.getName() != from && node.getName() != to)
                    { 
                        Console.WriteLine("Visiting " + node.getName()); // TEST
                        node.setFromNode(list[0]);
                        node.setVisited();
                        list.Add(node);
                    }
                    else if (node.getName() == to)
                    {
                        List<string> listStr = new List<string>();
                        Node destination = node;
                        destination.setFromNode(list[0]);
                        destination.setVisited();
                        list.Clear();
                        // print(); TEST
                        while (destination.getName() != from)
                        {
                            listStr.Add(destination.getName());
                            destination = destination.getFromNode();
                        }
                        listStr.Add(destination.getName());
                        setAllFNNull();
                        setAllUnvisited();
                        listStr.Reverse();
                        return listStr;
                    }
                }
                list.RemoveAt(0);
            }
            setAllFNNull();
            setAllUnvisited();
            return null; // Mungkin kasus gaketemu destination?? TEST
        }
        /*
        private void DFS2(Node node, string from)
        {
            Console.WriteLine("Visiting " + node.getName());
            node.setVisited();
            foreach (var dfsnode in node.getCNodes())
            {
                if (!dfsnode.getStatus() && dfsnode.getName() != from)
                {
                    dfsnode.setFromNode(node);
                    dfsnode.setVisited();
                    DFS2(dfsnode, from);
                }
            }
        }
        */
        public void DFSrec(Node node, string from)
        {
            Console.WriteLine("Visiting " + node.getName()); // TEST
            node.setVisited();
            foreach (var dfsnode in node.getCNodes())
            {
                if (!dfsnode.getStatus() && dfsnode.getName() != from)
                {
                    dfsnode.setFromNode(node);
                    dfsnode.setVisited();
                    DFSrec(dfsnode, from);
                }
            }
        }
        public List<string> DFS(string from, string to)
        {
            if (findNode(from) == null || findNode(to) == null || from == to)
            {
                return null;
                // return null;
            }
            DFSrec(findNode(from), from);
            if (findNode(to).getStatus()) // if Visited
            {
                List<string> list = new List<string>();
                Node destination = findNode(to);
                while (destination.getName() != from)
                {
                    list.Add(destination.getName());
                    destination = destination.getFromNode();
                }
                list.Add(destination.getName());
                setAllFNNull();
                setAllUnvisited();
                list.Reverse();
                return list;
            }
            else
            {
                setAllFNNull();
                setAllUnvisited();
                return null;
            }
        }
        public List<Tuple<string, int, List<string>>> getMutuals(string name)
        {
            List<string> listNames = new List<string>();
            List<int> listMutualCount = new List<int>();
            List<List<string>> listConnectedNodes = new List<List<string>>();
            if (findNode(name) == null)
            {
                return null;
            }
            foreach (Node node in findNode(name).getCNodes())
            {
                foreach (Node othernode in node.getCNodes())
                {
                    if (othernode.getName() != name && othernode.findNode(name) == -1)
                    {
                        int search = listNames.FindIndex(x => x == othernode.getName());
                        if (search == -1)
                        { 
                            listNames.Add(othernode.getName());
                            listMutualCount.Add(1);
                            var listCNodes = new List<string>();
                            listCNodes.Add(node.getName());
                            listConnectedNodes.Add(listCNodes);
                        }
                        else
                        {
                            listMutualCount[search] = listMutualCount[search] + 1;
                            listConnectedNodes[search].Add(node.getName());
                        }
                    }
                }
            }
            List<Tuple<string, int, List<string>>> list = new List<Tuple<string, int, List<string>>>();
            for (int i = 0; i < listNames.Count; i++)
            {
                list.Add(Tuple.Create(listNames[i], listMutualCount[i], listConnectedNodes[i]));
            }
            list.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            return list;
        }
        public void removeEdge(string from, string to)
        {
            findNode(from).removeConnection(to);
        }
        public void setAllUnvisited()
        {
            foreach (Node node in NodeList)
            {
                node.setUnvisited();
            }
        }
        public void setAllFNNull()
        {
            foreach (Node node in NodeList)
            {
                node.setFromNodeNull();
            }
        }
    }

	class Program
    {
        static void Main(string[] args) // Main
        {
            void PrintAll(List<string> lists)
            {
                for (int i = 0; i < lists.Count; i++)
                {
                    if (i != lists.Count - 1)
                    {
                        Console.Write(lists[i] + "-->");
                    }
                    else
                    {
                        Console.WriteLine(lists[i] + ".");
                    }
                }
            }
            void PrintMutuals(List<Tuple<string, int, List<string>>> lists)
            {
                foreach (var tuple in lists) // Mutual friends
                {
                    Console.WriteLine("Node : " + tuple.Item1);
                    Console.WriteLine("Count: " + tuple.Item2);
                    Console.Write("Nodes: ");
                    for (int i = 0; i < tuple.Item3.Count; i++)
                    {
                        if (i != tuple.Item3.Count - 1)
                        {
                            Console.Write(tuple.Item3[i] + ", ");
                        }
                        else
                        {
                            Console.WriteLine(tuple.Item3[i] + ".");
                        }
                    }
                    Console.WriteLine(":-----:");
                }
            }

            /*
            // First
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
            testNode4.addEdge(testNode4);

            testNode4.print();

            testNode4.SortConnected();
            testNode4.print();

            */

            /*
            // Second
            Graph graph = new Graph();
            Node gnode1 = new Node("node1");
            Node gnode2 = new Node("node2");
            Node gnode3 = new Node("node3");
            Node gnode4 = new Node("node4");
            graph.addNode(gnode1);
            graph.addNode(gnode2);
            graph.addNode(gnode3);
            graph.addNode(gnode4);
            graph.findNode("node1").addEdge(graph.findNode("node2"));
            graph.findNode("node1").print();
            graph.findNode("node2").print();

            if (graph.findNode("nodess") == null)
            {
                Console.WriteLine("Node nodess not found");
            }
            */

            /*
            // Third
            Graph graphs = new Graph();
            graphs.addConnection("node1", "node2");
            graphs.addConnection("node2", "node3");
            graphs.addConnection("node4", "node5");
            // graphs.findNode("node4").getCNodes()[0].setVisited();
            graphs.print();
            */

            Graph graphss = new Graph();
            graphss.addConnection("node1", "node2");
            graphss.addConnection("node1", "node3");
            graphss.addConnection("node3", "node4");
            graphss.addConnection("node2", "node4");
            graphss.addConnection("node1", "node5");
            graphss.addConnection("node1", "node6");
            graphss.addConnection("node5", "node7");
            graphss.addConnection("node6", "node7");
            graphss.addConnection("node1", "node8");
            graphss.addConnection("node8", "node7");
            
            PrintMutuals(graphss.getMutuals("node1")); // mutual friends

            var list = graphss.BFS("node1", "node7");
            PrintAll(list);

            // graphss.print(); TEST
            
            Graph secondGraph = new Graph();
            secondGraph.addConnection("a", "b");
            secondGraph.addConnection("a", "c");
            secondGraph.addConnection("a", "d");
            secondGraph.addConnection("b", "d");
            secondGraph.addConnection("b", "c");
            secondGraph.addConnection("b", "f");
            secondGraph.addConnection("c", "d");
            secondGraph.addConnection("c", "f");

            var list2 = secondGraph.BFS("a", "f");
            PrintAll(list2);
            Node g = new Node("g");
            secondGraph.addNode(g);
            var list3 = secondGraph.BFS("a", "g");
            if (list3 == null) // Tidak ditemukan
            {
                Console.WriteLine("Kosong");
            }
            // secondGraph.print(); TEST
            var list4 = secondGraph.DFS("a", "f");
            PrintAll(list4);
            var list5 = secondGraph.DFS("a", "g");
            if (list5 == null)
            {
                Console.WriteLine("Kosong2");
            }
            // secondGraph.print(); TEST
            Console.WriteLine("This is the problem from the PDF\n");
            Graph newGraph = new Graph();
            newGraph.addConnection("A", "B");
            newGraph.addConnection("A", "C");
            newGraph.addConnection("A", "D");
            newGraph.addConnection("B", "E");
            newGraph.addConnection("B", "C");
            newGraph.addConnection("B", "F");
            newGraph.addConnection("C", "G");
            newGraph.addConnection("C", "F");
            newGraph.addConnection("D", "G");
            newGraph.addConnection("D", "F");
            newGraph.addConnection("E", "H");
            newGraph.addConnection("E", "F");
            newGraph.addConnection("F", "H");
            Console.WriteLine("Mutuals");
            PrintMutuals(newGraph.getMutuals("A"));
            Console.WriteLine("BFS");
            PrintAll(newGraph.BFS("A", "H"));
            Console.WriteLine("DFS");
            PrintAll(newGraph.DFS("A", "H"));

            Console.ReadLine();
        }
    }
}