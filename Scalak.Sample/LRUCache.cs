namespace Scalak.Sample;

public class LruCache<TKey, TValue> where TKey : notnull
{
    private record CacheItem(TKey Key, TValue Value);

    private readonly int _capacity;
    private readonly Dictionary<TKey, CacheItem> _cacheItems;
    private readonly LinkedList<CacheItem> _cacheList;

    public LruCache(int capacity = 3)
    {
        _capacity = capacity;
        _cacheItems = new Dictionary<TKey, CacheItem>(capacity);
        _cacheList = new LinkedList<CacheItem>();
    }

    public TValue? Get(TKey key)
    {
        if (_cacheItems.TryGetValue(key, out var cacheItem))
            return cacheItem.Value;
        
        return default(TValue);
    }

    public void Put(TKey key, TValue? val)
    {
        var item = new CacheItem(key, val);
        _cacheItems.Add(key, item);
        _cacheList.AddLast(item);
        if (_cacheList.Count <= _capacity)
            return;

        var first = _cacheList.First;
        _cacheItems.Remove(first.Value.Key);
        _cacheList.RemoveFirst();
        
    }
}