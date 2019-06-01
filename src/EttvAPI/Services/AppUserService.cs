using System;
using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Models;
using EttvAPI.Services.Communication;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Services
{
    public class AppUserService : IAppUserService
    {
        public IEnumerable<AppUser> List()
        {
            throw new NotImplementedException();
        }

        public AppUserResponce Save(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public AppUserResponce Update(int id, AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public AppUserResponce Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
