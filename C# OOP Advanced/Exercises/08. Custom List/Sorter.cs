using System;
using System.Linq;

namespace _08.Custom_List
{
    public static class Sorter
    {
        public static CustumList<T> Sort<T>(CustumList<T> custumList)
            where T : IComparable<T>
        {
            var temp = custumList.ListOfElements.OrderBy(x => x);
            CustumList<T> list = new CustumList<T>(temp);
            return list;
        }
    }
}