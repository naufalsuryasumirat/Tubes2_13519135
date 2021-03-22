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
        private List<Tuple<string, string>> DrawInfo; // Informasi yang digunakan untuk menggambar Graph
        public Graph() // Default Constructor, membuat Graph kosong yang tidak memiliki node di dalamnya
        {
            this.NodeList = new List<Node>();
            this.DrawInfo = new List<Tuple<string, string>>();
        }
        public Graph(string filename) // User-defined Constructor, membuat graph dari input soal/permasalahan
        {
            this.NodeList = new List<Node>();
            this.DrawInfo = new List<Tuple<string, string>>();
            Console.WriteLine("READING FROM FILE"); // TEST
            string filenameRead = filename; // TEST READINGFILE
            string line;
            int lineCount;
            var readFile = new StreamReader(filenameRead);
            line = readFile.ReadLine();
            lineCount = Convert.ToInt32(line); // converting string to int
            for (int i = 0; i < lineCount; i++)
            {
                line = readFile.ReadLine();
                var vars = line.Split(new[] {' '});
                DrawInfo.Add(Tuple.Create(vars[0], vars[1])); // Menaruh informasi pada DrawInfo untuk digambar
                this.addConnection(vars[0], vars[1]);
                Console.WriteLine(line); // TEST
            }
            readFile.Close();
        }
        public List<string> getNodeNames() // Get list dari nama node yang terdapat pada graph
        {
            var names = new List<string>();
            foreach (var node in this.NodeList)
            {
                names.Add(node.getName());
            }
            return names;
        }
        public List<Tuple<string, string>> getDrawInfo() // Get DrawInfo untuk menggambar graph menggunakan MSAGL
        {
            return this.DrawInfo;
        }
        public void addNode(Node node) // Menambahkan node pada Graph, jika sudah terdapat node tersebut, tidak ditambahkan
        {
            if (findNode(node.getName()) == null)
            {
                NodeList.Add(node);
                this.DrawInfo.Add(new Tuple<string, string>(node.getName(), null));
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
            var t1 = new Tuple<string, string>(nodeOne, nodeTwo);
            var t2 = new Tuple<string, string>(nodeTwo, nodeOne);
            if (!this.DrawInfo.Contains(t1) && !this.DrawInfo.Contains(t2)) { this.DrawInfo.Add(t1); }
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
        public void removeEdge(string from, string to) // Menghilangkan koneksi antar Node pada Graph (from dan to harus terdapat pada Graph)
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
        private void PrintAll(List<string> list) // Method Private untuk meng-output hasil traversal (BFS/DFS)
        {
            if (list == null)
            {
                Console.WriteLine("Tidak terdapat jalan");
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
        public string getPrintAll(List<string> list) // Method public untuk mendapatkan hasil traversal (BFS/DFS) dalam bentuk string untuk diperlihatkan dalam GUI
        {
            string toReturn = "Nama Akun: " + list[0] + " dan " + list[list.Count - 1] + "\n";
            if (list == null) return null;
            if (list.Count - 2 == 0) { toReturn += "Direct Connection\n"; }
            else if (list.Count - 2 == 1) { toReturn += "1st Degree Connection\n"; }
            else if (list.Count - 2 == 2) { toReturn += "2nd Degree Connection\n"; }
            else if (list.Count - 2 == 3) { toReturn += "3rd Degree Connection\n"; }
            else if (list.Count - 2 > 3) { toReturn += (list.Count - 2).ToString() + "th Degree Connection\n"; }
            toReturn += "Jalur yang terbentuk: ";
            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                {
                    toReturn += list[i] + " --> ";
                }
                else
                {
                    toReturn += list[i] + ".\n";
                }
            }
            return toReturn;
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
                Console.WriteLine(":-----:");
            }
        }
        public string getPrintMutuals(string name) // Mengembalikan hasil PrintMutuals / Hasil mutual friends dengan format yang tepat (untuk diperlihatkan pada GUI) dalam bentuk string
        {
            var list = getMutuals(name);
            if (list.Count == 0) return "Tidak ada rekomendasi teman untuk akun " + name + "\n";
            string toReturn = "";
            toReturn += "Daftar rekomendasi teman untuk akun " + name + "\n";
            foreach (var tuple in list)
            {
                toReturn += "Nama Akun : " + tuple.Item1 + "\n";
                toReturn += tuple.Item2 + " Mutual Friends : ";
                for (int i = 0; i < tuple.Item3.Count; i++)
                {
                    if (i != tuple.Item3.Count - 1)
                    {
                        toReturn += tuple.Item3[i] + ", ";
                    }
                    else
                    {
                        toReturn += tuple.Item3[i] + ".\n";
                    }
                }
            }
            return toReturn;
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
}