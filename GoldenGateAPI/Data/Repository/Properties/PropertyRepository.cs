using GoldenGateAPI.Models;
using GoldenGateAPI.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoldenGateAPI.Data.Repository.Properties;

public class PropertyRepository : ICRUDAsyncRepository<Property>
{
    private readonly AppDbContext _context;
    private readonly IUserSession _userSession;
    private readonly UserManager<User> _userManager;

    public PropertyRepository(
        AppDbContext context,
        IUserSession userSession,
        UserManager<User> userManager
    )
    {
        _context = context;
        _userSession = userSession;
        _userManager = userManager;
    }


    public async Task<IEnumerable<Property>> GetAll() 
        => await _context.Properties.ToListAsync();

    public async Task<Property?> GetById(int id)
        => await _context.Properties.FindAsync(id);

    public async Task Create(Property entity)
    {
        var username = _userSession.GetUserSession();
        var userCreating = await _userManager.FindByNameAsync(username);
        entity.UserId = Guid.Parse(userCreating!.Id);

        await _context.Properties.AddAsync(entity);
    }

    public async Task Update(Property entity)
    {
        var username = _userSession.GetUserSession();
        var userCreating = await _userManager.FindByNameAsync(username);

        entity.UserId = Guid.Parse(userCreating!.Id);
        entity.LastUpdateDate = DateTime.Now;
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if(property is not null)
            _context.Properties.Remove(property);
    }

    public async Task<bool> SaveChanges()
    {
        return (await _context.SaveChangesAsync()) >= 0;
    }

}
