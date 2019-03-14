namespace Huffman
{
    public class Node
    {
        private char _symbol; //название символа
        private int _value; // колличество повторений в списке

        public Node(char symbol, int value)
        {
            Symbol = symbol;
            Value = value;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Node objAsNode = obj as Node;
            if (objAsNode == null) return false;
            else return Equals(objAsNode);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Symbol;
        }

        public bool Equals(Node other)
        {
            if (other == null) return false;
            return (this.Symbol.Equals(other.Symbol));
        }

        public char Symbol { get => _symbol; set => _symbol = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
