using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Models
{
    public class CatResponse
    {
        public int id { get; set; }
        public string url { get; set; }
        public string webpurl { get; set; }
        public float x { get; set; }
        public float y { get; set; }
    }
}
