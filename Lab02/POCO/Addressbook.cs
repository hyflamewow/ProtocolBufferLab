using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.POCO
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> Phones { get; set; }
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
