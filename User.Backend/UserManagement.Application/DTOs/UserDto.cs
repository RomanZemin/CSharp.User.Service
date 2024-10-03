using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Enums;

namespace UserManagement.Application.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        //public string PublicName { get; set; }
        public string City { get; set; }
        public string ActivityType { get; set; }
        public Gender? Sex {  get; set; }
    }
}
