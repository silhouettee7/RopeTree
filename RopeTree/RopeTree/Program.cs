using System.Security.Cryptography.X509Certificates;


public interface IRope
{
    public bool Remove(int index, int length);
    public void Insert(string value, int index);

}
public class Rope: IRope
{
    private RopeNode _root;

    public string this[int index]
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public string GetString()
    {
        return _root.GetValue();
    }

    public void Insert(string value, int index)
    {
        throw new NotImplementedException();
    }

    public bool Remove(int index, int length)
    {
        return true;
    }

    private (RopeNode, RopeNode) Split(int index)
    {
        throw new NotImplementedException();
    }

    private RopeNode Merge(RopeNode node1, RopeNode node2)
    {
        throw new NotImplementedException();
    }
}

public class RopeNode
{
    public string? Value { get; set; }
    public RopeNode? Left { get; set; }
    public RopeNode? Right { get; set; }

    public RopeNode(string value)
    {
        Value = value;
        Weight = value.Length;
    }

    public RopeNode(int weight)
    {
        Weight = weight;
    }

    public int Weight
    {
        get
        {
            if (Left == null && Right == null)
            {
                return Weight;
            }
            int leftWeight = Left?.Weight ?? 0;
            int rightWeight = Right?.Weight ?? 0;

            return leftWeight + rightWeight;
        }
        set
        {
            Weight = value;
        }
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