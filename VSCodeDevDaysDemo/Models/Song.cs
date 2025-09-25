namespace VSCodeDevDaysDemo.Models;

public enum SongOccasion
{
    Birthday,
    Anniversary,
    Wedding,
    Proposal,
    Friendship,
    FamilyCelebration,
    Graduation,
    NewBaby,
    Memorial,
    Holiday,
    Corporate,
    Other
}

public enum SongTone
{
    Romantic,
    Joyful,
    Nostalgic,
    Inspirational,
    Humorous,
    Emotional,
    Energetic,
    Reflective,
    Hopeful,
    Serious
}

public class SongRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public SongOccasion Occasion { get; set; }
    public SongTone Tone { get; set; }
    public string StoryDetails { get; set; } = string.Empty;
    public List<string> KeyPhrases { get; set; } = new List<string>();
    public List<string> PersonalReferences { get; set; } = new List<string>();
    public List<string> FeaturedInstruments { get; set; } = new List<string>();
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public SongProductionStage Stage { get; set; } = SongProductionStage.Requested;
    public string UserId { get; set; } = string.Empty;
    public SongDeliveryPackage Package { get; set; } = SongDeliveryPackage.Basic;
}

public enum SongProductionStage
{
    Requested,
    LyricsDrafted,
    LyricsReviewed,
    InProduction,
    MixingMastering,
    Ready,
    Delivered
}

public enum SongDeliveryPackage
{
    Basic,
    Premium,
    Deluxe
}

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Lyrics { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public string AudioUrl { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public int RequestId { get; set; }
    public bool IsFinal { get; set; }
    public List<SongDeliveryFormat> AvailableFormats { get; set; } = new List<SongDeliveryFormat>();
    public string CertificateUrl { get; set; } = string.Empty;
}

public class SongDeliveryFormat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FileExtension { get; set; } = string.Empty;
    public string DownloadUrl { get; set; } = string.Empty;
    public bool IsPhysical { get; set; }
    public string DeliveryStatus { get; set; } = string.Empty;
}