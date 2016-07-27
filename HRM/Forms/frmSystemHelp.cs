using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Resources;
using System.Collections;
using System.Runtime.InteropServices;

namespace HRM.Forms
{
    public partial class frmSystemHelp : DevExpress.XtraEditors.XtraForm
    {
        public frmSystemHelp()
        {
            InitializeComponent();
        }

     
        private void frmSystemHelp_Load(object sender, EventArgs e)
        {
            if (File.Exists("History/Help.txt"))
            {
                StreamReader rd = new StreamReader(@"History/Help.txt");
                txtHelp.Text = rd.ReadToEnd();
                rd.Close();
            }
        }

        public static bool Is64BitProcess
        {
            get { return IntPtr.Size == 8; }
        }

        public static bool Is64BitOperatingSystem
        {
            get
            {
                // Clearly if this is a 64-bit process we must be on a 64-bit OS.
                if (Is64BitProcess)
                    return true;
                // Ok, so we are a 32-bit process, but is the OS 64-bit?
                // If we are running under Wow64 than the OS is 64-bit.
                bool isWow64;
                return ModuleContainsFunction("kernel32.dll", "IsWow64Process") && IsWow64Process(GetCurrentProcess(), out isWow64) && isWow64;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        extern static bool IsWow64Process(IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] out bool isWow64);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern static IntPtr GetCurrentProcess();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        extern static IntPtr GetModuleHandle(string moduleName);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        extern static IntPtr GetProcAddress(IntPtr hModule, string methodName);
        static bool ModuleContainsFunction(string moduleName, string methodName)
        {
            IntPtr hModule = GetModuleHandle(moduleName);
            if (hModule != IntPtr.Zero)
                return GetProcAddress(hModule, methodName) != IntPtr.Zero;
            return false;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"Temp_HRM"))
            {
                Directory.CreateDirectory(@"Temp_HRM");

                if (Directory.Exists(@"Temp_HRM"))
                {
                    if (Is64BitOperatingSystem)
                    {
                      //  System.Diagnostics.Process.Start("regsvr32.exe", "ASocketx64.dll");
                    }
                    else
                    {
                       // System.Diagnostics.Process.Start("regsvr32.exe", "ASocket.dll");
                    }

                }

            }            
        }
    }
}