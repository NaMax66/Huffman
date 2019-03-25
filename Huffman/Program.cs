using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "bigLog.txt";


            var charsInFile = HuffmanTree.MakeFreqList(fileName);

            var tree = CodeMatch.MakeTree(charsInFile); // тест дерева

            var codeStruct = CodeMatch.getCode(tree[0]);

            makeLog(codeStruct);

            WriteFile(fileName, codeStruct);




            if (charsInFile.Count > 1)
            {
                Console.WriteLine($"В {tree.ToString()} {tree.Count} записей");
            }

            WriteFreqList(charsInFile, "Leafs.txt");

        }

        static public void WriteFile(string fileName, List<SymbolCode> list)
        {
            byte a = 255;

            //if fileName has a
            // 011
            //if < 8 00011
            // a = 00110

        }

        private static void makeLog(List<SymbolCode> codeStruct)
        {
            using (FileStream fs = File.Create($"logs/{DateTime.Now.ToFileTime()}.txt"))
            {
                foreach (SymbolCode s in codeStruct)
                {
                    if (s.Symbol == "\n")
                    {
                        s.Symbol = "символ переноса строки";
                    }
                    string txt = s.Symbol + " : " + s.ByteCode + "\r\n";
                    Console.WriteLine(txt);
                    AddText(fs, txt);
                }
            }
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private static void WriteFreqList(List<Node> list, string path)
        {
            //этот метод используется для тренеровки и он очень не эффективен. Если будет время - найти более эффективный способ.

            string s = "НЕ РЕАЛИЗОВАННО";
            int leavs = list.Count;
            long total = 0;

            if (list.Count > 1)
            {
                foreach (var node in list)
                {
                    total += node.Value;
                }

            }
            Console.WriteLine("Колличество разных символов: " + leavs);
            Console.WriteLine("Всего символов в файле: " + total);
            Console.WriteLine(list[0].Symbol + ":" + list[0].Value + " это самый редкий редкий элемент в файле");
            Console.WriteLine(list[list.Count - 1].Symbol + ":" + list[list.Count - 1].Value + " это самый частовстречающийся символ в файле");

            Console.WriteLine();
        }
    }
}
