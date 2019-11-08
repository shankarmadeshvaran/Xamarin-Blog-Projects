using System.Collections.Generic;
using CollectionView.Models;

namespace CollectionView.Service
{
    public class Contacts
    {
        public static IEnumerable<Contact> Get()
        {
            return new List<Contact>
            {
                new Contact() {UserId="1", FirstName="Contact", LastName="One", Email="contact.one@gmail.com",
                    Phone="1234131332", PhotoUrl="profile01.png",Country="India" },
                new Contact() {UserId="2", FirstName="Contact", LastName="Two", Email="contact.two@gmail.com",
                    Phone="12894131332", PhotoUrl="profile02.png",Country="India"  },
                new Contact() {UserId="3", FirstName="Contact", LastName="Three", Email="contact.three@gmail.com",
                    Phone="4234242235", PhotoUrl="profile03.png",Country="India"  },
                new Contact() {UserId="4", FirstName="Contact", LastName="Four", Email="contact.four@gmail.com",
                    Phone="6443245633", PhotoUrl="profile04.png",Country="India"  },
                new Contact() {UserId="5", FirstName="Contact", LastName="Five", Email="contact.five@gmail.com",
                    Phone="4234242235", PhotoUrl="profile05.png",Country="India"  },
                new Contact() {UserId="6", FirstName="Contact", LastName="Six", Email="contact.six@gmail.com",
                    Phone="2344324443", PhotoUrl="profile06.png",Country="India" },
                new Contact() {UserId="7", FirstName="Contact", LastName="Seven", Email="contact.seven@gmail.com",
                    Phone="234234234", PhotoUrl="profile01.png",Country="India" },
                new Contact() {UserId="8", FirstName="Contact", LastName="Eight", Email="contact.eight@gmail.com",
                    Phone="4234242235", PhotoUrl="profile02.png",Country="India"  },
            };
        }
    }
}
