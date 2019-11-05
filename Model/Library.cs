using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Model
{
    public class Hub
    {
        public string Id { get; set; }
        public string InstructorId { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<string> ContentLifetime { get; set; }
        public IEnumerable<string> RootVisitorAccessLimit { get; set; }
        public IEnumerable<Content> Content { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
    }

    public class Content
    {
        public string Id { get; set; }
        public DateTime AddDate { get; set; }
    }
    
    public class Library
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Access { get; set; }
        public IEnumerable<string> ContentLifetime { get; set; }
        public IEnumerable<Content> Content { get; set; }
        public LibTribe DefaultTribe { get; set; }
        public IEnumerable<LibTribe> Tribes { get; set; }
    }

    public class LibTribe
    {
        public string Id { get; set; }
        public DateTime AddDate { get; set; }
    }
}
