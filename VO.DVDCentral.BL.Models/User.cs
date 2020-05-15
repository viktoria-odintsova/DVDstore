using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO.DVDCentral.BL.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("User Id")]
        public string UserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Password { get; set; }

        public User() { }

        public User (string userId, string passcode)
        {
            //log in
            UserId = userId;
            Password = passcode;
        }

        public User(int id, string userid, string firstName, string lastName, string passcode)
        {
            //updating a user
            Id = id;
            UserId = userid;
            FirstName = firstName;
            LastName = lastName;
            Password = passcode;
        }

        public User(string userid, string firstname, string lastname, string passcode)
        {
            //creating a user
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            Password = passcode;
        }
    }
}
