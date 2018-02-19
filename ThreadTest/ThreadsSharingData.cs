using System;
using System.Threading;

namespace ThreadTest
{
    public class ThreadsSharingData
    {
        private int _flag;
        private int _value;


        public void Thread1()
        {
            _value = 5;
            // Writes the specified value to the specified field. On systems that require it, 
            // inserts a memory barrier that prevents the processor from reordering memory operations as follows: 
            // If a read or write appears before this method in the code,
            // the processor cannot move it after this method.
            Volatile.Write(ref _flag, 1);
//            Thread.VolatileWrite(ref _flag, 1);
        }

        public void Thread2()
        {
            // Reads the value of the specified field. On systems that require it, 
            // inserts a memory barrier that prevents the processor 
            // from reordering memory operations as follows: 
            // If a read or write appears after this method in the code,
            // the processor cannot move it before this method.
            if (Volatile.Read(ref _flag) == 1)
            //if (Thread.VolatileRead(ref _flag) == 1)
            {
                Console.WriteLine(_value);
            }
        }
    }
}