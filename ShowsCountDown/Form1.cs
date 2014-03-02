using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowsCountDown
{
    public partial class AddShowForm : Form
    {
        public delegate void EventHandler(object sender, EventArgs args);
        public event EventHandler ThrowEvent = delegate { };

        public AddShowForm()
        {
            InitializeComponent();
            AllShows allShows = new AllShows();
            this.showListForm.DataSource = allShows.getShowList();

        }

        public string getSelectedShow()
        {
            return showListForm.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddShowFormButton_Click(object sender, EventArgs e)
        {
            ThrowEvent(this, new EventArgs());
        }

        private void CancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
