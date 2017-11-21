using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class WarunkiAtmosferyczne 
    {
        public event EventHandler IntensywneOpadyDeszczu;
        public event EventHandler IntensywneOpadyŚniegu;
        public event EventHandler SilnyWiatr;
        public event EventHandler Upał;
        

        public WarunkiAtmosferyczne()
        {
            IntensywneOpadyŚniegu += Program.OnŚnieg;
            IntensywneOpadyDeszczu += Program.OnDeszcz;
            SilnyWiatr += Program.OnWiatr;
            Upał += Program.OnUpał;
        }
        private int _wiatr {get; set;}
        public int Wiatr {
            get { return _wiatr; }
            set { if ((_wiatr += value) >= 0) _wiatr = value;
                if (_wiatr >= 50) SilnyWiatr(this, EventArgs.Empty); } }

        private int _deszcz { get; set; }
        public int OpadyDeszczu {
            get { return _deszcz; }
            set { _deszcz = value; if (_deszcz >= 250) IntensywneOpadyDeszczu(this, EventArgs.Empty); } }

        private int _śnieg { get; set; }
        public int OpadyŚniegu {
            get { return _śnieg; }
            set { _śnieg = value; if (_śnieg >= 100) IntensywneOpadyŚniegu(this,EventArgs.Empty) ; } }

        private int _temp { get; set; }
        public int Temperatura {
            get { return _temp; }
                 set { _temp = value; if(_temp>=60) Upał(this,EventArgs.Empty); } }

        //public void OnUpał(object sender, EventArgs e)
        //{
        //    Console.WriteLine("on temp");
        //}

        //public void OnŚnieg(object sender, EventArgs e)
        //{
        //    Console.WriteLine("ON Śnieg");
        //}

        //public void OnDeszcz(object sender, EventArgs e)
        //{
        //    Console.WriteLine("On Deszcz");
        //}

        //public void OnWiatr(object sender, EventArgs e)
        //{
        //    Console.WriteLine("on wiatr");
        //}
    }
}
