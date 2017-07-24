using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;

namespace RelayControl
{
    public partial class Form1 : Form
    {
        relayBoard relay = new relayBoard();
        bool StatusOK = false;

        public Form1()
        {
            InitializeComponent();

            btn_relay1.Enabled = false;
            btn_relay2.Enabled = false;
            btn_relay3.Enabled = false;
            btn_relay4.Enabled = false;
            btn_relay1_off.Enabled = false;
            btn_relay2_off.Enabled = false;
            btn_relay3_off.Enabled = false;
            btn_relay4_off.Enabled = false;
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            StatusOK = relay.connect();
            if (StatusOK)
            {
                btn_find.Enabled = false;
                label1.Text = "Board Found";

                btn_relay1.Enabled = true;
                btn_relay2.Enabled = true;
                btn_relay3.Enabled = true;
                btn_relay4.Enabled = true;
                btn_relay1_off.Enabled = true;
                btn_relay2_off.Enabled = true;
                btn_relay3_off.Enabled = true;
                btn_relay4_off.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error connecting to relay board, please retry", "Connection Error");                   
                return;               
            }
         }
         
        private void btn_relay1_Click(object sender, EventArgs e)
        {           
            relay.RelaySwitch(Relaynum.ONE, Relaystate.ON);
            pictureBox1.BackColor = Color.Green;          
        }

        private void btn_relay2_Click(object sender, EventArgs e)
        {           
            relay.RelaySwitch(Relaynum.TWO, Relaystate.ON);
            pictureBox2.BackColor = Color.Green;
        }

        private void btn_relay3_Click(object sender, EventArgs e)
        {          
            relay.RelaySwitch(Relaynum.THREE, Relaystate.ON);
            pictureBox3.BackColor = Color.Green;
        }

        private void btn_relay4_Click(object sender, EventArgs e)
        {         
            relay.RelaySwitch(Relaynum.FOUR, Relaystate.ON);
            pictureBox4.BackColor = Color.Green;
        }

        private void btn_relay1_off_Click(object sender, EventArgs e)
        {
            relay.RelaySwitch(Relaynum.ONE, Relaystate.OFF);
            pictureBox1.BackColor = Color.Red;
        }

        private void btn_relay2_off_Click(object sender, EventArgs e)
        {
            relay.RelaySwitch(Relaynum.TWO, Relaystate.OFF);
            pictureBox2.BackColor = Color.Red;
        }

        private void btn_relay3_off_Click(object sender, EventArgs e)
        {
            relay.RelaySwitch(Relaynum.THREE, Relaystate.OFF);
            pictureBox3.BackColor = Color.Red;
        }

        private void btn_relay4_off_Click(object sender, EventArgs e)
        {
            relay.RelaySwitch(Relaynum.FOUR, Relaystate.OFF);
            pictureBox4.BackColor = Color.Red;
        }   
    }
}
