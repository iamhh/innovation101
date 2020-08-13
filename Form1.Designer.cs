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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.map_list = new System.Windows.Forms.ComboBox();
            this.use_test = new System.Windows.Forms.TextBox();
            this.load_map = new System.Windows.Forms.Button();
            this.show_node = new System.Windows.Forms.Button();
            this.show_path = new System.Windows.Forms.Button();
            this.start_node_text = new System.Windows.Forms.TextBox();
            this.end_node_text = new System.Windows.Forms.TextBox();
            this.start_node_button = new System.Windows.Forms.Button();
            this.end_node_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Location = new System.Drawing.Point(41, 109);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1104, 386);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // map_list
            // 
            this.map_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.map_list.FormattingEnabled = true;
            this.map_list.Items.AddRange(new object[] {
            "拓扑地图",
            "栅格地图"});
            this.map_list.Location = new System.Drawing.Point(126, 50);
            this.map_list.Name = "map_list";
            this.map_list.Size = new System.Drawing.Size(121, 23);
            this.map_list.TabIndex = 1;
            this.map_list.SelectedIndexChanged += new System.EventHandler(this.map_list_SelectedIndexChanged);
            // 
            // use_test
            // 
            this.use_test.Location = new System.Drawing.Point(413, 45);
            this.use_test.Name = "use_test";
            this.use_test.Size = new System.Drawing.Size(100, 25);
            this.use_test.TabIndex = 2;
            // 
            // load_map
            // 
            this.load_map.Location = new System.Drawing.Point(1179, 155);
            this.load_map.Name = "load_map";
            this.load_map.Size = new System.Drawing.Size(105, 56);
            this.load_map.TabIndex = 3;
            this.load_map.Text = "载入地图";
            this.load_map.UseVisualStyleBackColor = true;
            this.load_map.Click += new System.EventHandler(this.load_map_Click);
            // 
            // show_node
            // 
            this.show_node.Location = new System.Drawing.Point(1184, 258);
            this.show_node.Name = "show_node";
            this.show_node.Size = new System.Drawing.Size(99, 58);
            this.show_node.TabIndex = 4;
            this.show_node.Text = "显示节点";
            this.show_node.UseVisualStyleBackColor = true;
            this.show_node.Click += new System.EventHandler(this.show_node_Click);
            // 
            // show_path
            // 
            this.show_path.Location = new System.Drawing.Point(1189, 359);
            this.show_path.Name = "show_path";
            this.show_path.Size = new System.Drawing.Size(94, 56);
            this.show_path.TabIndex = 5;
            this.show_path.Text = "生成路径";
            this.show_path.UseVisualStyleBackColor = true;
            this.show_path.Click += new System.EventHandler(this.show_path_Click);
            // 
            // start_node_text
            // 
            this.start_node_text.Location = new System.Drawing.Point(680, 38);
            this.start_node_text.Name = "start_node_text";
            this.start_node_text.Size = new System.Drawing.Size(104, 25);
            this.start_node_text.TabIndex = 7;
            this.start_node_text.Text = "开始节点";
            // 
            // end_node_text
            // 
            this.end_node_text.Location = new System.Drawing.Point(1043, 38);
            this.end_node_text.Name = "end_node_text";
            this.end_node_text.Size = new System.Drawing.Size(135, 25);
            this.end_node_text.TabIndex = 9;
            this.end_node_text.Text = "终止节点";
            // 
            // start_node_button
            // 
            this.start_node_button.Location = new System.Drawing.Point(821, 26);
            this.start_node_button.Name = "start_node_button";
            this.start_node_button.Size = new System.Drawing.Size(83, 35);
            this.start_node_button.TabIndex = 10;
            this.start_node_button.Text = "确定";
            this.start_node_button.UseVisualStyleBackColor = true;
            this.start_node_button.Click += new System.EventHandler(this.start_node_button_Click);
            // 
            // end_node_button
            // 
            this.end_node_button.Location = new System.Drawing.Point(1206, 32);
            this.end_node_button.Name = "end_node_button";
            this.end_node_button.Size = new System.Drawing.Size(105, 33);
            this.end_node_button.TabIndex = 11;
            this.end_node_button.Text = "确定";
            this.end_node_button.UseVisualStyleBackColor = true;
            this.end_node_button.Click += new System.EventHandler(this.end_node_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1351, 549);
            this.Controls.Add(this.end_node_button);
            this.Controls.Add(this.start_node_button);
            this.Controls.Add(this.end_node_text);
            this.Controls.Add(this.start_node_text);
            this.Controls.Add(this.show_path);
            this.Controls.Add(this.show_node);
            this.Controls.Add(this.load_map);
            this.Controls.Add(this.use_test);
            this.Controls.Add(this.map_list);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "innovation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox map_list;
        private System.Windows.Forms.TextBox use_test;
        private System.Windows.Forms.Button load_map;
        private System.Windows.Forms.Button show_node;
        private System.Windows.Forms.Button show_path;
        private System.Windows.Forms.TextBox start_node_text;
        private System.Windows.Forms.TextBox end_node_text;
        private System.Windows.Forms.Button start_node_button;
        private System.Windows.Forms.Button end_node_button;
    }
}

