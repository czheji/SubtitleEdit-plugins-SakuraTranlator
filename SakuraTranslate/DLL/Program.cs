using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleEdit
{
    public static class Program
    {
        [STAThreadAttribute]
        public static int Main(string[] args)
        {
            MainForm form = new MainForm();
            form.ShowDialog();
            return 0;
        }
    }
}
