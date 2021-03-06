﻿using System;

namespace ScreenPowerOff
{
    class Program
    {
        static void Main(string[] args)
        {
            PowerOffScreen.PowerOff();
        }
    }

    public class PowerOffScreen
    {
        private const int WM_SYSCOMMAND = 0x112; //系统消息
        private const int SC_SCREENSAVE = 0xf140; // 启动屏幕保护消息
        private const int SC_MONITORPOWER = 0xF170; //关闭显示器的系统命令
        private const int POWER_OFF = 2; //2 为关闭, 1为省电状态，-1为开机
        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff); //广播消息，所有顶级窗体都会接收

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);



        public static void PowerOff()
        {
            // 关闭显示器
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, POWER_OFF);
            // 启动屏保
            //SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_SCREENSAVE, 0); 
        }
    }
}
