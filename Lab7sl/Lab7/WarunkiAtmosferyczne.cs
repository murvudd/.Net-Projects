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
        public event EventHandler IntensywneOpadyŚnegu;
        public event EventHandler SilnyWiatr;
        public event EventHandler Upał;

        private int _wiatr {get; set;}
        public int Wiatr {
            get { return _wiatr; }
            set { if ((_wiatr += value) >= 0) _wiatr += value;
                if (_wiatr >= 50) OnWiatr(); } }

        private int _deszcz { get; set; }
        public int OpadyDeszczu {
            get { return _deszcz; }

            set { _deszcz = value; } }

        private int _śnieg { get; set; }
        public int OpadyŚniegu {
            get { return _śnieg; }
            set { _śnieg = value; if (_śnieg >= 50) OnŚnieg() ; } }

        private int _temp { get; set; }
        public int Temperatura { get; set; }

        protected void OnUpał()
        {
            if (Upał != null) Upał(this, EventArgs.Empty);
        }

        protected void OnŚnieg()
        {
            if (IntensywneOpadyŚnegu != null) IntensywneOpadyŚnegu(this, EventArgs.Empty);
        }

        protected void OnDeszcz()
        {
            if (IntensywneOpadyDeszczu!= null) IntensywneOpadyDeszczu(this, EventArgs.Empty);
        }

        protected void OnWiatr()
        {
            if (SilnyWiatr != null) SilnyWiatr(this, EventArgs.Empty);
        }
    }
}
