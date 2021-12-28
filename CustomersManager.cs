using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_clientes
{
    public class CustomersManager
    {
        private const string Path = "Gestion.txt";//Adress of the data base
        DataBase dataBase = new DataBase(Path);//making a data base
        public List<Customer> Customers { get; private set; }//customers list


        public CustomersManager()
        {
            Customers = new List<Customer>();
            this.Customers = GettingCustomers();

        }

        private void RefreshList()
        {
            Customers = GettingCustomers();
        }

        private List<Customer> GettingCustomers()
        {
            if (System.IO.File.Exists(Path))
            {
                List<Customer> ListOfCustomers = new List<Customer>();
                Customer customer = new Customer();

                string[] Content = System.IO.File.ReadAllLines(Path);
                foreach(string Line in Content)
                {
                    string[] Dates = Line.Split(';');

                    customer.Create = bool.Parse(Dates[0]);
                    customer.CreateDate = DateTime.Parse(Dates[1]);
                    customer.Name = Dates[2];
                    customer.LastName = Dates[3];
                    customer.Address = Dates[4];

                    //adding to the list
                    ListOfCustomers.Add(customer);
                }
                return ListOfCustomers;
            }
            return new List<Customer>();
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
                //Ading to data base
                dataBase.Add(_Customer.Create.ToString(),_Customer.CreateDate.ToLongDateString(),_Customer.Name,_Customer.LastName,_Customer.Address);
                //end
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

        public void SetCustomer(int index, Customer _Customer)
        {
            this.Delete(index);
            Customers.Insert(index,_Customer);
            dataBase.RecreateDataBase(this.Customers);
        }

        public void Delete(int index)
        {
            dataBase.DeleteEspecificLine(index);
            Customers.RemoveAt(index);
            this.RefreshList();
        }


    }
}
