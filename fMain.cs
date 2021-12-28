using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_clientes
{
    public partial class fMain : Form
    {
        private CustomersManager _customerManager = new CustomersManager();

        public fMain()
        {
            InitializeComponent();
            _Refresh();
        }

        private void _Refresh()
        {
            //looking for and showing all customers in the list of the customers
            lstCustomers.Items.Clear();
            List<Customer> customers = _customerManager.Customers;
            foreach (Customer customer in customers)
            {
                ListViewItem item = lstCustomers.Items.Add(customer.Name);
                item.SubItems.Add(customer.LastName);
                item.SubItems.Add(customer.Address);
                item.SubItems.Add(customer.CreateDate.ToString("dd/MM/yyyy"));

            }

            //disabling
            if (lstCustomers.Items.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            lstCustomers.Focus();
            lblCountOfCostumers.Text = _customerManager.Customers.Count.ToString();//number of customers what there are in the list
        }

        private void fMain_Activated(object sender, EventArgs e)
        {
            //btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)//refresh buton
        {
            _Refresh();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            fCostumers formCustomer = new fCostumers();
            formCustomer.EditingCustomer = new Customer();
            if(formCustomer.ShowDialog() == DialogResult.OK)
            {
                Customer customer = formCustomer.EditingCustomer;
                _customerManager.AddCustomer(customer.Name, customer.LastName, customer.Address);
                btnRefresh.PerformClick();
            }
        }

        private void Edit()
        {
            if (lstCustomers.SelectedIndices.Count == 0) { return; }

            int index = lstCustomers.SelectedIndices[0];
            Customer SelectCustomer = _customerManager.Customers[index];

            fCostumers formCustomers = new fCostumers();
            formCustomers.EditingCustomer = new Customer()
            {
                Name = SelectCustomer.Name,
                LastName = SelectCustomer.LastName,
                Address = SelectCustomer.Address
            };

            if(formCustomers.ShowDialog() == DialogResult.OK)
            {
                _customerManager.SetCustomer(index, formCustomers.EditingCustomer);
                btnRefresh.PerformClick();
            }
        }

        private void DeleteCustomer()
        {
            if (lstCustomers.SelectedIndices.Count == 0) { return; }

            int index = lstCustomers.SelectedIndices[0];
            _customerManager.Delete(index);
            btnRefresh.PerformClick();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstCustomers_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }
    }
}
