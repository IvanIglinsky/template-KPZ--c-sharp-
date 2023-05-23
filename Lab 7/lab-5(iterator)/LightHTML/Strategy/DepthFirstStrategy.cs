using lab_5.LightHTML.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Strategy
{
    public class DepthFirstStrategy : IIteratorStrategy
    {
        public IEnumerator<LightNode> GetEnumerator(List<LightNode> collection)
        {
            return new DepthFirstIterator(collection);
        }
    }
}
