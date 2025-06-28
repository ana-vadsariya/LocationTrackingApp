using SQLite;
using LocationHeatmapApp.Models;

namespace LocationHeatmapApp.Services;

public class LocationDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public LocationDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<LocationEntry>().Wait();
    }

    public Task<int> SaveLocationAsync(LocationEntry location) =>
        _database.InsertAsync(location);

    public Task<List<LocationEntry>> GetLocationsAsync() =>
        _database.Table<LocationEntry>().ToListAsync();
}
