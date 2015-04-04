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
            Clean.Fix.enableTaskManager();
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            Clean.Fix.repairHOSTS();
        }

        private void monoFlat_Button3_Click(object sender, EventArgs e)
        {
            Clean.Fix.enableCMD();
        }

        private void monoFlat_Button4_Click(object sender, EventArgs e)
        {
            Clean.Fix.enableRegEdit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get a list of all running processes
            Process[] running = Process.GetProcesses();

            // Foreach process, add it to the listBox.
            foreach (Process process in running)
            {
                listBox1.Items.Add(process.ProcessName);
            }
        }

        public void refreshProc()
        {
            listBox1.Items.Clear();

            // Get a list of all running processes
            Process[] running = Process.GetProcesses();

            // Foreach process, add it to the listBox.
            foreach (Process process in running)
            {
                listBox1.Items.Add(process.ProcessName);
            }
        }

        private void monoFlat_Button6_Click(object sender, EventArgs e)
        {
            refreshProc();
        }

        private void monoFlat_Button9_Click(object sender, EventArgs e)
        {
            // If there was no process typed in to kill, do not continue.
            if (string.IsNullOrEmpty(ProcessName.Text))
                return;

            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    // If the process matches the typed in process name, kill it.
                    if (process.ProcessName.ToLower().Contains(ProcessName.Text))
                    {
                        process.Kill();
                    }
                }

                refreshProc();
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

        private void monoFlat_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the PayPal donation link
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=59VPBRNZZVTB6");
        }

        private void monoFlat_LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open a pastebin link containing the BTC address in which users can donate.
            Process.Start("http://pastebin.com/YQbjHZn4");
        }

        private void monoFlat_Button5_Click(object sender, EventArgs e)
        {
            Clean.Fix.enableLua();
        }
    }
}
