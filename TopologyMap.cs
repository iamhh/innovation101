using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation101
{
    interface TopologyMap
    {
        void load_map(System.Windows.Forms.WebBrowser webBrowser);
        void show_node(System.Windows.Forms.WebBrowser webBrowser);
        void show_path(System.Windows.Forms.WebBrowser webBrowser);
        void test(System.Windows.Forms.TextBox use_test);
        void show_com_path();
        void fresh_node();
    }
}