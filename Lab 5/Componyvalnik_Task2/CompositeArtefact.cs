namespace DesignPatterns.Composite
{
    class CompositeArtefact : Artefact
    {
        private List<Artefact> _children = new List<Artefact>();
        public CompositeArtefact(string name, int weight, int powerBuf) : base(name, weight, powerBuf)
        {
        }

        public void AddArtefact(Artefact artefact)
        {
            this._children.Add(artefact);
       
        }

      
        public void RemoveArtefact(Artefact artefact)
        {
            this._children.Remove(artefact);
           
        }

        public override int GetWeight()
        {
            return this._children.Aggregate(this._weight, (sum, next) => sum += next.GetWeight());
        }

        public override int GetPowerBuf()
        {
            return this._children.Aggregate(this._powerBuf, (sum, next) => sum += next.GetPowerBuf());
        }

        public int GetCount()
     {
       return this._children.Aggregate(0, (sum, next) =>
       {
         int nextCount = 1;
         if (next is CompositeArtefact)
         {
           CompositeArtefact nextComposite = (CompositeArtefact)next;
           nextCount = nextComposite.GetCount();
         }
         return sum += nextCount;
       });
     }
    }
}