using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_clientes
{
    public class Customer
    {
        public bool Create { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name{ get; set;}
        public string LastName { get; set; }
        public string Address { get; set; }
        public Customer()
        {
            CreateDate = DateTime.Now;
        }
    }
}
