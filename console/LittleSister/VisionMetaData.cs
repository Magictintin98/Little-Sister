using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleSister
{
    public class VisionMetaData
    {
        public double height;
        public double width;
        public string format;
        public VisionMetaData(double height,double width,string format)
        {
            this.height = height;
            this.width = width;
            this.format = format;
        }
    }
}
