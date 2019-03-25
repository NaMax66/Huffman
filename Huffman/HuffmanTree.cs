using Huffman;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class HuffmanTree
//TODO: чтобы этот класс возвращал дерево со всеми уровнями

{
    public static List<NodeLevel> MakeTree(List<NodeLevel> freqList)
    {
        return new List<NodeLevel>();
    }

    public static List<Node> MakeFreqList(string fileName)
    {
        List<Node> list = new List<Node>();

        using (StreamReader sr = File.OpenText(fileName))
        {
            string line;
            int endLineValue = 0; //на случай если в исходном файле всего одна строка
            while ((line = sr.ReadLine()) != null)
            {
                foreach (char item in line)
                {
                    int value = 1;
                    string latter = item.ToString();

                    if (list.Exists(x => x.Symbol == latter))
                    {
                        Node n = list.Find(x => x.Symbol == latter); //выражение в скобках символизирует принцп, по которому мы ищим
                        value = ++n.Value;
                        list.Remove(n);
                    }
                    list.Add(new Node(latter, value));
                }
                endLineValue++; //после прочтения линии добовляем символ новой строки
            }

            endLineValue--; // после всех итераций удаляем один символ конца строки

            if (endLineValue != 0) //это добавляет символ конца строки в дерево.
            {
                Node nodeEndLine = new Node("\n", endLineValue - 1); //вычитаем еденицу, так как в последней строке нет переноса
                list.Add(nodeEndLine);
            }
        }
        return list.OrderBy(x => x.Value).ToList();
    }

}
