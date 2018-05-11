using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.POCO
{
    public class Person
    {
        public string 姓名 { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> Phones { get; set; }
        public Person() { }
        public Person(Google.Protobuf.Examples.AddressBook.Person person)
        {
            this.姓名 = person.Name;
            this.Id = person.Id;
            this.Email = person.Email;
            this.Phones = person.Phones.Select(p => new PhoneNumber { Number = p.Number, Type = (PhoneType)p.Type }).ToList();
        }
        
    }
    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }
    public class PhoneNumber
    {
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }

}
