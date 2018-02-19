using System;
using System.Collections.Generic;

namespace CommonAlgo.ADT.HashTables
{
    public sealed class DictionaryLinkedList<TKey, TValue>
    {
        private const int TableLength = 997;
        private readonly List<Node>[] _values;

        public DictionaryLinkedList()
        {
            _values = new List<Node>[TableLength];
            for (int i = 0; i < TableLength; i++)
            {
                _values[i] = new List<Node>();
            }
        }

        public void Add(TKey key, TValue value)
        {
            int hashCode = PrepareKey(key);
            foreach (Node node in _values[hashCode])
            {
                if (node._key.Equals(hashCode))
                {
                    _values[hashCode].Remove(node);
                }
            }
            _values[hashCode].Add(new Node {_value = value, _key = key});
        }

        private int PrepareKey(TKey key)
        {
            int hashCode = key.GetHashCode();
            hashCode = hashCode & int.MaxValue;
            hashCode = hashCode%TableLength;
            return hashCode;
        }

        public bool Contains(TKey key)
        {
            int code = PrepareKey(key);
            foreach (Node t in _values[code])
            {
                if (t._key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }


        public TValue Find(TKey key)
        {
            int code = PrepareKey(key);
            Node find = _values[code].Find(node => node._key.Equals(key));
            if (find == null)
                throw new ElementNotFoundException("Element not found!");
            return find._value;
        }

        public class ElementNotFoundException : Exception
        {
            public ElementNotFoundException(string message) : base(message)
            {
            }
        }

        private class Node
        {
            public TKey _key;
            public TValue _value;
        }
    }
}