using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Model
{
    public class Media
    {
        public string Id { get; set; }
        public string InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        public DateTime RecordingDate { get; set; }
        public DateTime UploadDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Duration { get; set; }
        public long Size { get; set; }
        public double LikeScore { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Status { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime StagedDate { get; set; }
        public DateTime ArchivedDate { get; set; }
    }
}
