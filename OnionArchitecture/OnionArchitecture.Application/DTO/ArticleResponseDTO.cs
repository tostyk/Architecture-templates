﻿namespace OnionArchitecture.Application.DTO
{
    public class ArticleResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOnUtc { get; set; }
    }
}
