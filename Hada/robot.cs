using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class robot : FlipFlop
    {
        public string robotName;
        public lightsensor lightS;
        public proximitysensor proximityS;


        public robot(string name) : base(name) {
            robotName = name;
        }
        public void on()
        {
            lightS = new lightsensor("light sensor", 50, 20, 70);
            proximityS = new proximitysensor("proximity sensor", 100, 20);
            statusChanged += itemStatusChanged;
            toggle();
        }
        public void off()
        {
            statusChanged += itemStatusChanged;
            toggle();
        }
        public void createLowLightCondition()
        { 
            lightS.lowLightCondition += onLowLight;
        }
        public void createHighLightCondition()
        {
            lightS.highLightCondition += onHighLight;
        }
        public void createProximityCondition()
        {
            proximityS.proximityCondition += onProximity;
        }
        private void onLowLight(object sender, LowLightArgs e)
        {
            lightsensor ls = (lightsensor)sender;

            Console.WriteLine("low-light alert");
            Console.WriteLine("light level: " + e.level);
        }
        private void onHighLight(object sender, HighLightArgs e)
        {
            lightsensor ls = (lightsensor)sender;

            Console.WriteLine("high-light alert");
            Console.WriteLine("light level: " + e.level);
        }
        private void onProximity(object sender, ProximityArgs e)
        {
            proximitysensor ps = (proximitysensor)sender;

            Console.WriteLine("proximity alert");
            Console.WriteLine("proximity level: " + e.Proximity);
        }

        private void itemStatusChanged(object sender, StatusChangeArgs e)
        {
            FlipFlop ff = (FlipFlop)sender;

            Console.WriteLine("Object [{0}] status changed to: [{1}].", ff.name, e.status);
        }
    }
}
