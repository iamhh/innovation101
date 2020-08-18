using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Permissions;  //交互JS


namespace innovation101
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]//调用JS代码必要
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]


    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            this.topologyMap = new TopologyMapExample();
            this.gridMap = new GridMapExample();
        }

        private TopologyMap topologyMap;
        private GridMap gridMap;
        private int start_node;
        private int end_node;

        private void load_map_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            topologyMap.test(this.use_test);
            if (index == 0)
            {
                topologyMap.load_map(this.webBrowser);
            }
            else
            {
                gridMap.load_map(this.webBrowser);
            }
        }

        private void show_node_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.show_node(this.webBrowser);
            }
            else
            {
                gridMap.show_node(this.webBrowser);
            }
        }

        private void show_path_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.show_path(this.webBrowser, start_node, end_node);
            }
            else
            {
                gridMap.show_path(this.webBrowser, start_node, end_node);
            }
        }

        private void start_node_button_Click(object sender, EventArgs e)
        {
            start_node = int.Parse(this.start_node_text.Text);
        }

        private void end_node_button_Click(object sender, EventArgs e)
        {
            end_node = int.Parse(this.end_node_text.Text);
        }

        private void map_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}