using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wintellect.PowerCollections;

namespace BiDictionary
{
    public class BiDictionary<Key1, Key2, Val> : IEnumerable<Val>
    {
        public BiDictionary()
        {
            this.CompleteDictionary = new MultiDictionary<Tuple<Key1, Key2>, Val>(true);
            this.FirstKeyDictionary = new MultiDictionary<Key1, Val>(true);
            this.SecondKeyDictionary = new MultiDictionary<Key2, Val>(true);
        }

        public int Count
        {
            get { return this.CompleteDictionary.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(Key1 key1, Key2 key2, Val item)
        {
            this.CompleteDictionary.Add(new Tuple<Key1, Key2>(key1, key2), item);
            this.FirstKeyDictionary.Add(key1, item);
            this.SecondKeyDictionary.Add(key2, item);
        }

        public void Clear()
        {
            this.CompleteDictionary = new MultiDictionary<Tuple<Key1, Key2>, Val>(true);
            this.FirstKeyDictionary = new MultiDictionary<Key1, Val>(true);
            this.SecondKeyDictionary = new MultiDictionary<Key2, Val>(true);
        }

        public bool Contains(Val item)
        {
            foreach (var prod in this.CompleteDictionary)
            {
                if (prod.Value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Val> FindByBothKeys(Key1 key1, Key2 key2)
        {
            var result = this.CompleteDictionary.Where(node => node.Key == new Tuple<Key1, Key2>(key1, key2)).SelectMany(node => node.Value);
            return result;
        }

        public IEnumerable<Val> FindByFirstKey(Key1 key1)
        {
            var result = this.FirstKeyDictionary.Where(node => node.Key.Equals(key1)).SelectMany(node => node.Value);
            return result;
        }

        public IEnumerable<Val> FindBySecondKey(Key2 key2)
        {
            var result = this.SecondKeyDictionary.Where(node => node.Key.Equals(key2)).SelectMany(node => node.Value);
            return result;
        }

        public IEnumerator<Val> GetEnumerator()
        {
            foreach (var item in this.CompleteDictionary)
            {
                foreach (var val in item.Value)
                {
                    yield return val;
                }
            }
        }

        public bool Remove(Val item)
        {
            bool deletedSomething = false;
            Tuple<Key1, Key2> keys = null;
            foreach (var prod in this.CompleteDictionary)
            {
                if (prod.Value.Equals(item))
                {
                    keys = prod.Key;
                    this.FirstKeyDictionary.Remove(keys.Item1);
                    this.SecondKeyDictionary.Remove(keys.Item2);
                    deletedSomething = true;
                    break;
                }
            }
            if (deletedSomething)
            {
                this.CompleteDictionary.Remove(keys);
            }
            return deletedSomething;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private MultiDictionary<Tuple<Key1, Key2>, Val> CompleteDictionary { get; set; }

        private MultiDictionary<Key1, Val> FirstKeyDictionary { get; set; }

        private MultiDictionary<Key2, Val> SecondKeyDictionary { get; set; }
    }
}