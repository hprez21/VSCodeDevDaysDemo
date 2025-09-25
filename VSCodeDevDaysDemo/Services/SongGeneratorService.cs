using VSCodeDevDaysDemo.Models;

namespace VSCodeDevDaysDemo.Services;

public interface ISongGeneratorService
{
    Task<List<Genre>> GetGenresAsync();
    Task<Genre> GetGenreByIdAsync(int id);
    Task<SongRequest> CreateSongRequestAsync(SongRequest request);
    Task<SongRequest> UpdateSongRequestAsync(SongRequest request);
    Task<SongRequest> GetSongRequestByIdAsync(int id);
    Task<List<SongRequest>> GetUserSongRequestsAsync(string userId);
    Task<Song> GetSongByIdAsync(int id);
    Task<List<Song>> GetSongsByRequestIdAsync(int requestId);
    Task<SongRequest> UpdateSongStageAsync(int requestId, SongProductionStage stage);
}

public class SongGeneratorService : ISongGeneratorService
{
    // In a real app, this would use a database
    private readonly List<SongRequest> _songRequests = new();
    private readonly List<Song> _songs = new();
    private int _nextRequestId = 1;
    private int _nextSongId = 1;

    public Task<List<Genre>> GetGenresAsync()
    {
        return Task.FromResult(GenreData.GetAllGenres());
    }

    public Task<Genre> GetGenreByIdAsync(int id)
    {
        var genre = GenreData.GetAllGenres().FirstOrDefault(g => g.Id == id) ??
            throw new KeyNotFoundException($"Genre with ID {id} not found");
        return Task.FromResult(genre);
    }

    public Task<SongRequest> CreateSongRequestAsync(SongRequest request)
    {
        request.Id = _nextRequestId++;
        request.RequestDate = DateTime.Now;
        request.Stage = SongProductionStage.Requested;
        _songRequests.Add(request);
        return Task.FromResult(request);
    }

    public Task<SongRequest> UpdateSongRequestAsync(SongRequest request)
    {
        var existingRequest = _songRequests.FirstOrDefault(r => r.Id == request.Id) ??
            throw new KeyNotFoundException($"Song request with ID {request.Id} not found");

        var index = _songRequests.IndexOf(existingRequest);
        _songRequests[index] = request;

        return Task.FromResult(request);
    }

    public Task<SongRequest> GetSongRequestByIdAsync(int id)
    {
        var request = _songRequests.FirstOrDefault(r => r.Id == id) ??
            throw new KeyNotFoundException($"Song request with ID {id} not found");
        return Task.FromResult(request);
    }

    public Task<List<SongRequest>> GetUserSongRequestsAsync(string userId)
    {
        var requests = _songRequests.Where(r => r.UserId == userId).ToList();
        return Task.FromResult(requests);
    }

    public Task<Song> GetSongByIdAsync(int id)
    {
        var song = _songs.FirstOrDefault(s => s.Id == id) ??
            throw new KeyNotFoundException($"Song with ID {id} not found");
        return Task.FromResult(song);
    }

    public Task<List<Song>> GetSongsByRequestIdAsync(int requestId)
    {
        var songs = _songs.Where(s => s.RequestId == requestId).ToList();
        return Task.FromResult(songs);
    }

    public async Task<SongRequest> UpdateSongStageAsync(int requestId, SongProductionStage stage)
    {
        var request = await GetSongRequestByIdAsync(requestId);
        request.Stage = stage;
        return await UpdateSongRequestAsync(request);
    }
}