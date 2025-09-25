namespace VSCodeDevDaysDemo.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> CommonInstruments { get; set; } = new List<string>();
    public List<string> SampleSongs { get; set; } = new List<string>();
}

public static class GenreData
{
    public static List<Genre> GetAllGenres()
    {
        return new List<Genre>
        {
            new Genre { Id = 1, Name = "Pop", Description = "Popular music appealing to a wide audience", ImageUrl = "/images/genres/pop.jpg",
                CommonInstruments = new List<string> { "Piano", "Synthesizer", "Guitar", "Drums" },
                SampleSongs = new List<string> { "pop_sample_1.mp3", "pop_sample_2.mp3" } },
            new Genre { Id = 2, Name = "Rock", Description = "Guitar-driven sound with strong beats and catchy melodies", ImageUrl = "/images/genres/rock.jpg",
                CommonInstruments = new List<string> { "Electric Guitar", "Bass Guitar", "Drums", "Keyboard" },
                SampleSongs = new List<string> { "rock_sample_1.mp3", "rock_sample_2.mp3" } },
            new Genre { Id = 3, Name = "Balada", Description = "Slow-tempo romantic songs with emotional lyrics", ImageUrl = "/images/genres/balada.jpg",
                CommonInstruments = new List<string> { "Piano", "Strings", "Acoustic Guitar" },
                SampleSongs = new List<string> { "balada_sample_1.mp3", "balada_sample_2.mp3" } },
            new Genre { Id = 4, Name = "Corridos", Description = "Mexican folk ballads telling stories with regional instruments", ImageUrl = "/images/genres/corridos.jpg",
                CommonInstruments = new List<string> { "Accordion", "Bajo Sexto", "Acoustic Guitar", "Tuba" },
                SampleSongs = new List<string> { "corridos_sample_1.mp3", "corridos_sample_2.mp3" } },
            new Genre { Id = 5, Name = "Reggaetón", Description = "Urban Latin rhythm with Spanish lyrics and danceable beats", ImageUrl = "/images/genres/reggaeton.jpg",
                CommonInstruments = new List<string> { "Drum Machine", "Synthesizer", "Digital Audio Workstation" },
                SampleSongs = new List<string> { "reggaeton_sample_1.mp3", "reggaeton_sample_2.mp3" } },
            new Genre { Id = 6, Name = "Salsa", Description = "Cuban-influenced dance music with strong percussion", ImageUrl = "/images/genres/salsa.jpg",
                CommonInstruments = new List<string> { "Congas", "Timbales", "Trumpet", "Piano", "Bass" },
                SampleSongs = new List<string> { "salsa_sample_1.mp3", "salsa_sample_2.mp3" } },
            new Genre { Id = 7, Name = "Jazz", Description = "Improvisational music with complex harmonies", ImageUrl = "/images/genres/jazz.jpg",
                CommonInstruments = new List<string> { "Saxophone", "Trumpet", "Piano", "Double Bass", "Drums" },
                SampleSongs = new List<string> { "jazz_sample_1.mp3", "jazz_sample_2.mp3" } },
            new Genre { Id = 8, Name = "Ranchera", Description = "Traditional Mexican music with strong vocals", ImageUrl = "/images/genres/ranchera.jpg",
                CommonInstruments = new List<string> { "Mariachi Trumpet", "Vihuela", "Guitarrón", "Violin" },
                SampleSongs = new List<string> { "ranchera_sample_1.mp3", "ranchera_sample_2.mp3" } }
        };
    }
}