using System;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Services;

public class HobbyService
{
private ApplicationDbContext _context;
  
  public HobbyService(ApplicationDbContext context) {
    _context = context;
  }

  public async Task<List<Hobby>> GetHobbiesAsync() {
   return await  _context.Hobbies.ToListAsync();
  }
}
