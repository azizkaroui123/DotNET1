﻿namespace ENISNC.Models
{
    public class Paper
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Staus { get; set; }
        public string demanded_at { get; set; }
        public string approved_at { get; set; }
        public IList<User>? users { get; set; }
    }
}
