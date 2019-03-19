using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    static class CodeMatch
    { // этот класс преобразует дерево в префиксную таблицу кодировки
        private static string fileName;

        public static List<NodeLevel> MakeTree(List<Node> nodes) //лист приходит сортированным
        {
            List<NodeLevel> list = new List<NodeLevel>();

            //добавляем записи в лист с ветвями
            foreach (Node node in nodes)
            {
                list.Add(new NodeLevel(node.Symbol, node.Value));
            }

            var nodeZero = new NodeLevel();
            var nodeOne = new NodeLevel();

            while (true)
            {

                nodeZero = list[0];
                nodeOne = list[1];

                var symbolSum = nodeOne.Symbol + nodeZero.Symbol;
                var valueSum = nodeOne.Value + nodeZero.Value;

                var nodeSum = new NodeLevel(symbolSum, valueSum, nodeZero, nodeOne); //добавляем нижний уровень - суммарную ветку


                list.Remove(list[0]);
                list.Remove(list[0]);
                list.Add(nodeSum);

                list = list.OrderBy(x => x.Value).ToList();
                if (list.Count == 1) break;

            }

            return list;
        }

        public static SymbolCode[] getCode(List<NodeLevel> finalTree)
        {
            SymbolCode[] symbolCode = new SymbolCode[finalTree.Count];

            //TODO преобразование дерева в таблицу кодировки
            return symbolCode;
        }

    }



    struct SymbolCode
    {
        string s;
        int byteCode;

        public SymbolCode(string s, int byteCode)
        {
            this.s = s;
            this.byteCode = byteCode;
        }
    }


}
