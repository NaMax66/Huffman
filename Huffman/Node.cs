namespace Huffman
{
    public class Node
    {
        private string _symbol; //название символа //переделать
        private int _value; // колличество повторений в списке

        public Node()
        {

        }

        public Node(string symbol, int value)
        {
            Symbol = symbol;
            Value = value;
        }

        public string Symbol { get => _symbol; set => _symbol = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
