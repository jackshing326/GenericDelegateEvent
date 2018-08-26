using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenericDelegateEvent
{
    public class GenericSetOne<T>
    {
        private List<T> GenericSetList = new List<T>();

        public void Add(T item)
        {
            GenericSetList.Add(item);
        }

        public bool Del(T item)
        {
            return GenericSetList.Remove(item);
        }

        public T Get(T item)
        {
            if (GenericSetList.Contains(item))
            {
                return item;
            }
            else
            {
                return default(T);
            }
        }

        public int GetCount()
        {
            return GenericSetList.Count;
        }
    }

    public class GenericSetTwo<T, R>
    {
        private Dictionary<T, R> GenericSetDictionary = new Dictionary<T, R>();

        public void Add(T item, R _r)
        {
            GenericSetDictionary.Add(item, _r);
        }

        public bool Del(T item)
        {
            return GenericSetDictionary.Remove(item);
        }

        public R Get(T item)
        {
            if (GenericSetDictionary.ContainsKey(item))
            {
                return GenericSetDictionary[item];
            }
            else
            {
                return default(R);
            }
        }

        public int GetCount()
        {

            return GenericSetDictionary.Count;

        }
    }

    public class Product
    {
        public int ItemNo;
        public float Price;
        public string Name;
    }

}
