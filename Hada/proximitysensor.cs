using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    public class ProximityArgs : EventArgs
    {
        private float ps;

        public ProximityArgs(float ps)
        {
            this.ps = ps;
        }
        public float Proximity { get { return ps; } }
    }


    public class proximitysensor : FlipFlop
    {
        
        public float proximity;
        public float minp;
        public proximitysensor(string n, float p, float minp) : base(n) {
            name = n;
            proximity = p;
            this.minp = minp;
        }

        public float Proximity
        {
            get { return proximity; }
            set
            {
                proximity = value;
                if (proximity < minp)
                {
                    if (proximityCondition != null)
                        proximityCondition(this, new ProximityArgs(proximity));
                }
               
            }
        }

        public event EventHandler<ProximityArgs> proximityCondition;
    }
}
