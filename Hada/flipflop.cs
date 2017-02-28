using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    // Special EventArgs class to hold info about status changes.
    public class StatusChangeArgs : EventArgs
    {
        private FlipFlop.Status s;
        

        public StatusChangeArgs(FlipFlop.Status s)
        {
            this.s = s;
        }

        public FlipFlop.Status status { get { return s; } }
    }

    /**
     * Representa el rol de algo que puede cambiar de estado.
     *
     * Para ello emplea el metodo abstracto "toggle".
     */
    public abstract class FlipFlop
    {
        public enum Status { off, on }

        public FlipFlop(string n = " --- ")
        {
            rg = new Random();
            setRandomStatus();
            name = n;
        }


        ////////////////
        // Properties //
        ////////////////
        public string name { get; set; }

        public Status status
        {
            get { return st; }
            set
            {
                st = value;

                if (statusChanged != null)
                    statusChanged(this, new StatusChangeArgs(st));
            }
        }

        public void toggle()
        {
            if (status == Status.on)
                status = Status.off;
            else
                status = Status.on;
        }

        public void setRandomStatus()
        {
            if (rg.Next(2) == 0)
                status = Status.off;
            else
                status = Status.on;
        }

        public void showStatus()
        {
            Console.WriteLine("Status is {0}.", st);
        }

        // The event. Note that by using the generic EventHandler<T> event type
        // we do not need to declare a separate delegate type.
        public event EventHandler<StatusChangeArgs> statusChanged;

        private Status st;
        private Random rg;
    }
}

