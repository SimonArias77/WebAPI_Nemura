using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Nemura.DTOs;

public class UserLoginDto
{
    public string? NickName { get; set; }
    public string? Password { get; set; }

}
