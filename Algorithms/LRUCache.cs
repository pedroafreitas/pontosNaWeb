public class LRUCache
{
    private int _numOfCells;
    private Dictionary<int, int> _cache;
    private List<KeyValuePair<int, int>> _orderList;

    public LRUCache(int numberOfCacheCells)
    {
        this._numOfCells = numberOfCacheCells;
        _cache = new Dictionary<int, int>(_numOfCells);
        _orderList = new List<KeyValuePair<int, int>>(_numOfCells);
    }

    public void put(int key, int value)
    {
        if (_cache.Count == _numOfCells) // the cache is full we need to remove 1
        {
            var toRemove = _orderList[0];
            _cache.Remove(toRemove.Key);
            _orderList.Remove(toRemove);
        }
        _orderList.Add(new KeyValuePair<int, int>(key, value));
        _cache[key] = value;
    }

    public int get(int key)
    {
        if (!_cache.ContainsKey(key))
        {
            return -1;
        }

        //put the key and value to the back of the ordered list
        var tempCacheCell = _orderList.FirstOrDefault(x=>x.Key == key);
        _orderList.Remove(tempCacheCell);
        _orderList.Add(tempCacheCell);
        return _cache[key];
    }
}