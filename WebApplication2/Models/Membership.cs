using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}