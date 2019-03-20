public class NodeLevel : Huffman.Node
{
    // этот конструктор используется для инициализации листьев дерева - самого верхнего уровня
    public NodeLevel()
    {

    }
    public NodeLevel(string symbol, int value) : base(symbol, value)
    {
        BranchZero = null;
        BranchOne = null;
    }

    public NodeLevel(string symbols, int value, NodeLevel zero, NodeLevel one) : base(symbols, value)
    {
        BranchZero = zero;
        BranchOne = one;
    }
    public NodeLevel BranchZero { get; set; }
    public NodeLevel BranchOne { get; set; }
    public NodeLevel Parrent { get; set; }
    public bool Flag { get; set; }
}