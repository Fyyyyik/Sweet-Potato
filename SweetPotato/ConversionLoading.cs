using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweet_potato.SweetPotato
{
    public partial class Converting : Form
    {
        public static Converting instance;

        public Converting()
        {
            InitializeComponent();
            this.Load += this.ld_Converting;
        }

        void ld_Converting(object sender, EventArgs e)
        {
            instance = this;
            MainForm.instance.UpdateColor(false);
            this.CenterToScreen();
        }
    }
}
