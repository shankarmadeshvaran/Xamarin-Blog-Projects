using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionView.Models
{
    public class Contact
    {
        public string FirstName { get; set;}
        public string LastName { get;set; }
        public string UserId { get;set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string Country { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}
