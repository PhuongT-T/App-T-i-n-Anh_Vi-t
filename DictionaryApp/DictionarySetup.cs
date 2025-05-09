public class HashNode
{
    public string Key;
    public WordEntry Value;
    public HashNode Next;

    public HashNode(string key, WordEntry value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}public class DictionaryManager
{
    private const int SIZE = 101;
    private HashNode[] table;

    public DictionaryManager()
    {
        table = new HashNode[SIZE];
    }

    private int HashFunction(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash = (hash * 31 + c) % SIZE;
        }
        return hash;
    }

    public void AddWord(string key, WordEntry value)
    {
        int index = HashFunction(key);
        HashNode current = table[index];

        while (current != null)
        {
            if (current.Key == key)
            {
                current.Value = value;
                return;
            }
            current = current.Next;
        }

        HashNode newNode = new HashNode(key, value);
        newNode.Next = table[index];
        table[index] = newNode;
    }

    public WordEntry GetDefinition(string key)
    {
        int index = HashFunction(key);
        HashNode current = table[index];
        while (current != null)
        {
            if (current.Key == key)
                return current.Value;
            current = current.Next;
        }
        return null;
    }

    public bool Contains(string key)
    {
        return GetDefinition(key) != null;
    }
}
