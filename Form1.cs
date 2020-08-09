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


namespace innovation101
{

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
        private Node[] nodes;
        private int start_node;
        private int end_node;

        private void load_map_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.load_map(this.pictureBox);
            }
            else
            {
                gridMap.load_map(this.pictureBox);
            }
        }

        private void show_node_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.show_node(this.pictureBox);
            }
            else
            {
                gridMap.show_node(this.pictureBox);
            }
        }

        private void show_path_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.show_path(this.pictureBox,start_node,end_node);
            }
            else
            {
                gridMap.show_path(this.pictureBox,start_node,end_node);
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
