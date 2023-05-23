namespace lab_5.LightHTML.Iterator
{
    public class BreadthFirstIterator : NodeIterator
    {
        private Queue<LightNode> _queue;
        private LightNode? _current;
        public BreadthFirstIterator(List<LightNode> collection)
        {
            _queue = new Queue<LightNode>();
            foreach (var node in collection)
            {
                _queue.Enqueue(node);
            }
        }
        public override LightNode? CurrentNode() => _current;

        public override void Dispose()
        {
            _queue.Clear();
            _current = null;
        }

        public override bool MoveNext()
        {
            if (_queue.Count == 0)
            {
                _current = null;
                return false;
            }

            _current = _queue.Dequeue();
            foreach (var childNode in _current.Children)
            {
                _queue.Enqueue(childNode);
            }
            return true;
        }

        public override void Reset()
        {
            _queue.Clear();
            _current = null;
        }
    }
}
