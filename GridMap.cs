using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation101
{
    interface GridMap
    {
        void load_map(System.Windows.Forms.PictureBox picture);
        void show_node(System.Windows.Forms.PictureBox picture);
        void show_path(System.Windows.Forms.PictureBox picture);
    }
}
