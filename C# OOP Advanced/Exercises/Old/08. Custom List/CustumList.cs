using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.Custom_List
{
    public class CustumList<T> : ICustumList<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly IList<T> listOfElements;

        public CustumList()
            : this(Enumerable.Empty<T>())
        {
        }

        public CustumList(IEnumerable<T> collection)
        {
            this.listOfElements = new List<T>(collection);
        }

        public IList<T> ListOfElements
        {
            get { return this.listOfElements; }
        }

        public void Add(T element) => this.listOfElements.Add(element);

        public T Remove(int index)
        {
            T temp = this.listOfElements[index];
            this.listOfElements.RemoveAt(index);
            return temp;
        }

        public bool Contains(T element) => this.listOfElements.Contains(element);

        public void Swap(int index1, int index2)
        {
            var temp = this.listOfElements[index1];
            this.listOfElements[index1] = this.listOfElements[index2];
            this.listOfElements[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            return this.listOfElements
                .Where(e => element.CompareTo(e) == -1)
                .ToList()
                .Count();
        }

        public T Max() => this.listOfElements.Max();

        public T Min() => this.listOfElements.Min();

        public void Print()
        {
            listOfElements
                .ToList()
                .ForEach(t => Console.WriteLine(t));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.listOfElements.GetEnumerator();
        }
    }
}