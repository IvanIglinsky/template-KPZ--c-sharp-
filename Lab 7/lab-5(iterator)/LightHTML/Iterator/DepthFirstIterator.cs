using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Iterator
{
    public class DepthFirstIterator : NodeIterator
    {
        private Stack<LightNode> _stack;
        private LightNode? _current;
        public DepthFirstIterator(List<LightNode> collection)
        {

            _stack = new Stack<LightNode>();
            foreach (LightNode node in collection.Reverse<LightNode>())
            {
                _stack.Push(node);
            }
        }

        public override LightNode? CurrentNode() => _current;

        public override void Dispose()
        {
            _stack.Clear();
            _current = null;
        }

        public override bool MoveNext()
        {

            if (_stack.Count == 0)
            {
                _current = null;
                return false;
            }

            _current = _stack.Pop();
            foreach (var childNode in _current.Children)
            {
                _stack.Push(childNode);
            }
            return true;
        }

        public override void Reset()
        {
            _stack.Clear();
            _current = null;
        }
    }
}
