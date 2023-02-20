using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void GetFiles()
        {
            string[] files = Directory.GetFiles(@"C:\");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        private static void GetAllDrives()
        {
            // get all drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                Console.WriteLine($"Drive {drive.Name}");
                Console.WriteLine($"  Drive type: {drive.DriveType}");
                if (drive.IsReady == true)
                {
                    Console.WriteLine($"  Volume label: {drive.VolumeLabel}");
                    Console.WriteLine($"  File system: {drive.DriveFormat}");
                    Console.WriteLine($"  Available space to current user:{drive.AvailableFreeSpace}");
                    Console.WriteLine($"  Total available space: {drive.TotalFreeSpace}");
                    Console.WriteLine($"  Total size of drive: {drive.TotalSize} ");
                }
            }
        }

        private static void Deserialize()
        {
            BinaryFormatter binary = new BinaryFormatter();
            Stream stream = File.Open("C:\\Training\\Day 11\\sample.dat", FileMode.Open);
            Contact c = new Contact();
            c = (Contact)binary.Deserialize(stream);
            Console.WriteLine(c.Name);
            stream.Close();
        }

        private static void Serialize()
        {
            //Store contact info into file
            Contact contact = new Contact { ID = 1, Name = "John", EmailID = "name@web.com", Location ="City", Mobile="7896541230" };


            // text format - structured data
            Stream stream = File.Create("C:\\Training\\Day 11\\sample.dat");
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, contact);
            stream.Close();
        }

        private void SaveObject()
        {
            Contact contact = new Contact { ID = 1, Name = "John", EmailID = "name@web.com", Location ="City", Mobile="7896541230" };
            
            string csvData = $"{contact.ID},{contact.Name},{contact.EmailID}, {contact.Location}, {contact.Mobile}";
            
            StreamReader sw = new StreamReader("C:\\Training\\Day 11\\sample.txt");
            List<Contact> contacts = new List<Contact>();

            while (!sw.EndOfStream)
            {
                string line = sw.ReadLine();
                string[] data = line.Split(',');
                Contact c = new Contact();
                c.ID = int.Parse(data[0]);
                c.Name=data[1];
                c.Location = data[2];
                c.EmailID = data[3];
                c.Mobile = data[4];
            }
            StreamWriter sw1 = new StreamWriter("C:\\Training\\Day 11\\sample.txt");

            sw1.WriteLine(csvData);
            sw.Close();
        }


        private static void ReadLine()
        {
            //Save();
            //Read from file
            StreamReader reader = new StreamReader("C:\\Training\\Day 11\\sample.txt");
            // real all at once
            //string alllines = reader.ReadToEnd();
            while (!reader.EndOfStream)
            {
                string oneline = reader.ReadLine();
                Console.WriteLine(oneline);
            }
            reader.Close();
        }

        private static void Save()
        {
            //save info into a file
            string someData = "This is some data 4.";
            System.IO.StreamWriter writer = new System.IO.StreamWriter("C:\\Training\\Day 11\\sample.txt", append: true);
            try
            {
                writer.WriteLine(someData);
            }
            finally
            {
                writer.Close();
            }
        }
    }

    [Serializable]
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Location { get; set; }
        public string Mobile { get; set; }
    }
}
