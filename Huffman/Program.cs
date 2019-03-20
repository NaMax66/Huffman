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
            string fileName = "Роза.txt"; 



            var charsInFile = HuffmanTree.MakeFreqList(fileName);

            var tree = CodeMatch.MakeTree(charsInFile); // тест дерева

            var codeStruct = CodeMatch.getCode(tree[0]);

            makeLog(codeStruct);

            


            if (charsInFile.Count > 1)
            {
                Console.WriteLine($"В {tree.ToString()} {tree.Count} записей");
            }

            WriteFreqList(fileName, "Leafs.txt");

        }

        private static void makeLog(List<SymbolCode> codeStruct)
        {
            using(FileStream fs = File.Create($"logs/{DateTime.Now.ToFileTime()}.txt"))
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

        private static void WriteFreqList(string sorceFile, string path)
        {
            //этот метод используется для тренеровки и он очень не эффективен. Если будет время - найти более эффективный способ.

            string s = File.ReadAllText(sorceFile);
            int leavs = 0;
            string txt = "";

            var charsInFile = HuffmanTree.MakeFreqList(sorceFile);
            var tree = CodeMatch.MakeTree(charsInFile);

            if (tree.Count > 1)
            {
                foreach (var node in tree)
                {
                    Console.WriteLine(node.Symbol + ":" + node.Value);
                    txt += (node.Symbol + ":" + node.Value + "\r\n"); // \n не переводит строку в файле
                    leavs++;
                }
                txt = txt.Substring(0, txt.Length - 1); //удаляем последний перенос строки
            }
            else
            {
                txt = tree[0].Symbol;
                Console.WriteLine(txt);
                Console.WriteLine();
                Console.WriteLine($"в окончательном элементе {tree[0].Symbol.Length} символов");

            }




            File.WriteAllText(path, txt);

            Console.WriteLine("Колличество разных символов: " + leavs);
            Console.WriteLine("Всего символов в файле: " + s.Length);
            Console.WriteLine(charsInFile[0].Symbol + ":" + charsInFile[0].Value + " это первый элемент списка");
            Console.WriteLine(charsInFile[charsInFile.Count - 1].Symbol + ":" + charsInFile[charsInFile.Count - 1].Value + " это последний элемент списка");

            Console.WriteLine();
        }
    }
}
