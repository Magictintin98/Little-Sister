using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleSister
{
    public class Vision
    {
        public List<VisionCategorie> Categories;
        public VisionMetaData metadata;
        public string requestId;
        public Vision(List<VisionCategorie> listVisionCategorie,VisionMetaData metadata,string requestId)
        {
            this.Categories = listVisionCategorie;
            this.metadata = metadata;
            this.requestId = requestId;
        }
    }
}
