using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
    }
}
