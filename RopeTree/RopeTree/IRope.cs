namespace RopeTree;

public interface IRope
{
    public void Remove(int index, int length);
    public void Insert(string value, int index);
    public void Add(string value);
}