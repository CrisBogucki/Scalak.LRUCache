using Scalak.Sample;

var cache = new LruCache<int, string?>(2);

cache.Put(1, "One");
cache.Put(2, "Two");
Console.WriteLine(cache.Get(1)); // result: One

cache.Put(3, "Three"); // remove key 1
Console.WriteLine(cache.Get(2)); // result: default(string) (key 2 not exist in memory)

cache.Put(4, "Four"); // remove key 2
Console.WriteLine(cache.Get(1)); // result: default(string) (key 1xy)
Console.WriteLine(cache.Get(3)); // result: Three
Console.WriteLine(cache.Get(4)); // result: Four