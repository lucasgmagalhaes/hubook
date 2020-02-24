using System.Collections.Generic;

namespace Dort.Entity.GoogleBook
{
    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public List<string> Categories { get; }
        public ImageLinks ImageLinks { get; set; }
        public string Language { get; set; }
        public string PreviewLink { get; set; }
        public string InfoLink { get; set; }
        public string CanonicalVolumeLink { get; set; }

        public VolumeInfo()
        {
            Authors = new List<string>();
            Categories = new List<string>();
        }
    }
}
