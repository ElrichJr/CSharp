using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Last_Attempt_at_Lab_4
{
    class Media
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);
        public long OpenMediaFile(string FileName)
        {
            string FORMAT = "open \"" + FileName + "\" alias MediaFile";
            return mciSendString(FORMAT, null, 0, IntPtr.Zero);
        }
        public long play()
        {
            string command = "play MediaFile from 0";
            return mciSendString(command, null, 0, IntPtr.Zero);
        }
    }
}
