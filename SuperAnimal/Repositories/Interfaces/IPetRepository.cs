using SuperAnimal.Models;
using System.Collections.Generic;

namespace SuperAnimal.Repositories.Interfaces
{
    public interface IPetRepository
    {
        List<Pet> GetPetsForDeal(string searchedName = "");
    }
}