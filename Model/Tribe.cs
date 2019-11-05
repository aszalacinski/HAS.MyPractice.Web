using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Model
{
    public class Tribe
    {
        public string Id { get; set; }
        public string InstructorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public bool IsSubscription { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }

    public class Member
    {
        public string Id { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
