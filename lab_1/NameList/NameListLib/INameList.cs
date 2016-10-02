using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameListLib
{
    public interface INameList
    {
        void Add(string name);
        ArrayList GetNames();
        void Clear();
    }
}
