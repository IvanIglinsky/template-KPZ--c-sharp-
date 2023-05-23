using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Strategy
{
    public interface IIteratorStrategy
    {
        public IEnumerator<LightNode> GetEnumerator(List<LightNode> collection);
    }
}
