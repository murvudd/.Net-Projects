using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Autostrada
    {
        public event EventHandler BrakPługów;
        private int _dstpPługi { get; set; }
        public int DostępnePługi {
            get { return _dstpPługi; }
            set { _dstpPługi = value; if (_dstpPługi== 0) BrakPługów(this, EventArgs.Empty); } }
        public int PługiNaAutostradzie { get; set; }
        public int WszystkiePługi { get; set; } 

        public Autostrada()
        {
            WszystkiePługi = 10;
            DostępnePługi = WszystkiePługi;
            PługiNaAutostradzie = 0;
            BrakPługów += Program.OnPług;
        }
        public void WyślijPługi(object sender, EventArgs e)
        {
            
            PługiNaAutostradzie += 1;
            DostępnePługi =WszystkiePługi - PługiNaAutostradzie;
        }
       
    }
}
