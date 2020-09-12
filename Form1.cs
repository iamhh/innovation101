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

        private void load_map_Click(object sender, EventArgs e)  //text“载入地图”->“确认”
        {
            int index = this.map_list.SelectedIndex;
            topologyMap.test(this.use_test);
            if (index == 0)
            {
                //topologyMap.load_map(this.webBrowser);
                //topologyMap.show_node(this.webBrowser);
            }
            if (index == 1)
            {
                gridMap.load_map(this.webBrowser);
            }

        }

        private void show_node_Click(object sender, EventArgs e)
        {
            topologyMap.show_node(this.webBrowser);
        }

        private void show_path_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.show_path(this.webBrowser);
            }
            else if (index == 1)
            {
                gridMap.show_path(this.webBrowser);
            }
        }

        private void map_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void show_com_path_Click(object sender, EventArgs e)
        {
            topologyMap.show_com_path();
        }

        private void restar_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.fresh_node();
            }
            else if (index == 1)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)  //新增载入地图
        {
            topologyMap.load_map(this.webBrowser);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            System_setting st = new System_setting();
            st.ShowDialog();
        }
    }
}