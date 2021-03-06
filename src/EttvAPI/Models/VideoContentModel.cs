﻿namespace EttvAPI.Models
{
    public class VideoContentModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Tag { get; set; }
        public string Thumbnail { get; set; }
        public string SrcUri { get; set; }
        public string SrcExtention { get; set; }
        public int AppUserId { get; set; }
    }
}
