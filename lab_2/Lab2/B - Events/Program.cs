using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /* Answers:
     * a) --> Implemented in code
     * b) You can't raise an event outside the class it was defined. Events are supposed to raise
     *    status changes from inside the class.
     */

    // this delegate is the base for the sliders move event
    delegate void MoveEventHandler(object source, MoveEventArgs e);

    // this class contains the arguments of the slider move event
    public class MoveEventArgs : EventArgs
    {
        private int newPos;
        private int origPos;

        public MoveEventArgs(int newPos, int origPos)
        {
            this.newPos = newPos;
            this.origPos = origPos;
        }

        public int NewPos { get { return newPos; } }
        public int OrigPos { get { return origPos; } }
    }

    class Form
    {
        static void Main()
        {
            Slider slider = new Slider();

            // Let's simulate some slider moves
            MoveSlider(slider, 19);
            MoveSlider(slider, 92);
            MoveSlider(slider, -20);
            MoveSlider(slider, -16);
            MoveSlider(slider, 100);

        }

        // this is the method that should be called when the slider is moved
        internal static void Slider_Move(object source, MoveEventArgs e)
        {
            if (!(e.NewPos >= 0 && e.NewPos <= 100))
            {
                // if the new position is not valid, restore it to the previous value
                if (source is Slider)
                {
                    // only cast if source is Slider or a subclass of it
                    ((Slider)source).Position = e.OrigPos;
                }
            }
        }

        static void MoveSlider(Slider s, int pos)
        {
            Console.WriteLine("Moving slider to position {0} | Previous value: {1}", pos, s.Position);
            s.Position = pos;
            Console.WriteLine("\t new position is {0}", s.Position);
        }
    }

    class Slider
    {
        public event MoveEventHandler Move;

        public Slider()
        {
            Move += Form.Slider_Move;
            Position = 0;
        }
        private int position;

        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                int origPos = Position;
                position = value; // might be restored in the event
                Move(this, new MoveEventArgs(value, origPos));
            }
        }
    }



} 
