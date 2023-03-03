using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    internal interface Iterator<T>
    {
        bool HasNext();
        T Next();
    }
}
