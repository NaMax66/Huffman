using System;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Письмо.txt";

            var charsInFile = new HuffmanTree().makeTree(fileName);



            foreach (var node in charsInFile)
            {
                Console.WriteLine(node.Symbol + ":" + node.Value);

            }

            //Node node1 = new Node('d', 3);
            //Node node2 = new Node('d', 4);

            //List<Node> list = new List<Node>();
            //list.Add(node1);

            //Console.WriteLine(list.Contains(node2));

        }
    }
}
