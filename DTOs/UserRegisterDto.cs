using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Nemura.DTOs;

public class UserRegisterDto
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? NickName { get; set; }
    public string? email { get; set; }
    public string? Password { get; set; }
}
