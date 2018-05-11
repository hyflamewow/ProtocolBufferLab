using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.MessagePack
{
    [MessagePackObject]
    public class Person
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public int Id { get; set; }
        [Key(2)]
        public string Email { get; set; }
        [Key(3)]
        public List<PhoneNumber> Phones { get; set; }
    }
    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }
    [MessagePackObject]
    public class PhoneNumber
    {
        [Key(0)]
        public string Number { get; set; }
        [Key(1)]
        public PhoneType Type { get; set; }
    }

}
