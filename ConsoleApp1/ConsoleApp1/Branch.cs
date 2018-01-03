using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Branch
    {
        private string _outlook { get; set; }
        private string _temp { get; set; }
        private string _humidity { get; set; }        
        private string _play { get; set; }

        public string Outlook { get { return _outlook; }
             set { if (value == "Sunny"|| value == "Overcast" || value == "Rainy") { value = _outlook; } }
        }

        public string Temp { get { return _temp; }
            set {
                if (value == "Hot"|| value == "Mild"|| value =="Cold") value = _temp;
            }
        }

        public string Humidity { get { return _humidity; }
            set {
                if (value == "High"|| value =="Normal") value = _humidity;
            }
        }

        public bool Windy { get; set; }

        public bool Play { get; set; }


        public Branch()
        {

        }



    }
}
