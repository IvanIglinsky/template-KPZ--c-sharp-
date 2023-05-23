using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Iterator
{
    public abstract class NodeIterator : IEnumerator<LightNode>
    {
        public LightNode? Current => CurrentNode();

        object? IEnumerator.Current => CurrentNode();

        public abstract LightNode? CurrentNode();
        public abstract void Dispose();

        public abstract bool MoveNext();

        public abstract void Reset();
    }
}
