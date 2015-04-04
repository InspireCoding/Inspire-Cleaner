using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Inspire_Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Clean.Fix.TMGR();
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            Clean.Fix.HOSTS();
        }

        private void monoFlat_Button3_Click(object sender, EventArgs e)
        {
            Clean.Fix.CMD();
        }

        private void monoFlat_Button4_Click(object sender, EventArgs e)
        {
            Clean.Fix.RE();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] running = Process.GetProcesses();

            foreach (Process process in running)
            {
                listBox1.Items.Add(process.ProcessName);
            }
        }

        public void RefreshProc()
        {
            listBox1.Items.Clear();

            Process[] running = Process.GetProcesses();

            foreach (Process process in running)
            {
                listBox1.Items.Add(process.ProcessName);
            }
        }

        private void monoFlat_Button6_Click(object sender, EventArgs e)
        {
            RefreshProc();
        }

        private void monoFlat_Button9_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(ProcessName.Text))
                    {
                        process.Kill();
                    }
                }

                RefreshProc();
            }
            catch
            {
                MessageBox.Show("Could not kill the selected process.", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("The process has been killed!", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void monoFlat_Button8_Click(object sender, EventArgs e)
        {
            Clean.BotKiller();
        }

        private void monoFlat_Button7_Click(object sender, EventArgs e)
        {

        }

        private void monoFlat_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=59VPBRNZZVTB6");
        }

        private void monoFlat_LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://pastebin.com/YQbjHZn4");
        }

        private void monoFlat_Button5_Click(object sender, EventArgs e)
        {
            Clean.Fix.Lua();
        }
    }
}
