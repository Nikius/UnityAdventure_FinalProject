namespace _Project.Develop.Runtime.Utilities
{
    public class Buffer<T>
    {
        public readonly T[] Items;
        public int Count;

        public Buffer(int initialSize)
        {
            Items = new T[initialSize];
            Count = 0;
        }
    }
}