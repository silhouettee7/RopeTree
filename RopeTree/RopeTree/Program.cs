﻿using System.Security.Cryptography.X509Certificates;


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
        throw new NotImplementedException();
    }

    private (RopeNode, RopeNode) Split(int index)
    {
        throw new NotImplementedException();
    }

    private RopeNode Merge(RopeNode node1, RopeNode node2)
    {
        return new RopeNode(node1, node2);
    }


}

public class RopeNode
{
    public string? Value { get; set; }
    public RopeNode? Left { get; set; }
    public RopeNode? Right { get; set; }
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

    public RopeNode(string value)
    {
        Value = value;
        Weight = value.Length;
    }

    public RopeNode(int weight)
    {
        Weight = weight;
    }

    public RopeNode(RopeNode left, RopeNode right)
    {
        Left = left;
        Right = right;
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

    private static int GetHeight(RopeNode? node)
    {
        return node?.Height ?? 0;
    }
}