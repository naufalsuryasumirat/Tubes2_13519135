using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Classes
{
    // Define classes here
    // nanti yang ditandain TEST diapus / dicek
	public class Node // Class Node (Simpul)
    {
        private Node fromNode; // Menyimpan Node sebelumnya yang dilewati untuk mencapai Node ini (Digunakan untuk Algoritma Breadth-First Search dan Depth-First Search)
        private string Name; // Menyimpan Nama dari simpul
		private bool Visited; // Status telah dikunjungi atau belum
        private List<Node> CNodes; // Menyimpan Node/Simpul yang bertetangga (adjacent)
        private int Count; // Menyimpan jumlah node yang bertetangga (Mungkin tidak perlu) TEST
        public Node() // Default Constructor, mungkin tidak digunakan TEST
        {
            this.fromNode = null;
            this.Name = null;
            this.CNodes = new List<Node>();
            this.Visited = false;
        }
        public Node(string Name) // User-defined Constructor, fromNode = null, Name = parameter Name, CNodes = List<Node> baru yang kosong, Status Dikunjungi = false, Count = 0
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
        public void addCount() // Menambahkan Count sebanyak 1
        {
            this.Count++;
        }
        public void subtractCount() // Mengurangi Count sebanyak 1
        {
            this.Count--;
        }
        public int getCount() // Get Count
        {
            return this.Count;
        }
        public Node getFromNode() // Get Node sebelumnya (ketika traversal graf)
        {
            return this.fromNode;
        }
        public void setFromNode(Node node) // Set Node sebelumnya menjadi node (untuk traversal graf agar bisa traceback)
        {
            this.fromNode = node;
        }
        public void setFromNodeNull() // Set Node sebelumnya Null
        {
            this.fromNode = null;
        }
        public void addEdge(Node node) // Menambahkan koneksi/edge ke Node lain
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
        public void removeNode(string name) // Menghilangkan sebuah node dari list adjacent
        {
            this.CNodes.RemoveAt(findNode(name));
            subtractCount();
        }
        public void removeConnection(string name) // Menghilangkan koneksi antar node (menghilangkan dari node ini dengan node dengan Name = name)
        {
            (this.CNodes[findNode(name)]).removeNode(getName());
            removeNode(name);
        }
        public int findNode (string name) // Mengembalikan index dari node dengan nama = name dalam CNodes (adjacency list), mengembalikan (-1) jika tidak ditemukan
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
        public bool IsConnected(string name) // Mengecek koneksi antar dua node, mengembalikan true jika terhubungi, mengembalikan false jika tidak
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
        public List<Node> getCNodes() // Mengembalikan Adjacency List (CNodes) dari Node
        {
            return this.CNodes;
        }
        public void SortConnected() // Mengurutkan Adjacency List CNodes berdasarkan atribut string Name, menaik (Karena diutamakan sesuai abjad)
        {
            this.CNodes.Sort((x, y) => x.getName().CompareTo(y.getName()));
        }
        public void print() // Meng-output-kan Info dari Node
        {
            Console.WriteLine("Name     : " + this.Name);
            Console.WriteLine("Count    : " + this.Count);
            Console.Write("Connected: "); // Nama dari Node yang bertetanggaan
            for (int i = 0; i < this.CNodes.Count; i++)
            {
                if (i != this.CNodes.Count - 1)
                {
                    Console.Write(this.CNodes[i].getName() + ", ");
                }
                else
                {
                    Console.WriteLine(this.CNodes[i].getName() + ".");
                }
            }
            Console.Write("Status   : "); // Status sudah dikunjungi atau belum
            if (this.Visited)
            {
                Console.WriteLine("Visited");
            }
            else
            {
                Console.WriteLine("Unvisited");
            }
            Console.Write("From     : ");
            if (this.fromNode == null) // Jika tidak terdapat penelusuran Node sebelumnya
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
        private List<Node> NodeList; // List berisi Node yang terdapat pada Graph
        public Graph() // Default Constructor, membuat Graph kosong yang tidak memiliki node di dalamnya
        {
            this.NodeList = new List<Node>();
        }
        public Graph(string filename) // User-defined Constructor, membuat graph dari input soal/permasalahan
        {
            this.NodeList = new List<Node>();
            Console.WriteLine("READING FROM FILE"); // TEST
            string filenameRead = "../../" + filename; // TEST
            string line;
            int lineCount;
            var readFile = new StreamReader(filenameRead);
            line = readFile.ReadLine();
            lineCount = Convert.ToInt32(line); // converting string to int
            for (int i = 0; i < lineCount; i++)
            {
                line = readFile.ReadLine();
                var vars = line.Split(new[] {' '});
                this.addConnection(vars[0], vars[1]);
                Console.WriteLine(line); // TEST
            }
            readFile.Close();
        }
        public void addNode(Node node) // Menambahkan node pada Graph, jika sudah terdapat node tersebut, tidak ditambahkan
        {
            // NodeList.Add(node); // TEST (boleh duplikat?)
            if (findNode(node.getName()) == null)
            {
                 NodeList.Add(node);
            }
        }
        public Node findNode(string name) // Mengembalikan Node node jika terdapat pada Graph, jika tidak akan dikembalikan null
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
        // Menambahkan koneksi antar dua node, jika salah satu atau kedua node tersebut belum terdapat pada Graph, node tersebut akan ditambahkan
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
        public void print() // Meng-output-kan informasi tiap Node yang terdapat pada Graph
        {
            foreach (Node node in NodeList)
            {
                node.print();
            }
        }
        public List<string> BFS(string from, string to) // Mengembalikan List of string hasil penelusuran BFS dari suatu Node ke Node lainnya, jika tidak terdapat koneksi, dikembalikan null
        // Algoritma BFS bekerja dengan iteratif, dimulai dari Node from
        // Dari Node from, menelusuri seluruh tetangga terlebih dahulu (alphabetically) kemudian menlanjutkan menelusuri tetangga dari hasil telusuran tersebut
        // Bekerja dengan membuat sebuah Queue (First In First Out), jika telah dikunjungi, Node ditambahkan ke bagian akhir list, dan melanjutkan penelusuran Node dari Queue paling depan
        // Tiap iterasi (Jika Node paling depan Queue telah dikunjungi seluruh tetangganya), Node tersebut di-remove dari Queue, kemudian dilanjutkan untuk Node berikutnya
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
        public void DFSrec(Node node, string from) // Menelusuri Graph secara DFS (rekursif), dimulai dari Node dengan Name = from
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
        public List<string> DFS(string from, string to) // Mengembalikan hasil penelusuran (jalur) Graph secara DFS, dimulai dari Node from hingga Node to
        // DFS bekerja dengan rekursif, dimulai dari Node from
        // Dari Node from, ditelusuri Node bertetangga (alphabetically) dan menelusuri Node tersebut lagi sebelum menelusuri Node bertetangga lainnya
        {
            if (findNode(from) == null || findNode(to) == null || from == to) // Kasus jika Node from atau Node to tidak terdapat pada Graph
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
        public List<Tuple<string, int, List<string>>> getMutuals(string name) // Mengembalikan Mutual Friend dari sebuah Node
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
        public void removeEdge(string from, string to) // Menghilangkan koneksi antar Node pada Graph (from dan to harus terdapat pada Graph) TEST
        {
            findNode(from).removeConnection(to);
        }
        public void setAllUnvisited() // Set setiap Node pada Graph menjadi Unvisited (Visited = false) (reset untuk traversal berikutnya)
        {
            foreach (Node node in NodeList)
            {
                node.setUnvisited();
            }
        }
        public void setAllFNNull() // Set setiap Node pada Graph agar memiliki FromNode = null (reset untuk traversal berikutnya)
        {
            foreach (Node node in NodeList)
            {
                node.setFromNodeNull();
            }
        }
        private void PrintAll(List<string> list) // Method Private untuk meng-output hasil traversal (BFS/DFS) TEST (mungkin ditambahkan getter sebagai sebuah string)
        {
            if (list == null)
            {
                Console.WriteLine("Tidak terdapat jalan"); // TEST mungkin tambah parameter from, to
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                {
                    Console.Write(list[i] + " --> ");
                }
                else
                {
                    Console.WriteLine(list[i] + ".");
                }
            }
        }
        private void PrintMutuals(List<Tuple<string, int, List<string>>> list) // Method Private untuk meng-output Mutual Friend sebuah Node (mungkin ditambahkan getter sebagai sebuah string)
        {
            foreach (var tuple in list) // Mutual friends
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
                Console.WriteLine(":-----:"); // TEST
            }
        }
        public void WritePathBFS(string from, string to) // Method public untuk meng-output hasil traversal menggunakan algoritma BFS dari Node from hingga Node to
        {
            PrintAll(BFS(from, to));
        }
        public void WritePathDFS(string from, string to) // Method public untuk meng-output hasil traversal menggunakan algoritma DFS dari Node from hingga Node to
        {
            PrintAll(DFS(from, to));
        }
        public void WriteMutuals(string source) // Method public untuk meng-output hasil penemuan mutual friend dari Node source
        {
            PrintMutuals(getMutuals(source));
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

            // READING FROM FILE
            Console.WriteLine("READING FROM FILE");
            Graph fileGraph = new Graph();
            string filename = "../../test.txt";
            string line;
            int lineCount;
            var sr = new StreamReader(filename);
            line = sr.ReadLine();
            lineCount = Convert.ToInt32(line); // converting string to int
            for (int i = 0; i < lineCount; i++)
            {
                line = sr.ReadLine();
                var vars = line.Split(new[] {' '});
                fileGraph.addConnection(vars[0], vars[1]);
                Console.WriteLine(line);
            }
            sr.Close();
            Console.WriteLine("Mutuals");
            PrintMutuals(fileGraph.getMutuals("A"));
            Console.WriteLine("BFS");
            PrintAll(fileGraph.BFS("A", "H"));
            Console.WriteLine("DFS");
            PrintAll(fileGraph.DFS("A", "H"));

            // Ways to use the class to print
            Graph testRead = new Graph("test.txt");
            testRead.WriteMutuals("A");
            testRead.WritePathBFS("A", "H");
            testRead.WritePathDFS("A", "H");

            Console.ReadLine();
        }
    }
}