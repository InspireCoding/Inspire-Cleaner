using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

    public class Clean
    {
        public static void BotKiller()
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            for (int i = 0; i < RegKey.GetValueNames().Length; i++)
            {
                try
                {
                    if (RegKey.GetValueNames()[i].ToString() != "NoIPDUCv4" && RegKey.GetValueNames()[i].ToString() != "Skype")
                    {
                        RegKey.SetValue(RegKey.GetValueNames()[i].ToString(), "");
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to clear out the registry.", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("All possible running bots have been killed!", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public class Fix
        {
            public static void TMGR()
            {
                try
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                    key.SetValue("DisableTaskMgr", 0);
                }
                catch
                {
                    MessageBox.Show("Unable to repair the Task Manger.", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Task Manager has been repaired!", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public static void HOSTS()
            {
                try
                {
                    Directory.CreateDirectory(@"C:\windows\system32\drivers\etc\old\");
                    File.Move(@"C:\windows\system32\drivers\etc\hosts", @"C:\windows\system32\drivers\etc\old\hosts");
                }
                catch
                {
                    MessageBox.Show("Unable to repair the HOSTS file.", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(@"HOSTS file has been repaired! - Old file stored in C:\windows\system32\drivers\etc\old\", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public static void CMD()
            {
                try
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
                    key.SetValue("DisableCMD", 0);
                }
                catch
                {
                    MessageBox.Show("Unable to repair the CMD.", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("CMD has been repaired!", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public static void RE()
            {
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                    key.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
                    key.Close();
                }
                catch
                {
                    MessageBox.Show("Unable to repair Reg Edit.", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(@"Reg Edit has been repaired!", "Inspire Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }