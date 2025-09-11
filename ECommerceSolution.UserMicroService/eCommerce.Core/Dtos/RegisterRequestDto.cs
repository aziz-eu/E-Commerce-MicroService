using eCommerce.Core.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Dtos
{
    public record RegisterRequestDto(
        string? Email,
        string? Password,
        string? Name,
        GenderOptions? Gender
        );
    
}
