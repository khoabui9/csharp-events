using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{

    public class LowLightArgs : EventArgs
    {
        public float level;
        //private lightsensor ls;
        //private lightsensor ls;

        public LowLightArgs(float ls)
        {
            this.level = ls;
        }
        public float Level { get { return level; } }
    }


    public class HighLightArgs : EventArgs
    {
        public float level;
        //private lightsensor ls;

        public HighLightArgs(float ls)
        {
            this.level = ls;
        }
        public float Level { get { return level; } }
    }

    public  class lightsensor : FlipFlop
    {
        //private string sensorname;
        private float minLevel;
        private float maxLevel;
        public float level;
        


        public lightsensor(string n, float l, float minl, float maxl) : base(n)
        {
            name = n;
            minLevel = minl;
            maxLevel = maxl;
            //if (l < minLevel)
            //    level = minLevel;
            //else if (l > maxLevel)
            //    level = maxl;
            //else
            level = l;
            
        }
        
        public float Level
        {
            get { return level; } 
            set
            {
                level = value;
                if (level < minLevel)
                {
                    if (lowLightCondition != null)
                        lowLightCondition(this, new LowLightArgs(level));
                }
                if (level > maxLevel)
                {
                    if (highLightCondition != null)
                        highLightCondition(this, new HighLightArgs(level));
                }
            }
        }    

        public event EventHandler<LowLightArgs> lowLightCondition;
        public event EventHandler<HighLightArgs> highLightCondition;
    }
}
