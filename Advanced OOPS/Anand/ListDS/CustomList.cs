using System;
using System.Collections.Generic;
namespace ListDS
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }
        public Type[] _array;
        public Type this[int index]
        {
            get { return _array[index]; } //gets the index value of an array
            set { _array[index] = value; } //sets value to the index

        }
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }
        public void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }
        // add  a range of values after the end of array position 
        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements._count + 4;
            Type[] temp = new Type[_capacity];
            int position = _count - 1;
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            int k = 0;
            for (int i = _count; i < _count + elements.Count; i++)
            {
                temp[i] = elements[k];
                k++;
            }
            _array = temp;
            _count = _count + elements._count;
        }
        public bool Contains(Type element)
        {
            bool temp = false;
            foreach (Type data in _array)
            {
                if (data.Equals(element))
                {
                    temp = true;
                    break;
                }
            }
            return temp;
        }
        public int IndexOf(Type element)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (element.Equals(_array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void Insert(int position, Type element)
        {
            _capacity = _capacity + 1 + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count + 1; i++)
            {
                if (i < position)
                {
                    temp[i] = _array[i];
                    i++;
                }

                else if (i == position)
                {
                    temp[i] = element;
                }

                else
                {
                    temp[i] = _array[i - 1]; //previous position of array values inserted after the value
                }
            }
            _count++;
            _array = temp;
        }
        public void InsertRange(int position, CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < position; i++)
            {
                temp[i] = _array[i];
            }
            int j = 0;
            for (int i = position; i < position + elements.Count; i++)
            {
                temp[i] = elements[j];
                j++;
            }
            int k = position;
            for (int i = position + elements.Count; i < _count + elements.Count; i++)
            {
                temp[i] = _array[k];
                k++;
            }
            _array = temp;
            _count = _count + elements.Count;
        }
        // removes the element using its position
        public void RemoveAt(int position)
        {
            for (int i = 0; i < _count - 1; i++)
            {
                //1,2,3,4,5
                //1,2,4,5
                // elements remain same before the position of the value;
                if (i >= position)
                {
                    _array[i] = _array[i + 1]; //replace elements after the position of removed element
                }
            }
            _count--;
        }
        // removes the element from the array
        public bool Remove(Type element)
        {
            int position = IndexOf(element);
            //1,2,3,4,5
            //1,2,4,5
            if (position >= 0)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }
        public void Reverse()
        {
            Type[] temp = new Type[_capacity];
            int j = 0;
            for (int i = _count - 1; i >= 0; i--)
            {
                temp[j] = _array[i];
                j++;
            }
            _array = temp;
        }
        public void Sort()
        {
            for (int i = 0; i < _count; i++)
            {
                for (int j = 0; j < _count; j++)
                {
                    if (IsGreater(_array[j], _array[j + 1]))
                    {
                        Type temp = _array[j + 1];
                        _array[j + 1] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }
        public bool IsGreater(Type value1, Type value2)
        {
            int result = Comparer<Type>.Default.Compare(value1, value2);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

    }
}
