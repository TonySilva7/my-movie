﻿namespace MyMovie.Domain.Models;
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public int DirectorId { get; set; }
}
