using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Model
{
    //public class Media
    //{
    //    public string Id { get; set; }
    //    public string InstructorId { get; set; }
    //    public string InstructorName { get; set; }
    //    public string FileName { get; set; }
    //    public string FileType { get; set; }
    //    public string FileExtension { get; set; }
    //    public DateTime RecordingDate { get; set; }
    //    public DateTime UploadDate { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public long Duration { get; set; }
    //    public long Size { get; set; }
    //    public double LikeScore { get; set; }
    //    public IEnumerable<string> Tags { get; set; }
    //    public string Status { get; set; }
    //    public DateTime PublishedDate { get; set; }
    //    public DateTime StagedDate { get; set; }
    //    public DateTime ArchivedDate { get; set; }
    //}

    public class Media
    {
        public string Id { get; set; }
        public string InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        public ContentDetails ContentDetails { get; set; }
        public DateTime RecordingDate { get; set; }
        public DateTime UploadDate { get; set; }
        public StateDetails State { get; set; }
        public Manifest Manifest { get; set; }
        public Uri Uri { get; set; }
    }

    public class ContentDetails
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Duration { get; set; }
        public long Size { get; set; }
        public double LikeScore { get; set; }
        public List<string> Tags { get; set; }
    }

    public class StateDetails
    {
        public StatusType Status { get; set; }
        public DateTime Published { get; set; }
        public DateTime Staged { get; set; }
        public DateTime Archived { get; set; }
    }

    public class Manifest
    {
        public Dictionary<string, string> Items { get; set; }
    }

    public enum StatusType
    {
        NONE = 0,
        STAGED,
        PUBLISHED,
        ARCHIVED
    }
}
