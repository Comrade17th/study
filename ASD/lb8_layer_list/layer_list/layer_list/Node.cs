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
            string next = "null";
            string next2 = "null";
            if (Next != null)
                next = Next.Name;
            if (Next2 != null)
                next2 = Next2.Name;
            return ($"{Name} {Phone} ||| {next} {next2}");
        }

    }
}
