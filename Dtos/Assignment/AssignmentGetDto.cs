using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebAPI_Nemura.Enums;

namespace WebAPI_Nemura.Dtos.Assignment
{
    public class AssignmentGetDto
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public AssignmentStatus Status {get; set;}
        public AssignmentPriority Priority {get; set;}
        public int ProjectId {get; set;}
        

    }
}