using System.Collections.Generic;
using System.Threading;

namespace CommonAlgo.ADT.Stacks
{
    // Надо сделать очередь с операциями push(T) и T pop(). Операции должны поддерживать обращение с разных потоков. 
    // Операция push всегда вставляет и выходит. Операция pop ждет пока не появится новый элемент. 
    // В качестве контейнера внутри можно использовать только стандартную очередь (Queue).
    // Версия Никиты, задача из Касперского
    public class BlockingMyQueue<T>
    {
        #region Fields

        private readonly Queue<T> _queue1 = new Queue<T>();
        private readonly Queue<T> _queue2 = new Queue<T>();

        #endregion

        #region Methods

        public T Pop()
        {
            lock (_queue1)
            {
                while (_queue1.Count == 0)
                {
                    Monitor.Wait(_queue1);
                }
                return _queue1.Dequeue();
            }
        }

        public void Push(T data)
        {
            lock (_queue1)
            {
                if (_queue1.Count == 0)
                {
                    _queue1.Enqueue(data);
                }
                else
                {
                    while (_queue1.Count > 0)
                    {
                        _queue2.Enqueue(_queue1.Dequeue());
                    }
                    _queue1.Enqueue(data);
                    while (_queue2.Count > 0)
                    {
                        _queue1.Enqueue(_queue2.Dequeue());
                    }
                }
                Monitor.Pulse(_queue1);
            }
        }

        #endregion
    }


}