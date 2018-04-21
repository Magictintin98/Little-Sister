using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleSister
{
    public class VisionCategorie
    {
        public string name;
        public double score;
        public VisionCategorie(string name,double score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
