using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameListLib
{
    public class NameList : INameList, IList
    {
        private ArrayList names = new ArrayList();

        public object this[int index]
        {
            get
            {
                return names[index];
            }

            set
            {
                names[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return names.Count;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Add(object value)
        {
            this.Add(value);
            return names.Count - 1;
        }

        public void Add(string name) => names.Add(name);
        public void Clear() => names.Clear();

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ArrayList GetNames()
        {
            ArrayList namesCpy = new ArrayList();
            namesCpy.AddRange(namesCpy);
            return namesCpy;
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
