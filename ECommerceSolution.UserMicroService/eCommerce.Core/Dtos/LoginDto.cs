﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Dtos
{
    public record LoginDto(
        string? Email,
        string? Password
        );
}
