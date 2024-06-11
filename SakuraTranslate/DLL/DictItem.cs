using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleEdit
{
    public class DictItem
    {
        public string Src { get; set; }
        public string Dst { get; set; }
        public string Info { get; set; }

        public string[] ToArray()
        {
            return new string[] { Src, Dst, Info };
        }
        public string GetKey()
        {
            if (string.IsNullOrEmpty(Info))
            {
                return Src + "->" + Dst;
            }
            else
            {
                return Src + "->" + Dst + " #" + Info;
            }
        }
        public string GetTag()
        {
            return Src + ", " + Dst + ", " + Info;
        }
    }
}
