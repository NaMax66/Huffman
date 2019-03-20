using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    static class CodeMatch
    { // этот класс преобразует дерево в префиксную таблицу кодировки

        static List<SymbolCode> codeList;

        public static List<NodeLevel> MakeTree(List<Node> nodes) //лист приходит сортированным
        {
            List<NodeLevel> list = new List<NodeLevel>();

            //добавляем записи в лист с ветвями
            foreach (Node node in nodes)
            {
                NodeLevel n = new NodeLevel(node.Symbol, node.Value);
                list.Add(n);
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

                ref NodeLevel nodeSumRef = ref nodeSum;
                nodeZero.Parrent = nodeSumRef; // добавляем ссылку на родительский элемент
                nodeOne.Parrent = nodeSumRef;


                list.Remove(list[0]); //удаляем две верхние записи
                list.Remove(list[0]);
                list.Add(nodeSum);

                list = list.OrderBy(x => x.Value).ToList();
                if (list.Count == 1) break;

            }

            return list;
        }

        public static List<SymbolCode> getCode(NodeLevel finalTree) //сюда передаём окончательный элемент со вложенными элементами
        {
            //TODO преобразование дерева в таблицу кодировки



            string allSymbolsString = finalTree.Symbol;

            int symbolsAmount = allSymbolsString.Length;

            //SymbolCode[] symbolCode = new SymbolCode[symbolsAmount];

            codeList = new List<SymbolCode>();

            NodeLevel tmp = CheckNext(finalTree, "");

            return codeList;
        }

        //рекурсивный метод, который добирается до символа и присваивает ему код
        public static NodeLevel CheckNext(NodeLevel element, string code)
        {
            if (element.BranchZero != null)
            {
                if (element.BranchZero.Flag) element.BranchZero = null; //удаляем проверенные элементы
            }
            if (element.BranchOne != null)
            {
                if (element.BranchOne.Flag) element.BranchOne = null;
            }


            if (element.BranchZero == null && element.BranchOne == null) //если обе ветки пустые - возможно мы добрались до ключевого элемента
            {
                if (IsOneSymbol(element)) // в кодовую таблицу добавляем элеметы только с одним символом
                {
                    SymbolCode pare = new SymbolCode(element.Symbol, code);

                    codeList.Add(pare);
                }
                element.Flag = true; //ставим пометку на удаление

                if (element.Parrent == null) return null; // это означает, что мы в самом корне дерева и можно закончить проверку
                return CheckNext(element.Parrent, code.Remove(code.Length - 1)); //возвращаемся к родительскому элементу
            }
            else if (element.BranchZero != null)
            {
                return CheckNext(element.BranchZero, code += 0);
            }
            else return CheckNext(element.BranchOne, code += 1);
        }

        private static bool IsOneSymbol(NodeLevel element)
        {
            return (element.Symbol.Length == 1);
        }


    }



    //TODO оптимизировать, чтобы байткод хранился в подходящей переменной
    class SymbolCode
    {
        private string symbol;
        private string byteCode;

        public string Symbol { get => symbol; set => symbol = value; }
        public string ByteCode { get => byteCode; set => byteCode = value; }

        public SymbolCode(string symbol, string byteCode)
        {
            this.Symbol = symbol;
            this.ByteCode = byteCode;
        }



    }




}
