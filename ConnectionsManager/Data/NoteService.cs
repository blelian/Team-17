using Microsoft.EntityFrameworkCore;

namespace ConnectionsManager.Data;

public class NoteService
{
    private readonly ApplicationDbContext _context;

    public NoteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Note>> GetAllAsync() =>
        await _context.Notes.ToListAsync();

    public async Task<Note?> GetByIdAsync(int id) =>
        await _context.Notes.FindAsync(id);

    public async Task AddAsync(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Note note)
    {
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Notes.FindAsync(id);
        if (entity != null)
        {
            _context.Notes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
