using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Blocklist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Start button
        private void button1_Click_1(object sender, EventArgs e)
        {
            // List of second level domains: google.com match.com bbc.com
            List<string> goodAddresses = new List<string>();

            // Make a list of addresses
            var addressList = richTextBox1.Text.Split('\n').ToList();

            // Remove subdomain related stuff
            foreach (var address in addressList)
            {
                var temp = address;
                // sub1.sub2.google.com to google.com
                while (temp.Count(t => t== '.') > 1)
                {
                    temp = temp.Remove(0, temp.IndexOf('.') + 1);
                }

                goodAddresses.Add(temp);
            }

            StringBuilder SB = new StringBuilder();
            // Remove duplicates with disting().tolist()
            foreach (var address in goodAddresses.Distinct().ToList())
            {
                SB.AppendLine(address);
            }
            richTextBox2.Text = SB.ToString();
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;
        }
    }
}
