using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeUI.ApiServices.Dtos;

namespace NikeUI.ApiServices.Interfaces
{
    public interface IUserService
    {
        Task<bool> PostUser(RegisterDto RegisterDto);
    }
}