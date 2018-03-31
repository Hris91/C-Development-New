using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> collection;
        private int currentIndex;

        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
            this.currentIndex = 0;
        }

        public bool HasIndex()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {         
            if (this.currentIndex < this.collection.Count - 1)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (!this.collection.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var t in this.collection)
            {
                yield return t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
