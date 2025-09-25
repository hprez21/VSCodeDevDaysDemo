namespace VSCodeDevDaysDemo.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconClass { get; set; } = string.Empty;
    public List<string> SampleTracks { get; set; } = new();
}

public class EmotionalTone
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ColorClass { get; set; } = string.Empty;
}

public class SongRequest
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Occasion { get; set; } = string.Empty;
    public Genre Genre { get; set; } = new();
    public EmotionalTone Tone { get; set; } = new();
    public string PersonalStory { get; set; } = string.Empty;
    public string SpecialNames { get; set; } = string.Empty;
    public string Keywords { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public SongRequestStatus Status { get; set; } = SongRequestStatus.Draft;
    public string? PreviewAudioUrl { get; set; }
}

public class AudioPreview
{
    public int Id { get; set; }
    public int SongRequestId { get; set; }
    public string AudioUrl { get; set; } = string.Empty;
    public int DurationSeconds { get; set; } = 30;
    public string GeneratedLyrics { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsGenerated { get; set; }
}

public enum SongRequestStatus
{
    Draft,
    PreviewGenerated,
    PaymentPending,
    InProduction,
    Completed
}

public class Package
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> Features { get; set; } = new();
    public string BadgeClass { get; set; } = string.Empty;
}