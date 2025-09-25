using VSCodeDevDaysDemo.Models;

namespace VSCodeDevDaysDemo.Services;

public interface IAudioPreviewService
{
    Task<AudioPreview> GeneratePreviewAsync(SongRequest request);
    Task<string> GenerateLyricsPreviewAsync(SongRequest request);
    Task<bool> IsPreviewReadyAsync(int songRequestId);
    Task<AudioPreview?> GetPreviewAsync(int songRequestId);
}

public class AudioPreviewService : IAudioPreviewService
{
    private readonly Dictionary<int, AudioPreview> _previews = new();
    private readonly Random _random = new();

    // Simulamos diferentes samples de audio para cada género
    private readonly Dictionary<string, List<string>> _genreSamples = new()
    {
        ["Pop"] = new List<string> { "sample-pop-1.mp3", "sample-pop-2.mp3", "sample-pop-3.mp3" },
        ["Rock"] = new List<string> { "sample-rock-1.mp3", "sample-rock-2.mp3", "sample-rock-3.mp3" },
        ["Balada"] = new List<string> { "sample-ballad-1.mp3", "sample-ballad-2.mp3", "sample-ballad-3.mp3" },
        ["Reggaeton"] = new List<string> { "sample-reggaeton-1.mp3", "sample-reggaeton-2.mp3" },
        ["Jazz"] = new List<string> { "sample-jazz-1.mp3", "sample-jazz-2.mp3" },
        ["Folk"] = new List<string> { "sample-folk-1.mp3", "sample-folk-2.mp3" }
    };

    public async Task<AudioPreview> GeneratePreviewAsync(SongRequest request)
    {
        // Simulamos el tiempo de generación con IA
        await Task.Delay(_random.Next(2000, 8000)); // 2-8 segundos de "generación"

        var preview = new AudioPreview
        {
            Id = _random.Next(1000, 9999),
            SongRequestId = request.Id,
            AudioUrl = GetSampleAudioUrl(request.Genre.Name),
            DurationSeconds = 30,
            GeneratedLyrics = await GenerateLyricsPreviewAsync(request),
            CreatedAt = DateTime.Now,
            IsGenerated = true
        };

        _previews[request.Id] = preview;
        return preview;
    }

    public async Task<string> GenerateLyricsPreviewAsync(SongRequest request)
    {
        // Simulamos generación de letras basadas en las selecciones del usuario
        await Task.Delay(1000);

        var lyricsTemplates = new List<string>();

        // Plantillas basadas en el tono emocional
        switch (request.Tone.Name.ToLower())
        {
            case "romántico":
                lyricsTemplates.AddRange(new[]
                {
                    "En tus ojos veo el destino,\nEn tu sonrisa encuentro el camino,\n{names}, mi corazón late por ti,\nEres todo lo que pedí.",
                    "Cada momento a tu lado,\nEs un sueño que se ha realizado,\n{names}, eres mi inspiración,\nEres toda mi canción."
                });
                break;
            case "alegre":
                lyricsTemplates.AddRange(new[]
                {
                    "Hoy es un día especial,\nTodo brilla como un cristal,\n{names}, vamos a celebrar,\nLa vida hay que disfrutar.",
                    "Baila, canta, ríe sin parar,\nCon {names} todo puede brillar,\nEste momento hay que guardar,\nEn el corazón lo voy a llevar."
                });
                break;
            case "nostálgico":
                lyricsTemplates.AddRange(new[]
                {
                    "Recuerdo aquellos días,\nCuando todo era alegría,\n{names}, los momentos que vivimos,\nNunca los olvidaremos.",
                    "En el tiempo que se fue,\nTantos sueños encontré,\n{names}, en mi memoria están,\nY por siempre estarán."
                });
                break;
            default:
                lyricsTemplates.AddRange(new[]
                {
                    "Esta canción es para ti,\n{names}, desde el corazón,\nCada nota, cada verso aquí,\nLleva mi emoción.",
                    "Palabras que quiero decir,\nEn una melodía expresar,\n{names}, te quiero compartir,\nTodo lo que siento acá."
                });
                break;
        }

        var selectedTemplate = lyricsTemplates[_random.Next(lyricsTemplates.Count)];
        
        // Reemplazamos los marcadores con información personal
        var names = string.IsNullOrEmpty(request.SpecialNames) ? "querido amigo" : request.SpecialNames;
        var lyrics = selectedTemplate.Replace("{names}", names);

        // Agregamos información de la historia personal si está disponible
        if (!string.IsNullOrEmpty(request.PersonalStory) && request.PersonalStory.Length > 20)
        {
            lyrics += "\n\n" + GenerateStoryVerse(request.PersonalStory, names);
        }

        return lyrics;
    }

    public async Task<bool> IsPreviewReadyAsync(int songRequestId)
    {
        await Task.Delay(100); // Simular verificación
        return _previews.ContainsKey(songRequestId) && _previews[songRequestId].IsGenerated;
    }

    public async Task<AudioPreview?> GetPreviewAsync(int songRequestId)
    {
        await Task.Delay(100);
        return _previews.TryGetValue(songRequestId, out var preview) ? preview : null;
    }

    private string GetSampleAudioUrl(string genreName)
    {
        // En un entorno real, esto retornaría URLs de archivos de audio generados por IA
        // Para el prototipo, usamos archivos de muestra estáticos
        
        if (_genreSamples.TryGetValue(genreName, out var samples))
        {
            var selectedSample = samples[_random.Next(samples.Count)];
            return $"/audio/samples/{selectedSample}";
        }

        // Fallback para géneros no definidos
        return $"/audio/samples/sample-generic-{_random.Next(1, 4)}.mp3";
    }

    private string GenerateStoryVerse(string story, string names)
    {
        // Extrae elementos clave de la historia para crear un verso personalizado
        var words = story.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var emotionalWords = words.Where(w => IsEmotionalWord(w)).Take(2).ToList();
        
        if (emotionalWords.Any())
        {
            return $"Como {string.Join(" y ", emotionalWords)} que sientes,\n{names}, en nuestras mentes,\nEsta historia que vivimos,\nJuntos siempre la escribimos.";
        }

        return $"Nuestra historia es especial,\n{names}, es algo real,\nCada capítulo que escribimos,\nPara siempre lo vivimos.";
    }

    private bool IsEmotionalWord(string word)
    {
        var emotionalWords = new HashSet<string>
        {
            "amor", "feliz", "alegria", "tristeza", "emocion", "corazon", "alma", "sueño", "esperanza", "pasion",
            "recuerdo", "memoria", "tiempo", "vida", "familia", "amistad", "cariño", "ternura", "sorpresa"
        };
        
        return emotionalWords.Contains(word.ToLower().Trim('.', ',', '!', '?'));
    }
}