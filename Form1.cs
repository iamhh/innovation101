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
            System_setting system_Setting = new System_setting();
            this.topologyMap = new TopologyMapExample(system_Setting);
            this.gridMap = new GridMapExample();
            x = this.Width;
            y = this.Height;
            setTag(this);
            this.robot = new Robot(system_Setting);
        }

        private TopologyMapExample topologyMap;
        private GridMap gridMap;
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private Robot robot;

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }

        private void show_node_Click(object sender, EventArgs e)
        {
            int index=this.map_list.SelectedIndex;
            if(index==0){
                topologyMap.show_node(this.webBrowser);
            }else{
                gridMap.show_node(this.webBrowser);
            }
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
            int index = this.map_list.SelectedIndex;
            //topologyMap.test(this.use_test);
            if (index == 0)
            {
                //topologyMap.load_map(this.webBrowser);
                //topologyMap.show_node(this.webBrowser);
            }
            if (index == 1)
            {
                gridMap.load_map(this.webBrowser);
                //gridMap.show_node(this.webBrowser);
            }
        }

        private void show_com_path_Click(object sender, EventArgs e)
        {
            int index=this.map_list.SelectedIndex;
            if(index==0){
                topologyMap.show_com_path();
            }else{
                gridMap.showComPath();
            }
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

        private void show_navi_path_Click(object sender, EventArgs e)
        {
            int index = this.map_list.SelectedIndex;
            if (index == 0)
            {
                topologyMap.show_navigation_path();
            }
            else if (index == 1)
            {
                gridMap.show_grid(this.webBrowser);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }

        private void button4_Click(object sender, EventArgs e) //button4 robot up
        {
            robot.up();
        }

        private void button5_Click(object sender, EventArgs e) //button5 robot left
        {
            robot.left();
        }

        private void button6_Click(object sender, EventArgs e) //button6 robot right
        {
            robot.right();
        }

        private void button7_Click(object sender, EventArgs e) //button7 robot down
        {
            robot.down();
        }

        private void button10_Click(object sender, EventArgs e) //button10 robot stop
        {
            robot.stop(); 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            robot.rightup();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            robot.leftup();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            robot.leftdown();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            robot.rightdown();
        }
    }
}