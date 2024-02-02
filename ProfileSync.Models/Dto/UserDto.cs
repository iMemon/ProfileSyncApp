using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileSync.Models.Dto
{
    public class UserDto
    {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;
            public string? Address { get; set; }
            public string? Phone { get; set; }
        
    }
}
