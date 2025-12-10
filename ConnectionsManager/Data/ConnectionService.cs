using Microsoft.EntityFrameworkCore;

namespace ConnectionsManager.Data;

public class ConnectionService
{
    private readonly ApplicationDbContext _context;

    public ConnectionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Connection>> GetAllAsync() =>
        await _context.Connections.ToListAsync();

    public async Task<Connection?> GetByIdAsync(int id) =>
        await _context.Connections.FindAsync(id);

    public async Task AddAsync(Connection connection)
    {
        _context.Connections.Add(connection);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Connection connection)
    {
        _context.Connections.Update(connection);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Connections.FindAsync(id);
        if (entity != null)
        {
            _context.Connections.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
