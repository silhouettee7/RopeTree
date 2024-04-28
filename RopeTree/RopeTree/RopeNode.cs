namespace RopeTree;

public class RopeNode
{
    public string? Value { get; set; }
    public RopeNode? Left { get; set; }
    public RopeNode? Right { get; set; }
    public int Weight
    {
        get
        {
            if (Left == null && Right == null)
            {
                return Value!.Length;
            }
            int leftWeight = Left?.Weight ?? 0;
            int rightWeight = Right?.Weight ?? 0;
            
            return leftWeight + rightWeight;
        }
    }
    public int BalanceFactor => GetHeight(Right) - GetHeight(Left);
    public int Height
    {
        get
        {
            var hl = GetHeight(Left);
            var hr = GetHeight(Right);
            return (hl > hr ? hl : hr) + 1;
        }
    }
    private static int GetHeight(RopeNode? node)
    {
        return node?.Height ?? 0;
    }
    public RopeNode(string value)
    {
        Value = value;
    }

    public RopeNode(RopeNode left, RopeNode right)
    {
        Left = left;
        Right = right;
    }

    public string GetValue()
    {
        if (Left == null && Right == null)
        {
            return Value!;
        }

        return (Left != null ? Left.GetValue() : "") + (Right != null ? Right.GetValue() : "");
    }

}