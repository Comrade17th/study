using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace layer_list
{
    internal class Node
    {
        string name, phone;
        public Node(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Phone { get { return phone; } set { name = value; } }
        public Node Next { get; set; }
        public Node Next2 { get; set; }

        public string GetInfo()
        {
            return ($"{Name} {Phone}");
        }

        public string GetInfo(bool temp)
        {
            return ($"{Name} {Phone} {Next.Name} {Next2.Name}");
        }
    }
}
