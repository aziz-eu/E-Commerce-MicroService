using eCommerce.Core.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Dtos
{
    public record AuthenticationResponse
    (
        Guid UserId,
        string? Email,
        string? Name,
        string? Gender,
        bool? IsAuthenticated,
        string? Token

        );
}
