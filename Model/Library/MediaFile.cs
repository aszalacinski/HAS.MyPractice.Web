using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Model.Library
{
    public class MediaFile
    {
        public string Id { get; set; }
        public long Duration { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string MediaUri { get; set; }
    }
}
