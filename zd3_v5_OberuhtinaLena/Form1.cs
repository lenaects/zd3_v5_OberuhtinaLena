using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd3_v5_OberuhtinaLena
{
    public partial class Form1 :Form
    {
        private List<MobileConnection> mobileconnectionlist;
        private List<MobileCommunicathionFee> mobilecommunicathionfeelist;
        private Dictionary<int, double> rezultQ;
        private Dictionary<int, double> rezultQp; 

        public Form1 ()
        {
            InitializeComponent();
            mobileconnectionlist = new List<MobileConnection>();
            mobilecommunicathionfeelist = new List<MobileCommunicathionFee>();
            rezultQ = new Dictionary<int, double>();
            rezultQp = new Dictionary<int, double>();
        }

        private void listBox2_SelectedIndexChanged (object sender, EventArgs e)
        {

        }

        private void Form1_Load (object sender, EventArgs e)
        {

        }

        private void button1_Click (object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
                MessageBox.Show("Заполните все поля!!!");
            else
            {int id = (int) numericUpDown1.Value;
            string name = textBox1.Text;
            int pricemin = (int) numericUpDown2.Value;
            double spuare = (double) numericUpDown3.Value;
            string speed = comboBox1.Text;
            if (MobileConnection.ID(mobileconnectionlist, id))
                MessageBox.Show("Мобильная связь с таким id уже существует");
            else if (MobileConnection.Names(mobileconnectionlist, name))
                MessageBox.Show("Мобильная связь с таким именем уже существует");
            else
            {
                MobileConnection mobileconnections = new MobileConnection(id, name, pricemin, spuare, speed);
                mobileconnectionlist.Add(mobileconnections);

                listBox1.Items.Add(mobileconnections.Print());
            }

            }
            
        }

        private void button2_Click (object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) MessageBox.Show("Выберите объект из списка");
            else
            { int index = listBox1.SelectedIndex;
            MobileConnection mobileconnection = mobileconnectionlist[index];
            if (rezultQ.ContainsKey(mobileconnection.Id))
            {
                rezultQ.Remove(mobileconnection.Id);
            }
            mobileconnectionlist.Remove(mobileconnection);
            listBox1.Items.RemoveAt(index);
                ObnovBaza();

            }
           
        }
        private void ObnovBaza()
        {
            listBox2.Items.Clear();
            foreach (KeyValuePair<int, double> result in rezultQ)
            {
                listBox2.Items.Add($"{result.Key}:{result.Value}");
            }
        }

        private void button5_Click (object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) MessageBox.Show("Выберите объект из списка");
            else
            {int index = listBox1.SelectedIndex;
            MobileConnection mobileconnection = mobileconnectionlist[index];

           if (rezultQ.ContainsKey(mobileconnection.Id))MessageBox.Show("Результат уже рассчитан для выбранного объекта");
            else
            {
             double rezult = mobileconnection.Q();
            rezultQ.Add(mobileconnection.Id, rezult);
            listBox2.Items.Add($"{mobileconnection.Id}:{rezult}");
            }
           

            }
            
        }

        private void button3_Click (object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == ""||comboBox2.Text=="")
                MessageBox.Show("Заполните все поля!!!");
            else
            {int id = (int) numericUpDown1.Value;
            string name = textBox1.Text;
            int pricemin = (int) numericUpDown2.Value;
            double spuare = (double) numericUpDown3.Value;
            string speed = comboBox1.Text;
            bool p;
            if (comboBox2.Text == "есть") p = true;
            else p=false;
            int user = (int)numericUpDown4.Value;
            if (MobileCommunicathionFee.ID(mobilecommunicathionfeelist, id))
                MessageBox.Show("Мобильная связь с таким id уже существует");
            else if (MobileCommunicathionFee.Names(mobilecommunicathionfeelist, name))
                MessageBox.Show("Мобильная связь с таким именем уже существует");
            else
            {
                MobileCommunicathionFee mobilecommunicathionfee = new MobileCommunicathionFee(id, name, pricemin, spuare, speed,p,user);
                    mobilecommunicathionfeelist.Add(mobilecommunicathionfee);

                listBox3.Items.Add(mobilecommunicathionfee.Print());
            }

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1) MessageBox.Show("Выберите объект из списка");
            else
            {int index = listBox3.SelectedIndex;
            MobileCommunicathionFee mobilecommunicathionfee = mobilecommunicathionfeelist[index];
            if (rezultQp.ContainsKey(mobilecommunicathionfee.Id))
            {
                rezultQp.Remove(mobilecommunicathionfee.Id);
            }
            mobilecommunicathionfeelist.Remove(mobilecommunicathionfee);
            listBox3.Items.RemoveAt(index);
            ObnovNasled();

            }
            
        }
        private void ObnovNasled()
        {
            listBox4.Items.Clear();
            foreach (KeyValuePair<int, double> result in rezultQp)
            {
                listBox4.Items.Add($"{result.Key}:{result.Value}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1) MessageBox.Show("Выберите объект из списка");
            else
            {int index = listBox3.SelectedIndex;
            MobileCommunicathionFee mobilecommunicathionfee = mobilecommunicathionfeelist[index];

            if (rezultQp.ContainsKey(mobilecommunicathionfee.Id))MessageBox.Show("Результат уже рассчитан для выбранного объекта");
                else
                { double rezult = mobilecommunicathionfee.Q();
                  rezultQp.Add(mobilecommunicathionfee.Id, rezult);
                 listBox4.Items.Add($"{mobilecommunicathionfee.Id}:{rezult}");

                }
           

            }
            
        }
    }
    
    
}
