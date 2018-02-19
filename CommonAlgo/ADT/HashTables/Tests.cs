using System;
using NUnit.Framework;

namespace CommonAlgo.ADT.HashTables
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DictiionaryLinkedListTest()
        {
            var n = new DictionaryLinkedList<CustomKeyBrokenHash, string>();
            n.Add(new CustomKeyBrokenHash("key1"), "str0");
            n.Add(new CustomKeyBrokenHash("key2"), "str1");
            var customKeyBrokenHash = new CustomKeyBrokenHash("key3");
            n.Add(customKeyBrokenHash, "str2");

            bool contains = n.Contains(customKeyBrokenHash);
            Assert.IsTrue(contains);
        }

        [Test]
        public void DictionaryArrayest()
        {
            var n = new DictionaryArray<CustomKeyBrokenHash, string>();
            const int cnt = 100;
            for (int i = 0; i < cnt; i++)
            {
                n.Add(new CustomKeyBrokenHash("key" + i), "val" + i);
            }
            Assert.IsTrue(n.Count == cnt);

            for (int i = 0; i < cnt; i++)
            {
                Assert.IsTrue(n.Contains(new CustomKeyBrokenHash("key" + i)));
            }

            for (int i = cnt - 1; i >= 1; i--)
            {
                n.Delete(new CustomKeyBrokenHash("key" + i));
            }
            Assert.IsTrue(n.Count == 1);

            Assert.True(n.Contains(new CustomKeyBrokenHash("key" + 0)));
            n.Delete(new CustomKeyBrokenHash("key" + 0));
            Assert.IsTrue(n.Count == 0);
        }

        [Test]
        public void HashOverflowTest()
        {
            unchecked
            {
                int i = 0x7fffffff + 10;
                Console.WriteLine(i.ToString());
            }

            // var d = new Dictionary<string, string>();
            // int num1 = this.comparer.GetHashCode(key) & int.MaxValue;
        }


        [Test]
        public void StringHashingTest()
        {
            var c = new StringEmulHash("Test");
            int hashCode = c.GetHashCode();
            Console.WriteLine(hashCode);
        }
    }

    public class StringEmulHash
    {
        private readonly char[] _c;

        public StringEmulHash(string c)
        {
            _c = new char[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                _c[i] = c[i];
            }
        }

        public override int GetHashCode()
        {
            int h = 17;
            for (int i = 0; i < _c.Length; i++)
            {
                h = (31*h) + _c[i];
            }

            return h;
        }
    }

    public class CustomKeyBrokenHash : IComparable<CustomKeyBrokenHash>, IComparable
    {
        private readonly string _key;

        public CustomKeyBrokenHash(string key1)
        {
            _key = key1;
        }

        int IComparable.CompareTo(object obj)
        {
            return CompareTo((CustomKeyBrokenHash) obj);
        }

        public int CompareTo(CustomKeyBrokenHash other)
        {
            return String.Compare(_key, other._key, StringComparison.Ordinal);
        }

        private bool Equals(CustomKeyBrokenHash other)
        {
            return _key.Equals(other._key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CustomKeyBrokenHash) obj);
        }

        public override int GetHashCode()
        {
            return 3; // Test
        }
    }
}