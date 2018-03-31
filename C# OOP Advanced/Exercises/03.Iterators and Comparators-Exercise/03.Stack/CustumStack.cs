using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class CustumStack : IEnumerable<int>
    {
        private IList<int> data;

        public CustumStack()
        {
            this.data = new List<int>();
        }

        public void Push(int[] input)
        {
            foreach (var element in input)
            {
                this.data.Add(element);
            }
        }

        public int Pop()
        {
            if (!this.data.Any())
            {
                throw new InvalidOperationException("No elements");
            }

            var lastElement = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);

            return lastElement;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
