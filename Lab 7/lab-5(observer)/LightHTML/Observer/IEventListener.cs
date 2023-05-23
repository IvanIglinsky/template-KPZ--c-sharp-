using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Observer
{
    public interface IEventListener
    {
        public void Update(LightNode node);
    }
}
