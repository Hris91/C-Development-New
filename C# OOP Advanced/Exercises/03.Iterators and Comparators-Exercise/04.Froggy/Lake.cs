using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private IList<int> rocks;

        public Lake(IList<int> rocks)
        {
            this.rocks = rocks;
            this.rocks.Insert(0, 0);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i < this.rocks.Count; i++)
            {
                if (i % 2 != 0)
                {
                    yield return this.rocks[i];
                }   
            }
            for (int i = this.rocks.Count - 1; i >= 1; i--)
            {
                if (i % 2 == 0)
                {
                    yield return this.rocks[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
