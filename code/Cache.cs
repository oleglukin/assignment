using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment
{
    public class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        private int maximumNumberOfElements;
        private List<Tuple<TKey, TValue, DateTime>> values;

        /// <summary>
        /// Cache constructor. Accepts maximum number of elements stored in the cache.
        /// </summary>
        public Cache(int maximumNumberOfElements)
        {
            this.maximumNumberOfElements = maximumNumberOfElements;
            this.values = new List<Tuple<TKey, TValue, DateTime>>();
        }


        /// <summary>
        /// Add new value to the cache or update existing one. Cache size cannot be larger than defined
        /// value of maximumNumberOfElements. If it reaches this maximum size then it should remove 
        /// the oldest (least recent) element.
        /// </summary>
        public void AddOrUpdate(TKey key, TValue value)
        {
            DateTime now = new DateTime();
            var element = values.Where(e => e.Item1.Equals(key)).FirstOrDefault();
            if (element != null)
            {
                values[values.FindIndex(e => e.Item1.Equals(key))] = Tuple.Create(key, value, now);
            }
            else if (values.Count < maximumNumberOfElements)
            {
                values.Add(Tuple.Create(key, value, now));
            }
            else
            {
                var minDateTime = values.Min(e => e.Item3);
                values.Remove(values.Where(e => e.Item3.Equals(minDateTime)).First());
                values.Add(Tuple.Create(key, value, now));
            }
        }


        /// <summary>
        /// Try to get cached value by key. Return true if it can find the value. Otherwise return false.
        /// </summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = values.Where(e => e.Item1.Equals(key)).FirstOrDefault();
            bool found = (element != null) ? true : false;
            value = (element != null) ? element.Item2 : default(TValue);
            return found;
        }
    }
}