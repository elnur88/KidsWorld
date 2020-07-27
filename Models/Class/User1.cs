using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class User1
    {

        public int UserId { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        public int User_Id { get; set; }
        public string FullName { get; set; }

        public string FullAdress { get; set; }
        public string UserName1 { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

    }
}