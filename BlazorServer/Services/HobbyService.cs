using System;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Services;

/// <summary>
/// The HobbyService Class contains methods used to retrieve Hobby entities from the database
/// </summary>
public class HobbyService
{

  /// <summary>
  /// The database context.
  /// </summary>
  private ApplicationDbContext _context;
  
  /// <summary>
  /// The HobbyService constructor which sets the database context.
  /// </summary>
  /// <param name="context">The database context</param>
  public HobbyService(ApplicationDbContext context) {
    _context = context;
  }

  /// <summary>
  /// Returns a list of all the hobbies in the database.
  /// </summary>
  /// <returns>A list of Hobby entities</returns>
  public async Task<List<Hobby>> GetHobbiesAsync() {
   return await  _context.Hobbies.ToListAsync();
  }

  /// <summary>
  /// Returns a list of all the hobbies in the database that have partialName in their HobbyName.
  /// </summary>
  /// <param name="partialName">A string</param>
  /// <returns>A list of Hobby entities</returns>
  public async Task<List<Hobby>> GetHobbiesWithNamesLike(string partialName)
    {
        return  await _context.Hobbies
        .Where(h => h.HobbyName.ToLower().Contains(partialName.ToLower()))
        .ToListAsync();
    }
}
