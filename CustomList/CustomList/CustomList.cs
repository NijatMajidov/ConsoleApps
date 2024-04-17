using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    internal class CustomList<T> 
    {
        private T[] _items;
        private int _count;
        public int Count { get { return _count; } }
        public int Capacity { get { return _items.Length; } }
        public T this[int index] { get {  return _items[index]; } }

        public CustomList()
        {
            _items = new T[0];
            _count = 0;
        }
        public CustomList(int capacity)
        {
            if (capacity < 0) 
                Console.WriteLine("ERROR");

            if (capacity == 0)
                _items = Array.Empty<T>();
            else
                _items = new T[capacity];
        }
        public void Add(T item)
        {
            if(_items.Length == 0) Array.Resize(ref _items, _items.Length+4);
            if(_count == _items.Length) Array.Resize(ref _items,_items.Length*2);
            _items[_count] = item;
            _count++;
        }

        public void Reverse()
        {
            int nullItemCount = _items.Length - Count;
            for (int i = _items.Length-(nullItemCount+1); i >= 0; --i)
            {
                Console.WriteLine(_items[i]);
            }
        }


        public void Remove(T item)
        {
            for(int i=0; i<Count; i++)
            {
                if()
            }
        }

        


    }
}
