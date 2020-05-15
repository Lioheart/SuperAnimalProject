using Microsoft.EntityFrameworkCore;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.Repositories.Interfaces;
using SuperAnimal.Services.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Pet> GetPetsForDeal(string searchedName = "")
        {
            return _context.Pets.Where(x => string.IsNullOrEmpty(searchedName) || x.Name.Contains(searchedName))
                .Take(50)
                .Include(x => x.User)
                .ToList();
        }
    }
}
