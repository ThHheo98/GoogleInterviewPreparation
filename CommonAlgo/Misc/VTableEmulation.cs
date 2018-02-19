using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public static class VTableHelper
    {
        public static readonly Dictionary<Type, Dictionary<string, Delegate>> VTable;

        static VTableHelper()
        {
            VTable = new Dictionary<Type, Dictionary<string, Delegate>>();
        }

        public static object InvokeMethod(this object item, string methodName, params object[] args)
        {
            Dictionary<string, Delegate> methods;
            if (!VTable.TryGetValue(item.GetType(), out methods))
                throw new Exception();
            Delegate dDelegate;
            if (!methods.TryGetValue(methodName, out dDelegate))
                throw new Exception();
            var objects = new List<object>(args);
            objects.Insert(0, item);
            return dDelegate.DynamicInvoke(objects.ToArray());
        }
    }

    public class Alpha
    {
        private int _value;

        static Alpha()
        {
            Action<Alpha> action = Test;
            VTableHelper.VTable.Add(typeof (Alpha), new Dictionary<string, Delegate>
            {
                {"TestIneffective", action}
            });
        }

        private static void Test(Alpha alpha)
        {
            int value = alpha._value;
        }

        private void Test()
        {
            int value = _value;
        }
    }

    public class Beta : Alpha
    {
        static Beta()
        {
            Action<Beta> action = Test;
            VTableHelper.VTable.Add(typeof (Beta), new Dictionary<string, Delegate>
            {
                {"TestIneffective", action}
            });
        }

        private static void Test(Beta beta)
        {
        }
    }

    [TestFixture]
    public class TestFixture
    {
        public void TestVTable()
        {
            Alpha alpha = new Beta();
            alpha.InvokeMethod("TestIneffective");
        }
    }
}