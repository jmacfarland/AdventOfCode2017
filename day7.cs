using System.Collections.Generic;
using System.Text.RegularExpressions;
class Day7
{
    public static void solve()
    {
        string rootNode = "";
        string[] inputLines = getInput();
        IDictionary<string, int> nodes = new Dictionary<string, int>();

        foreach(string str in inputLines)
        {
            string[] temp = str.Split(' ');
            foreach(string tempStr in temp)
            {
                //clean to remove all but alphabetic chars
                string tempStrClean = Regex.Replace(tempStr,  "[^a-zA-Z ' ']", "");

                //only add the strings that are valid node names
                if(tempStrClean.Contains("(") == false && tempStrClean.Contains("->") == false)
                {
                    if(nodes.ContainsKey(tempStrClean)) 
                    {
                        nodes[tempStrClean]++;
                    }
                    else 
                    {
                        nodes[tempStrClean] = 1;
                    }
                }
            }
        }

        foreach(KeyValuePair<string, int> item in nodes)
        {
            if(item.Value == 1) rootNode = item.Key;
        }

        //PART TWO
        IDictionary<string, int> nodeWeights = new Dictionary<string, int>();
        foreach(string str in inputLines)
        {
            string[] temp = str.Split(' ');
            int weight;
            int.TryParse(temp[1].Replace("(", "").Replace(")", ""), out weight);

            nodeWeights.Add(temp[0], weight);
            //System.Console.WriteLine(temp[0] + ", " + weight);
        }

        //get all connections in dictionary
        IDictionary<string, string[]> nodeConnections = new Dictionary<string, string[]>();
        foreach(string str in inputLines)
        {
            string[] temp = str.Split(' ');
            
            if(temp.Length > 3)//node points to other nodes
            {
                string[] connections = new string[temp.Length - 3];//ignores original node, (x), and -> strings
                for(int i = 0; i < temp.Length - 3; i++)
                {
                    connections[i] = Regex.Replace(temp[i + 3],  "[^a-zA-Z ' ']", "");
                }
                nodeConnections.Add(temp[0], connections);

                /*
                System.Console.Write(temp[0] + ": ");
                foreach(string s in connections)
                {
                    System.Console.Write(s + ", ");
                }
                System.Console.WriteLine("\n");
                */
            }
            else
            {
                nodeConnections.Add(temp[0], null);//no connections
            }
        }

        Node root = new Node(rootNode, nodeWeights[rootNode]);
        root = fixTree(root, nodeConnections);
        root = fixWeights(root, nodeWeights);

        System.Console.WriteLine(root.name + ", weight: " + root.weight + ", totalWeight: " + root.totalWeight);
    }

    static Node fixWeights(Node root, IDictionary<string, int> nodeWeights)
    {
        root.weight = root.totalWeight = nodeWeights[root.name];
        if(root.nodesAbove.Count != 0)
        {
            foreach(Node node in root.nodesAbove)
            {
                fixWeights(node, nodeWeights);
                root.totalWeight += node.totalWeight;
            }
        }
        //System.Console.WriteLine(root.name + ", weight: " + root.weight + ", totalWeight: " + root.totalWeight);

        return root;
    }

    static Node fixTree(Node root, IDictionary<string, string[]> nodeConnections)
    {
        if(nodeConnections[root.name] != null)
        {
            //iterates over connections array value that is mapped to the root node name
            foreach(string connection in nodeConnections[root.name])
            {
                Node temp = new Node(connection);
                temp = fixTree(temp, nodeConnections);
                root.nodesAbove.Add(temp);
            }
        }

        return root;
    }
    

    static string[] getInput()
    {
        //string text = System.IO.File.ReadAllText(@"C:\Users\JMacfarland\adventOfCode2017\day7_input.txt");
        string text = System.IO.File.ReadAllText(@"C:\Users\JMacfarland\adventOfCode2017\day7_test.txt");
        string[] temp = text.Split('\n');

        return temp;
    }
}

class Node
{
    public int weight;
    public int totalWeight;
    public string name;
    public List<Node> nodesAbove;

    public Node(string name, int weight = 0)
    {
        this.name = name;
        this.weight = weight;//only weight of self
        this.totalWeight = weight;//will contain weight of self + weight of all nodes above
        nodesAbove = new List<Node>();
    }
}