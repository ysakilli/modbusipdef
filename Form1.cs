using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;



namespace Modbusp
{
    public partial class Form1 : Form
    {
        string m;

        ModbusClient modbusClient = new ModbusClient("172.27.0.100 ", 502);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m = IPadressinput.Text;

            ModbusClient modbusClient = new ModbusClient( m, 502);

                       

            if (modbusClient.Connected)
            {

                modbusClient.Disconnect();

            }

            

            modbusClient.Connect();
                   
            Connectioncontroller();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            modbusClient.Disconnect();
            Connectioncontroller();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Checkcontroller();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            modbusClient.IPAddress = m;
           
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = modbusClient.IPAddress;
            
        }

        private void Connectioncontroller()
        {
            
                if (modbusClient.Connected)
            {
                textBox1.Text = "Connected";
                MessageBox.Show("Connected");
            }
            else
            {
                textBox1.Text = "Disconnected";
                MessageBox.Show("Disconnected");

            }

        }

        private void Checkcontroller()
        {
            IPadressinput.Enabled = checkBox1.Checked;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void IPadressinput_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
