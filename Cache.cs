
namespace assignment
{
    public class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        private int maximumNumberOfElements;

        /// <summary>
        /// Cache constructor. Accepts maximum number of elements stored in the cache.
        /// </summary>
        public Cache(int maximumNumberOfElements)
        {
            this.maximumNumberOfElements = maximumNumberOfElements;
        }

        public void AddOrUpdate(TKey key, TValue value)
        {

        }
        
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            return false;
        }
    }

}