using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class BaseService
    {
        protected readonly ApplicationDbContext Context;
        protected readonly ILogger Logger;


        public BaseService(ILogger logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

    }
}
