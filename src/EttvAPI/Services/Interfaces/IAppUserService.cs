using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Models;

namespace EttvAPI.Services.Interfaces
{
    public interface IAppUserService
    {
        IEnumerable<AppUser> ListAsync();
        AppUserModel SaveAsync(AppUser appUser);
        AppUserModel UpdateAsync(int id, AppUser appUser);
        AppUserModel DeleteAsync(int id);
    }
}
