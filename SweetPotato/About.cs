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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Load += this.ld_About;
        }

        void ld_About(object sender, EventArgs e)
        {
            MainForm.instance.UpdateColor(false);
            this.CenterToScreen();
        }
    }

    public class FormSingletonAbout
    {
        private static About instance;

        public static About Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new About();
                }
                return instance;
            }
        }
    }
}
