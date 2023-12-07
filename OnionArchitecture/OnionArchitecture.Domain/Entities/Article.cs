﻿namespace OnionArchitecture.Domain.Entities
{
    public class Article : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOnUtc { get; set; }
    }
}
