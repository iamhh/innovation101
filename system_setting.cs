using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Win32;


namespace innovation101
{
    public partial class System_setting : Form
    {
        private SerialPort ComDevice = new SerialPort();
        public byte Receive = 2;
        public byte Send = 1;
        public byte[] packet = new byte[1000];
        public int packetCount = 0;
        public byte lasech = 0;
        private double[] allData;

        public System_setting()
        {
            InitializeComponent();
            InitralConfig();
            //button_Switch_Click(null, null);
        }
        /// <summary>
        /// 从注册表获取系统串口列表
        /// </summary>
        public string[] GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                string[] str = new string[sSubKeys.Length];
                for (int i = 0; i < sSubKeys.Length; i++)
                {
                    str[i] = (string)keyCom.GetValue(sSubKeys[i]);
                }
                return str;
            }
            else
                return null;

        }
        /// <summary>
        /// 配置初始化
        /// </summary>
        private void InitralConfig()
        {
            string[] coms = GetComList();
            if (coms == null)
            {
                return;
            }
            for (int i = 0; i < coms.Length; i++)
            {
                if (ComDevice.IsOpen)
                {
                    ComDevice.Close();
                }
                comboBox_Port.Items.Add(coms[i]);
            }
            comboBox_Port.SelectedIndex = 0;
            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            //   ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }
        /// <summary>
        /// 一旦ComDevice.DataReceived事件发生，就将从串口接收到的数据显示到接收端对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sender"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!ComDevice.IsOpen)
            {
                MessageBox.Show("com not open");
                return;
            }
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //实现数据的解码与显示
            AddData(ReDatas);
        }

        /// <summary>
        /// 解码过程
        /// </summary>
        /// <param name="data">串口通信的数据编码方式因串口而异，需要查询串口相关信息以获取</param>
        public void AddData(byte[] data)
        {
            int i = 0;
            int len = data.Length;
            for (i = 0; i < len; i++)
            {
                if (data[i] == '\r' || data[i] == '\n')
                {
                    RefreshUI(Encoding.Default.GetString(packet));
                    this.allData=getAllDataA(Encoding.Default.GetString(packet));
                    //RefreshUI(string.Join("",packet));
                    //复位，重新接收
                    packetCount = 0;
                    //  Array.Clear(packet, 0, packet.Length);
                }
                else
                {
                    packet[packetCount] = data[i];
                    packetCount++;

                    if (packetCount >= 1000)
                    {
                        //复位，重新接收
                        packetCount = 0;
                        //  Array.Clear(packet, 0, packet.Length);
                    }
                    else
                    {
                        packet[packetCount] = 0;
                    }
                }
            }
        }

        public double[] getAllData()
        {
            while (this.allData == null)
            {

            }
            return this.allData;
        }

        public double[] getAllDataA(string s)
        {
            int n = 8;
            /*double[] data = new double[n * 4];//经纬度   温湿度
            int index = int.Parse(s.Substring(0, 1));
            index = index * 4;
            string[] strs = s.Split('#');
            if (data[index] == 0)
            {
                data[index++] = Double.Parse(strs[2]);
                data[index++] = Double.Parse(strs[1]);
                data[index++] = Double.Parse(strs[3]);
                data[index++] = Double.Parse(strs[4]);
;            }*/
            double[] data = new double[n * 4];
            string[] strs = s.Split(':');
            for (int i = 4, j = 1; i < data.Length&&j<strs.Length; i += 4, j += 2){
                char[] a = strs[j].ToCharArray();
                if(a[1]>='0'&&a[1]<='9') data[i + 2] = Double.Parse(strs[j].Substring(0,2));
                else data[i + 2] = Double.Parse(strs[j].Substring(0, 1));
                a = strs[j + 1].ToCharArray();
                if(a[1]>='0'&&a[1]<='9') data[i + 3] = Double.Parse(strs[j + 1].Substring(0,2));
                else data[i + 3] = Double.Parse(strs[j+1].Substring(0, 1));
            }
            return data;
        }

        private void RefreshUI(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                this.label_line1.Text = "";
                this.label_line2.Text = "";
                this.label_line3.Text = "";
                return;
            }

            string[] str1 = str.Split('#');

                //if (str1.Length == 0)
                if(true)
                {
                    this.label_line1.Text = str;
                    this.label_line2.Text = "";
                    this.label_line3.Text = "";
                }
                else if (str1.Length == 1)
                {
                    this.label_line1.Text = str1[0];                    
                    //this.label_line1.Text = str;
                    this.label_line2.Text = "";
                    this.label_line3.Text = "";
                }
                else if (str1.Length == 2)
                {
                    this.label_line1.Text = str1[0];
                    this.label_line2.Text = str1[1];
                    this.label_line3.Text = "";
                }
                else if (str1.Length >= 3)
                {
                    this.label_line1.Text = str1[0];
                    this.label_line2.Text = str1[1];
                    this.label_line3.Text = str1[2];
                }

        }

        /// <summary>
        /// 串口开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_Switch_Click(object sender, EventArgs e)
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }
            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                ComDevice.PortName = comboBox_Port.Text;
                ComDevice.BaudRate = 115200;
                ComDevice.Parity = (Parity)Convert.ToInt32("0");
                ComDevice.DataBits = 8;
                ComDevice.StopBits = (StopBits)Convert.ToInt32("1");
                try
                {
                    //开启串口
                    ComDevice.Open();
                    button_Send.Enabled = true;
                    button_Switch.Text = "关闭串口";
                    //注册COM口监听事件
                    ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    ComDevice.Close();
                    button_Send.Enabled = false;
                    //pictureBox1.Image = imageList1.Images[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_Switch.Text = "开启串口";
            }
            comboBox_Port.Enabled = !ComDevice.IsOpen;
        }
        /// <summary>
        /// 将消息编码并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Send_Click(object sender, EventArgs e)
        {
            string str = textBox_send.Text;

            if (string.IsNullOrEmpty(str))
            {
                return;
            };
            //RefreshUI(str);
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
            //RefreshUI(string.Join("", byteArray));
            SendData(byteArray);
        }

        public void send(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            };
            //RefreshUI(str);
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
            //RefreshUI(string.Join("", byteArray));
            SendData(byteArray);

        }

        /// <summary>
        /// 此函数将编码后的消息传递给串口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //将消息传递给串口
                    ComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void comboBox_Port_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
