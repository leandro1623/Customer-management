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
    public partial class fCostumers : Form
    {
        private Customer _editingCustomer;

        public fCostumers()
        {
            InitializeComponent();
        }
        public Customer EditingCustomer
        {
            get { return _editingCustomer; }
            set
            {
                _editingCustomer = value;
                bindSource.Add(_editingCustomer);
            }
        }
    }
}
