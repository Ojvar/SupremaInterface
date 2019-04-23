using System;
using System.Windows.Forms;
using Test.Forms;

namespace Test
{
    class Program
    {
        [STAThread]
        static void Main (string[] args)
        {
            Application.Run (new TestForm ());
        }
    }
}
