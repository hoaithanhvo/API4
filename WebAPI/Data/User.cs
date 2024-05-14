using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
