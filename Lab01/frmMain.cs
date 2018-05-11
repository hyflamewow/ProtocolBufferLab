using Google.Protobuf;
using Google.Protobuf.Examples.AddressBook;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using static Google.Protobuf.Examples.AddressBook.Person.Types;

namespace Lab01
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            Person john = new Person
            {
                Id = 1234,
                Name = "John Doe",
                Email = "jdoe@example.com",
                Phones = { new PhoneNumber { Number = "555-4321", Type = PhoneType.Home } }
            };
            using (var output = File.Create("john.dat"))
            {
                john.WriteTo(output);
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Person john;
            using (var input = File.OpenRead("john.dat"))
            {
                john = Person.Parser.ParseFrom(input);
            }
            MessageBox.Show(JsonConvert.SerializeObject(john));
        }
    }
}
