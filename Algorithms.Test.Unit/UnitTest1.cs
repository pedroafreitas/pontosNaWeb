[TestClass]
public class LruCacheUnitTest
{
    [TestMethod]
    public void LruCacheTest()
    {
        LRUCache cache = new LRUCache(2 /* capacity */ );

        cache.put(1, 1);
        cache.put(2, 2);
        Assert.AreEqual(1, cache.get(1));       // returns 1
        cache.put(3, 3);    // evicts key 2
        Assert.AreEqual(-1, cache.get(2));       // returns -1 (not found)
        cache.put(4, 4);    // evicts key 1
        Assert.AreEqual(-1, cache.get(1));       // returns -1 (not found)
        Assert.AreEqual(3, cache.get(3));       // returns 3
        Assert.AreEqual(4, cache.get(4));       // returns 4
    }
}