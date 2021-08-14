using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Interfaces
{
    public interface IJwtAuthenticationService
    {
        string Aunthenticate(UserLogin userLogin);
    }
}
