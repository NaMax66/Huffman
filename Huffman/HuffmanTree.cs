using Huffman;
using System.Collections.Generic;
using System.IO;

public class HuffmanTree
//этот класс должен строить дерево на основании файла
//для начала нужно определить частоту каждого символа
{
    List<char> _leaves;
    public HuffmanTree()
    {

    }

    public List<Node> makeTree(string fileName)
    {
        List<Node> list = new List<Node>();

        using (StreamReader sr = File.OpenText(fileName))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                foreach (char item in line)
                {
                    int value = 1;
                    Node node = new Node(item, value);

                    if (list.Contains(node))
                    {
                        value = list.Find(x => x.Symbol == item).Value;
                        list.Remove(node);
                        value++;
                        node = new Node(item, value);
                    }


                    list.Add(node);
                }

            }
        }

        return list;
    }

    public List<char> Leaves { get => _leaves; set => _leaves = value; }
}
