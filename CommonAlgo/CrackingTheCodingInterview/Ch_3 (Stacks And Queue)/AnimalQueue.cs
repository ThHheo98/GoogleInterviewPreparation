using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class AnimalQueue
    {
        private readonly List<Cat> _cats = new List<Cat>();
        private readonly List<Dog> _dogs = new List<Dog>();
        private int _order;

        public int Count
        {
            get { return _dogs.Count + _cats.Count; }
        }

        public void Enqueue(Animal a)
        {
            a.Order = _order;
            _order++;

            if (a is Dog) _dogs.Add((Dog) a);
            else if (a is Cat) _cats.Add((Cat) a);
        }

        public Animal DequeueAny()
        {
            if (_dogs.Count == 0)
            {
                Cat t = _cats[0];
                _cats.Remove(t);
                return t;
            }

            if (_cats.Count == 0)
            {
                Dog t = _dogs[0];
                _dogs.Remove(t);
                return t;
            }

            Dog dog = _dogs[0];
            Cat cat = _cats[0];

            if (dog.IsOlderThan(cat))
            {
                _dogs.Remove(dog);
                return dog;
            }
            _cats.Remove(cat);
            return cat;
        }

        public Animal DequeueCats()
        {
            if (_cats.Count > 0)
            {
                Cat t = _cats[0];
                _cats.Remove(t);
                return t;
            }
            return null;
        }

        public Animal DequeueDogs()
        {
            if (_dogs.Count > 0)
            {
                Dog t = _dogs[0];
                _dogs.Remove(t);
                return t;
            }
            return null;
        }
    }
}