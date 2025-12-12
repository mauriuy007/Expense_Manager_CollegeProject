using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaLogicaAplicacion.Dtos.User
{
    public record UserLoginDtoResponse(
        int Id,
        string Email,
        string Role,
        string Token
    );
}
