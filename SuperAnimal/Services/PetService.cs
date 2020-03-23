using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.Services.ServiceResponses;
using SuperAnimal.ViewModels.Pet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class PetService : BaseService
    {
        private readonly IWebHostEnvironment WebHostEnvironment;

        public PetService(ILogger<PetService> logger, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : base(logger, context)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public ServiceResponse<Pet> CreateNewPet(AddPetViewModel model)
        {
            var relativeFilePath = string.Empty;
            if (model.ProfilePhoto != null)
            {
                CreateDirectoryForPetPhotosIfDoesntExist();
                var uniqueFileName = GenerateUniqueFileName(model.ProfilePhoto);
                var filePath = GenerateFilePathForPetPhoto(uniqueFileName);
                relativeFilePath = "\\images\\Pets\\" + uniqueFileName;
                SaveFile(model.ProfilePhoto, filePath);
            }
            else
            {
                relativeFilePath = "\\images\\pet_profile_photo_placeholder.png";
            }

            var pet = new Pet
            {
                Name = model.Name,
                Description = model.Description,
                ProfilePhoto = relativeFilePath,
                UserId = model.UserId
            };

            Context.Pets.Add(pet);
            Context.SaveChanges();
            return ServiceResponse<Pet>.Ok(pet);
        }

        private void CreateDirectoryForPetPhotosIfDoesntExist()
        {
            var uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images/Pets");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
        }

        private string GenerateFilePathForPetPhoto(string uniqueFileName)
        {
            string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images\\Pets");
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            return filePath;
        }

        private string GenerateUniqueFileName(IFormFile file)
        {
            return Guid.NewGuid().ToString() + "_" + file.FileName;
        }

        private void SaveFile(IFormFile file, string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
        }


    }
}
