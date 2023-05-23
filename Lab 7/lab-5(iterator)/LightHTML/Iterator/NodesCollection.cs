using lab_5.LightHTML.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Iterator
{
    public class NodesCollection : IteratorAggregate
    {
        private List<LightNode> _collection = new List<LightNode>();
        public IIteratorStrategy Strategy { get; set; } = new SurfaceStrategy();
        public List<LightNode> GetItems()
        {
            return _collection;
        }
        public void AddItem(LightNode node)
        {
            _collection.Add(node);
        }
        public override IEnumerator<LightNode> GetEnumerator()
        {
            return Strategy.GetEnumerator(_collection);
        }

    }
}
