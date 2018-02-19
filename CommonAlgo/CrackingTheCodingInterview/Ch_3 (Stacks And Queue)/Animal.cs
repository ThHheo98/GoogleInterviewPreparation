namespace CommonAlgo.CrackingTheCodingInterview
{
    public abstract class Animal
    {
        private string _name;

        protected Animal(string name)
        {
            _name = name;
        }

        public int Order { get; set; }


        public bool IsOlderThan(Animal a)
        {
            return Order < a.Order;
        }
    }
}