using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace innovation101
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.map_list = new System.Windows.Forms.ComboBox();
            this.use_test = new System.Windows.Forms.TextBox();
            this.load_map = new System.Windows.Forms.Button();
            this.show_node = new System.Windows.Forms.Button();
            this.show_path = new System.Windows.Forms.Button();
            this.show_com_path = new System.Windows.Forms.Button();
            this.restar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // map_list
            // 
            this.map_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.map_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.map_list.FormattingEnabled = true;
            this.map_list.Items.AddRange(new object[] {
            "拓扑地图",
            "栅格地图"});
            this.map_list.Location = new System.Drawing.Point(24, 36);
            this.map_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.map_list.Name = "map_list";
            this.map_list.Size = new System.Drawing.Size(179, 26);
            this.map_list.TabIndex = 1;
            this.map_list.SelectedIndexChanged += new System.EventHandler(this.map_list_SelectedIndexChanged);
            // 
            // use_test
            // 
            this.use_test.Location = new System.Drawing.Point(49, 31);
            this.use_test.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.use_test.Name = "use_test";
            this.use_test.Size = new System.Drawing.Size(429, 28);
            this.use_test.TabIndex = 2;
            this.use_test.Visible = false;
            // 
            // load_map
            // 
            this.load_map.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.load_map.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.load_map.Location = new System.Drawing.Point(213, 31);
            this.load_map.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.load_map.Name = "load_map";
            this.load_map.Size = new System.Drawing.Size(146, 37);
            this.load_map.TabIndex = 3;
            this.load_map.Text = "确认";
            this.load_map.UseVisualStyleBackColor = false;
            this.load_map.Click += new System.EventHandler(this.load_map_Click);
            // 
            // show_node
            // 
            this.show_node.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.show_node.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.show_node.Location = new System.Drawing.Point(194, 4);
            this.show_node.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.show_node.Name = "show_node";
            this.show_node.Size = new System.Drawing.Size(125, 42);
            this.show_node.TabIndex = 4;
            this.show_node.Text = "节点上线";
            this.show_node.UseVisualStyleBackColor = false;
            this.show_node.Click += new System.EventHandler(this.show_node_Click);
            // 
            // show_path
            // 
            this.show_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.show_path.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.show_path.Location = new System.Drawing.Point(17, 29);
            this.show_path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.show_path.Name = "show_path";
            this.show_path.Size = new System.Drawing.Size(176, 41);
            this.show_path.TabIndex = 5;
            this.show_path.Text = "生成导航地图";
            this.show_path.UseVisualStyleBackColor = false;
            this.show_path.Click += new System.EventHandler(this.show_path_Click);
            // 
            // show_com_path
            // 
            this.show_com_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_com_path.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.show_com_path.Location = new System.Drawing.Point(362, 4);
            this.show_com_path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.show_com_path.Name = "show_com_path";
            this.show_com_path.Size = new System.Drawing.Size(154, 42);
            this.show_com_path.TabIndex = 13;
            this.show_com_path.Text = "显示通信连接";
            this.show_com_path.UseVisualStyleBackColor = false;
            this.show_com_path.Click += new System.EventHandler(this.show_com_path_Click);
            // 
            // restar
            // 
            this.restar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.restar.Location = new System.Drawing.Point(261, 29);
            this.restar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.restar.Name = "restar";
            this.restar.Size = new System.Drawing.Size(117, 41);
            this.restar.TabIndex = 14;
            this.restar.Text = "重启";
            this.restar.UseVisualStyleBackColor = false;
            this.restar.Click += new System.EventHandler(this.restar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 42);
            this.button1.TabIndex = 15;
            this.button1.Text = "载入地图";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1581, 134);
            this.panel1.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.Controls.Add(this.show_com_path);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.show_node);
            this.panel6.Location = new System.Drawing.Point(48, 43);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(533, 59);
            this.panel6.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.Controls.Add(this.show_path);
            this.panel5.Controls.Add(this.restar);
            this.panel5.Location = new System.Drawing.Point(1065, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(432, 93);
            this.panel5.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.Controls.Add(this.map_list);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.load_map);
            this.panel4.Location = new System.Drawing.Point(610, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(374, 90);
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "选择地图模式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "导航模块";
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.webBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1581, 514);
            this.webBrowser.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1581, 514);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 532);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1581, 116);
            this.panel3.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "机器人控制";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(108, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "启动";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(108, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "移动速度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "当前坐标";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "x：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(408, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "y：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(359, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 28);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(437, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(33, 28);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(338, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 28);
            this.textBox3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "移动控制：";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button7);
            this.panel7.Controls.Add(this.button6);
            this.panel7.Controls.Add(this.button5);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(499, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(267, 110);
            this.panel7.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(136, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 36);
            this.button4.TabIndex = 11;
            this.button4.Text = "↑";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(94, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(36, 36);
            this.button5.TabIndex = 12;
            this.button5.Text = "←";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(178, 38);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(36, 36);
            this.button6.TabIndex = 13;
            this.button6.Text = "→";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(136, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(36, 36);
            this.button7.TabIndex = 14;
            this.button7.Text = "↓";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button8.Location = new System.Drawing.Point(1035, 69);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(133, 36);
            this.button8.TabIndex = 12;
            this.button8.Text = "系统设置";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1581, 648);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.use_test);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "基于物联网的应急导航系统";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox map_list;
        private System.Windows.Forms.TextBox use_test;
        private System.Windows.Forms.Button load_map;
        private System.Windows.Forms.Button show_node;
        private System.Windows.Forms.Button show_path;
        private System.Windows.Forms.Button show_com_path;
        private System.Windows.Forms.Button restar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
    }
}
