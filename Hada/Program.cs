using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Program
    {
        static void Main(string[] args)
        {
            List<robot> robo = new List<robot>();
            Random random = new Random();

            int number = random.Next(10);

           
            for (int l = 0; l < number; l++)
            {
                var rob = new robot("robot: " + l.ToString());
                robo.Add(rob);
                rob.on();
                rob.createLowLightCondition();
                rob.createHighLightCondition();
                rob.createProximityCondition();
                rob.lightS.Level = random.Next(100);
                rob.proximityS.Proximity = random.Next(100);
            }
            Console.ReadLine();

        }
    }
}
