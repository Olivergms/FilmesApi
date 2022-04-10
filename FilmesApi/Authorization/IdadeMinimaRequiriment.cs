using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Authorization
{
    public class IdadeMinimaRequiriment : IAuthorizationRequirement
    {
        public IdadeMinimaRequiriment(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }

        public int IdadeMinima { get; set; }
    }
}
