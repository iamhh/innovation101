using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation101
{
    class Robot
    {
        private System_setting system_Setting = null;

        public Robot(System_setting system_Setting)
        {
            this.system_Setting = system_Setting;
            //this.system_Setting.button_Switch_Click(null, null);
        }

        public void up()
        {
            this.system_Setting.send("A30B");
        }

        public void down()
        {
            this.system_Setting.send("A50B");
        }

        public void left()
        {
            this.system_Setting.send("A70B");
        }

        public void right()
        {
            this.system_Setting.send("A90B");
        }

        public void leftup()
        {
            this.system_Setting.send("A110B");
        }

        public void leftdown()
        {
            this.system_Setting.send("A150B");
        }

        public void rightup()
        {
            this.system_Setting.send("A130B");
        }

        public void rightdown()
        {
            this.system_Setting.send("A170B");
        }

        public void stop()
        {
            this.system_Setting.send("A10B");
        }
    }
}
