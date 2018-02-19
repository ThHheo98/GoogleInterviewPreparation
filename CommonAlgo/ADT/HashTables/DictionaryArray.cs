using System;

namespace CommonAlgo.ADT.HashTables
{
    public sealed class DictionaryArray<TKey, TValue> where TKey : class, IComparable
    {
        private int _count;
        private TKey[] _keys;
        private int _size = 16;
        private TValue[] _values;

        public DictionaryArray()
        {
            _count = 0;
            _values = new TValue[_size];
            _keys = new TKey[_size];
        }

        public int Count
        {
            get { return _count; }
        }

        private int GetHash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff)%_size;
        }

        public void Add(TKey key, TValue value)
        {
            if (_count >= _size/2) Resize(2*_size);

            var hash = GetHash(key);
            int i;
            for (i = hash; _keys[i] != null; i = (i + 1)%_size)
            {
                if (_keys[i].Equals(key))
                {
                    _values[i] = value;
                    return;
                }
            }

            _keys[i] = key;
            _values[i] = value;

            _count++;
        }

        private void Resize(int newSize)
        {
            var v = new TValue[newSize];
            var k = new TKey[newSize];

            var t = newSize >= _size ? _size : newSize;
            for (var i = 0; i < t; i++)
            {
                v[i] = _values[i];
                k[i] = _keys[i];
            }
            _values = v;
            _keys = k;
            _size = newSize;
        }

        public void Delete(TKey key)
        {
            if (!Contains(key)) return;
            var i = GetHash(key);

            while (!key.Equals(_keys[i]))
            {
                i = (i + 1)%_size;
            }

            // remove element
            _keys[i] = default(TKey);
            _values[i] = default(TValue);

            // remove NULL values in _arrays
            i = (i + 1)%_size;
            while (_keys[i] != null)
            {
                var keyToRedo = _keys[i];
                var valueToRedo = _values[i];
                _keys[i] = default(TKey);
                _values[i] = default(TValue);
                _count--;
                Add(keyToRedo, valueToRedo);
                i = (i + 1)%_size;
            }
            _count--;
            if (_count > 0 && _count == _size/8) Resize(_size/2);
        }

        public bool Contains(TKey key)
        {
            var hash = GetHash(key);
            int i;
            for (i = hash; _keys[i] != null; i = (i + 1)%_size)
            {
                if (_keys[i].CompareTo(key) == 0)
                    return true;
            }
            return false;
        }

        public TValue Get(TKey key)
        {
            var hash = GetHash(key);
            for (var i = hash; _keys[i] != null; i = (i + 1)%_size)
            {
                if (_keys[i].Equals(key))
                {
                    return _values[i];
                }
            }
            return default(TValue);
        }
    }
}