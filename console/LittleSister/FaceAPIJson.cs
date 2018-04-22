using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleSister
{
    public class FaceAPIJson
    {
        public string faceId;
        public List<FaceRectangle> faceRectangle;
        public FaceAPIJson(string faceId,List<FaceRectangle>faceRectangle)
        {
            this.faceId = faceId;
            this.faceRectangle = faceRectangle;
        }
    }
}
