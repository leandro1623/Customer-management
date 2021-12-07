using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_clientes
{
    public class CustomersManager
    {
        public List<Customer> Customers { get; private set; }//customers list

        public CustomersManager()
        {
            Customers = new List<Customer>();
        }

        public bool AddCustomer(string name,string lastName,string address)
        {

            if (VerifyingData(name, lastName, address))
            {
                Customer _Customer = new Customer();
                _Customer.Name = name;
                _Customer.LastName = lastName;
                _Customer.Address = address;
                Customers.Add(_Customer);//adding a customer to the list of the customers
                _Customer.Create = true;
                return _Customer.Create;
            }
            else
            {
                return false;
            }
        }

        public bool VerifyingData(string name, string lastName, string address)
        {
            if(!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address)))
            {
                return true;
            }
            return false;
        }

        public void SetCustomer(int index, Customer editingCustomer)
        {
            Customers[index] = editingCustomer;
        }

        public void Delete(int index)
        {
            Customers.RemoveAt(index);
        }
    }
}
