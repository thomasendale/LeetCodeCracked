using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.Generic
{
    public struct KeyValuePair<K,V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
    public class GenericHashTable<K,V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K,V>>[] items;
        public GenericHashTable(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValuePair<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int hashcode = key.GetHashCode()%size;
            return Math.Abs(hashcode);
        }
        public V Find (K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> list = GetLinkedList(position);
            foreach ( KeyValuePair<K,V> pair in list)
            {
                if(pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
            return default(V);
        }
        public void Add ( K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> list = GetLinkedList(position);
            KeyValuePair<K, V> kv = new KeyValuePair<K, V> { Key = key, Value = value };
            list.AddLast(kv);
            items[position] = list;
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> list = GetLinkedList(position);
            foreach ( KeyValuePair<K,V> pair in list)
            {
                if (pair.Key.Equals(key))
                {
                    list.Remove(pair);
                    items[position] = list;
                    break;
                }
            }
        } 
        public LinkedList<KeyValuePair<K,V>> GetLinkedList (int position)
        {
            LinkedList<KeyValuePair<K,V>> list= items[position];
            if( list==null)
            {
                list = new LinkedList<KeyValuePair<K,V>>();
                items[position]=list;
            }
            return list;
        }
    }
}
