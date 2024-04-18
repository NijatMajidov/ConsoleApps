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
        public T this[int index] { get { if (index >= _count) { Console.WriteLine("Index is greater than count"); } return _items[index]; } }

        public CustomList()
        {
            _items = new T[0];
            _count = 0;
        }

        public CustomList(int capacity)
        {
            if (capacity < 0) 
                Console.WriteLine("The capacity of the list cannot be negative");

            if (capacity == 0)
                _items = Array.Empty<T>();
            else
                _items = new T[capacity];
            _count = 0;
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
            for (int i = 0; i < _count / 2; i++)
            {
                T temp = _items[i];
                _items[i] = _items[_count - i - 1];
                _items[_count - i - 1] = temp;
            }
        }

        public void Reverse(int index, int count)
        {
            if (index < 0 || count < 0 || index + count > _count)
                throw new ArgumentOutOfRangeException();

            Array.Reverse(_items, index, count);
        }

        public T Find(Predicate<T> predicate)
        {
            for (int i = 0; i < _count; i++)
            {
                if (predicate(_items[i]))
                {
                    return _items[i];
                }
            }
            return default(T);
        }

        public CustomList<T> FindAll(Predicate<T> predicate)
        {
            CustomList<T> resultList = new CustomList<T>();

            for (int i = 0; i < _count; i++)
            {
                if (predicate(_items[i]))
                {
                    resultList.Add(_items[i]);
                }
            }

            return resultList;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_items, item, 0, _count);
            if (index < 0)
            {
                return false;
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _count--;
            return true; 
        }

        public int RemoveAll(Predicate<T> predicate)
        {
            int removedCount = 0;
            for (int i = 0; i < _count; i++)
            {
                if (predicate(_items[i]))
                {
                    for (int j = i; j < _count - 1; j++)
                    {
                        _items[j] = _items[j + 1];
                    }
                    _count--;
                    removedCount++;
                    i--; 
                }
            }
            return removedCount;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < _count; i++)
            {
                action(_items[i]);
            }
        }
        public void AddRange(List<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (_count == _items.Length)
                Array.Resize(ref _items, Math.Max(4, _items.Length * 2));

            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[index] = item;
            _count++;
        }

        public void InsertRange(int index, List<T> collection)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var itemsToAdd = collection.ToArray();
            if (_count + itemsToAdd.Length > _items.Length)
                Array.Resize(ref _items, Math.Max(4, _count + itemsToAdd.Length * 2));

            Array.Copy(_items, index, _items, index + itemsToAdd.Length, _count - index);
            Array.Copy(itemsToAdd, 0, _items, index, itemsToAdd.Length);
            _count += itemsToAdd.Length;
        }

        public T[] ToArray()
        {
            T[] array = new T[_count];
            Array.Copy(_items, array, _count);
            return array;
        }

        public void Sort()
        {
            Array.Sort(_items, 0, _count);
        }

        public T Min()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            return _items.Take(_count).Min();
        }

        public T Max()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            return _items.Take(_count).Max();
        }
        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _count);
        }

        public int LastIndexOf(T item)
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                    return i;
            }
            return -1;
        }
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
        }

        public T[] CopyTo()
        {
            var copy = new T[_count];
            Array.Copy(_items, copy, _count);
            return copy;
        }

        
    }
}
