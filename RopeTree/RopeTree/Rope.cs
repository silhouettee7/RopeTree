namespace RopeTree;

public class Rope : IRope
{
    private RopeNode _root;

    public Rope(string value)
    {
        _root = new RopeNode(value);
    }
    public char this[int index]
    {
        get
        {
            var current = _root;
            while (true)
            {
                if (current!.Left != null)
                {
                    if (current.Left.Weight > index)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        index -= current.Left.Weight;
                        current = current.Right;
                    }
                }
                else
                {
                    return current.Value![index];
                }
            }
        }
    }

    public void Add(string value)
    {
        var subTree = new RopeNode(value);
        _root = Merge(_root, subTree);
    }

    public void Insert(string value, int index)
    {
        (RopeNode tree1, RopeNode tree3) = Split(_root, index);
        var tree2 = new RopeNode(value);
        _root = Merge(Merge(tree1, tree2), tree3);
    }

    public void Remove(int index, int length)
    {
        (RopeNode tree1, RopeNode tree2) = Split(_root, index);
        var tree3 = Split(tree2, length).Item2;
        _root = Merge(tree1, tree3);
    }

    public string SubString(int index, int length)
    {
        var subTree = Split(_root, index);
        var res = Split(subTree.Item2, length);
        _root = Merge(subTree.Item1, res.Item2);
        
        return res.Item1.Value!;
    }

    public override string ToString()
    {
        return _root.GetValue();
    }

    private (RopeNode, RopeNode) Split(RopeNode node, int i)
    {
        RopeNode tree1, tree2;

        if (node.Left != null)
        {
            if (node.Left.Weight > i)
            {
                (RopeNode, RopeNode) res = Split(node.Left, i);
                tree1 = res.Item1;
                tree2 = new RopeNode(res.Item2, node.Right!);
            }
            else
            {
                (RopeNode, RopeNode) res = Split(node.Right!, i - node.Left.Weight);
                tree1 = new RopeNode(node.Left, res.Item1);
                tree2 = res.Item2;
            }
        }
        else
        {
            tree1 = new RopeNode(node.Value!.Substring(0, i));
            tree2 = new RopeNode(node.Value.Substring(i, node.Value.Length - i));
        }

        return (tree1, tree2);
    }

    private RopeNode Merge(RopeNode node1, RopeNode node2)
    {
        var res = new RopeNode(node1, node2);
        res = Balance(res);
        return res;
    }

    private RopeNode Balance(RopeNode node)
    {
        if (node.BalanceFactor > 1)
        {
            if (node.Right!.BalanceFactor < 0)
            {
                node.Right = RotateRight(node.Right);
            }

            node = RotateLeft(node);
        }
        else if (node.BalanceFactor < -1)
        {
            if (node.Left!.BalanceFactor > 0)
            {
                node.Left = RotateLeft(node.Left);
            }
            node = RotateRight(node);
        }

        return node;
    }
    private RopeNode RotateRight(RopeNode subTree)
    {
        var tempLeftTree = subTree;
        subTree = subTree.Left!;
        tempLeftTree.Left = subTree.Right;
        subTree.Right = tempLeftTree;

        return subTree;
    }

    private RopeNode RotateLeft(RopeNode subTree)
    {
        var tempRightTree = subTree;
        subTree = subTree.Right!;
        tempRightTree.Right = subTree.Left;
        subTree.Left = tempRightTree;

        return subTree;
    }
}