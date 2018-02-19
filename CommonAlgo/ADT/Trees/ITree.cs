using System;

namespace CommonAlgo.ADT.Trees
{
    public enum TraverseOrder : byte
    {
        PreOrder = 1,
        InOrder = 2,
        PostOrder = 3,
        InOrderReverse = 4
    }

    public interface ITree<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        void Traverse(TraverseOrder traverseOrder);
        void Add(TKey key, TValue item);
        void Remove(TValue item);
        TValue Find(TKey key);
        void Remove(TKey key);

        TKey GetMaximumKey();
        TKey GetMinimumKey();
        TValue GetMinimumValue();
        TValue GetMaximumValue();

        TKey Floor(TKey key); // нижняя опора
        TKey Ceil(TKey key); // нижняя опора

        void BFS();
        void DFS();
    }
}