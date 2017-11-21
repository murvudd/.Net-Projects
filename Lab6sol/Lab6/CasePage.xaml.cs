using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for CasePage.xaml
    /// </summary>

    class Case
    {
        public int? Year { get; set; }
        public int? Age { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Activity { get; set; }
        public string Sex { get; set; }
        public string Fatal { get; set; }
    }


    public partial class CasePage : Page
    {
        public CasePage()
        {
            InitializeComponent();

        }
    }
}
