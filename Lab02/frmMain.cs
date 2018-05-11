using Google.Protobuf;
using Google.Protobuf.Examples.AddressBook;
using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Examples.AddressBook.Person.Types;

namespace Lab02
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
            POCO.Person john2 = new POCO.Person
            {
                Id = 1234,
                Name = "John Doe",
                Email = "jdoe@example.com",
                Phones = new List<POCO.PhoneNumber>() { new POCO.PhoneNumber { Number = "555-4321", Type = POCO.PhoneType.Home } }
            };
            MessagePack.Person john3 = new MessagePack.Person
            {
                Id = 1234,
                Name = "John Doe",
                Email = "jdoe@example.com",
                Phones = new List<MessagePack.PhoneNumber>() { new MessagePack.PhoneNumber { Number = "555-4321", Type = MessagePack.PhoneType.Home } }
            };

            //#Protocol Buffer
            using (var output = File.Create("john.dat"))
            {
                john.WriteTo(output);
            }
            //#Json
            using (var output = File.CreateText("john.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(output, john2);
            }
            //#Messag Pack
            using (var output = File.Create("john.mp"))
            {
                MessagePackSerializer.Serialize<MessagePack.Person>(output, john3);
            }

            FileInfo protoBufFile = new FileInfo("john.dat");
            FileInfo jsonFile = new FileInfo("john.json");
            FileInfo messagePackFile = new FileInfo("john.mp");
            MessageBox.Show($"ProtoBufFile={protoBufFile.Length}, JsonFile={jsonFile.Length}, MessagePackFile={messagePackFile.Length}");

        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Person john;
            using (var input = File.OpenRead("john.dat"))
            {
                john = Person.Parser.ParseFrom(input);
            }
            MessageBox.Show(JsonConvert.SerializeObject(john));
            POCO.Person john2;
            using (var input = File.OpenText("john.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                john2 = (POCO.Person)serializer.Deserialize(input, typeof(POCO.Person));
            }
            MessageBox.Show(JsonConvert.SerializeObject(john));
            MessagePack.Person john3;
            using (var input = File.OpenRead("john.mp"))
            {
                john3 = MessagePackSerializer.Deserialize<MessagePack.Person>(input);
            }
            MessageBox.Show(JsonConvert.SerializeObject(john3));
        }

        private void btnParseSpeed_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            long protoBufSpeed = 0;
            long jsonSpeed = 0;
            long messagePackSpeed = 0;
            //#測試MessagePack的速度
            sw.Reset();
            Thread.Sleep(1000);
            MessagePack.Person john3;
            byte[] input3 = File.ReadAllBytes("john.mp");
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                john3 = MessagePackSerializer.Deserialize<MessagePack.Person>(input3);
            }
            sw.Stop();
            messagePackSpeed = sw.ElapsedMilliseconds;

            //#測試ProtoBuf解析的速度
            sw.Reset();
            Thread.Sleep(1000);
            Person john;
            byte[] input = File.ReadAllBytes("john.dat");
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                john = Person.Parser.ParseFrom(input);
            }
            sw.Stop();
            protoBufSpeed = sw.ElapsedMilliseconds;
            sw.Reset();
            Thread.Sleep(1000);
            string input2 = File.ReadAllText("john.json");
            //#測試Json解析的速度
            POCO.Person john2;
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                john2 = JsonConvert.DeserializeObject<POCO.Person>(input2);
            }
            sw.Stop();
            jsonSpeed = sw.ElapsedMilliseconds;
           
            MessageBox.Show($"ProtoBufSpeed={protoBufSpeed}, JsonSpeed={jsonSpeed}, MessagePackSpeed={messagePackSpeed}");
        }
    }
}
